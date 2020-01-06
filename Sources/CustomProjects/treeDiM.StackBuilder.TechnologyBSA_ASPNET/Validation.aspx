<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Validation.aspx.cs" Inherits="Validation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            height: 11px;
            width: 65px;
        }
        .auto-style3 {
            width: 150px;
        }
        .auto-style4 {
            text-align: right;
        }
        .border {
            border: solid 8px;
            color: lightblue;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:UpdatePanel ID="loadedPallet" runat="server" UpdateMode="Conditional">

            </asp:UpdatePanel>
             <table class="auto-style1">
                 <tr>

                 </tr>
             </table>
        </div>
    </form>
</body>
</html>
