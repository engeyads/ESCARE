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
    public partial class CreateNewReceipt : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (User.Identity.GetUserId() == null)
            {
                Response.Redirect("/Account/Login.aspx");
            }
            txtRemain.Attributes.Add("readonly", "readonly");
            txtVat.Attributes.Add("readonly", "readonly");

            if (!IsPostBack)
            {
                //DropDownList1.DataBind();
                //DropDownList1.Items.Insert(0, new ListItem("Select Service Kind...", "0"));
                getVAT();
                getBillDoctxt_Clin("in");

                //ddlin();
                return;
            }

        }

        //public void ProcesRequest(HttpContext context)
        //{

        //    List<string> listStudentNames = new List<string>();

        //    string cs = ConfigurationManager.ConnectionStrings["Hospital"].ConnectionString;
        //    using (SqlConnection con = new SqlConnection(cs))
        //    {
        //        SqlCommand cmd = new SqlCommand("select Name from Services where Name like '" + TextBox1.Text + "%' AND KID ='" + ddlKind.SelectedValue + "'", con);

        //        con.Open();
        //        SqlDataReader rdr = cmd.ExecuteReader();
        //        while (rdr.Read())
        //        {
        //            listStudentNames.Add(rdr["Name"].ToString());
        //        }
        //    }

        //    JavaScriptSerializer js = new JavaScriptSerializer();
        //    context.Response.Write(js.Serialize(listStudentNames));
        //}



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
        protected void Init_hdnNationality(string val)
        {
            hdnlblNationality.Text = val;
        }
        protected void getTblPFiles()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            SqlCommand cmd;// new SqlCommand("SELECT COUNT(*) from patient where PID like '%" + txtPID.Text + "%'", con);
            int userCount = 0;
            DataTable dt = new DataTable();
            txtFileNo.Text = "";
            switch (rbgSearchBy.SelectedValue)
            {
                case "0":
                    cmd = new SqlCommand("SELECT COUNT(*) from patient where PID like '%" + txtPID.Text + "%'", con);
                    con.Open();
                    userCount = (int)cmd.ExecuteScalar();
                    con.Close();
                    if (userCount > 1)
                    {
                        dt = GetDataTable("SELECT patient.PID, (patient.FName+' '+patient.MName+' '+patient.LName) AS EnName, (patient.ArFName+' '+patient.ArMName+' '+patient.ArLName) AS ArName, CASE WHEN IDType = 1 THEN 'ID Card' ELSE 'Passport' END AS IDType, patient.Mobile, countries.Name, patient.Profition, patient.Blood, patient.Address, patient.DOB, patient.InDate FROM patient,countries where patient.PID like '%" + txtPID.Text + "%' AND countries.ID = patient.Nationality");
                    }
                    else if (userCount == 1)
                    {

                        SqlCommand cmd1 = new SqlCommand("SELECT FileNo,(patient.ArFName+' '+patient.ArMName+' '+patient.ArLName) AS ArName ,Patient.Nationality from Patient where PID like '%" + txtPID.Text + "%'", con);
                        con.Open();
                        SqlDataReader dr = cmd1.ExecuteReader();
                        if (dr.Read())
                        {
                            txtFileNo.Text = Convert.ToString(dr["FileNo"]);
                            txtPID.Text = Convert.ToString(dr["ArName"]);
                            Init_hdnNationality(Convert.ToString(dr["Nationality"]));

                            refreshBill();
                        }
                        con.Close();
                    }
                    else
                    {
                        lblmsg.Text = "Record Not Existed";
                        lblmsg.ForeColor = System.Drawing.Color.Red;
                        lblmsg.Visible = true;
                    }
                    break;
                case "1":
                    cmd = new SqlCommand("SELECT COUNT(*) from patient where patient.Mobile like '%" + txtPID.Text + "%'", con);
                    con.Open();
                    userCount = (int)cmd.ExecuteScalar();
                    con.Close();
                    if (userCount > 1)
                    {
                        dt = GetDataTable("SELECT patient.PID, (patient.FName+' '+patient.MName+' '+patient.LName) AS EnName, (patient.ArFName+' '+patient.ArMName+' '+patient.ArLName) AS ArName, CASE WHEN IDType = 1 THEN 'ID Card' ELSE 'Passport' END AS IDType, patient.Mobile, countries.Name, patient.Profition, patient.Blood, patient.Address, patient.DOB, patient.InDate FROM patient,countries where patient.Mobile like '%" + txtPID.Text + "%' AND countries.ID = patient.Nationality");
                    }
                    else if (userCount == 1)
                    {

                        SqlCommand cmd1 = new SqlCommand("SELECT FileNo,(patient.ArFName+' '+patient.ArMName+' '+patient.ArLName) AS ArName ,Patient.Nationality from Patient where patient.Mobile like '%" + txtPID.Text + "%'", con);
                        con.Open();
                        SqlDataReader dr = cmd1.ExecuteReader();
                        if (dr.Read())
                        {
                            txtFileNo.Text = Convert.ToString(dr["FileNo"]);
                            txtPID.Text = Convert.ToString(dr["ArName"]);
                            Init_hdnNationality(Convert.ToString(dr["Nationality"]));

                            refreshBill();
                        }
                        con.Close();
                    }
                    else
                    {
                        lblmsg.Text = "Record Not Existed";
                        lblmsg.ForeColor = System.Drawing.Color.Red;
                        lblmsg.Visible = true;
                    }
                    break;
                case "2":
                    cmd = new SqlCommand("SELECT COUNT(*) from patient where (patient.ArFName+' '+patient.ArMName+' '+patient.ArLName) like '%" + txtPID.Text + "%' or (patient.FName+' '+patient.MName+' '+patient.LName) like '%" + txtPID.Text + "%'", con);
                    con.Open();
                    userCount = (int)cmd.ExecuteScalar();
                    con.Close();
                    if (userCount > 1)
                    {
                        dt = GetDataTable("SELECT patient.PID, (patient.FName+' '+patient.MName+' '+patient.LName) AS EnName, (patient.ArFName+' '+patient.ArMName+' '+patient.ArLName) AS ArName, CASE WHEN IDType = 1 THEN 'ID Card' ELSE 'Passport' END AS IDType, patient.Mobile, countries.Name, patient.Profition, patient.Blood, patient.Address, patient.DOB, patient.InDate FROM patient,countries where (patient.ArFName+' '+patient.ArMName+' '+patient.ArLName) like '%" + txtPID.Text + "%' or (patient.FName+' '+patient.MName+' '+patient.LName) like '%" + txtPID.Text + "%' AND countries.ID = patient.Nationality");
                    }
                    else if (userCount == 1)
                    {

                        SqlCommand cmd1 = new SqlCommand("SELECT FileNo,(patient.ArFName+' '+patient.ArMName+' '+patient.ArLName) AS ArName ,Patient.Nationality from Patient where (ArFName+' '+ArMName+' '+ArLName) like '%" + txtPID.Text + "%' or (FName+' '+MName+' '+LName) like '%" + txtPID.Text + "%'", con);
                        con.Open();
                        SqlDataReader dr = cmd1.ExecuteReader();
                        if (dr.Read())
                        {
                            txtFileNo.Text = Convert.ToString(dr["FileNo"]);
                            txtPID.Text = Convert.ToString(dr["ArName"]);
                            Init_hdnNationality(Convert.ToString(dr["Nationality"]));

                            refreshBill();
                        }
                        con.Close();
                    }
                    else
                    {
                        lblmsg.Text = "Record Not Existed";
                        lblmsg.ForeColor = System.Drawing.Color.Red;
                        lblmsg.Visible = true;
                    }
                    break;
                default:
                    dt = GetDataTable("SELECT patient.PID, (patient.FName+' '+patient.MName+' '+patient.LName) AS EnName, (patient.ArFName+' '+patient.ArMName+' '+patient.ArLName) AS ArName, CASE WHEN IDType = 1 THEN 'ID Card' ELSE 'Passport' END AS IDType, patient.Mobile, countries.Name, patient.Profition, patient.Blood, patient.Address, patient.DOB, patient.InDate FROM patient,countries where patient.PID like '%" + txtPID.Text + "%' AND countries.ID = patient.Nationality");
                    break;
            }

            gvPList.DataSource = dt;
            gvPList.DataBind();
            con.Close();

        }
        protected void refreshBill()
        {
            getBillDoctxt_Clin("in");
            txtBillDoc.Text = "";
            txtBillClin.Text = "";

            txtArName1.Text = "";
            txtAmount1.Text = "";
            txtCode1.Text = "";
            txtDisAmt1.Text = "";
            txtDisPer1.Text = "";
            txtEnName1.Text = "";
            txtQty1.Text = "";
            txtNetAmt1.Text = "";
            txtVat1.Text = "";

            txtArName2.Text = "";
            txtAmount2.Text = "";
            txtCode2.Text = "";
            txtDisAmt2.Text = "";
            txtDisPer2.Text = "";
            txtEnName2.Text = "";
            txtQty2.Text = "";
            txtNetAmt2.Text = "";
            txtVat2.Text = "";

            txtArName3.Text = "";
            txtAmount3.Text = "";
            txtCode3.Text = "";
            txtDisAmt3.Text = "";
            txtDisPer3.Text = "";
            txtEnName3.Text = "";
            txtQty3.Text = "";
            txtNetAmt3.Text = "";
            txtVat3.Text = "";

            txtArName4.Text = "";
            txtAmount4.Text = "";
            txtCode4.Text = "";
            txtDisAmt4.Text = "";
            txtDisPer4.Text = "";
            txtEnName4.Text = "";
            txtQty4.Text = "";
            txtNetAmt4.Text = "";
            txtVat4.Text = "";

            txtArName5.Text = "";
            txtAmount5.Text = "";
            txtCode5.Text = "";
            txtDisAmt5.Text = "";
            txtDisPer5.Text = "";
            txtEnName5.Text = "";
            txtQty5.Text = "";
            txtNetAmt5.Text = "";
            txtVat5.Text = "";

            txtArName6.Text = "";
            txtAmount6.Text = "";
            txtCode6.Text = "";
            txtDisAmt6.Text = "";
            txtDisPer6.Text = "";
            txtEnName6.Text = "";
            txtQty6.Text = "";
            txtNetAmt6.Text = "";
            txtVat6.Text = "";

            txtArName7.Text = "";
            txtAmount7.Text = "";
            txtCode7.Text = "";
            txtDisAmt7.Text = "";
            txtDisPer7.Text = "";
            txtEnName7.Text = "";
            txtQty7.Text = "";
            txtNetAmt7.Text = "";
            txtVat7.Text = "";

            txtAmtDV.Text = "";
            txtVat.Text = "";
            txtRemain.Text = "";
            txtCash.Text = "";
            txtCredit.Text = "";
            txtPrice.Text = "";

            lblmsg.Visible = false;
        }

        protected void refreshbillonly()
        {
            txtArName1.Text = "";
            txtAmount1.Text = "";
            txtCode1.Text = "";
            txtDisAmt1.Text = "";
            txtDisPer1.Text = "";
            txtEnName1.Text = "";
            txtQty1.Text = "";
            txtNetAmt1.Text = "";
            txtVat1.Text = "";

            txtArName2.Text = "";
            txtAmount2.Text = "";
            txtCode2.Text = "";
            txtDisAmt2.Text = "";
            txtDisPer2.Text = "";
            txtEnName2.Text = "";
            txtQty2.Text = "";
            txtNetAmt2.Text = "";
            txtVat2.Text = "";

            txtArName3.Text = "";
            txtAmount3.Text = "";
            txtCode3.Text = "";
            txtDisAmt3.Text = "";
            txtDisPer3.Text = "";
            txtEnName3.Text = "";
            txtQty3.Text = "";
            txtNetAmt3.Text = "";
            txtVat3.Text = "";

            txtArName4.Text = "";
            txtAmount4.Text = "";
            txtCode4.Text = "";
            txtDisAmt4.Text = "";
            txtDisPer4.Text = "";
            txtEnName4.Text = "";
            txtQty4.Text = "";
            txtNetAmt4.Text = "";
            txtVat4.Text = "";

            txtArName5.Text = "";
            txtAmount5.Text = "";
            txtCode5.Text = "";
            txtDisAmt5.Text = "";
            txtDisPer5.Text = "";
            txtEnName5.Text = "";
            txtQty5.Text = "";
            txtNetAmt5.Text = "";
            txtVat5.Text = "";

            txtArName6.Text = "";
            txtAmount6.Text = "";
            txtCode6.Text = "";
            txtDisAmt6.Text = "";
            txtDisPer6.Text = "";
            txtEnName6.Text = "";
            txtQty6.Text = "";
            txtNetAmt6.Text = "";
            txtVat6.Text = "";

            txtArName7.Text = "";
            txtAmount7.Text = "";
            txtCode7.Text = "";
            txtDisAmt7.Text = "";
            txtDisPer7.Text = "";
            txtEnName7.Text = "";
            txtQty7.Text = "";
            txtNetAmt7.Text = "";
            txtVat7.Text = "";

            txtAmtDV.Text = "";
            txtVat.Text = "";
            txtRemain.Text = "";
            txtCash.Text = "";
            txtCredit.Text = "";
            txtPrice.Text = "";
        }

        protected void getPatByFileNo()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            SqlCommand cmd;// new SqlCommand("SELECT COUNT(*) from patient where PID like '%" + txtPID.Text + "%'", con);
            int userCount = 0;
            DataTable dt = new DataTable();
            txtPID.Text = "";

            cmd = new SqlCommand("SELECT COUNT(*) from patient where FileNo like '%" + txtFileNo.Text + "%'", con);
            con.Open();
            userCount = (int)cmd.ExecuteScalar();
            con.Close();
            if (userCount == 1)
            {
                SqlCommand cmd1 = new SqlCommand("SELECT (ArFName+' '+ArMName+' '+ArLName) AS ArName, Patient.Nationality from Patient where FileNo = '" + txtFileNo.Text + "'", con);
                con.Open();
                SqlDataReader dr = cmd1.ExecuteReader();
                if (dr.Read())
                {
                    txtPID.Text = Convert.ToString(dr["ArName"]);
                    Init_hdnNationality(Convert.ToString(dr["Nationality"]));

                    refreshBill();
                }
                con.Close();
            }
            else if (userCount > 1)
            {
                lblmsg.Text = "Please Enter Correct File Number!";
                lblmsg.ForeColor = System.Drawing.Color.Yellow;
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "CallMyFunction", "MyFunction()", true);
            }
            else
            {
                lblmsg.Text = "Record Not Existed";
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "CallMyFunction", "MyFunction()", true);
            }

            con.Close();

        }

        protected void txtPID_TextChanged(object sender, EventArgs e)
        {
            getTblPFiles();
        }

        protected void txtFileNo_TextChanged(object sender, EventArgs e)
        {
            getPatByFileNo();
        }

        protected void gvPList_SelectedIndexChanged(object sender, EventArgs e)
        {

            GridViewRow row = gvPList.SelectedRow;

            // In this example, the first column (index 0) contains
            lblmsg.Text = gvPList.SelectedRow.Cells[1].Text;

            lblmsg.ForeColor = System.Drawing.Color.Brown;
            lblmsg.Visible = true;


        }

        protected void gvPList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvPList.PageIndex = e.NewPageIndex;
            gvPList.DataBind();
            getTblPFiles();
        }



        protected void btnSearch_OnClickEvent(object sender, EventArgs e)
        {
            getTblPFiles();
        }

        protected void btnProceed_Click(object sender, EventArgs e)
        {
            //getTblAvDoc();
        }

        protected string getClid(string Doctor, string Service)
        {
            string CLID = null;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand("SELECT CLID from Clinic where EID= '" + Doctor + "' AND SID = '" + Service + "' AND [Available]=1", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                CLID = Convert.ToString(dr["CLID"]);
                return CLID;
            }
            con.Close();
            return null;
        }
        protected void getVAT()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand("SELECT VAT from VAT", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                hdnVat.Value = Convert.ToString(dr["VAT"]);

            }
            con.Close();
        }
        private string byUserEID()
        {
            string byUserEID = User.Identity.GetUserId();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand("SELECT EID FROM AspNetUsers where ID='" + byUserEID + "'", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                byUserEID = Convert.ToString(dr["EID"]);
                con.Close();
                return byUserEID;
            }
            con.Close();
            return null;
        }

        protected string newReciept()
        {
            if (txtPrice.Text != "" && txtFileNo.Text != "" && txtBillDoc.Text != "" && txtBillClin.Text != "")
            {
                string by = byUserEID();
                string pid = txtFileNo.Text;
                string did = txtBillDoc.Text;
                string pri = txtPrice.Text;
                double price = float.Parse(pri, CultureInfo.InvariantCulture.NumberFormat);
                string VAT = txtVat.Text;
                string amt = txtAmtDV.Text;
                string csh = txtCash.Text;
                string crd = txtCredit.Text;
                DateTime localDate = DateTime.Now;

                string clid = txtBillClin.Text;

                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

                SqlCommand cmd = new SqlCommand("spINSERT_dbo_Bills", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PF", pid);
                cmd.Parameters.AddWithValue("@DID", did);
                cmd.Parameters.AddWithValue("@DateIssued", localDate);
                cmd.Parameters.AddWithValue("@InsNo", "");
                cmd.Parameters.AddWithValue("@Paid", 1);
                cmd.Parameters.AddWithValue("@NetAmt", amt);
                cmd.Parameters.AddWithValue("@VAT", VAT);
                cmd.Parameters.AddWithValue("@Total", pri);
                cmd.Parameters.AddWithValue("@Cash", csh);
                cmd.Parameters.AddWithValue("@Credit", crd);
                cmd.Parameters.AddWithValue("@Ins", "");
                cmd.Parameters.AddWithValue("@IssuedBy", by);
                cmd.Parameters.AddWithValue("@CLID", clid);

                con.Open();

                int k = cmd.ExecuteNonQuery();

                con.Close();

                cmd = new SqlCommand("spINSERT_dbo_PD", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PID", pid);
                cmd.Parameters.AddWithValue("@EmpID", did);
                cmd.Parameters.AddWithValue("@CLID", clid);
                cmd.Parameters.AddWithValue("@Date", localDate);
                con.Open();

                k = cmd.ExecuteNonQuery();
                if (k != 0)
                {
                    cmd = new SqlCommand("SELECT TOP 1 RPID FROM hospital.dbo.Bills ORDER BY ID DESC", con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        string RPID = Convert.ToString(dr["RPID"]);
                        con.Close();
                        if (txtCode1.Text != "" && txtNetAmt1.Text != "")
                        {
                            cmd = new SqlCommand("spINSERT_dbo_Service_Bill", con);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@SID", txtCode1.Text);
                            cmd.Parameters.AddWithValue("@RPID", RPID);
                            cmd.Parameters.AddWithValue("@DisP", txtDisPer1.Text);
                            cmd.Parameters.AddWithValue("@DisA", txtDisAmt1.Text);
                            cmd.Parameters.AddWithValue("@Qty", txtQty1.Text);
                            cmd.Parameters.AddWithValue("@vat", txtVat1.Text);
                            cmd.Parameters.AddWithValue("@amt", txtNetAmt1.Text);
                            con.Open();

                            k = cmd.ExecuteNonQuery();

                            con.Close();
                        }

                        if (txtCode2.Text != "" && txtNetAmt2.Text != "")
                        {
                            cmd = new SqlCommand("spINSERT_dbo_Service_Bill", con);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@SID", txtCode2.Text);
                            cmd.Parameters.AddWithValue("@RPID", RPID);
                            cmd.Parameters.AddWithValue("@DisP", txtDisPer2.Text);
                            cmd.Parameters.AddWithValue("@DisA", txtDisAmt2.Text);
                            cmd.Parameters.AddWithValue("@Qty", txtQty2.Text);
                            cmd.Parameters.AddWithValue("@vat", txtVat2.Text);
                            cmd.Parameters.AddWithValue("@amt", txtNetAmt2.Text);
                            con.Open();

                            k = cmd.ExecuteNonQuery();

                            con.Close();
                        }

                        if (txtCode3.Text != "" && txtNetAmt3.Text != "")
                        {
                            cmd = new SqlCommand("spINSERT_dbo_Service_Bill", con);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@SID", txtCode3.Text);
                            cmd.Parameters.AddWithValue("@RPID", RPID);
                            cmd.Parameters.AddWithValue("@DisP", txtDisPer3.Text);
                            cmd.Parameters.AddWithValue("@DisA", txtDisAmt3.Text);
                            cmd.Parameters.AddWithValue("@Qty", txtQty3.Text);
                            cmd.Parameters.AddWithValue("@vat", txtVat3.Text);
                            cmd.Parameters.AddWithValue("@amt", txtNetAmt3.Text);
                            con.Open();

                            k = cmd.ExecuteNonQuery();

                            con.Close();
                        }

                        if (txtCode4.Text != "" && txtNetAmt4.Text != "")
                        {
                            cmd = new SqlCommand("spINSERT_dbo_Service_Bill", con);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@SID", txtCode4.Text);
                            cmd.Parameters.AddWithValue("@RPID", RPID);
                            cmd.Parameters.AddWithValue("@DisP", txtDisPer4.Text);
                            cmd.Parameters.AddWithValue("@DisA", txtDisAmt4.Text);
                            cmd.Parameters.AddWithValue("@Qty", txtQty4.Text);
                            cmd.Parameters.AddWithValue("@vat", txtVat4.Text);
                            cmd.Parameters.AddWithValue("@amt", txtNetAmt4.Text);
                            con.Open();

                            k = cmd.ExecuteNonQuery();

                            con.Close();
                        }

                        if (txtCode5.Text != "" && txtNetAmt5.Text != "")
                        {
                            cmd = new SqlCommand("spINSERT_dbo_Service_Bill", con);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@SID", txtCode5.Text);
                            cmd.Parameters.AddWithValue("@RPID", RPID);
                            cmd.Parameters.AddWithValue("@DisP", txtDisPer5.Text);
                            cmd.Parameters.AddWithValue("@DisA", txtDisAmt5.Text);
                            cmd.Parameters.AddWithValue("@Qty", txtQty5.Text);
                            cmd.Parameters.AddWithValue("@vat", txtVat5.Text);
                            cmd.Parameters.AddWithValue("@amt", txtNetAmt5.Text);
                            con.Open();

                            k = cmd.ExecuteNonQuery();

                            con.Close();
                        }

                        if (txtCode6.Text != "" && txtNetAmt6.Text != "")
                        {
                            cmd = new SqlCommand("spINSERT_dbo_Service_Bill", con);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@SID", txtCode6.Text);
                            cmd.Parameters.AddWithValue("@RPID", RPID);
                            cmd.Parameters.AddWithValue("@DisP", txtDisPer6.Text);
                            cmd.Parameters.AddWithValue("@DisA", txtDisAmt6.Text);
                            cmd.Parameters.AddWithValue("@Qty", txtQty6.Text);
                            cmd.Parameters.AddWithValue("@vat", txtVat6.Text);
                            cmd.Parameters.AddWithValue("@amt", txtNetAmt6.Text);
                            con.Open();

                            k = cmd.ExecuteNonQuery();

                            con.Close();
                        }

                        if (txtCode7.Text != "" && txtNetAmt7.Text != "")
                        {
                            cmd = new SqlCommand("spINSERT_dbo_Service_Bill", con);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@SID", txtCode7.Text);
                            cmd.Parameters.AddWithValue("@RPID", RPID);
                            cmd.Parameters.AddWithValue("@DisP", txtDisPer7.Text);
                            cmd.Parameters.AddWithValue("@DisA", txtDisAmt7.Text);
                            cmd.Parameters.AddWithValue("@Qty", txtQty7.Text);
                            cmd.Parameters.AddWithValue("@vat", txtVat7.Text);
                            cmd.Parameters.AddWithValue("@amt", txtNetAmt7.Text);
                            con.Open();

                            k = cmd.ExecuteNonQuery();

                            con.Close();
                        }
                        lblmsg.Text = "تم انشاء الفاتورة رقم "+RPID;
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "CallMyFunction", "MyFunction()", true);
                        return RPID;
                    }
                }
                con.Close();
            }
            return "false";

        }
        protected void search(string bill)
        {
            refreshBill();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

            SqlCommand cmd = new SqlCommand("SELECT [RPID]" +
                                                    ",[PF]" +
                                                    ",[ClinicName]" +
                                                    ",[CLID]" +
                                                    ",[DID]" +
                                                    ",[Service]" +
                                                    ",[ServiceEn]" +
                                                    ",[Price]" +
                                                    ",[SID]" +
                                                    ",CONVERT(varchar, [DateIssued], 111) as DateIssued" +
                                                    ",CONVERT(varchar, [DateIssued], 0) as TimeIssued" +
                                                    ",[NetAmt]" +
                                                    ",[VAT]" +
                                                    ",[Total]" +
                                                    ",[IssuedBy]" +
                                                    ",[EmpArName]" +
                                                    ",[EmpEnName]" +
                                                    ",[PArName]" +
                                                    ",[PEnName]" +
                                                    ",[ItemVat]" +
                                                    ",[Dis]" +
                                                    ",[Qty]" +
                                                    ",[ItemAmt] " +
                                            "FROM [Hospital].[dbo].[Bill] " +
                                            "WHERE [RPID] ='" + bill + "'", con);

            con.Open();

            SqlDataReader dr = cmd.ExecuteReader();
            
            if (dr.Read())
            {

                lblmsg.Text = "تم العثور على الفاتورة " + txtBillNo.Text;
                lblmsg.ForeColor = System.Drawing.Color.GreenYellow;

                txtFileNo.Text = Convert.ToString(dr["PF"]).Trim();
                txtFileNo_TextChanged(null, null);
                txtPID.Text = Convert.ToString(dr["PArName"]).Trim();
                txtBillDoc.Text = Convert.ToString(dr["DID"]).Trim();
                txtBillDoc_TextChanged(null, null);
                txtIssued.Text = Convert.ToString(dr["DateIssued"]).Trim();
                txtTimeIssued.Text = Convert.ToString(dr["TimeIssued"]).Substring(11).Trim(); 

                txtAmtDV.Text = Convert.ToString(dr["NetAmt"]).Trim();
                txtVat.Text = Convert.ToString(dr["VAT"]).Trim();
                txtPrice.Text = Convert.ToString(dr["Total"]).Trim();

                //txt.Text = Convert.ToString(dr["IssuedBy"]).Trim();
                //CardNo.Text = Convert.ToString(dr["EmpArName"]).Trim();
                List<TextBox> i1 = new List<TextBox>();
                List<TextBox> i2 = new List<TextBox>();
                List<TextBox> i3 = new List<TextBox>();
                List<TextBox> i4 = new List<TextBox>();
                List<TextBox> i5 = new List<TextBox>();
                List<TextBox> i6 = new List<TextBox>();
                List<TextBox> i7 = new List<TextBox>();

                List<List<TextBox>> ls = new List<List<TextBox>>();

                ls.Add(i1);
                ls.Add(i2);
                ls.Add(i3);
                ls.Add(i4);
                ls.Add(i5);
                ls.Add(i6);
                ls.Add(i7);

                ls[0].Add(txtCode1);
                ls[0].Add(txtQty1);
                ls[0].Add(txtDisPer1);

                ls[1].Add(txtCode2);
                ls[1].Add(txtQty2);
                ls[1].Add(txtDisPer2);

                ls[2].Add(txtCode3);
                ls[2].Add(txtQty3);
                ls[2].Add(txtDisPer3);

                ls[3].Add(txtCode4);
                ls[3].Add(txtQty4);
                ls[3].Add(txtDisPer4);

                ls[4].Add(txtCode5);
                ls[4].Add(txtQty5);
                ls[4].Add(txtDisPer5);

                ls[5].Add(txtCode6);
                ls[5].Add(txtQty6);
                ls[5].Add(txtDisPer6);

                ls[6].Add(txtCode7);
                ls[6].Add(txtQty7);
                ls[6].Add(txtDisPer7);

                int i = 0;

                do
                {
                    ls[i][0].Text = Convert.ToString(dr["SID"]).Trim();
                    txtchange(i);
                    ls[i][1].Text = Convert.ToString(dr["Qty"]).Trim();
                    ls[i][2].Text = Convert.ToString(dr["Dis"]).Trim();
                    txtperchange(i);
                    i++;
                } while (dr.Read());

                

            }
            else
            {
                lblmsg.Text = "لا يوجد فاتورة بهذا الرقم";
            }
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "CallMyFunction", "MyFunction()", true);
            con.Close();
        }
        protected void btnSearchBlill_Click(object sender, EventArgs e)
        {
            search(txtBillNo.Text);
        }
        protected void ddlPaymentType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void btnRecipe_Click(object sender, EventArgs e)
        {
            if ((txtCredit.Text != "" && double.Parse(txtCredit.Text) == double.Parse(txtPrice.Text)) || (txtCash.Text != "" && double.Parse(txtCash.Text) == double.Parse(txtPrice.Text)))
            {
                string nReceipt = newReciept();
                if (nReceipt != "false")
                {
                    refreshBill();
                    ClientScript.RegisterClientScriptBlock(Page.GetType(), "popup_receipt", "<script type=\"text/javascript\">var nw = window.open('RptPrintOut?sRef=Receipt&ReceiptID=" + nReceipt + "', \"MyWindowID\", \"fullscreen = no, toolbar = no, menubar = no, status = no\");</script>");

                }
            }
            else
            {
                lblmsg.Text = "لم تقم باستلام المبلغ، برجاء ادخال المبلغ في الكاش او البطاقة";
                lblmsg.ForeColor = System.Drawing.Color.Red;
                lblmsg.Visible = true;
            }
        }
        protected void txtchange(int i){
            switch (i)
            {
                case 0:
                    txtCode1_TextChanged(null, null);
                    //txtDisPer1_TextChanged(null, null);
                    break;
                case 1:
                    txtCode2_TextChanged(null, null);
                    //txtDisPer2_TextChanged(null, null);
                    break;
                case 2:
                    txtCode3_TextChanged(null, null);
                    //txtDisPer3_TextChanged(null, null);
                    break;
                case 3:
                    txtCode4_TextChanged(null, null);
                    //txtDisPer4_TextChanged(null, null);
                    break;
                case 4:
                    txtCode5_TextChanged(null, null);
                    //txtDisPer5_TextChanged(null, null);
                    break;
                case 5:
                    txtCode6_TextChanged(null, null);
                    //txtDisPer6_TextChanged(null, null);
                    break;
                case 6:
                    txtCode7_TextChanged(null, null);
                    //txtDisPer7_TextChanged(null, null);
                    break;
            }
        }
        protected void txtperchange(int i)
        {
            switch (i)
            {
                case 0:
                    txtDisPer1_TextChanged(null, null);
                    break;
                case 1:
                    txtDisPer2_TextChanged(null, null);
                    break;
                case 2:
                    txtDisPer3_TextChanged(null, null);
                    break;
                case 3:
                    txtDisPer4_TextChanged(null, null);
                    break;
                case 4:
                    txtCode5_TextChanged(null, null);
                    break;
                case 5:
                    txtDisPer6_TextChanged(null, null);
                    break;
                case 6:
                    txtDisPer7_TextChanged(null, null);
                    break;
            }
        }
        //protected void ddlin()
        //{
        //    DataTable dt = GetDataTable("SELECT SID , ([Name] + [ArName]) AS service from services where KID = '" + DropDownList1.SelectedValue + "'");
        //    if (dt.IsInitialized)
        //    {
        //        DropDownList2.DataSource = dt;
        //        DropDownList2.DataTextField = "service";
        //        DropDownList2.DataValueField = "SID";
        //        DropDownList2.DataBind();
        //        txtPrice.Text = "";
        //        txtPrice.DataBind();
        //        grdDoc.DataBind();
        //        DropDownList2.Items.Insert(0, new ListItem("Select Service...", "NA"));
        //    }
        //}

        public void getBillDoc_Clin()
        {
            DataTable dt = GetDataTable("SELECT Clinic_Doctor.DID, (Employees.ArFName+' '+Employees.ArMName+' '+Employees.ArLName) as ArName FROM Employees,Clinic_Doctor,UClinic where Employees.[Available]=1 AND Clinic_Doctor.DID = Employees.EmpID AND Clinic_Doctor.CLID = '" + ddlBillClin.SelectedValue + "' AND Clinic_Doctor.CLID = UClinic.CLID AND UClinic.Available=1");
            if (dt.IsInitialized)
            {
                ddlBillDoc.DataSource = dt;
                ddlBillDoc.DataTextField = "ArName";
                ddlBillDoc.DataValueField = "DID";
                txtBillDoc.Text = "";
                ddlBillDoc.DataBind();
                ddlBillDoc.Items.Insert(0, new ListItem("-- اختر طبيب --", "NA"));
            }
        }

        public void getBillDoctxt_Clin(int i)
        {
            DataTable dt = null;
            switch (i)
            {
                case 1:
                    dt = GetDataTable("SELECT Clinic_Doctor.DID, (Employees.ArFName+' '+Employees.ArMName+' '+Employees.ArLName) as EArName, UClinic.ArName, UClinic.CLID FROM Employees,Clinic_Doctor,UClinic where Clinic_Doctor.DID = Employees.EmpID AND UClinic.CLID=Clinic_Doctor.CLID AND Clinic_Doctor.DID = '" + txtBillDoc.Text + "' AND UClinic.Available=1 AND Employees.Available=1");
                    if (dt.IsInitialized)
                    {
                        DataTableReader dr = dt.CreateDataReader();

                        if (dr.Read())
                        {
                            ddlBillClin.SelectedValue = Convert.ToString(dr["CLID"]);
                            txtBillClin.Text = ddlBillClin.SelectedValue;
                            ddlBillDoc.SelectedValue = Convert.ToString(dr["DID"]);
                        }

                        //ddlBillDoc.DataBind();
                        //ddlBillClin.DataBind();
                        //txtBillClin.DataBind();
                    }
                    break;
                case 2:
                    dt = GetDataTable("SELECT Clinic_Doctor.DID, (Employees.ArFName+' '+Employees.ArMName+' '+Employees.ArLName) as EArName, UClinic.ArName, UClinic.CLID FROM Employees,Clinic_Doctor,UClinic where Clinic_Doctor.DID = Employees.EmpID AND UClinic.CLID=Clinic_Doctor.CLID AND Clinic_Doctor.DID = '" + ddlBillDoc.SelectedValue + "' AND UClinic.Available=1 AND Employees.Available=1");
                    if (dt.IsInitialized)
                    {
                        DataTableReader dr = dt.CreateDataReader();

                        if (dr.Read())
                        {
                            ddlBillClin.SelectedValue = Convert.ToString(dr["CLID"]);
                            txtBillClin.Text = ddlBillClin.SelectedValue;
                            txtBillDoc.Text = Convert.ToString(dr["DID"]);
                        }

                        //ddlBillDoc.DataBind();
                        //ddlBillClin.DataBind();
                        //txtBillClin.DataBind();
                    }
                    break;
                default:
                    break;
            }
        }

        public void getBillDoctxt_Clin(String n)
        {
            DataTable dt = GetDataTable("SELECT Clinic_Doctor.DID, (Employees.ArFName+' '+Employees.ArMName+' '+Employees.ArLName) as EArName, UClinic.ArName, UClinic.CLID FROM Employees,Clinic_Doctor,UClinic where Clinic_Doctor.DID = Employees.EmpID AND UClinic.CLID=Clinic_Doctor.CLID AND UClinic.Available=1 AND Employees.Available=1");
            if (dt.IsInitialized)
            {
                ddlBillDoc.DataSource = dt;
                ddlBillDoc.DataTextField = "EArName";
                ddlBillDoc.DataValueField = "DID";

                ddlBillClin.DataSource = dt;
                ddlBillClin.DataTextField = "ArName";
                ddlBillClin.DataValueField = "CLID";

                ddlBillDoc.DataBind();
                ddlBillClin.DataBind();

                ddlBillDoc.Items.Insert(0, new ListItem("-- اختر طبيب --", "NA"));
                ddlBillClin.Items.Insert(0, new ListItem("-- اختر عيادة --", "NA"));
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ddlin();
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(
            this.GetType(), "OpenWindow", "window.open('/AddCustomer.aspx','_newtab');", true);
        }

        protected void ddlBillClin_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlBillClin.SelectedValue != "NA")
            {
                txtBillClin.Text = ddlBillClin.SelectedValue;
                getBillDoc_Clin();

            }else
            {
                getBillDoctxt_Clin("in");
                txtBillDoc.Text = "";
            }
            refreshbillonly();
        }

        protected void txtBillClin_TextChanged(object sender, EventArgs e)
        {
            ddlBillClin.SelectedValue = txtBillClin.Text;
            if (ddlBillClin.SelectedValue != "NA")
            {
                getBillDoc_Clin();
            }
            else
            {
                getBillDoctxt_Clin("in");
                txtBillDoc.Text = "";
            }
            refreshbillonly();
            refreshGrdServices();
        }

        protected void ddlBillDoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            getBillDoctxt_Clin(2);
            refreshbillonly();
            refreshGrdServices();
        }

        protected void txtBillDoc_TextChanged(object sender, EventArgs e)
        {
            if (txtBillDoc.Text =="" || txtBillDoc.Text == null)
            {
                getBillDoctxt_Clin("In");
            }
            else
            {
                getBillDoctxt_Clin(1);
            }
            refreshbillonly();
            refreshGrdServices();
        }
        protected void refreshGrdServices()
        {
            grdServices.DataSource = GetDataTable("SELECT Services.SID, Services.Name, Services.ArName, Services.Price From Services,Clinics_Services,UClinic where Clinics_Services.CLID=UClinic.CLID AND Clinics_Services.CLID='" + txtBillClin.Text + "' AND Services.SID=Clinics_Services.SID AND Services.Av=1 AND UClinic.Available=1");
            
            grdServices.DataBind();
            
        }

        protected void grdServices_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = grdServices.SelectedRow;

            // Display the first name from the selected row.
            // In this example, the third column (index 2) contains
            // the first name.
            if (txtCode1.Text == "")
            {
                txtCode1.Text = row.Cells[1].Text;
                txtCode1_TextChanged(null,null);
                if (txtDisPer1.Text == "")
                {
                    txtDisPer1.Text = "0";
                }
                txtDisPer1_TextChanged(null,null);
            }
            else if(txtCode1.Text == row.Cells[1].Text)
            {
                txtQty1.Text = Convert.ToString(Convert.ToInt32(txtQty1.Text)+1);
                txtQty1_TextChanged(null,null);
                if (txtDisPer1.Text == "")
                {
                    txtDisPer1.Text = "0";
                }
                txtDisPer1_TextChanged(null, null);
            }
            else if (txtCode2.Text == "")
            {
                txtCode2.Text = row.Cells[1].Text;
                txtCode2_TextChanged(null, null);
                if (txtDisPer2.Text == "")
                {
                    txtDisPer2.Text = "0";
                }
                txtDisPer2_TextChanged(null, null);
            }
            else if (txtCode2.Text == row.Cells[1].Text)
            {
                txtQty2.Text = Convert.ToString(Convert.ToInt32(txtQty2.Text) + 1);
                txtQty2_TextChanged(null, null);
                if (txtDisPer2.Text == "")
                {
                    txtDisPer2.Text = "0";
                }
                txtDisPer2_TextChanged(null, null);
            }
            else if (txtCode3.Text == "")
            {
                txtCode3.Text = row.Cells[1].Text;
                txtCode3_TextChanged(null, null);
                if (txtDisPer3.Text == "")
                {
                    txtDisPer3.Text = "0";
                }
                txtDisPer3_TextChanged(null, null);
            }
            else if (txtCode3.Text == row.Cells[1].Text)
            {
                txtQty3.Text = Convert.ToString(Convert.ToInt32(txtQty3.Text) + 1);
                txtQty3_TextChanged(null, null);
                if (txtDisPer3.Text == "")
                {
                    txtDisPer3.Text = "0";
                }
                txtDisPer3_TextChanged(null, null);
            }else if (txtCode4.Text == "")
            {
                txtCode4.Text = row.Cells[1].Text;
                txtCode4_TextChanged(null, null);
                if (txtDisPer4.Text == "")
                {
                    txtDisPer4.Text = "0";
                }
                txtDisPer4_TextChanged(null, null);
            }
            else if (txtCode4.Text == row.Cells[1].Text)
            {
                txtQty4.Text = Convert.ToString(Convert.ToInt32(txtQty4.Text) + 1);
                txtQty4_TextChanged(null, null);
                if (txtDisPer4.Text == "")
                {
                    txtDisPer4.Text = "0";
                }
                txtDisPer4_TextChanged(null, null);
            }else if (txtCode5.Text == "")
            {
                txtCode5.Text = row.Cells[1].Text;
                txtCode5_TextChanged(null, null);
                if (txtDisPer5.Text == "")
                {
                    txtDisPer5.Text = "0";
                }
                txtDisPer5_TextChanged(null, null);
            }
            else if (txtCode5.Text == row.Cells[1].Text)
            {
                txtQty5.Text = Convert.ToString(Convert.ToInt32(txtQty5.Text) + 1);
                txtQty5_TextChanged(null, null);
                if (txtDisPer5.Text == "")
                {
                    txtDisPer5.Text = "0";
                }
                txtDisPer5_TextChanged(null, null);
            }else if (txtCode6.Text == "")
            {
                txtCode6.Text = row.Cells[1].Text;
                txtCode6_TextChanged(null, null);
                if (txtDisPer6.Text == "")
                {
                    txtDisPer6.Text = "0";
                }
                txtDisPer6_TextChanged(null, null);
            }
            else if (txtCode6.Text == row.Cells[1].Text)
            {
                txtQty6.Text = Convert.ToString(Convert.ToInt32(txtQty6.Text) + 1);
                txtQty6_TextChanged(null, null);
                if (txtDisPer6.Text == "")
                {
                    txtDisPer6.Text = "0";
                }
                txtDisPer6_TextChanged(null, null);
            }else if (txtCode7.Text == "")
            {
                txtCode7.Text = row.Cells[1].Text;
                txtCode7_TextChanged(null, null);
                if (txtDisPer7.Text == "")
                {
                    txtDisPer7.Text = "0";
                }
                txtDisPer7_TextChanged(null, null);
            }
            else if (txtCode7.Text == row.Cells[1].Text)
            {
                txtQty7.Text = Convert.ToString(Convert.ToInt32(txtQty7.Text) + 1);
                txtQty7_TextChanged(null, null);
                if (txtDisPer7.Text == "")
                {
                    txtDisPer7.Text = "0";
                }
                txtDisPer7_TextChanged(null, null);
            }
            else
            {
                
            }
        }

        protected DataTableReader getServices(int txtType,string txtText)
        {
            if (txtType==1) {
                DataTable dt = GetDataTable("SELECT Services.Name, Services.ArName, Services.Price ,Services.VatApplyed From Services,Clinics_Services,UClinic where Clinics_Services.CLID=UClinic.CLID AND Clinics_Services.CLID='" + txtBillClin.Text + "' AND Services.SID=Clinics_Services.SID AND Services.SID='" + txtText + "' AND UClinic.Available=1 AND Services.Av=1");
                if (dt.IsInitialized)
                {
                    DataTableReader dr = dt.CreateDataReader();
                    return dr;
                }
            }
            return null;
        }
        private void up1()
        {
            txtArName1.Text = txtArName2.Text;
            txtAmount1.Text = txtAmount2.Text;
            txtCode1.Text = txtCode2.Text;
            txtDisAmt1.Text = txtDisAmt2.Text;
            txtDisPer1.Text = txtDisPer2.Text;
            txtEnName1.Text = txtEnName2.Text;
            txtQty1.Text = txtQty2.Text;
            txtNetAmt1.Text = txtNetAmt2.Text;
            txtVat1.Text = txtVat2.Text;
        }
        private void up2()
        {
            txtArName2.Text = txtArName3.Text;
            txtAmount2.Text = txtAmount3.Text;
            txtCode2.Text = txtCode3.Text;
            txtDisAmt2.Text = txtDisAmt3.Text;
            txtDisPer2.Text = txtDisPer3.Text;
            txtEnName2.Text = txtEnName3.Text;
            txtQty2.Text = txtQty3.Text;
            txtNetAmt2.Text = txtNetAmt3.Text;
            txtVat2.Text = txtVat3.Text;
        }
        private void up3()
        {
            txtArName3.Text = txtArName4.Text;
            txtAmount3.Text = txtAmount4.Text;
            txtCode3.Text = txtCode4.Text;
            txtDisAmt3.Text = txtDisAmt4.Text;
            txtDisPer3.Text = txtDisPer4.Text;
            txtEnName3.Text = txtEnName4.Text;
            txtQty3.Text = txtQty4.Text;
            txtNetAmt3.Text = txtNetAmt4.Text;
            txtVat3.Text = txtVat4.Text;
        }
        private void up4()
        {
            txtArName4.Text = txtArName5.Text;
            txtAmount4.Text = txtAmount5.Text;
            txtCode4.Text = txtCode5.Text;
            txtDisAmt4.Text = txtDisAmt5.Text;
            txtDisPer4.Text = txtDisPer5.Text;
            txtEnName4.Text = txtEnName5.Text;
            txtQty4.Text = txtQty5.Text;
            txtNetAmt4.Text = txtNetAmt5.Text;
            txtVat4.Text = txtVat5.Text;
        }
        private void up5()
        {
            txtArName5.Text = txtArName6.Text;
            txtAmount5.Text = txtAmount6.Text;
            txtCode5.Text = txtCode6.Text;
            txtDisAmt5.Text = txtDisAmt6.Text;
            txtDisPer5.Text = txtDisPer6.Text;
            txtEnName5.Text = txtEnName6.Text;
            txtQty5.Text = txtQty6.Text;
            txtNetAmt5.Text = txtNetAmt6.Text;
            txtVat5.Text = txtVat6.Text;
        }
        private void up6()
        {
            txtArName6.Text = txtArName7.Text;
            txtAmount6.Text = txtAmount7.Text;
            txtCode6.Text = txtCode7.Text;
            txtDisAmt6.Text = txtDisAmt7.Text;
            txtDisPer6.Text = txtDisPer7.Text;
            txtEnName6.Text = txtEnName7.Text;
            txtQty6.Text = txtQty7.Text;
            txtNetAmt6.Text = txtNetAmt7.Text;
            txtVat6.Text = txtVat7.Text;
        }
        private void up7()
        {
            txtArName7.Text = "";
            txtAmount7.Text = "";
            txtCode7.Text = "";
            txtDisAmt7.Text = "";
            txtDisPer7.Text = "";
            txtEnName7.Text = "";
            txtQty7.Text = "";
            txtNetAmt7.Text = "";
            txtVat7.Text = "";
        }
        protected void btnDel1_Click(object sender, EventArgs e)
        {
            up1();
            up2();
            up3();
            up4();
            up5();
            up6();
            up7();

            txtPrice.Text = Convert.ToString((txtNetAmt1.Text != "" ? double.Parse(txtNetAmt1.Text) : double.Parse("0")) + (txtNetAmt2.Text != "" ? double.Parse(txtNetAmt2.Text) : double.Parse("0")) + (txtNetAmt3.Text != "" ? double.Parse(txtNetAmt3.Text) : double.Parse("0")) + (txtNetAmt4.Text != "" ? double.Parse(txtNetAmt4.Text) : double.Parse("0")) + (txtNetAmt5.Text != "" ? double.Parse(txtNetAmt5.Text) : double.Parse("0")) + (txtNetAmt6.Text != "" ? double.Parse(txtNetAmt6.Text) : double.Parse("0")) + (txtNetAmt7.Text != "" ? double.Parse(txtNetAmt7.Text) : double.Parse("0")));


            txtVat.Text = Convert.ToString((txtVat1.Text != "" ? double.Parse(txtVat1.Text) : double.Parse("0")) + (txtVat2.Text != "" ? double.Parse(txtVat2.Text) : double.Parse("0")) + (txtVat3.Text != "" ? double.Parse(txtVat3.Text) : double.Parse("0")) + (txtVat4.Text != "" ? double.Parse(txtVat4.Text) : double.Parse("0")) + (txtVat5.Text != "" ? double.Parse(txtVat5.Text) : double.Parse("0")) + (txtVat6.Text != "" ? double.Parse(txtVat6.Text) : double.Parse("0")) + (txtVat7.Text != "" ? double.Parse(txtVat7.Text) : double.Parse("0")));

            txtAmtDV.Text = Convert.ToString((txtAmount1.Text != "" ? double.Parse(txtAmount1.Text) : double.Parse("0")) + (txtAmount2.Text != "" ? double.Parse(txtAmount2.Text) : double.Parse("0")) + (txtAmount3.Text != "" ? double.Parse(txtAmount3.Text) : double.Parse("0")) + (txtAmount4.Text != "" ? double.Parse(txtAmount4.Text) : double.Parse("0")) + (txtAmount5.Text != "" ? double.Parse(txtAmount5.Text) : double.Parse("0")) + (txtAmount6.Text != "" ? double.Parse(txtAmount6.Text) : double.Parse("0")) + (txtAmount7.Text != "" ? double.Parse(txtAmount7.Text) : double.Parse("0")));
        }

        protected void btnDel2_Click(object sender, EventArgs e)
        {
            up2();
            up3();
            up4();
            up5();
            up6();
            up7();

            txtPrice.Text = Convert.ToString((txtNetAmt1.Text != "" ? double.Parse(txtNetAmt1.Text) : double.Parse("0")) + (txtNetAmt2.Text != "" ? double.Parse(txtNetAmt2.Text) : double.Parse("0")) + (txtNetAmt3.Text != "" ? double.Parse(txtNetAmt3.Text) : double.Parse("0")) + (txtNetAmt4.Text != "" ? double.Parse(txtNetAmt4.Text) : double.Parse("0")) + (txtNetAmt5.Text != "" ? double.Parse(txtNetAmt5.Text) : double.Parse("0")) + (txtNetAmt6.Text != "" ? double.Parse(txtNetAmt6.Text) : double.Parse("0")) + (txtNetAmt7.Text != "" ? double.Parse(txtNetAmt7.Text) : double.Parse("0")));


            txtVat.Text = Convert.ToString((txtVat1.Text != "" ? double.Parse(txtVat1.Text) : double.Parse("0")) + (txtVat2.Text != "" ? double.Parse(txtVat2.Text) : double.Parse("0")) + (txtVat3.Text != "" ? double.Parse(txtVat3.Text) : double.Parse("0")) + (txtVat4.Text != "" ? double.Parse(txtVat4.Text) : double.Parse("0")) + (txtVat5.Text != "" ? double.Parse(txtVat5.Text) : double.Parse("0")) + (txtVat6.Text != "" ? double.Parse(txtVat6.Text) : double.Parse("0")) + (txtVat7.Text != "" ? double.Parse(txtVat7.Text) : double.Parse("0")));

            txtAmtDV.Text = Convert.ToString((txtAmount1.Text != "" ? double.Parse(txtAmount1.Text) : double.Parse("0")) + (txtAmount2.Text != "" ? double.Parse(txtAmount2.Text) : double.Parse("0")) + (txtAmount3.Text != "" ? double.Parse(txtAmount3.Text) : double.Parse("0")) + (txtAmount4.Text != "" ? double.Parse(txtAmount4.Text) : double.Parse("0")) + (txtAmount5.Text != "" ? double.Parse(txtAmount5.Text) : double.Parse("0")) + (txtAmount6.Text != "" ? double.Parse(txtAmount6.Text) : double.Parse("0")) + (txtAmount7.Text != "" ? double.Parse(txtAmount7.Text) : double.Parse("0")));
        }

        protected void btnDel3_Click(object sender, EventArgs e)
        {
            up3();
            up4();
            up5();
            up6();
            up7();

            txtPrice.Text = Convert.ToString((txtNetAmt1.Text != "" ? double.Parse(txtNetAmt1.Text) : double.Parse("0")) + (txtNetAmt2.Text != "" ? double.Parse(txtNetAmt2.Text) : double.Parse("0")) + (txtNetAmt3.Text != "" ? double.Parse(txtNetAmt3.Text) : double.Parse("0")) + (txtNetAmt4.Text != "" ? double.Parse(txtNetAmt4.Text) : double.Parse("0")) + (txtNetAmt5.Text != "" ? double.Parse(txtNetAmt5.Text) : double.Parse("0")) + (txtNetAmt6.Text != "" ? double.Parse(txtNetAmt6.Text) : double.Parse("0")) + (txtNetAmt7.Text != "" ? double.Parse(txtNetAmt7.Text) : double.Parse("0")));


            txtVat.Text = Convert.ToString((txtVat1.Text != "" ? double.Parse(txtVat1.Text) : double.Parse("0")) + (txtVat2.Text != "" ? double.Parse(txtVat2.Text) : double.Parse("0")) + (txtVat3.Text != "" ? double.Parse(txtVat3.Text) : double.Parse("0")) + (txtVat4.Text != "" ? double.Parse(txtVat4.Text) : double.Parse("0")) + (txtVat5.Text != "" ? double.Parse(txtVat5.Text) : double.Parse("0")) + (txtVat6.Text != "" ? double.Parse(txtVat6.Text) : double.Parse("0")) + (txtVat7.Text != "" ? double.Parse(txtVat7.Text) : double.Parse("0")));

            txtAmtDV.Text = Convert.ToString((txtAmount1.Text != "" ? double.Parse(txtAmount1.Text) : double.Parse("0")) + (txtAmount2.Text != "" ? double.Parse(txtAmount2.Text) : double.Parse("0")) + (txtAmount3.Text != "" ? double.Parse(txtAmount3.Text) : double.Parse("0")) + (txtAmount4.Text != "" ? double.Parse(txtAmount4.Text) : double.Parse("0")) + (txtAmount5.Text != "" ? double.Parse(txtAmount5.Text) : double.Parse("0")) + (txtAmount6.Text != "" ? double.Parse(txtAmount6.Text) : double.Parse("0")) + (txtAmount7.Text != "" ? double.Parse(txtAmount7.Text) : double.Parse("0")));
        }

        protected void btnDel4_Click(object sender, EventArgs e)
        {
            up4();
            up5();
            up6();
            up7();

            txtPrice.Text = Convert.ToString((txtNetAmt1.Text != "" ? double.Parse(txtNetAmt1.Text) : double.Parse("0")) + (txtNetAmt2.Text != "" ? double.Parse(txtNetAmt2.Text) : double.Parse("0")) + (txtNetAmt3.Text != "" ? double.Parse(txtNetAmt3.Text) : double.Parse("0")) + (txtNetAmt4.Text != "" ? double.Parse(txtNetAmt4.Text) : double.Parse("0")) + (txtNetAmt5.Text != "" ? double.Parse(txtNetAmt5.Text) : double.Parse("0")) + (txtNetAmt6.Text != "" ? double.Parse(txtNetAmt6.Text) : double.Parse("0")) + (txtNetAmt7.Text != "" ? double.Parse(txtNetAmt7.Text) : double.Parse("0")));


            txtVat.Text = Convert.ToString((txtVat1.Text != "" ? double.Parse(txtVat1.Text) : double.Parse("0")) + (txtVat2.Text != "" ? double.Parse(txtVat2.Text) : double.Parse("0")) + (txtVat3.Text != "" ? double.Parse(txtVat3.Text) : double.Parse("0")) + (txtVat4.Text != "" ? double.Parse(txtVat4.Text) : double.Parse("0")) + (txtVat5.Text != "" ? double.Parse(txtVat5.Text) : double.Parse("0")) + (txtVat6.Text != "" ? double.Parse(txtVat6.Text) : double.Parse("0")) + (txtVat7.Text != "" ? double.Parse(txtVat7.Text) : double.Parse("0")));

            txtAmtDV.Text = Convert.ToString((txtAmount1.Text != "" ? double.Parse(txtAmount1.Text) : double.Parse("0")) + (txtAmount2.Text != "" ? double.Parse(txtAmount2.Text) : double.Parse("0")) + (txtAmount3.Text != "" ? double.Parse(txtAmount3.Text) : double.Parse("0")) + (txtAmount4.Text != "" ? double.Parse(txtAmount4.Text) : double.Parse("0")) + (txtAmount5.Text != "" ? double.Parse(txtAmount5.Text) : double.Parse("0")) + (txtAmount6.Text != "" ? double.Parse(txtAmount6.Text) : double.Parse("0")) + (txtAmount7.Text != "" ? double.Parse(txtAmount7.Text) : double.Parse("0")));
        }

        protected void btnDel5_Click(object sender, EventArgs e)
        {
            up5();
            up6();
            up7();

            txtPrice.Text = Convert.ToString((txtNetAmt1.Text != "" ? double.Parse(txtNetAmt1.Text) : double.Parse("0")) + (txtNetAmt2.Text != "" ? double.Parse(txtNetAmt2.Text) : double.Parse("0")) + (txtNetAmt3.Text != "" ? double.Parse(txtNetAmt3.Text) : double.Parse("0")) + (txtNetAmt4.Text != "" ? double.Parse(txtNetAmt4.Text) : double.Parse("0")) + (txtNetAmt5.Text != "" ? double.Parse(txtNetAmt5.Text) : double.Parse("0")) + (txtNetAmt6.Text != "" ? double.Parse(txtNetAmt6.Text) : double.Parse("0")) + (txtNetAmt7.Text != "" ? double.Parse(txtNetAmt7.Text) : double.Parse("0")));


            txtVat.Text = Convert.ToString((txtVat1.Text != "" ? double.Parse(txtVat1.Text) : double.Parse("0")) + (txtVat2.Text != "" ? double.Parse(txtVat2.Text) : double.Parse("0")) + (txtVat3.Text != "" ? double.Parse(txtVat3.Text) : double.Parse("0")) + (txtVat4.Text != "" ? double.Parse(txtVat4.Text) : double.Parse("0")) + (txtVat5.Text != "" ? double.Parse(txtVat5.Text) : double.Parse("0")) + (txtVat6.Text != "" ? double.Parse(txtVat6.Text) : double.Parse("0")) + (txtVat7.Text != "" ? double.Parse(txtVat7.Text) : double.Parse("0")));

            txtAmtDV.Text = Convert.ToString((txtAmount1.Text != "" ? double.Parse(txtAmount1.Text) : double.Parse("0")) + (txtAmount2.Text != "" ? double.Parse(txtAmount2.Text) : double.Parse("0")) + (txtAmount3.Text != "" ? double.Parse(txtAmount3.Text) : double.Parse("0")) + (txtAmount4.Text != "" ? double.Parse(txtAmount4.Text) : double.Parse("0")) + (txtAmount5.Text != "" ? double.Parse(txtAmount5.Text) : double.Parse("0")) + (txtAmount6.Text != "" ? double.Parse(txtAmount6.Text) : double.Parse("0")) + (txtAmount7.Text != "" ? double.Parse(txtAmount7.Text) : double.Parse("0")));
        }

        protected void btnDel6_Click(object sender, EventArgs e)
        {
            up6();
            up7();

            txtPrice.Text = Convert.ToString((txtNetAmt1.Text != "" ? double.Parse(txtNetAmt1.Text) : double.Parse("0")) + (txtNetAmt2.Text != "" ? double.Parse(txtNetAmt2.Text) : double.Parse("0")) + (txtNetAmt3.Text != "" ? double.Parse(txtNetAmt3.Text) : double.Parse("0")) + (txtNetAmt4.Text != "" ? double.Parse(txtNetAmt4.Text) : double.Parse("0")) + (txtNetAmt5.Text != "" ? double.Parse(txtNetAmt5.Text) : double.Parse("0")) + (txtNetAmt6.Text != "" ? double.Parse(txtNetAmt6.Text) : double.Parse("0")) + (txtNetAmt7.Text != "" ? double.Parse(txtNetAmt7.Text) : double.Parse("0")));


            txtVat.Text = Convert.ToString((txtVat1.Text != "" ? double.Parse(txtVat1.Text) : double.Parse("0")) + (txtVat2.Text != "" ? double.Parse(txtVat2.Text) : double.Parse("0")) + (txtVat3.Text != "" ? double.Parse(txtVat3.Text) : double.Parse("0")) + (txtVat4.Text != "" ? double.Parse(txtVat4.Text) : double.Parse("0")) + (txtVat5.Text != "" ? double.Parse(txtVat5.Text) : double.Parse("0")) + (txtVat6.Text != "" ? double.Parse(txtVat6.Text) : double.Parse("0")) + (txtVat7.Text != "" ? double.Parse(txtVat7.Text) : double.Parse("0")));

            txtAmtDV.Text = Convert.ToString((txtAmount1.Text != "" ? double.Parse(txtAmount1.Text) : double.Parse("0")) + (txtAmount2.Text != "" ? double.Parse(txtAmount2.Text) : double.Parse("0")) + (txtAmount3.Text != "" ? double.Parse(txtAmount3.Text) : double.Parse("0")) + (txtAmount4.Text != "" ? double.Parse(txtAmount4.Text) : double.Parse("0")) + (txtAmount5.Text != "" ? double.Parse(txtAmount5.Text) : double.Parse("0")) + (txtAmount6.Text != "" ? double.Parse(txtAmount6.Text) : double.Parse("0")) + (txtAmount7.Text != "" ? double.Parse(txtAmount7.Text) : double.Parse("0")));
        }

        protected void btnDel7_Click(object sender, EventArgs e)
        {
            up7();

            txtPrice.Text = Convert.ToString((txtNetAmt1.Text != "" ? double.Parse(txtNetAmt1.Text) : double.Parse("0")) + (txtNetAmt2.Text != "" ? double.Parse(txtNetAmt2.Text) : double.Parse("0")) + (txtNetAmt3.Text != "" ? double.Parse(txtNetAmt3.Text) : double.Parse("0")) + (txtNetAmt4.Text != "" ? double.Parse(txtNetAmt4.Text) : double.Parse("0")) + (txtNetAmt5.Text != "" ? double.Parse(txtNetAmt5.Text) : double.Parse("0")) + (txtNetAmt6.Text != "" ? double.Parse(txtNetAmt6.Text) : double.Parse("0")) + (txtNetAmt7.Text != "" ? double.Parse(txtNetAmt7.Text) : double.Parse("0")));


            txtVat.Text = Convert.ToString((txtVat1.Text != "" ? double.Parse(txtVat1.Text) : double.Parse("0")) + (txtVat2.Text != "" ? double.Parse(txtVat2.Text) : double.Parse("0")) + (txtVat3.Text != "" ? double.Parse(txtVat3.Text) : double.Parse("0")) + (txtVat4.Text != "" ? double.Parse(txtVat4.Text) : double.Parse("0")) + (txtVat5.Text != "" ? double.Parse(txtVat5.Text) : double.Parse("0")) + (txtVat6.Text != "" ? double.Parse(txtVat6.Text) : double.Parse("0")) + (txtVat7.Text != "" ? double.Parse(txtVat7.Text) : double.Parse("0")));
            txtAmtDV.Text = Convert.ToString((txtAmount1.Text != "" ? double.Parse(txtAmount1.Text) : double.Parse("0")) + (txtAmount2.Text != "" ? double.Parse(txtAmount2.Text) : double.Parse("0")) + (txtAmount3.Text != "" ? double.Parse(txtAmount3.Text) : double.Parse("0")) + (txtAmount4.Text != "" ? double.Parse(txtAmount4.Text) : double.Parse("0")) + (txtAmount5.Text != "" ? double.Parse(txtAmount5.Text) : double.Parse("0")) + (txtAmount6.Text != "" ? double.Parse(txtAmount6.Text) : double.Parse("0")) + (txtAmount7.Text != "" ? double.Parse(txtAmount7.Text) : double.Parse("0")));

        }

        protected void txtCode1_TextChanged(object sender, EventArgs e)
        {
            DataTableReader dr = getServices(1, txtCode1.Text);
            if (dr.Read())
            {
                txtEnName1.Text = Convert.ToString(dr["Name"]);
                txtArName1.Text = Convert.ToString(dr["ArName"]);
                txtAmount1.Text = Convert.ToString(dr["Price"]);
                hdnAmount1.Value = Convert.ToString(dr["Price"]);

                txtQty1.Text = "1";
                if (hdnlblNationality.Text != "3" && Convert.ToInt32(dr["VatApplyed"]) != 0)
                {
                    string amt = txtAmount1.Text;
                    txtVat1.Text = Convert.ToString(((amt != "" ? double.Parse(amt) : double.Parse("0")) * double.Parse(hdnVat.Value)) / 100);
                    txtNetAmt1.Text = Convert.ToString(double.Parse(amt) + double.Parse(txtVat1.Text));
                }
                else
                {
                    txtVat1.Text = "0";
                    txtNetAmt1.Text = txtAmount1.Text;
                }
                if (txtQty1.Text == "")
                {
                    txtQty1.Text = "1";
                }
                if (txtDisPer1.Text == "")
                {
                    txtDisPer1.Text = "0";
                }
                txtQty1_TextChanged(null,null);
                txtDisPer1_TextChanged(null,null);
                txtPrice.Text = Convert.ToString((txtNetAmt1.Text != "" ? double.Parse(txtNetAmt1.Text) : double.Parse("0")) + (txtNetAmt2.Text != "" ? double.Parse(txtNetAmt2.Text) : double.Parse("0")) + (txtNetAmt3.Text != "" ? double.Parse(txtNetAmt3.Text) : double.Parse("0")) + (txtNetAmt4.Text != "" ? double.Parse(txtNetAmt4.Text) : double.Parse("0")) + (txtNetAmt5.Text != "" ? double.Parse(txtNetAmt5.Text) : double.Parse("0")) + (txtNetAmt6.Text != "" ? double.Parse(txtNetAmt6.Text) : double.Parse("0")) + (txtNetAmt7.Text != "" ? double.Parse(txtNetAmt7.Text) : double.Parse("0")));
                txtVat.Text = Convert.ToString((txtVat1.Text != "" ? double.Parse(txtVat1.Text) : double.Parse("0")) + (txtVat2.Text != "" ? double.Parse(txtVat2.Text) : double.Parse("0")) + (txtVat3.Text != "" ? double.Parse(txtVat3.Text) : double.Parse("0")) + (txtVat4.Text != "" ? double.Parse(txtVat4.Text) : double.Parse("0")) + (txtVat5.Text != "" ? double.Parse(txtVat5.Text) : double.Parse("0")) + (txtVat6.Text != "" ? double.Parse(txtVat6.Text) : double.Parse("0")) + (txtVat7.Text != "" ? double.Parse(txtVat7.Text) : double.Parse("0")));
                txtAmtDV.Text = Convert.ToString((txtAmount1.Text != "" ? double.Parse(txtAmount1.Text) : double.Parse("0")) + (txtAmount2.Text != "" ? double.Parse(txtAmount2.Text) : double.Parse("0")) + (txtAmount3.Text != "" ? double.Parse(txtAmount3.Text) : double.Parse("0")) + (txtAmount4.Text != "" ? double.Parse(txtAmount4.Text) : double.Parse("0")) + (txtAmount5.Text != "" ? double.Parse(txtAmount5.Text) : double.Parse("0")) + (txtAmount6.Text != "" ? double.Parse(txtAmount6.Text) : double.Parse("0")) + (txtAmount7.Text != "" ? double.Parse(txtAmount7.Text) : double.Parse("0")));
            }
        }
        protected void txtAmount1_TextChanged(object sender, EventArgs e)
        {

        }
        protected void txtQty1_TextChanged(object sender, EventArgs e)
        {
            if (txtVat1.Text != "0")
            {
                string amt = Convert.ToString(Convert.ToDouble(hdnAmount1.Value) * Convert.ToInt32(txtQty1.Text));
                txtVat1.Text = Convert.ToString(((amt != "" ? double.Parse(amt) : double.Parse("0")) * double.Parse(hdnVat.Value)) / 100);
                txtNetAmt1.Text = Convert.ToString(double.Parse(amt) + double.Parse(txtVat1.Text));
            }
            else
            {
                txtNetAmt1.Text = Convert.ToString(Convert.ToDouble(hdnAmount1.Value) * Convert.ToInt32(txtQty1.Text));
            }
            txtAmount1.Text = Convert.ToString(Convert.ToDouble(hdnAmount1.Value)*Convert.ToInt32(txtQty1.Text));
            if (txtDisPer1.Text == "")
            {
                txtDisPer1.Text = "0";
            }
            txtDisPer1_TextChanged(null, null);
            txtPrice.Text = Convert.ToString((txtNetAmt1.Text != "" ? double.Parse(txtNetAmt1.Text) : double.Parse("0")) + (txtNetAmt2.Text != "" ? double.Parse(txtNetAmt2.Text) : double.Parse("0")) + (txtNetAmt3.Text != "" ? double.Parse(txtNetAmt3.Text) : double.Parse("0")) + (txtNetAmt4.Text != "" ? double.Parse(txtNetAmt4.Text) : double.Parse("0")) + (txtNetAmt5.Text != "" ? double.Parse(txtNetAmt5.Text) : double.Parse("0")) + (txtNetAmt6.Text != "" ? double.Parse(txtNetAmt6.Text) : double.Parse("0")) + (txtNetAmt7.Text != "" ? double.Parse(txtNetAmt7.Text) : double.Parse("0")));
            txtVat.Text = Convert.ToString((txtVat1.Text != "" ? double.Parse(txtVat1.Text) : double.Parse("0")) + (txtVat2.Text != "" ? double.Parse(txtVat2.Text) : double.Parse("0")) + (txtVat3.Text != "" ? double.Parse(txtVat3.Text) : double.Parse("0")) + (txtVat4.Text != "" ? double.Parse(txtVat4.Text) : double.Parse("0")) + (txtVat5.Text != "" ? double.Parse(txtVat5.Text) : double.Parse("0")) + (txtVat6.Text != "" ? double.Parse(txtVat6.Text) : double.Parse("0")) + (txtVat7.Text != "" ? double.Parse(txtVat7.Text) : double.Parse("0")));
            txtAmtDV.Text = Convert.ToString((txtAmount1.Text != "" ? double.Parse(txtAmount1.Text) : double.Parse("0")) + (txtAmount2.Text != "" ? double.Parse(txtAmount2.Text) : double.Parse("0")) + (txtAmount3.Text != "" ? double.Parse(txtAmount3.Text) : double.Parse("0")) + (txtAmount4.Text != "" ? double.Parse(txtAmount4.Text) : double.Parse("0")) + (txtAmount5.Text != "" ? double.Parse(txtAmount5.Text) : double.Parse("0")) + (txtAmount6.Text != "" ? double.Parse(txtAmount6.Text) : double.Parse("0")) + (txtAmount7.Text != "" ? double.Parse(txtAmount7.Text) : double.Parse("0")));
        }
        protected void txtDisPer1_TextChanged(object sender, EventArgs e)
        {
            txtAmount1.Text = Convert.ToString(((Convert.ToDouble(hdnAmount1.Value) * Convert.ToInt32(txtQty1.Text)) - ((Convert.ToDouble(hdnAmount1.Value) * Convert.ToInt32(txtQty1.Text)) * (Convert.ToDouble(txtDisPer1.Text)/100))));
            txtDisAmt1.Text = Convert.ToString((Convert.ToDouble(hdnAmount1.Value) * Convert.ToInt32(txtQty1.Text)) * (Convert.ToDouble(txtDisPer1.Text) / 100));
            if (txtVat1.Text != "0")
            {
                string amt = Convert.ToString(Convert.ToDouble(txtAmount1.Text));
                txtVat1.Text = Convert.ToString((Convert.ToDouble(amt)* double.Parse(hdnVat.Value))/100);
                txtNetAmt1.Text = Convert.ToString(Convert.ToDouble(amt) + Convert.ToDouble(txtVat1.Text));
            }
            else
            {
                txtNetAmt1.Text = Convert.ToString(Convert.ToDouble(txtAmount1.Text));
            }
            txtPrice.Text = Convert.ToString((txtNetAmt1.Text != "" ? double.Parse(txtNetAmt1.Text) : double.Parse("0")) + (txtNetAmt2.Text != "" ? double.Parse(txtNetAmt2.Text) : double.Parse("0")) + (txtNetAmt3.Text != "" ? double.Parse(txtNetAmt3.Text) : double.Parse("0")) + (txtNetAmt4.Text != "" ? double.Parse(txtNetAmt4.Text) : double.Parse("0")) + (txtNetAmt5.Text != "" ? double.Parse(txtNetAmt5.Text) : double.Parse("0")) + (txtNetAmt6.Text != "" ? double.Parse(txtNetAmt6.Text) : double.Parse("0")) + (txtNetAmt7.Text != "" ? double.Parse(txtNetAmt7.Text) : double.Parse("0")));
            txtVat.Text = Convert.ToString((txtVat1.Text != "" ? double.Parse(txtVat1.Text) : double.Parse("0")) + (txtVat2.Text != "" ? double.Parse(txtVat2.Text) : double.Parse("0")) + (txtVat3.Text != "" ? double.Parse(txtVat3.Text) : double.Parse("0")) + (txtVat4.Text != "" ? double.Parse(txtVat4.Text) : double.Parse("0")) + (txtVat5.Text != "" ? double.Parse(txtVat5.Text) : double.Parse("0")) + (txtVat6.Text != "" ? double.Parse(txtVat6.Text) : double.Parse("0")) + (txtVat7.Text != "" ? double.Parse(txtVat7.Text) : double.Parse("0")));
            txtAmtDV.Text = Convert.ToString((txtAmount1.Text != "" ? double.Parse(txtAmount1.Text) : double.Parse("0")) + (txtAmount2.Text != "" ? double.Parse(txtAmount2.Text) : double.Parse("0")) + (txtAmount3.Text != "" ? double.Parse(txtAmount3.Text) : double.Parse("0")) + (txtAmount4.Text != "" ? double.Parse(txtAmount4.Text) : double.Parse("0")) + (txtAmount5.Text != "" ? double.Parse(txtAmount5.Text) : double.Parse("0")) + (txtAmount6.Text != "" ? double.Parse(txtAmount6.Text) : double.Parse("0")) + (txtAmount7.Text != "" ? double.Parse(txtAmount7.Text) : double.Parse("0")));
        }
        protected void txtDisAmt1_TextChanged(object sender, EventArgs e)
        {
            txtAmount1.Text = Convert.ToString((Convert.ToDouble(hdnAmount1.Value) * Convert.ToInt32(txtQty1.Text)) - (Convert.ToDouble(txtDisAmt1.Text)));
            txtDisPer1.Text = Convert.ToString((Convert.ToDouble(txtDisAmt1.Text) / (Convert.ToDouble(hdnAmount1.Value) * Convert.ToInt32(txtQty1.Text))) * 100);
            if (txtVat1.Text != "0")
            {
                string amt = Convert.ToString(Convert.ToDouble(txtAmount1.Text));
                txtVat1.Text = Convert.ToString((Convert.ToDouble(amt) * double.Parse(hdnVat.Value)) / 100);
                txtNetAmt1.Text = Convert.ToString(Convert.ToDouble(amt) + Convert.ToDouble(txtVat1.Text));
            }
            else
            {
                txtNetAmt1.Text = Convert.ToString(Convert.ToDouble(txtAmount1.Text));
            }
            txtPrice.Text = Convert.ToString((txtNetAmt1.Text != "" ? double.Parse(txtNetAmt1.Text) : double.Parse("0")) + (txtNetAmt2.Text != "" ? double.Parse(txtNetAmt2.Text) : double.Parse("0")) + (txtNetAmt3.Text != "" ? double.Parse(txtNetAmt3.Text) : double.Parse("0")) + (txtNetAmt4.Text != "" ? double.Parse(txtNetAmt4.Text) : double.Parse("0")) + (txtNetAmt5.Text != "" ? double.Parse(txtNetAmt5.Text) : double.Parse("0")) + (txtNetAmt6.Text != "" ? double.Parse(txtNetAmt6.Text) : double.Parse("0")) + (txtNetAmt7.Text != "" ? double.Parse(txtNetAmt7.Text) : double.Parse("0")));
            txtVat.Text = Convert.ToString((txtVat1.Text != "" ? double.Parse(txtVat1.Text) : double.Parse("0")) + (txtVat2.Text != "" ? double.Parse(txtVat2.Text) : double.Parse("0")) + (txtVat3.Text != "" ? double.Parse(txtVat3.Text) : double.Parse("0")) + (txtVat4.Text != "" ? double.Parse(txtVat4.Text) : double.Parse("0")) + (txtVat5.Text != "" ? double.Parse(txtVat5.Text) : double.Parse("0")) + (txtVat6.Text != "" ? double.Parse(txtVat6.Text) : double.Parse("0")) + (txtVat7.Text != "" ? double.Parse(txtVat7.Text) : double.Parse("0")));
            txtAmtDV.Text = Convert.ToString((txtAmount1.Text != "" ? double.Parse(txtAmount1.Text) : double.Parse("0")) + (txtAmount2.Text != "" ? double.Parse(txtAmount2.Text) : double.Parse("0")) + (txtAmount3.Text != "" ? double.Parse(txtAmount3.Text) : double.Parse("0")) + (txtAmount4.Text != "" ? double.Parse(txtAmount4.Text) : double.Parse("0")) + (txtAmount5.Text != "" ? double.Parse(txtAmount5.Text) : double.Parse("0")) + (txtAmount6.Text != "" ? double.Parse(txtAmount6.Text) : double.Parse("0")) + (txtAmount7.Text != "" ? double.Parse(txtAmount7.Text) : double.Parse("0")));
        }


        protected void txtCode2_TextChanged(object sender, EventArgs e)
        {
            DataTableReader dr = getServices(1, txtCode2.Text);
            if (dr.Read())
            {
                txtEnName2.Text = Convert.ToString(dr["Name"]);
                txtArName2.Text = Convert.ToString(dr["ArName"]);
                txtAmount2.Text = Convert.ToString(dr["Price"]);
                hdnAmount2.Value = Convert.ToString(dr["Price"]);

                txtQty2.Text = "1";
                if (hdnlblNationality.Text != "3" && Convert.ToInt32(dr["VatApplyed"]) != 0)
                {
                    string amt = txtAmount2.Text;
                    txtVat2.Text = Convert.ToString(((amt != "" ? double.Parse(amt) : double.Parse("0")) * double.Parse(hdnVat.Value)) / 100);
                    txtNetAmt2.Text = Convert.ToString(double.Parse(amt) + double.Parse(txtVat2.Text));
                }
                else
                {
                    txtVat2.Text = "0";
                    txtNetAmt2.Text = txtAmount2.Text;
                }
                if (txtQty2.Text == "")
                {
                    txtQty2.Text = "1";
                }
                if (txtDisPer2.Text == "")
                {
                    txtDisPer2.Text = "0";
                }
                txtQty2_TextChanged(null, null);
                txtDisPer2_TextChanged(null, null);
                txtPrice.Text = Convert.ToString((txtNetAmt1.Text != "" ? double.Parse(txtNetAmt1.Text) : double.Parse("0")) + (txtNetAmt2.Text != "" ? double.Parse(txtNetAmt2.Text) : double.Parse("0")) + (txtNetAmt3.Text != "" ? double.Parse(txtNetAmt3.Text) : double.Parse("0")) + (txtNetAmt4.Text != "" ? double.Parse(txtNetAmt4.Text) : double.Parse("0")) + (txtNetAmt5.Text != "" ? double.Parse(txtNetAmt5.Text) : double.Parse("0")) + (txtNetAmt6.Text != "" ? double.Parse(txtNetAmt6.Text) : double.Parse("0")) + (txtNetAmt7.Text != "" ? double.Parse(txtNetAmt7.Text) : double.Parse("0")));
                txtVat.Text = Convert.ToString((txtVat1.Text != "" ? double.Parse(txtVat1.Text) : double.Parse("0")) + (txtVat2.Text != "" ? double.Parse(txtVat2.Text) : double.Parse("0")) + (txtVat3.Text != "" ? double.Parse(txtVat3.Text) : double.Parse("0")) + (txtVat4.Text != "" ? double.Parse(txtVat4.Text) : double.Parse("0")) + (txtVat5.Text != "" ? double.Parse(txtVat5.Text) : double.Parse("0")) + (txtVat6.Text != "" ? double.Parse(txtVat6.Text) : double.Parse("0")) + (txtVat7.Text != "" ? double.Parse(txtVat7.Text) : double.Parse("0")));
                txtAmtDV.Text = Convert.ToString((txtAmount1.Text != "" ? double.Parse(txtAmount1.Text) : double.Parse("0")) + (txtAmount2.Text != "" ? double.Parse(txtAmount2.Text) : double.Parse("0")) + (txtAmount3.Text != "" ? double.Parse(txtAmount3.Text) : double.Parse("0")) + (txtAmount4.Text != "" ? double.Parse(txtAmount4.Text) : double.Parse("0")) + (txtAmount5.Text != "" ? double.Parse(txtAmount5.Text) : double.Parse("0")) + (txtAmount6.Text != "" ? double.Parse(txtAmount6.Text) : double.Parse("0")) + (txtAmount7.Text != "" ? double.Parse(txtAmount7.Text) : double.Parse("0")));
            }
        }
        protected void txtAmount2_TextChanged(object sender, EventArgs e)
        {

        }
        protected void txtQty2_TextChanged(object sender, EventArgs e)
        {
            if (txtVat2.Text != "0")
            {
                string amt = Convert.ToString(Convert.ToDouble(hdnAmount2.Value) * Convert.ToInt32(txtQty2.Text));
                txtVat2.Text = Convert.ToString(((amt != "" ? double.Parse(amt) : double.Parse("0")) * double.Parse(hdnVat.Value)) / 100);
                txtNetAmt2.Text = Convert.ToString(double.Parse(amt) + double.Parse(txtVat2.Text));
            }
            else
            {
                txtNetAmt2.Text = Convert.ToString(Convert.ToDouble(hdnAmount2.Value) * Convert.ToInt32(txtQty2.Text));
            }
            txtAmount2.Text = Convert.ToString(Convert.ToDouble(hdnAmount2.Value) * Convert.ToInt32(txtQty2.Text));
            if (txtDisPer2.Text == "")
            {
                txtDisPer2.Text = "0";
            }
            txtDisPer2_TextChanged(null, null);
            txtPrice.Text = Convert.ToString((txtNetAmt1.Text != "" ? double.Parse(txtNetAmt1.Text) : double.Parse("0")) + (txtNetAmt2.Text != "" ? double.Parse(txtNetAmt2.Text) : double.Parse("0")) + (txtNetAmt3.Text != "" ? double.Parse(txtNetAmt3.Text) : double.Parse("0")) + (txtNetAmt4.Text != "" ? double.Parse(txtNetAmt4.Text) : double.Parse("0")) + (txtNetAmt5.Text != "" ? double.Parse(txtNetAmt5.Text) : double.Parse("0")) + (txtNetAmt6.Text != "" ? double.Parse(txtNetAmt6.Text) : double.Parse("0")) + (txtNetAmt7.Text != "" ? double.Parse(txtNetAmt7.Text) : double.Parse("0")));
            txtVat.Text = Convert.ToString((txtVat1.Text != "" ? double.Parse(txtVat1.Text) : double.Parse("0")) + (txtVat2.Text != "" ? double.Parse(txtVat2.Text) : double.Parse("0")) + (txtVat3.Text != "" ? double.Parse(txtVat3.Text) : double.Parse("0")) + (txtVat4.Text != "" ? double.Parse(txtVat4.Text) : double.Parse("0")) + (txtVat5.Text != "" ? double.Parse(txtVat5.Text) : double.Parse("0")) + (txtVat6.Text != "" ? double.Parse(txtVat6.Text) : double.Parse("0")) + (txtVat7.Text != "" ? double.Parse(txtVat7.Text) : double.Parse("0")));
            txtAmtDV.Text = Convert.ToString((txtAmount1.Text != "" ? double.Parse(txtAmount1.Text) : double.Parse("0")) + (txtAmount2.Text != "" ? double.Parse(txtAmount2.Text) : double.Parse("0")) + (txtAmount3.Text != "" ? double.Parse(txtAmount3.Text) : double.Parse("0")) + (txtAmount4.Text != "" ? double.Parse(txtAmount4.Text) : double.Parse("0")) + (txtAmount5.Text != "" ? double.Parse(txtAmount5.Text) : double.Parse("0")) + (txtAmount6.Text != "" ? double.Parse(txtAmount6.Text) : double.Parse("0")) + (txtAmount7.Text != "" ? double.Parse(txtAmount7.Text) : double.Parse("0")));
        }
        protected void txtDisPer2_TextChanged(object sender, EventArgs e)
        {
            txtAmount2.Text = Convert.ToString(((Convert.ToDouble(hdnAmount2.Value) * Convert.ToInt32(txtQty2.Text)) - ((Convert.ToDouble(hdnAmount2.Value) * Convert.ToInt32(txtQty2.Text)) * (Convert.ToDouble(txtDisPer2.Text) / 100))));
            txtDisAmt2.Text = Convert.ToString((Convert.ToDouble(hdnAmount2.Value) * Convert.ToInt32(txtQty2.Text)) * (Convert.ToDouble(txtDisPer2.Text) / 100));
            if (txtVat2.Text != "0")
            {
                string amt = Convert.ToString(Convert.ToDouble(txtAmount2.Text));
                txtVat2.Text = Convert.ToString((Convert.ToDouble(amt) * double.Parse(hdnVat.Value)) / 100);
                txtNetAmt2.Text = Convert.ToString(Convert.ToDouble(amt) + Convert.ToDouble(txtVat2.Text));
            }
            else
            {
                txtNetAmt2.Text = Convert.ToString(Convert.ToDouble(txtAmount2.Text));
            }
            txtPrice.Text = Convert.ToString((txtNetAmt1.Text != "" ? double.Parse(txtNetAmt1.Text) : double.Parse("0")) + (txtNetAmt2.Text != "" ? double.Parse(txtNetAmt2.Text) : double.Parse("0")) + (txtNetAmt3.Text != "" ? double.Parse(txtNetAmt3.Text) : double.Parse("0")) + (txtNetAmt4.Text != "" ? double.Parse(txtNetAmt4.Text) : double.Parse("0")) + (txtNetAmt5.Text != "" ? double.Parse(txtNetAmt5.Text) : double.Parse("0")) + (txtNetAmt6.Text != "" ? double.Parse(txtNetAmt6.Text) : double.Parse("0")) + (txtNetAmt7.Text != "" ? double.Parse(txtNetAmt7.Text) : double.Parse("0")));
            txtVat.Text = Convert.ToString((txtVat1.Text != "" ? double.Parse(txtVat1.Text) : double.Parse("0")) + (txtVat2.Text != "" ? double.Parse(txtVat2.Text) : double.Parse("0")) + (txtVat3.Text != "" ? double.Parse(txtVat3.Text) : double.Parse("0")) + (txtVat4.Text != "" ? double.Parse(txtVat4.Text) : double.Parse("0")) + (txtVat5.Text != "" ? double.Parse(txtVat5.Text) : double.Parse("0")) + (txtVat6.Text != "" ? double.Parse(txtVat6.Text) : double.Parse("0")) + (txtVat7.Text != "" ? double.Parse(txtVat7.Text) : double.Parse("0")));
            txtAmtDV.Text = Convert.ToString((txtAmount1.Text != "" ? double.Parse(txtAmount1.Text) : double.Parse("0")) + (txtAmount2.Text != "" ? double.Parse(txtAmount2.Text) : double.Parse("0")) + (txtAmount3.Text != "" ? double.Parse(txtAmount3.Text) : double.Parse("0")) + (txtAmount4.Text != "" ? double.Parse(txtAmount4.Text) : double.Parse("0")) + (txtAmount5.Text != "" ? double.Parse(txtAmount5.Text) : double.Parse("0")) + (txtAmount6.Text != "" ? double.Parse(txtAmount6.Text) : double.Parse("0")) + (txtAmount7.Text != "" ? double.Parse(txtAmount7.Text) : double.Parse("0")));
        }
        protected void txtDisAmt2_TextChanged(object sender, EventArgs e)
        {
            txtAmount2.Text = Convert.ToString((Convert.ToDouble(hdnAmount2.Value) * Convert.ToInt32(txtQty2.Text)) - (Convert.ToDouble(txtDisAmt2.Text)));
            txtDisPer2.Text = Convert.ToString((Convert.ToDouble(txtDisAmt2.Text) / (Convert.ToDouble(hdnAmount2.Value) * Convert.ToInt32(txtQty2.Text))) * 100);
            if (txtVat2.Text != "0")
            {
                string amt = Convert.ToString(Convert.ToDouble(txtAmount2.Text));
                txtVat2.Text = Convert.ToString((Convert.ToDouble(amt) * double.Parse(hdnVat.Value)) / 100);
                txtNetAmt2.Text = Convert.ToString(Convert.ToDouble(amt) + Convert.ToDouble(txtVat2.Text));
            }
            else
            {
                txtNetAmt2.Text = Convert.ToString(Convert.ToDouble(txtAmount2.Text));
            }
            txtPrice.Text = Convert.ToString((txtNetAmt1.Text != "" ? double.Parse(txtNetAmt1.Text) : double.Parse("0")) + (txtNetAmt2.Text != "" ? double.Parse(txtNetAmt2.Text) : double.Parse("0")) + (txtNetAmt3.Text != "" ? double.Parse(txtNetAmt3.Text) : double.Parse("0")) + (txtNetAmt4.Text != "" ? double.Parse(txtNetAmt4.Text) : double.Parse("0")) + (txtNetAmt5.Text != "" ? double.Parse(txtNetAmt5.Text) : double.Parse("0")) + (txtNetAmt6.Text != "" ? double.Parse(txtNetAmt6.Text) : double.Parse("0")) + (txtNetAmt7.Text != "" ? double.Parse(txtNetAmt7.Text) : double.Parse("0")));
            txtVat.Text = Convert.ToString((txtVat1.Text != "" ? double.Parse(txtVat1.Text) : double.Parse("0")) + (txtVat2.Text != "" ? double.Parse(txtVat2.Text) : double.Parse("0")) + (txtVat3.Text != "" ? double.Parse(txtVat3.Text) : double.Parse("0")) + (txtVat4.Text != "" ? double.Parse(txtVat4.Text) : double.Parse("0")) + (txtVat5.Text != "" ? double.Parse(txtVat5.Text) : double.Parse("0")) + (txtVat6.Text != "" ? double.Parse(txtVat6.Text) : double.Parse("0")) + (txtVat7.Text != "" ? double.Parse(txtVat7.Text) : double.Parse("0")));
            txtAmtDV.Text = Convert.ToString((txtAmount1.Text != "" ? double.Parse(txtAmount1.Text) : double.Parse("0")) + (txtAmount2.Text != "" ? double.Parse(txtAmount2.Text) : double.Parse("0")) + (txtAmount3.Text != "" ? double.Parse(txtAmount3.Text) : double.Parse("0")) + (txtAmount4.Text != "" ? double.Parse(txtAmount4.Text) : double.Parse("0")) + (txtAmount5.Text != "" ? double.Parse(txtAmount5.Text) : double.Parse("0")) + (txtAmount6.Text != "" ? double.Parse(txtAmount6.Text) : double.Parse("0")) + (txtAmount7.Text != "" ? double.Parse(txtAmount7.Text) : double.Parse("0")));
        }

        protected void txtCode3_TextChanged(object sender, EventArgs e)
        {
            DataTableReader dr = getServices(1, txtCode3.Text);
            if (dr.Read())
            {
                txtEnName3.Text = Convert.ToString(dr["Name"]);
                txtArName3.Text = Convert.ToString(dr["ArName"]);
                txtAmount3.Text = Convert.ToString(dr["Price"]);
                hdnAmount3.Value = Convert.ToString(dr["Price"]);

                txtQty3.Text = "1";
                if (hdnlblNationality.Text != "3" && Convert.ToInt32(dr["VatApplyed"]) != 0)
                {
                    string amt = txtAmount3.Text;
                    txtVat3.Text = Convert.ToString(((amt != "" ? double.Parse(amt) : double.Parse("0")) * double.Parse(hdnVat.Value)) / 100);
                    txtNetAmt3.Text = Convert.ToString(double.Parse(amt) + double.Parse(txtVat3.Text));
                }
                else
                {
                    txtVat3.Text = "0";
                    txtNetAmt3.Text = txtAmount3.Text;
                }
                if (txtQty3.Text == "")
                {
                    txtQty3.Text = "1";
                }
                if (txtDisPer3.Text == "")
                {
                    txtDisPer3.Text = "0";
                }
                txtQty3_TextChanged(null, null);
                txtDisPer3_TextChanged(null, null);
                txtPrice.Text = Convert.ToString((txtNetAmt1.Text != "" ? double.Parse(txtNetAmt1.Text) : double.Parse("0")) + (txtNetAmt2.Text != "" ? double.Parse(txtNetAmt2.Text) : double.Parse("0")) + (txtNetAmt3.Text != "" ? double.Parse(txtNetAmt3.Text) : double.Parse("0")) + (txtNetAmt4.Text != "" ? double.Parse(txtNetAmt4.Text) : double.Parse("0")) + (txtNetAmt5.Text != "" ? double.Parse(txtNetAmt5.Text) : double.Parse("0")) + (txtNetAmt6.Text != "" ? double.Parse(txtNetAmt6.Text) : double.Parse("0")) + (txtNetAmt7.Text != "" ? double.Parse(txtNetAmt7.Text) : double.Parse("0")));
                txtVat.Text = Convert.ToString((txtVat1.Text != "" ? double.Parse(txtVat1.Text) : double.Parse("0")) + (txtVat2.Text != "" ? double.Parse(txtVat2.Text) : double.Parse("0")) + (txtVat3.Text != "" ? double.Parse(txtVat3.Text) : double.Parse("0")) + (txtVat4.Text != "" ? double.Parse(txtVat4.Text) : double.Parse("0")) + (txtVat5.Text != "" ? double.Parse(txtVat5.Text) : double.Parse("0")) + (txtVat6.Text != "" ? double.Parse(txtVat6.Text) : double.Parse("0")) + (txtVat7.Text != "" ? double.Parse(txtVat7.Text) : double.Parse("0")));
                txtAmtDV.Text = Convert.ToString((txtAmount1.Text != "" ? double.Parse(txtAmount1.Text) : double.Parse("0")) + (txtAmount2.Text != "" ? double.Parse(txtAmount2.Text) : double.Parse("0")) + (txtAmount3.Text != "" ? double.Parse(txtAmount3.Text) : double.Parse("0")) + (txtAmount4.Text != "" ? double.Parse(txtAmount4.Text) : double.Parse("0")) + (txtAmount5.Text != "" ? double.Parse(txtAmount5.Text) : double.Parse("0")) + (txtAmount6.Text != "" ? double.Parse(txtAmount6.Text) : double.Parse("0")) + (txtAmount7.Text != "" ? double.Parse(txtAmount7.Text) : double.Parse("0")));
            }
        }
        protected void txtAmount3_TextChanged(object sender, EventArgs e)
        {

        }
        protected void txtQty3_TextChanged(object sender, EventArgs e)
        {
            if (txtVat3.Text != "0")
            {
                string amt = Convert.ToString(Convert.ToDouble(hdnAmount3.Value) * Convert.ToInt32(txtQty3.Text));
                txtVat3.Text = Convert.ToString(((amt != "" ? double.Parse(amt) : double.Parse("0")) * double.Parse(hdnVat.Value)) / 100);
                txtNetAmt3.Text = Convert.ToString(double.Parse(amt) + double.Parse(txtVat3.Text));
            }
            else
            {
                txtNetAmt3.Text = Convert.ToString(Convert.ToDouble(hdnAmount3.Value) * Convert.ToInt32(txtQty3.Text));
            }
            txtAmount3.Text = Convert.ToString(Convert.ToDouble(hdnAmount3.Value) * Convert.ToInt32(txtQty3.Text));
            if (txtDisPer3.Text == "")
            {
                txtDisPer3.Text = "0";
            }
            txtDisPer3_TextChanged(null, null);
            txtPrice.Text = Convert.ToString((txtNetAmt1.Text != "" ? double.Parse(txtNetAmt1.Text) : double.Parse("0")) + (txtNetAmt2.Text != "" ? double.Parse(txtNetAmt2.Text) : double.Parse("0")) + (txtNetAmt3.Text != "" ? double.Parse(txtNetAmt3.Text) : double.Parse("0")) + (txtNetAmt4.Text != "" ? double.Parse(txtNetAmt4.Text) : double.Parse("0")) + (txtNetAmt5.Text != "" ? double.Parse(txtNetAmt5.Text) : double.Parse("0")) + (txtNetAmt6.Text != "" ? double.Parse(txtNetAmt6.Text) : double.Parse("0")) + (txtNetAmt7.Text != "" ? double.Parse(txtNetAmt7.Text) : double.Parse("0")));
            txtVat.Text = Convert.ToString((txtVat1.Text != "" ? double.Parse(txtVat1.Text) : double.Parse("0")) + (txtVat2.Text != "" ? double.Parse(txtVat2.Text) : double.Parse("0")) + (txtVat3.Text != "" ? double.Parse(txtVat3.Text) : double.Parse("0")) + (txtVat4.Text != "" ? double.Parse(txtVat4.Text) : double.Parse("0")) + (txtVat5.Text != "" ? double.Parse(txtVat5.Text) : double.Parse("0")) + (txtVat6.Text != "" ? double.Parse(txtVat6.Text) : double.Parse("0")) + (txtVat7.Text != "" ? double.Parse(txtVat7.Text) : double.Parse("0")));
            txtAmtDV.Text = Convert.ToString((txtAmount1.Text != "" ? double.Parse(txtAmount1.Text) : double.Parse("0")) + (txtAmount2.Text != "" ? double.Parse(txtAmount2.Text) : double.Parse("0")) + (txtAmount3.Text != "" ? double.Parse(txtAmount3.Text) : double.Parse("0")) + (txtAmount4.Text != "" ? double.Parse(txtAmount4.Text) : double.Parse("0")) + (txtAmount5.Text != "" ? double.Parse(txtAmount5.Text) : double.Parse("0")) + (txtAmount6.Text != "" ? double.Parse(txtAmount6.Text) : double.Parse("0")) + (txtAmount7.Text != "" ? double.Parse(txtAmount7.Text) : double.Parse("0")));
        }
        protected void txtDisPer3_TextChanged(object sender, EventArgs e)
        {
            txtAmount3.Text = Convert.ToString(((Convert.ToDouble(hdnAmount3.Value) * Convert.ToInt32(txtQty3.Text)) - ((Convert.ToDouble(hdnAmount3.Value) * Convert.ToInt32(txtQty3.Text)) * (Convert.ToDouble(txtDisPer3.Text) / 100))));
            txtDisAmt3.Text = Convert.ToString((Convert.ToDouble(hdnAmount3.Value) * Convert.ToInt32(txtQty3.Text)) * (Convert.ToDouble(txtDisPer3.Text) / 100));
            if (txtVat3.Text != "0")
            {
                string amt = Convert.ToString(Convert.ToDouble(txtAmount3.Text));
                txtVat3.Text = Convert.ToString((Convert.ToDouble(amt) * double.Parse(hdnVat.Value)) / 100);
                txtNetAmt3.Text = Convert.ToString(Convert.ToDouble(amt) + Convert.ToDouble(txtVat3.Text));
            }
            else
            {
                txtNetAmt3.Text = Convert.ToString(Convert.ToDouble(txtAmount3.Text));
            }
            txtPrice.Text = Convert.ToString((txtNetAmt1.Text != "" ? double.Parse(txtNetAmt1.Text) : double.Parse("0")) + (txtNetAmt2.Text != "" ? double.Parse(txtNetAmt2.Text) : double.Parse("0")) + (txtNetAmt3.Text != "" ? double.Parse(txtNetAmt3.Text) : double.Parse("0")) + (txtNetAmt4.Text != "" ? double.Parse(txtNetAmt4.Text) : double.Parse("0")) + (txtNetAmt5.Text != "" ? double.Parse(txtNetAmt5.Text) : double.Parse("0")) + (txtNetAmt6.Text != "" ? double.Parse(txtNetAmt6.Text) : double.Parse("0")) + (txtNetAmt7.Text != "" ? double.Parse(txtNetAmt7.Text) : double.Parse("0")));
            txtVat.Text = Convert.ToString((txtVat1.Text != "" ? double.Parse(txtVat1.Text) : double.Parse("0")) + (txtVat2.Text != "" ? double.Parse(txtVat2.Text) : double.Parse("0")) + (txtVat3.Text != "" ? double.Parse(txtVat3.Text) : double.Parse("0")) + (txtVat4.Text != "" ? double.Parse(txtVat4.Text) : double.Parse("0")) + (txtVat5.Text != "" ? double.Parse(txtVat5.Text) : double.Parse("0")) + (txtVat6.Text != "" ? double.Parse(txtVat6.Text) : double.Parse("0")) + (txtVat7.Text != "" ? double.Parse(txtVat7.Text) : double.Parse("0")));
            txtAmtDV.Text = Convert.ToString((txtAmount1.Text != "" ? double.Parse(txtAmount1.Text) : double.Parse("0")) + (txtAmount2.Text != "" ? double.Parse(txtAmount2.Text) : double.Parse("0")) + (txtAmount3.Text != "" ? double.Parse(txtAmount3.Text) : double.Parse("0")) + (txtAmount4.Text != "" ? double.Parse(txtAmount4.Text) : double.Parse("0")) + (txtAmount5.Text != "" ? double.Parse(txtAmount5.Text) : double.Parse("0")) + (txtAmount6.Text != "" ? double.Parse(txtAmount6.Text) : double.Parse("0")) + (txtAmount7.Text != "" ? double.Parse(txtAmount7.Text) : double.Parse("0")));
        }
        protected void txtDisAmt3_TextChanged(object sender, EventArgs e)
        {
            txtAmount3.Text = Convert.ToString((Convert.ToDouble(hdnAmount3.Value) * Convert.ToInt32(txtQty3.Text)) - (Convert.ToDouble(txtDisAmt3.Text)));
            txtDisPer3.Text = Convert.ToString((Convert.ToDouble(txtDisAmt3.Text) / (Convert.ToDouble(hdnAmount3.Value) * Convert.ToInt32(txtQty3.Text))) * 100);
            if (txtVat3.Text != "0")
            {
                string amt = Convert.ToString(Convert.ToDouble(txtAmount3.Text));
                txtVat3.Text = Convert.ToString((Convert.ToDouble(amt) * double.Parse(hdnVat.Value)) / 100);
                txtNetAmt3.Text = Convert.ToString(Convert.ToDouble(amt) + Convert.ToDouble(txtVat3.Text));
            }
            else
            {
                txtNetAmt3.Text = Convert.ToString(Convert.ToDouble(txtAmount3.Text));
            }
            txtPrice.Text = Convert.ToString((txtNetAmt1.Text != "" ? double.Parse(txtNetAmt1.Text) : double.Parse("0")) + (txtNetAmt2.Text != "" ? double.Parse(txtNetAmt2.Text) : double.Parse("0")) + (txtNetAmt3.Text != "" ? double.Parse(txtNetAmt3.Text) : double.Parse("0")) + (txtNetAmt4.Text != "" ? double.Parse(txtNetAmt4.Text) : double.Parse("0")) + (txtNetAmt5.Text != "" ? double.Parse(txtNetAmt5.Text) : double.Parse("0")) + (txtNetAmt6.Text != "" ? double.Parse(txtNetAmt6.Text) : double.Parse("0")) + (txtNetAmt7.Text != "" ? double.Parse(txtNetAmt7.Text) : double.Parse("0")));
            txtVat.Text = Convert.ToString((txtVat1.Text != "" ? double.Parse(txtVat1.Text) : double.Parse("0")) + (txtVat2.Text != "" ? double.Parse(txtVat2.Text) : double.Parse("0")) + (txtVat3.Text != "" ? double.Parse(txtVat3.Text) : double.Parse("0")) + (txtVat4.Text != "" ? double.Parse(txtVat4.Text) : double.Parse("0")) + (txtVat5.Text != "" ? double.Parse(txtVat5.Text) : double.Parse("0")) + (txtVat6.Text != "" ? double.Parse(txtVat6.Text) : double.Parse("0")) + (txtVat7.Text != "" ? double.Parse(txtVat7.Text) : double.Parse("0")));
            txtAmtDV.Text = Convert.ToString((txtAmount1.Text != "" ? double.Parse(txtAmount1.Text) : double.Parse("0")) + (txtAmount2.Text != "" ? double.Parse(txtAmount2.Text) : double.Parse("0")) + (txtAmount3.Text != "" ? double.Parse(txtAmount3.Text) : double.Parse("0")) + (txtAmount4.Text != "" ? double.Parse(txtAmount4.Text) : double.Parse("0")) + (txtAmount5.Text != "" ? double.Parse(txtAmount5.Text) : double.Parse("0")) + (txtAmount6.Text != "" ? double.Parse(txtAmount6.Text) : double.Parse("0")) + (txtAmount7.Text != "" ? double.Parse(txtAmount7.Text) : double.Parse("0")));
        }

        protected void txtCode4_TextChanged(object sender, EventArgs e)
        {
            DataTableReader dr = getServices(1, txtCode4.Text);
            if (dr.Read())
            {
                txtEnName4.Text = Convert.ToString(dr["Name"]);
                txtArName4.Text = Convert.ToString(dr["ArName"]);
                txtAmount4.Text = Convert.ToString(dr["Price"]);
                hdnAmount4.Value = Convert.ToString(dr["Price"]);

                txtQty4.Text = "1";
                if (hdnlblNationality.Text != "3" && Convert.ToInt32(dr["VatApplyed"]) != 0)
                {
                    string amt = txtAmount4.Text;
                    txtVat4.Text = Convert.ToString(((amt != "" ? double.Parse(amt) : double.Parse("0")) * double.Parse(hdnVat.Value)) / 100);
                    txtNetAmt4.Text = Convert.ToString(double.Parse(amt) + double.Parse(txtVat4.Text));
                }
                else
                {
                    txtVat4.Text = "0";
                    txtNetAmt4.Text = txtAmount4.Text;
                }
                if (txtQty4.Text == "")
                {
                    txtQty4.Text = "1";
                }
                if (txtDisPer4.Text == "")
                {
                    txtDisPer4.Text = "0";
                }
                txtQty4_TextChanged(null, null);
                txtDisPer4_TextChanged(null, null);
                txtPrice.Text = Convert.ToString((txtNetAmt1.Text != "" ? double.Parse(txtNetAmt1.Text) : double.Parse("0")) + (txtNetAmt2.Text != "" ? double.Parse(txtNetAmt2.Text) : double.Parse("0")) + (txtNetAmt3.Text != "" ? double.Parse(txtNetAmt3.Text) : double.Parse("0")) + (txtNetAmt4.Text != "" ? double.Parse(txtNetAmt4.Text) : double.Parse("0")) + (txtNetAmt5.Text != "" ? double.Parse(txtNetAmt5.Text) : double.Parse("0")) + (txtNetAmt6.Text != "" ? double.Parse(txtNetAmt6.Text) : double.Parse("0")) + (txtNetAmt7.Text != "" ? double.Parse(txtNetAmt7.Text) : double.Parse("0")));
                txtVat.Text = Convert.ToString((txtVat1.Text != "" ? double.Parse(txtVat1.Text) : double.Parse("0")) + (txtVat2.Text != "" ? double.Parse(txtVat2.Text) : double.Parse("0")) + (txtVat3.Text != "" ? double.Parse(txtVat3.Text) : double.Parse("0")) + (txtVat4.Text != "" ? double.Parse(txtVat4.Text) : double.Parse("0")) + (txtVat5.Text != "" ? double.Parse(txtVat5.Text) : double.Parse("0")) + (txtVat6.Text != "" ? double.Parse(txtVat6.Text) : double.Parse("0")) + (txtVat7.Text != "" ? double.Parse(txtVat7.Text) : double.Parse("0")));
                txtAmtDV.Text = Convert.ToString((txtAmount1.Text != "" ? double.Parse(txtAmount1.Text) : double.Parse("0")) + (txtAmount2.Text != "" ? double.Parse(txtAmount2.Text) : double.Parse("0")) + (txtAmount3.Text != "" ? double.Parse(txtAmount3.Text) : double.Parse("0")) + (txtAmount4.Text != "" ? double.Parse(txtAmount4.Text) : double.Parse("0")) + (txtAmount5.Text != "" ? double.Parse(txtAmount5.Text) : double.Parse("0")) + (txtAmount6.Text != "" ? double.Parse(txtAmount6.Text) : double.Parse("0")) + (txtAmount7.Text != "" ? double.Parse(txtAmount7.Text) : double.Parse("0")));
            }
        }
        protected void txtAmount4_TextChanged(object sender, EventArgs e)
        {

        }
        protected void txtQty4_TextChanged(object sender, EventArgs e)
        {
            if (txtVat4.Text != "0")
            {
                string amt = Convert.ToString(Convert.ToDouble(hdnAmount4.Value) * Convert.ToInt32(txtQty4.Text));
                txtVat4.Text = Convert.ToString(((amt != "" ? double.Parse(amt) : double.Parse("0")) * double.Parse(hdnVat.Value)) / 100);
                txtNetAmt4.Text = Convert.ToString(double.Parse(amt) + double.Parse(txtVat4.Text));
            }
            else
            {
                txtNetAmt4.Text = Convert.ToString(Convert.ToDouble(hdnAmount4.Value) * Convert.ToInt32(txtQty4.Text));
            }
            txtAmount4.Text = Convert.ToString(Convert.ToDouble(hdnAmount4.Value) * Convert.ToInt32(txtQty4.Text));
            if (txtDisPer4.Text == "")
            {
                txtDisPer4.Text = "0";
            }
            txtDisPer4_TextChanged(null, null);
            txtPrice.Text = Convert.ToString((txtNetAmt1.Text != "" ? double.Parse(txtNetAmt1.Text) : double.Parse("0")) + (txtNetAmt2.Text != "" ? double.Parse(txtNetAmt2.Text) : double.Parse("0")) + (txtNetAmt3.Text != "" ? double.Parse(txtNetAmt3.Text) : double.Parse("0")) + (txtNetAmt4.Text != "" ? double.Parse(txtNetAmt4.Text) : double.Parse("0")) + (txtNetAmt5.Text != "" ? double.Parse(txtNetAmt5.Text) : double.Parse("0")) + (txtNetAmt6.Text != "" ? double.Parse(txtNetAmt6.Text) : double.Parse("0")) + (txtNetAmt7.Text != "" ? double.Parse(txtNetAmt7.Text) : double.Parse("0")));
            txtVat.Text = Convert.ToString((txtVat1.Text != "" ? double.Parse(txtVat1.Text) : double.Parse("0")) + (txtVat2.Text != "" ? double.Parse(txtVat2.Text) : double.Parse("0")) + (txtVat3.Text != "" ? double.Parse(txtVat3.Text) : double.Parse("0")) + (txtVat4.Text != "" ? double.Parse(txtVat4.Text) : double.Parse("0")) + (txtVat5.Text != "" ? double.Parse(txtVat5.Text) : double.Parse("0")) + (txtVat6.Text != "" ? double.Parse(txtVat6.Text) : double.Parse("0")) + (txtVat7.Text != "" ? double.Parse(txtVat7.Text) : double.Parse("0")));
            txtAmtDV.Text = Convert.ToString((txtAmount1.Text != "" ? double.Parse(txtAmount1.Text) : double.Parse("0")) + (txtAmount2.Text != "" ? double.Parse(txtAmount2.Text) : double.Parse("0")) + (txtAmount3.Text != "" ? double.Parse(txtAmount3.Text) : double.Parse("0")) + (txtAmount4.Text != "" ? double.Parse(txtAmount4.Text) : double.Parse("0")) + (txtAmount5.Text != "" ? double.Parse(txtAmount5.Text) : double.Parse("0")) + (txtAmount6.Text != "" ? double.Parse(txtAmount6.Text) : double.Parse("0")) + (txtAmount7.Text != "" ? double.Parse(txtAmount7.Text) : double.Parse("0")));
        }
        protected void txtDisPer4_TextChanged(object sender, EventArgs e)
        {
            txtAmount4.Text = Convert.ToString(((Convert.ToDouble(hdnAmount4.Value) * Convert.ToInt32(txtQty4.Text)) - ((Convert.ToDouble(hdnAmount4.Value) * Convert.ToInt32(txtQty4.Text)) * (Convert.ToDouble(txtDisPer4.Text) / 100))));
            txtDisAmt4.Text = Convert.ToString((Convert.ToDouble(hdnAmount4.Value) * Convert.ToInt32(txtQty4.Text)) * (Convert.ToDouble(txtDisPer4.Text) / 100));
            if (txtVat4.Text != "0")
            {
                string amt = Convert.ToString(Convert.ToDouble(txtAmount4.Text));
                txtVat4.Text = Convert.ToString((Convert.ToDouble(amt) * double.Parse(hdnVat.Value)) / 100);
                txtNetAmt4.Text = Convert.ToString(Convert.ToDouble(amt) + Convert.ToDouble(txtVat4.Text));
            }
            else
            {
                txtNetAmt4.Text = Convert.ToString(Convert.ToDouble(txtAmount4.Text));
            }
            txtPrice.Text = Convert.ToString((txtNetAmt1.Text != "" ? double.Parse(txtNetAmt1.Text) : double.Parse("0")) + (txtNetAmt2.Text != "" ? double.Parse(txtNetAmt2.Text) : double.Parse("0")) + (txtNetAmt3.Text != "" ? double.Parse(txtNetAmt3.Text) : double.Parse("0")) + (txtNetAmt4.Text != "" ? double.Parse(txtNetAmt4.Text) : double.Parse("0")) + (txtNetAmt5.Text != "" ? double.Parse(txtNetAmt5.Text) : double.Parse("0")) + (txtNetAmt6.Text != "" ? double.Parse(txtNetAmt6.Text) : double.Parse("0")) + (txtNetAmt7.Text != "" ? double.Parse(txtNetAmt7.Text) : double.Parse("0")));
            txtVat.Text = Convert.ToString((txtVat1.Text != "" ? double.Parse(txtVat1.Text) : double.Parse("0")) + (txtVat2.Text != "" ? double.Parse(txtVat2.Text) : double.Parse("0")) + (txtVat3.Text != "" ? double.Parse(txtVat3.Text) : double.Parse("0")) + (txtVat4.Text != "" ? double.Parse(txtVat4.Text) : double.Parse("0")) + (txtVat5.Text != "" ? double.Parse(txtVat5.Text) : double.Parse("0")) + (txtVat6.Text != "" ? double.Parse(txtVat6.Text) : double.Parse("0")) + (txtVat7.Text != "" ? double.Parse(txtVat7.Text) : double.Parse("0")));
            txtAmtDV.Text = Convert.ToString((txtAmount1.Text != "" ? double.Parse(txtAmount1.Text) : double.Parse("0")) + (txtAmount2.Text != "" ? double.Parse(txtAmount2.Text) : double.Parse("0")) + (txtAmount3.Text != "" ? double.Parse(txtAmount3.Text) : double.Parse("0")) + (txtAmount4.Text != "" ? double.Parse(txtAmount4.Text) : double.Parse("0")) + (txtAmount5.Text != "" ? double.Parse(txtAmount5.Text) : double.Parse("0")) + (txtAmount6.Text != "" ? double.Parse(txtAmount6.Text) : double.Parse("0")) + (txtAmount7.Text != "" ? double.Parse(txtAmount7.Text) : double.Parse("0")));
        }
        protected void txtDisAmt4_TextChanged(object sender, EventArgs e)
        {
            txtAmount4.Text = Convert.ToString((Convert.ToDouble(hdnAmount4.Value) * Convert.ToInt32(txtQty4.Text)) - (Convert.ToDouble(txtDisAmt4.Text)));
            txtDisPer4.Text = Convert.ToString((Convert.ToDouble(txtDisAmt4.Text) / (Convert.ToDouble(hdnAmount4.Value) * Convert.ToInt32(txtQty4.Text))) * 100);
            if (txtVat4.Text != "0")
            {
                string amt = Convert.ToString(Convert.ToDouble(txtAmount4.Text));
                txtVat4.Text = Convert.ToString((Convert.ToDouble(amt) * double.Parse(hdnVat.Value)) / 100);
                txtNetAmt4.Text = Convert.ToString(Convert.ToDouble(amt) + Convert.ToDouble(txtVat4.Text));
            }
            else
            {
                txtNetAmt4.Text = Convert.ToString(Convert.ToDouble(txtAmount4.Text));
            }
            txtPrice.Text = Convert.ToString((txtNetAmt1.Text != "" ? double.Parse(txtNetAmt1.Text) : double.Parse("0")) + (txtNetAmt2.Text != "" ? double.Parse(txtNetAmt2.Text) : double.Parse("0")) + (txtNetAmt3.Text != "" ? double.Parse(txtNetAmt3.Text) : double.Parse("0")) + (txtNetAmt4.Text != "" ? double.Parse(txtNetAmt4.Text) : double.Parse("0")) + (txtNetAmt5.Text != "" ? double.Parse(txtNetAmt5.Text) : double.Parse("0")) + (txtNetAmt6.Text != "" ? double.Parse(txtNetAmt6.Text) : double.Parse("0")) + (txtNetAmt7.Text != "" ? double.Parse(txtNetAmt7.Text) : double.Parse("0")));
            txtVat.Text = Convert.ToString((txtVat1.Text != "" ? double.Parse(txtVat1.Text) : double.Parse("0")) + (txtVat2.Text != "" ? double.Parse(txtVat2.Text) : double.Parse("0")) + (txtVat3.Text != "" ? double.Parse(txtVat3.Text) : double.Parse("0")) + (txtVat4.Text != "" ? double.Parse(txtVat4.Text) : double.Parse("0")) + (txtVat5.Text != "" ? double.Parse(txtVat5.Text) : double.Parse("0")) + (txtVat6.Text != "" ? double.Parse(txtVat6.Text) : double.Parse("0")) + (txtVat7.Text != "" ? double.Parse(txtVat7.Text) : double.Parse("0")));
            txtAmtDV.Text = Convert.ToString((txtAmount1.Text != "" ? double.Parse(txtAmount1.Text) : double.Parse("0")) + (txtAmount2.Text != "" ? double.Parse(txtAmount2.Text) : double.Parse("0")) + (txtAmount3.Text != "" ? double.Parse(txtAmount3.Text) : double.Parse("0")) + (txtAmount4.Text != "" ? double.Parse(txtAmount4.Text) : double.Parse("0")) + (txtAmount5.Text != "" ? double.Parse(txtAmount5.Text) : double.Parse("0")) + (txtAmount6.Text != "" ? double.Parse(txtAmount6.Text) : double.Parse("0")) + (txtAmount7.Text != "" ? double.Parse(txtAmount7.Text) : double.Parse("0")));
        }

        protected void txtCode5_TextChanged(object sender, EventArgs e)
        {
            DataTableReader dr = getServices(1, txtCode5.Text);
            if (dr.Read())
            {
                txtEnName5.Text = Convert.ToString(dr["Name"]);
                txtArName5.Text = Convert.ToString(dr["ArName"]);
                txtAmount5.Text = Convert.ToString(dr["Price"]);
                hdnAmount5.Value = Convert.ToString(dr["Price"]);

                txtQty5.Text = "1";
                if (hdnlblNationality.Text != "3" && Convert.ToInt32(dr["VatApplyed"]) != 0)
                {
                    string amt = txtAmount5.Text;
                    txtVat5.Text = Convert.ToString(((amt != "" ? double.Parse(amt) : double.Parse("0")) * double.Parse(hdnVat.Value)) / 100);
                    txtNetAmt5.Text = Convert.ToString(double.Parse(amt) + double.Parse(txtVat5.Text));
                }
                else
                {
                    txtVat5.Text = "0";
                    txtNetAmt5.Text = txtAmount5.Text;
                }
                if (txtQty5.Text == "")
                {
                    txtQty5.Text = "1";
                }
                if (txtDisPer5.Text == "")
                {
                    txtDisPer5.Text = "0";
                }
                txtQty5_TextChanged(null, null);
                txtDisPer5_TextChanged(null, null);
                txtPrice.Text = Convert.ToString((txtNetAmt1.Text != "" ? double.Parse(txtNetAmt1.Text) : double.Parse("0")) + (txtNetAmt2.Text != "" ? double.Parse(txtNetAmt2.Text) : double.Parse("0")) + (txtNetAmt3.Text != "" ? double.Parse(txtNetAmt3.Text) : double.Parse("0")) + (txtNetAmt4.Text != "" ? double.Parse(txtNetAmt4.Text) : double.Parse("0")) + (txtNetAmt5.Text != "" ? double.Parse(txtNetAmt5.Text) : double.Parse("0")) + (txtNetAmt6.Text != "" ? double.Parse(txtNetAmt6.Text) : double.Parse("0")) + (txtNetAmt7.Text != "" ? double.Parse(txtNetAmt7.Text) : double.Parse("0")));
                txtVat.Text = Convert.ToString((txtVat1.Text != "" ? double.Parse(txtVat1.Text) : double.Parse("0")) + (txtVat2.Text != "" ? double.Parse(txtVat2.Text) : double.Parse("0")) + (txtVat3.Text != "" ? double.Parse(txtVat3.Text) : double.Parse("0")) + (txtVat4.Text != "" ? double.Parse(txtVat4.Text) : double.Parse("0")) + (txtVat5.Text != "" ? double.Parse(txtVat5.Text) : double.Parse("0")) + (txtVat6.Text != "" ? double.Parse(txtVat6.Text) : double.Parse("0")) + (txtVat7.Text != "" ? double.Parse(txtVat7.Text) : double.Parse("0")));
                txtAmtDV.Text = Convert.ToString((txtAmount1.Text != "" ? double.Parse(txtAmount1.Text) : double.Parse("0")) + (txtAmount2.Text != "" ? double.Parse(txtAmount2.Text) : double.Parse("0")) + (txtAmount3.Text != "" ? double.Parse(txtAmount3.Text) : double.Parse("0")) + (txtAmount4.Text != "" ? double.Parse(txtAmount4.Text) : double.Parse("0")) + (txtAmount5.Text != "" ? double.Parse(txtAmount5.Text) : double.Parse("0")) + (txtAmount6.Text != "" ? double.Parse(txtAmount6.Text) : double.Parse("0")) + (txtAmount7.Text != "" ? double.Parse(txtAmount7.Text) : double.Parse("0")));
            }
        }
        protected void txtAmount5_TextChanged(object sender, EventArgs e)
        {

        }
        protected void txtQty5_TextChanged(object sender, EventArgs e)
        {
            if (txtVat5.Text != "0")
            {
                string amt = Convert.ToString(Convert.ToDouble(hdnAmount5.Value) * Convert.ToInt32(txtQty5.Text));
                txtVat5.Text = Convert.ToString(((amt != "" ? double.Parse(amt) : double.Parse("0")) * double.Parse(hdnVat.Value)) / 100);
                txtNetAmt5.Text = Convert.ToString(double.Parse(amt) + double.Parse(txtVat5.Text));
            }
            else
            {
                txtNetAmt5.Text = Convert.ToString(Convert.ToDouble(hdnAmount5.Value) * Convert.ToInt32(txtQty5.Text));
            }
            txtAmount5.Text = Convert.ToString(Convert.ToDouble(hdnAmount5.Value) * Convert.ToInt32(txtQty5.Text));
            if (txtDisPer5.Text == "")
            {
                txtDisPer5.Text = "0";
            }
            txtDisPer5_TextChanged(null, null);
            txtPrice.Text = Convert.ToString((txtNetAmt1.Text != "" ? double.Parse(txtNetAmt1.Text) : double.Parse("0")) + (txtNetAmt2.Text != "" ? double.Parse(txtNetAmt2.Text) : double.Parse("0")) + (txtNetAmt3.Text != "" ? double.Parse(txtNetAmt3.Text) : double.Parse("0")) + (txtNetAmt4.Text != "" ? double.Parse(txtNetAmt4.Text) : double.Parse("0")) + (txtNetAmt5.Text != "" ? double.Parse(txtNetAmt5.Text) : double.Parse("0")) + (txtNetAmt6.Text != "" ? double.Parse(txtNetAmt6.Text) : double.Parse("0")) + (txtNetAmt7.Text != "" ? double.Parse(txtNetAmt7.Text) : double.Parse("0")));
            txtVat.Text = Convert.ToString((txtVat1.Text != "" ? double.Parse(txtVat1.Text) : double.Parse("0")) + (txtVat2.Text != "" ? double.Parse(txtVat2.Text) : double.Parse("0")) + (txtVat3.Text != "" ? double.Parse(txtVat3.Text) : double.Parse("0")) + (txtVat4.Text != "" ? double.Parse(txtVat4.Text) : double.Parse("0")) + (txtVat5.Text != "" ? double.Parse(txtVat5.Text) : double.Parse("0")) + (txtVat6.Text != "" ? double.Parse(txtVat6.Text) : double.Parse("0")) + (txtVat7.Text != "" ? double.Parse(txtVat7.Text) : double.Parse("0")));
            txtAmtDV.Text = Convert.ToString((txtAmount1.Text != "" ? double.Parse(txtAmount1.Text) : double.Parse("0")) + (txtAmount2.Text != "" ? double.Parse(txtAmount2.Text) : double.Parse("0")) + (txtAmount3.Text != "" ? double.Parse(txtAmount3.Text) : double.Parse("0")) + (txtAmount4.Text != "" ? double.Parse(txtAmount4.Text) : double.Parse("0")) + (txtAmount5.Text != "" ? double.Parse(txtAmount5.Text) : double.Parse("0")) + (txtAmount6.Text != "" ? double.Parse(txtAmount6.Text) : double.Parse("0")) + (txtAmount7.Text != "" ? double.Parse(txtAmount7.Text) : double.Parse("0")));
        }
        protected void txtDisPer5_TextChanged(object sender, EventArgs e)
        {
            txtAmount5.Text = Convert.ToString(((Convert.ToDouble(hdnAmount5.Value) * Convert.ToInt32(txtQty5.Text)) - ((Convert.ToDouble(hdnAmount5.Value) * Convert.ToInt32(txtQty5.Text)) * (Convert.ToDouble(txtDisPer5.Text) / 100))));
            txtDisAmt5.Text = Convert.ToString((Convert.ToDouble(hdnAmount5.Value) * Convert.ToInt32(txtQty5.Text)) * (Convert.ToDouble(txtDisPer5.Text) / 100));
            if (txtVat5.Text != "0")
            {
                string amt = Convert.ToString(Convert.ToDouble(txtAmount5.Text));
                txtVat5.Text = Convert.ToString((Convert.ToDouble(amt) * double.Parse(hdnVat.Value)) / 100);
                txtNetAmt5.Text = Convert.ToString(Convert.ToDouble(amt) + Convert.ToDouble(txtVat5.Text));
            }
            else
            {
                txtNetAmt5.Text = Convert.ToString(Convert.ToDouble(txtAmount5.Text));
            }
            txtPrice.Text = Convert.ToString((txtNetAmt1.Text != "" ? double.Parse(txtNetAmt1.Text) : double.Parse("0")) + (txtNetAmt2.Text != "" ? double.Parse(txtNetAmt2.Text) : double.Parse("0")) + (txtNetAmt3.Text != "" ? double.Parse(txtNetAmt3.Text) : double.Parse("0")) + (txtNetAmt4.Text != "" ? double.Parse(txtNetAmt4.Text) : double.Parse("0")) + (txtNetAmt5.Text != "" ? double.Parse(txtNetAmt5.Text) : double.Parse("0")) + (txtNetAmt6.Text != "" ? double.Parse(txtNetAmt6.Text) : double.Parse("0")) + (txtNetAmt7.Text != "" ? double.Parse(txtNetAmt7.Text) : double.Parse("0")));
            txtVat.Text = Convert.ToString((txtVat1.Text != "" ? double.Parse(txtVat1.Text) : double.Parse("0")) + (txtVat2.Text != "" ? double.Parse(txtVat2.Text) : double.Parse("0")) + (txtVat3.Text != "" ? double.Parse(txtVat3.Text) : double.Parse("0")) + (txtVat4.Text != "" ? double.Parse(txtVat4.Text) : double.Parse("0")) + (txtVat5.Text != "" ? double.Parse(txtVat5.Text) : double.Parse("0")) + (txtVat6.Text != "" ? double.Parse(txtVat6.Text) : double.Parse("0")) + (txtVat7.Text != "" ? double.Parse(txtVat7.Text) : double.Parse("0")));
            txtAmtDV.Text = Convert.ToString((txtAmount1.Text != "" ? double.Parse(txtAmount1.Text) : double.Parse("0")) + (txtAmount2.Text != "" ? double.Parse(txtAmount2.Text) : double.Parse("0")) + (txtAmount3.Text != "" ? double.Parse(txtAmount3.Text) : double.Parse("0")) + (txtAmount4.Text != "" ? double.Parse(txtAmount4.Text) : double.Parse("0")) + (txtAmount5.Text != "" ? double.Parse(txtAmount5.Text) : double.Parse("0")) + (txtAmount6.Text != "" ? double.Parse(txtAmount6.Text) : double.Parse("0")) + (txtAmount7.Text != "" ? double.Parse(txtAmount7.Text) : double.Parse("0")));
        }
        protected void txtDisAmt5_TextChanged(object sender, EventArgs e)
        {
            txtAmount5.Text = Convert.ToString((Convert.ToDouble(hdnAmount5.Value) * Convert.ToInt32(txtQty5.Text)) - (Convert.ToDouble(txtDisAmt5.Text)));
            txtDisPer5.Text = Convert.ToString((Convert.ToDouble(txtDisAmt5.Text) / (Convert.ToDouble(hdnAmount5.Value) * Convert.ToInt32(txtQty5.Text))) * 100);
            if (txtVat5.Text != "0")
            {
                string amt = Convert.ToString(Convert.ToDouble(txtAmount5.Text));
                txtVat5.Text = Convert.ToString((Convert.ToDouble(amt) * double.Parse(hdnVat.Value)) / 100);
                txtNetAmt5.Text = Convert.ToString(Convert.ToDouble(amt) + Convert.ToDouble(txtVat5.Text));
            }
            else
            {
                txtNetAmt5.Text = Convert.ToString(Convert.ToDouble(txtAmount5.Text));
            }
            txtPrice.Text = Convert.ToString((txtNetAmt1.Text != "" ? double.Parse(txtNetAmt1.Text) : double.Parse("0")) + (txtNetAmt2.Text != "" ? double.Parse(txtNetAmt2.Text) : double.Parse("0")) + (txtNetAmt3.Text != "" ? double.Parse(txtNetAmt3.Text) : double.Parse("0")) + (txtNetAmt4.Text != "" ? double.Parse(txtNetAmt4.Text) : double.Parse("0")) + (txtNetAmt5.Text != "" ? double.Parse(txtNetAmt5.Text) : double.Parse("0")) + (txtNetAmt6.Text != "" ? double.Parse(txtNetAmt6.Text) : double.Parse("0")) + (txtNetAmt7.Text != "" ? double.Parse(txtNetAmt7.Text) : double.Parse("0")));
            txtVat.Text = Convert.ToString((txtVat1.Text != "" ? double.Parse(txtVat1.Text) : double.Parse("0")) + (txtVat2.Text != "" ? double.Parse(txtVat2.Text) : double.Parse("0")) + (txtVat3.Text != "" ? double.Parse(txtVat3.Text) : double.Parse("0")) + (txtVat4.Text != "" ? double.Parse(txtVat4.Text) : double.Parse("0")) + (txtVat5.Text != "" ? double.Parse(txtVat5.Text) : double.Parse("0")) + (txtVat6.Text != "" ? double.Parse(txtVat6.Text) : double.Parse("0")) + (txtVat7.Text != "" ? double.Parse(txtVat7.Text) : double.Parse("0")));
            txtAmtDV.Text = Convert.ToString((txtAmount1.Text != "" ? double.Parse(txtAmount1.Text) : double.Parse("0")) + (txtAmount2.Text != "" ? double.Parse(txtAmount2.Text) : double.Parse("0")) + (txtAmount3.Text != "" ? double.Parse(txtAmount3.Text) : double.Parse("0")) + (txtAmount4.Text != "" ? double.Parse(txtAmount4.Text) : double.Parse("0")) + (txtAmount5.Text != "" ? double.Parse(txtAmount5.Text) : double.Parse("0")) + (txtAmount6.Text != "" ? double.Parse(txtAmount6.Text) : double.Parse("0")) + (txtAmount7.Text != "" ? double.Parse(txtAmount7.Text) : double.Parse("0")));
        }

        protected void txtCode6_TextChanged(object sender, EventArgs e)
        {
            DataTableReader dr = getServices(1, txtCode6.Text);
            if (dr.Read())
            {
                txtEnName6.Text = Convert.ToString(dr["Name"]);
                txtArName6.Text = Convert.ToString(dr["ArName"]);
                txtAmount6.Text = Convert.ToString(dr["Price"]);
                hdnAmount6.Value = Convert.ToString(dr["Price"]);

                txtQty6.Text = "1";
                if (hdnlblNationality.Text != "3" && Convert.ToInt32(dr["VatApplyed"]) != 0)
                {
                    string amt = txtAmount6.Text;
                    txtVat6.Text = Convert.ToString(((amt != "" ? double.Parse(amt) : double.Parse("0")) * double.Parse(hdnVat.Value)) / 100);
                    txtNetAmt6.Text = Convert.ToString(double.Parse(amt) + double.Parse(txtVat6.Text));
                }
                else
                {
                    txtVat6.Text = "0";
                    txtNetAmt6.Text = txtAmount6.Text;
                }
                if (txtQty6.Text == "")
                {
                    txtQty6.Text = "1";
                }
                if (txtDisPer6.Text == "")
                {
                    txtDisPer6.Text = "0";
                }
                txtQty6_TextChanged(null, null);
                txtDisPer6_TextChanged(null, null);
                txtPrice.Text = Convert.ToString((txtNetAmt1.Text != "" ? double.Parse(txtNetAmt1.Text) : double.Parse("0")) + (txtNetAmt2.Text != "" ? double.Parse(txtNetAmt2.Text) : double.Parse("0")) + (txtNetAmt3.Text != "" ? double.Parse(txtNetAmt3.Text) : double.Parse("0")) + (txtNetAmt4.Text != "" ? double.Parse(txtNetAmt4.Text) : double.Parse("0")) + (txtNetAmt5.Text != "" ? double.Parse(txtNetAmt5.Text) : double.Parse("0")) + (txtNetAmt6.Text != "" ? double.Parse(txtNetAmt6.Text) : double.Parse("0")) + (txtNetAmt7.Text != "" ? double.Parse(txtNetAmt7.Text) : double.Parse("0")));
                txtVat.Text = Convert.ToString((txtVat1.Text != "" ? double.Parse(txtVat1.Text) : double.Parse("0")) + (txtVat2.Text != "" ? double.Parse(txtVat2.Text) : double.Parse("0")) + (txtVat3.Text != "" ? double.Parse(txtVat3.Text) : double.Parse("0")) + (txtVat4.Text != "" ? double.Parse(txtVat4.Text) : double.Parse("0")) + (txtVat5.Text != "" ? double.Parse(txtVat5.Text) : double.Parse("0")) + (txtVat6.Text != "" ? double.Parse(txtVat6.Text) : double.Parse("0")) + (txtVat7.Text != "" ? double.Parse(txtVat7.Text) : double.Parse("0")));
                txtAmtDV.Text = Convert.ToString((txtAmount1.Text != "" ? double.Parse(txtAmount1.Text) : double.Parse("0")) + (txtAmount2.Text != "" ? double.Parse(txtAmount2.Text) : double.Parse("0")) + (txtAmount3.Text != "" ? double.Parse(txtAmount3.Text) : double.Parse("0")) + (txtAmount4.Text != "" ? double.Parse(txtAmount4.Text) : double.Parse("0")) + (txtAmount5.Text != "" ? double.Parse(txtAmount5.Text) : double.Parse("0")) + (txtAmount6.Text != "" ? double.Parse(txtAmount6.Text) : double.Parse("0")) + (txtAmount7.Text != "" ? double.Parse(txtAmount7.Text) : double.Parse("0")));
            }
        }
        protected void txtAmount6_TextChanged(object sender, EventArgs e)
        {

        }
        protected void txtQty6_TextChanged(object sender, EventArgs e)
        {
            if (txtVat1.Text != "0")
            {
                string amt = Convert.ToString(Convert.ToDouble(hdnAmount6.Value) * Convert.ToInt32(txtQty6.Text));
                txtVat6.Text = Convert.ToString(((amt != "" ? double.Parse(amt) : double.Parse("0")) * double.Parse(hdnVat.Value)) / 100);
                txtNetAmt6.Text = Convert.ToString(double.Parse(amt) + double.Parse(txtVat6.Text));
            }
            else
            {
                txtNetAmt6.Text = Convert.ToString(Convert.ToDouble(hdnAmount6.Value) * Convert.ToInt32(txtQty6.Text));
            }
            txtAmount6.Text = Convert.ToString(Convert.ToDouble(hdnAmount6.Value) * Convert.ToInt32(txtQty6.Text));
            if (txtDisPer6.Text == "")
            {
                txtDisPer6.Text = "0";
            }
            txtDisPer6_TextChanged(null, null);
            txtPrice.Text = Convert.ToString((txtNetAmt1.Text != "" ? double.Parse(txtNetAmt1.Text) : double.Parse("0")) + (txtNetAmt2.Text != "" ? double.Parse(txtNetAmt2.Text) : double.Parse("0")) + (txtNetAmt3.Text != "" ? double.Parse(txtNetAmt3.Text) : double.Parse("0")) + (txtNetAmt4.Text != "" ? double.Parse(txtNetAmt4.Text) : double.Parse("0")) + (txtNetAmt5.Text != "" ? double.Parse(txtNetAmt5.Text) : double.Parse("0")) + (txtNetAmt6.Text != "" ? double.Parse(txtNetAmt6.Text) : double.Parse("0")) + (txtNetAmt7.Text != "" ? double.Parse(txtNetAmt7.Text) : double.Parse("0")));
            txtVat.Text = Convert.ToString((txtVat1.Text != "" ? double.Parse(txtVat1.Text) : double.Parse("0")) + (txtVat2.Text != "" ? double.Parse(txtVat2.Text) : double.Parse("0")) + (txtVat3.Text != "" ? double.Parse(txtVat3.Text) : double.Parse("0")) + (txtVat4.Text != "" ? double.Parse(txtVat4.Text) : double.Parse("0")) + (txtVat5.Text != "" ? double.Parse(txtVat5.Text) : double.Parse("0")) + (txtVat6.Text != "" ? double.Parse(txtVat6.Text) : double.Parse("0")) + (txtVat7.Text != "" ? double.Parse(txtVat7.Text) : double.Parse("0")));
            txtAmtDV.Text = Convert.ToString((txtAmount1.Text != "" ? double.Parse(txtAmount1.Text) : double.Parse("0")) + (txtAmount2.Text != "" ? double.Parse(txtAmount2.Text) : double.Parse("0")) + (txtAmount3.Text != "" ? double.Parse(txtAmount3.Text) : double.Parse("0")) + (txtAmount4.Text != "" ? double.Parse(txtAmount4.Text) : double.Parse("0")) + (txtAmount5.Text != "" ? double.Parse(txtAmount5.Text) : double.Parse("0")) + (txtAmount6.Text != "" ? double.Parse(txtAmount6.Text) : double.Parse("0")) + (txtAmount7.Text != "" ? double.Parse(txtAmount7.Text) : double.Parse("0")));
        }
        protected void txtDisPer6_TextChanged(object sender, EventArgs e)
        {
            txtAmount6.Text = Convert.ToString(((Convert.ToDouble(hdnAmount6.Value) * Convert.ToInt32(txtQty6.Text)) - ((Convert.ToDouble(hdnAmount6.Value) * Convert.ToInt32(txtQty6.Text)) * (Convert.ToDouble(txtDisPer6.Text) / 100))));
            txtDisAmt6.Text = Convert.ToString((Convert.ToDouble(hdnAmount6.Value) * Convert.ToInt32(txtQty6.Text)) * (Convert.ToDouble(txtDisPer6.Text) / 100));
            if (txtVat6.Text != "0")
            {
                string amt = Convert.ToString(Convert.ToDouble(txtAmount6.Text));
                txtVat6.Text = Convert.ToString((Convert.ToDouble(amt) * double.Parse(hdnVat.Value)) / 100);
                txtNetAmt6.Text = Convert.ToString(Convert.ToDouble(amt) + Convert.ToDouble(txtVat6.Text));
            }
            else
            {
                txtNetAmt6.Text = Convert.ToString(Convert.ToDouble(txtAmount6.Text));
            }
            txtPrice.Text = Convert.ToString((txtNetAmt1.Text != "" ? double.Parse(txtNetAmt1.Text) : double.Parse("0")) + (txtNetAmt2.Text != "" ? double.Parse(txtNetAmt2.Text) : double.Parse("0")) + (txtNetAmt3.Text != "" ? double.Parse(txtNetAmt3.Text) : double.Parse("0")) + (txtNetAmt4.Text != "" ? double.Parse(txtNetAmt4.Text) : double.Parse("0")) + (txtNetAmt5.Text != "" ? double.Parse(txtNetAmt5.Text) : double.Parse("0")) + (txtNetAmt6.Text != "" ? double.Parse(txtNetAmt6.Text) : double.Parse("0")) + (txtNetAmt7.Text != "" ? double.Parse(txtNetAmt7.Text) : double.Parse("0")));
            txtVat.Text = Convert.ToString((txtVat1.Text != "" ? double.Parse(txtVat1.Text) : double.Parse("0")) + (txtVat2.Text != "" ? double.Parse(txtVat2.Text) : double.Parse("0")) + (txtVat3.Text != "" ? double.Parse(txtVat3.Text) : double.Parse("0")) + (txtVat4.Text != "" ? double.Parse(txtVat4.Text) : double.Parse("0")) + (txtVat5.Text != "" ? double.Parse(txtVat5.Text) : double.Parse("0")) + (txtVat6.Text != "" ? double.Parse(txtVat6.Text) : double.Parse("0")) + (txtVat7.Text != "" ? double.Parse(txtVat7.Text) : double.Parse("0")));
            txtAmtDV.Text = Convert.ToString((txtAmount1.Text != "" ? double.Parse(txtAmount1.Text) : double.Parse("0")) + (txtAmount2.Text != "" ? double.Parse(txtAmount2.Text) : double.Parse("0")) + (txtAmount3.Text != "" ? double.Parse(txtAmount3.Text) : double.Parse("0")) + (txtAmount4.Text != "" ? double.Parse(txtAmount4.Text) : double.Parse("0")) + (txtAmount5.Text != "" ? double.Parse(txtAmount5.Text) : double.Parse("0")) + (txtAmount6.Text != "" ? double.Parse(txtAmount6.Text) : double.Parse("0")) + (txtAmount7.Text != "" ? double.Parse(txtAmount7.Text) : double.Parse("0")));
        }
        protected void txtDisAmt6_TextChanged(object sender, EventArgs e)
        {
            txtAmount6.Text = Convert.ToString((Convert.ToDouble(hdnAmount6.Value) * Convert.ToInt32(txtQty6.Text)) - (Convert.ToDouble(txtDisAmt6.Text)));
            txtDisPer6.Text = Convert.ToString((Convert.ToDouble(txtDisAmt6.Text) / (Convert.ToDouble(hdnAmount6.Value) * Convert.ToInt32(txtQty6.Text))) * 100);
            if (txtVat6.Text != "0")
            {
                string amt = Convert.ToString(Convert.ToDouble(txtAmount1.Text));
                txtVat6.Text = Convert.ToString((Convert.ToDouble(amt) * double.Parse(hdnVat.Value)) / 100);
                txtNetAmt6.Text = Convert.ToString(Convert.ToDouble(amt) + Convert.ToDouble(txtVat6.Text));
            }
            else
            {
                txtNetAmt6.Text = Convert.ToString(Convert.ToDouble(txtAmount6.Text));
            }
            txtPrice.Text = Convert.ToString((txtNetAmt1.Text != "" ? double.Parse(txtNetAmt1.Text) : double.Parse("0")) + (txtNetAmt2.Text != "" ? double.Parse(txtNetAmt2.Text) : double.Parse("0")) + (txtNetAmt3.Text != "" ? double.Parse(txtNetAmt3.Text) : double.Parse("0")) + (txtNetAmt4.Text != "" ? double.Parse(txtNetAmt4.Text) : double.Parse("0")) + (txtNetAmt5.Text != "" ? double.Parse(txtNetAmt5.Text) : double.Parse("0")) + (txtNetAmt6.Text != "" ? double.Parse(txtNetAmt6.Text) : double.Parse("0")) + (txtNetAmt7.Text != "" ? double.Parse(txtNetAmt7.Text) : double.Parse("0")));
            txtVat.Text = Convert.ToString((txtVat1.Text != "" ? double.Parse(txtVat1.Text) : double.Parse("0")) + (txtVat2.Text != "" ? double.Parse(txtVat2.Text) : double.Parse("0")) + (txtVat3.Text != "" ? double.Parse(txtVat3.Text) : double.Parse("0")) + (txtVat4.Text != "" ? double.Parse(txtVat4.Text) : double.Parse("0")) + (txtVat5.Text != "" ? double.Parse(txtVat5.Text) : double.Parse("0")) + (txtVat6.Text != "" ? double.Parse(txtVat6.Text) : double.Parse("0")) + (txtVat7.Text != "" ? double.Parse(txtVat7.Text) : double.Parse("0")));
            txtAmtDV.Text = Convert.ToString((txtAmount1.Text != "" ? double.Parse(txtAmount1.Text) : double.Parse("0")) + (txtAmount2.Text != "" ? double.Parse(txtAmount2.Text) : double.Parse("0")) + (txtAmount3.Text != "" ? double.Parse(txtAmount3.Text) : double.Parse("0")) + (txtAmount4.Text != "" ? double.Parse(txtAmount4.Text) : double.Parse("0")) + (txtAmount5.Text != "" ? double.Parse(txtAmount5.Text) : double.Parse("0")) + (txtAmount6.Text != "" ? double.Parse(txtAmount6.Text) : double.Parse("0")) + (txtAmount7.Text != "" ? double.Parse(txtAmount7.Text) : double.Parse("0")));
        }

        protected void txtCode7_TextChanged(object sender, EventArgs e)
        {
            DataTableReader dr = getServices(1, txtCode7.Text);
            if (dr.Read())
            {
                txtEnName7.Text = Convert.ToString(dr["Name"]);
                txtArName7.Text = Convert.ToString(dr["ArName"]);
                txtAmount7.Text = Convert.ToString(dr["Price"]);
                hdnAmount7.Value = Convert.ToString(dr["Price"]);

                txtQty7.Text = "1";
                if (hdnlblNationality.Text != "3" && Convert.ToInt32(dr["VatApplyed"]) != 0)
                {
                    string amt = txtAmount7.Text;
                    txtVat7.Text = Convert.ToString(((amt != "" ? double.Parse(amt) : double.Parse("0")) * double.Parse(hdnVat.Value)) / 100);
                    txtNetAmt7.Text = Convert.ToString(double.Parse(amt) + double.Parse(txtVat7.Text));
                }
                else
                {
                    txtVat7.Text = "0";
                    txtNetAmt7.Text = txtAmount7.Text;
                }
                if (txtQty7.Text == "")
                {
                    txtQty7.Text = "1";
                }
                if (txtDisPer7.Text == "")
                {
                    txtDisPer7.Text = "0";
                }
                txtQty7_TextChanged(null, null);
                txtDisPer7_TextChanged(null, null);
                txtPrice.Text = Convert.ToString((txtNetAmt1.Text != "" ? double.Parse(txtNetAmt1.Text) : double.Parse("0")) + (txtNetAmt2.Text != "" ? double.Parse(txtNetAmt2.Text) : double.Parse("0")) + (txtNetAmt3.Text != "" ? double.Parse(txtNetAmt3.Text) : double.Parse("0")) + (txtNetAmt4.Text != "" ? double.Parse(txtNetAmt4.Text) : double.Parse("0")) + (txtNetAmt5.Text != "" ? double.Parse(txtNetAmt5.Text) : double.Parse("0")) + (txtNetAmt6.Text != "" ? double.Parse(txtNetAmt6.Text) : double.Parse("0")) + (txtNetAmt7.Text != "" ? double.Parse(txtNetAmt7.Text) : double.Parse("0")));
                txtVat.Text = Convert.ToString((txtVat1.Text != "" ? double.Parse(txtVat1.Text) : double.Parse("0")) + (txtVat2.Text != "" ? double.Parse(txtVat2.Text) : double.Parse("0")) + (txtVat3.Text != "" ? double.Parse(txtVat3.Text) : double.Parse("0")) + (txtVat4.Text != "" ? double.Parse(txtVat4.Text) : double.Parse("0")) + (txtVat5.Text != "" ? double.Parse(txtVat5.Text) : double.Parse("0")) + (txtVat6.Text != "" ? double.Parse(txtVat6.Text) : double.Parse("0")) + (txtVat7.Text != "" ? double.Parse(txtVat7.Text) : double.Parse("0")));
                txtAmtDV.Text = Convert.ToString((txtAmount1.Text != "" ? double.Parse(txtAmount1.Text) : double.Parse("0")) + (txtAmount2.Text != "" ? double.Parse(txtAmount2.Text) : double.Parse("0")) + (txtAmount3.Text != "" ? double.Parse(txtAmount3.Text) : double.Parse("0")) + (txtAmount4.Text != "" ? double.Parse(txtAmount4.Text) : double.Parse("0")) + (txtAmount5.Text != "" ? double.Parse(txtAmount5.Text) : double.Parse("0")) + (txtAmount6.Text != "" ? double.Parse(txtAmount6.Text) : double.Parse("0")) + (txtAmount7.Text != "" ? double.Parse(txtAmount7.Text) : double.Parse("0")));
            }
        }
        protected void txtAmount7_TextChanged(object sender, EventArgs e)
        {

        }
        protected void txtQty7_TextChanged(object sender, EventArgs e)
        {
            if (txtVat7.Text != "0")
            {
                string amt = Convert.ToString(Convert.ToDouble(hdnAmount7.Value) * Convert.ToInt32(txtQty7.Text));
                txtVat7.Text = Convert.ToString(((amt != "" ? double.Parse(amt) : double.Parse("0")) * double.Parse(hdnVat.Value)) / 100);
                txtNetAmt7.Text = Convert.ToString(double.Parse(amt) + double.Parse(txtVat7.Text));
            }
            else
            {
                txtNetAmt7.Text = Convert.ToString(Convert.ToDouble(hdnAmount7.Value) * Convert.ToInt32(txtQty7.Text));
            }
            txtAmount7.Text = Convert.ToString(Convert.ToDouble(hdnAmount7.Value) * Convert.ToInt32(txtQty7.Text));
            if (txtDisPer7.Text == "")
            {
                txtDisPer7.Text = "0";
            }
            txtDisPer7_TextChanged(null, null);
            txtPrice.Text = Convert.ToString((txtNetAmt1.Text != "" ? double.Parse(txtNetAmt1.Text) : double.Parse("0")) + (txtNetAmt2.Text != "" ? double.Parse(txtNetAmt2.Text) : double.Parse("0")) + (txtNetAmt3.Text != "" ? double.Parse(txtNetAmt3.Text) : double.Parse("0")) + (txtNetAmt4.Text != "" ? double.Parse(txtNetAmt4.Text) : double.Parse("0")) + (txtNetAmt5.Text != "" ? double.Parse(txtNetAmt5.Text) : double.Parse("0")) + (txtNetAmt6.Text != "" ? double.Parse(txtNetAmt6.Text) : double.Parse("0")) + (txtNetAmt7.Text != "" ? double.Parse(txtNetAmt7.Text) : double.Parse("0")));
            txtVat.Text = Convert.ToString((txtVat1.Text != "" ? double.Parse(txtVat1.Text) : double.Parse("0")) + (txtVat2.Text != "" ? double.Parse(txtVat2.Text) : double.Parse("0")) + (txtVat3.Text != "" ? double.Parse(txtVat3.Text) : double.Parse("0")) + (txtVat4.Text != "" ? double.Parse(txtVat4.Text) : double.Parse("0")) + (txtVat5.Text != "" ? double.Parse(txtVat5.Text) : double.Parse("0")) + (txtVat6.Text != "" ? double.Parse(txtVat6.Text) : double.Parse("0")) + (txtVat7.Text != "" ? double.Parse(txtVat7.Text) : double.Parse("0")));
            txtAmtDV.Text = Convert.ToString((txtAmount1.Text != "" ? double.Parse(txtAmount1.Text) : double.Parse("0")) + (txtAmount2.Text != "" ? double.Parse(txtAmount2.Text) : double.Parse("0")) + (txtAmount3.Text != "" ? double.Parse(txtAmount3.Text) : double.Parse("0")) + (txtAmount4.Text != "" ? double.Parse(txtAmount4.Text) : double.Parse("0")) + (txtAmount5.Text != "" ? double.Parse(txtAmount5.Text) : double.Parse("0")) + (txtAmount6.Text != "" ? double.Parse(txtAmount6.Text) : double.Parse("0")) + (txtAmount7.Text != "" ? double.Parse(txtAmount7.Text) : double.Parse("0")));
        }
        protected void txtDisPer7_TextChanged(object sender, EventArgs e)
        {
            txtAmount7.Text = Convert.ToString(((Convert.ToDouble(hdnAmount7.Value) * Convert.ToInt32(txtQty7.Text)) - ((Convert.ToDouble(hdnAmount7.Value) * Convert.ToInt32(txtQty7.Text)) * (Convert.ToDouble(txtDisPer7.Text) / 100))));
            txtDisAmt7.Text = Convert.ToString((Convert.ToDouble(hdnAmount7.Value) * Convert.ToInt32(txtQty7.Text)) * (Convert.ToDouble(txtDisPer7.Text) / 100));
            if (txtVat7.Text != "0")
            {
                string amt = Convert.ToString(Convert.ToDouble(txtAmount7.Text));
                txtVat7.Text = Convert.ToString((Convert.ToDouble(amt) * double.Parse(hdnVat.Value)) / 100);
                txtNetAmt7.Text = Convert.ToString(Convert.ToDouble(amt) + Convert.ToDouble(txtVat7.Text));
            }
            else
            {
                txtNetAmt7.Text = Convert.ToString(Convert.ToDouble(txtAmount7.Text));
            }
            txtPrice.Text = Convert.ToString((txtNetAmt1.Text != "" ? double.Parse(txtNetAmt1.Text) : double.Parse("0")) + (txtNetAmt2.Text != "" ? double.Parse(txtNetAmt2.Text) : double.Parse("0")) + (txtNetAmt3.Text != "" ? double.Parse(txtNetAmt3.Text) : double.Parse("0")) + (txtNetAmt4.Text != "" ? double.Parse(txtNetAmt4.Text) : double.Parse("0")) + (txtNetAmt5.Text != "" ? double.Parse(txtNetAmt5.Text) : double.Parse("0")) + (txtNetAmt6.Text != "" ? double.Parse(txtNetAmt6.Text) : double.Parse("0")) + (txtNetAmt7.Text != "" ? double.Parse(txtNetAmt7.Text) : double.Parse("0")));
            txtVat.Text = Convert.ToString((txtVat1.Text != "" ? double.Parse(txtVat1.Text) : double.Parse("0")) + (txtVat2.Text != "" ? double.Parse(txtVat2.Text) : double.Parse("0")) + (txtVat3.Text != "" ? double.Parse(txtVat3.Text) : double.Parse("0")) + (txtVat4.Text != "" ? double.Parse(txtVat4.Text) : double.Parse("0")) + (txtVat5.Text != "" ? double.Parse(txtVat5.Text) : double.Parse("0")) + (txtVat6.Text != "" ? double.Parse(txtVat6.Text) : double.Parse("0")) + (txtVat7.Text != "" ? double.Parse(txtVat7.Text) : double.Parse("0")));
            txtAmtDV.Text = Convert.ToString((txtAmount1.Text != "" ? double.Parse(txtAmount1.Text) : double.Parse("0")) + (txtAmount2.Text != "" ? double.Parse(txtAmount2.Text) : double.Parse("0")) + (txtAmount3.Text != "" ? double.Parse(txtAmount3.Text) : double.Parse("0")) + (txtAmount4.Text != "" ? double.Parse(txtAmount4.Text) : double.Parse("0")) + (txtAmount5.Text != "" ? double.Parse(txtAmount5.Text) : double.Parse("0")) + (txtAmount6.Text != "" ? double.Parse(txtAmount6.Text) : double.Parse("0")) + (txtAmount7.Text != "" ? double.Parse(txtAmount7.Text) : double.Parse("0")));
        }
        protected void txtDisAmt7_TextChanged(object sender, EventArgs e)
        {
            txtAmount7.Text = Convert.ToString((Convert.ToDouble(hdnAmount7.Value) * Convert.ToInt32(txtQty7.Text)) - (Convert.ToDouble(txtDisAmt7.Text)));
            txtDisPer7.Text = Convert.ToString((Convert.ToDouble(txtDisAmt7.Text) / (Convert.ToDouble(hdnAmount7.Value) * Convert.ToInt32(txtQty7.Text))) * 100);
            if (txtVat7.Text != "0")
            {
                string amt = Convert.ToString(Convert.ToDouble(txtAmount7.Text));
                txtVat7.Text = Convert.ToString((Convert.ToDouble(amt) * double.Parse(hdnVat.Value)) / 100);
                txtNetAmt7.Text = Convert.ToString(Convert.ToDouble(amt) + Convert.ToDouble(txtVat7.Text));
            }
            else
            {
                txtNetAmt7.Text = Convert.ToString(Convert.ToDouble(txtAmount7.Text));
            }
            txtPrice.Text = Convert.ToString((txtNetAmt1.Text != "" ? double.Parse(txtNetAmt1.Text) : double.Parse("0")) + (txtNetAmt2.Text != "" ? double.Parse(txtNetAmt2.Text) : double.Parse("0")) + (txtNetAmt3.Text != "" ? double.Parse(txtNetAmt3.Text) : double.Parse("0")) + (txtNetAmt4.Text != "" ? double.Parse(txtNetAmt4.Text) : double.Parse("0")) + (txtNetAmt5.Text != "" ? double.Parse(txtNetAmt5.Text) : double.Parse("0")) + (txtNetAmt6.Text != "" ? double.Parse(txtNetAmt6.Text) : double.Parse("0")) + (txtNetAmt7.Text != "" ? double.Parse(txtNetAmt7.Text) : double.Parse("0")));
            txtVat.Text = Convert.ToString((txtVat1.Text != "" ? double.Parse(txtVat1.Text) : double.Parse("0")) + (txtVat2.Text != "" ? double.Parse(txtVat2.Text) : double.Parse("0")) + (txtVat3.Text != "" ? double.Parse(txtVat3.Text) : double.Parse("0")) + (txtVat4.Text != "" ? double.Parse(txtVat4.Text) : double.Parse("0")) + (txtVat5.Text != "" ? double.Parse(txtVat5.Text) : double.Parse("0")) + (txtVat6.Text != "" ? double.Parse(txtVat6.Text) : double.Parse("0")) + (txtVat7.Text != "" ? double.Parse(txtVat7.Text) : double.Parse("0")));
            txtAmtDV.Text = Convert.ToString((txtAmount1.Text != "" ? double.Parse(txtAmount1.Text) : double.Parse("0")) + (txtAmount2.Text != "" ? double.Parse(txtAmount2.Text) : double.Parse("0")) + (txtAmount3.Text != "" ? double.Parse(txtAmount3.Text) : double.Parse("0")) + (txtAmount4.Text != "" ? double.Parse(txtAmount4.Text) : double.Parse("0")) + (txtAmount5.Text != "" ? double.Parse(txtAmount5.Text) : double.Parse("0")) + (txtAmount6.Text != "" ? double.Parse(txtAmount6.Text) : double.Parse("0")) + (txtAmount7.Text != "" ? double.Parse(txtAmount7.Text) : double.Parse("0")));
        }



    }
}