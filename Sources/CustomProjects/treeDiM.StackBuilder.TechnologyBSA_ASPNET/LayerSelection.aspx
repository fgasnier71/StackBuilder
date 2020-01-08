<<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="~/Default.aspx.cs" CodeFile="~/LayerSelection.aspx.cs" Inherits="_Default" EnableSessionState="True" %>
<!DOCTYPE html><html xmlns="http://www.w3.org/1999/xhtml"><head runat="server"><title></title><style type="text/css">
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
    <script type="text/javascript" src="javascript/jquery1.11.0.min.js"></script>
    <link type="text/css" href="css/jquery.keypad.css" rel="stylesheet" />
    <script type="text/javascript" src="javascript/jquery.plugin.min.js"></script>
    <script type="text/javascript" src="javascript/jquery.keypad.js"></script>
    <script type="text/javascript">
        function ActivateVirtualKeyboard() {
            $('#TBCaseLength').keypad({ keypadOnly: true, layout: $.keypad.numericLayout, onClose: function (value, inst) { $('#BTRefresh').click(); } });
            $('#TBCaseWidth').keypad({ keypadOnly: true, layout: $.keypad.numericLayout, onClose: function (value, inst) { $('#BTRefresh').click(); } });
            $('#TBCaseHeight').keypad({ keypadOnly: true, layout: $.keypad.numericLayout, onClose: function (value, inst) { $('#BTRefresh').click(); } });
            $('#TBCaseWeight').keypad({ keypadOnly: true, layout: $.keypad.numericLayout, onClose: function (value, inst) { $('#BTRefresh').click(); } });
            $('#TBPalletLength').keypad({ keypadOnly: true, layout: $.keypad.numericLayout, onClose: function (value, inst) { $('#BTRefresh').click(); } });
            $('#TBPalletWidth').keypad({ keypadOnly: true, layout: $.keypad.numericLayout, onClose: function (value, inst) { $('#BTRefresh').click(); } });
            $('#TBPalletHeight').keypad({ keypadOnly: true, layout: $.keypad.numericLayout, onClose: function (value, inst) { $('#BTRefresh').click(); } });
            $('#TBPalletWeight').keypad({ keypadOnly: true, layout: $.keypad.numericLayout, onClose: function (value, inst) { $('#BTRefresh').click(); } });
            $('#TBMaxPalletHeight').keypad({ keypadOnly: true, layout: $.keypad.numericLayout, onClose: function (value, inst) { $('#BTRefresh').click(); } });
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
        <asp:ScriptManager ID="pageUpdates" runat="server" EnablePartialRendering="true"></asp:ScriptManager>
        <asp:UpdatePanel ID="controlsInput" runat="server">
            <ContentTemplate>
                <div>
                    <table class="auto-style1">
                        <tr>
                            <td id="Label_CaseDim" class="auto-style3">Case dimensions</td>
                            <td class="auto-style2">
                                <asp:TextBox ID="TBCaseLength" runat="server" Width="60px"></asp:TextBox>
                            </td>
                            <td class="auto-style2">
                                <asp:TextBox ID="TBCaseWidth" runat="server" Width="60px"></asp:TextBox>
                            </td>
                            <td class="auto-style2">
                                <asp:TextBox ID="TBCaseHeight" runat="server" Width="60px"></asp:TextBox>
                            </td>
                            <td class="auto-style2">
                                <asp:Label ID="Label1" runat="server" Text="mm"></asp:Label>
                            </td>
                            <td id="Label_PalletDim" class="auto-style3">Pallet dimensions</td>
                            <td class="auto-style2">
                                <asp:TextBox ID="TBPalletLength" runat="server" Width="60px"></asp:TextBox>
                            </td>
                            <td class="auto-style2">
                                <asp:TextBox ID="TBPalletWidth" runat="server" Width="60px"></asp:TextBox>
                            </td>
                            <td class="auto-style2">
                                <asp:TextBox ID="TBPalletHeight" runat="server" Width="60px"></asp:TextBox>
                            </td>
                            <td class="auto-style2">mm</td>
                        </tr>
                        <tr>
                            <td>Case weight</td>
                            <td>
                                <asp:TextBox ID="TBCaseWeight" runat="server" Width="60px"></asp:TextBox>
                            </td>
                            <td />
                            <td />
                            <td>kg</td>
                            <td>Pallet weight</td>
                            <td>
                                <asp:TextBox ID="TBPalletWeight" runat="server" Width="60px"></asp:TextBox>
                            </td>
                            <td />
                            <td />
                            <td>kg</td>
                        </tr>
                        <tr>
                            <td />
                            <td />
                            <td />
                            <td />
                            <td />
                            <td />
                            <td />
                            <td />
                            <td />
                            <td />
                        </tr>
                        <tr>
                            <td />
                            <td />
                            <td></td>
                            <td />
                            <td />
                            <td>Maximum Pallet Height</td>
                            <td>
                                <asp:TextBox ID="TBMaxPalletHeight" runat="server" Width="60px"></asp:TextBox>
                            </td>
                            <td />
                            <td />
                            <td>mm</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="BTRefresh" runat="server" Text="Refresh" OnClick="BTRefresh_Click" />
                            </td>
                            <td />
                            <td />
                            <td />
                            <td />
                            <td />
                            <td />
                            <td />
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
                            <td />
                            <td />
                            <td />
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
                                ImageUrl='<%# "LayerThumbHandler.ashx?LayerDesc=" + Eval("LayerDesc") + "&Dimensions=" + Eval("Dimensions")%>'
                                CommandName="ImageButtonClick"
                                CommandArgument='<%# Eval("LayerDesc")%>' Style="flex: 0 0 auto;" />
                        </ItemTemplate>
                    </asp:ListView>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <p>&nbsp;</p>

        <asp:UpdatePanel ID="selectedLayer" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <table class="auto-style1">
                    <tr>
                        <td colspan="2">
                            <asp:Image ID="ImagePallet" runat="server" Height="500px" Width="500px" alt="Dynamic Image" />
                        </td>
                        <td colspan="2">
                            <asp:GridView ID="PalletDetails" runat="server" AllowPaging="false" BackColor="White" ForeColor="Black" BorderColor="Black"
                                AutoGenerateColumns="false" Width="500px">
                                <AlternatingRowStyle BackColor="LightBlue" />
                                <PagerStyle BackColor="LightGray" ForeColor="Black" />
                                <HeaderStyle BackColor="LightGray" ForeColor="Black" />
                                <Columns>
                                    <asp:BoundField DataField="Name" HeaderText="Name" ItemStyle-Width="35%" ReadOnly="true" />
                                    <asp:BoundField DataField="Value" HeaderText="Value" ItemStyle-Width="35%" />
                                    <asp:BoundField DataField="Unit" HeaderText="Unit" ItemStyle-Width="30%" />
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="bnDecrement" runat="server" OnClick="AngleIncrement" Text="&lt;-" Width="130px" />
                        </td>
                        <td class="auto-style4">
                            <asp:Button ID="bnIncrement" runat="server" OnClick="AngleDecrement" Text="-&gt;" Width="130px" />
                        </td>
                        <td></td>
                        <td class="auto-style4">
                            <asp:Button ID="bnNext" runat="server" OnClick="OnNext" Text="Next" Width="130px" />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
