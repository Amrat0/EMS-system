using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using DatabaseConnection;
using EMS.Model;

namespace EMS.Pages.Employees
{
    public partial class Add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["employeeInfo"] == null)
                Response.Redirect("../../Unauthorize.aspx");
            else
            {
                Employee employee = new Employee();
                employee = (Employee)Session["employeeInfo"];
                if (!employee.isAdmin)
                    Response.Redirect("../../Unauthorize.aspx");

            }
            ddldepartment.Items.Add(new ListItem("HR", "1"));
            ddldepartment.Items.Add(new ListItem("Finance", "2"));
            ddldepartment.Items.Add(new ListItem("Marketing", "3"));
            ddldepartment.Items.Add(new ListItem("IT", "4"));


            //onClick and onClientClick  different onClientClick is client side ka uper koi action perform karna hoto through javascript onClick use for server side request.
        }

        protected void createEmployee_Click(object sender, EventArgs e)
        {
            if (!validateUserNm.IsValid || !nameReq.IsValid){
                message.InnerText = nameReq.ErrorMessage;
                return;
            }
            string userName = txtUserName.Text;
            string name = txtname.Text;
            string address = txtaddress.Text;
            string designation = txtdesignation.Text;
            bool checkAdmin = false;

            if (isAdmin.Checked)
                checkAdmin = true;
            string insertQuery = "" +
            string.Format("INSERT INTO[dbo].[Employee] " +        
                   "([UserName]" +
                   ",[Name] " +
                   ",[Password] " +
                   ",[Address] " +
                   ",[Designation] " +
                   ",[DeptId] " +
                   ",[isAdmin]) " +
            "VALUES " +
                   "('{0}'" +
                   ",'{1}' " +
                   ",'{2}' " +
                   ",'{3}' " +
                   ",'{4}' " +
                   ",'{5}' " +
                   ",'{6}' ) ", userName,name,txtpassword.Text,address, designation,ddldepartment.SelectedValue.ToString(), checkAdmin);

            try
            {
                //connection open karwna ha
                DBConnection.GetSqlConnection().Open();
                if (CheckUser(userName)){
                    message.InnerText = "!User Name already exists! ";
                    DBConnection.GetSqlConnection().Close();
                    return;
                }
                //sqlCommand aik class ha jo ka humay command babati ha query ki
                SqlCommand command = new SqlCommand(insertQuery, DBConnection.GetSqlConnection());
                //executeNonQuery: is used for Select Query like, nonQuery is Update,Insert,Delete,
                //Sclar Reader: is used for transectional data many data used it for push 
                command.ExecuteNonQuery();
                message.InnerText = "Employee added successfully!";
                txtUserName.Text = "";
                txtaddress.Text = "";
                txtdesignation.Text = "";
                txtname.Text = "";
                txtpassword.Text = "";
                ddldepartment.SelectedIndex = -1; //set default
                isAdmin.Checked = false;
            }
            catch (Exception ex)
            {
                //loc for net .dl : automatically login ka mechnisum provde kartii ha static function hota ha
                message.InnerText = "Error creating employee! Please contact system administrator! ";
            }
            finally
            {
                DBConnection.GetSqlConnection().Close();
            }
        }
        private bool CheckUser (string userName)
        {
            bool exists = false;
            string query = string.Format("Select 1 from Employee where username='{0}'", userName);
            SqlCommand command = new SqlCommand(query, DBConnection.GetSqlConnection());
            SqlDataReader sqlDataReader = command.ExecuteReader();
            if (sqlDataReader.HasRows)
                exists = true;
            sqlDataReader.Close();
            return exists;
        }
    }
}  