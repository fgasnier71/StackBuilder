<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

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
            width: 150px
        }
        .auto-style4 {
            text-align: right;
        }
    </style>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.0/jquery.min.js"></script>
    <link type="text/css" href="css/jquery.keypad.css" rel="stylesheet" />
    <script type="text/javascript" src="javascript/jquery.plugin.min.js"></script>
    <script type="text/javascript" src="javascript/jquery.keypad.js"></script>
    <script type="text/javascript">
        function ActivateVirtualKeyboard() {
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style3">
                        <asp:Button ID="bnNew" runat="server" Text="New project" Width="130px" OnClick="OnNewProject" />
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:Button ID="bnOpen" runat="server" Text="Open project" Width="130px" OnClick="OnOpenProject" />
                    </td>
                    <td>
                        <asp:DropDownList ID="DropDownListFiles" runat="server" Width="130px" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
