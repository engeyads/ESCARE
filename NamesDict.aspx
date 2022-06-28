<%@ Page Title="قاموس الاسماء" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NamesDict.aspx.cs" Inherits="ESCARE.NamesDict" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Page CSS -->
    <link href="CSS/Services.css" rel="stylesheet" />
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
                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                            <contenttemplate>
                                <asp:Button ID="btnClinics" runat="server" Text="العيادات" cssclass="buttons" OnClick="btnClinics_Click" />
                                <asp:Button ID="btnEmployees" runat="server" Text="الموظفين" cssclass="buttons" OnClick="btnEmployees_Click" />
                                <asp:Button ID="btnKinds" runat="server" Text="انواع الخدمات" cssclass="buttons" OnClick="btnKinds_Click" />
                                <asp:Button ID="btnClinEmp" runat="server" Text="ربط موظف بعيادة" cssclass="buttons" OnClick="btnClinEmp_Click" />
                            </contenttemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="btnClinics" />
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
                        <asp:Label ID="lblStoreHead" runat="server" Text="المخازن" CssClass="labelStyleH2"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div>
                            <asp:Label ID="lblArName" runat="server" Text="الاسم - (عربي):" CssClass="labelStyle"></asp:Label>
                        </div>
                        <div>
                            <asp:TextBox ID="txtArName" runat="server" CssClass="txtStyle" ></asp:TextBox>
                        </div>
                    </td>
                    <td>
                        <div>
                            <asp:Label ID="lblEnName" runat="server" Text="الاسم - (انجليزي):" CssClass="labelStyle"></asp:Label>
                        </div>
                        <div>
                            <asp:TextBox ID="txtEnName" runat="server" CssClass="txtStyle" ></asp:TextBox>
                        </div>
                    </td>
                </tr>
            </table>
            <br>
            <asp:Button ID="btnSave" runat="server" Text="حفظ" CssClass="buttons" OnClick="btnSave_Click" />
            <div class="Grid">
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="grdStores" runat="server" DataKeyNames="ArName,EnName" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" CssClass="GridView" AllowPaging="True" PagerSettings-PageButtonCount="5" PageSize="6" PageIndex="0">
                            <Columns>
                                <asp:BoundField DataField="ArName" HeaderText="الاسم - (عربي)" SortExpression="ArName" ReadOnly="true"></asp:BoundField>
                                <asp:BoundField DataField="EnName" HeaderText="الاسم - (انجليزي)" SortExpression="EnName"></asp:BoundField>
                                
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
                <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:DefaultConnection %>' SelectCommand="SELECT ArName,EnName FROM NameDic" UpdateCommand="spUPDATE_dbo_NameDic" UpdateCommandType="StoredProcedure" DeleteCommand="spDELETE_dbo_NameDic" DeleteCommandType="StoredProcedure">

                    <DeleteParameters>
                        <asp:Parameter Name="ArName" Type="String"></asp:Parameter>
                    </DeleteParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="ArName" Type="String"></asp:Parameter>
                        <asp:Parameter Name="EnName" Type="String"></asp:Parameter>
                    </UpdateParameters>
                </asp:SqlDataSource>
            </div>
            <br />
            
            
            
        </div>
    </div>
    

</asp:Content>
