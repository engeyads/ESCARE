<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ESCARE._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href="CSS/Default.css" rel="stylesheet" />
    <link href="CSS/font-awsome.min.css" rel="stylesheet" />
    <script src="https://code.jquery.com/jquery-1.10.2.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <div class="bg bluring"></div>
    <div class="jumbotron bluring">



        <div class="butos">
            <table>
                <tr>
                    <td>
                        <%--<asp:Button ID="btnAppo" runat="server" CssClass="buts Button1" Text="Appointment" />
                        <asp:ImageButton id="btnApp" runat="server" CssClass="buts Button1" ImageUrl="~/icons/Simpleicons_Business_calendar-with-a-clock-time-tools.svg.png" />
                        <asp:Label ID="Label1" runat="server" CssClass="buts" Text="Appointment"></asp:Label>--%>
                        <ul>
                            <li id="btnAppo">
                                <p>Appointment</p>
                            </li>
                        </ul>
                    </td>
                    <td>
                        <%--<asp:Button ID="btnAdmin" runat="server" CssClass="buts" Text="Administrator" />--%>
                        <ul>
                            <li id="btnAdmin">
                                <p>Administrator</p>
                            </li>
                        </ul>
                    </td>
                    <td>
                        <%--<asp:Button ID="btnRad" runat="server" CssClass="buts" Text="Radiology" />--%>
                        <ul>
                            <li id="btnRad">
                                <p>Radiology</p>
                            </li>
                        </ul>
                    </td>
                    <td>
                        <%--<asp:Button ID="btnLab" runat="server" CssClass="buts" Text="Lab" />--%>
                        <ul>
                            <li id="btnLab">
                                <p>Lab</p>
                            </li>
                        </ul>
                    </td>
                    <td>
                        <%--<asp:Button ID="btnPat" runat="server" CssClass="buts" Text="Patient" />--%>
                        <ul>
                            <li id="btnPat">
                                <p>Patient</p>
                            </li>
                        </ul>
                    </td>
                    <td>
                        <%--<asp:Button ID="btnCPat" runat="server" CssClass="buts button2" Text="Company Patient" />--%>
                        <ul>
                            <li id="btnCPat">
                                <p>Company Patient</p>
                            </li>
                        </ul>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%--<asp:Button ID="btnServ" runat="server" CssClass="buts" Text="Service" />--%>
                        <ul>
                            <li id="btnServ">
                                <p>Service</p>
                            </li>
                        </ul>
                    </td>
                    <td>
                        <%--<asp:Button ID="btnFPat" runat="server" CssClass="buts" Text="Family Patient" />--%>
                        <ul>
                            <li id="btnFPat">
                                <p>Family Patient</p>
                            </li>
                        </ul>
                    </td>
                    <td colspan="2">
                        <%--<asp:Button ID="btnMaster" runat="server" CssClass="buts" Text="Master" />--%>
                        <ul>
                            <li id="btnMaster">
                                <p>Master</p>
                            </li>
                        </ul>
                    </td>
                    <td>
                        <%--<asp:Button ID="btnRep" runat="server" CssClass="buts" Text="Reports" />--%>
                        <ul>
                            <li id="btnRep">
                                <p>Reports</p>
                            </li>
                        </ul>
                    </td>
                    <td>
                        <%--<asp:Button ID="btnER" runat="server" CssClass="buts" Text="Emergency" />--%>
                        <ul>
                            <li id="btnER">
                                <p>Emergency</p>
                            </li>
                        </ul>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%--<asp:Button ID="btnCWD" runat="server" CssClass="buts button3" Text="Cash with Discount" />--%>
                        <ul>
                            <li id="btnCWD">
                                <p>Cash with Discount</p>
                            </li>
                        </ul>
                    </td>
                    <td>
                        <%--<asp:Button ID="btnDoc" runat="server" CssClass="buts" Text="Doctor" />--%>
                        <ul>
                            <li id="btnDoc">
                                <p>Doctor</p>
                            </li>
                        </ul>
                    </td>
                    <td>
                        <%--<asp:Button ID="btnBill" runat="server" CssClass="buts" Text="Billing" />--%>
                        <ul>
                            <li id="btnBill">
                                <p>Billing</p>
                            </li>
                        </ul>
                    </td>
                    <td>
                        <%--<asp:Button ID="btnIns" runat="server" CssClass="buts" Text="Insurance" />--%>
                        <ul>
                            <li id="btnIns">
                                <p>Insurance</p>
                            </li>
                        </ul>
                    </td>
                    <td>
                        <%--<asp:Button ID="btnSR" runat="server" CssClass="buts" Text="Stock Room" />--%>
                        <ul>
                            <li id="btnSR">
                                <i></i>
                                <p>Stock Room</p>
                            </li>
                        </ul>

                    </td>
                    <td>
                        <%--<asp:Button ID="btnOp" runat="server" CssClass="buts button4" Text="Operations" />--%>
                        <ul>
                            <li id="btnOp">
                                <p>Operations</p>
                            </li>
                        </ul>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div class="dim">
    </div>
    <div class="cl">
        <div class="cl-head"></div>
        <div class="inbutos">
            <table></table>
        </div>
    </div>
    <div class="lang bluring">
        <div class="pl"><i class="icon-cog"></i></div>
        <div class="langBar">
            <table>
                <tr>
                    <td>
                        <ul>
                            <li id="btnLang">
                                <p>اللغة العربية</p>
                                <i></i>
                            </li>
                        </ul>
                    </td>
                </tr>
                <tr>
                    <td>
                        <ul>
                            <li id="btnLog">
                                <asp:LoginView runat="server" ViewStateMode="Disabled">
                                    <LoggedInTemplate>
                                        <asp:LoginStatus id="lgot" runat="server" LogoutAction="Redirect" LogoutText="Log off <i class='icon-signout'></i>" LogoutPageUrl="~/" OnLoggingOut="Unnamed_LoggingOut" />
                                    </LoggedInTemplate>
                                </asp:LoginView>

                            </li>
                        </ul>
                    </td>
                </tr>
            </table>
        </div>
    </div>

    <div class="DateTimeNow bluring">
        <table>
            <tr>
                <td>
                    <ul>
                        <li id="nowLoged">
                            <p><i class="icon-user"></i>أهلاً، <asp:Label ID="Label1" runat="server" CssClass="nowLoged p" text="" Enabled="True"></asp:Label> !</p>
                        </li>
                    </ul>
                </td>
            </tr>
            <tr>
                <td>
                    <ul>
                        <li id="nowdate">
                            <p><i class="icon-calendar"></i><i id="date"></i></p>
                        </li>
                    </ul>
                </td>
            </tr>
            <tr>
                <td>
                    <ul>
                        <li id="nowtime">
                            <p><i class="icon-time"></i><i id="time"></i></p>
                        </li>
                    </ul>
                </td>
            </tr>
        </table>
    </div>
    <script src="Scripts/datetimeup.js"></script>
    <script src="Scripts/popup.js"></script>
</asp:Content>
