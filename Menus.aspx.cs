using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ESCARE
{
    public partial class Menus : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (User.Identity.GetUserId() == null)
            {
                Response.Redirect("/Account/Login.aspx");
            }
            if (!IsPostBack)
            {
                checkRole();
            }
        }
        private void checkRole()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand("SELECT Profition from Employees where EID=(select EID from AspNetUsers where id='" + User.Identity.GetUserId() + "')", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string eid = Convert.ToString(dr["Profition"]);
                lblmsg.Text = eid;
                lblmsg.DataBind();
                con.Close();
            }
        }

        protected void btnCheckReceipts_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterClientScriptBlock(Page.GetType(), "popup_receipts", "<script type=\"text/javascript\">var nw = window.open('RptPrintOut?sRef=Receipt&ReceiptID=000001', \"MyWindowID\", \"fullscreen = 0, toolbar = 0, menubar = 1, status = 1\");</script>");
        }
        protected void btnManageEmpClinic_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterClientScriptBlock(Page.GetType(), "popup_Manage_Clinic", "<script type=\"text/javascript\">var nw = window.open('ManageEmpRole', \"MyWindowID\", \"fullscreen = no, toolbar = 0, menubar = 0, status = 0\");</script>");
        }

        protected void btnAddNewEmployee_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterClientScriptBlock(Page.GetType(), "popup_Add_New_Employee", "<script type=\"text/javascript\">var nw = window.open('AddNewEmployee', \"MyWindowID\", \"fullscreen = 0, toolbar = 0, menubar = 0, status = 0\");</script>");
        }

        protected void btnCheckEmployees_Click(object sender, EventArgs e)
        {

        }
    }
}