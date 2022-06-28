<%@ Page Title="Create New Receipt" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddCustomer.aspx.cs" Inherits="ESCARE.AddCustomer" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Page CSS -->
    <link href="CSS/addCustomer.css" rel="stylesheet" />
    <meta http-equiv="Content-Type" content="text/html;charset=utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!-- new calendar CSS -->
    <link rel="stylesheet" type="text/css" media="screen" href="CSS/bootstrap-datetimepicker.min.css">
    <!-- new calendar JS -->
    <script src="js/1.8.3/jquery.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/bootstrap-datetimepicker.min.js"></script>
    <!-- Begin Page -->
    <div class="bg"></div>
    <div class="msg">
                <asp:Label ID="lblmsg" class="txtlbl" runat="server" ></asp:Label>
            </div>
            <script>
                if ($(".txtlbl").text().trim().length > 1) {
                    $(".msg").show().delay(5000).fadeOut();
                    
                } else {
                    $('.msg').hide();
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
            <table>
                <tr>
                    <td>
                        <table class="innerTable">
                            <tr>
                                <td>
                                    <div>
                                        <asp:Label ID="lblFile" runat="server" Text="رقم الملف:" CssClass="labelStyle"></asp:Label>
                                    </div>
                                    <div>
                                        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                            <ContentTemplate>
                                                <asp:TextBox ID="txtFile" runat="server" Width="80px" CssClass="txtStyle" OnTextChanged="txtFile_TextChanged" ></asp:TextBox>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <asp:Button ID="btnSearch" runat="server" Text="Button" OnClick="txtFile_TextChanged" />
                                    </div>
                                </td>
                                <td>
                                    <div>
                                        <asp:Label ID="lblFileAlt" runat="server" Text="رقم الملف البديل:" CssClass="labelStyle"></asp:Label>
                                    </div>
                                    <div>
                                        <asp:TextBox ID="txtFileAlt" runat="server" Width="80px" CssClass="txtStyle" ></asp:TextBox>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td>
                        <div>
                            <asp:Label ID="lblGender" runat="server" Text="الجنس:" CssClass="labelStyle"></asp:Label>
                        </div>
                        <div>
                            <asp:RadioButtonList ID="rblGender" runat="server" DataSourceID="SqlDataSource2" DataTextField="GenderAr" DataValueField="ID" RepeatDirection="Horizontal"></asp:RadioButtonList>
                            <asp:SqlDataSource runat="server" ID="SqlDataSource2" ConnectionString='<%$ ConnectionStrings:DefaultConnection %>' SelectCommand="SELECT [ID], [GenderAr] FROM [Gender]"></asp:SqlDataSource>
                        </div>
                    </td>
                    <td>
                        <div>

                            <asp:Label ID="lblIDType" runat="server" Text="نوع الهوية:" CssClass="labelStyle"></asp:Label>
                        </div>
                        <div>
                            <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                <contenttemplate>
                                    <asp:DropDownList ID="ddlIDType" runat="server" DataSourceID="SqlDataSource1" DataTextField="IDTypeAr" DataValueField="ID" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="ddlIDType_SelectedIndexChanged">
                                        <asp:ListItem Text="-- اختر نوع --" Value="0" />
                                    </asp:DropDownList>
                                </contenttemplate>
                            </asp:UpdatePanel>
                            <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:DefaultConnection %>' SelectCommand="SELECT [IDTypeAr], [ID] FROM [IDTypes]"></asp:SqlDataSource>
                        </div>
                    </td>
                    <td>
                        <div>
                            <asp:Label ID="lblIDNo" runat="server" Text="رقم الهوية:" CssClass="labelStyle"></asp:Label>
                        </div>
                        <div>
                            <asp:TextBox ID="txtIDNo" runat="server" CssClass="txtStyle" TextMode="Number" ></asp:TextBox>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblocr" runat="server" Text=""></asp:Label>
                        
                    </td>
                    <tr>
                        <td>
                        <table>
                            <tr>
                                <td>
                                    <asp:FileUpload ID="FileUpload1" cssclass="upld" onchange="readURL(this)" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <img id="imge" class="idimg" src="#" alt="لم تقم باختيار صورة" width="100" height="100" />
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td colspan="2" style="align-content:center">
                        <div class="PersonID">
                <div class="subject">
                    <asp:Label ID="Label1" runat="server" Text="الهوية"></asp:Label>
                </div>
                <div class="details">
                    <table>
                        <tr>
                            <td>
                            <asp:Image ID="IDCard" runat="server" cssclass="imgper" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
                    </td>
                </tr>
                <tr>
                    <td colspan="5" style="padding-top:100px;">
                        <hr>
                    </td>
                </tr>
                <tr class="taH2r">
                    <td colspan="5" class="taH2">
                        <asp:Label ID="lblArName" runat="server" Text="الاسم (عربي)" CssClass="labelStyleH2"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="5">
                        <asp:UpdatePanel ID="UpdatePanel9" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <table>
                                    <tr>

                                        <td>
                                            <div>
                                                <asp:Label ID="lblArFName" runat="server" Text="الاسم الأول:" CssClass="labelStyle"></asp:Label>
                                            </div>
                                            <div>

                                                <asp:TextBox ID="txtArFName" runat="server" CssClass="txtStyle" OnTextChanged="txtArFName_TextChanged" AutoPostBack="True"></asp:TextBox>

                                            </div>
                                        </td>
                                        <td>
                                            <div>
                                                <asp:Label ID="lblArMName" runat="server" Text="اسم الاب:" CssClass="labelStyle"></asp:Label>
                                            </div>
                                            <div>

                                                <asp:TextBox ID="txtArMName" runat="server" CssClass="txtStyle" OnTextChanged="txtArMName_TextChanged" AutoPostBack="True"></asp:TextBox>

                                            </div>
                                        </td>
                                        <td>
                                            <div>
                                                <asp:Label ID="lblArTName" runat="server" Text="اسم الجد:" CssClass="labelStyle"></asp:Label>
                                            </div>
                                            <div>

                                                <asp:TextBox ID="txtArTName" runat="server" CssClass="txtStyle" OnTextChanged="txtArTName_TextChanged" AutoPostBack="True"></asp:TextBox>

                                            </div>
                                        </td>
                                        <td>
                                            <div>
                                                <asp:Label ID="lblArLName" runat="server" Text="الاسم الأخير:" CssClass="labelStyle"></asp:Label>
                                            </div>
                                            <div>

                                                <asp:TextBox ID="txtArLName" runat="server" CssClass="txtStyle" OnTextChanged="txtArLName_TextChanged" AutoPostBack="True"></asp:TextBox>

                                            </div>
                                        </td>

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
                                                <asp:TextBox ID="txtEnFName" runat="server" CssClass="txtStyle"></asp:TextBox>
                                            </div>

                                        </td>
                                        <td>
                                            <div>
                                                <asp:Label ID="lblEnMName" runat="server" Text="اسم الاب:" CssClass="labelStyle"></asp:Label>
                                            </div>
                                            <div>
                                                <asp:TextBox ID="txtEnMName" runat="server" CssClass="txtStyle"></asp:TextBox>
                                            </div>

                                        </td>
                                        <td>
                                            <div>
                                                <asp:Label ID="lblEnTName" runat="server" Text="اسم الجد:" CssClass="labelStyle"></asp:Label>
                                            </div>
                                            <div>
                                                <asp:TextBox ID="txtEnTName" runat="server" CssClass="txtStyle"></asp:TextBox>
                                            </div>

                                        </td>
                                        <td>
                                            <div>
                                                <asp:Label ID="lblEnLName" runat="server" Text="الاسم الأخير:" CssClass="labelStyle"></asp:Label>
                                            </div>
                                            <div>
                                                <asp:TextBox ID="txtEnLName" runat="server" CssClass="txtStyle"></asp:TextBox>
                                            </div>
                                        </td>


                                    </tr>
                                </table>

                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td colspan="5">
                        <hr>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div>
                            <asp:Label ID="lblNationality" runat="server" Text="الجنسية:" CssClass="labelStyle"></asp:Label>
                        </div>
                        <div>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
                                <ContentTemplate>
                                    <table class="innerTable">
                                        <tr>
                                            <td>
                                                <asp:TextBox Width="30px" ID="txtNationalityID" runat="server" CausesValidation="False" AutoPostBack="true" CssClass="txtStyle" OnTextChanged="txtNationalityID_TextChanged" TextMode="Number" ></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlNationalityName" runat="server" DataSourceID="SqlDataSource3" DataTextField="ArName" DataValueField="Id" Width="30px" OnSelectedIndexChanged="ddlNationalityName_SelectedIndexChanged" AutoPostBack="True" CausesValidation="True" AppendDataBoundItems="true">
                                                    <asp:ListItem Text="-- اختر جنسة --" Value="0" />                                                    
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </td>
                    <td>
                        <div>
                            <asp:Label ID="lblVou" runat="server" Text="الرصيد المتبقي:" CssClass="labelStyle"></asp:Label>
                        </div>
                        <div>
                            <table class="innerTable">
                                <tr>
                                    <td>
                                        <asp:TextBox ID="txtVou" Width="80px" runat="server" CssClass="txtStyle" ></asp:TextBox>
                                    </td>
                                    <td>
                                        <a href="#">ايصال الاستلام</a>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                    <td>
                        <table class="innerTable">
                            <tr>
                                <td>
                                    <asp:Label ID="lblRDate" runat="server" Text="تاريخ التسجيل:" CssClass="labelStyle"></asp:Label>
                                    <div id="datetimepicker" class="input-append date">
                                        <asp:TextBox ID="txtRDate" runat="server"  Width="100px"></asp:TextBox>
                                        <span class="add-on" style="height: 28px">
                                            <i data-time-icon="icon-time" data-date-icon="icon-calendar"></i>
                                        </span>
                                    </div>


                                </td>
                                <td>
                                    <asp:Label ID="lblRTime" runat="server" Text="الوقت:" CssClass="labelStyle"></asp:Label>
                                    <div id="timepicker" class="input-append date">
                                        <asp:TextBox ID="txtRTime" runat="server"  Width="80px"></asp:TextBox>
                                        <span class="add-on" style="height: 28px">
                                            <i data-time-icon="icon-time" data-date-icon="icon-calendar"></i>
                                        </span>
                                    </div>
                                </td>
                            </tr>
                        </table>


                    </td>
                    <td>
                        <div>
                            <asp:Label ID="lblStatus" runat="server" Text="الحالة الاجتماعية" CssClass="labelStyle"></asp:Label>
                        </div>
                        <div>
                            <asp:DropDownList ID="ddlStatus" runat="server" DataSourceID="SqlDataSource4" DataTextField="ArName" DataValueField="ID" AppendDataBoundItems="true">
                                <asp:ListItem Text="-- اختر الحالة الإجتماعية --" Value="0" />
                            </asp:DropDownList>
                            <asp:SqlDataSource runat="server" ID="SqlDataSource4" ConnectionString='<%$ ConnectionStrings:DefaultConnection %>' SelectCommand="SELECT [ArName], [ID] FROM [PersonalStatus]"></asp:SqlDataSource>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>

                                <div>
                                    <asp:Label ID="lblFamilyCode" runat="server" Text="كود العائلة:" CssClass="labelStyle"></asp:Label>
                                </div>
                                <div>
                                    <asp:DropDownList ID="ddlFamilyCode" runat="server" DataTextField="Relation" DataValueField="Id" Width="30px" OnSelectedIndexChanged="ddlNationalityName_SelectedIndexChanged" AutoPostBack="True" CausesValidation="True" DataSourceID="SqlDataSource6" AppendDataBoundItems="true">
                                        <asp:ListItem Text="-- اختر كود --" Value="0" />
                                    </asp:DropDownList>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <asp:SqlDataSource runat="server" ID="SqlDataSource6" ConnectionString='<%$ ConnectionStrings:DefaultConnection %>' SelectCommand="SELECT ID, (CODE+' '+ArRelationName) as Relation from FamilyRelation"></asp:SqlDataSource>
                    </td>
                    <td>
                        <div>
                            <asp:Label ID="lblAge" runat="server" Text="العمر:" CssClass="labelStyle"></asp:Label>
                        </div>
                        <div>
                            <asp:TextBox ID="txtAge" runat="server" CssClass="txtStyle"></asp:TextBox>
                        </div>
                    </td>
                    <td>
                        <asp:Label ID="lblDOB" runat="server" Text="تاريخ الميلاد:" CssClass="labelStyle"></asp:Label>
                        <div id="datetimepicker2" class="input-append date">
                            <asp:TextBox ID="txtDOB" runat="server" ></asp:TextBox>
                            <span class="add-on" style="height: 28px">
                                <i data-time-icon="icon-time" data-date-icon="icon-calendar"></i>
                            </span>
                        </div>

                    </td>
                    <td>
                        <div>
                            <asp:Label ID="lblDOBH" runat="server" Text="تاريخ الميلاد هجري:" CssClass="labelStyle"></asp:Label>
                        </div>
                        <div>
                            <asp:TextBox ID="TextBox3" class="form-control" runat="server" CssClass="droid-arabic-kufi"></asp:TextBox>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div>
                            <asp:Label ID="lblMobile" runat="server" Text="الموبايل:" CssClass="labelStyle"></asp:Label>
                        </div>
                        <div>
                            <asp:TextBox ID="txtMobile" class="form-control" runat="server"  CssClass="txtStyle" TextMode="Number"></asp:TextBox>
                        </div>
                    </td>
                    <td>
                        <div>
                            <asp:Label ID="lblEmail" runat="server" Text="البريد الإلكتروني:" CssClass="labelStyle"></asp:Label>
                        </div>
                        <div>
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="txtStyle" TextMode="Email" ></asp:TextBox>
                        </div>
                    </td>
                    <td>
                        <div>
                            <asp:Label ID="lblTel" runat="server" Text="التليفون:" CssClass="labelStyle"></asp:Label>
                        </div>
                        <div>
                            <asp:TextBox ID="txtTel" runat="server" CssClass="txtStyle" TextMode="Number" ></asp:TextBox>
                        </div>
                    </td>
                    <td>
                        <div>
                            <asp:Label ID="lblAddress" runat="server" Text="العنوان:" CssClass="labelStyle"></asp:Label>
                        </div>
                        <div>
                            <asp:TextBox ID="txtAddress" class="form-control" runat="server"  CssClass="txtStyle"></asp:TextBox>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%--<div>
                            <asp:Label ID="lblDoc" runat="server" Text="الطبيب المراجع:" CssClass="labelStyle"></asp:Label>
                        </div>
                        <div>
                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                <ContentTemplate>
                                    <asp:TextBox ID="txtDoc" runat="server" Width="50px" AutoPostBack="True" OnTextChanged="txtDoc_TextChanged" TextMode="Number" ></asp:TextBox>
                                    <asp:DropDownList ID="ddlDoc" runat="server"  DataSourceID="SqlDataSource5" DataTextField="DName" DataValueField="EmpID" AutoPostBack="True" OnSelectedIndexChanged="ddlDoc_SelectedIndexChanged" AppendDataBoundItems="true">
                                        <asp:ListItem Text="-- اختر طبيب --" Value="0" />
                                    </asp:DropDownList>
                                    <asp:SqlDataSource runat="server" ID="SqlDataSource5" ConnectionString='<%$ ConnectionStrings:DefaultConnection %>' SelectCommand="select EmpID,(ArFName+' '+ArLName) as DName from employees where Profition=3"></asp:SqlDataSource>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>--%>
                    </td>
                    <td colspan="3">
                        <div>
                            <asp:Label ID="lblCom" runat="server" Text="التعليق:" CssClass="labelStyle"></asp:Label>
                        </div>
                        <div>
                            <asp:TextBox ID="txtCom" runat="server" CssClass="txtStyle" Height="60px" Width="650px" TextMode="MultiLine"></asp:TextBox>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div>
                            <asp:Label ID="lblPType" runat="server" Text="فئة المريض:" CssClass="labelStyle"></asp:Label>
                        </div>
                        <div>
                            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                <ContentTemplate>
                                    <asp:TextBox ID="txtPType" runat="server" Width="30px" AutoPostBack="True" OnTextChanged="txtPType_TextChanged" TextMode="Number" ></asp:TextBox>
                                    <asp:DropDownList ID="ddlPType" runat="server" Width="170px" DataSourceID="SqlDataSource7" DataTextField="ArName" DataValueField="ID" AutoPostBack="True" OnSelectedIndexChanged="ddlPType_SelectedIndexChanged" AppendDataBoundItems="true">
                                        <asp:ListItem Text="-- اختر فئة --" Value="0" />
                                    </asp:DropDownList>
                                    <asp:SqlDataSource runat="server" ID="SqlDataSource7" ConnectionString='<%$ ConnectionStrings:DefaultConnection %>' SelectCommand="select ID,ArName from PatientTypes"></asp:SqlDataSource>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </td>
                    <td>
                        <div>
                            <asp:Label ID="lblMar" runat="server" Text="تمت معرفتنا عن طريق:" CssClass="labelStyle"></asp:Label>
                        </div>
                        <div>
                            <asp:DropDownList ID="ddlMar" runat="server" Width="100px" DataSourceID="SqlDataSource8" DataTextField="ArName" DataValueField="ID" AppendDataBoundItems="true">
                                <asp:ListItem Text="-- اختر الطريقة --" Value="0" />
                            </asp:DropDownList>
                            <asp:SqlDataSource runat="server" ID="SqlDataSource8" ConnectionString='<%$ ConnectionStrings:DefaultConnection %>' SelectCommand="select ID,ArName from Marketing"></asp:SqlDataSource>
                        </div>
                    </td>
                    <td>
                        <div>
                            <asp:Label ID="lblResp" runat="server" Text="ولي الأمر:" CssClass="labelStyle"></asp:Label>
                        </div>
                        <div>
                            <asp:TextBox ID="txtResp" runat="server" CssClass="txtStyle" ></asp:TextBox>
                        </div>
                    </td>
                    <td>
                        <%--<table class="innerTable">
                            <tr>
                                <td>--%>
                                    <div>
                                        <asp:Label ID="lblCity" runat="server" Text="المدينة:" CssClass="labelStyle"></asp:Label>
                                    </div>
                                    <div>
                                        <asp:UpdatePanel runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlCity" runat="server" Width="60px" AppendDataBoundItems="true" DataSourceID="SqlDataSource10" DataTextField="ArName" DataValueField="ID" AutoPostBack="true" CausesValidation="false" OnSelectedIndexChanged="ddlCity_SelectedIndexChanged">
                                                    <asp:ListItem Text="-- اختر مدينة --" Value="0" />
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <asp:SqlDataSource runat="server" ID="SqlDataSource10" ConnectionString='<%$ ConnectionStrings:DefaultConnection %>' SelectCommand="SELECT [ID], [ArName] FROM [Cities]"></asp:SqlDataSource>
                                    </div>
                               <%-- </td>
                                
                            </tr>
                        </table>--%>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div>
                            <asp:Label ID="lblCN" runat="server" Text="رقم البطاقة المرجعية:" CssClass="labelStyle"></asp:Label>
                        </div>
                        <div>
                            <asp:TextBox ID="txtCN" runat="server" CssClass="txtStyle" ></asp:TextBox>
                        </div>
                    </td>
                    <td>
                        <div>
                            <asp:Label ID="lblFileType" runat="server" Text="نوع الملف الطبي:" CssClass="labelStyle"></asp:Label>
                        </div>
                        <div>
                            <asp:TextBox ID="txtFileType" runat="server" CssClass="txtStyle" ></asp:TextBox>
                        </div>
                    </td>
                    <td>
                        <div>
                            <asp:Label ID="lblWorkGroupCode" runat="server" Text="كود طاقم العمل:" CssClass="labelStyle"></asp:Label>
                        </div>
                        <div>
                            <asp:TextBox ID="txtWorkGroupCode" runat="server" CssClass="txtStyle" ></asp:TextBox>
                        </div>
                    </td>
                    <td>
                        <div>
                            <asp:Label ID="lblNeighbour" runat="server" Text="الحي:" CssClass="labelStyle"></asp:Label>
                        </div>
                        <div>
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlNeighbour" runat="server" AutoPostBack="true" CausesValidation="false" Width="60px">
                                        <asp:ListItem Text="-- إختر مدينة أولاً --" Value="0" />
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <%--<div>
                            <asp:Label ID="lblType" runat="server" Text="نوع الشريحة:" CssClass="labelStyle" Visible="False"></asp:Label>
                        </div>
                        <div>
                            <asp:DropDownList ID="ddlType" runat="server" AppendDataBoundItems="true" Visible="False">
                                <asp:ListItem Text="-- اختر نوع --" Value="" />
                            </asp:DropDownList>
                        </div>--%>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div>
                            <asp:Label ID="lblProfition" runat="server" Text="الوظيفة:" CssClass="labelStyle"></asp:Label>
                        </div>
                        <div>
                            <asp:TextBox ID="txtProfition" runat="server" CssClass="txtStyle" ></asp:TextBox>
                        </div>
                    </td>
                    <td>
                        <div>
                            <asp:Label ID="lblCompanyName" runat="server" Text="جهة العمل:" CssClass="labelStyle"></asp:Label>
                        </div>
                        <div>
                            <asp:TextBox ID="txtCompanyName" runat="server" CssClass="txtStyle" ></asp:TextBox>
                        </div>
                    </td>
                    <td>
                        <div>
                            <asp:Label ID="lblAccNo" runat="server" Text="رقم الحساب:" CssClass="labelStyle"></asp:Label>
                        </div>
                        <div>
                            <asp:TextBox ID="txtAccNo" runat="server" CssClass="txtStyle" ></asp:TextBox>
                        </div>
                    </td>
                    <td>
                        <div>
                            <asp:Label ID="lblRegBy" runat="server" Text="سجل بواسطة:" CssClass="labelStyle"></asp:Label>
                        </div>
                        <div>
                            <asp:TextBox ID="txtRegBy" runat="server" CssClass="txtStyle" ReadOnly="true" ></asp:TextBox>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div class="Save">
                            <asp:Button ID="btnProceed" runat="server" Text="حفظ" CssClass="buttons" OnClick="btnProceed_Click" />
                        </div>
                    </td>
                </tr>
            </table>
            <div class="insin">
            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                <ContentTemplate>
                    <asp:Label ID="lblInsCardNo" runat="server" Text="رقم البطاقة" CssClass="labelStyle"></asp:Label>
                    <asp:TextBox ID="txtInsCardNo" runat="server" Width="120px" AutoPostBack="True" TextMode="Number"></asp:TextBox>

                    <asp:Label ID="lblIns" runat="server" Text="التأمين" CssClass="labelStyle"></asp:Label>
                    <asp:TextBox ID="txtIns" runat="server" Width="80px" AutoPostBack="True" OnTextChanged="txtIns_TextChanged" TextMode="Number"></asp:TextBox>
                    <asp:DropDownList ID="ddlIns" runat="server" Width="170px" DataSourceID="SqlDataSource5" DataTextField="Name" DataValueField="IID" AutoPostBack="True" OnSelectedIndexChanged="ddlIns_SelectedIndexChanged" AppendDataBoundItems="true">
                        <asp:ListItem Text="-- اختر فئة --" Value="0" />
                    </asp:DropDownList>
                    <asp:SqlDataSource runat="server" ID="SqlDataSource5" ConnectionString='<%$ ConnectionStrings:DefaultConnection %>' SelectCommand="select IID,Name from Insurance"></asp:SqlDataSource>

                    <asp:Label ID="lblInsClass" runat="server" Text="نوع التأمين" CssClass="labelStyle"></asp:Label>
                    <asp:TextBox ID="txtInsClass" runat="server" Width="80px" AutoPostBack="True" OnTextChanged="txtInsClass_TextChanged" TextMode="Number"></asp:TextBox>
                    <asp:DropDownList ID="ddlInsClass" runat="server" Width="170px" DataSourceID="SqlDataSource9" DataTextField="Name" DataValueField="ITID" AutoPostBack="True" OnSelectedIndexChanged="ddlInsClass_SelectedIndexChanged" AppendDataBoundItems="true">
                        <asp:ListItem Text="-- اختر فئة --" Value="0" />
                    </asp:DropDownList>
                    <asp:SqlDataSource runat="server" ID="SqlDataSource9" ConnectionString='<%$ ConnectionStrings:DefaultConnection %>' SelectCommand="select ITID,(Type+' '+Class) as Name from InsuranceType"></asp:SqlDataSource>

                    <asp:Label ID="lblAppLim" runat="server" Text="الحد الاقصى" CssClass="labelStyle"></asp:Label>
                    <asp:TextBox ID="txtAppLim" runat="server" Width="60px" AutoPostBack="True" TextMode="Number"></asp:TextBox>

                    <asp:Label ID="lblExpIns" runat="server" Text="تاريخ الانتهاء:" CssClass="labelStyle"></asp:Label>
                    <asp:TextBox ID="txtExpIns" runat="server" CssClass="txtDate" TextMode="Date"></asp:TextBox>
                
                    <asp:FileUpload ID="FileUpload2" onchange="readURL1(this)" Class="sele" runat="server" />
                    <img id="imge1" src="#" class="idimg" alt="" width="100" height="100" />
                </ContentTemplate>
            </asp:UpdatePanel>
                
            </div>
            <%--<script>
                $('MainContent_ddlPType').onchange(function () {
                    if ($('MainContent_ddlPType').val == "1") {
                        $('.insin').hide();
                    } else {
                        $('.insin').show();
                    }
                });
            </script>--%>
            <div class="Insurance">
                <div class="subject">
                    <asp:Label ID="lblKind" runat="server" Text="التأمين"></asp:Label>
                </div>
                <div class="details">
                    <table>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblIID" runat="server" Text=" Insurance: "></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="IID" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblCardNo" runat="server" Text=" Card Number: "></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="CardNo" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblExp" runat="server" Text=" Expire at: "></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Exp" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Image ID="imageInsurance" runat="server" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
        <!-- On Page Scripts -->
        <asp:SqlDataSource runat="server" ID="SqlDataSource3" ConnectionString='<%$ ConnectionStrings:DefaultConnection %>' SelectCommand="SELECT [Id], [ArName],[flag] FROM [Countries]"></asp:SqlDataSource>
        
        <script type="text/javascript">
            $('#datetimepicker').datetimepicker({
                pickTime: false,
                format: "dd / MM / yyyy",
                endDate: new Date()
            });
            $('#datetimepicker2').datetimepicker({
                pickTime: false,
                format: "dd / MM / yyyy",
                endDate: new Date()
            });
            
            $('#timepicker').datetimepicker({
                pickDate: false,
                format: "HH:mm PP",
                pick12HourFormat: true,
                pickSeconds: false
            });
        </script>
        <script type="text/javascript">
            $(document).ready(function () {
                $("input").on("keypress", function (e) {
                    if (e.keyCode === 13) {
                        $(this).next("input").focus();
                    }
                });
            });
        </script>

        

    </div>

    <script>
        $(document).ready(function () {
            $('#datetimepicker2').on('changeDate', function (e) {
                var dob = new Date(e.date.toString());
                var today = new Date();
                var age = Math.floor((today - dob) / (365.25 * 24 * 60 * 60 * 1000));
                $('#MainContent_txtAge').val(age);


                function gmod(n, m) {
                    return ((n % m) + m) % m;
                }

                function kuwaiticalendar(adjust) {
                    var today = new Date();
                    if (adjust) {
                        adjustmili = 1000 * 60 * 60 * 24 * adjust;
                        todaymili = today.getTime() + adjustmili;
                        today = new Date(todaymili);
                    }
                    day = dob.getDate();
                    month = dob.getMonth();
                    year = dob.getFullYear();
                    m = month + 1;
                    y = year;
                    if (m < 3) {
                        y -= 1;
                        m += 12;
                    }

                    a = Math.floor(y / 100.);
                    b = 2 - a + Math.floor(a / 4.);
                    if (y < 1583) b = 0;
                    if (y == 1582) {
                        if (m > 10) b = -10;
                        if (m == 10) {
                            b = 0;
                            if (day > 4) b = -10;
                        }
                    }

                    jd = Math.floor(365.25 * (y + 4716)) + Math.floor(30.6001 * (m + 1)) + day + b - 1524;

                    b = 0;
                    if (jd > 2299160) {
                        a = Math.floor((jd - 1867216.25) / 36524.25);
                        b = 1 + a - Math.floor(a / 4.);
                    }
                    bb = jd + b + 1524;
                    cc = Math.floor((bb - 122.1) / 365.25);
                    dd = Math.floor(365.25 * cc);
                    ee = Math.floor((bb - dd) / 30.6001);
                    day = (bb - dd) - Math.floor(30.6001 * ee);
                    month = ee - 1;
                    if (ee > 13) {
                        cc += 1;
                        month = ee - 13;
                    }
                    year = cc - 4716;


                    wd = gmod(jd + 1, 7) + 1;

                    iyear = 10631. / 30.;
                    epochastro = 1948084;
                    epochcivil = 1948085;

                    shift1 = 8.01 / 60.;

                    z = jd - epochastro;
                    cyc = Math.floor(z / 10631.);
                    z = z - 10631 * cyc;
                    j = Math.floor((z - shift1) / iyear);
                    iy = 30 * cyc + j;
                    z = z - Math.floor(j * iyear + shift1);
                    im = Math.floor((z + 28.5001) / 29.5);
                    if (im == 13) im = 12;
                    id = z - Math.floor(29.5001 * im - 29);

                    var myRes = new Array(8);

                    myRes[0] = day; //calculated day (CE)
                    myRes[1] = month - 1; //calculated month (CE)
                    myRes[2] = year; //calculated year (CE)
                    myRes[3] = jd - 1; //julian day number
                    myRes[4] = wd - 1; //weekday number
                    myRes[5] = id; //islamic date
                    myRes[6] = im - 1; //islamic month
                    myRes[7] = iy; //islamic year

                    return myRes;
                }
                
                function writeIslamicDate(adjustment) {
                    //English Mode:
                    //var wdNames = new Array("Ahad", "Ithnin", "Thulatha", "Arbaa", "Khams", "Jumuah", "Sabt");
                    //var iMonthNames = new Array("Muharram", "Safar", "Rabi'ul Awwal", "Rabi'ul Akhir",
                    //    "Jumadal Ula", "Jumadal Akhira", "Rajab", "Sha'ban",
                    //    "Ramadan", "Shawwal", "Dhul Qa'ada", "Dhul Hijja");

                    //Arabic Mode:
                    //var wdNames = new Array("الأحد", "الإثنين", "الثلاثاء", "الأربعاء", "الخميس", "الجمعة", "السبت");
                    //var iMonthNames = new Array("محرم", "صفر", "ربيع الأول", "ربيع الاخر",
                    //    "جمادى الأول", "جمادى الاخر", "رجب", "شعبان",
                    //    "رمضان", "شوال", "ذو القعدة", "ذو الحجة");

                    //Numiric Mode:
                    var iMonthNames = new Array("/ 1 /", "/ 2 /", "/ 3 /", "/ 4 /",
                        "/ 5 /", "/ 6 /", "/ 7 /", "/ 8 /",
                        "/ 9 /", "/ 10 /", "/ 11 /", "/ 12 /");

                    var iDate = kuwaiticalendar(adjustment);
                    var outputIslamicDate = //wdNames[iDate[4]] + ", " +
                        iDate[5] + " " + iMonthNames[iDate[6]] + " " + iDate[7] + " هـ";
                    return outputIslamicDate;
                }
                $('#MainContent_TextBox3').val(writeIslamicDate(4));
            });

        });
    </script>
    <script>
        function readURL(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#imge').attr('src', e.target.result);
                }

                reader.readAsDataURL(input.files[0]);
            }
        }
        $("#MainContent_FileUpload1").change(function () {
            readURL(this);
        });
        function readURL1(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#imge1').attr('src', e.target.result);
                }

                reader.readAsDataURL(input.files[0]);
            }
        }
        $("#MainContent_FileUpload2").change(function () {
            readURL1(this);
        });
    </script>
</asp:Content>
