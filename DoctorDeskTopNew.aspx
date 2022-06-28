<%@ Page Title="Patient Ticket" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DoctorDeskTopNew.aspx.cs" Inherits="ESCARE.DoctorDeskTopNew" %>

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
                        <asp:UpdatePanel ID="UpdatePanel2"   runat="server" >
                            <ContentTemplate>
                                <asp:TextBox ID="txtPID"  runat="server" OnTextChanged="txtPID_TextChanged" Width="150px"></asp:TextBox>

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
                        
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:Timer ID="Timer1" runat="server" OnTick="RefreshGridView" Interval="2000" />
                                    <asp:GridView ID="gvPendingPatients" CssClass="GridView"  OnSelectedIndexChanged="gvPList_SelectedIndexChanged" runat="server" AutoGenerateSelectButton="False" CellPadding="3" ForeColor="Black" GridLines="Vertical" Width="894px" Height="59px" AllowPaging="True" PageSize="5" EnableSortingAndPagingCallbacks="false" OnPageIndexChanging="gvPList_PageIndexChanging" ontick="timer_Tick" AutoPostBack="true">
                                    
                                        <Columns>
                                            
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="OldDiag" cssclass="lnkbuttons" runat="server" Text="تشخيصات سابقة" OnClick="PartialPostBackOldDiag" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="Diag" cssclass="lnkbuttons" runat="server" Text="تشخيص" OnClick="PartialPostBackDiag" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    
                                        <EditRowStyle Wrap="False" />
                                        <PagerSettings PageButtonCount="4" />
                                    </asp:GridView>

                                </ContentTemplate>
                            </asp:UpdatePanel>
                        
                    </td>
                </tr>
            </table>
            <br />
            

    </div>
        <div>
            <table>
                <tr>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                            <ContentTemplate>
                                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                                <asp:GridView ID="gvPatientServices" runat="server"></asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <asp:HiddenField ID="HiddenField1" runat="server" OnValueChanged="HiddenField1_ValueChanged" />
</asp:Content>
