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
    public partial class MedicalReport : Page
    {

        private string CLID;
        private string EID;
        private string PID;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (User.Identity.GetUserId() == null)
            {
                Response.Redirect("/Account/Login.aspx");
            }

            SetInitialRow();
            if (!IsPostBack)
            {
                CLID = Request["CLID"];
                EID = getEmpID(Request["EID"]);
                PID = Request["PID"];
                

                txtPID.Text = PID;
                txtPID.DataBind();

                
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
                return null;
        }

        private string storeReport()
        {
            CLID = Request["CLID"];
            EID = getEmpID(Request["EID"]);
            PID = Request["PID"];

            if ((txtMedicalReport.Text != null || txtMedicalReport.Text != "") && CLID != null && PID != null && EID != null)
            {
                string Description = txtMedicalReport.Text;
                DateTime localDate = DateTime.Now;
               
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
                
                SqlCommand cmd = new SqlCommand("spINSERT_dbo_DReports", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CLID", CLID);
                cmd.Parameters.AddWithValue("@EID", EID);
                cmd.Parameters.AddWithValue("@PID", PID);
                cmd.Parameters.AddWithValue("@Description", Description);
                cmd.Parameters.AddWithValue("@Date", localDate);
                con.Open();

                
                int k = cmd.ExecuteNonQuery();
                if (k != 0)
                {
                    cmd = new SqlCommand("SELECT TOP 1 REID FROM hospital.dbo.DReports ORDER BY ID DESC", con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        string reid = Convert.ToString(dr["REID"]);
                        con.Close();
                        con.Open();
                        cmd = new SqlCommand("spUPDATE_dbo_PD_Customer_Done", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CLID", CLID);
                        cmd.Parameters.AddWithValue("@PID", PID);
                        
                        k = cmd.ExecuteNonQuery();
                        if (k != 0)
                        {
                            con.Close();
                            return reid;
                        }
                    }
                }
                con.Close();
            }
            return "false";
        }

        protected void btnDone_Click(object sender, EventArgs e)
        {
            
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                string print = storeReport();
                if (print != "false")
                {
                    ClientScript.RegisterClientScriptBlock(Page.GetType(), "popup_receipt", "<script type=\"text/javascript\">var nw = window.open('RptPrintOut?sRef=Receipt&ReceiptID=" + print + "', \"MyWindowID\", \"fullscreen = no, toolbar = no, menubar = no, status = no\");</script>");
                    string close = @"<script type='text/javascript'>
                                window.returnValue = true;
                                window.close();
                                </script>";
                    base.Response.Write(close);
                }
                else
                {

                }
            }
            else
            {

            }
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

        private void SetInitialRow()
        {
            DataTable dt = new DataTable();
            DataRow dr = null;
            dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
            dt.Columns.Add(new DataColumn("Medicine Name", typeof(string)));
            dt.Columns.Add(new DataColumn("Times", typeof(string)));
            dt.Columns.Add(new DataColumn("How To Use", typeof(string)));
            dt.Columns.Add(new DataColumn("Quantity", typeof(string)));
            dr = dt.NewRow();
            dr["RowNumber"] = 1;
            dr["Medicine Name"] = string.Empty;
            dr["Times"] = string.Empty;
            dr["How To Use"] = string.Empty;
            dr["Quantity"] = string.Empty;
            dt.Rows.Add(dr);

            //Store the DataTable in ViewState
            ViewState["CurrentTable"] = dt;

            Gridview1.DataSource = dt;
            Gridview1.DataBind();
        }
        private void AddNewRowToGrid()
        {
            int rowIndex = 0;

            if (ViewState["CurrentTable"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                DataRow drCurrentRow = null;
                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {
                        //extract the TextBox values
                        TextBox box1 = (TextBox)Gridview1.Rows[rowIndex].Cells[1].FindControl("TextBox1");
                        TextBox box2 = (TextBox)Gridview1.Rows[rowIndex].Cells[2].FindControl("TextBox2");
                        TextBox box3 = (TextBox)Gridview1.Rows[rowIndex].Cells[3].FindControl("TextBox3");
                        TextBox box4 = (TextBox)Gridview1.Rows[rowIndex].Cells[4].FindControl("TextBox4");

                        drCurrentRow = dtCurrentTable.NewRow();
                        drCurrentRow["RowNumber"] = i + 1;

                        dtCurrentTable.Rows[i - 1]["Medicine Name"] = box1.Text;
                        dtCurrentTable.Rows[i - 1]["Times"] = box2.Text;
                        dtCurrentTable.Rows[i - 1]["How To Use"] = box3.Text;
                        dtCurrentTable.Rows[i - 1]["Quantity"] = box4.Text;

                        rowIndex++;
                    }
                    dtCurrentTable.Rows.Add(drCurrentRow);
                    ViewState["CurrentTable"] = dtCurrentTable;

                    Gridview1.DataSource = dtCurrentTable;
                    Gridview1.DataBind();
                }
            }
            else
            {
                Response.Write("ViewState is null");
            }

            //Set Previous Data on Postbacks
            SetPreviousData();
        }
        private void SetPreviousData()
        {
            int rowIndex = 0;
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        TextBox box1 = (TextBox)Gridview1.Rows[rowIndex].Cells[1].FindControl("TextBox1");
                        TextBox box2 = (TextBox)Gridview1.Rows[rowIndex].Cells[2].FindControl("TextBox2");
                        TextBox box3 = (TextBox)Gridview1.Rows[rowIndex].Cells[3].FindControl("TextBox3");
                        TextBox box4 = (TextBox)Gridview1.Rows[rowIndex].Cells[4].FindControl("TextBox4");

                        box1.Text = dt.Rows[i]["Medicine Name"].ToString();
                        box2.Text = dt.Rows[i]["Times"].ToString();
                        box3.Text = dt.Rows[i]["How To Use"].ToString();
                        box4.Text = dt.Rows[i]["Quantity"].ToString();

                        rowIndex++;
                    }
                }
            }
        }
        
        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            AddNewRowToGrid();
        }
    }
}