<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MedicalReport.aspx.cs" Inherits="ESCARE.MedicalReport" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script type = "text/javascript">
        function Confirm() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Do you want to save data?")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }
    </script>
    <div class="jumbotron">
    <div id="wrapper">
        Patient:
        <asp:TextBox ID="txtPID" runat="server"  Width="150px" Enabled="False"></asp:TextBox>
       
        <br />

        <asp:Label ID="lblMedicalReport" runat="server" Text="Report: "></asp:Label>
        <asp:TextBox ID="txtMedicalReport" runat="server" Height="145px" TextMode="MultiLine" Width="584px" OnTextChanged="txtMedicalReport_TextChanged" ></asp:TextBox>
        <br />
        <asp:Label ID="lblMedic" runat="server" Text="Medicine:"></asp:Label>
        <br />
        
            
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                
                <asp:gridview ID="Gridview1" runat="server" ShowFooter="true" AutoGenerateColumns="false">
            <Columns>
            <asp:BoundField DataField="RowNumber" HeaderText="Row Number" />
            <asp:TemplateField HeaderText="Medicine Name">
                <ItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Times">
                <ItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="How To Use">
                <ItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Quantity">
                <ItemTemplate>
                     <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                </ItemTemplate>
                <FooterStyle HorizontalAlign="Right" />
                <FooterTemplate>
                 <asp:Button ID="ButtonAdd" runat="server" Text="Add New Row" 
                        onclick="ButtonAdd_Click" />
                </FooterTemplate>
            </asp:TemplateField>
            </Columns>
        </asp:gridview>

                <br />
                
                <asp:Button ID="btnPrintReport" runat="server" Text="Print Report" OnClick="btnPrintReport_Click"  />
                <asp:Button ID="btnPrintMidic" runat="server" Text="Print Medicice" OnClick="btnPrintMidic_Click"  />
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:Button ID="btnDone" runat="server" Text="Done" OnClick="btnDone_Click" OnClientClick = "Confirm()" />
        

        <br />
    </div>
        </div>
    <div class="row">
    </div>
    <asp:HiddenField ID="HiddenField1" runat="server" />
</asp:Content>
