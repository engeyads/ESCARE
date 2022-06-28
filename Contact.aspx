<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="ESCARE.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Contact Us:</h3>
    <address>
        Saudi Arabia<br />
        Eastern Province, Dammam<br />
        <abbr title="Phone">Mobile:</abbr>
        + (966) 50 439 9960
    </address>

    <address>
        <strong>Contact:</strong>   <a href="mailto:eyad@sammours.com">eyad@sammours.com</a><br />
        <%--<strong>Marketing:</strong> <a href="mailto:Marketing@example.com">Marketing@example.com</a>--%>
    </address>
</asp:Content>
