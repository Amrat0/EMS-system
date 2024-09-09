using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EMS.Model;
namespace EMS
{
    public partial class EMS : System.Web.UI.MasterPage
    {
       public bool isAdmin = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            Employee employee = new Employee();
            employee = (Employee)Session["employeeInfo"];
            if (employee != null)
            {
                isAdmin = employee.isAdmin;
            }
        }
    }
}