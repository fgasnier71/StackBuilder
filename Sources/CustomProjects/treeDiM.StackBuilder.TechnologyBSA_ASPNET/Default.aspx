<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" EnableSessionState="True" %>

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
            width: 150px;
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
            $('#TBCaseLength').keypad({ keypadOnly: true, layout: $.keypad.numericLayout, });
            $('#TBCaseWidth').keypad({ keypadOnly: true, layout: $.keypad.numericLayout, });
            $('#TBCaseHeight').keypad({ keypadOnly: true, layout: $.keypad.numericLayout, });
            $('#TBCaseWeight').keypad({ keypadOnly: true, layout: $.keypad.numericLayout, });
            $('#TBPalletLength').keypad({ keypadOnly: true, layout: $.keypad.numericLayout, });
            $('#TBPalletWidth').keypad({ keypadOnly: true, layout: $.keypad.numericLayout, });
            $('#TBPalletHeight').keypad({ keypadOnly: true, layout: $.keypad.numericLayout, });
            $('#TBPalletWeight').keypad({ keypadOnly: true, layout: $.keypad.numericLayout, });
            $('#TBMaxPalletHeight').keypad({ keypadOnly: true, layout: $.keypad.numericLayout, });
        }
    </script>



</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td id="Label_CaseDim" class="auto-style3">Case dimensions</td>
                    <td class="auto-style2">
                        <asp:TextBox ID="TBCaseLength" runat="server" Width="60px" TextMode="Number" OnInit="ControlInit" PlaceHolder="TBCaseLength"></asp:TextBox>
                    </td>
                    <td class="auto-style2">
                        <asp:TextBox ID="TBCaseWidth" runat="server" Width="60px" TextMode="Number" PlaceHolder="TBCaseWidth"></asp:TextBox>
                    </td>
                    <td class="auto-style2">
                        <asp:TextBox ID="TBCaseHeight" runat="server" Width="60px" TextMode="Number"></asp:TextBox>
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
        <div class="liste" style="margin: 0px; padding: 0px; border-style: solid; border-width: 1px; overflow-x: scroll; width: 100%; height: 100px;">
            <asp:ListView ID="dlLayers" RepeatDirection="Horizontal" CellSpacing="0" runat="server" SelectedIndex="0" OnItemCommand="OnLVLayersItemCommand">
                <ItemTemplate>
                    <asp:ImageButton ID="Image1"
                        runat="server"
                        Height='<%# Unit.Parse(ConfigSettings.ThumbSize) %>'
                        Width='<%# Unit.Parse(ConfigSettings.ThumbSize) %>'
                        ImageUrl='<%# "LayerThumbHandler.ashx?LayerDesc=" + Eval("LayerDesc") %>'
                        CommandName="ImageButtonClick"
                        CommandArgument='<%# Eval("LayerDesc")%>' />
                </ItemTemplate>
            </asp:ListView>
        </div>
        <p>&nbsp;</p>
        <table class="auto-style1">
            <tr>
                <td colspan="2">
                    <asp:Image ID="ImagePallet" runat="server" Height="500px" Width="500px" alt="Dynamic Image" />
                </td>
                <td colspan="2">
                    <asp:GridView ID="PalletDetails" runat="server" AllowPaging="false" BackColor="White" ForeColor="Black" BorderColor="Black"
                        AutoGenerateColumns="false"  Width="500px">
                        <AlternatingRowStyle BackColor="LightBlue" />
                        <PagerStyle BackColor="LightGray" ForeColor="Black" />
                        <HeaderStyle BackColor="LightGray" ForeColor="Black" />
                        <Columns>
                            <asp:BoundField DataField="Name" HeaderText="Name" ItemStyle-Width="35%" ReadOnly="true"/>
                            <asp:BoundField DataField="Value" HeaderText="Value" ItemStyle-Width="35%"/>
                            <asp:BoundField DataField="Unit" HeaderText="Unit" ItemStyle-Width="30%"/>
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
                <td></td>
            </tr>
        </table>
    </form>
</body>
</html>
