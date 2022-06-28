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
using System.Text;

namespace ESCARE
{
    public partial class DoctorDeskTop : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterPostBackControl();
            if (User.Identity.GetUserId() == null)
            {
                Response.Redirect("/Account/Login.aspx");
            }

            if (!IsPostBack)
            {
                getProf();
                checkRole();
                //getPatientPendingTickets();
                //gvPendingPatients.DataBind();
                return;
            }
            
            
        }

        private void RegisterPostBackControl()
        {
            try
            {

                //foreach (GridViewRow row in gvPendingPatients.Rows)
                //{
                //    //LinkButton Diag = row.FindControl("Diag") as LinkButton;
                //    //ScriptManager.GetCurrent(this).RegisterPostBackControl(Diag);

                //    //LinkButton OldDiag = row.FindControl("OldDiag") as LinkButton;
                //    //ScriptManager.GetCurrent(this).RegisterPostBackControl(OldDiag);

                //    //UpdatePanel1.Triggers.Add(new AsyncPostBackTrigger() { ControlID = lnkFull.UniqueID });

                //    AsyncPostBackTrigger trigger = new AsyncPostBackTrigger();
                //    trigger.ControlID = (row.FindControl("Diag") as LinkButton).UniqueID;
                //    trigger.EventName = "Click"; //like "Click", "IndexChanged", etc.
                //    UpdatePanel1.Triggers.Add(trigger);
                //}


            }
            catch
            {
                //Your exception management
            }

        }
        //protected void PartialPostBackDiag(object sender, EventArgs e)
        //{
        //    string PFile = ((sender as LinkButton).NamingContainer as GridViewRow).Cells[2].Text;
        //    txtPID.DataBind();
        //    txtPID.Text = PFile;

        //    string CLID = ((sender as LinkButton).NamingContainer as GridViewRow).Cells[5].Text;
        //    string PID = ((sender as LinkButton).NamingContainer as GridViewRow).Cells[2].Text;
        //    string DateIssued = ((sender as LinkButton).NamingContainer as GridViewRow).Cells[6].Text;

        //    Label1.DataBind();
        //    Label1.Text = CLID + PID + DateIssued;
            
        //    gvPatientServices.DataSource = GetDataTable("SELECT [RPID], [SID], [Service], [IssuedBy], [ItemVat], [Dis], [Qty], [ItemAmt] FROM [Hospital].[dbo].[Bill] WHERE [DateIssued]='" + DateIssued + "' AND [PF]='" + PID + "' AND [CLID]='" + CLID + "'");
        //    gvPatientServices.DataBind();
        //}
        protected void PartialPostBackOldDiag(object sender, EventArgs e)
        {
            string PFile = ((sender as LinkButton).NamingContainer as GridViewRow).Cells[3].Text;

            //string ss = "";
            //Panel1.DataBind();
            //ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Key", "<script>$('.cl.inbutos table').html(" + ss + "); $('.cl').show();</script>", false);
        }
        private void getProf()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand("SELECT Employees.Profition, Employees.empid, Clinic_Doctor.CLID from Employees,Clinic_Doctor where Clinic_Doctor.DID=Employees.EmpID AND Employees.EmpID=(select EID from AspNetUsers where id='" + User.Identity.GetUserId() + "')", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                
                HiddenField1.Value = Convert.ToString(dr["Profition"]);
                HiddenField2.Value = Convert.ToString(dr["empid"]);
                HiddenField3.Value = DateTime.Now.ToString("yyyy/MM/dd");
                HiddenField4.Value = Convert.ToString(dr["CLID"]);
            }
            con.Close();
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

        //protected void getPatientPendingTickets()
        //{
        //    DataTable dtt = new DataTable();
        //    if (HiddenField1.Value == "03")
        //    {
                
        //        dtt = GetDataTable("SELECT patient.FileNo as 'رقم الملف', (patient.FName+' '+patient.MName+' '+patient.LName) as 'الاسم انجليزي', (patient.ArFName+' '+patient.ArMName+' '+patient.ArLName) as 'الاسم عربي' , PD.CLID as 'رقم العيادة', PD.Date as 'وقت الحجز' from patient,PD where patient.FileNo=pd.pid and pd.AV=1 and pd.EID =(select EID from AspNetUsers where UserName='" + User.Identity.GetUserName() + "')");
                
                
        //    }
        //    if (HiddenField1.Value == "04")
        //    {
                
        //        dtt = GetDataTable("SELECT patient.FileNo as 'رقم الملف', (patient.FName+' '+patient.MName+' '+patient.LName) as 'الاسم انجليزي', (patient.ArFName+' '+patient.ArMName+' '+patient.ArLName) as 'الاسم عربي' , PD.CLID as 'رقم العيادة', PD.Date as 'وقت الحجز' from patient,PD,employees where patient.FileNo=pd.pid and pd.AV=1 and pd.EID =employees.Managr and employees.empid=(select EID from AspNetUsers where UserName='" + User.Identity.GetUserName() + "')");
                
                
        //    }
            
        //    gvPendingPatients.DataSource = dtt;
        //    gvPendingPatients.DataBind();
        //}

        //protected void gvPList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    gvPendingPatients.PageIndex = e.NewPageIndex;
        //    gvPendingPatients.DataBind();
        //    getPatientPendingTickets();
        //}
        //protected void gvPList_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //    string CLID = gvPendingPatients.SelectedRow.Cells[4].Text;
        //    string PID = gvPendingPatients.SelectedRow.Cells[1].Text;
        //    string EID = User.Identity.GetUserName();

        //    ClientScript.RegisterClientScriptBlock(Page.GetType(), "popup_MedicalReport", "<script type=\"text/javascript\">var nw = window.open('~/MedicalReport.aspx?CLID=" + CLID + "&PID=" + PID + "&EID=" + EID + "', \"MyWindowID\", \"fullscreen = no, toolbar = no, menubar = no, status = no\");</script>");
        //}

        //protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        string queryString = string.Empty;


        //        for (int x = 0; x < gvPendingPatients.Columns.Count; x++)
        //        {
        //            string separator = (x == 0 ? "?" : "&");
        //            queryString += string.Format("{0}{1}={2}", separator, gvPendingPatients.Columns[x].HeaderText, e.Row.Cells[x].Text);
        //        }


        //        e.Row.Attributes["ondblclick"] = string.Format("popItUp({0})", queryString);
        //    }
        //}


        //protected void btnRecipe_Click(object sender, EventArgs e)
        //{
        //    string CLID = gvPendingPatients.SelectedRow.Cells[4].Text.Trim();
        //    string PID = gvPendingPatients.SelectedRow.Cells[1].Text.Trim();
        //    string EID = User.Identity.GetUserName().Trim();

        //    ClientScript.RegisterClientScriptBlock(Page.GetType(), "popup_MedicalReport", "<script type=\"text/javascript\">var nw = window.open('MedicalReport.aspx?&CLID=" + CLID + "&PID=" + PID + "&EID=" + EID + "', \"MyWindowID\", \"fullscreen = no, toolbar = no, menubar = no, status = no\");</script>");

        //}
        protected void RefreshGridView(object sender, EventArgs e)
        {
            //getPatientPendingTickets();

        }

        protected void btnViewPrev_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterClientScriptBlock(Page.GetType(), "popup_MedicalReport", "<script type=\"text/javascript\">var nw = window.open('PreviousCustomer.aspx', \"MyWindowID\", \"fullscreen = no, toolbar = no, menubar = no, status = no\");</script>");
        }

        public DateTime ParseDate(string date)
        {
            DateTimeFormatInfo dateFormatProvider = new DateTimeFormatInfo();
            dateFormatProvider.ShortDatePattern = "yyyy/dd/MM";
            return DateTime.Parse(date, dateFormatProvider);
        }

        protected void txtPID_TextChanged(object sender, EventArgs e)
        {
            string dates = txtPID.Text;
            
            HiddenField3.Value = dates.Replace('-', '/');
        }
        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void DetailsView1_ItemCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "goto")
            {
                string id = e.CommandArgument.ToString();
                Response.Redirect("Default3.aspx?id=" + id);
            }
        }

        protected void HiddenField1_ValueChanged(object sender, EventArgs e)
        {

        }
        protected void HiddenField2_ValueChanged(object sender, EventArgs e)
        {

        }
        protected void HiddenField3_ValueChanged(object sender, EventArgs e)
        {

        }
        protected void HiddenField4_ValueChanged(object sender, EventArgs e)
        {

        }
        protected void gvPendingPatients_RowCommand(object sender,GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Diag")
            {
                // Retrieve the row index stored in the 
                // CommandArgument property.
                //int index = Convert.ToInt32(e.CommandArgument);

                // Retrieve the row that contains the button 
                // from the Rows collection.
                //GridViewRow row = gvPendingPatients.Rows[index];


                //// Add code here to add the item to the shopping cart.
                string ss = "< tr > < td > < ul >  < a >< li > < i  ></i> <p>Patient Registration</p>   </li></a>  </ul> </td> </tr>";

                ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Key", "<script>$('.cl.inbutos table').html("+ss+");</script>", false);



                int id = Convert.ToInt32(e.CommandArgument);
                //GridViewRow row = gvPendingPatients.Rows[id];
                //TableCell contactName = row.Cells[3];
                //txtPID.Text = contactName.Text;

            }

        }
    }
}