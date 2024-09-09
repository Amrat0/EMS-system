using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DatabaseConnection;
using System.Data.SqlClient;
using EMS.Model;

namespace EMS
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submit_Click(object sender, EventArgs e)
        {
            try
            {
                string userName = txtuserName.Text;
                string password = txtpassword.Text;

                string query = "Select ID, Name, isAdmin from Employee where username = @username and password = @password";
                SqlCommand command = new SqlCommand(query, DBConnection.GetSqlConnection());
                command.Parameters.AddWithValue("@username", userName);
                command.Parameters.AddWithValue("@password", password);
                DBConnection.GetSqlConnection().Open();

                SqlDataReader dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
      /*session manage login logout from employe */
                    dataReader.Read();
                    Employee employee = new Employee();
                    employee.ID = dataReader.GetInt32(0);
                    employee.Name = dataReader.GetString(1);
                    employee.isAdmin = dataReader.GetBoolean(2);
                    Session["employeeInfo"] = employee;
                    Response.Redirect("/Pages/Home.aspx");
                }
                else
                {
                    output.InnerText = "Invaild username/ or password!";
                }
                dataReader.Close();
            }
            catch(Exception ex)
            {
                output.InnerText = "Unhandled Exception!";
            }
            finally
            {
                DBConnection.GetSqlConnection().Close();
            }
            
        }
    }
}