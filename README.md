# Offy Data DLR
>*Make your offline projects more productive and useful*

<img src="https://raw.githubusercontent.com/OffyGIS/Offy-Data-DLR/master/offyapp.JPG" width="300" height="200"/>

**Offy Data Downloader** is an, open source desktop portable, application used to download different types of open GIS data for an offline use later.
For now, it's downloading tiles from all known tile servers, store them at your machine and give you the possibility to include them easily in different GIS clients : 

* *Desktop GIS clients: Qgis, ArcMap...*
* *WebMap clients: Openlayers, LeafletJS...*

##### Current features
* Download tiles by areas (Offy projects) from different tile servers
* Create multi areas
* Pause and resume downloading
* Save paused download
* Preview downloaded tiles (even during the download process)
* Combine your output from different sources

##### Missing features
* For now, the software can deal only with tiles (256x256). So, other data types are not supported yet

## Getting started

### ✓ Requirements
* Windows with .NET 4.0 Framework installed
* Internet connexion

### ✓ Create your first Area
>1. Download the latest release from [Latest release](https://github.com/OffyGIS/Offy-Data-DLR/releases/latest)

>2. Extrat and open **"Offy Data DLR.exe"**

>3. Take a look at the "Usage Policy": Menu -> ? -> Data usage policy

>4. Navigate to a region (city) by zoom/pan using the mouse

>5. Select an area by draging a box on the map view using the mouse

>6. Select zoom levels: Min=1 -> Max=13

>7. Choose your data source (your tile service provider)

>8. Save the Area

>9. Start the download

### ✓ Preview downloaded data
At any time, during or after downloading, you could preview the downloaded tile:

>Menu -> Tools -> Browse downloaded Tiles

### ✓ Include the output in your projects

#### For **Desktop GIS clients**

##### • ***Create your TMS service definition file:***

>Menu -> Tools -> Export TMS service definition

the file will be exported to your area folder

##### • ***Put the output on a local web server (localhost):***
The reason why we need a web server is that GDAL_WMS definition are not complient with file:/// protocol. So, a local web server will help you to use Tiles within http:// protocol.

>If you don't have a local web server, you could use one of the following:

>* Microsoft IIS: [Installing IIS 7 on Windows Vista and Windows 7t](https://www.iis.net/learn/install/installing-iis-7/installing-iis-on-windows-vista-and-windows-7)

>* Apache HTTP Server: [Download Apache HTTP Server](https://httpd.apache.org/download.cgi) 

>* Many other Web servers are available. Feel free to use what you want.

Copy the output **Tiles** Folder to the **/www** folder of your local web server

##### • ***Include the exported XML file in your project:***
Modify the **ServerUrl** in the XML file to match the Tiles location in your web server, and copy it where you want !!

* For ***Qgis***: Add Raster -> select the XML file
* For ***ArcGIS***: Add Data -> select the XML file

>You just know about on-fly projection transformations to adjust other data with your local tile service projection.

That's it!

#### For **WebMap clients**

##### • ***Openlayers:***
Create a layer and add it to your map ({imageType} is your images extention).

from a local absolute path
```javascript
var TileLayer = new ol.layer.Tile
({
    source: new ol.source.XYZ({url: 'file:///C:/.../tiles_directory/{z}/{x}/{y}.{imageType}'})
});
```
from a local relative path
```javascript
var TileLayer = new ol.layer.Tile
({
    source: new ol.source.XYZ({url: 'tiles_directory/{z}/{x}/{y}.{imageType}'})
});
```
from your local web server
```javascript
var TileLayer = new ol.layer.Tile
({
    source: new ol.source.XYZ({url: 'http://localhost/tiles_directory/{z}/{x}/{y}.{imageType}'})
});
```

##### • ***Leaflet:***
Create a layer and add it to your map ({imageType} is your images extention).
from a local relative path
```javascript
var TileLayer = L.tileLayer('file:///C:/.../tiles_directory/{z}/{x}/{y}.{imageType}', { minZoom: 1, maxZoom: 14 });
```
from a local relative path
```javascript
var TileLayer = L.tileLayer('tiles_directory/{z}/{x}/{y}.{imageType}', { minZoom: 1, maxZoom: 14 });
```
from your local web server
```javascript
var TileLayer = L.tileLayer('http://localhost/tiles_directory/{z}/{x}/{y}.{imageType}', { minZoom: 1, maxZoom: 14 });
```

## Issues & Bugs
If you detect any issue/bug report it [here](https://github.com/OffyGIS/Offy-Data-DLR/issues). Thank you!
