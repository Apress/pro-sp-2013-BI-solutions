<script language="javascript">

var _application = Sys.Application;
var _visioWebPart; 
var onShapeSelectionChanged = null;

_application.add_load(onApplicationLoad);

function onApplicationLoad()
{
    _visioWebPart= new Vwa.VwaControl("WebPartWPQ2");
    _visioWebPart.addHandler("diagramcomplete", onDiagramComplete);
    _visioWebPart.addHandler("shapeselectionchanged", onShapeSelectionChanged);
}

function onDiagramComplete()
{
    var _page = _visioWebPart.getActivePage(); 
    _page.setZoom(85);
}

onShapeSelectionChanged = function(source, args)
{
    var _activePage = _visioWebPart.getActivePage(); 
    var _shape = _activePage.getShapes(); 
    var _shapeItem = _shape.getItemById(args);
    var _shapeData = _shapeItem.getShapeData();
    var _description = ""; 
   
    for (var j = 0; j < _shapeData.length; j++)
    {       
        if (_shapeData[j].label == "Details")
        {
            _description = _shapeData[j].value;
            continue;
        }
    }    

    document.getElementById('landmarkDetails').firstChild.data = _description;   
}

</SCRIPT>
<div id="landmarkDetails" style="font-family: Verdana; font-style: bold; font-size:14pt; color:red;">landmark details...</div>
