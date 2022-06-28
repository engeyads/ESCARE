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
    public partial class EnAddCustomer : Page
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
            txtRegBy.Text = getUserFullName();
            txtDOB.Attributes.Add("readonly", "readonly");
            TextBox3.Attributes.Add("readonly", "readonly");
            txtRTime.Attributes.Add("readonly", "readonly");
            txtRDate.Attributes.Add("readonly", "readonly");
            txtAge.Attributes.Add("readonly", "readonly");
            txtFileType.Attributes.Add("readonly", "readonly");
        }

        protected string getUserFullName()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand("SELECT (Employees.FName+' '+Employees.LName) as EnName from Employees,AspNetUsers where AspNetUsers.Id='" + Context.User.Identity.GetUserId() + "' and Employees.EmpID = AspNetUsers.EID", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string name = Convert.ToString(dr["EnName"]).Trim();
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
                
                switch (eid)
                {
                    case "1":
                        Response.Redirect("/Menus.aspx");
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
                        
                        break;
                    default:
                        Response.Redirect("/default.aspx");
                        break;
                }

                con.Close();
            }
            else
            {
                Response.Redirect("/default.aspx");
            }
        }

        protected void addNewCustomer()
        {
            string d = txtDOB.Text.ToString();
            DateTime localDate = DateTime.Now;
            DateTime DOBDate = DateTime.Parse(d);


            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) from patient where PID = '" + txtIDNo.Text + "'", con);

            {
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
                    cmd = new SqlCommand("spINSERT_dbo_Patient", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PID", txtIDNo.Text);
                    cmd.Parameters.AddWithValue("@FName", txtEnFName.Text);
                    cmd.Parameters.AddWithValue("@MName", txtEnMName.Text);
                    cmd.Parameters.AddWithValue("@MMName", txtEnMName.Text);
                    cmd.Parameters.AddWithValue("@LName", txtEnLName.Text);
                    cmd.Parameters.AddWithValue("@ArFName", txtArFName.Text);
                    cmd.Parameters.AddWithValue("@ArMName", txtArMName.Text);
                    cmd.Parameters.AddWithValue("@ArMMName", txtArMName.Text);
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
                    con.Open();

                    int k = cmd.ExecuteNonQuery();
                    if (k != 0)
                    {
                        lblmsg.Text = "Record Inserted Succesfully into the Database";
                        lblmsg.ForeColor = System.Drawing.Color.GreenYellow;
                        lblmsg.Visible = true;
                    }
                    con.Close();
                    

                }

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
        }

        protected void ddlDoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtDoc.Text = ddlDoc.SelectedValue;
            txtDoc.DataBind();
        }
        protected void ddlPType_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtPType.Text = ddlPType.SelectedValue;
            txtPType.DataBind();
        }
        protected void ddlCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            InsertDataToNieghbours();
        }
        protected void InsertDataToNieghbours()
        {
            DataTable dt = GetDataTable("select ID,EnName from Neighbours where City='" + ddlCity.SelectedValue + "'");
            if (dt.IsInitialized) {
                ddlNeighbour.DataSource = dt;
                ddlNeighbour.DataTextField = "EnName";
                ddlNeighbour.DataValueField = "ID";
                ddlNeighbour.DataBind();
                ddlNeighbour.Items.Insert(0, new ListItem("-- Select Neighbourhood --", ""));
            }
        }

        protected void btnProceed_Click(object sender, EventArgs e)
        {
            
            if (txtIDNo.Text != "" &&
                txtEnFName.Text != "" &&
                txtEnMName.Text != "" &&
                txtEnMName.Text != "" &&
                txtEnLName.Text != "" &&
                txtArFName.Text != "" &&
                txtArMName.Text != "" &&
                txtArMName.Text != "" &&
                txtArLName.Text != "" &&
                txtDOB.Text != "" &&
                rblGender.SelectedValue != null &&
                ddlIDType.SelectedValue != null &&
                txtMobile.Text != "" &&
                ddlNationalityName.SelectedValue != null &&
                txtProfition.Text != "" &&
                txtAddress.Text != "" &&
                ddlStatus.SelectedValue != null &&
                txtTel.Text != "" &&
                ddlCity.SelectedValue != null &&
                ddlNeighbour.SelectedValue != null &&
                ddlPType.SelectedValue != null)
            {
                addNewCustomer();
            }
        }

        protected void txtNationalityID_TextChanged(object sender, EventArgs e)
        {
            ddlNationalityName.SelectedValue = txtNationalityID.Text;
        }

        protected void txtDoc_TextChanged(object sender, EventArgs e)
        {
            ddlDoc.SelectedValue = txtDoc.Text;
        }

        protected void txtPType_TextChanged(object sender, EventArgs e)
        {
            ddlPType.SelectedValue = txtPType.Text;
        }

        protected void txtFile_TextChanged(object sender, EventArgs e)
        {

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