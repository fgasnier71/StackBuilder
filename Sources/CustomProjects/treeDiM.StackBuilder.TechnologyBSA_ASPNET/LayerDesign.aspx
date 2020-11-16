<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LayerDesign.aspx.cs" Inherits="LayerDesign" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Layer design page</title>
    <link type="text/css" href="css/default.css" rel="stylesheet" />
    <link href="css/jquery-ui.css" rel="stylesheet" />
    <link href="css/keyboard.css" rel="stylesheet" />
    <script type="text/javascript" src="javascript/jquery.min.js"></script>
    <script type="text/javascript" src="javascript/jquery-ui.min.js"></script>
    <script type="text/javascript" src="javascript/jquery.keyboard.js"></script>
    <script type="text/javascript" src="javascript/jquery.keyboard.extension-typing.js"></script>
    <script type="text/javascript" src="javascript/fabric.min.js"></script>
    <script type="text/javascript" src="javascript/layerDesignHelpers.js"></script>
    <script type="text/javascript">
        var snap = 5;
        var counter = 0;
        var rectLeft = 0;
        var rectTop = 0;
        var canvasWidth = 0;
        var canvasHeight = 0;
        var caseWidth = <%= this.javaSerial.Serialize(this._casePixelWidth)%>;
        var caseHeight = <%= this.javaSerial.Serialize(this._casePixelHeight)%>;
        var boxPositions = <%= this.javaSerial.Serialize(this._boxPositions)%>;
        var palletDimensions = <%= this.javaSerial.Serialize(this._palletDims)%>

        $(window).load(function () {
            var canvas = new fabric.Canvas('canvas', {
                isDrawingMode: false,
                canvasWidth: document.getElementById('canvas').width,
                canvasHeight: document.getElementById('canvas').height,
                rectLeft: 0,
                rectTop: 0,
                perPixelTargetFind: true,
                targetFindTolerance: 1,
                selection: true,
            });

            document.getElementById('canvas').fabric = canvas;

            canvasWidth = canvas.width;
            canvasHeight = canvas.height;

            var len = boxPositions.length;
            for (var i = 0; i < len; ++i)
            {
                insertCase(canvas, boxPositions[i].NumberCase, boxPositions[i].X, boxPositions[i].Y, boxPositions[i].Angle);
            }
            
            fabric.util.addListener(canvas.upperCanvasEl, 'dblclick', function (e) {
                var target = canvas.findTarget(e);
                target.setCoords();
                target.rotate(mod(target.get('angle') + 90, 360));
                target.setCoords();
                canvas.renderAll();
            });
            canvas.on('object:moving', function (options) {
                options.target.setCoords();
                Move(canvas, options.target);
                options.target.setCoords();
            });
        });
        function insertCases(number) {
            var canvas = document.getElementById('canvas').fabric;
            insertCase(canvas, number, canvasWidth-100, 0, 0);
            canvas.renderAll();
        }
        function remove() {
            var canvas = document.getElementById('canvas').fabric;
            canvas.getActiveObjects().forEach((obj) => {
                canvas.remove(obj)
            });
            canvas.discardActiveObject().renderAll();
        }
        function Save() {
            $(document).ready(function () {

                var canvas = document.getElementById('canvas').fabric;
                let boxPositions = [];
                var counter = 0;
                canvas.forEachObject(function (obj) {
                    boxPositions.push(
                        {
                            Index: counter,
                            X: obj.left,
                            Y: obj.top,
                            Angle: obj.get('angle'),
                            NumberCase: 1,
                        }
                    );
                    ++counter;
                });

                $.ajax({
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'json',
                    type: 'POST',
                    url: 'LayerDesign.aspx/SaveCasePositions',
                    data: JSON.stringify({ 'list': boxPositions }),
                    success: function () {
                        alert("success");
                    },
                    error: function (response) {
                        alert(JSON.stringify(response));
                    }
                });
            });
        }

    </script>
</head>

<body>
    <form id="form1" runat="server">
        <div class="div980x780">
            <asp:ScriptManager ID="pageUpdates" runat="server" EnablePartialRendering="true"></asp:ScriptManager>
<table>
                    <tr>
                        <td colspan="4">
            <div class="canvas-container" style="width: 950px; height: 500px; position: relative; user-select: none;">
                
                            <canvas id="canvas" width="950" height="500" style="border: 1px solid #ccc" runat="server"></canvas>
            </div>
                        </td>
                        <td colspan="1">
                            <table class="style100pct">
                                <tr>
                                    <td>
                                        <input id="ButtonAdd1" type="buttonadd1" onclick="JavaScript: insertCases(1);" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <input id="ButtonAdd2" type="buttonadd2" onclick="JavaScript: insertCases(2);" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <input id="ButtonAdd3" type="buttonadd3" onclick="JavaScript: insertCases(3);" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <input id="ButtonAdd4" type="buttonadd4"  onclick="JavaScript: insertCases(4);" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <input id="Remove" type="buttonremove" onclick="JavaScript: remove();" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            <div>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
                    <ContentTemplate>
                        <table class="style100pct">
                            <tr>
                                <td class="style100pct" />
                                &nbsp;
                                <td class="style100pct" />
                                &nbsp;
                            </tr>
                            <tr>
                                <td class="style100pct" />
                                <asp:Button ID="bnPrev" runat="server" CssClass="buttonPrev" OnClick="OnPrevious" Text="&lt; Previous" />
                                <td class="style100pct" />
                                <input id="ButtonSave" type="button" value="Next &gt;" onclick="JavaScript: Save();" />
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </form>
</body>
</html>
