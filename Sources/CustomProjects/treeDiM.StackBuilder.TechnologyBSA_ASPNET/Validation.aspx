<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Validation.aspx.cs" Inherits="treeDiM.StackBuilder.TechnologyBSA_ASPNET.Validation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 550px;
            text-align: center;
        }
        .auto-style3 {
            width: 500px;
            text-align: left;
        }
        .auto-style4 {
            text-align: right;
        }
        .border {
            border: solid 8px;
            color: lightblue;
        }
        .auto-style5 {
            text-align: left;
        }

        .auto-style6 {
        }

        .auto-style7 {
            text-align: right;
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
            $('#TBFileName').keyboard({ layout: 'qwerty' }).addTyping();
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
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="div980x780">
            <asp:ScriptManager ID="pageUpdates" runat="server" EnablePartialRendering="true"></asp:ScriptManager>
            <asp:UpdatePanel ID="loadedPallet" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <table class="style100pct">
                        <tr>
                            <td colspan="3" class="auto-style2">
                                <asp:Image ID="ImagePallet" runat="server" Height="550px" Width="550px" alt="Dynamic Image" ImageAlign="Middle" />
                            </td>
                            <td colspan="2" class="auto-style3">
                                <asp:Panel ID="PanelLayerOrientation" runat="server" GroupingText="Alternate layer orientation" Width="100%" BorderColor="LightGray" BackColor="Transparent">
                                    <table class="style100pct">
                                        <tr>
                                            <td>
                                                <asp:CheckBox ID="ChkbMirrorLength" runat="server" OnCheckedChanged="OnInputChanged" AutoPostBack="true"/>
                                                <span class="slider round" />
                                            </td>
                                            <td>
                                                <asp:Image ID="IMGMirrorLength" runat="server" ImageUrl="Images/MirrorLength.png" />
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="ChkbMirrorWidth" runat="server" OnCheckedChanged="OnInputChanged" AutoPostBack="true"/>
                                                <span class="custom-slider round" />
                                            </td>
                                            <td>
                                                <asp:Image ID="IMGMirrorWidth" runat="server" ImageUrl="Images/MirrorWidth.png" />
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <br />
                                <asp:Panel ID="PanelInterlayer" runat="server" GroupingText="Interlayers" Width="100%" BorderColor="LightGray" BackColor="Transparent">
                                    <div style="height:300px; overflow:scroll">
                                        <asp:ListView ID="LVInterlayers" runat="server">
                                            <LayoutTemplate>
                                                <table id="tableInterlayers" runat="server">
                                                    <tr id="itemPlaceholder" runat="server"/>
                                                </table>
                                            </LayoutTemplate>
                                            <ItemTemplate>
                                                <tr id="ITInterlayer" runat="server">
                                                    <td id="td1" runat="server">
                                                        <asp:Label ID="LayerLabel" Text='<%#Eval("Name") %>' Width="100px" runat="server" CssClass="labelRight"/>
                                                    </td>
                                                    <td id="td2" runat="server">
                                                        <label class="switch">
                                                            <asp:CheckBox ID="LayerCheckBox" AutoPostBack="true" Checked='<%#Eval("Activated") %>' runat="server"/>
                                                            <span class="slider round"/>
                                                        </label>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:ListView>
                                    </div>
                                </asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="bnDecrement" CssClass="buttonInc" runat="server" OnClick="AngleIncrement" Style="background-image: url('Images/left.png'); background-repeat: no-repeat" />
                            </td>
                            <td/>
                            <td class="styleTextAlignRight">
                                <asp:Button ID="bnIncrement" CssClass="buttonInc" runat="server" OnClick="AngleDecrement" Style="background-image: url('Images/right.png'); background-repeat: no-repeat" />
                            </td>
                            <td class="auto-style6"></td>
                            <td class="auto-style6"></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="BTPrev" runat="server" Text="&lt; Previous" CssClass="buttonPrev" OnClick="OnPrevious" />
                            </td>
                            <td />
                            <td class="styleTextAlignRight">
                                <asp:Label ID="lbFileName" runat="server" Text="File name" CssClass="labelRight" />
                            </td>
                            <td class="auto-style4">
                                <asp:TextBox ID="TBFileName" runat="server" Width="100%" CssClass="textbox" />
                            </td>
                            <td >
                                <asp:Button ID="btExport" runat="server" OnClick="OnExport" Text="Export" CssClass="button" Style="background-image: url('Images/Export.png'); background-repeat: no-repeat" />
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>

    </form>
</body>
</html>
