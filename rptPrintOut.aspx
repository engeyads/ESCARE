<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="rptPrintOut.aspx.cs" Inherits="ESCARE.rptPrintOut" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
           
        <Report FileName="Reports\CrystalReport1.rpt">
        </Report>

        </CR:CrystalReportSource>
    </div>
    </form>
</body>
</html>
