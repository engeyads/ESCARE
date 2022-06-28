<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PreviousCustomer.aspx.cs" Inherits="ESCARE.PreviousCustomer" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script>
        //$(document).ready(function () {
        //    if ($("#hdnDdlOldValue").val() != $("#DropDownList2").val()) {
        //        DropdwonOnChangeFunction();
        //    }
        //});
    </script>
    <div class="jumbotron">
    <div id="wrapper">
        Patient:
        
        <br />
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <asp:TextBox ID="txtPID" runat="server"  Width="150px" Enabled="true" OnTextChanged="txtPID_TextChanged" ></asp:TextBox>
                <asp:Label ID="lblmsg" runat="server" Text=""></asp:Label>
                <asp:GridView ID="gvPList" runat="server" AutoGenerateSelectButton="True" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" OnSelectedIndexChanged="gvPList_SelectedIndexChanged" OnPageIndexChanging="gvPList_PageIndexChanging" AllowPaging="True" GridLines="Vertical" PageSize="5">
                    <AlternatingRowStyle BackColor="#CCCCCC" />
                    <FooterStyle BackColor="#CCCCCC" />
                    <HeaderStyle BackColor="#101010" Font-Bold="True" ForeColor="White" />
                    <PagerSettings PageButtonCount="4" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#808080" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#383838" />
                </asp:GridView>
                <br />
                <asp:GridView ID="gvPReports" runat="server" AllowPaging="True" AutoGenerateSelectButton="True" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" OnSelectedIndexChanged="gvPReports_SelectedIndexChanged" OnPageIndexChanging="gvPReports_PageIndexChanging" PageSize="5">
                    <AlternatingRowStyle BackColor="#CCCCCC" />
                    <FooterStyle BackColor="#CCCCCC" />
                    <HeaderStyle BackColor="#101010" Font-Bold="True" ForeColor="White" />
                    <PagerSettings PageButtonCount="4" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#808080" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#383838" />
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:Label ID="lblMedicalReport" runat="server" Text="Report: "></asp:Label>
        
        <br />
        <asp:Label ID="lblMedic" runat="server" Text="Medicine:"></asp:Label>
        <br />
        
            
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:TextBox ID="txtMedicalReport" runat="server" Height="145px" TextMode="MultiLine" Width="584px" OnTextChanged="txtMedicalReport_TextChanged" ></asp:TextBox>

                <br />
                <asp:GridView ID="GridView1" runat="server"></asp:GridView>
                <asp:Button ID="btnPrintReport" runat="server" Text="Print Report" OnClick="btnPrintReport_Click"  />
                <asp:Button ID="btnPrintMidic" runat="server" Text="Print Medicine" OnClick="btnPrintMidic_Click"  />
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:Button ID="btnDone" runat="server" Text="Done" OnClick="btnDone_Click"  />
        <asp:Label ID="lbmsg" runat="server"></asp:Label>
        

        <br />
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
        <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
    </div>
        </div>
    <div class="row">
    </div>
    <asp:HiddenField ID="HiddenField1" runat="server" />
</asp:Content>
