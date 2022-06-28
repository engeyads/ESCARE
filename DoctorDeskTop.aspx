<%@ Page Title="Patient Ticket" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DoctorDeskTop.aspx.cs" Inherits="ESCARE.DoctorDeskTop" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <link href="CSS/DoctorDeskTop.css" rel="stylesheet" />
    <div class="bg bluring""></div>
    <div class="jumbotron1 bluring">
        <div id="wrapper">
            <table>
                <tr>
                    <td>
                        <div>
                            <asp:Label ID="lblPName" runat="server" Text="بحث ملف مريض:"></asp:Label>
                        </div>
                        <div style="float:right">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server" >
                            <ContentTemplate>
                                <asp:TextBox ID="txtPID"  runat="server" OnTextChanged="txtPID_TextChanged" Width="150px" TextMode="Date" AutoPostBack="True"></asp:TextBox>

                            </ContentTemplate>
                        </asp:UpdatePanel>
                        </div>
                        <div>
                            <asp:Button ID="btnSrch" style="margin-top:1px" runat="server" OnClick="Button1_Click" Text="بحث" CssClass="buttons" />
                        </div>
                    </td>
                </tr>
                <tr>
                    <td colspan="1">
                        <asp:Timer ID="Timer1" runat="server" OnTick="RefreshGridView" Interval="10000" />
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" >
                            <contenttemplate>
                                
                                <asp:GridView ID="grdStores" runat="server" DataKeyNames="FileNo,CLID" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" CssClass="GridView" AllowPaging="True" PagerSettings-PageButtonCount="5" PageSize="6" ontick="timer_Tick" AutoPostBack="true">
                                    <Columns>
                                        <asp:BoundField DataField="FileNo" HeaderText="FileNo" SortExpression="FileNo"></asp:BoundField>
                                        <asp:BoundField DataField="PArName" HeaderText="PArName" SortExpression="PArName" ReadOnly="True"></asp:BoundField>
                                        <asp:BoundField DataField="Date" HeaderText="Date" SortExpression="Date" ReadOnly="True"></asp:BoundField>
                                        <asp:BoundField DataField="Time" HeaderText="Time" SortExpression="Time" ReadOnly="True"></asp:BoundField>
                                        <asp:BoundField DataField="Paid" HeaderText="Paid" SortExpression="Paid"></asp:BoundField>
                                        <asp:BoundField DataField="IssuedBy" HeaderText="IssuedBy" SortExpression="IssuedBy"></asp:BoundField>
                                        <asp:BoundField DataField="PType" HeaderText="PType" SortExpression="PType"></asp:BoundField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:ImageButton ID="DoneBtn" CommandName="Update" runat="server"
                                                    ImageUrl="~/icons/done.png" ToolTip="انهاء" Height="20px" Width="20px" OnClientClick="return confirm('Mark patient as done?');" />
                                                <asp:ImageButton ID="Service" CommandName="goto" runat="server"
                                                    ImageUrl="~/icons/diagnose.png" ToolTip="تشخيص" Height="20px" Width="20px" CommandArgument='<%# Bind("FileNo") %>'  />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:BoundField DataField="Done" HeaderText="منتهي" SortExpression="Done"></asp:BoundField>
                                    </Columns>
                                </asp:GridView>
                                <asp:HiddenField ID="HiddenField1" runat="server" OnValueChanged="HiddenField1_ValueChanged" />
                                <asp:HiddenField ID="HiddenField2" runat="server" OnValueChanged="HiddenField2_ValueChanged" />
                                <asp:HiddenField ID="HiddenField3" runat="server" OnValueChanged="HiddenField3_ValueChanged" />
                                <asp:HiddenField ID="HiddenField4" runat="server" OnValueChanged="HiddenField4_ValueChanged" />
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="Timer1" />
                            </Triggers>
                        </asp:UpdatePanel>
                        <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:DefaultConnection %>' SelectCommand="SELECT [FileNo],[PArName],[Date],[Time],[Paid],[IssuedBy],[PType],[CLID],IIF([AV] = '1', 'انتظار', 'منتهي') as Done FROM [Ticket] WHERE (([EID] = @EID) AND ([Date] = @Date) AND ([CLID] = @CLID))" UpdateCommand="spUPDATE_dbo_PD_Customer_Done" UpdateCommandType="StoredProcedure">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="HiddenField2" PropertyName="Value" DefaultValue="0" Name="EID" Type="String"></asp:ControlParameter>
                                <asp:ControlParameter ControlID="HiddenField3" PropertyName="Value" DefaultValue="2018/10/04" Name="Date" Type="DateTime"></asp:ControlParameter>
                                <asp:ControlParameter ControlID="HiddenField4" PropertyName="Value" DefaultValue="0" Name="CLID" Type="String"></asp:ControlParameter>
                            </SelectParameters>
                            <UpdateParameters>
                                <asp:Parameter Name="FileNo" Type="String"></asp:Parameter>
                                <asp:Parameter Name="CLID" Type="String"></asp:Parameter>
                            </UpdateParameters>
                        </asp:SqlDataSource>
                        
                    </td>
                </tr>
            </table>
            <br />
            

    </div>
        <div>
            <table>
                <tr>
                    <td>
                       
                        

                    </td>
                </tr>
            </table>
        </div>
    </div>
    
</asp:Content>
