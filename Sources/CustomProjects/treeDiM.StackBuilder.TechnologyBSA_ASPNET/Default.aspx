<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" EnableSessionState="True"%>

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
        </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td id="Label_CaseDim" class="auto-style3">Case dimensions</td>
                    <td class="auto-style2">
                        <asp:TextBox ID="TBCaseLength" runat="server" Width="60px" TextMode="Number" OnInit="ControlInit"></asp:TextBox>
                    </td>
                    <td class="auto-style2">
                        <asp:TextBox ID="TBCaseWidth" runat="server" Width="60px" TextMode="Number"></asp:TextBox>
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
                    <td/>
                    <td/>
                    <td>kg</td>
                </tr>
                <tr>
                    <td/>
                    <td/>
                    <td/>
                    <td/>
                    <td/>
                    <td/>
                    <td />
                    <td />
                    <td />
                    <td />
                </tr>
                <tr>
                    <td/>
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
    <p>
        &nbsp;</p>
    <table class="auto-style1">
        <tr>
            <td>
                <asp:Image ID="ImagePallet" runat="server" Height="500px" Width="500px" alt="Dynamic Image"/>
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
    </form>
    </body>
</html>
