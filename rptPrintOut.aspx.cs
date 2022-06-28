using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using System.ComponentModel;
using System.Drawing;
using System.Web.SessionState;
using System.Drawing.Printing;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Web;
using Microsoft.Win32;
using System.IO;
using System.Data.SqlClient;


namespace ESCARE
{
    public partial class rptPrintOut : System.Web.UI.Page
    {
        protected string[] sAccess;
        ReportDocument rd;
        DiskFileDestinationOptions diskOpts;
        FileStream fs;
        long FileSize;

        #region Page Load


        protected void Page_Load(object sender, EventArgs e)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
            // If Session Expired, then redirect to Error Page
            Session["UserName"] = "Eyad";
            if (Session["UserName"] == null)
            {
                Response.Redirect("errors/sessionNotAvailable.aspx");
            }

            if (Request.QueryString["sRef"] != null)
                switch (Request.QueryString["sRef"].ToString())
                {
                    case "Receipt":
                        PrintReceipt();
                        break;
                }
        }

        #region Receipt
        private void PrintReceipt()
        {
            string RptServer = "ESSERVER";// ConfigurationManager.AppSettings["reportServer"].ToString();
            string RptUserId = "Report";// ConfigurationManager.AppSettings["ReportUser"].ToString();
            string RptPwd = "Rp12345!";// ConfigurationManager.AppSettings["ReportPwd"].ToString();
            string RptDatabase = "Hospital";// ConfigurationManager.AppSettings["ReportDatabase"].ToString();
            string nDiffHours = "3"; //Chttp://localhost/rptPrintOut.aspx.csonfigurationManager.AppSettings["nDiffTime"].ToString();

            string sReportSource = "Reports\\CrystalReport3.rpt";

            rd = new ReportDocument();
            rd.Load(Server.MapPath(sReportSource));
            ConnectionInfo cl = new ConnectionInfo();

            //CrystalReportLogon cl = new CrystalReportLogon(this.Page);
            //cl.CrReportLogon(rd, RptServer, ConfigurationManager.AppSettings["ReportDatabase"].ToString(), RptUserId, RptPwd);

            cl.ServerName = RptServer;
            cl.DatabaseName = RptDatabase;
            cl.UserID = RptUserId;
            cl.Password = RptPwd;

            TableLogOnInfos crtableLogoninfos = new TableLogOnInfos();
            TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
            Tables CrTables;

            CrTables = rd.Database.Tables;
            foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in CrTables)
            {
                crtableLogoninfo = CrTable.LogOnInfo;
                crtableLogoninfo.ConnectionInfo = cl;
                CrTable.ApplyLogOnInfo(crtableLogoninfo);
            }

            //DateTime dtFrom = Convert.ToDateTime(Request.QueryString["dtFrom"].ToString() + " 00:00");
            //DateTime dtTo = Convert.ToDateTime(Request.QueryString["dtTo"].ToString() + " 23:59");

            string lblPrint = "Printed: " + DateTime.Now.AddHours(Convert.ToInt32(nDiffHours)).ToString("dd/MM/yyyy HHmm") + " by " + Session["UserName"].ToString();
            //rd.SetParameterValue("lblPrint", lblPrint);
            rd.SetParameterValue("ReceiptID", Request.QueryString["ReceiptID"].ToString());
            //rd.SetParameterValue("@IDBranch", Request.QueryString["IDBr"].ToString());
            //rd.SetParameterValue("@IDShowroom", Request.QueryString["IDShRoom"].ToString());
            //rd.SetParameterValue("@dtFrom", dtFrom);
            //rd.SetParameterValue("@dtTo", dtTo);

            diskOpts = new DiskFileDestinationOptions();

            string dtCurrentDateString = DateTime.Now.ToString("ddMMyyyyhhmm");
            diskOpts.DiskFileName = Path.GetTempPath()/* Request.PhysicalApplicationPath + "\\Output*/+ "\\Receipt" + dtCurrentDateString + ".pdf";
            rd.ExportOptions.DestinationOptions = diskOpts;

            rd.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
            rd.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
            rd.Export();

            Response.Clear();
            Response.Buffer = true;

            string TargetFileName = Path.GetTempPath()/* Request.PhysicalApplicationPath + "\\Output*/+ "\\Receipt" + dtCurrentDateString + ".pdf";
            fs = new FileStream(TargetFileName, FileMode.Open);
            FileSize = fs.Length;
            byte[] bBuffer = new byte[FileSize];
            fs.Read(bBuffer, 0, Convert.ToInt32(FileSize));
            fs.Close();
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-length", bBuffer.Length.ToString());

            Response.BinaryWrite(bBuffer);
            Response.Flush();
            Response.Close();

            rd.Close();
            rd.Dispose();
            GC.Collect();
        }
        #endregion
    }
}
#endregion
