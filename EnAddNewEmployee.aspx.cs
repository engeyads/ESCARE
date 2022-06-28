using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
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
using ESCARE.Models;

namespace ESCARE
{
    public partial class EnAddNewEmployee : Page
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
            txtDOB.Attributes.Add("readonly", "readonly");
        }

        private void checkRole()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand("SELECT Profition from Employees where EmpID=(select EID from AspNetUsers where id='" + User.Identity.GetUserId() + "')", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string eid = Convert.ToString(dr["Profition"]);
                //lblmsg.Text = eid;
                //lblmsg.DataBind();
                switch (eid)
                {
                    case "01":

                        break;
                    case "02":
                        Response.Redirect("/Menus.aspx");
                        break;
                    case "03":
                        Response.Redirect("/PatientTicket.aspx");
                        break;
                    case "04":
                        Response.Redirect("/PatientTicket.aspx");
                        break;
                    case "05":
                        Response.Redirect("/Default.aspx");
                        break;
                    case "06":
                        Response.Redirect("/Default.aspx");
                        break;
                    case "07":
                        Response.Redirect("/Default.aspx");
                        break;
                    case "08":

                        break;
                    default:
                        //lblmsg.Text = "Access Denied!";
                        //lblmsg.DataBind();
                        break;
                }

                con.Close();
            }
            else
            {
                //lblmsg.Text = "Access Denied!";
                //lblmsg.DataBind();
            }
        }

        protected void AddNewEmp()
        {

            string d = txtDOB.Text.ToString();
            DateTime localDate = DateTime.Now;
            DateTime DOBDate = DateTime.Parse(d);

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) from Employees where EID = '" + txtEID.Text + "'", con);


            con.Open();
            int userCount = (int)cmd.ExecuteScalar();
            con.Close();
            if (userCount != 0)
            {
                lblmsg.Text = "Record Already Exist";
                lblmsg.ForeColor = System.Drawing.Color.Red;
                lblmsg.Visible = true;
            }
            else
            {
                cmd = new SqlCommand("spINSERT_dbo_Employees", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EID", txtEID.Text);
                cmd.Parameters.AddWithValue("@FName", txtEnFName.Text);
                cmd.Parameters.AddWithValue("@MName", txtEnMName.Text);
                cmd.Parameters.AddWithValue("@TName", txtEnTName.Text);
                cmd.Parameters.AddWithValue("@LName", txtEnLName.Text);
                cmd.Parameters.AddWithValue("@ArFName", txtArFName.Text);
                cmd.Parameters.AddWithValue("@ArMName", txtArMName.Text);
                cmd.Parameters.AddWithValue("@ArTName", txtArTName.Text);
                cmd.Parameters.AddWithValue("@ArLName", txtArLName.Text);
                cmd.Parameters.AddWithValue("@Mobile", txtMobile.Text);
                cmd.Parameters.AddWithValue("@Tel", txtTel.Text);
                cmd.Parameters.AddWithValue("@Nationality", ddlNationalityName.SelectedValue);
                cmd.Parameters.AddWithValue("@Profition", ddlRole.SelectedValue);
                cmd.Parameters.AddWithValue("@Manager", ddlManager.SelectedValue);
                cmd.Parameters.AddWithValue("@Discount", txtDisAmt.Text);
                cmd.Parameters.AddWithValue("@Available", 1);
                cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@DOB", DOBDate);
                cmd.Parameters.AddWithValue("@JoinDate", localDate);
                con.Open();

                int k = cmd.ExecuteNonQuery();
                if (k != 0)
                {
                    lblmsg.Text = "Record Inserted Succesfully into the Database";
                    lblmsg.ForeColor = System.Drawing.Color.CornflowerBlue;
                    lblmsg.Visible = true;
                }
                con.Close();

                cmd = new SqlCommand("SELECT TOP 1 EmpID from Employees ORDER BY EmpID DESC", con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    string EmpID = Convert.ToString(dr["EmpID"]);

                    var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                    var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
                    var user = new ApplicationUser() { UserName = txtUser.Text, Email = txtEmail.Text, EID = EmpID };
                    IdentityResult result = manager.Create(user, txtPass.Text);
                    if (result.Succeeded)
                    {
                        lblmsg.Text = "Record Inserted Succesfully into the Database";
                        lblmsg.ForeColor = System.Drawing.Color.CornflowerBlue;
                        lblmsg.Visible = true;
                    }
                    else
                    {
                        lblmsg.Text = "Error";
                    }
                }
                con.Close();
            }



        }

        private DataTable GetDataTable(string cmdText)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            SqlDataAdapter SqlAdp = new SqlDataAdapter("", con);
            DataTable DT = new DataTable();
            try
            {
                SqlAdp.SelectCommand.CommandText = cmdText;
                SqlAdp.Fill(DT);
            }
            finally
            {
                if (SqlAdp != null)
                    SqlAdp.Dispose();
                if (DT != null)
                    DT.Dispose();
            }
            return DT;
        }

        protected void InsertDataToManager()
        {
            DataTable dt = GetDataTable("select EmpID,(ArFName+' '+ArMName+' '+ArLName) as ArName from Employees where Profition='" + ddlRole.SelectedValue + "'");
            if (dt.IsInitialized)
            {
                ddlManager.DataSource = dt;
                ddlManager.DataTextField = "ArName";
                ddlManager.DataValueField = "EmpID";
                ddlManager.DataBind();
                ddlManager.Items.Insert(0, new ListItem("-- اختر المدير --", ""));
            }
        }

        //protected void btnCheck_Click(object sender, EventArgs e)
        //{
        //    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        //    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) from Employees where EID like '%" + txtEmpID.Text + "%' or Mobile like '%" + txtEmpMobile.Text + "%'", con);
        //    con.Open();
        //    int userCount = (int)cmd.ExecuteScalar();
        //    con.Close();
        //    if (userCount != 0)
        //    {
        //        lblmsg.Text = "Found!";
        //        lblmsg.ForeColor = System.Drawing.Color.CornflowerBlue;
        //        lblmsg.Visible = true;

        //        DataTable dt = new DataTable();
        //        dt = GetDataTable("SELECT Employees.EID, (Employees.FName+' '+Employees.MName+' '+Employees.LName) AS EnName, (Employees.ArFName+' '+Employees.ArMName+' '+Employees.ArLName) AS ArName, Employees.Mobile, countries.Name, Employees.Profition, Employees.Blood, Employees.Address, Employees.DOB, Employees.InDate FROM Employees,countries where EID like '%" + txtEmpID.Text + "%' AND countries.ID = Employees.Nationality");

        //        gvPList.DataSource = dt;
        //        gvPList.DataBind();
        //        con.Close();

        //    }
        //    else
        //    {
        //        lblmsg.Text = "Record Not Existed";
        //        lblmsg.ForeColor = System.Drawing.Color.Red;
        //        lblmsg.Visible = true;
        //    }
        //}

        //protected void btnUpdate_Click(object sender, EventArgs e)
        //{
        //    ClientScript.RegisterClientScriptBlock(Page.GetType(), "popup_ManageClinic", "<script type=\"text/javascript\">var nw = window.open('ManageEmpRole.aspx?&EID=" + txtEmpID.Text + "', \"MyWindowID\", \"fullscreen = no, toolbar = no, menubar = no, status = no\");</script>");
        //}

        protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
        {

        }

        protected void ddlRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            InsertDataToManager();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (txtPass.Text == txtCPass.Text && txtPass.Text != "" && txtUser.Text != "" && txtArFName.Text != "" && txtArLName.Text != "" && txtEnFName.Text != "" && txtEnLName.Text != "")
            {
                if (txtDisAmt.Text == "")
                {
                    txtDisAmt.Text = "0";
                }
                else if (Convert.ToDouble(txtDisAmt.Text) > 70)
                {
                    txtDisAmt.Text = "70";
                }
                else if (Convert.ToDouble(txtDisAmt.Text) < 0)
                {
                    txtDisAmt.Text = "0";
                }
                AddNewEmp();
            }
        }
        protected void ddlNationalityName_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtNationalityID.Text = ddlNationalityName.SelectedValue;
        }
        protected void txtNationalityID_TextChanged(object sender, EventArgs e)
        {
            ddlNationalityName.SelectedValue = txtNationalityID.Text;
        }
    }
}