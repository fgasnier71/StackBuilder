<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LayerEdition.aspx.cs" Inherits="LayerEdition" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
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
    <link type="text/css" href="css/default.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="ex2">
            <asp:ScriptManager ID="pageUpdate" runat="server" EnablePartialRendering="true"></asp:ScriptManager>
            <asp:UpdatePanel ID="layerImage" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
                    <div>
                        <table class="style100pct">
                            <tr>
                                <td class="style500px" rowspan="6">
                                    <asp:ImageButton ID="IBLayer"
                                        runat="server"
                                        Height="500px" Width="500px"
                                        alt="Dynamic Image" OnClick="OnIBLayerClicked" />
                                </td>
                                <td class="auto-style50px" />
                                <td class="auto-style50px" />
                                <td class="auto-style50px">
                                    <asp:ImageButton ID="ButtonUpMost" runat="server" ImageUrl="~/Images/upMost.png" OnClick="OnArrowMaxClicked" CssClass="buttonInc" /></td>
                                <td class="auto-style50px" />
                                <td />
                                <td />
                            </tr>
                            <tr>
                                <td class="style50px" />
                                <td class="style50px" />
                                <td class="style50px">
                                    <asp:ImageButton ID="ButtonUp" runat="server" ImageUrl="~/Images/up.png" OnClick="OnArrowClicked" CssClass="buttonInc" /></td>
                                <td class="style50px" />
                                <td />
                                <td />
                            </tr>
                            <tr>
                                <td class="style50px">
                                    <asp:ImageButton ID="ButtonLeftMost" runat="server" ImageUrl="~/Images/leftMost.png" OnClick="OnArrowMaxClicked" CssClass="buttonInc" /></td>
                                <td class="style50px">
                                    <asp:ImageButton ID="ButtonLeft" runat="server" ImageUrl="~/Images/left.png" OnClick="OnArrowClicked" CssClass="buttonInc" /></td>
                                <td class="style50px">
                                    <asp:ImageButton ID="ButtonRotate" runat="server" ImageUrl="~/Images/ArrowRotate.png" OnClick="OnRotateClicked" CssClass="buttonInc" /></td>
                                <td class="style50px">
                                    <asp:ImageButton ID="ButtonRight" runat="server" ImageUrl="~/Images/right.png" OnClick="OnArrowClicked" CssClass="buttonInc" /></td>
                                <td class="style50px">
                                    <asp:ImageButton ID="ButtonRightMost" runat="server" ImageUrl="~/Images/rightMost.png" OnClick="OnArrowMaxClicked" CssClass="buttonInc" /></td>
                                <td />
                            </tr>
                            <tr>
                                <td class="style50px" />
                                <td class="style50px" />
                                <td class="style50px">
                                    <asp:ImageButton ID="ButtonDown" runat="server" ImageUrl="~/Images/down.png" OnClick="OnArrowClicked" CssClass="buttonInc" /></td>
                                <td class="style50px" />
                                <td />
                                <td />
                            </tr>
                            <tr>
                                <td class="style50px" />
                                <td class="style50px" />
                                <td class="style50px">
                                    <asp:ImageButton ID="ButtonDownMost" runat="server" ImageUrl="~/Images/downMost.png" OnClick="OnArrowMaxClicked" CssClass="buttonInc" /></td>
                                <td class="style50px" />
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
                            </tr>

                        </table>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <div>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
                    <ContentTemplate>
                        <table class="style100pct">
                            <tr>
                                <td class="style100pct"/>
                                &nbsp;
                                <td class="style100pct"/>
                                &nbsp;
                            </tr>
                            <tr>
                                <td class="style100pct" />
                                <asp:Button ID="bnPrev" runat="server" CssClass="buttonPrev" OnClick="OnPrevious" Text="&lt; Previous" />
                                <td class="style100pct" />
                                <asp:Button ID="bnNext" runat="server" CssClass="buttonNext" OnClick="OnNext" Text="Next &gt;" />
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </form>
</body>
</html>
