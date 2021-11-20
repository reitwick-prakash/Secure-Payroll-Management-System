<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="payslip.aspx.cs" Inherits="Payroll_Sys.payslip" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Payslip</title>
    <script src="Scripts/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="breadcrumb">
            <div class="container">
                <h1>Payroll</h1>

            </div>
            <asp:DropDownList runat="server" ID="emp" DataSourceID="SqlDataSource1" DataTextField="UserName" DataValueField="Id" AutoPostBack="true">
            </asp:DropDownList>

            <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:DefaultConnection %>' SelectCommand="SELECT * FROM [AspNetUsers]"></asp:SqlDataSource>
        
        <asp:GridView runat="server" DataSourceID="SqlDataSource2" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName"></asp:BoundField>
                <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName"></asp:BoundField>
                <asp:BoundField DataField="Salary" HeaderText="Salary" SortExpression="Salary"></asp:BoundField>
                <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email"></asp:BoundField>
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource runat="server" ID="SqlDataSource2" ConnectionString='<%$ ConnectionStrings:DefaultConnection %>' SelectCommand="SELECT [FirstName], [LastName], [Salary], [Email] FROM [AspNetUsers] WHERE ([Id] = @Id)">
            <SelectParameters>
                <asp:ControlParameter ControlID="emp" PropertyName="SelectedValue" Name="Id" Type="String"></asp:ControlParameter>
            </SelectParameters>
        </asp:SqlDataSource>
            
    </div>
        <asp:Button Text="Generate Payslip" runat="server" OnClick="Unnamed2_Click" />
    </form>
</body>
</html>
