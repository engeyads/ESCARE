<%@ Page Title="Create New Receipt" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ServiceKind.aspx.cs" Inherits="ESCARE.ServiceKind" %>

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
                        <asp:Label ID="lblService" runat="server" Text="الخدمة" CssClass="labelStyleH2"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table class="innerTable">
                            <tr>
                                <td>
                                    <div>
                                        <asp:Label ID="lblClin" runat="server" Text="كود العيادة:" CssClass="labelStyle"></asp:Label>
                                    </div>
                                </td>
                            </tr>
                            <tr>

                                <td>
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>
                                            <div>
                                                <asp:TextBox ID="txtClin" Width="40px" runat="server" CssClass="txtStyle" OnTextChanged="txtClin_TextChanged" AutoPostBack="True"></asp:TextBox>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                                <td>
                                    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                        <ContentTemplate>
                                            <div>
                                                <asp:DropDownList ID="ddlClin" runat="server" DataSourceID="SqlDataSource4" DataTextField="ArName" DataValueField="ClID" OnSelectedIndexChanged="ddlClin_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                                                <asp:SqlDataSource runat="server" ID="SqlDataSource4" ConnectionString='<%$ ConnectionStrings:DefaultConnection %>' SelectCommand="SELECT [ClID], [ArName] FROM [UClinic]"></asp:SqlDataSource>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>

                            </tr>
                        </table>
                    </td>
                    <td>
                        <div>
                            <asp:Label ID="lblSID" runat="server" Text="كود الخدمة:" CssClass="labelStyle"></asp:Label>
                        </div>
                        <div>
                            <asp:TextBox ID="txtSID" runat="server" CssClass="txtStyle" ></asp:TextBox>
                        </div>
                    </td>
                    <td>
                        <div>
                            <asp:Label ID="lblSEnName" runat="server" Text="اسم الخدمة - انجليزي:" CssClass="labelStyle"></asp:Label>
                        </div>
                        <div>
                            <asp:TextBox ID="txtSEnName" runat="server" CssClass="txtStyle" ></asp:TextBox>
                        </div>
                    </td>
                    <td>
                        <div>
                            <asp:Label ID="lblSArName" runat="server" Text="اسم الخدمة - عربي:" CssClass="labelStyle"></asp:Label>
                        </div>
                        <div>
                            <asp:TextBox ID="txtSArName" runat="server" CssClass="txtStyle" ></asp:TextBox>
                        </div>
                    </td>
                </tr>
                
                <tr>
                    <td>
                        <div>
                            <asp:Label ID="lblSPrice" runat="server" Text="قيمة الخدمة:" CssClass="labelStyle"></asp:Label>
                        </div>
                        <div>
                            <asp:TextBox ID="txtSPrice" runat="server" CssClass="txtStyle" ></asp:TextBox>
                        </div>
                    </td>
                    <td>
                        <div>
                            <asp:Label ID="lblOPrice" runat="server" Text="تكلفة الخدمة:" CssClass="labelStyle"></asp:Label>
                        </div>
                        <div>
                            <asp:TextBox ID="txtOPrice" runat="server" CssClass="txtStyle" ></asp:TextBox>
                        </div>
                    </td>
                    <td>
                        <table class="innerTable">
                            <tr>
                                <td>
                                    <div>
                                        <asp:Label ID="lblKind" runat="server" Text="نوع الخدمة:" CssClass="labelStyle"></asp:Label>
                                    </div>
                                </td>
                            </tr>
                            <tr>

                                <td>
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                            <div>

                                                <asp:TextBox ID="txtKind" Width="40px" runat="server" CssClass="txtStyle" OnTextChanged="txtKind_TextChanged" AutoPostBack="True"></asp:TextBox>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                                <td>
                                <td>
                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                        <ContentTemplate>
                                            <div>
                                                <asp:DropDownList ID="ddlKind" runat="server" DataSourceID="SqlDataSource2" DataTextField="ArName" DataValueField="KID" OnSelectedIndexChanged="ddlKind_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                                                <asp:SqlDataSource runat="server" ID="SqlDataSource2" ConnectionString='<%$ ConnectionStrings:DefaultConnection %>' SelectCommand="SELECT [KID], [ArName] FROM [ServiceKind]"></asp:SqlDataSource>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>

                            </tr>
                        </table>
                    </td>
                    <td>
                        <table>
                            <tr>
                                <td>
                                    <div>
                                        <asp:CheckBox ID="chkVAT" runat="server" Text="خاضع للضريبة" />
                                    </div>
                                </td>
                                <td>
                                    <div>
                                        <asp:CheckBox ID="chk" runat="server" Text="تفعيل الخدمة" />
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <br>
            <asp:Button ID="btnSave" runat="server" Text="حفظ" CssClass="buttons" OnClick="btnSave_Click" />
            <div class="Grid">
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="grdServices" runat="server" DataKeyNames="SID,KID,CLID" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" CssClass="GridView" AllowPaging="True" PageSize="6" PageIndex="0">
                            <Columns>
                                <asp:BoundField DataField="SID" HeaderText="كـ . الخدمة" SortExpression="SID"></asp:BoundField>
                                <asp:BoundField DataField="SName" HeaderText="اسم الخدمة - انجليزي" SortExpression="SName"></asp:BoundField>
                                <asp:BoundField DataField="SArName" HeaderText="اسم الخدمة - عربي" SortExpression="SArName"></asp:BoundField>
                                <asp:BoundField DataField="KID" HeaderText="كـ . النوع" SortExpression="KID"></asp:BoundField>
                                <asp:BoundField DataField="KArName" HeaderText="نوع الخدمة" SortExpression="KArName"></asp:BoundField>
                                <asp:BoundField DataField="Price" HeaderText="سعر الخدمة" SortExpression="Price"></asp:BoundField>
                                <asp:BoundField DataField="VatApplyed" HeaderText="الضريبة" SortExpression="VatApplyed"></asp:BoundField>
                                <asp:BoundField DataField="ClID" HeaderText="كـ . العيادة" SortExpression="ClID"></asp:BoundField>
                                <asp:BoundField DataField="CArName" HeaderText="العيادة" SortExpression="CArName"></asp:BoundField>

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
                <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:DefaultConnection %>' SelectCommand="SELECT [SID], [SName], [SArName], [KID], [KArName], [Price], [VatApplyed], [ClID], [CArName] FROM [Service]" UpdateCommand="spUPDATE_Services" UpdateCommandType="StoredProcedure" DeleteCommand="spDELETE_Services" DeleteCommandType="StoredProcedure">

                    <DeleteParameters>
                        <asp:Parameter Name="SID" Type="String"></asp:Parameter>
                        <asp:Parameter Name="KID" Type="String"></asp:Parameter>
                        <asp:Parameter Name="ClID" Type="String"></asp:Parameter>
                    </DeleteParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="SID" Type="String"></asp:Parameter>
                        <asp:Parameter Name="SName" Type="String"></asp:Parameter>
                        <asp:Parameter Name="SArName" Type="String"></asp:Parameter>
                        <asp:Parameter Name="KID" Type="String"></asp:Parameter>
                        <asp:Parameter Name="KArName" Type="String"></asp:Parameter>
                        <asp:Parameter Name="Price" Type="Double"></asp:Parameter>
                        <asp:Parameter Name="VatApplyed" Type="Int32"></asp:Parameter>
                        <asp:Parameter Name="ClID" Type="String"></asp:Parameter>
                        <asp:Parameter Name="CArName" Type="String"></asp:Parameter>
                    </UpdateParameters>
                </asp:SqlDataSource>
            </div>
            <br />
            
            
            
        </div>
    </div>
    

</asp:Content>
