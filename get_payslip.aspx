<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="get_payslip.aspx.cs" Inherits="Payroll_Sys.get_payslip" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Payslip</title>
    <script src="Scripts/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="breadcrumb">
                <h1>Payroll for Employee <%=Session["Firstname"] %></h1>
        </div>
            <div>
                <label><%=DateTime.Today %></label><br />
                <h3> Email- <b><%=Session["Firstname"] %></b></h3>

                <div class="row">
                    <div class="col-lg-6">
                        Final Pay
                    </div>

                    <div class="col-lg-6">
                        Gross Salary 
                    </div>                    
                    <div class="col-lg-6">
                        <%--<%=double.Parse(Session["basic"].ToString())-double.Parse(Session["tax"].ToString())%>--%>
                        <%=Session["Salary"] %>
                    </div>

                </div>
                    <button title="Print" onclick="printtopdf()">Print</button>
                    <script type="text/javascript"> 
                        function printtopdf() {
                            window.print();
                        }
                    </script>
            </div>
        </div>

    </form>

</body>
</html>
