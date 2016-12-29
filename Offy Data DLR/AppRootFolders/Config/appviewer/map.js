    var sourceVector = new ol.source.Vector({wrapX: false});

    var vector = new ol.layer.Vector({
		source: sourceVector,
		style: new ol.style.Style
		({
			fill: new ol.style.Fill({color: 'rgba(255, 255, 255, 0.3)'}),
			stroke: new ol.style.Stroke({color: '#aadfaa', width: 4})
		})
    });
	
	var scaleLineControl = new ol.control.ScaleLine();
	
    var map = new ol.Map({
		controls: 
		ol.control.defaults({attribution: false}).extend([
			scaleLineControl
        ]),
		layers: 
		[
			new ol.layer.Tile({
				source: new ol.source.XYZ({url: 'http://tile.openstreetmap.org/{z}/{x}/{y}.png'})
			}),
			vector
		],
		target: 'map',
		view: new ol.View({
			center: ol.proj.transform([-7,31], 'EPSG:4326', 'EPSG:3857'), 
			zoom: 5
		})
    });

    var draw;
	var drawing = false;
	
	function isDrawing()
	{
		return drawing;
	}
	
	function addInteraction() 
	{
		maxPoints = 2;
		
		geometryFunction = function(coordinates, geometry) 
		{
			if (!geometry) 
			{
				geometry = new ol.geom.Polygon(null);
			}
			
			var start = coordinates[0];
			var end = coordinates[1];
			
			geometry.setCoordinates
			([
				[start, [start[0], end[1]], end, [end[0], start[1]], start]
			]);
			
			return geometry;
		};
		
		draw = new ol.interaction.Draw
		({
			source: sourceVector,
			type:'LineString',
			geometryFunction: geometryFunction,
			maxPoints: maxPoints
		});
		
		draw.on('drawend', function() 
		{
			sourceVector.clear();
			drawing = false;
		});
		draw.on('drawstart', function() 
		{
			drawing = true;
		});
		
		map.addInteraction(draw);
	}

    addInteraction();
	
	window.onresize = function()
	{
		//map.addInteraction(draw);
	}
	
	function getRectangleExtent()
	{
		if(sourceVector.getFeatures().length == 0) return 'x';
		return(
		ol.proj.transform([sourceVector.getFeatures()[0].getGeometry().getExtent()[0], sourceVector.getFeatures()[0].getGeometry().getExtent()[1]], 'EPSG:3857', 'EPSG:4326') + 
		',' +
		ol.proj.transform([sourceVector.getFeatures()[0].getGeometry().getExtent()[2], sourceVector.getFeatures()[0].getGeometry().getExtent()[3]], 'EPSG:3857', 'EPSG:4326')
		);
	}
	
	function newBoxFromExtent(minx, miny, maxx, maxy)
	{
		sourceVector.clear();
		
		var points = 
		[
			ol.proj.transform([minx,maxy], 'EPSG:4326', 'EPSG:3857'), 
			ol.proj.transform([maxx,maxy], 'EPSG:4326', 'EPSG:3857'), 
			ol.proj.transform([maxx,miny], 'EPSG:4326', 'EPSG:3857'), 
			ol.proj.transform([minx,miny], 'EPSG:4326', 'EPSG:3857'), 
			ol.proj.transform([minx,maxy], 'EPSG:4326', 'EPSG:3857')
		];
		
		var polygon = new ol.geom.Polygon([points])
		var feature = new ol.Feature({geometry: polygon});
		sourceVector.addFeature(feature);
		
		map.getView().fit(polygon.getExtent(), map.getSize());
	}
	
	function addTileLayer(_url)
	{
		KeepFirstLayerOnly();
		
		var tileLayer = new ol.layer.Tile({
			source: new ol.source.XYZ({url: _url})
		});
		
		map.getLayers().insertAt(0, tileLayer);
	}
	
	function KeepFirstLayerOnly()
	{
		if(map.getLayers().getLength() != 2) return;
		
		map.getLayers().removeAt(0);
	}
	
	var xy = document.createElement('div');
	xy.setAttribute('id', 'xy');
	xy.style.display = 'none';
	document.body.appendChild(xy);
	
	var mousePosition = new ol.control.MousePosition({
        coordinateFormat: ol.coordinate.createStringXY(5),
        projection: 'EPSG:4326',
        target: xy,
        undefinedHTML: '&nbsp;'
    });
	
	map.addControl(mousePosition);
	
	function getMousePosition()
	{
		return document.getElementById('xy').childNodes[0].innerHTML;
	}
	
	function getZoom()
	{
		return map.getView().getZoom();
	}
	
	function changeScaleUnits(units)
	{
		scaleLineControl.setUnits(units);
	}