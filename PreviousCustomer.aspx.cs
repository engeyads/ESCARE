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
    public partial class PreviousCustomer : Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (User.Identity.GetUserId() == null)
            {
                Response.Redirect("/Account/Login.aspx");
            }

            
            if (!IsPostBack)
            {
                
               
                return;
            } else
            {

            }

        }

        

        private DataTable GetDataTable(string cmdText)
        {
            string sConstring = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlDataAdapter SqlAdp = new SqlDataAdapter("", sConstring);
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

        protected void getTblPFiles()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) from patient where PID like '%" + txtPID.Text + "%'", con);
            int userCount = 0;
            DataTable dtt = new DataTable();
            
                    con.Open();
                    userCount = (int)cmd.ExecuteScalar();
                    con.Close();
                    if (userCount != 0)
                    {
                        dtt = GetDataTable("SELECT patient.PID, (patient.FName+' '+patient.MName+' '+patient.LName) AS EnName,patient.Profition, patient.DOB FROM patient,countries where patient.PID like '%" + txtPID.Text + "%' AND countries.ID = patient.Nationality");
                        lblmsg.Text = "Found!";
                        lblmsg.ForeColor = System.Drawing.Color.CornflowerBlue;
                        lblmsg.Visible = true;
                    }
                    else
                    {
                        lblmsg.Text = "No Reports Existed!";
                        lblmsg.ForeColor = System.Drawing.Color.Red;
                        lblmsg.Visible = true;
                    }
                    

            gvPList.DataSource = dtt;
            gvPList.DataBind();
            con.Close();

        }

        private string getEmpID(String username)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand("SELECT EID from AspNetUsers where  username='" + username + "'", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string eid = Convert.ToString(dr["EID"]).Trim();
                con.Close();
                return eid;
                    
            } else
                con.Close();
            return null;
        }

        

        protected void btnDone_Click(object sender, EventArgs e)
        {
            string close = @"<script type='text/javascript'>
                                window.returnValue = true;
                                window.close();
                                </script>";
            base.Response.Write(close);
        }


    
        

        protected void txtPID_TextChanged(object sender, EventArgs e)
        {
            getTblPFiles();
        }

        private void gvPList_Fill()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) from DReports where PID like '%" + txtPID.Text + "%'", con);
            int userCount = 0;
            DataTable dtt = new DataTable();

            con.Open();
            userCount = (int)cmd.ExecuteScalar();

            if (userCount != 0)
            {
                dtt = GetDataTable("SELECT DREports.REID, (Employees.FNAME+' '+Employees.LName) AS 'By Doctor',(Patient.FName+' '+Patient.LName) AS Patient, DReports.Date from DReports,Employees,Patient where Patient.PID=DReports.PID AND DReports.EID=Employees.EID AND DReports.PID = '" + gvPList.SelectedRow.Cells[1].Text + "'");


                gvPReports.DataSource = dtt;
                gvPReports.DataBind();

                lblmsg.Text = "found!";
                lblmsg.ForeColor = System.Drawing.Color.CornflowerBlue;
                lblmsg.Visible = true;
            }
            else
            {
                lblmsg.Text = "no reports found!";
                lblmsg.ForeColor = System.Drawing.Color.Red;
                lblmsg.Visible = true;
            }


            con.Close();
        }

        protected void gvPList_SelectedIndexChanged(object sender, EventArgs e)
        {
            gvPList_Fill();
        }

        protected void btnPrintReport_Click(object sender, EventArgs e)
        {

        }

        protected void btnPrintMidic_Click(object sender, EventArgs e)
        {

        }

        protected void grdWasfa_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void txtMedicalReport_TextChanged(object sender, EventArgs e)
        {

        }

        protected void AddNewRow_Click(object sender, EventArgs e)
        {

        }

        private void gvPReports_Fill()
        {
            string report = null;

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) from DReports where PID like '%" + txtPID.Text + "%'", con);
            int userCount = 0;
            DataTable dt = new DataTable();

            con.Open();
            userCount = (int)cmd.ExecuteScalar();

            if (userCount != 0)
            {
                cmd = new SqlCommand("SELECT description from DReports where REID = '" + gvPReports.SelectedRow.Cells[1].Text + "'", con);
                
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    report = Convert.ToString(dr["description"]);
                }
                txtMedicalReport.Text = report;
                

                lblmsg.Text = "found!";
                lblmsg.ForeColor = System.Drawing.Color.CornflowerBlue;
                lblmsg.Visible = true;
                
            }
            else
            {
                lblmsg.Text = "no reports found!";
                lblmsg.ForeColor = System.Drawing.Color.Red;
                lblmsg.Visible = true;
            }


            con.Close();
        }

        protected void gvPReports_SelectedIndexChanged(object sender, EventArgs e)
        {
            gvPReports_Fill();
        }

        protected void gvPList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvPList.PageIndex = e.NewPageIndex;
            gvPList.DataBind();
            getTblPFiles();
        }
        protected void gvPReports_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvPReports.PageIndex = e.NewPageIndex;
            gvPReports.DataBind();
            gvPList_Fill();
        }
    }
}