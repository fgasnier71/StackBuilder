<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="treeDiM.StackBuilder.TechnologyBSA_ASPNET._Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link type="text/css" href="css/jquery.keypad.css" rel="stylesheet" />
    <link type="text/css" href="css/default.css" rel="stylesheet" />
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.0/jquery.min.js"></script>
    <script type="text/javascript" src="javascript/jquery.plugin.min.js"></script>
    <script type="text/javascript" src="javascript/jquery.keypad.js"></script>
    <script type="text/javascript">
        function ActivateVirtualKeyboard() {
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="div980x780">
            <table class="style100pct">
                <tr>
                    <td class="style250px">
                        <asp:Button ID="bnNew" CssClass ="buttonIntro" runat="server" Text="New project" OnClick="OnNewProject" Style="background-image:url('Images/Create.png'); background-repeat:no-repeat"/>
                    </td>
                    <td/>
                </tr>
                <tr>
                    <td class="style250px">
                        <asp:Button ID="bnOpen" CssClass ="buttonIntro" runat="server" Text="Open project" OnClick="OnOpenProject" Style="background-image:url('Images/open.png'); background-repeat:no-repeat"/>
                    </td>
                    <td>
                        <asp:DropDownList ID="DropDownListFiles" CssClass="select" runat="server" Width="160px" Height="60px"/>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
