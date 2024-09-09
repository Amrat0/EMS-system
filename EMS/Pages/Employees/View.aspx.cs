using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using DatabaseConnection;

 /*Conneted Mode: inside it woh hum manullay open or close karwata ha or Disconneted ka under automatically maintain open and close  */

namespace EMS.Pages.Employees
{
    public partial class View : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["employeeInfo"] == null)
                Response.Redirect("../../Unauthorize.aspx");
            if(!Page.IsPostBack)
                BindData();
        } 

        protected void employeeGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            employeeGridView.EditIndex = e.NewEditIndex;
            BindData();
        }
        private void BindData()
        {
            string selectQuery = "Select id, name, address, designation, deptId, isAdmin, salary, tenure from Employee";
            SqlCommand command = new SqlCommand(selectQuery, DBConnection.GetSqlConnection());
            /* DataAdapter automatically it self connection build and set & take string and open and closed it*/
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);

            DataSet ds = new DataSet();
            sqlDataAdapter.Fill(ds, "Employee");

            employeeGridView.DataSource = ds;
            employeeGridView.DataBind();
        }

        protected void employeeGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            employeeGridView.EditIndex = -1;
            BindData();
         

        }

        protected void employeeGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
                
            try
            {
                string id = employeeGridView.Rows[e.RowIndex].Cells[1].Text; 
                TextBox name = (TextBox)employeeGridView.Rows[e.RowIndex].Cells[2].Controls[0];
                TextBox address = (TextBox)employeeGridView.Rows[e.RowIndex].Cells[3].Controls[0];
                TextBox designation = (TextBox)employeeGridView.Rows[e.RowIndex].Cells[4].Controls[0];
                DropDownList departmentId = (DropDownList)employeeGridView.Rows[e.RowIndex].FindControl("ddldepartment");
                CheckBox isadmin = (CheckBox)employeeGridView.Rows[e.RowIndex].Cells[7].Controls[0];
                TextBox salary = (TextBox)employeeGridView.Rows[e.RowIndex].FindControl("textSalary");
                TextBox tenure = (TextBox)employeeGridView.Rows[e.RowIndex].FindControl("textTenure");


                string query = "UPDATE [dbo].[Employee] " +
                                   " SET[Name] = @name " +
                                   ",[Address] = @address " +
                                   ",[Designation] = @designation " +
                                   ",[DeptId] = @deptId " +
                                   ",[isAdmin] = @isadmin " +
                                   ",[salary] = @salary " +
                                   ",[tenure] = @tenure " +

                               "WHERE Id =@id";
                SqlCommand command = new SqlCommand(query, DBConnection.GetSqlConnection());
                command.Parameters.AddWithValue("@name", name.Text);
                command.Parameters.AddWithValue("@address", address.Text);
                command.Parameters.AddWithValue("@designation", designation.Text);
                command.Parameters.AddWithValue("@deptId", departmentId.Text);
                command.Parameters.AddWithValue("@isadmin", isadmin.Checked);
                command.Parameters.AddWithValue("@salary", salary.Text);
                command.Parameters.AddWithValue("@tenure", tenure.Text);

                command.Parameters.AddWithValue("@id", id);
                DBConnection.GetSqlConnection().Open();
                command.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
          

            }
            finally
            {
                DBConnection.GetSqlConnection().Close();
                employeeGridView.EditIndex = -1;
                BindData();

            }
        }

        protected void employeeGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if(e.Row.RowType == DataControlRowType.DataRow)
            {
                Label departIdVal = (Label)e.Row.FindControl("lblDepartmentId");
                DropDownList ddldepartment = (DropDownList)e.Row.FindControl("ddldepartment");
                ddldepartment.SelectedIndex = int.Parse(departIdVal.Text);


            }
        }

        protected void employeeGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
        
            string name = employeeGridView.SelectedRow.Cells[2].Text;
            string address = employeeGridView.SelectedRow.Cells[3].Text;
            string designation = employeeGridView.SelectedRow.Cells[4].Text;
            DropDownList department = (DropDownList)employeeGridView.SelectedRow.Cells[5].FindControl("ddldepartment");
            CheckBox isadmin = (CheckBox)employeeGridView.SelectedRow.Cells[7].Controls[0];

            content.InnerHtml = string.Format("<b>Name: </b> {0} <br />" +
               "<b>Address: </b> {1} <br />" +
               "<b>Designation: </b> {2} <br />" +
               "<b>Department: </b> {3} <br />" +
               "<b>Admin: </b> {4} <br />"
               , name,address,designation,department.SelectedItem.Text,isadmin.Checked );
        }

        protected void employeeGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            employeeGridView.PageIndex = e.NewPageIndex;
            BindData();
        }
    }
}