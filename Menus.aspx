<%@ Page Title="Create New Receipt" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Menus.aspx.cs" Inherits="ESCARE.Menus" %>

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
            <asp:Label ID="lblmsg" runat="server" Text=""></asp:Label>
            <asp:Button ID="btnAddNewEmployee" runat="server" Text="Add New Employee" OnClick="btnAddNewEmployee_Click" />
            <asp:Button ID="btnManageEmpClinic" runat="server" Text="Add Employee to Clinic" onClick="btnManageEmpClinic_Click"/>
            <asp:Button ID="btnCheckReceipts" runat="server" Text="Check Receipts" OnClick="btnCheckReceipts_Click"/>
            <asp:Button ID="btnCheckEmployees" runat="server" Text="Check Employees" OnClick="btnCheckEmployees_Click" />
        </div>
    </div>
    <div class="row">
    </div>

</asp:Content>
