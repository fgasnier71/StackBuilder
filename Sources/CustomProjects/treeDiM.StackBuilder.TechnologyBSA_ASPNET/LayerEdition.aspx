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
                            <td class="auto-style11"> <asp:ImageButton ID="ButtonUpMost" runat="server" Width="32px" Text="To Top" Height="32px" ImageUrl="~/Images/ArrowUpBStop.png" OnClick="OnArrowMaxClicked" BorderStyle="Solid" BorderWidth="1px"/></td>
                            <td class="auto-style12" />
                            <td />
                            <td />
                        </tr>
                        <tr>
                            <td />
                            <td class="auto-style13" />
                            <td class="auto-style10" />
                            <td class="auto-style11"><asp:ImageButton ID="ButtonUp" runat="server" Width="32px" Text="To Top" Height="32px" ImageUrl="~/Images/ArrowUpB.png" OnClick="OnArrowClicked" BorderStyle="Solid" BorderWidth="1px"/></td>
                            <td class="auto-style12" />
                            <td />
                            <td />
                        </tr>
                        <tr>
                            <td />
                            <td class="auto-style9"><asp:ImageButton ID="ButtonLeftMost" runat="server" Width="32px" Text="To Top" Height="32px" ImageUrl="~/Images/ArrowLeftBStop.png" OnClick="OnArrowMaxClicked" BorderStyle="Solid" BorderWidth="1px" /></td>
                            <td class="auto-style6"><asp:ImageButton ID="ButtonLeft" runat="server" Width="32px" Text="To Top" Height="32px" ImageUrl="~/Images/ArrowLeftB.png" OnClick="OnArrowClicked" BorderStyle="Solid" BorderWidth="1px" /></td>
                            <td class="auto-style11"><asp:ImageButton ID="ButtonRotate" runat="server" Width="32px" Text="To Top" Height="32px" ImageUrl="~/Images/ArrowRotate.png" OnClick="OnRotateClicked" BorderStyle="Solid" BorderWidth="1px"/></td>
                            <td class="auto-style12"><asp:ImageButton ID="ButtonRight" runat="server" Width="32px" Text="To Top" Height="32px" ImageUrl="~/Images/ArrowRightB.png" OnClick="OnArrowClicked" BorderStyle="Solid" BorderWidth="1px"/></td>
                            <td><asp:ImageButton ID="ButtonRightMost" runat="server" Width="32px" Text="To Top" Height="32px" ImageUrl="~/Images/ArrowRightBStop.png" OnClick="OnArrowMaxClicked" BorderStyle="Solid" BorderWidth="1px"/></td>
                            <td />
                        </tr>
                        <tr>
                            <td />
                            <td class="auto-style13" />
                            <td class="auto-style10" />
                            <td class="auto-style11"><asp:ImageButton ID="ButtonDown" runat="server" Width="32px" Text="To Top" Height="32px" ImageUrl="~/Images/ArrowDownB.png" OnClick="OnArrowClicked" BorderStyle="Solid" BorderWidth="1px"/></td>
                            <td class="auto-style12" />
                            <td />
                            <td />
                        </tr>
                        <tr>
                            <td />
                            <td class="auto-style13" />
                            <td class="auto-style10" />
                            <td class="auto-style11"><asp:ImageButton ID="ButtonDownMost" runat="server" Width="32px" Text="To Top" Height="32px" ImageUrl="~/Images/ArrowDownBStop.png" OnClick="OnArrowMaxClicked" BorderStyle="Solid" BorderWidth="1px"/></td>
                            <td class="auto-style12" />
                            <td />
                            <td />
                        </tr>
                        <tr>
                            <td />
                            <td />
                            <td />
                            <td />
                            <td />
                            <td />
                            <td />
                        </tr>

                    </table>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
                    <table class="auto-style1">
                        <tr>
                            <td class="auto-style1" />
                            <asp:Button ID="bnPrev" runat="server" OnClick="OnPrevious" Text="&lt; Previous" Width="130px" />
                            <td class="auto-style1" />
                            <asp:Button ID="bnNext" runat="server" Text="Next &gt;" Width="130px" OnClick="OnNext" />
                        </tr>
                    </table>
                </ContentTemplate>


            </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>
