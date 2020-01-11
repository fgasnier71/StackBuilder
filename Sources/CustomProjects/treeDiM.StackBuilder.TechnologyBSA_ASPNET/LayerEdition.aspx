<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LayerEdition.aspx.cs" Inherits="LayerEdition" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1{
            width: 100%;
        }
        .auto-style5 {
            text-align: center;
        }
        .auto-style6 {
            text-align: right;
            width: 49px;
        }
        .auto-style8 {
            width: 317px;
        }
        .auto-style9 {
            text-align: right;
            width: 388px;
        }
        .auto-style10 {
            width: 49px;
        }
        .auto-style11 {
            text-align: center;
            width: 70px;
        }
        .auto-style12 {
            width: 53px;
        }
        .auto-style13 {
            width: 388px;
        }
    </style>
    <script>

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="pageUpdate" runat="server" EnablePartialRendering="true"></asp:ScriptManager>
        <asp:UpdatePanel ID="layerImage" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
            <ContentTemplate>
                <div>
                    <table class="auto-style1">
                        <tr>
                            <td colspan="7" class="auto-style5">
                                <asp:ImageButton ID="IBLayer"
                                    runat="server"
                                    Height="500px" Width="500px"
                                    alt="Dynamic Image" OnClick="OnIBLayerClicked"/>
                            </td>
                        </tr>
                        <tr>
                            <td />
                            <td class="auto-style13" />
                            <td class="auto-style10" />
                            <td class="auto-style11"> <asp:ImageButton ID="ButtonUpMost" runat="server" Width="32px" Text="To Top" Height="32px" ImageUrl="~/Images/ArrowUp.png" OnClick="OnArrowClicked" /></td>
                            <td class="auto-style12" />
                            <td />
                            <td />
                        </tr>
                        <tr>
                            <td />
                            <td class="auto-style13" />
                            <td class="auto-style10" />
                            <td class="auto-style11"><asp:ImageButton ID="ButtonUp" runat="server" Width="32px" Text="To Top" Height="32px" ImageUrl="~/Images/ArrowUp.png" OnClick="OnArrowClicked" /></td>
                            <td class="auto-style12" />
                            <td />
                            <td />
                        </tr>
                        <tr>
                            <td />
                            <td class="auto-style9"><asp:ImageButton ID="ButtonLeftMost" runat="server" Width="32px" Text="To Top" Height="32px" ImageUrl="~/Images/ArrowLeft.png" OnClick="OnArrowClicked" /></td>
                            <td class="auto-style6"><asp:ImageButton ID="ButtonLeft" runat="server" Width="32px" Text="To Top" Height="32px" ImageUrl="~/Images/ArrowLeft.png" OnClick="OnArrowClicked" /></td>
                            <td class="auto-style11"><asp:ImageButton ID="ButtonRotate" runat="server" Width="32px" Text="To Top" Height="32px" ImageUrl="~/Images/ArrowRotate.png" OnClick="OnArrowClicked" /></td>
                            <td class="auto-style12"><asp:ImageButton ID="ButtonRight" runat="server" Width="32px" Text="To Top" Height="32px" ImageUrl="~/Images/ArrowRight.png" OnClick="OnArrowClicked" /></td>
                            <td><asp:ImageButton ID="ButtonRightMost" runat="server" Width="32px" Text="To Top" Height="32px" ImageUrl="~/Images/ArrowRight.png" OnClick="OnArrowClicked" /></td>
                            <td />
                        </tr>
                        <tr>
                            <td />
                            <td class="auto-style13" />
                            <td class="auto-style10" />
                            <td class="auto-style11"><asp:ImageButton ID="ButtonDown" runat="server" Width="32px" Text="To Top" Height="32px" ImageUrl="~/Images/ArrowDown.png" OnClick="OnArrowClicked" /></td>
                            <td class="auto-style12" />
                            <td />
                            <td />
                        </tr>
                        <tr>
                            <td />
                            <td class="auto-style13" />
                            <td class="auto-style10" />
                            <td class="auto-style11"><asp:ImageButton ID="ButtonDownMost" runat="server" Width="32px" Text="To Top" Height="32px" ImageUrl="~/Images/ArrowDown.png" OnClick="OnArrowClicked" /></td>
                            <td class="auto-style12" />
                            <td />
                            <td />
                        </tr>
                    </table>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div>
        </div>
    </form>
</body>
</html>
