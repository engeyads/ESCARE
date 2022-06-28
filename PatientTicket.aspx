<%@ Page Title="Patient Ticket" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PatientTicket.aspx.cs" Inherits="ESCARE.PatientTicket" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script>
        $(document).ready(function () {
            if ($("#hdnDdlOldValue").val() != $("#DropDownList2").val()) {
                DropdwonOnChangeFunction();
            }
        });
    </script>
    <div class="jumbotron">
        <div id="wrapper">
            
            <div><asp:Label ID="lblPName" runat="server" Text="Search Patient File"></asp:Label>
            </div>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server" style="float:left" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:TextBox ID="txtPID" runat="server" OnTextChanged="txtPID_TextChanged" Width="150px"></asp:TextBox>
                    
                </ContentTemplate>
            </asp:UpdatePanel>
            <div><asp:Button ID="btnSrch" runat="server" OnClick="Button1_Click" Text="Search" />
            </div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:Timer ID="Timer1" runat="server" OnTick="RefreshGridView" Interval="2000" />
                    <asp:GridView  ID="gvPendingPatients" OnRowDataBound="gv_RowDataBound" OnSelectedIndexChanged="gvPList_SelectedIndexChanged" runat="server" AllowSorting="True" AutoGenerateSelectButton="True" CellPadding="3" ForeColor="Black" GridLines="Vertical" Width="894px" Height="59px" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" AllowPaging="True" PageSize="5" EnableSortingAndPagingCallbacks="false" OnPageIndexChanging="gvPList_PageIndexChanging" ontick="timer_Tick" AutoPostBack="true">
                        <AlternatingRowStyle BackColor="#CCCCCC" Wrap="False" />
                        <EditRowStyle Wrap="False" />
                        <FooterStyle BackColor="#CCCCCC" />
                        <HeaderStyle BackColor="#101010" BorderStyle="Inset" Font-Bold="True" ForeColor="White" Height="20px" Wrap="False" />
                        <PagerSettings PageButtonCount="4" />
                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                        <RowStyle Height="20px" Wrap="False" />
                        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" Wrap="False" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#808080" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#383838" />

                    </asp:GridView>
                    
                </ContentTemplate>
            </asp:UpdatePanel>

            <br />
            <asp:Button ID="btnRecipe" runat="server" Text="Write Report" OnClick="btnRecipe_Click" />
            <asp:Button ID="btnViewPrev" runat="server" Text="View Previous Reports" OnClick="btnViewPrev_Click" />
        </div>
    </div>
    <div class="row">
    </div>
    <asp:HiddenField ID="HiddenField1" runat="server" OnValueChanged="HiddenField1_ValueChanged" />
</asp:Content>
