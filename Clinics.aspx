<%@ Page Title="العيادات" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Clinics.aspx.cs" Inherits="ESCARE.Clinics" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Page CSS -->
    <link href="CSS/Clinics.css" rel="stylesheet" />
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
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                            <contenttemplate>
                                <asp:Button ID="btnServices" runat="server" Text="الخدمات" cssclass="buttons" OnClick="btnServices_Click" />
                                <asp:Button ID="btnEmployees" runat="server" Text="الموظفين" cssclass="buttons" OnClick="btnEmployees_Click" />
                                <asp:Button ID="btnKinds" runat="server" Text="انواع الخدمات" cssclass="buttons" OnClick="btnKinds_Click" />
                                <asp:Button ID="btnClinEmp" runat="server" Text="ربط طبيب بعيادة" cssclass="buttons" OnClick="btnClinEmp_Click" />
                            </contenttemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="btnServices" />
                                <asp:AsyncPostBackTrigger ControlID="btnEmployees" />
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
                        <asp:Label ID="lblService" runat="server" Text="العيادة" CssClass="labelStyleH2"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table class="innerTable">
                            <tr>
                                <td>
                                    <div>
                                        <asp:Label ID="lblClinID" runat="server" Text="كود:" CssClass="labelStyle"></asp:Label>
                                    </div>
                                </td>
                                <td>
                                    <div>
                                        <asp:Label ID="lblClinName" runat="server" Text="اسم العيادة - عربي:" CssClass="labelStyle"></asp:Label>
                                    </div>
                                </td>
                            </tr>
                            <tr>

                                <td>
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>
                                            <div>
                                                <asp:TextBox ID="txtClinID" Width="40px" runat="server" CssClass="txtStyle" OnTextChanged="txtClinID_TextChanged" AutoPostBack="True"></asp:TextBox>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                                <td>
                                    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                        <ContentTemplate>
                                            <div>
                                                <asp:TextBox ID="txtClinName" runat="server" OnTextChanged="txtClinName_TextChanged" AutoPostBack="True"></asp:TextBox>
                                                
                                                <asp:SqlDataSource runat="server" ID="SqlDataSource4" ConnectionString='<%$ ConnectionStrings:DefaultConnection %>' SelectCommand="SELECT [ClID], [ArName] FROM [UClinic]"></asp:SqlDataSource>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td>
                        
                    </td>
                    <td>
                        
                    </td>
                    <td>
                        <div>
                            <asp:Label ID="lblClinEnName" runat="server" Text="اسم العيادة - انجليزي:" CssClass="labelStyle"></asp:Label>
                        </div>
                        <div>
                            <asp:TextBox ID="txtClinEnName" runat="server" CssClass="txtStyle" ></asp:TextBox>
                        </div>
                    </td>
                    <td>
                        <div>
                            <asp:Label ID="lblDesc" runat="server" Text="الوصف:" CssClass="labelStyle"></asp:Label>
                        </div>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <div>
                                    <asp:TextBox ID="txtDesc" runat="server" AutoPostBack="True"></asp:TextBox>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td>
                        <div class="Checks">
                            <asp:CheckBox ID="chk" runat="server" Text="تفعيل العيادة" />
                        </div>
                    </td>
                </tr>
                
                
            </table>
            <br>
            <asp:Button ID="btnSave" runat="server" Text="حفظ" CssClass="buttons" OnClick="btnSave_Click" />
            <div class="Grid">
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="grdServices" runat="server" DataKeyNames="ClID" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" CssClass="GridView" AllowPaging="True" PageSize="6">
                            <Columns>
                                <asp:BoundField DataField="ClID" HeaderText="الكود" SortExpression="ClID" ReadOnly="True"></asp:BoundField>
                                <asp:BoundField DataField="ArName" HeaderText="اسم العيادة - عربي" SortExpression="ArName"></asp:BoundField>
                                <asp:BoundField DataField="EnName" HeaderText="اسم العيادة - انجليزي" SortExpression="EnName"></asp:BoundField>
                                <asp:BoundField DataField="Description" HeaderText="الوصف" SortExpression="Description"></asp:BoundField>
                                <asp:TemplateField HeaderText="مفعلة">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="Available" DataField="Available" runat="server" Checked='<%# Eval("Available").Equals(1) %>' onclick="return false;" />
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <%--<asp:CheckBox ID="Available" DataField="Available" runat="server" Checked='<%# DataBinder.Eval(Container.DataItem,"Available").ToString() == "1" %>' Text=<%# DataBinder.Eval(Container.DataItem,"Available").ToString() == "1" ? "1" : "0" %> ></asp:CheckBox>--%>
                                        <asp:TextBox ID="Av" DataField="Available" runat="server" Text='<%# Bind("Available") %>' />
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="EditBtn" CommandName="Edit" runat="server"
                                            ImageUrl="~/icons/edit.png" ToolTip="Edit" Height="20px" Width="20px" />
                                    </ItemTemplate>


                                    <EditItemTemplate>
                                        <asp:ImageButton ID="UpdateBtn" CommandName="Update" runat="server"
                                            ImageUrl="~/icons/T.png" ToolTip="Save" Height="20px" Width="20px"  />
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
                <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:DefaultConnection %>' SelectCommand="SELECT [ClID], [ArName], [EnName], [Description], [Available] FROM [UClinic]" DeleteCommand="DELETE FROM [UClinic] WHERE [ClID]=@ClID" UpdateCommand="UPDATE [UClinic] SET [ArName]=@ArName, [EnName]=@EnName, [Description]=@Description, [Available]=@Available WHERE [ClID]=@ClID">
                    <DeleteParameters>
                        <asp:Parameter Name="ClID"></asp:Parameter>
                    </DeleteParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="ArName"></asp:Parameter>
                        <asp:Parameter Name="EnName"></asp:Parameter>
                        <asp:Parameter Name="Description"></asp:Parameter>
                        <asp:Parameter Name="ClID"></asp:Parameter>
                        <asp:Parameter Name="Available"></asp:Parameter>
                    </UpdateParameters>
                </asp:SqlDataSource>
            </div>
            <br />
            
            
        </div>
    </div>
    

</asp:Content>
