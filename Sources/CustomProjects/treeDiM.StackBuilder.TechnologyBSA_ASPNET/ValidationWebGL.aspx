<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ValidationWebGL.aspx.cs" Inherits="Validation" %>

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
    <script type="text/javascript" src="javascript/jquery1.11.0.min.js"></script>
    <script type="text/javascript" src="javascript/jquery.plugin.min.js"></script>
    <script type="text/javascript" src="javascript/jquery.keypad.js"></script>
    <script type="text/javascript" src="javascript/three.min.js"></script>
    <script type="text/javascript" src="javascript/three-gltf-loader.min.js"></script>
    <script type="text/javascript" src="javascript/model-element.min.js"></script>
        <script type="text/javascript">
            function updateStyles() {
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

    <script type="text/javascript">
        function ActivateVirtualKeyboard() {
            $('#TBFileName').keypad({ keypadOnly: true, layout: $.keypad.qwertyLayout });
        }
    </script>
    <link type="text/css" href="css/jquery.keypad.css" rel="stylesheet" />
    <link type="text/css" href="css/default.css" rel="stylesheet" />
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
                                <table>
                                    <tr>
                                        <td style="height: 400px; width: 300px; overflow: hidden">
                                            <div id="XModelDiv" class="wrap" runat="server">
                                                <x-model id="XMODEL" class="x-model" src="./Output/Analysis.glb" />
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <input class="property__input" id="rotateZ" type="range" min="0" max="359" value="45" oninput="updateStyles()">
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td colspan="2" class="auto-style3">
                                <asp:Panel ID="PanelLayerOrientation" runat="server" GroupingText="Alternate layer orientation" Width="100%" BorderColor="LightGray" BackColor="Transparent">
                                    <table class="style100pct">
                                        <tr>
                                            <td>
                                                <asp:CheckBox ID="ChkbMirrorLength" runat="server" OnCheckedChanged="OnInputChanged" AutoPostBack="true" CssClass="checkbox" Width="25px" />
                                            </td>
                                            <td>
                                                <asp:Image ID="IMGMirrorLength" runat="server" ImageUrl="Images/MirrorLength.png" />
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="ChkbMirrorWidth" runat="server" OnCheckedChanged="OnInputChanged" AutoPostBack="true" CssClass="checkbox" Width="25px" />
                                            </td>
                                            <td>
                                                <asp:Image ID="IMGMirrorWidth" runat="server" ImageUrl="Images/MirrorWidth.png" />
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <br />
                                <asp:Panel ID="PanelInterlayer" runat="server" GroupingText="Interlayers" Width="100%" BorderColor="LightGray" BackColor="Transparent">
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:CheckBox ID="ChkbInterlayerBottom" runat="server" Text="Bottom" OnCheckChanged="OnInputChanged" AutoPostBack="true" CssClass="checkbox" />
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="ChkbInterlayersIntermediate" runat="server" Text="Intermediate" OnCheckChanged="OnInputChanged" AutoPostBack="true" CssClass="checkbox" />
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="ChkbInterlayerTop" runat="server" Text="Top" OnCheckChanged="OnInputChanged" AutoPostBack="true" CssClass="checkbox" />
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </td>
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
                            <td>
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
