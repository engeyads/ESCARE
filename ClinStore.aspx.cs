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
    public partial class ClinStore : Page
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
        private string getUserID()
        {
            string eid = "false";
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand("SELECT EmpID from Employees where EmpID=(select EID from AspNetUsers where id='" + User.Identity.GetUserId() + "')", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                eid = Convert.ToString(dr["EmpID"]);
            }
            return eid;
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

        public DateTime ParseDate(string date)
        {
            DateTimeFormatInfo dateFormatProvider = new DateTimeFormatInfo();
            dateFormatProvider.ShortDatePattern = "dd/MM/yyyy";
            return DateTime.Parse(date, dateFormatProvider);
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

        protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
        {

        }

        protected void InsertStore()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand("spUPDATE_dbo_UClinicStore", con);
                cmd.CommandType = CommandType.StoredProcedure;
            
                cmd.Parameters.AddWithValue("@CLID", ddlClin.SelectedValue);
                cmd.Parameters.AddWithValue("@STID", ddlStore.SelectedValue);
                con.Open();

                int k = cmd.ExecuteNonQuery();
                if (k != 0)
                {
                    lblmsg.Text = "Record Inserted Succesfully into the Database";
                    lblmsg.ForeColor = System.Drawing.Color.CornflowerBlue;
                    lblmsg.Visible = true;
                }
                con.Close();
            
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            InsertStore();
        }

        private void OnDSUpdatedHandler(Object source, SqlDataSourceStatusEventArgs e)
        {
            if (e.AffectedRows > 0)
            {

            }
            else
            {

            }
        }

        protected void txtClin_TextChanged(object sender, EventArgs e)
        {
            ddlClin.DataBind();
            ddlClin.SelectedValue = txtClin.Text;
        }

        protected void ddlClin_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtClin.DataBind();
            txtClin.Text = ddlClin.SelectedValue;
        }

        protected void txtStore_TextChanged(object sender, EventArgs e)
        {
            ddlStore.DataBind();
            ddlStore.SelectedValue = txtStore.Text;
        }

        protected void ddlStore_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtStore.DataBind();
            txtStore.Text = ddlStore.SelectedValue;
        }

        

        protected void btnClinics_Click(object sender, EventArgs e)
        {
            Response.Redirect("Clinics.aspx");
        }

        protected void btnStore_Click(object sender, EventArgs e)
        {
            Response.Redirect("store.aspx");
        }

        protected void btnServices_Click(object sender, EventArgs e)
        {
            Response.Redirect("Services.aspx");
        }

        protected void btnClinEmp_Click(object sender, EventArgs e)
        {
            Response.Redirect("ClinicDoctor.aspx");
        }

    }
}