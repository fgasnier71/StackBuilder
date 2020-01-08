<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Validation.aspx.cs" Inherits="Validation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
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
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="pageUpdates" runat="server" EnablePartialRendering="true"></asp:ScriptManager>
            <asp:UpdatePanel ID="loadedPallet" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <table class="auto-style1">
                        <tr>
                            <td colspan="2">
                                <asp:Image ID="ImagePallet" runat="server" Height="500px" Width="500px" alt="Dynamic Image" />
                            </td>
                            <td colspan="2">
                                <asp:CheckBox ID="ChkbAlternateLayers" runat="server" Text="Alternate layers" OnCheckedChanged="OnInputChanged" AutoPostBack="true"/>
                                <br />
                                <asp:CheckBox ID="ChkbBottomInterlayer" runat="server" Text="Bottom interlayer" OnCheckChanged="OnInputChanged" AutoPostBack="true"/>
                                <br />
                                <asp:CheckBox ID="ChkbIntermediateInterlayers" runat="server" Text="Intermediate interlayers" OnCheckChanged="OnInputChanged" AutoPostBack="true"/>
                                <br />
                                <asp:CheckBox ID="ChkbTopInterlayer" runat="server" Text="Top interlayer" OnCheckChanged="OnInputChanged" AutoPostBack="true"/>
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
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>
