using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ESCARE
{
    public partial class _Default : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (User.Identity.GetUserId() == null)
            {
                Response.Redirect("/Account/Login.aspx");
            }

            Label1.Text = getUserFullName();

        }
        protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            insertLog(3, "Normal Logout");
            Context.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        }
        protected string getUserFullName()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand("SELECT (Employees.ArFName+' '+Employees.ArLName) as ArName from Employees,AspNetUsers where AspNetUsers.Id='" + Context.User.Identity.GetUserId() + "' and Employees.EmpID = AspNetUsers.EID", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string name = Convert.ToString(dr["ArName"]).Trim();
                con.Close();
                return name;

            }
            else
                con.Close();
            return null;
        }
        public static string getclientIP()
        {
            string result = string.Empty;
            string ip = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            
            if (!string.IsNullOrEmpty(ip))
            {
                string[] ipRange = ip.Split(',');
                int le = ipRange.Length - 1;
                result = ipRange[0];
            }
            else
            {
                result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }

            return result;
        }
        public static string DetermineCompName(string IP)
        {
            IPAddress myIP = IPAddress.Parse(IP);
            IPHostEntry GetIPHost = Dns.GetHostEntry(myIP);
            List<string> compName = GetIPHost.HostName.ToString().Split('.').ToList();
            return compName.First();
        }
        private void insertLog(int st, string des)
        {
            string ip = getclientIP();
            string CN = DetermineCompName(ip);
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand("spINSERT_dbo_Logs", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserName", Context.User.Identity.GetUserName());
            cmd.Parameters.AddWithValue("@status", st);
            cmd.Parameters.AddWithValue("@des", des);
            cmd.Parameters.AddWithValue("@IPAddress", ip); 
            cmd.Parameters.AddWithValue("@CN", CN);
            con.Open();

            int k = cmd.ExecuteNonQuery();
            if (k != 0)
            {

            }
            con.Close();
        }
    }
}