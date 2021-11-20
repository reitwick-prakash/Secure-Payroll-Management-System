using Payroll_Sys.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Payroll_Sys
{
    [Authorize(Roles = MyConstants.RoleEmployee)]
    public partial class payslip : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed2_Click(object sender, EventArgs e)
        {
            string Firstname = emp.SelectedItem.Text;
            string email = emp.SelectedItem.Text;
            string role = emp.SelectedValue;

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=aspnet-Payroll Sys-20211117120929;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.AspNetUsers WHERE Email= '" + email + "'", con);
            //cmd.Parameters.Add("@role",System.Data.SqlDbType.NChar,10).Value
            SqlDataReader result = cmd.ExecuteReader();
            result.Read();

            double Salary = double.Parse(result["Salary"].ToString());
            double tax = Salary * (30 / 100);

            Session["Salary"] = Salary;

            Session["tax"] = tax;

            Session["Firstname"] = Firstname;
           
            Response.Redirect("get_payslip.aspx");
        }
    }
}