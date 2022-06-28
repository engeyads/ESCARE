<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Resiept.aspx.cs" Inherits="ESCARE.Receipt" %>

<!DOCTYPE html><html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
    <title></title>
        <link href="CSS/StyleSheet2.css" rel="stylesheet" />
        <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
  <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
  <script>
  $( function() {
    var availableTags = [
      
    ];
    $( "#TextBox1" ).autocomplete({
      source: availableTags
    });
  } );
  </script>
    </head>
    <body>
    <form id="form1" runat="server">
    <div id="wrapper">
        <asp:Label ID="lblPName" runat="server" Text="Search Patient File"></asp:Label>
        <asp:TextBox ID="txtPID" runat="server" OnTextChanged="txtPID_TextChanged" Width="150px"></asp:TextBox>
        <asp:Button ID="btnSrch" runat="server" OnClick="Button1_Click" Text="Search" />
        <asp:RadioButtonList ID="rbgSearchBy" runat="server">
            <asp:ListItem Selected="True" Value="0">By Patient ID / Passport</asp:ListItem>
            <asp:ListItem Value="1">By Patient Mobile</asp:ListItem>
            <asp:ListItem Value="2">By Patient Name</asp:ListItem>
        </asp:RadioButtonList>
        <asp:Label ID="lblmsg" runat="server" Text=""></asp:Label>
        <asp:GridView ID="gvPList" onselectedindexchanged="gvPList_SelectedIndexChanged" runat="server" AllowSorting="True" AutoGenerateEditButton="True" AutoGenerateSelectButton="True" CellPadding="4" ForeColor="#333333" GridLines="None" Width="494px" Height="180px">
            <AlternatingRowStyle BackColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" BorderColor="#3399FF" BorderStyle="Inset" Font-Bold="True" ForeColor="White" Height="20px" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" Height="20px" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
        <asp:Label ID="lblKind" runat="server" Text="Service Type: "></asp:Label>
        <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="Name" DataValueField="KID">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Hospital %>" SelectCommand="SELECT [KID], ([Name]+' '+ [ArName]) AS Name FROM [ServiceKind]"></asp:SqlDataSource>
        <asp:Label ID="lblServ" runat="server" Text="Service: "></asp:Label>
        <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="SqlDataSource2" DataTextField="Name" DataValueField="SID" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
            <asp:ListItem Value="0">Select Service...</asp:ListItem>
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Hospital %>" SelectCommand="select SID, Name+' '+ArName AS Name from Services"></asp:SqlDataSource>

        <asp:Label ID="lblPrice" runat="server" Text="Price: "></asp:Label>

        <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
        <asp:Button ID="btnProceed" runat="server" Text="Search Available Doctor" OnClick="btnProceed_Click" />
        

        <br />
        <asp:GridView ID="grdDoc" runat="server" AllowSorting="True" AutoGenerateEditButton="True" AutoGenerateSelectButton="True" CellPadding="4" ForeColor="#333333" GridLines="None" Width="494px" Height="180px">
            <AlternatingRowStyle BackColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" BorderColor="#3399FF" BorderStyle="Inset" Font-Bold="True" ForeColor="White" Height="20px" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" Height="20px" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
        <asp:Button ID="btnRecipe" runat="server" Text="Print Recipe" OnClick="btnRecipe_Click" />

    </div>
    </form>
</body>
</html>
