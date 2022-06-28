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
    public partial class PatientTicket : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (User.Identity.GetUserId() == null)
            {
                Response.Redirect("/Account/Login.aspx");
            }

            if (!IsPostBack)
            {
                getProf();
                checkRole();
                getPatientPendingTickets();
                gvPendingPatients.DataBind();
                return;
            }
        }

        private void getProf()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand("SELECT Profition from Employees where EID=(select EID from AspNetUsers where id='" + User.Identity.GetUserId() + "')", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                HiddenField1.Value = Convert.ToString(dr["Profition"]);
            }
            con.Close();
        }
        private void checkRole()
        {
            
            switch (HiddenField1.Value)
            {
                case "1":
                    Response.Redirect("/Menus.aspx");
                    break;
                case "2":
                    Response.Redirect("/Menus.aspx");
                    break;
                case "3":

                    break;
                case "4":
                    btnRecipe.Enabled = false;
                    break;
                case "5":
                    Response.Redirect("/CreateNewReceipt.aspx");
                    break;
                default:

                    break;
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

        protected void getPatientPendingTickets()
        {
            DataTable dtt = new DataTable();
            if (HiddenField1.Value == "3")
            {
                
                dtt = GetDataTable("SELECT patient.PID, (patient.FName+' '+patient.MName+' '+patient.LName) AS EnName, (patient.ArFName+' '+patient.ArMName+' '+patient.ArLName) AS ArName , PD.CLID, PD.Date from patient,PD where patient.pid=pd.pid and pd.AV=1 and pd.EID =(select EID from AspNetUsers where UserName='" + User.Identity.GetUserName() + "')");
                
                
            }
            if (HiddenField1.Value == "4")
            {
                
                dtt = GetDataTable("SELECT patient.PID, (patient.FName+' '+patient.MName+' '+patient.LName) AS EnName, (patient.ArFName+' '+patient.ArMName+' '+patient.ArLName) AS ArName , PD.CLID, PD.Date from patient,PD,employees where patient.pid=pd.pid and pd.AV=1 and pd.EID =employees.Managr and employees.eid=(select EID from AspNetUsers where UserName='" + User.Identity.GetUserName() + "')");
                
                
            }
            
            gvPendingPatients.DataSource = dtt;
            gvPendingPatients.DataBind();
        }

        protected void gvPList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvPendingPatients.PageIndex = e.NewPageIndex;
            gvPendingPatients.DataBind();
            getPatientPendingTickets();
        }
        protected void gvPList_SelectedIndexChanged(object sender, EventArgs e)
        {

            string CLID = gvPendingPatients.SelectedRow.Cells[4].Text;
            string PID = gvPendingPatients.SelectedRow.Cells[1].Text;
            string EID = User.Identity.GetUserName();

            ClientScript.RegisterClientScriptBlock(Page.GetType(), "popup_MedicalReport", "<script type=\"text/javascript\">var nw = window.open('~/MedicalReport.aspx?CLID=" + CLID + "&PID=" + PID + "&EID=" + EID + "', \"MyWindowID\", \"fullscreen = no, toolbar = no, menubar = no, status = no\");</script>");

        }

        protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string queryString = string.Empty;


                for (int x = 0; x < gvPendingPatients.Columns.Count; x++)
                {
                    string separator = (x == 0 ? "?" : "&");
                    queryString += string.Format("{0}{1}={2}", separator, gvPendingPatients.Columns[x].HeaderText, e.Row.Cells[x].Text);
                }


                e.Row.Attributes["ondblclick"] = string.Format("popItUp({0})", queryString);
            }
        }


        protected void btnRecipe_Click(object sender, EventArgs e)
        {
            string CLID = gvPendingPatients.SelectedRow.Cells[4].Text.Trim();
            string PID = gvPendingPatients.SelectedRow.Cells[1].Text.Trim();
            string EID = User.Identity.GetUserName().Trim();

            ClientScript.RegisterClientScriptBlock(Page.GetType(), "popup_MedicalReport", "<script type=\"text/javascript\">var nw = window.open('MedicalReport.aspx?&CLID=" + CLID + "&PID=" + PID + "&EID=" + EID + "', \"MyWindowID\", \"fullscreen = no, toolbar = no, menubar = no, status = no\");</script>");

        }
        protected void RefreshGridView(object sender, EventArgs e)
        {
            getPatientPendingTickets();

        }

        protected void btnViewPrev_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterClientScriptBlock(Page.GetType(), "popup_MedicalReport", "<script type=\"text/javascript\">var nw = window.open('PreviousCustomer.aspx', \"MyWindowID\", \"fullscreen = no, toolbar = no, menubar = no, status = no\");</script>");
        }
        protected void txtPID_TextChanged(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void HiddenField1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}