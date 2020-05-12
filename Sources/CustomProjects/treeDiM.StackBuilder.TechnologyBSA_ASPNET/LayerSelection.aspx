<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="~/Default.aspx.cs" CodeFile="~/LayerSelection.aspx.cs" Inherits="treeDiM.StackBuilder.TechnologyBSA_ASPNET._Default" EnableSessionState="True" %>
<%@ Import Namespace="treeDiM.StackBuilder.TechnologyBSA_ASPNET" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .border {
            border: solid 8px;
            color: lightblue;
        }
        .auto-style6 {
            height: 504px;
        }
    </style>
    <link type="text/css" href="css/default.css" rel="stylesheet" />
    <link href="css/jquery-ui.css" rel="stylesheet" />
    <link href="css/keyboard.css" rel="stylesheet" />
    <script type="text/javascript" src="javascript/jquery.min.js"></script>
    <script type="text/javascript" src="javascript/jquery-ui.min.js"></script>
    <script type="text/javascript" src="javascript/jquery.keyboard.js"></script>
    <script type="text/javascript" src="javascript/jquery.keyboard.extension-typing.js"></script>
    <script type="text/javascript">
        function ActivateVirtualKeyboard() {
            $('#TBCaseLength').keyboard({ layout: 'num', restrictInput: true, preventPaste: true, autoAccept: true }).addTyping();
            $('#TBCaseWidth').keyboard({ layout: 'num', restrictInput: true, preventPaste: true, autoAccept: true, accepted: function () { $('#BTRefresh').click(); } }).addTyping();
            $('#TBCaseHeight').keyboard({ layout: 'num', restrictInput: true, preventPaste: true, autoAccept: true, accepted: function () { $('#BTRefresh').click(); } }).addTyping();
            $('#TBPalletLength').keyboard({ layout: 'num', restrictInput: true, preventPaste: true, autoAccept: true, accepted: function () { $('#BTRefresh').click(); } }).addTyping();
            $('#TBPalletWidth').keyboard({ layout: 'num', restrictInput: true, preventPaste: true, autoAccept: true, accepted: function () { $('#BTRefresh').click(); } }).addTyping();
            $('#TBPalletHeight').keyboard({ layout: 'num', restrictInput: true, preventPaste: true, autoAccept: true, accepted: function () { $('#BTRefresh').click(); } }).addTyping();
            $('#TBPalletWeight').keyboard({ layout: 'num', restrictInput: true, preventPaste: true, autoAccept: true, accepted: function () { $('#BTRefresh').click(); } }).addTyping();
            $('#TBMaxPalletWeight').keyboard({ layout: 'num', restrictInput: true, preventPaste: true, autoAccept: true, accepted: function () { $('#BTRefresh').click(); } }).addTyping();
            /* Code to get jQuery UI to work with jQuery 3.4+ ... */
            $.isArray = function (a) {
                return Object.prototype.toString.call(a) === '[object Array]';
            }
            $.isFunction = function (f) {
                return typeof f === 'function';
            }
            $.isWindow = function (w) {
                var toString = Object.prototype.toString.call(w);
                return toString == '[object global]' ||
                    toString == '[object Window]' ||
                    toString == '[object DOMWindow]';
            }
        }
        function ScrollTo() {
            if ($('.border').length > 0) {
                $('div.liste').animate({ scrollLeft: $('.border').position().left - 20 }, 200);
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="div980x780">
            <asp:ScriptManager ID="pageUpdates" runat="server" EnablePartialRendering="true"></asp:ScriptManager>
            <asp:UpdatePanel ID="controlsInput" runat="server">
                <ContentTemplate>
                    <div>
                        <table class="style100pct">
                            <tr>
                                <td>
                                    <asp:label ID="LBCaseDim" runat="server" Text="Case dimensions" CssClass="label" />
                                </td>
                                <td class="style65px">
                                    <asp:TextBox ID="TBCaseLength" runat="server" Width="60px" CssClass="textbox"/>
                                </td>
                                <td class="style65px">
                                    <asp:TextBox ID="TBCaseWidth" runat="server" Width="60px" CssClass="textbox"/>
                                </td>
                                <td class="style65px">
                                    <asp:TextBox ID="TBCaseHeight" runat="server" Width="60px" CssClass="textbox"/>
                                </td>
                                <td class="style65px">
                                    <asp:Label ID="Label1" runat="server" Text="mm" CssClass="label"/>
                                </td>
                                <td>
                                    <asp:label ID="LBPalletDim" runat="server" Text="Pallet dimensions" CssClass="label" />
                                </td>
                                <td class="style65px">
                                    <asp:TextBox ID="TBPalletLength" runat="server" Width="60px" CssClass="textbox"/>
                                </td>
                                <td class="style65px">
                                    <asp:TextBox ID="TBPalletWidth" runat="server" Width="60px" CssClass="textbox"/>
                                </td>
                                <td class="style65px">
                                    <asp:TextBox ID="TBPalletHeight" runat="server" Width="60px" CssClass="textbox"/>
                                </td>
                                <td>
                                    <asp:Label ID="LBPalletDimUnit" runat="server" Text="mm" CssClass="label" />
                                <td />
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="LBCaseWeight" runat="server" Text="Case weight" CssClass="label"/>
                                </td>
                                <td>
                                    <asp:TextBox ID="TBCaseWeight" runat="server" Width="60px" CssClass="textbox"/>
                                </td>
                                <td />
                                <td />
                                <td>
                                    <asp:Label ID="LBCaseWeightUnit" runat="server" Text="kg" CssClass="label" />
                                </td>
                                <td>
                                    <asp:Label ID="LBPalletWeight" runat="server" Text="Pallet weight" CssClass="label"/>
                                </td>
                                <td>
                                    <asp:TextBox ID="TBPalletWeight" runat="server" Width="60px" CssClass="textbox"/>
                                </td>
                                <td />
                                <td />
                                <td>
                                    <asp:Label Id="LBPalletWeightUnit" runat="server" Text="kg" CssClass="label" />
                                </td>
                                <td/>
                            </tr>
                            <tr>
                                <td />
                                <td />
                                <td />
                                <td />
                                <td />
                                <td>
                                    <asp:Label ID="LBMaximumPalletHeight" runat="server" Text="Maximum Pallet Height" CssClass="label"/>
                                <td>
                                    <asp:TextBox ID="TBMaxPalletHeight" runat="server" Width="60px" CssClass="textbox"/>
                                </td>
                                <td />
                                <td />
                                <td>
                                    <asp:Label ID="LBMaxPalletHeightUnit" runat="server" Text="mm" CssClass="label"/>
                                </td>
                                <td>
                                    <asp:Button ID="BTRefresh" runat="server" Text="Refresh" OnClick="BTRefresh_Click" CssClass="buttonRefresh" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:UpdatePanel ID="layersUpdate" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
                    <div class="liste" style="margin: 0px; padding: 0px; border-style: solid; border-width: 1px; display: flex; overflow-x: auto; overflow-y: hidden; width: 100%; height: auto;">
                        <asp:ListView ID="dlLayers" CellSpacing="0" runat="server" OnItemCommand="OnLVLayersItemCommand">
                            <ItemTemplate>
                                <asp:ImageButton ID="Image1"
                                    runat="server"
                                    Height='<%# Unit.Parse(ConfigSettings.ThumbSize) %>'
                                    Width='<%# Unit.Parse(ConfigSettings.ThumbSize) %>'
                                    ImageUrl='<%# "HandlerLayerThumb.ashx?LayerDesc=" + Eval("LayerDesc") + "&Dimensions=" + Eval("Dimensions")%>'
                                    CommandName="ImageButtonClick"
                                    CommandArgument='<%# Eval("LayerDesc")%>' Style="flex: 0 0 auto;" />
                            </ItemTemplate>
                        </asp:ListView>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:UpdatePanel ID="selectedLayer" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <table class="style100pct">
                        <tr>
                            <td colspan="2">
                                <asp:Image ID="ImagePallet" runat="server" Height="460px" Width="500px" alt="Dynamic Image" />
                            </td>
                            <td colspan="2">
                                <asp:GridView ID="PalletDetails" runat="server" AllowPaging="false" BackColor="White" ForeColor="Black" BorderColor="Black"
                                    AutoGenerateColumns="false" Width="400px">
                                    <RowStyle Font-Names="Arial" Font-Size="16px" />
                                    <AlternatingRowStyle Font-Names="Arial" Font-Size="16px" BackColor="LightBlue" />
                                    <PagerStyle BackColor="LightGray" ForeColor="Black" />
                                    <HeaderStyle BackColor="LightGray" ForeColor="Black" CssClass="headercell"/>
                                    <Columns>
                                        <asp:BoundField DataField="Name" HeaderText="Name" ControlStyle-CssClass="stylefont" ItemStyle-Width="50%" ReadOnly="true" />
                                        <asp:BoundField DataField="ValueUnit" HeaderText="Value" ControlStyle-CssClass="stylefont" ItemStyle-Width="50%" />
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="bnDecrement" CssClass="buttonInc" runat="server" OnClick="AngleIncrement" Style="background-image:url('Images/left.png'); background-repeat:no-repeat"/>
                            </td>
                            <td class="styleTextAlignRight">
                                <asp:Button ID="bnIncrement" CssClass="buttonInc" runat="server" OnClick="AngleDecrement" Style="background-image:url('Images/right.png'); background-repeat:no-repeat"/>
                            </td>
                            <td  class="styleTextAlignRight">
                                <asp:Button ID="bnEditLayer" CssClass="button" runat="server" OnClick="OnEditLayer" Text="Edit layer" Style="background-image:url('Images/editlayer.png'); background-repeat:no-repeat" Width="150px" />
                            </td>
                            <td  class="styleTextAlignRight">
                                <asp:Button ID="bnNext" CssClass="buttonNext" runat="server" OnClick="OnNext" Text="Next &gt;" />
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>
