<%@ Page Title="Log in" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ESCARE.Account.Login" Async="true" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <%--<h2><%: Title %></h2>--%>
    <script>
        $(".navbar").hide();
    </script>
    <link href="../CSS/esCareLogin.css" rel="stylesheet" />
    <script src="../Auth/login.js"></script>
    <script src="../Scripts/JS.js"></script>
    
    <div class="login">
        
        <div class="imag"></div>
        <h3>Login</h3>
        <hr>
        <table>
            <tr>
                <div class="info">
                    <td><asp:Label ID="lbluser" AssociatedControlID="Email" runat="server" Text="User Name:"></asp:Label></td>
                    <td><asp:TextBox ID="Email" runat="server" placeholder="User Name" Width="160px"></asp:TextBox></td>
                </div>
            </tr>
            <tr>
                <div class="pass">
                    <td><asp:Label ID="lblpass" AssociatedControlID="Password" runat="server" Text="Password:"></asp:Label></td>
                    <td><asp:TextBox ID="Password" TextMode="Password" runat="server" placeholder="Password" Width="160px"></asp:TextBox></td>
                </div>
            </tr>
        </table>
        <div class="err">
            <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                <p class="text-danger">
                    <asp:Literal runat="server" ID="FailureText" />
                </p>
            </asp:PlaceHolder>
        </div>
        <div class="remember">
            <asp:CheckBox runat="server" ID="RememberMe" />
            <asp:Label runat="server" AssociatedControlID="RememberMe">Remember me?</asp:Label>
        </div>
        <div class="Buttons">
            <asp:Button runat="server" OnClick="LogIn" Text="Log in" CssClass="btn btn-default" />
        </div>
    </div>

    <div class="backstretch" style="left: 0px; top: 0px; overflow: hidden; margin: 0px; padding: 0px; height: 404px; width: 1366px; z-index: -999999; position: fixed;"><img style="border-style: none; border-color: inherit; border-width: medium; position: absolute; margin: 0px; padding: 0px; width: 1366px; height: 819.3px; max-width: none; z-index: -999999; left: 0px; top: -207px;" src="Auth/bg05.jpg"></div>
    
</asp:Content>
