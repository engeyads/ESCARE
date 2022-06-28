<%@ Page Title="المخازن" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ClinStore.aspx.cs" Inherits="ESCARE.ClinStore" %>

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
                                <asp:Button ID="btnStore" runat="server" Text="المخازن" cssclass="buttons" OnClick="btnStore_Click" />
                                <asp:Button ID="btnServices" runat="server" Text="الخدمات" cssclass="buttons" OnClick="btnServices_Click" />
                                <asp:Button ID="btnClinEmp" runat="server" Text="ربط موظف بعيادة" cssclass="buttons" OnClick="btnClinEmp_Click" />
                            </contenttemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="btnClinics" />
                                <asp:AsyncPostBackTrigger ControlID="btnStore" />
                                <asp:AsyncPostBackTrigger ControlID="btnServices" />
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
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                            <div>
                                                <asp:TextBox ID="txtClin" Width="40px" runat="server" CssClass="txtStyle" OnTextChanged="txtClin_TextChanged" AutoPostBack="True"></asp:TextBox>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                                <td>
                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                        <ContentTemplate>
                                            <div>
                                                <asp:DropDownList ID="ddlClin" runat="server" DataSourceID="SqlDataSource2" DataTextField="ArName" DataValueField="CLID" OnSelectedIndexChanged="ddlClin_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                                                <asp:SqlDataSource runat="server" ID="SqlDataSource2" ConnectionString='<%$ ConnectionStrings:DefaultConnection %>' SelectCommand="SELECT [CLID], [ArName] FROM [UClinic]"></asp:SqlDataSource>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>

                            </tr>
                            <tr>
                                <td>
                                    <div>
                                        <asp:Label ID="lblStore" runat="server" Text="كود المخزن:" CssClass="labelStyle"></asp:Label>
                                    </div>
                                </td>
                            </tr>
                            <tr>

                                <td>
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>
                                            <div>
                                                <asp:TextBox ID="txtStore" Width="40px" runat="server" CssClass="txtStyle" OnTextChanged="txtStore_TextChanged" AutoPostBack="True"></asp:TextBox>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                                <td>
                                    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                        <ContentTemplate>
                                            <div>
                                                <asp:DropDownList ID="ddlStore" runat="server" DataSourceID="SqlDataSource4" DataTextField="ArName" DataValueField="STID" OnSelectedIndexChanged="ddlStore_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                                                <asp:SqlDataSource runat="server" ID="SqlDataSource4" ConnectionString='<%$ ConnectionStrings:DefaultConnection %>' SelectCommand="SELECT [STID], [ArName] FROM [Store]"></asp:SqlDataSource>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
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
                        <asp:GridView ID="grdClinStore" runat="server" DataKeyNames="STID,CLID" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" CssClass="GridView" AllowPaging="True" PagerSettings-PageButtonCount="5" PageSize="6" PageIndex="0">
                            <Columns>
                                <asp:BoundField DataField="STID" HeaderText="كود المخزن" SortExpression="STID" ReadOnly="true"></asp:BoundField>
                                <asp:BoundField DataField="SArName" HeaderText="اسم المخزن - عربي" SortExpression="SArName" ReadOnly="true"></asp:BoundField>
                                <asp:BoundField DataField="SEnName" HeaderText="اسم المخزن - انجليزي" SortExpression="SEnName" ReadOnly="true"></asp:BoundField>
                                <asp:BoundField DataField="CLID" HeaderText="كود العيادة" SortExpression="CLID" ReadOnly="true"></asp:BoundField>
                                <asp:BoundField DataField="CArName" HeaderText="اسم العيادة - عربي" SortExpression="CArName" ReadOnly="true"></asp:BoundField>
                                <asp:BoundField DataField="CEnName" HeaderText="اسم العيادة - انجليزي" SortExpression="CEnName" ReadOnly="true"></asp:BoundField>

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
                <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:DefaultConnection %>' SelectCommand="SELECT [store].[STID], [store].[ArName] as [SArName], [store].[EnName] as [SEnName], [UClinic].[CLID], [UClinic].[ArName] as [CArName], [UClinic].[EnName] as [CEnName] FROM [Store],[UClinic] WHERE [store].[STID]=[UClinic].[STID]" DeleteCommand="spREMOVE_StoreUClinic" DeleteCommandType="StoredProcedure">
                    <DeleteParameters>
                        <asp:Parameter Name="STID" Type="String"></asp:Parameter>
                        <asp:Parameter Name="CLID" Type="String"></asp:Parameter>
                    </DeleteParameters>
                </asp:SqlDataSource>
            </div>
            <br />
            
            
            
        </div>
    </div>
    

</asp:Content>
