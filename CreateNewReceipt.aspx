<%@ Page Title="Create New Receipt" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateNewReceipt.aspx.cs" Inherits="ESCARE.CreateNewReceipt" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href="CSS/CreateNewReceipt.css" rel="stylesheet" />
    <meta http-equiv="Content-Type" content="text/html;charset=utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!-- new calendar CSS -->
    <script src="Scripts/jquery-1.11.0.js"></script>
    <link rel="stylesheet" type="text/css" media="screen" href="CSS/bootstrap-datetimepicker.min.css">
    <script>
        $(document).ready(function () {
            if ($("#hdnDdlOldValue").val() != $("#DropDownList2").val()) {
                DropdwonOnChangeFunction();
            }
        });
    </script>
    <asp:HiddenField ID="hdnVat" runat="server" />
    <asp:Label ID="hdnlblNationality" runat="server" Visible="False"></asp:Label>
    <div class="bg"></div>
    <div class="msg">
        <asp:UpdatePanel ID="UpdatePanel11" runat="server" >
            <ContentTemplate>
                <asp:Label ID="lblmsg" class="txtlbl" runat="server"></asp:Label>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <script>
        if ($(".txtlbl").text().trim().length > 1) {
            $(".msg").show().delay(5000).fadeOut();

        } else {
            $('.msg').hide();
        }
        function MyFunction(){
            if ($(".txtlbl").text().trim().length > 1) {
                $(".msg").show().delay(5000).fadeOut();

            } else {
                $('.msg').hide();
            }
        }
    </script>
    <script runat="server">

        protected void ProcessClick_Handler(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(2000);
        }

    </script>
    <div class="jumbotron1">
        <div id="wrapper">
            <ul>
                <li>
                    <asp:UpdatePanel ID="UpdatePanel10" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:Button ID="btnRegister" runat="server" Text="ملف مريض جديد" CssClass="buttons" OnClick="btnRegister_Click" />
                        </ContentTemplate>
                        <triggers>
                            <asp:AsyncPostBackTrigger ControlID="btnRegister" />
                        </triggers>
                    </asp:UpdatePanel>
                </li>
            </ul>

            <div class="Doctor">
                <div class="Doc">
                    <div class="subject">
                        <asp:Label ID="lblDoc" runat="server" Text="تسجيل الفاتورة"></asp:Label>
                    </div>
                    <table class="Tables">
                        <tr>
                            <td>
                                <div class="BillInfo">
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="BillPatient">
                                    <asp:Label ID="lblBillNo" runat="server" Text="رقم الفاتورة"></asp:Label>
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <asp:TextBox ID="txtBillNo" runat="server" OnTextChanged="btnSearchBlill_Click" Width="100px"></asp:TextBox>
                                            <asp:Button ID="btnSearchBill" runat="server" Text="بحث" CssClass="buttons" OnClick="btnSearchBlill_Click" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>

                                </div>

                            </td>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="txtIssued" runat="server" Width="100px"></asp:TextBox>
                                            <asp:TextBox ID="txtTimeIssued" runat="server" Width="100px"></asp:TextBox>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="BillPatInf">
                                    <table class="innerTable">
                                        <tr>
                                            <th>
                                                <h4>بيانات ملف المريض</h4>
                                            </th>
                                        </tr>
                                        <tr>
                                            <td>
                                                <div>
                                                    <asp:Label ID="lblFileNo" runat="server" Text="رقم الملف"></asp:Label>
                                                </div>
                                                <div>
                                                    <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                                        <ContentTemplate>
                                                            <asp:TextBox ID="txtFileNo" runat="server" AutoPostBack="True" CssClass="srch" OnTextChanged="txtFileNo_TextChanged"></asp:TextBox>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </div>
                                            </td>
                                            <td>
                                                <div>
                                                    <asp:Label ID="lblPatName" runat="server" Text="اسم المريض"></asp:Label>
                                                </div>
                                                <div class="searchPat">
                                                    <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                                        <ContentTemplate>
                                                            <asp:TextBox ID="txtPID" runat="server" OnTextChanged="txtPID_TextChanged" CssClass="srch" Style="float: right" AutoPostBack="True"></asp:TextBox>
                                                            <asp:ImageButton ID="btnSearch" runat="server" ImageUrl="~/icons/search1.png" BackColor="#F0F0F0" ImageAlign="Middle" OnClick="btnSearch_OnClickEvent" />
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </div>
                                            </td>
                                            <td>
                                                <div>
                                                    <asp:RadioButtonList ID="rbgSearchBy" runat="server" CssClass="radioButtonList">
                                                        <asp:ListItem Selected="True" Value="0" Text="رقم الهوية"></asp:ListItem>
                                                        <asp:ListItem Value="1" Text="رقم الجوال"></asp:ListItem>
                                                        <asp:ListItem Value="2" Text="الاســـم"></asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="BillDoc">
                                    <table class="innerTable">
                                        <tr>
                                            <th>
                                                <h4>بيانات الطبيب</h4>
                                            </th>
                                        </tr>
                                        <tr>
                                            <td>
                                                <div>
                                                    <asp:Label ID="lblBillClin" runat="server" Text="العيادة"></asp:Label>
                                                </div>
                                                <div>
                                                    <asp:UpdatePanel runat="server">
                                                        <ContentTemplate>
                                                            <asp:TextBox ID="txtBillClin" runat="server" Width="60px" AutoPostBack="True" OnTextChanged="txtBillClin_TextChanged"></asp:TextBox>
                                                            <asp:DropDownList ID="ddlBillClin" runat="server" AutoPostBack="True" CssClass="cln" OnSelectedIndexChanged="ddlBillClin_SelectedIndexChanged"></asp:DropDownList>

                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </div>
                                            </td>
                                            <td>
                                                <div>
                                                    <asp:Label ID="lblBillDoc" runat="server" Text="الطبيب"></asp:Label>
                                                </div>
                                                <div>
                                                    <asp:UpdatePanel runat="server">
                                                        <ContentTemplate>
                                                            <asp:TextBox ID="txtBillDoc" runat="server" Width="60px" AutoPostBack="True" OnTextChanged="txtBillDoc_TextChanged"></asp:TextBox>
                                                            <asp:DropDownList ID="ddlBillDoc" runat="server" AutoPostBack="True" CssClass="cln" OnSelectedIndexChanged="ddlBillDoc_SelectedIndexChanged">
                                                                <asp:ListItem Text="-- اختر طبيب --" Value="NA" Selected="True"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:GridView ID="gvPList" OnSelectedIndexChanged="gvPList_SelectedIndexChanged" runat="server" AllowSorting="True" AutoGenerateEditButton="True" AutoGenerateSelectButton="True" CellPadding="3" ForeColor="Black" GridLines="Vertical" Width="894px" Height="59px" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" AllowPaging="True" PageSize="5" EnableSortingAndPagingCallbacks="false" OnPageIndexChanging="gvPList_PageIndexChanging">
                        <AlternatingRowStyle BackColor="#CCCCCC" Wrap="False" />
                        <EditRowStyle Wrap="False" />
                        <FooterStyle BackColor="#CCCCCC" />
                        <HeaderStyle BackColor="#101010" BorderStyle="Inset" Font-Bold="True" ForeColor="White" Height="20px" Wrap="False" />
                        <PagerSettings PageButtonCount="4" />
                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                        <RowStyle Height="20px" Wrap="False" />
                        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" Wrap="False" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#808080" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#383838" />
                    </asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>


            

            <div class="Bills">
                
                <div class="BillServices">
                    <div class="subject">
                        <asp:Label ID="lblKind" runat="server" Text="خدمات الفاتورة"></asp:Label>
                    </div>
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                        <ContentTemplate>
                            <asp:Table ID="Table1" CssClass="Tables" runat="server">
                                <asp:TableRow TableSection="TableHeader" CssClass="TableHeader">
                                    <asp:TableHeaderCell>
                                        <asp:Label ID="lblCode" runat="server" Text="الكود" CssClass="TlabelStyle"></asp:Label>
                                    </asp:TableHeaderCell>
                                    <asp:TableHeaderCell>
                                        <asp:Label ID="lblArName" runat="server" Text="الاسم (عربي)"></asp:Label>
                                    </asp:TableHeaderCell>
                                    <asp:TableHeaderCell>
                                        <asp:Label ID="lblEnName" runat="server" Text="الاسم (انجليزي)"></asp:Label>
                                    </asp:TableHeaderCell>
                                    <asp:TableHeaderCell>
                                        <asp:Label ID="lblAmount" runat="server" Text="القيمة"></asp:Label>
                                    </asp:TableHeaderCell>
                                    <asp:TableHeaderCell>
                                        <asp:Label ID="lblQty" runat="server" Text="الكمية"></asp:Label>
                                    </asp:TableHeaderCell>
                                    <asp:TableHeaderCell>
                                        <asp:Label ID="lblDisPer" runat="server" Text="%"></asp:Label>
                                    </asp:TableHeaderCell>
                                    <asp:TableHeaderCell>
                                        <asp:Label ID="lblDisAmt" runat="server" Text="الخصم"></asp:Label>
                                    </asp:TableHeaderCell>
                                    <asp:TableHeaderCell>
                                        <asp:Label ID="lblNetAmt" runat="server" Text="اجمالي"></asp:Label>
                                    </asp:TableHeaderCell>
                                    <asp:TableHeaderCell>
                                        <asp:Label ID="Label2" runat="server" Text="الضريبة"></asp:Label>
                                    </asp:TableHeaderCell>
                                    <asp:TableHeaderCell>
                                        <asp:Label ID="lblDel" runat="server" Text="حذف"></asp:Label>
                                    </asp:TableHeaderCell>
                                </asp:TableRow>
                                <asp:TableRow TableSection="TableBody">
                                    <asp:TableCell>
                                        <asp:TextBox ID="txtCode1" Class="txtCode" runat="server" CssClass="TbodyText" Width="60" AutoPostBack="True" OnTextChanged="txtCode1_TextChanged"></asp:TextBox>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:TextBox ID="txtArName1" Class="txtArName" ReadOnly="true" runat="server" CssClass="TbodyText" Width="150" AutoPostBack="True"></asp:TextBox>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:TextBox ID="txtEnName1" Class="txtEnName" ReadOnly="true" runat="server" CssClass="TbodyText" Width="150" AutoPostBack="True"></asp:TextBox>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:TextBox ID="txtAmount1" Class="txtAmount" runat="server" CssClass="TbodyText" AutoPostBack="True" OnTextChanged="txtAmount1_TextChanged"></asp:TextBox>
                                        <asp:HiddenField ID="hdnAmount1" runat="server" />
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:TextBox ID="txtQty1" Class="txtQty" runat="server" CssClass="TbodyText" AutoPostBack="True" OnTextChanged="txtQty1_TextChanged"></asp:TextBox>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:TextBox ID="txtDisPer1" Class="txtDisPer" runat="server" CssClass="TbodyText" AutoPostBack="True" OnTextChanged="txtDisPer1_TextChanged"></asp:TextBox>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:TextBox ID="txtDisAmt1" Class="txtDisAmt" runat="server" CssClass="TbodyText" AutoPostBack="True" OnTextChanged="txtDisAmt1_TextChanged"></asp:TextBox>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:TextBox ID="txtNetAmt1" Class="txtNetAmt" ReadOnly="true" runat="server" CssClass="TbodyText" AutoPostBack="True"></asp:TextBox>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:TextBox ID="txtVat1" Class="txtNetAmt" ReadOnly="true" runat="server" CssClass="TbodyText" AutoPostBack="True"></asp:TextBox>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:ImageButton ID="btnDel1" runat="server" ImageUrl="~/icons/x.png" cssclass="tabButon" onclick="btnDel1_Click"  />
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow TableSection="TableBody">
                                    <asp:TableCell>
                                        <asp:TextBox ID="txtCode2" Class="txtCode" runat="server" CssClass="TbodyText" Width="60" AutoPostBack="True" OnTextChanged="txtCode2_TextChanged"></asp:TextBox>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:TextBox ID="txtArName2" Class="txtArName" ReadOnly="true" runat="server" CssClass="TbodyText" Width="150" AutoPostBack="True"></asp:TextBox>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:TextBox ID="txtEnName2" Class="txtEnName" ReadOnly="true" runat="server" CssClass="TbodyText" Width="150" AutoPostBack="True"></asp:TextBox>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:TextBox ID="txtAmount2" Class="txtAmount" runat="server" CssClass="TbodyText" AutoPostBack="True" OnTextChanged="txtAmount2_TextChanged"></asp:TextBox>
                                        <asp:HiddenField ID="hdnAmount2" runat="server" />
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:TextBox ID="txtQty2" Class="txtQty" runat="server" CssClass="TbodyText" AutoPostBack="True" OnTextChanged="txtQty2_TextChanged"></asp:TextBox>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:TextBox ID="txtDisPer2" Class="txtDisPer" runat="server" CssClass="TbodyText" AutoPostBack="True" OnTextChanged="txtDisPer2_TextChanged"></asp:TextBox>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:TextBox ID="txtDisAmt2" Class="txtDisAmt" runat="server" CssClass="TbodyText" AutoPostBack="True" OnTextChanged="txtDisAmt2_TextChanged"></asp:TextBox>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:TextBox ID="txtNetAmt2" Class="txtNetAmt" ReadOnly="true" runat="server" CssClass="TbodyText" AutoPostBack="True"></asp:TextBox>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:TextBox ID="txtVat2" Class="txtNetAmt" ReadOnly="true" runat="server" CssClass="TbodyText" AutoPostBack="True"></asp:TextBox>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:ImageButton ID="btnDel2" runat="server" ImageUrl="~/icons/x.png" cssclass="tabButon" onclick="btnDel2_Click"  />
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow TableSection="TableBody">
                                    <asp:TableCell>
                                        <asp:TextBox ID="txtCode3" Class="txtCode" runat="server" CssClass="TbodyText" Width="60" AutoPostBack="True" OnTextChanged="txtCode3_TextChanged"></asp:TextBox>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:TextBox ID="txtArName3" Class="txtArName" ReadOnly="true" runat="server" CssClass="TbodyText" Width="150" AutoPostBack="True"></asp:TextBox>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:TextBox ID="txtEnName3" Class="txtEnName" ReadOnly="true" runat="server" CssClass="TbodyText" Width="150" AutoPostBack="True"></asp:TextBox>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:TextBox ID="txtAmount3" Class="txtAmount" runat="server" CssClass="TbodyText" AutoPostBack="True" OnTextChanged="txtAmount3_TextChanged"></asp:TextBox>
                                        <asp:HiddenField ID="hdnAmount3" runat="server" />
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:TextBox ID="txtQty3" Class="txtQty" runat="server" CssClass="TbodyText" AutoPostBack="True" OnTextChanged="txtQty3_TextChanged"></asp:TextBox>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:TextBox ID="txtDisPer3" Class="txtDisPer" runat="server" CssClass="TbodyText" AutoPostBack="True" OnTextChanged="txtDisPer3_TextChanged"></asp:TextBox>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:TextBox ID="txtDisAmt3" Class="txtDisAmt" runat="server" CssClass="TbodyText" AutoPostBack="True" OnTextChanged="txtDisAmt3_TextChanged"></asp:TextBox>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:TextBox ID="txtNetAmt3" Class="txtNetAmt" ReadOnly="true" runat="server" CssClass="TbodyText" AutoPostBack="True"></asp:TextBox>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:TextBox ID="txtVat3" Class="txtNetAmt" ReadOnly="true" runat="server" CssClass="TbodyText" AutoPostBack="True"></asp:TextBox>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:ImageButton ID="btnDel3" runat="server" ImageUrl="~/icons/x.png" cssclass="tabButon" onclick="btnDel3_Click"  />
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow TableSection="TableBody">
                                    <asp:TableCell>
                                        <asp:TextBox ID="txtCode4" Class="txtCode" runat="server" CssClass="TbodyText" Width="60" AutoPostBack="True" OnTextChanged="txtCode4_TextChanged"></asp:TextBox>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:TextBox ID="txtArName4" Class="txtArName" ReadOnly="true" runat="server" CssClass="TbodyText" Width="150" AutoPostBack="True"></asp:TextBox>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:TextBox ID="txtEnName4" Class="txtEnName" ReadOnly="true" runat="server" CssClass="TbodyText" Width="150" AutoPostBack="True"></asp:TextBox>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:TextBox ID="txtAmount4" Class="txtAmount" runat="server" CssClass="TbodyText" AutoPostBack="True" OnTextChanged="txtAmount4_TextChanged"></asp:TextBox>
                                        <asp:HiddenField ID="hdnAmount4" runat="server" />
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:TextBox ID="txtQty4" Class="txtQty" runat="server" CssClass="TbodyText" AutoPostBack="True" OnTextChanged="txtQty4_TextChanged"></asp:TextBox>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:TextBox ID="txtDisPer4" Class="txtDisPer" runat="server" CssClass="TbodyText" AutoPostBack="True" OnTextChanged="txtDisPer4_TextChanged"></asp:TextBox>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:TextBox ID="txtDisAmt4" Class="txtDisAmt" runat="server" CssClass="TbodyText" AutoPostBack="True" OnTextChanged="txtDisAmt4_TextChanged"></asp:TextBox>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:TextBox ID="txtNetAmt4" Class="txtNetAmt" ReadOnly="true" runat="server" CssClass="TbodyText" AutoPostBack="True"></asp:TextBox>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:TextBox ID="txtVat4" Class="txtNetAmt" ReadOnly="true" runat="server" CssClass="TbodyText" AutoPostBack="True"></asp:TextBox>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:ImageButton ID="btnDel4" runat="server" ImageUrl="~/icons/x.png" cssclass="tabButon" onclick="btnDel4_Click"  />
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow TableSection="TableBody">
                                    <asp:TableCell>
                                        <asp:TextBox ID="txtCode5" Class="txtCode" runat="server" CssClass="TbodyText" Width="60" AutoPostBack="True" OnTextChanged="txtCode5_TextChanged"></asp:TextBox>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:TextBox ID="txtArName5" Class="txtArName" ReadOnly="true" runat="server" CssClass="TbodyText" Width="150" AutoPostBack="True"></asp:TextBox>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:TextBox ID="txtEnName5" Class="txtEnName" ReadOnly="true" runat="server" CssClass="TbodyText" Width="150" AutoPostBack="True"></asp:TextBox>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:TextBox ID="txtAmount5" Class="txtAmount" runat="server" CssClass="TbodyText" AutoPostBack="True" OnTextChanged="txtAmount5_TextChanged"></asp:TextBox>
                                        <asp:HiddenField ID="hdnAmount5" runat="server" />
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:TextBox ID="txtQty5" Class="txtQty" runat="server" CssClass="TbodyText" AutoPostBack="True" OnTextChanged="txtQty5_TextChanged"></asp:TextBox>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:TextBox ID="txtDisPer5" Class="txtDisPer" runat="server" CssClass="TbodyText" AutoPostBack="True" OnTextChanged="txtDisPer5_TextChanged"></asp:TextBox>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:TextBox ID="txtDisAmt5" Class="txtDisAmt" runat="server" CssClass="TbodyText" AutoPostBack="True" OnTextChanged="txtDisAmt5_TextChanged"></asp:TextBox>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:TextBox ID="txtNetAmt5" Class="txtNetAmt" ReadOnly="true" runat="server" CssClass="TbodyText" AutoPostBack="True"></asp:TextBox>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:TextBox ID="txtVat5" Class="txtNetAmt" ReadOnly="true" runat="server" CssClass="TbodyText" AutoPostBack="True"></asp:TextBox>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:ImageButton ID="btnDel5" runat="server" ImageUrl="~/icons/x.png" cssclass="tabButon" onclick="btnDel5_Click"  />
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow TableSection="TableBody">
                                    <asp:TableCell>
                                        <asp:TextBox ID="txtCode6" Class="txtCode" runat="server" CssClass="TbodyText" Width="60" AutoPostBack="True" OnTextChanged="txtCode6_TextChanged"></asp:TextBox>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:TextBox ID="txtArName6" Class="txtArName" ReadOnly="true" runat="server" CssClass="TbodyText" Width="150" AutoPostBack="True"></asp:TextBox>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:TextBox ID="txtEnName6" Class="txtEnName" ReadOnly="true" runat="server" CssClass="TbodyText" Width="150" AutoPostBack="True"></asp:TextBox>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:TextBox ID="txtAmount6" Class="txtAmount" runat="server" CssClass="TbodyText" AutoPostBack="True" OnTextChanged="txtAmount6_TextChanged"></asp:TextBox>
                                        <asp:HiddenField ID="hdnAmount6" runat="server" />
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:TextBox ID="txtQty6" Class="txtQty" runat="server" CssClass="TbodyText" AutoPostBack="True" OnTextChanged="txtQty6_TextChanged"></asp:TextBox>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:TextBox ID="txtDisPer6" Class="txtDisPer" runat="server" CssClass="TbodyText" AutoPostBack="True" OnTextChanged="txtDisPer6_TextChanged"></asp:TextBox>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:TextBox ID="txtDisAmt6" Class="txtDisAmt" runat="server" CssClass="TbodyText" AutoPostBack="True" OnTextChanged="txtDisAmt6_TextChanged"></asp:TextBox>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:TextBox ID="txtNetAmt6" Class="txtNetAmt" runat="server" ReadOnly="true" CssClass="TbodyText" AutoPostBack="True"></asp:TextBox>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:TextBox ID="txtVat6" Class="txtNetAmt" ReadOnly="true" runat="server" CssClass="TbodyText" AutoPostBack="True"></asp:TextBox>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:ImageButton ID="btnDel6" runat="server" ImageUrl="~/icons/x.png" cssclass="tabButon" onclick="btnDel6_Click"  />
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow TableSection="TableBody">
                                    <asp:TableCell>
                                        <asp:TextBox ID="txtCode7" Class="txtCode" runat="server" CssClass="TbodyText" Width="60" AutoPostBack="True" OnTextChanged="txtCode7_TextChanged"></asp:TextBox>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:TextBox ID="txtArName7" Class="txtArName" ReadOnly="true" runat="server" CssClass="TbodyText" Width="150" AutoPostBack="True"></asp:TextBox>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:TextBox ID="txtEnName7" Class="txtEnName" ReadOnly="true" runat="server" CssClass="TbodyText" Width="150" AutoPostBack="True"></asp:TextBox>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:TextBox ID="txtAmount7" Class="txtAmount" runat="server" CssClass="TbodyText" AutoPostBack="True" OnTextChanged="txtAmount7_TextChanged"></asp:TextBox>
                                        <asp:HiddenField ID="hdnAmount7" runat="server" />
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:TextBox ID="txtQty7" Class="txtQty" runat="server" CssClass="TbodyText" AutoPostBack="True" OnTextChanged="txtQty7_TextChanged"></asp:TextBox>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:TextBox ID="txtDisPer7" Class="txtDisPer" runat="server" CssClass="TbodyText" AutoPostBack="True" OnTextChanged="txtDisPer7_TextChanged"></asp:TextBox>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:TextBox ID="txtDisAmt7" Class="txtDisAmt" runat="server" CssClass="TbodyText" AutoPostBack="True" OnTextChanged="txtDisAmt7_TextChanged"></asp:TextBox>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:TextBox ID="txtNetAmt7" Class="txtNetAmt" runat="server" ReadOnly="true" CssClass="TbodyText" AutoPostBack="True"></asp:TextBox>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:TextBox ID="txtVat7" Class="txtNetAmt" ReadOnly="true" runat="server" CssClass="TbodyText" AutoPostBack="True"></asp:TextBox>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:ImageButton ID="btnDel7" runat="server" ImageUrl="~/icons/x.png"  cssclass="tabButon" onclick="btnDel7_Click" />
                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                            <script type="text/javascript">

                                $(".TbodyText").keyup(function (e) {
                                    if (e.keyCode === 13) {
                                        $(this).next('input').focus();
                                    }
                                });
                                
                            </script>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>

            <div class="Services">
                <div class="Ser">
                    <div class="subject">
                        <asp:Label ID="Label3" runat="server" Text="خدمات العيادة"></asp:Label>
                    </div>
                    <div class="zag">
                        <div class="Tables1">
                            <asp:UpdatePanel ID="UpdatePanel6"  runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="grdServices" OnSelectedIndexChanged="grdServices_SelectedIndexChanged" cssclass="grd" runat="server">
                                        <Columns>
                                            <asp:CommandField ShowSelectButton="True" ControlStyle-CssClass="buttons" ButtonType="Button" ShowHeader="True" HeaderText="اضافة" SelectText="اضافة"></asp:CommandField>
                                        </Columns>
                                    </asp:GridView>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>

                    </div>
                </div>
            </div>

            <div class="Total">
                <div class="Tot">
                    <div class="subject">
                        <asp:Label ID="Label1" runat="server" Text="تسجيل الفاتورة"></asp:Label>
                    </div>
                    <div class="Tables">
                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                            <ContentTemplate>
                                <table class="tab">
                                    <tr>
                                        <td>
                                            <div>
                                                <asp:Label ID="lblPaymentType" runat="server" Text="طريقة الدفع:"></asp:Label>
                                            </div>
                                            <div>
                                                <asp:DropDownList ID="ddlPaymentType" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPaymentType_SelectedIndexChanged" DataSourceID="SqlDataSource1" DataTextField="PaymentType" DataValueField="id"></asp:DropDownList>
                                                <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:DefaultConnection %>' SelectCommand="SELECT [id], [PaymentType] FROM [Payment]"></asp:SqlDataSource>
                                            </div>
                                        </td>
                                        <td>
                                            <div>
                                                <asp:Label ID="lblRemain" runat="server" Text="المتبقي:"></asp:Label>
                                            </div>
                                            <div>
                                                <asp:TextBox ID="txtRemain" runat="server"></asp:TextBox>
                                            </div>
                                        </td>
                                        <td>
                                            <div>
                                                <asp:Label ID="lblVat" runat="server" Text="الضريبة:"></asp:Label>
                                            </div>
                                            <div>
                                                <asp:TextBox ID="txtVat" runat="server"></asp:TextBox>
                                            </div>
                                        </td>
                                        <td>
                                            <div>
                                                <asp:Label ID="lblAmtDV" runat="server" Text="الاجمالي بدون الضريبة:"></asp:Label>
                                            </div>
                                            <div>
                                                <asp:TextBox ID="txtAmtDV" runat="server"></asp:TextBox>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td>
                                            <div>
                                                <asp:Label ID="lblCredit" runat="server" Text="دفع بالبطاقة:"></asp:Label>
                                            </div>
                                            <div>
                                                <asp:TextBox ID="txtCredit"  runat="server"></asp:TextBox>
                                            </div>
                                        </td>
                                        <td>
                                            <div>
                                                <asp:Label ID="lblCash" runat="server" Text="دفع كاش:"></asp:Label>
                                            </div>
                                            <div>
                                                <asp:TextBox ID="txtCash"  runat="server"></asp:TextBox>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <asp:Label ID="lblPrice" runat="server" Text="الاجمالي:"></asp:Label>
                        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                            <ContentTemplate>
                                <asp:TextBox ID="txtPrice" ReadOnly="true" runat="server"></asp:TextBox>
                                <asp:Button ID="btnProceed" runat="server" Text="حفظ" CssClass="buttons" OnClick="btnProceed_Click" />
                                <asp:Button ID="btnRecipe" runat="server" Text="حفظ و طباعة" CssClass="buttons" OnClick="btnRecipe_Click" />
                            </ContentTemplate>
                        </asp:UpdatePanel>

                        <br />
                        
                        
                    </div>
                </div>            
            </div>
        </div>
    </div>
    
</asp:Content>
