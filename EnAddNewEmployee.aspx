<%@ Page Title="Create New Receipt" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EnAddNewEmployee.aspx.cs" Inherits="ESCARE.EnAddNewEmployee" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Page CSS -->
    <link href="CSS/addNewEmployee.css" rel="stylesheet" />
    <!-- new calendar CSS -->
    <link rel="stylesheet" type="text/css" media="screen" href="CSS/bootstrap-datetimepicker.min.css">
    <!-- new calendar JS -->
    <script src="js/1.8.3/jquery.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/bootstrap-datetimepicker.min.js"></script>
    <!-- Begin Page -->
    <div class="bg"></div>
    <div class="jumbotron1">
        <div id="wrapper">
            <asp:Label ID="lblmsg" runat="server" Text=""></asp:Label>
            <table>
                <tr>
                    <td colspan="5">
                        <hr>
                    </td>
                </tr>
                <tr class="taH2r">
                    <td colspan="5" class="taH2">
                        <asp:Label ID="lblArName" runat="server" Text="الاسم (عربي)" CssClass="labelStyleH2"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div>
                            <asp:Label ID="lblArFName" runat="server" Text="الاسم الأول:" CssClass="labelStyle"></asp:Label>
                        </div>
                        <div>
                            <asp:TextBox ID="txtArFName" runat="server" CssClass="txtStyle" ></asp:TextBox>
                        </div>
                    </td>
                    <td>
                        <div>
                            <asp:Label ID="lblArMName" runat="server" Text="اسم الاب:" CssClass="labelStyle"></asp:Label>
                        </div>
                        <div>
                            <asp:TextBox ID="txtArMName" runat="server" CssClass="txtStyle" ></asp:TextBox>
                        </div>
                    </td>
                    <td>
                        <div>
                            <asp:Label ID="lblArTName" runat="server" Text="اسم الجد:" CssClass="labelStyle"></asp:Label>
                        </div>
                        <div>
                            <asp:TextBox ID="txtArTName" runat="server" CssClass="txtStyle" ></asp:TextBox>
                        </div>
                    </td>
                    <td>
                        <div>
                            <asp:Label ID="lblArLName" runat="server" Text="الاسم الأخير:" CssClass="labelStyle"></asp:Label>
                        </div>
                        <div>
                            <asp:TextBox ID="txtArLName" runat="server" CssClass="txtStyle" ></asp:TextBox>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td colspan="5">
                        <hr>
                    </td>
                </tr>
                <tr class="taH2r">
                    <td colspan="5" class="taH2">
                        <asp:Label ID="lblEnName" runat="server" Text="الاسم (انجليزي)" CssClass="labelStyleH2"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div>
                            <asp:Label ID="lblEnFName" runat="server" Text="الاسم الأول:" CssClass="labelStyle"></asp:Label>
                        </div>
                        <div>
                            <asp:TextBox ID="txtEnFName" runat="server" CssClass="txtStyle" ></asp:TextBox>
                        </div>
                    </td>
                    <td>
                        <div>
                            <asp:Label ID="lblEnMName" runat="server" Text="اسم الاب:" CssClass="labelStyle"></asp:Label>
                        </div>
                        <div>
                            <asp:TextBox ID="txtEnMName" runat="server" CssClass="txtStyle" ></asp:TextBox>
                        </div>
                    </td>
                    <td>
                        <div>
                            <asp:Label ID="lblEnTName" runat="server" Text="اسم الجد:" CssClass="labelStyle"></asp:Label>
                        </div>
                        <div>
                            <asp:TextBox ID="txtEnTName" runat="server" CssClass="txtStyle" ></asp:TextBox>
                        </div>
                    </td>
                    <td>
                        <div>
                            <asp:Label ID="lblEnLName" runat="server" Text="الاسم الأخير:" CssClass="labelStyle"></asp:Label>
                        </div>
                        <div>
                            <asp:TextBox ID="txtEnLName" runat="server" CssClass="txtStyle" ></asp:TextBox>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td colspan="5">
                        <hr>
                    </td>
                </tr>
                <tr class="taH2r">
                    <td colspan="5" class="taH2">
                        <asp:Label ID="lblEnter" runat="server" Text="معلومات الدخول" CssClass="labelStyleH2"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div>
                            <asp:Label ID="lblUser" runat="server" Text="اسم المستخدم:" CssClass="labelStyle"></asp:Label>
                        </div>
                        <div>
                            <asp:TextBox ID="txtUser" runat="server" CssClass="txtStyle" ></asp:TextBox>
                        </div>
                    </td>
                    <td>
                        <div>
                            <asp:Label ID="lblPass" runat="server" Text="كلمة المرور:" CssClass="labelStyle"></asp:Label>
                        </div>
                        <div>
                            <asp:TextBox ID="txtPass" runat="server" CssClass="txtStyle" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtPass"  ErrorMessage="The password field is required." ForeColor="Red" />
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Password must be 8-10 characters long with at least one numeric,</br>one upper case character and one special character." ControlToValidate="txtPass" ValidationExpression="(?=^.{8,10}$)(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&*()_+}{&quot;:;'?/>.<,])(?!.*\s).*$" ForeColor="Red"></asp:RegularExpressionValidator>
                        </div>
                    </td>
                    <td>
                        <div>
                            <asp:Label ID="lblCPass" runat="server" Text="تأكيد كلمة المرور:" CssClass="labelStyle"></asp:Label>
                        </div>
                        <div>
                            <asp:TextBox ID="txtCPass" runat="server" CssClass="txtStyle" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtCPass"  Display="Dynamic" ErrorMessage="The confirm password field is required." ForeColor="Red" />
                            <asp:CompareValidator runat="server" ControlToCompare="txtPass" ControlToValidate="txtCPass"  Display="Dynamic" ErrorMessage="The password and confirmation password do not match." ForeColor="Red" />
                        </div>
                    </td>
                    <td>
                        <div>
                            <asp:Label ID="lblRole" runat="server" Text="الوظيفة:" CssClass="labelStyle"></asp:Label>
                        </div>
                        <div>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlRole" runat="server" DataSourceID="SqlDataSource2" DataTextField="RoleAr" DataValueField="RID" OnSelectedIndexChanged="ddlRole_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                                    <asp:SqlDataSource runat="server" ID="SqlDataSource2" ConnectionString='<%$ ConnectionStrings:DefaultConnection %>' SelectCommand="SELECT [RoleAr], [RID] FROM [Roles]"></asp:SqlDataSource>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td colspan="5">
                        <hr>
                    </td>
                </tr>
                <tr class="taH2r">
                    <td colspan="5" class="taH2">
                        <asp:Label ID="lblExtra" runat="server" Text="معلومات اضافية" CssClass="labelStyleH2"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div>
                            <asp:Label ID="lblEmail" runat="server" Text="الايميل:" CssClass="labelStyle"></asp:Label>
                        </div>
                        <div>
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="txtStyle" TextMode="Email"></asp:TextBox>
                        </div>
                    </td>
                    <td>
                        <div>
                            <asp:Label ID="lblMobile" runat="server" Text="رقم الجوال:" CssClass="labelStyle"></asp:Label>
                        </div>
                        <div>
                            <asp:TextBox ID="txtMobile" runat="server" CssClass="txtStyle" TextMode="Number"></asp:TextBox>
                        </div>
                    </td>
                    <td>
                        <div>
                            <asp:Label ID="lblTel" runat="server" Text="رقم الهاتف:" CssClass="labelStyle"></asp:Label>
                        </div>
                        <div>
                            <asp:TextBox ID="txtTel" runat="server" CssClass="txtStyle" TextMode="Number"></asp:TextBox>
                        </div>
                    </td>
                    <td>
                        <table class="innerTable">
                            <tr>
                                <td>
                                    <div>
                                        <asp:Label ID="lblDisAmt" runat="server" Text="%الخصم:" CssClass="labelStyle"></asp:Label>
                                    </div>
                                    <div>
                                        <asp:TextBox ID="txtDisAmt" runat="server" CssClass="txtStyle" Width="50px" TextMode="Number"></asp:TextBox>
                                    </div>
                                </td>
                                <td>
                                    <div>
                                        <asp:Label ID="lblManager" runat="server" Text="المدير المباشر:" CssClass="labelStyle"></asp:Label>
                                    </div>
                                    <div>
                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlManager" runat="server" CssClass="ddliki"></asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div>
                            <asp:Label ID="lblEID" runat="server" Text="رقم الهوية:" CssClass="labelStyle"></asp:Label>
                        </div>
                        <div>
                            <asp:TextBox ID="txtEID" runat="server" CssClass="txtStyle" TextMode="Number"></asp:TextBox>
                        </div>
                    </td>
                    <td>
                        <asp:Label ID="lblDOB" runat="server" Text="تاريخ الميلاد:" CssClass="labelStyle"></asp:Label>
                        <div id="datetimepicker2" class="input-append date">
                            <asp:TextBox ID="txtDOB" runat="server" Width="178px"></asp:TextBox>
                            <span class="add-on" style="height: 28px">
                                <i data-time-icon="icon-time" data-date-icon="icon-calendar"></i>
                            </span>
                        </div>

                    </td>
                
                    <td>
                        <div>
                            <asp:Label ID="lblNationality" runat="server" Text="الجنسية:" CssClass="labelStyle"></asp:Label>
                        </div>
                        <div>
                            <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Always">
                                <ContentTemplate>
                                    <table class="innerTable">
                                        <tr>
                                            <td>
                                                <asp:TextBox Width="30px" ID="txtNationalityID" runat="server" CausesValidation="False" AutoPostBack="true" CssClass="txtStyle" OnTextChanged="txtNationalityID_TextChanged" TextMode="Number" ></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlNationalityName" runat="server" DataSourceID="SqlDataSource3" DataTextField="ArName" DataValueField="Id" Width="30px" OnSelectedIndexChanged="ddlNationalityName_SelectedIndexChanged" AutoPostBack="True" CausesValidation="True" AppendDataBoundItems="true">
                                                    <asp:ListItem Text="-- اختر جنسة --" Value="" />
                                                </asp:DropDownList>
                                                <asp:SqlDataSource runat="server" ID="SqlDataSource3" ConnectionString='<%$ ConnectionStrings:DefaultConnection %>' SelectCommand="SELECT [Id], [ArName] FROM [Countries]"></asp:SqlDataSource>
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </td>
                <td>
            </tr>
            </table>
            <div class="Grid">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="grdEmployees" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" CssClass="GridView" AllowPaging="True" PagerSettings-PageButtonCount="5" PageSize="6">
                            <Columns>
                                <asp:BoundField DataField="EmpID" HeaderText="EmpID" SortExpression="EmpID"></asp:BoundField>
                                <asp:BoundField DataField="ArName" HeaderText="ArName" ReadOnly="True" SortExpression="ArName"></asp:BoundField>
                                <asp:BoundField DataField="EnName" HeaderText="EnName" ReadOnly="True" SortExpression="EnName"></asp:BoundField>
                                <asp:BoundField DataField="Mobile" HeaderText="Mobile" SortExpression="Mobile"></asp:BoundField>
                                <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email"></asp:BoundField>
                                <asp:BoundField DataField="Profition" HeaderText="Profition" SortExpression="Profition"></asp:BoundField>
                                <asp:BoundField DataField="Manager" HeaderText="Manager" SortExpression="Manager"></asp:BoundField>
                                <asp:BoundField DataField="JoinDate" HeaderText="JoinDate" SortExpression="JoinDate"></asp:BoundField>
                            </Columns>
                        </asp:GridView>
                        <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:DefaultConnection %>' SelectCommand="SELECT [EmpID], ([ArFName]+' '+[ArMName]+' '+[ArTName]+' '+[ArLName]) as [ArName], ([FName]+' '+[MName]+' '+[TName]+' '+[LName]) as [EnName], [Mobile], [Email], [Profition], [Manager], convert(varchar(10), [JoinDate], 120) as JoinDate FROM [Employees]"></asp:SqlDataSource>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <br />
            <script type="text/javascript">
                var d = new Date(), s = new Date();
                d.setFullYear(d.getFullYear() - 20);
                s.setFullYear(d.getFullYear() - 100);
            $('#datetimepicker2').datetimepicker({
                pickTime: false,
                format: "dd / MM / yyyy",
                startDate:s,
                endDate: d,
                todayHighlight: true,
                defaultDate: d
            });
        </script>
            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                <contenttemplate>
                    <asp:Button ID="btnManageRole" runat="server" Text="ادارة العيادات" cssclass="buttons" />
                    
                </contenttemplate>
                
            </asp:UpdatePanel>
            <br><asp:Button ID="btnSave" runat="server" Text="حفظ" cssclass="buttons" OnClick="btnSave_Click" />
        </div>
    </div>
    
    
</asp:Content>
