<%@ Page Title="المخازن" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="store.aspx.cs" Inherits="ESCARE.store" %>

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
                        <table class="innerTable">
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
                    <td>
                        <div>
                            <asp:Label ID="lblSArName" runat="server" Text="اسم المخزن (عربي):" CssClass="labelStyle"></asp:Label>
                        </div>
                        <div>
                            <asp:TextBox ID="txtSArName" runat="server" CssClass="txtStyle" ></asp:TextBox>
                        </div>
                    </td>
                    <td>
                        <div>
                            <asp:Label ID="lblSEnName" runat="server" Text="اسم المخزن - (انجليزي):" CssClass="labelStyle"></asp:Label>
                        </div>
                        <div>
                            <asp:TextBox ID="txtSEnName" runat="server" CssClass="txtStyle" ></asp:TextBox>
                        </div>
                    </td>
                    <td>
                        <div>
                            <asp:Label ID="lblLocation" runat="server" Text="الموقع:" CssClass="labelStyle"></asp:Label>
                        </div>
                        <div>
                            <asp:DropDownList ID="ddlLocation" runat="server" DataSourceID="SqlDataSource3" DataTextField="ArName" DataValueField="ID"></asp:DropDownList>
                            <asp:SqlDataSource runat="server" ID="SqlDataSource3" ConnectionString='<%$ ConnectionStrings:DefaultConnection %>' SelectCommand="SELECT [ID], [ArName] FROM [Cities]"></asp:SqlDataSource>
                        </div>
                    </td>
                </tr>
                
                <tr>
                    <td colspan="4">
                        <div>
                            <asp:Label ID="lblDesc" runat="server" Text="الوصف:" CssClass="labelStyle"></asp:Label>
                        </div>
                        <div>
                            <asp:TextBox ID="txtDesc" runat="server" CssClass="txtStyle" TextMode="MultiLine"></asp:TextBox>
                        </div>
                    </td>
                </tr>
            </table>
            <br>
            <asp:Button ID="btnSave" runat="server" Text="حفظ" CssClass="buttons" OnClick="btnSave_Click" />
            <div class="Grid">
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="grdStores" runat="server" DataKeyNames="STID" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" CssClass="GridView" AllowPaging="True" PagerSettings-PageButtonCount="5" PageSize="6" PageIndex="0">
                            <Columns>
                                <asp:BoundField DataField="STID" HeaderText="كود" SortExpression="STID" ReadOnly="True"></asp:BoundField>
                                <asp:BoundField DataField="ArName" HeaderText="اسم المخزن - عربي" SortExpression="ArName"></asp:BoundField>
                                <asp:BoundField DataField="EnName" HeaderText="اسم المخزن - انجليزي" SortExpression="EnName"></asp:BoundField>
                                <asp:BoundField DataField="cArName" HeaderText="الموقع" SortExpression="Location" ReadOnly="True"></asp:BoundField>
                                <asp:TemplateField HeaderText="مفعل">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="Valid" DataField="Valid" runat="server" Checked='<%# Eval("Valid").Equals(1) %>' onclick="return false;" />
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <%--<asp:CheckBox ID="Available" DataField="Available" runat="server" Checked='<%# DataBinder.Eval(Container.DataItem,"Available").ToString() == "1" %>' Text=<%# DataBinder.Eval(Container.DataItem,"Available").ToString() == "1" ? "1" : "0" %> ></asp:CheckBox>--%>
                                        <asp:TextBox ID="Valid" DataField="Valid" runat="server" Text='<%# Bind("Valid") %>' TextMode="Number" MaxLength="1" />
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="r_Date" HeaderText="تاريخ التسجيل" SortExpression="r_Date" ReadOnly="True"></asp:BoundField>
                                
                                <asp:BoundField DataField="R_By" HeaderText="سجل بواسطة" SortExpression="R_By" ReadOnly="True"></asp:BoundField>
                                

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
                <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:DefaultConnection %>' SelectCommand="SELECT store.STID,store.ArName,store.EnName,cities.ArName as cArName,store.valid,convert(varchar(10), store.r_Date, 120) as [r_Date],store.r_By FROM [Store],[cities] where cities.id=store.location" UpdateCommand="spUPDATE_dbo_Store" UpdateCommandType="StoredProcedure" DeleteCommand="spDELETE_dbo_Store" DeleteCommandType="StoredProcedure">

                    <DeleteParameters>
                        <asp:Parameter Name="STID" Type="String"></asp:Parameter>
                    </DeleteParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="STID" Type="String"></asp:Parameter>
                        <asp:Parameter Name="ArName" Type="String"></asp:Parameter>
                        <asp:Parameter Name="EnName" Type="String"></asp:Parameter>
                        <asp:Parameter Name="Location" Type="String"></asp:Parameter>
                        <asp:Parameter Name="Descr" Type="String"></asp:Parameter>
                        <asp:Parameter Name="Valid" Type="Double"></asp:Parameter>
                    </UpdateParameters>
                </asp:SqlDataSource>
            </div>
            <br />
            
            
            
        </div>
    </div>
    

</asp:Content>
