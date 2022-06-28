<%@ Page Title="ربط طبيب بعيادة" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ClinicDoctor.aspx.cs" Inherits="ESCARE.ClinicDoctor" %>

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
            
            <table>
                <tr>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                            <contenttemplate>
                                <asp:Button ID="btnClinics" runat="server" Text="العيادات" cssclass="buttons" OnClick="btnClinics_Click" />
                                <asp:Button ID="btnEmployees" runat="server" Text="الموظفين" cssclass="buttons" OnClick="btnEmployees_Click" />
                                <asp:Button ID="btnKinds" runat="server" Text="انواع الخدمات" cssclass="buttons" OnClick="btnKinds_Click" />
                                <asp:Button ID="btnServices" runat="server" Text="الخدمات" cssclass="buttons" OnClick="btnServices_Click" />
                            </contenttemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="btnClinics" />
                                <asp:AsyncPostBackTrigger ControlID="btnEmployees" />
                                <asp:AsyncPostBackTrigger ControlID="btnKinds" />
                                <asp:AsyncPostBackTrigger ControlID="btnServices" />
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
                        <asp:Label ID="lblService" runat="server" Text="ربط طبيب بعيادة" CssClass="labelStyleH2"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table class="innerTable">
                            <tr>
                                <td colspan="2">
                                    <div>
                                        <asp:Label ID="lblClin" runat="server" Text="العيادة:" CssClass="labelStyle"></asp:Label>
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
                        <table class="innerTable">
                            <tr>
                                <td colspan="2">
                                    <div>
                                        <asp:Label ID="lblDoc" runat="server" Text="الطبيب:" CssClass="labelStyle"></asp:Label>
                                    </div>
                                </td>
                            </tr>
                            <tr>

                                <td>
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                            <div>
                                                <asp:TextBox ID="txtDoc" Width="50px" runat="server" CssClass="txtStyle" OnTextChanged="txtDoc_TextChanged" AutoPostBack="True"></asp:TextBox>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                                <td>
                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                        <ContentTemplate>
                                            <div>
                                                <asp:DropDownList ID="ddlDoc" runat="server" DataSourceID="SqlDataSource2" DataTextField="ArName" DataValueField="EmpID" OnSelectedIndexChanged="ddlDoc_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                                                <asp:SqlDataSource runat="server" ID="SqlDataSource2" ConnectionString='<%$ ConnectionStrings:DefaultConnection %>' SelectCommand="SELECT [EmpID], ([ArFName]+' '+[ArMName]+' '+[ArTName]+' '+[ArLName]) as [ArName] FROM [Employees] WHERE [Profition]='03'"></asp:SqlDataSource>
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
           
            <div class="Grid">
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <div>
                            <asp:Label ID="lblmsg" runat="server" Text=""></asp:Label>
                        </div>
                        <div>
                            <asp:Button ID="btnSave" runat="server" Text="حفظ" CssClass="buttons" OnClick="btnSave_Click" />
                        </div>
                        <asp:GridView ID="grdServices" runat="server" DataKeyNames="ClID,DID" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" CssClass="GridView" AllowPaging="True" PageSize="6">
                            <Columns>
                                <asp:BoundField DataField="ClID" HeaderText="ClID" ReadOnly="True" SortExpression="ClID"></asp:BoundField>
                                <asp:BoundField DataField="ArName" HeaderText="ArName" ReadOnly="True" SortExpression="ArName"></asp:BoundField>
                                <asp:BoundField DataField="EnName" HeaderText="EnName" ReadOnly="True" SortExpression="EnName"></asp:BoundField>

                                <asp:TemplateField HeaderText="Name"
                                    SortExpression="FirstName">

                                    <EditItemTemplate>
                                        <asp:TextBox  ID="DID" runat="server" DataField="DID" Text='<%# Bind("DID") %>' ></asp:TextBox>
                                        <asp:DropDownList ID="ddlDID" runat="server" DataSourceID="SqlDataSource3" DataTextField="ArName" DataValueField="EmpID" ></asp:DropDownList>

                                        <asp:SqlDataSource runat="server" ID="SqlDataSource3" ConnectionString='<%$ ConnectionStrings:DefaultConnection %>' SelectCommand="SELECT EmpID,(ArFName+' '+ArMName+' '+ArLName) as ArName FROM Employees WHERE Profition='03' OR Profition='04'"></asp:SqlDataSource>
                                    </EditItemTemplate>

                                    <ItemTemplate>
                                        <asp:Label ID="DID" runat="server" Text='<%# Bind("DID") %>'></asp:Label>
                                    </ItemTemplate>

                                </asp:TemplateField>

                                <asp:BoundField DataField="EArName" HeaderText="EArName" ReadOnly="True" SortExpression="EArName"></asp:BoundField>
                                <asp:BoundField DataField="EEnName" HeaderText="EEnName" ReadOnly="True" SortExpression="EEnName"></asp:BoundField>
                                <asp:BoundField DataField="RoleAr" HeaderText="RoleAr" ReadOnly="True" SortExpression="RoleAr"></asp:BoundField>

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
                <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:DefaultConnection %>' SelectCommand="SELECT [ClID], [ArName], [EnName], [DID], [EArName], [EEnName], [RoleAr] FROM [Clinic_Doc]" DeleteCommand="spDELETE_dbo_Clinic_Doctor" DeleteCommandType="StoredProcedure" UpdateCommand="spUPDATE_dbo_Clinic_Doctor" UpdateCommandType="StoredProcedure">
                    <DeleteParameters>
                        <asp:Parameter Name="CLID" Type="String"></asp:Parameter>
                        <asp:Parameter Name="DID" Type="String"></asp:Parameter>
                    </DeleteParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="CLID" Type="String"></asp:Parameter>
                        <asp:Parameter Name="DID" Type="String"></asp:Parameter>
                    </UpdateParameters>
                </asp:SqlDataSource>
            </div>
            <br />
            
            
            
        </div>
    </div>
    

</asp:Content>
