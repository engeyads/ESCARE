using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ESCARE
{
    public partial class Receipt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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
            string sConstring = ConfigurationManager.ConnectionStrings["Hospital"].ConnectionString;
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
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Hospital"].ConnectionString);
            SqlCommand cmd;// new SqlCommand("SELECT COUNT(*) from patient where PID like '%" + txtPID.Text + "%'", con);
            int userCount = 0;
            DataTable dt = new DataTable();
                switch (rbgSearchBy.SelectedValue)
                {
                    case "0":
                        cmd = new SqlCommand("SELECT COUNT(*) from patient where PID like '%" + txtPID.Text + "%'", con);
                        con.Open();
                        userCount = (int)cmd.ExecuteScalar();
                        con.Close();
                        if (userCount != 0)
                        {
                            dt = GetDataTable("SELECT patient.PID, (patient.FName+' '+patient.MName+' '+patient.LName) AS EnName, (patient.ArFName+' '+patient.ArMName+' '+patient.ArLName) AS ArName, CASE WHEN IDType = 1 THEN 'ID Card' ELSE 'Passport' END AS IDType, patient.Mobile, countries.Name, patient.Profition, patient.Blood, patient.Address, patient.DOB, patient.InDate FROM patient,countries where patient.PID like '%" + txtPID.Text + "%' AND countries.ID = patient.Nationality");
                            lblmsg.Text = "by ID / Passport!";
                            lblmsg.ForeColor = System.Drawing.Color.CornflowerBlue;
                            lblmsg.Visible = true;
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
                        if (userCount != 0)
                        {
                            dt = GetDataTable("SELECT patient.PID, (patient.FName+' '+patient.MName+' '+patient.LName) AS EnName, (patient.ArFName+' '+patient.ArMName+' '+patient.ArLName) AS ArName, CASE WHEN IDType = 1 THEN 'ID Card' ELSE 'Passport' END AS IDType, patient.Mobile, countries.Name, patient.Profition, patient.Blood, patient.Address, patient.DOB, patient.InDate FROM patient,countries where patient.Mobile like '%" + txtPID.Text + "%' AND countries.ID = patient.Nationality");
                            lblmsg.Text = "by Mobile / Phone!";
                            lblmsg.ForeColor = System.Drawing.Color.CornflowerBlue;
                            lblmsg.Visible = true;
                        }
                        else
                        {
                            lblmsg.Text = "Record Not Existed";
                            lblmsg.ForeColor = System.Drawing.Color.Red;
                            lblmsg.Visible = true;
                        }
                    break;
                    case "2":
                        cmd = new SqlCommand("SELECT COUNT(*) from patient where patient.FName like '%" + txtPID.Text + "%'", con);
                        con.Open();
                        userCount = (int)cmd.ExecuteScalar();
                        con.Close();
                        if (userCount != 0)
                        {
                            dt = GetDataTable("SELECT patient.PID, (patient.FName+' '+patient.MName+' '+patient.LName) AS EnName, (patient.ArFName+' '+patient.ArMName+' '+patient.ArLName) AS ArName, CASE WHEN IDType = 1 THEN 'ID Card' ELSE 'Passport' END AS IDType, patient.Mobile, countries.Name, patient.Profition, patient.Blood, patient.Address, patient.DOB, patient.InDate FROM patient,countries where patient.FName like '%" + txtPID.Text + "%' AND countries.ID = patient.Nationality");
                            lblmsg.Text = "by First Name!";
                            lblmsg.ForeColor = System.Drawing.Color.CornflowerBlue;
                            lblmsg.Visible = true;
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

        protected void getTblAvDoc()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Hospital"].ConnectionString);
            SqlCommand cmd = new SqlCommand("SELECT distinct COUNT(*) from Clinic,Employees where Employees.Profition = '03' AND Clinic.SID = '" + DropDownList2.SelectedValue + "'", con);
            int userCount = 0;
            DataTable dt = new DataTable();

            con.Open();
            userCount = (int)cmd.ExecuteScalar();

            if (userCount != 0)
            {
                dt = GetDataTable("SELECT distinct Employees.EID, (Employees.FName+' '+Employees.LName) AS 'Doctor En Name', (Employees.ArFName+' '+Employees.ArLName) AS 'Doctor Ar Name' from Clinic,Employees where Employees.Profition = '03' AND Clinic.SID = '" + DropDownList2.SelectedValue + "'");
                
            }
            else
            {
                lblmsg.Text = "No Doctors Available!";
                lblmsg.ForeColor = System.Drawing.Color.Red;
                lblmsg.Visible = true;
            }

            grdDoc.DataSource = dt;
            grdDoc.DataBind();
            con.Close();

        }

        protected void txtPID_TextChanged(object sender, EventArgs e)
        {
            getTblPFiles();
        }
        protected void gvPList_SelectedIndexChanged(object sender, EventArgs e)
        {

            GridViewRow row = gvPList.SelectedRow;

            // In this example, the first column (index 0) contains
            lblmsg.Text = gvPList.SelectedRow.Cells[1].Text;

            lblmsg.ForeColor = System.Drawing.Color.Brown;
                lblmsg.Visible = true;
            
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {

            getTblAvDoc();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Hospital"].ConnectionString);
            SqlCommand cmd = new SqlCommand("SELECT price from services where SID = '" + DropDownList2.SelectedValue + "'", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                txtPrice.Text = Convert.ToString(dr["price"]);
            }
            else
            {
                txtPrice.Text = "false";
                txtPrice.DataBind();
            }
            con.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            getTblPFiles();
        }

        protected void btnProceed_Click(object sender, EventArgs e)
        {
            getTblAvDoc();
        }

        protected void btnRecipe_Click(object sender, EventArgs e)
        {

        }
    }

}