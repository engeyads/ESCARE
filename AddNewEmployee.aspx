<%@ Page Title="الموظفين" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddNewEmployee.aspx.cs" Inherits="ESCARE.AddNewEmployee" %>

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
            <table>
                <tr>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                            <contenttemplate>
                                <asp:Button ID="btnServices" runat="server" Text="الخدمات" cssclass="buttons" OnClick="btnServices_Click" />
                                <asp:Button ID="btnClinics" runat="server" Text="العيادات" cssclass="buttons" OnClick="btnClinics_Click" />
                                <asp:Button ID="btnKinds" runat="server" Text="انواع الخدمات" cssclass="buttons" OnClick="btnKinds_Click" />
                                <asp:Button ID="btnClinEmp" runat="server" Text="ربط طبيب بعيادة" cssclass="buttons" OnClick="btnClinEmp_Click" />
                            </contenttemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="btnServices" />
                                <asp:AsyncPostBackTrigger ControlID="btnClinics" />
                                <asp:AsyncPostBackTrigger ControlID="btnKinds" />
                                <asp:AsyncPostBackTrigger ControlID="btnClinEmp" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
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
                        </div>
                        
                    </td>
                    <td>
                        <div>
                            <asp:Label ID="lblCPass" runat="server" Text="تأكيد كلمة المرور:" CssClass="labelStyle"></asp:Label>
                        </div>
                        <div>
                            <asp:TextBox ID="txtCPass" runat="server" CssClass="txtStyle" TextMode="Password"></asp:TextBox>
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
                            <asp:TextBox ID="txtEID" runat="server" CssClass="txtStyle" TextMode="Number" ></asp:TextBox>
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
                <tr>
                    <td>
                        <asp:Button ID="btnSave" runat="server" Text="حفظ" CssClass="buttons" OnClick="btnSave_Click" />
                    </td>
                </tr>
            </table>
            <asp:Label ID="lblmsg" runat="server" Text=""></asp:Label>
            <%--<asp:RequiredFieldValidator runat="server" ControlToValidate="txtPass"  ErrorMessage="يجب ادخال كلمة مرور!" ForeColor="Red" />
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="يجب ان تتكون كلمة المرور من 8-10 احرف تحوي على الاقل رقم و حرف كبير و علامة!" ControlToValidate="txtPass" ValidationExpression="(?=^.{8,10}$)(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&*()_+}{&quot;:;'?/>.<,])(?!.*\s).*$" ForeColor="Red"></asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtCPass"  Display="Dynamic" ErrorMessage="يجب ادخال كلمة المرور التأكيدية!" ForeColor="Red" />
            <asp:CompareValidator runat="server" ControlToCompare="txtPass" ControlToValidate="txtCPass"  Display="Dynamic" ErrorMessage="كلمة المرور لا تتطابق مع كلمة المرور التأكيدية!" ForeColor="Red" />--%>
            <div class="Grid">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="grdEmployees" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" CssClass="GridView" AllowPaging="True" PagerSettings-PageButtonCount="5" PageSize="6" DataKeyNames="EmpID" AllowCustomPaging="False">
                            <Columns>
                                
                                <asp:BoundField DataField="EmpID" HeaderText="الرقم الوظيفي" ReadOnly="True" SortExpression="EmpID"></asp:BoundField>
                                

                                <asp:TemplateField HeaderText="الاسم - عربي" SortExpression="ArFName">
                                    <EditItemTemplate>
                                        <asp:TextBox DataField="ArFName" ID="ArFName" runat="server" Text='<%# Bind("ArFName") %>'></asp:TextBox>
                                        <asp:TextBox DataField="ArMName" ID="ArMName" runat="server" Text='<%# Bind("ArMName") %>'></asp:TextBox>
                                        <asp:TextBox DataField="ArTName" ID="ArTName" runat="server" Text='<%# Bind("ArTName") %>'></asp:TextBox>
                                        <asp:TextBox DataField="ArLName" ID="ArLName" runat="server" Text='<%# Bind("ArLName") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="ArFName" runat="server" Text='<%# Eval("ArFName")+" "+Eval("ArMName")+" "+Eval("ArTName")+" "+Eval("ArLName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="الاسم - انجليزي" SortExpression="ArFName">
                                    <EditItemTemplate>
                                        <div style="display:inline-block">
                                            <asp:TextBox DataField="LName" ID="LName" runat="server" Text='<%# Bind("LName") %>'></asp:TextBox>
                                            <asp:TextBox DataField="TName" ID="TName" runat="server" Text='<%# Bind("TName") %>'></asp:TextBox>
                                            <asp:TextBox DataField="MName" ID="MName" runat="server" Text='<%# Bind("MName") %>'></asp:TextBox>
                                            <asp:TextBox DataField="FName" ID="FName" runat="server" Text='<%# Bind("FName") %>'></asp:TextBox>
                                        </div>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="FName" runat="server" Text='<%# Eval("FName")+" "+Eval("MName")+" "+Eval("TName")+" "+Eval("LName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Mobile" HeaderText="الجوال" SortExpression="Mobile"></asp:BoundField>
                                <asp:BoundField DataField="Tel" HeaderText="التلفون" SortExpression="Tel"></asp:BoundField>
                                <asp:TemplateField HeaderText="البريد" SortExpression="email">
                                    <EditItemTemplate>
                                        <asp:TextBox DataField="email" ID="email" runat="server" Text='<%# Bind("email") %>' TextMode="Email"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="email" DataField="email" runat="server" Text='<%# Bind("email") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="العمل" SortExpression="RID">
                                    <EditItemTemplate>
                                        <asp:TextBox DataField="Profition" ID="RID" runat="server" Text='<%# Bind("RID") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Profition" DataField="Profition" runat="server" Text='<%# Bind("Profition") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="الخصم" SortExpression="Discount">
                                    <EditItemTemplate>
                                        <asp:TextBox DataField="Discount" ID="Discount" runat="server" Text='<%# Bind("Discount") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Discount" DataField="Discount" runat="server" Text='<%# Eval("Discount")+" %" %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Manager" HeaderText="المدير" SortExpression="Manager"></asp:BoundField>
                                <asp:TemplateField HeaderText="الميلاد" SortExpression="DOB">
                                    <EditItemTemplate>
                                        <asp:TextBox DataField="DOB" ID="DOB" runat="server" Text='<%# Bind("DOB") %>' TextMode="Date"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lbDOB" runat="server" Text='<%# Eval("DOB") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="التسجيل" SortExpression="JoinDate">
                                    <ItemTemplate>
                                        <asp:Label ID="lbJoinDate" runat="server" Text='<%# Eval("JoinDate") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="EID" HeaderText="الهوية" SortExpression="EID"></asp:BoundField>
                                <asp:TemplateField HeaderText="الجنسية" SortExpression="Nationality">
                                    <EditItemTemplate>
                                        <asp:TextBox DataField="Nationality" ID="NID" runat="server" Text='<%# Bind("NID") %>' ></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Nationality" DataField="Nationality" runat="server" Text='<%# Bind("Nationality") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="مفعل" SortExpression="DOB">
                                    <EditItemTemplate>
                                        <asp:TextBox DataField="Available" ID="Available" runat="server" Text='<%# Bind("Available") %>' ></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="Available" DataField="Available" runat="server" Checked='<%# Eval("Available").Equals(1) %>' onclick="return false;" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="EditBtn" CommandName="Edit" runat="server"
                                            ImageUrl="~/icons/edit.png" ToolTip="Edit" Height="20px" Width="20px" />
                                    </ItemTemplate>


                                    <EditItemTemplate>
                                        <asp:ImageButton ID="UpdateBtn" CommandName="Update" runat="server"
                                            ImageUrl="~/icons/T.png" ToolTip="Save" Height="20px" Width="20px" />
                                        <asp:ImageButton ID="CancelBtn" CommandName="Cancel" runat="server"
                                            ImageUrl="~/icons/x.png" ToolTip="Cancel" Height="20px" Width="20px" />
                                    </EditItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="DelBtn" CommandName="Delete" runat="server"
                                            ImageUrl="~/icons/del.png" ToolTip="Delete" Height="20px" Width="20px" OnClientClick="return confirm('Do you want to delete this row?');" />
                                    </ItemTemplate>
                                </asp:TemplateField>

                            </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:DefaultConnection %>' SelectCommand="SELECT [Employees].[EmpID], [Employees].[ArFName], [Employees].[ArMName], [Employees].[ArTName], [Employees].[ArLNAme], [Employees].[FName], [Employees].[MName], [Employees].[TName], [Employees].[LName], [Employees].[Mobile], [Employees].[Tel], [Employees].[email], [Roles].[RoleAr] as [Profition], [Employees].[Profition] as [RID] , [Employees].[Discount], [Employees].[Manager], convert(varchar(10), [Employees].[DOB], 120) as [DOB], convert(varchar(10), [Employees].[JoinDate], 120) as [JoinDate], [Employees].[EID], [Countries].[ArName] as [Nationality], [Employees].[Nationality] as [NID], [Employees].[Available], [Employees].[Address] FROM [Employees],[Countries],[Roles] WHERE [Countries].[ID]=[Employees].[Nationality] AND [Employees].[Profition]=[Roles].[RID]" DeleteCommand="spDELETE_Employees" DeleteCommandType="StoredProcedure" UpdateCommand="spUPDATE_Employees" UpdateCommandType="StoredProcedure">
                    <DeleteParameters>
                        <asp:Parameter Name="EmpID" Type="String"></asp:Parameter>
                    </DeleteParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="EmpID" Type="String"></asp:Parameter>
                        <asp:Parameter Name="EID" Type="String"></asp:Parameter>
                        <asp:Parameter Name="FName" Type="String"></asp:Parameter>
                        <asp:Parameter Name="MName" Type="String"></asp:Parameter>
                        <asp:Parameter Name="TName" Type="String"></asp:Parameter>
                        <asp:Parameter Name="LName" Type="String"></asp:Parameter>
                        <asp:Parameter Name="ArFName" Type="String"></asp:Parameter>
                        <asp:Parameter Name="ArMName" Type="String"></asp:Parameter>
                        <asp:Parameter Name="ArTName" Type="String"></asp:Parameter>
                        <asp:Parameter Name="ArLName" Type="String"></asp:Parameter>
                        <asp:Parameter Name="Mobile" Type="String"></asp:Parameter>
                        <asp:Parameter Name="Tel" Type="String"></asp:Parameter>
                        <asp:Parameter Name="Email" Type="String"></asp:Parameter>
                        <asp:Parameter Name="RID" Type="String"></asp:Parameter>
                        <asp:Parameter Name="Discount" Type="Double"></asp:Parameter>
                        <asp:Parameter Name="Manager" Type="String"></asp:Parameter>
                        <asp:Parameter Name="DOB" Type="String"></asp:Parameter>
                        <asp:Parameter Name="NID" Type="Int32"></asp:Parameter>
                        <asp:Parameter Name="Available" Type="Int32"></asp:Parameter>
                    </UpdateParameters>
                </asp:SqlDataSource>
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
            $('#datetimepicker4').datetimepicker({
                pickTime: false,
                format: "dd / MM / yyyy",
                startDate:s,
                endDate: d,
                todayHighlight: true,
                defaultDate: d
            });
        </script>
            
            
        </div>
    </div>
    

</asp:Content>
