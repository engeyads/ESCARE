using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using IronOcr;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ESCARE
{
    public partial class AddCustomer : Page
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
            upDir = Path.Combine(Request.PhysicalApplicationPath, "Uploads");
            txtRegBy.Text = getUserFullName();
            txtDOB.Attributes.Add("readonly", "readonly");
            TextBox3.Attributes.Add("readonly", "readonly");
            txtRTime.Attributes.Add("readonly", "readonly");
            txtRDate.Attributes.Add("readonly", "readonly");
            txtAge.Attributes.Add("readonly", "readonly");
            txtFileType.Attributes.Add("readonly", "readonly");

        }

        protected void flags()
        {
            ddlNationalityName.DataBind();
            //Now add class to each and every item in dropdown
            //Now, add a "SysCode" attribute to each item in the dropdown list
            string imageURL = "";
            for (int i = 0; i < ddlNationalityName.Items.Count; i++)
            {
                switch (ddlNationalityName.Items[i].Text)
                {
                    case "فلسطين":
                        imageURL = "IMG/flag-palestine.jpg";
                        break;
                    case "البحرين":
                        imageURL = "IMG/flag-bahrain.jpg";
                        break;
                    case "السعودية":
                        imageURL = "IMG/flag-saudi.jpg";
                        break;
                    case "تونس":
                        imageURL = "IMG/flag-tunisia.jpg";
                        break;
                    case "المغرب":
                        imageURL = "IMG/flag-morocco.jpg";
                        break;
                }
                ListItem item = ddlNationalityName.Items[i];
                item.Attributes["style"] = "background: url(" + imageURL + ");background-repeat:no-repeat;";
            }
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
        protected bool addNewCustomer(string filen)
        {
            string d = txtDOB.Text.ToString();
            DateTime localDate = DateTime.Now;
            DateTime DOBDate = ParseDate(d);


            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) from patient where PID = '" + txtIDNo.Text + "'", con);

            con.Open();
            int userCount = (int)cmd.ExecuteScalar();
            con.Close();
            if (userCount != 0)
            {
                lblmsg.Text = "المريض مسجل مسبقا";
                return false;
            }
            else
            {
                string regby = null;
                cmd = new SqlCommand("SELECT empID from employees where EmpID = (select EID from AspNetUsers where id='" + User.Identity.GetUserId() + "')", con);
                con.Open();
                SqlDataReader dremp = cmd.ExecuteReader();

                if (dremp.Read())
                {

                    regby = Convert.ToString(dremp["empID"]);
                    con.Close();
                    cmd = new SqlCommand("spINSERT_dbo_Patient", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PID", txtIDNo.Text);
                    cmd.Parameters.AddWithValue("@FName", txtEnFName.Text);
                    cmd.Parameters.AddWithValue("@MName", txtEnMName.Text);
                    cmd.Parameters.AddWithValue("@MMName", txtEnTName.Text);
                    cmd.Parameters.AddWithValue("@LName", txtEnLName.Text);
                    cmd.Parameters.AddWithValue("@ArFName", txtArFName.Text);
                    cmd.Parameters.AddWithValue("@ArMName", txtArMName.Text);
                    cmd.Parameters.AddWithValue("@ArMMName", txtArTName.Text);
                    cmd.Parameters.AddWithValue("@ArLName", txtArLName.Text);
                    cmd.Parameters.AddWithValue("@Gen", rblGender.SelectedValue);
                    cmd.Parameters.AddWithValue("@IDType", ddlIDType.SelectedValue);
                    cmd.Parameters.AddWithValue("@Mobile", txtMobile.Text);
                    cmd.Parameters.AddWithValue("@Nationality", ddlNationalityName.SelectedValue);
                    cmd.Parameters.AddWithValue("@Profition", txtProfition.Text);
                    cmd.Parameters.AddWithValue("@Organization", txtCompanyName.Text);
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@DOB", DOBDate);
                    cmd.Parameters.AddWithValue("@InDate", localDate);
                    cmd.Parameters.AddWithValue("@Add", ddlMar.SelectedValue);
                    cmd.Parameters.AddWithValue("@Marital", ddlStatus.SelectedValue);
                    cmd.Parameters.AddWithValue("@FCode", ddlFamilyCode.SelectedValue);
                    cmd.Parameters.AddWithValue("@Tel", txtTel.Text);
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@City", ddlCity.SelectedValue);
                    cmd.Parameters.AddWithValue("@Neighbour", ddlNeighbour.SelectedValue);
                    cmd.Parameters.AddWithValue("@Comment", txtCom.Text);
                    cmd.Parameters.AddWithValue("@PType", ddlPType.SelectedValue);
                    cmd.Parameters.AddWithValue("@Regby", regby);
                    cmd.Parameters.AddWithValue("@IDCard", filen);
                    con.Open();

                    int k = cmd.ExecuteNonQuery();
                    if (k != 0)
                    {

                        con.Close();

                        cmd = new SqlCommand("SELECT FileNo from Patient where PID = '" + txtIDNo.Text + "'", con);
                        con.Open();
                        SqlDataReader dr = cmd.ExecuteReader();

                        if (dr.Read())
                        {
                            string fileno = Convert.ToString(dr["FileNo"]);
                            string succ = "";
                            con.Close();

                            if (ddlPType.SelectedValue != "1")
                            {
                                cmd = new SqlCommand("spINSERT_dbo_PatientInsurance", con);
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@CardNo", txtInsCardNo.Text);
                                cmd.Parameters.AddWithValue("@PF", fileno);
                                cmd.Parameters.AddWithValue("@IID", ddlIns.SelectedValue);
                                cmd.Parameters.AddWithValue("@ITID", ddlInsClass.SelectedValue);
                                cmd.Parameters.AddWithValue("@Expire", txtExpIns.Text);
                                cmd.Parameters.AddWithValue("@HospitalUp", txtAppLim.Text);
                                cmd.Parameters.AddWithValue("@CardImageURL", upins);
                                cmd.Parameters.AddWithValue("@valid", 1);
                                con.Open();

                                k = cmd.ExecuteNonQuery();
                                if (k != 0)
                                {
                                    succ = "مع التأمين";
                                }
                                con.Close();
                            }

                            txtFile.Text = fileno;
                            txtFile_TextChanged(null, null);

                            lblmsg.Text = "تم ادخال البيانات بنجاح" + succ;
                            lblmsg.ForeColor = System.Drawing.Color.GreenYellow;
                            return true;
                        }
                    }
                    con.Close();
                }

                return false;

            }

        }

        private DataTable GetDataTable(string cmdText)
        {
            SqlConnection sConstring = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
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

        //protected void btnCheck_Click(object sender, EventArgs e)
        //{
        //    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        //    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) from patient where PID like '%" + txtPID.Text + "%' or Mobile like '%" + txtPMobile.Text + "%'", con);
        //    con.Open();
        //    int userCount = (int)cmd.ExecuteScalar();
        //    con.Close();
        //    if (userCount != 0)
        //    {
        //        lblmsg.Text = "Found!";
        //        lblmsg.ForeColor = System.Drawing.Color.CornflowerBlue;
        //        lblmsg.Visible = true;

        //        DataTable dt = new DataTable();
        //        dt = GetDataTable("SELECT patient.PID, (patient.FName+' '+patient.MName+' '+patient.LName) AS EnName, (patient.ArFName+' '+patient.ArMName+' '+patient.ArLName) AS ArName, CASE WHEN IDType = 1 THEN 'ID Card' ELSE 'Passport' END AS IDType, patient.Mobile, countries.Name, patient.Profition, patient.Blood, patient.Address, patient.DOB, patient.InDate FROM patient,countries where PID like '%" + txtPID.Text + "%' AND countries.ID = patient.Nationality");

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
        //    SqlConnection con = new SqlConnection(@"Data Source=ENGEYAD-PC;Initial Catalog=Hospital;Persist Security Info=True;User ID=sa;Password=Khalaf@2018");
        //    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) from patient where PID = '" + txtPID.Text + "'", con);
        //}

        protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
        {

        }

        protected void ddlNationalityName_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtNationalityID.Text = ddlNationalityName.SelectedValue;
            txtNationalityID.DataBind();
            if (ddlNationalityName.SelectedValue == "3") { ddlIDType.SelectedValue = "1"; }
            else if(ddlIDType.SelectedValue == "1") { ddlIDType.SelectedIndex = 0; }
            flags();
        }

        //protected void ddlDoc_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    txtDoc.Text = ddlDoc.SelectedValue;
        //    txtDoc.DataBind();
        //}
        protected void ddlIns_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtIns.Text = ddlIns.SelectedValue;
            txtIns.DataBind();

        }
        protected void txtIns_TextChanged(object sender, EventArgs e)
        {
            ddlIns.SelectedValue = txtIns.Text;
            ddlIns.DataBind();

        }
        protected void txtInsClass_TextChanged(object sender, EventArgs e)
        {
            ddlInsClass.SelectedValue = txtInsClass.Text;
            ddlInsClass.DataBind();

        }
        protected void ddlInsClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtInsClass.Text = ddlInsClass.SelectedValue;
            txtInsClass.DataBind();

        }
        protected void ddlPType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlPType.SelectedValue == "2" || ddlPType.SelectedValue == "3")
            {
                lblInsCardNo.Visible = true;
                txtInsCardNo.Visible = true;
                lblIns.Visible = true;
                txtIns.Visible = true;
                ddlIns.Visible = true;
                lblInsClass.Visible = true;
                txtInsClass.Visible = true;
                ddlInsClass.Visible = true;
                lblAppLim.Visible = true;
                txtAppLim.Visible = true;
                lblExpIns.Visible = true;
                txtExpIns.Visible = true;
                FileUpload2.Visible = true;
            }
            else
            {
                lblInsCardNo.Visible = false;
                txtInsCardNo.Visible = false;
                lblIns.Visible = false;
                txtIns.Visible = false;
                ddlIns.Visible = false;
                lblInsClass.Visible = false;
                txtInsClass.Visible = false;
                ddlInsClass.Visible = false;
                lblAppLim.Visible = false;
                txtAppLim.Visible = false;
                lblExpIns.Visible = false;
                txtExpIns.Visible = false;
                FileUpload2.Visible = false;
            }
            txtPType.Text = ddlPType.SelectedValue;
            txtPType.DataBind();

        }
        protected void ddlCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            InsertDataToNieghbours();
        }
        protected void InsertDataToNieghbours()
        {
            DataTable dt = GetDataTable("select ID,ArName from Neighbours where City='" + ddlCity.SelectedValue + "'");
            if (dt.IsInitialized)
            {
                ddlNeighbour.DataSource = dt;
                ddlNeighbour.DataTextField = "ArName";
                ddlNeighbour.DataValueField = "ID";
                ddlNeighbour.DataBind();
                ddlNeighbour.Items.Insert(0, new ListItem("-- اختر حي --", "0"));
            }
        }

        protected void btnProceed_Click(object sender, EventArgs e)
        {
            string ins = ddlPType.SelectedValue;
            if (ins == "1")
            {
                lblmsg.Text = "";
                lblmsg.ForeColor = System.Drawing.Color.Coral;
                if (txtIDNo.Text != "" &&
                    txtEnFName.Text != "" &&
                    txtEnLName.Text != "" &&
                    txtArFName.Text != "" &&
                    txtArLName.Text != "" &&
                    txtDOB.Text != "" &&
                    rblGender.SelectedValue != null &&
                    ddlIDType.SelectedValue != null &&
                    txtMobile.Text != "" &&
                    ddlNationalityName.SelectedValue != null &&
                    txtProfition.Text != "" &&
                    ddlStatus.SelectedValue != null &&
                    ddlCity.SelectedValue != null &&
                    ddlPType.SelectedValue != null)
                {
                    if (FileUpload1.HasFile)
                    {
                        imgUpload();
                    }
                    else
                    {
                        lblmsg.Text = "لم تقم باختيار صورة للهوية";
                    }
                }
                else
                {
                    lblmsg.Text = "لم تقم بادخال بيانات كافية لتسجيل المريض";
                }
            }
            else
            {
                lblmsg.Text = "";
                lblmsg.ForeColor = System.Drawing.Color.Coral;
                if (txtIDNo.Text != "" &&
                    txtEnFName.Text != "" &&
                    txtEnLName.Text != "" &&
                    txtArFName.Text != "" &&
                    txtArLName.Text != "" &&
                    txtDOB.Text != "" &&
                    rblGender.SelectedValue != null &&
                    ddlIDType.SelectedValue != null &&
                    txtMobile.Text != "" &&
                    ddlNationalityName.SelectedValue != null &&
                    txtProfition.Text != "" &&
                    ddlStatus.SelectedValue != null &&
                    ddlCity.SelectedValue != null &&
                    ddlPType.SelectedValue != null &&
                    ddlIns.SelectedValue != null &&
                    ddlInsClass.SelectedValue != null &&
                    txtAppLim.Text != "" &&
                    txtExpIns.Text != "" && 
                    FileUpload2.HasFile != false)
                {
                    if (FileUpload1.HasFile)
                    {
                        insUpload();
                        imgUpload();
                    }
                    else
                    {
                        lblmsg.Text = "لم تقم باختيار صورة للهوية";
                    }
                }
                else
                {
                    lblmsg.Text = "لم تقم بادخال بيانات كافية لتسجيل المريض";
                }
            }
        }

        protected void txtNationalityID_TextChanged(object sender, EventArgs e)
        {
            ddlNationalityName.SelectedValue = txtNationalityID.Text;
        }

        protected void txtArFName_TextChanged(object sender, EventArgs e)
        {
            string fn = txtArFName.Text;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand("SELECT EnName FROM NameDic WHERE ArName='"+ fn +"'", con);
            con.Open();
            SqlDataReader dremp = cmd.ExecuteReader();

            if (dremp.Read())
            {

                txtEnFName.Text = Convert.ToString(dremp["EnName"]);
            }
            txtArMName.Focus();
        }
        protected void txtArMName_TextChanged(object sender, EventArgs e)
        {
            string mn = txtArMName.Text;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand("SELECT EnName FROM NameDic WHERE ArName='" + mn + "'", con);
            con.Open();
            SqlDataReader dremp = cmd.ExecuteReader();

            if (dremp.Read())
            {

                txtEnMName.Text = Convert.ToString(dremp["EnName"]);
            }
            txtArTName.Focus();
        }
        protected void txtArTName_TextChanged(object sender, EventArgs e)
        {
            string tn = txtArTName.Text;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand("SELECT EnName FROM NameDic WHERE ArName='" + tn + "'", con);
            con.Open();
            SqlDataReader dremp = cmd.ExecuteReader();

            if (dremp.Read())
            {

                txtEnTName.Text = Convert.ToString(dremp["EnName"]);
            }
            txtArLName.Focus();
        }
        protected void txtArLName_TextChanged(object sender, EventArgs e)
        {
            string ln = txtArLName.Text;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand("SELECT EnName FROM NameDic WHERE ArName='" + ln + "'", con);
            con.Open();
            SqlDataReader dremp = cmd.ExecuteReader();

            if (dremp.Read())
            {

                txtEnLName.Text = Convert.ToString(dremp["EnName"]);
            }
        }

        //protected void txtDoc_TextChanged(object sender, EventArgs e)
        //{
        //    ddlDoc.SelectedValue = txtDoc.Text;
        //}

        protected void txtPType_TextChanged(object sender, EventArgs e)
        {
            ddlPType.SelectedValue = txtPType.Text;
        }

        protected void txtFile_TextChanged(object sender, EventArgs e)
        {
            lblmsg.Text = "";
            lblmsg.ForeColor = System.Drawing.Color.Coral;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand("select [Patient].[Id]" +
                                                    ",[Patient].[PID]" +
                                                    ",[Patient].[FName]" +
                                                    ",[Patient].[MName]" +
                                                    ",[Patient].[TName]" +
                                                    ",[Patient].[LName]" +
                                                    ",[Patient].[ArFName]" +
                                                    ",[Patient].[ArMName]" +
                                                    ",[Patient].[ArTName]" +
                                                    ",[Patient].[ArLName]" +
                                                    ",[Patient].[IDType]" +
                                                    ",[Patient].[Mobile]" +
                                                    ",[Patient].[Nationality]" +
                                                    ",[Patient].[Profition]" +
                                                    ",[Patient].[Address]" +
                                                    ",CONVERT(varchar, [Patient].[DOB], 111) as DOB" +
                                                    ",CONVERT(varchar, [Patient].[InDate], 111) as InDate" +
                                                    ",CONVERT(varchar, [Patient].[InDate], 0) as InTime" +
                                                    ",[Patient].[Organization]" +
                                                    ",[Patient].[Ad]" +
                                                    ",[Patient].[Marital]" +
                                                    ",[Patient].[FCode]" +
                                                    ",[Patient].[Tel]" +
                                                    ",[Patient].[email]" +
                                                    ",[Patient].[City]" +
                                                    ",[Patient].[Neighbour]" +
                                                    ",[Patient].[Comment]" +
                                                    ",[Patient].[PType]" +
                                                    ",[Patient].[Gender]" +
                                                    ",([Employees].[ArFName] + ' ' + [Employees].[ArLName]) as EmpName" +
                                                    ",[Patient].[FileNo]" +
                                                    ",[Patient].[IDCard]" +
                                      " from [Patient],[Employees]" +
                                      " where [Patient].[FileNo]='" + txtFile.Text + "'" +
                                      " AND [Employees].[EmpID] = [Patient].[Regby]", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                //erease
                CardNo.Text = "";
                IID.Text = "";
                Exp.Text = "";
                imageInsurance.ImageUrl = null;
                imageInsurance.Width = 0; imageInsurance.Height = 0;
                txtIDNo.Text = ""; 
                txtEnFName.Text = ""; 
                txtEnMName.Text = ""; 
                txtEnTName.Text = ""; 
                txtEnLName.Text = ""; 
                txtArFName.Text = ""; 
                txtArMName.Text = "";
                txtArTName.Text = ""; 
                txtArLName.Text = ""; 
                ddlIDType.SelectedValue = "0"; 
                txtMobile.Text = ""; 
                txtNationalityID.Text = ""; 
                ddlNationalityName.SelectedValue = "0"; 
                txtProfition.Text = ""; 
                txtAddress.Text = ""; 
                txtDOB.Text = ""; 
                txtRDate.Text = "";
                txtRDate.Text = ""; 
                txtCompanyName.Text = ""; 
                ddlMar.SelectedValue = "0"; 
                ddlStatus.SelectedValue = "0"; 
                ddlFamilyCode.SelectedValue = "0";
                txtTel.Text = ""; 
                txtEmail.Text = ""; 
                ddlCity.SelectedValue = "0";
                txtCom.Text = ""; 
                txtPType.Text = ""; 
                ddlPType.SelectedValue = "0"; 
                rblGender.SelectedValue = null;
                txtRegBy.Text = "";
                txtIns.Text = "";
                ddlIns.SelectedIndex = 0;
                txtInsClass.Text = "";
                ddlInsClass.SelectedIndex = 0;
                txtExpIns.Text = "";
                txtAppLim.Text = "";

                //insert
                string date = Convert.ToString(dr["InDate"]);
                string time = Convert.ToString(dr["InTime"]);
                time = time.Substring(11).Trim();
                if (!dr.IsDBNull(1)) { txtIDNo.Text = Convert.ToString(dr["PID"]); } else { txtIDNo.Text = ""; }
                if (!dr.IsDBNull(2)) { txtEnFName.Text = Convert.ToString(dr["FName"]); } else { txtEnFName.Text = ""; }
                if (!dr.IsDBNull(3)) { txtEnMName.Text = Convert.ToString(dr["MName"]); } else { txtEnMName.Text = ""; }
                if (!dr.IsDBNull(4)) { txtEnTName.Text = Convert.ToString(dr["TName"]); } else { txtEnTName.Text = ""; }
                if (!dr.IsDBNull(5)) { txtEnLName.Text = Convert.ToString(dr["LName"]); } else { txtEnLName.Text = ""; }
                if (!dr.IsDBNull(6)) { txtArFName.Text = Convert.ToString(dr["ArFName"]); } else { txtArFName.Text = ""; }
                if (!dr.IsDBNull(7)) { txtArMName.Text = Convert.ToString(dr["ArMName"]); } else { txtArMName.Text = ""; }
                if (!dr.IsDBNull(8)) { txtArTName.Text = Convert.ToString(dr["ArTName"]); } else { txtArTName.Text = ""; }
                if (!dr.IsDBNull(9)) { txtArLName.Text = Convert.ToString(dr["ArLName"]); } else { txtArLName.Text = ""; }
                if (!dr.IsDBNull(10)) { ddlIDType.SelectedValue = Convert.ToString(dr["IDType"]).Trim(); } else { ddlIDType.SelectedValue = ""; }
                if (!dr.IsDBNull(11)) { txtMobile.Text = Convert.ToString(dr["Mobile"]); } else { txtMobile.Text = ""; }
                if (!dr.IsDBNull(12)) { txtNationalityID.Text = Convert.ToString(dr["Nationality"]); } else { txtNationalityID.Text = ""; }
                if (!dr.IsDBNull(12)) { ddlNationalityName.SelectedValue = Convert.ToString(dr["Nationality"]).Trim(); } else { ddlNationalityName.SelectedValue = ""; }
                if (!dr.IsDBNull(13)) { txtProfition.Text = Convert.ToString(dr["Profition"]); } else { txtProfition.Text = ""; }
                if (!dr.IsDBNull(14)) { txtAddress.Text = Convert.ToString(dr["Address"]); } else { txtAddress.Text = ""; }
                if (!dr.IsDBNull(15)) { txtDOB.Text = Convert.ToString(dr["DOB"]); } else { txtDOB.Text = ""; }
                if (!dr.IsDBNull(16)) { txtRDate.Text = date; } else { txtRDate.Text = ""; }
                if (!dr.IsDBNull(16)) { txtRTime.Text = time; } else { txtRDate.Text = ""; }
                if (!dr.IsDBNull(17)) { txtCompanyName.Text = Convert.ToString(dr["Organization"]); } else { txtCompanyName.Text = ""; }
                if (!dr.IsDBNull(18)) { ddlMar.SelectedValue = Convert.ToString(dr["Ad"]).Trim(); } else { ddlMar.SelectedValue = ""; }
                if (!dr.IsDBNull(19)) { ddlStatus.SelectedValue = Convert.ToString(dr["Marital"]).Trim(); } else { ddlStatus.SelectedValue = ""; }
                if (!dr.IsDBNull(20)) { ddlFamilyCode.SelectedValue = Convert.ToString(dr["FCode"]).Trim(); } else { ddlFamilyCode.SelectedValue = ""; }
                if (!dr.IsDBNull(21)) { txtTel.Text = Convert.ToString(dr["Tel"]); } else { txtTel.Text = ""; }
                if (!dr.IsDBNull(22)) { txtEmail.Text = Convert.ToString(dr["email"]); } else { txtEmail.Text = ""; }
                if (!dr.IsDBNull(23)) { ddlCity.SelectedValue = Convert.ToString(dr["City"]).Trim(); if (Convert.ToString(dr["Neighbour"]) != "0") { InsertDataToNieghbours(); } if (!dr.IsDBNull(24) && Convert.ToString(dr["Neighbour"]) !="0") { ddlNeighbour.SelectedValue = Convert.ToString(dr["Neighbour"]).Trim(); } else { ddlNeighbour.SelectedValue = ""; } } else { ddlCity.SelectedValue = ""; InsertDataToNieghbours(); }
                if (!dr.IsDBNull(25)) { txtCom.Text = Convert.ToString(dr["Comment"]); } else { txtCom.Text = ""; }
                if (!dr.IsDBNull(26)) { txtPType.Text = Convert.ToString(dr["PType"]); } else { txtPType.Text = ""; }
                if (!dr.IsDBNull(26)) { ddlPType.SelectedValue = Convert.ToString(dr["PType"]).Trim(); } else { ddlPType.SelectedValue = ""; }
                if (!dr.IsDBNull(27)) { rblGender.SelectedValue = Convert.ToString(dr["Gender"]).Trim(); } else { }
                if (!dr.IsDBNull(28)) { txtRegBy.Text = Convert.ToString(dr["EmpName"]).Trim(); } else { txtRegBy.Text = ""; }
                if (!dr.IsDBNull(29)) {
                    IDCard.ImageUrl = "Uploads/" + Convert.ToString(dr["IDCard"]).Trim();

                    //var Ocr = new AdvancedOcr()
                    //{
                    //    Language = IronOcr.Languages.Arabic.OcrLanguagePack,
                    //    ColorSpace = AdvancedOcr.OcrColorSpace.GrayScale,
                    //    EnhanceResolution = true,
                    //    EnhanceContrast = true,
                    //    CleanBackgroundNoise = true,
                    //    ColorDepth = 4,
                    //    RotateAndStraighten = false,
                    //    DetectWhiteTextOnDarkBackgrounds = false,
                    //    ReadBarCodes = false,
                    //    Strategy = AdvancedOcr.OcrStrategy.Fast,
                    //    InputImageType = AdvancedOcr.InputTypes.Document
                    //};

                    //var Result = Ocr.Read(upDir+ "/" + Convert.ToString(dr["IDCard"]).Trim());
                    //lblocr.Text = Result.Text;
                } else
                {
                    IDCard.ImageUrl = "";
                }

                con.Close();

                cmd = new SqlCommand("select [PatientInsurance].[CardNo]" +
                                           ",[Insurance].[Name]" +
                                           ",CONVERT(varchar, [PatientInsurance].[Expire], 111) as Expire" +
                                           ",[PatientInsurance].[CardImageURL]" +
                                    " FROM [PatientInsurance],[Insurance]" +
                                    " WHERE [PatientInsurance].[PF] = '" + txtFile.Text + "'" +
                                    " AND [Insurance].[IID] = [PatientInsurance].[IID]", con);
                con.Open();
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    if (!dr.IsDBNull(0)) { CardNo.Text = Convert.ToString(dr["CardNo"]).Trim(); } else { CardNo.Text = ""; }
                    if (!dr.IsDBNull(1)) { IID.Text = Convert.ToString(dr["Name"]).Trim(); } else { IID.Text = ""; }
                    if (!dr.IsDBNull(2)) { Exp.Text = Convert.ToString(dr["Expire"]).Trim(); } else { Exp.Text = ""; }
                    if (!dr.IsDBNull(3)) { imageInsurance.ImageUrl = "Uploads/" + Convert.ToString(dr["CardImageURL"]).Trim(); imageInsurance.Width = 400; imageInsurance.Height = 210; } else { imageInsurance.ImageUrl = ""; }
                }
                lblmsg.Text = "تم العثور على ملف المريض " + txtFile.Text;
                lblmsg.ForeColor = System.Drawing.Color.GreenYellow;
            }
            else
            {
                lblmsg.Text = "لا يوجد ملف بهذا الرقم";
                
                
            }
            con.Close();
        }
        
        private string upDir;
        protected void imgUpload()
        {
            // check if a file is being submitted  
            if (FileUpload1.PostedFile.FileName != "")
            {
                // check extension  
                string ext = Path.GetExtension(FileUpload1.PostedFile.FileName);

                var myUniqueFileName= $@"{Guid.NewGuid()}{ext}";
                switch (ext.ToLower())
                {
                    case ".png":
                    case ".jpg":
                    case ".jpeg":
                        break;
                    default:
                        lblmsg.Text = "عذراً الملف الذي قمت باختياره بصيغة غير مسموحة...";
                        return;
                }
                
                // using the following 2 lines of code the file will retain its original name.  
                string sfn = Path.GetFileName(FileUpload1.PostedFile.FileName);
                string fPath = Path.Combine(upDir, myUniqueFileName);
                
                    bool isInserted = addNewCustomer(myUniqueFileName);
                if (isInserted)
                {
                    try
                    {
                        FileUpload1.PostedFile.SaveAs(fPath);
                    }
                    catch (IOException ex)
                    {
                        lblmsg.Text = "خطأ اثناء رفع المرفق: " + ex.Message;
                    }
                    catch (Exception er)
                    {
                        lblmsg.Text += "خطأ غير معروف: " + er.Message;
                    }
                }

                }
        }
        string upins;
        protected void insUpload()
        {
            // check if a file is being submitted  
            if (FileUpload2.PostedFile.FileName != "")
            {
                // check extension  
                string ext = Path.GetExtension(FileUpload2.PostedFile.FileName);

                var myUniqueFileName = $@"{Guid.NewGuid()}{ext}";
                upins = myUniqueFileName;
                switch (ext.ToLower())
                {
                    case ".png":
                    case ".jpg":
                    case ".jpeg":
                        break;
                    default:
                        lblmsg.Text = "عذراً الملف الذي قمت باختياره بصيغة غير مسموحة...";
                        return;
                }

                // using the following 2 lines of code the file will retain its original name.  
                string sfn = Path.GetFileName(FileUpload2.PostedFile.FileName);
                string fPath = Path.Combine(upDir, myUniqueFileName);
                
                try
                {
                    FileUpload2.PostedFile.SaveAs(fPath);
                }
                catch (IOException ex)
                {
                    lblmsg.Text = "خطأ اثناء رفع المرفق: " + ex.Message;
                }
                catch (Exception er)
                {
                    lblmsg.Text += "خطأ غير معروف: " + er.Message;
                }
            }
        }

        protected void ddlIDType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlIDType.SelectedValue=="1")
            {
                txtNationalityID.Text = "3";
                ddlNationalityName.SelectedValue = "3";
            }
            else if(ddlNationalityName.SelectedValue == "3")
            {
                txtNationalityID.Text = "";
                ddlNationalityName.SelectedIndex = 0;
            }
        }
        //protected void TextBox2_TextChanged(object sender, EventArgs e)
        //{
        //    DateTime now = DateTime.Now;
        //    DateTime givenDate = DateTime.Parse(txtDOB.Text);

        //    int days = now.Subtract(givenDate).Days;
        //    int age = Convert.ToInt32(Math.Floor(days / 365.24219));
        //    txtAge.Text = age.ToString();
        //}

    }
    
}