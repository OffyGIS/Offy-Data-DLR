	var scaleLineControl = new ol.control.ScaleLine();
	var mousePositionControl = new ol.control.MousePosition
	({
		coordinateFormat: ol.coordinate.createStringXY(4),
		projection: 'EPSG:4326'
	});

	var map = new ol.Map({
		controls: 
		ol.control.defaults({attribution: false}).extend([
			scaleLineControl,
			mousePositionControl
		]),
		target: 'map',
		view: new ol.View()
	});

	function fitMapToExtent(minx, miny, maxx, maxy)
	{		
		var points = 
		[
			ol.proj.transform([minx,maxy], 'EPSG:4326', 'EPSG:3857'), 
			ol.proj.transform([maxx,maxy], 'EPSG:4326', 'EPSG:3857'), 
			ol.proj.transform([maxx,miny], 'EPSG:4326', 'EPSG:3857'), 
			ol.proj.transform([minx,miny], 'EPSG:4326', 'EPSG:3857'), 
			ol.proj.transform([minx,maxy], 'EPSG:4326', 'EPSG:3857')
		];
		
		var polygon = new ol.geom.Polygon([points])
		
		map.getView().fit(polygon.getExtent(), map.getSize());
	}
	
	function addTileLayer(path)
	{
		var lay = new ol.layer.Tile
		({
			source: new ol.source.XYZ({url: path})
		});
		
		map.addLayer(lay);
	}
	
	function setZoom(zoomLevel)
	{
		map.getView().setZoom(zoomLevel);
	}
	