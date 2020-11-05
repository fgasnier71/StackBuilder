<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LayerDesign.aspx.cs" Inherits="LayerDesign" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
        var caseWidth = 100;
        var caseHeight = 80;

        $(window).load(function () {
            var canvas = new fabric.Canvas('canvas', {
                isDrawingMode: false,
                canvasWidth: document.getElementById('canvas').width,
                canvasHeight: document.getElementById('canvas').height,
                rectLeft: 0,
                rectTop: 0,
            });
            canvas.selection = false;
            canvas.perPixelTargetFind = true;
            canvasWidth = canvas.width;
            canvasHeight = canvas.height;

            insertCase(canvas, 1, 0, 0, 0);
            insertCase(canvas, 1, 100, 0, 0);
            insertCase(canvas, 1, 200, 0, 0);

            insertCase(canvas, 1, 0, 80, 0);
            insertCase(canvas, 1, 100, 80, 0);
            insertCase(canvas, 1, 200, 80, 0);


            fabric.util.addListener(canvas.upperCanvasEl, 'dblclick', function (e) {
                var target = canvas.findTarget(e);
                target.setCoords();
                target.rotate(mod(target.get('angle') + 90, 360));
                target.setCoords();
                canvas.renderAll();
            });

            canvas.on('object:moving', function (options) {
                // Sets corner position coordinates based on current angle, width and height
                options.target.setCoords();
                Move(canvas, options.target);
                options.target.setCoords();
            });
        });

    </script>
</head>

<body>
    <form id="form1" runat="server">
        <div class="div980x780">
            <asp:ScriptManager ID="pageUpdates" runat="server" EnablePartialRendering="true"></asp:ScriptManager>
            <div class="canvas-container" style="width: 500px; height: 500px; position: relative; user-select: none;">
                <canvas id="canvas" width="800" height="500" style="border: 1px solid #ccc" runat="server"></canvas>
            </div>
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
