<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="~/LayerSelectionWebGL.aspx.cs" CodeFile="~/LayerSelectionWebGL.aspx.cs" Inherits="treeDiM.StackBuilder.TechnologyBSA_ASPNET.LayerSelectionWebGL" EnableSessionState="True" %>
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
        .auto-style1 {
            height: 28px;
        }
    </style>
    <link type="text/css" href="css/default.css" rel="stylesheet" />
    <link href="css/jquery-ui.css" rel="stylesheet" />
    <link href="css/keyboard.css" rel="stylesheet" />
    <script type="text/javascript" src="javascript/jquery.min.js"></script>
    <script type="text/javascript" src="javascript/jquery-ui.min.js"></script>
    <script type="text/javascript" src="javascript/jquery.keyboard.js"></script>
    <script type="text/javascript" src="javascript/jquery.keyboard.extension-typing.js"></script>
    <script type="text/javascript" src="javascript/three.min.js"></script>
    <script type="text/javascript" src="javascript/three-gltf-loader.min.js"></script>
    <script type="text/javascript" src="javascript/model-element.min.js"></script>
    <script type="text/javascript">
        function ActivateVirtualKeyboard() {
            $('#TBCaseLength').keyboard({ layout: 'num', restrictInput: true, preventPaste: true, autoAccept: true, accepted: function () { $('#BTRefresh').click(); } }).addTyping();
            $('#TBCaseWidth').keyboard({ layout: 'num', restrictInput: true, preventPaste: true, autoAccept: true, accepted: function () { $('#BTRefresh').click(); } }).addTyping();
            $('#TBCaseHeight').keyboard({ layout: 'num', restrictInput: true, preventPaste: true, autoAccept: true, accepted: function () { $('#BTRefresh').click(); } }).addTyping();
            $('#TBCaseWeight').keyboard({ layout: 'num', restrictInput: true, preventPaste: true, autoAccept: true, accepted: function () { $('#BTRefresh').click(); } }).addTyping();
            $('#TBPalletLength').keyboard({ layout: 'num', restrictInput: true, preventPaste: true, autoAccept: true, accepted: function () { $('#BTRefresh').click(); } }).addTyping();
            $('#TBPalletWidth').keyboard({ layout: 'num', restrictInput: true, preventPaste: true, autoAccept: true, accepted: function () { $('#BTRefresh').click(); } }).addTyping();
            $('#TBPalletHeight').keyboard({ layout: 'num', restrictInput: true, preventPaste: true, autoAccept: true, accepted: function () { $('#BTRefresh').click(); } }).addTyping();
            $('#TBPalletWeight').keyboard({ layout: 'num', restrictInput: true, preventPaste: true, autoAccept: true, accepted: function () { $('#BTRefresh').click(); } }).addTyping();
            $('#TBNumberOfLayers').keyboard({ layout: 'num', restrictInput: true, preventPaste: true, autoAccept: true, accepted: function () { $('#BTRefresh').click(); } }).addTyping();
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
    <script type="text/javascript">
        function updateStyles()
        {
            var css;
            if (!css) {
                css = document.createElement('style');
                document.body.appendChild(css);
            }
            let cssText = `
              x-model {
                width: 300px;
                height: 150px;
                transform: rotateX(60deg) rotateY(0deg) rotateZ(${rotateZ.value}deg);
              }`;
            css.textContent = cssText;
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
                                    <asp:Label ID="LBCaseDim" runat="server" Text="Case dimensions" CssClass="label" />
                                </td>
                                <td class="style65px">
                                    <asp:TextBox ID="TBCaseLength" runat="server" Width="60px" CssClass="textbox" />
                                </td>
                                <td class="style65px">
                                    <asp:TextBox ID="TBCaseWidth" runat="server" Width="60px" CssClass="textbox" />
                                </td>
                                <td class="style65px">
                                    <asp:TextBox ID="TBCaseHeight" runat="server" Width="60px" CssClass="textbox" />
                                </td>
                                <td class="style65px">
                                    <asp:Label runat="server" Text="mm" CssClass="label" />
                                </td>
                                <td>
                                    <asp:Label ID="LBPalletDim" runat="server" Text="Pallet dimensions" CssClass="label" />
                                </td>
                                <td class="style65px">
                                    <asp:DropDownList ID="DropDownPalletDim" runat="server" CssClass="select" OnSelectedIndexChanged="BTRefresh_Click" AutoPostBack="True">
                                        <asp:ListItem>1200x800</asp:ListItem>
                                        <asp:ListItem>1200x1000</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td class="style65px">
                                </td>
                                <td class="style65px">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;<td />
                            </tr>
                            <tr>
                                <td class="style65px">
                                    <asp:Label ID="LBCaseWeight" runat="server" Text="Case weight" CssClass="label" />
                                </td>
                                <td class="style65px">
                                    <asp:TextBox ID="TBCaseWeight" runat="server" Width="60px" CssClass="textbox" />
                                </td>
                                <td class="auto-style1" />
                                <td class="auto-style1" />
                                <td class="auto-style1">
                                    <asp:Label ID="LBCaseWeightUnit" runat="server" Text="kg" CssClass="label" />
                                </td>
                                <td class="auto-style1">
                                    <asp:Label ID="LBPalletWeight" runat="server" Text="Pallet weight" CssClass="label" />
                                </td>
                                <td class="auto-style1">
                                    <asp:TextBox ID="TBPalletWeight" runat="server" Width="60px" CssClass="textbox" />
                                </td>
                                <td class="auto-style1" />
                                <td class="auto-style1" />
                                <td class="auto-style1">
                                    <asp:Label ID="LBPalletWeightUnit" runat="server" Text="kg" CssClass="label" />
                                </td>
                                <td class="auto-style1" />
                            </tr>
                            <tr>
                                <td />
                                <td />
                                <td />
                                <td />
                                <td />
                                <td>
                                    <asp:Label ID="LBNumberOfLayers" runat="server" Text="Number of layers" CssClass="label" /></td>
                                <td>
                                    <asp:TextBox ID="TBNumberOfLayers" runat="server" Width="60px" CssClass="textbox" />
                                <td />
                                <td />
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:Button ID="BTRefresh" runat="server" Text="Refresh" OnClick="BTRefresh_Click" CssClass="buttonRefresh" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="11">
                                    <asp:CompareValidator ID="cvCaseLength" runat="server" ControlToValidate="TBCaseLength" ErrorMessage="Length < 50 not allowed." ForeColor="Red" Operator="GreaterThanEqual" ValueToCompare="50.0" Type="Double" Height="8px"></asp:CompareValidator>
                                    <asp:CompareValidator ID="cvCaseWidth" runat="server" ControlToValidate="TBCaseWidth" ErrorMessage="Width < 50 not allowed." ForeColor="Red" Operator="GreaterThanEqual" ValueToCompare="50.0" Type="Double" Height="8px"></asp:CompareValidator>
                                    <asp:CompareValidator ID="cvCaseHeight" runat="server" ControlToValidate="TBCaseHeight" ErrorMessage="Height < 50 not allowed." ForeColor="Red" Operator="GreaterThanEqual" ValueToCompare="50.0" Type="Double" Height="8px"></asp:CompareValidator>
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
                                    ImageUrl='<%# "HandlerLayerThumb.ashx?LayerDesc=" + Eval("LayerDesc") + "&Dimensions=" + Eval("Dimensions") + "&PalletIndex=" + Eval("PalletIndex")%>'
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
                                    <table>
                                        <tr>
                                            <td/>
                                            <td style="height: 400px; width:300px; overflow:hidden">
                                                <div id="XModelDiv" class="wrap" runat="server">
                                                    <x-model ID="XMODEL" class="x-model" src="./Output/Analysis.glb"/>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td/>
                                            <td>
                                                <input class="custom-slider" id="rotateZ" type="range" min="0" max="359" value="45" oninput="updateStyles()">
                                            </td>
                                        </tr>
                                    </table>
                            </td>
                            <td colspan="2">
                                <asp:GridView ID="PalletDetails" runat="server" AllowPaging="false" BackColor="White" ForeColor="Black" BorderColor="Black"
                                    AutoGenerateColumns="false" Width="400px">
                                    <RowStyle Font-Names="Arial" Font-Size="16px" />
                                    <AlternatingRowStyle Font-Names="Arial" Font-Size="16px" BackColor="LightBlue" />
                                    <PagerStyle BackColor="LightGray" ForeColor="Black" />
                                    <HeaderStyle BackColor="LightGray" ForeColor="Black" CssClass="headercell" />
                                    <Columns>
                                        <asp:BoundField DataField="Name" HeaderText="Name" ControlStyle-CssClass="stylefont" ItemStyle-Width="50%" ReadOnly="true" />
                                        <asp:BoundField DataField="ValueUnit" HeaderText="Value" ControlStyle-CssClass="stylefont" ItemStyle-Width="50%" />
                                    </Columns>
                                </asp:GridView>

                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td class="styleTextAlignRight">&nbsp;</td>
                            <td class="styleTextAlignRight">
                                <asp:Button ID="bnEditLayer" CssClass="button" runat="server" OnClick="OnEditLayer" Text="Edit layer" Style="background-image: url('Images/editlayer.png'); background-repeat: no-repeat" Width="150px" />
                            </td>
                            <td class="styleTextAlignRight">
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
