<%@ Page Title="Create New Receipt" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="ESCARE.Main" %>

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
                
        </div>
    </div>
    <div class="row">
    </div>
    <asp:HiddenField ID="HiddenField1" runat="server" OnValueChanged="HiddenField1_ValueChanged" />
</asp:Content>
