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
    public partial class ManageEmpRole : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (User.Identity.GetUserId() == null)
            {
                Response.Redirect("/Account/Login.aspx");
            }
            if (!IsPostBack)
            {
                DropDownList1.Items.Insert(0, new ListItem("Select Doctor / Nurse ...", "0"));
                if (Request["EID"] != null || Request["EID"] != "")
                {
                    txtEmpID.Text = Request["EID"];
                    if (txtEmpID.Text != null || txtEmpID.Text != "")
                    {
                        DropDownList1.SelectedValue = txtEmpID.Text;
                    }
                }
                else
                {
                    inetVal();
                }
                gvEmpServiceFill();
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
                switch (eid)
                {
                    case "1":
                        
                        break;
                    case "2":
                        Response.Redirect("/Menus.aspx");
                        break;
                    case "3":
                        Response.Redirect("/PatientTicket.aspx");
                        break;
                    case "4":
                        Response.Redirect("/PatientTicket.aspx");
                        break;
                    case "5":
                        Response.Redirect("/CreateNewReceipt.aspx");
                        break;
                    default:
                        lblmsg.Text = "Access Denied!";
                        lblmsg.DataBind();
                        break;
                }

                con.Close();
            }
            else
            {
                lblmsg.Text = "Access Denied!";
                lblmsg.DataBind();
            }
        }

        protected void btnPAdd_Click(object sender, EventArgs e)
        {



            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            
            string kind = null;
            for (int i = 0; i < chkServices.Items.Count; i++)
            {
                if (chkServices.Items[i].Selected)
                {
                    con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
                    cmd = new SqlCommand("select KID from services where SID='" + chkServices.Items[i].Value + "'", con);
                    con.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        kind = Convert.ToString(dr["KID"]);
                        con.Close();
                        cmd = new SqlCommand("spINSERT_dbo_Clinic", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CLID", txtCLID.Text);
                        cmd.Parameters.AddWithValue("@EID", txtEmpID.Text);
                        cmd.Parameters.AddWithValue("@KID", kind);
                        cmd.Parameters.AddWithValue("@SID", chkServices.Items[i].Value);
                        con.Open();

                        int k = cmd.ExecuteNonQuery();
                        if (k != 0)
                        {
                            lblmsg.Text = "Record Inserted Succesfully into the Database";
                            lblmsg.ForeColor = System.Drawing.Color.CornflowerBlue;
                            lblmsg.Visible = true;
                            con.Close();
                        }
                        con.Close();

                    }
                }
            }
            
            gvEmpServiceFill();
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

        protected void gvEmpServiceFill()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) from Employees where EID = '" + txtEmpID.Text + "'", con);
            con.Open();
            int userCount = (int)cmd.ExecuteScalar();
            con.Close();
            if (userCount != 0)
            {
                DataTable dt = new DataTable();
                dt = GetDataTable("SELECT Clinic.EID,Clinic.CLID,Clinic.SID,(Services.Name+' '+Services.ArName) AS Service,Clinic.KID,(serviceKind.Name+' '+serviceKind.ArName) AS Kind FROM Employees,Clinic,services,serviceKind where Clinic.EID = '" + txtEmpID.Text + "' AND Employees.EID=Clinic.EID AND Services.SID=Clinic.SID AND ServiceKind.KID=Clinic.KID AND Services.KID=ServiceKind.KID");
                con.Close();
                
                gvEmpService.DataSource = dt;
                gvEmpService.DataBind();
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) from Employees where EID = '" + txtEmpID.Text + "'", con);
        }

        protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
        {

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedIndex == 0)
            {
                txtEmpID.DataBind();
                txtEmpID.Text = "";
                gvEmpService.DataBind();
            }
            else
            {
                inetVal();
            }
        }
        private void inetVal()
        {
            txtEmpID.DataBind();
            txtEmpID.Text = DropDownList1.SelectedValue;
            gvEmpServiceFill();
        }
        protected void txtEmpID_TextChanged(object sender, EventArgs e)
        {
            gvEmpServiceFill();
        }
    }
}