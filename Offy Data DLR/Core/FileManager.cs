using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace Offy.Core
{
    static public class FileManager
    {
        public static List<DataSource> LoadDataSources(string configFile)
        {
            List<DataSource> DSs = new List<DataSource>();

            XmlDocument doc = new XmlDocument();
            try
            {
                doc.Load(configFile);
            }
            catch(XmlException e)
            {
                return null;
            }           

            if (!doc.HasChildNodes || doc.ChildNodes[0].Name.ToLower() != "configuration")
            {
                DSs.Add(DataSource.defaultDataSource());
                return DSs;
            }

            XmlNode configuration = doc.FirstChild;

            if (!configuration.HasChildNodes)
            {
                DSs.Add(DataSource.defaultDataSource());
                return DSs;
            }

            XmlNode datasources = null;

            foreach (XmlNode dss in configuration.ChildNodes)
            {
                if (dss.Name.ToLower() == "datasources")
                {
                    datasources = dss;
                    break;
                }
            }

            if (datasources == null)
            {
                DSs.Add(DataSource.defaultDataSource());
                return DSs;
            }

            foreach (XmlNode ds in datasources.ChildNodes)
            {
                if (ds.Name.ToLower() != "datasource") continue;
                if (ds.Attributes.Count == 0) continue;

                string url = "", name = "", query = "", imgType = "";

                foreach (XmlAttribute a in ds.Attributes)
                {
                    if (a.Name.ToLower() == "url") url = a.Value;
                    if (a.Name.ToLower() == "name") name = a.Value;
                    if (a.Name.ToLower() == "query") query = a.Value;
                    if (a.Name.ToLower() == "imagetype") imgType = a.Value;
                }

                if (url != "" && name != "") DSs.Add(new DataSource(url, name, query, imgType));
            }

            if (DSs.Count == 0) DSs.Add(DataSource.defaultDataSource());

            return DSs;
        }

        public static void saveArea(string areasFolder, Area area)
        {
            if (!Directory.Exists(areasFolder)) Directory.CreateDirectory(areasFolder);

            string areaFolder = area.SavedOnDisk ? Path.Combine(areasFolder, area.FolderName) : Path.Combine(areasFolder, area.Name);

            if (!area.SavedOnDisk)
            {
                if (!Directory.Exists(areaFolder))
                {
                    Directory.CreateDirectory(areaFolder);

                    area.FolderName = area.Name;
                }
                else
                {
                    int index = 0;

                    while (Directory.Exists(areaFolder + index)) index++;

                    areaFolder = areaFolder + index;
                    Directory.CreateDirectory(areaFolder);


                    area.FolderName = new DirectoryInfo(areaFolder).Name;
                }
            }

            if (!Directory.Exists(Path.Combine(areaFolder, "Tiles"))) Directory.CreateDirectory(Path.Combine(areaFolder, "Tiles"));

            XmlDocument doc = new XmlDocument();

            XmlNode areaNode = newXmlNode(doc, "Area");
            doc.AppendChild(areaNode);

            XmlNode name = newXmlNode(doc, "Name", area.Name);
            XmlNode Extent = newXmlNode(doc, "Extent", area.Extent.getString());
            XmlNode getExtentFromMap = newXmlNode(doc, "GetExtentFromMap", area.GetExtentFromMap.ToString());
            XmlNode minzoom = newXmlNode(doc, "MinZoom", area.Minzoom.ToString());
            XmlNode maxzoom = newXmlNode(doc, "MaxZoom", area.Maxzoom.ToString());
            XmlNode dataSourceName = newXmlNode(doc, "DataSourceName", area.DataSourceName);
            XmlNode firstTile = newXmlNode(doc, "FT", area.FirstTile.getString());
            XmlNode currentTile = newXmlNode(doc, "CT", area.CurrentTile.getString());
            XmlNode lastTile = newXmlNode(doc, "LT", area.LastTile.getString());
            XmlNode locked = newXmlNode(doc, "L", area.Locked.ToString());
            XmlNode paused = newXmlNode(doc, "P", area.Paused.ToString());
            XmlNode downloaded = newXmlNode(doc, "D", area.Downloaded.ToString());

            areaNode.AppendChild(name);
            areaNode.AppendChild(Extent);
            areaNode.AppendChild(getExtentFromMap);
            areaNode.AppendChild(minzoom);
            areaNode.AppendChild(maxzoom);
            areaNode.AppendChild(dataSourceName);
            areaNode.AppendChild(firstTile);
            areaNode.AppendChild(currentTile);
            areaNode.AppendChild(lastTile);
            areaNode.AppendChild(locked);
            areaNode.AppendChild(paused);
            areaNode.AppendChild(downloaded);

            doc.Save(Path.Combine(areaFolder, "area.areadef"));
        }

        public static XmlNode newXmlNode(XmlDocument doc, string name, string innerText = null)
        {
            XmlNode node = doc.CreateElement(name);

            if (innerText != null) node.InnerText = innerText;

            return node;
        }

        public static Area openArea(string areaDefPath)
        {
            Area newArea = new Area();

            XmlDocument doc = new XmlDocument();
            doc.Load(areaDefPath);

            if (!doc.HasChildNodes || doc.ChildNodes[0].Name.ToLower() != "area")
            {
                return Area.createNewArea();
            }

            XmlNode area = doc.FirstChild;

            if (!area.HasChildNodes)
            {
                return Area.createNewArea();
            }

            System.Globalization.CultureInfo usC =
                        System.Globalization.CultureInfo.CreateSpecificCulture("en-US");

            foreach (XmlNode nd in area.ChildNodes)
            {
                if (nd.Name.ToLower() == "name")
                {
                    newArea.Name = nd.InnerText;
                }
                if (nd.Name.ToLower() == "extent")
                {
                    newArea.Extent = new Extent(
                        double.Parse(nd.InnerText.Split(',')[0], usC),
                        double.Parse(nd.InnerText.Split(',')[1], usC),
                        double.Parse(nd.InnerText.Split(',')[2], usC),
                        double.Parse(nd.InnerText.Split(',')[3], usC));
                }
                if (nd.Name.ToLower() == "getExtentfrommap")
                {
                    newArea.GetExtentFromMap = bool.Parse(nd.InnerText.ToLower());
                }
                if (nd.Name.ToLower() == "minzoom")
                {
                    newArea.Minzoom = int.Parse(nd.InnerText.ToLower());
                }
                if (nd.Name.ToLower() == "maxzoom")
                {
                    newArea.Maxzoom = int.Parse(nd.InnerText.ToLower());
                }
                if (nd.Name.ToLower() == "datasourcename")
                {
                    newArea.DataSourceName = nd.InnerText;
                }
                if (nd.Name.ToLower() == "ft")
                {
                    newArea.FirstTile = new Zxy(
                        int.Parse(nd.InnerText.Split(',')[0], usC),
                        int.Parse(nd.InnerText.Split(',')[1], usC),
                        int.Parse(nd.InnerText.Split(',')[2], usC));
                }
                if (nd.Name.ToLower() == "ct")
                {
                    newArea.CurrentTile = new Zxy(
                        int.Parse(nd.InnerText.Split(',')[0], usC),
                        int.Parse(nd.InnerText.Split(',')[1], usC),
                        int.Parse(nd.InnerText.Split(',')[2], usC));
                }
                if (nd.Name.ToLower() == "lt")
                {
                    newArea.LastTile = new Zxy(
                        int.Parse(nd.InnerText.Split(',')[0], usC),
                        int.Parse(nd.InnerText.Split(',')[1], usC),
                        int.Parse(nd.InnerText.Split(',')[2], usC));
                }
                if (nd.Name.ToLower() == "l")
                {
                    newArea.Locked = bool.Parse(nd.InnerText.ToLower());
                }
                if (nd.Name.ToLower() == "p")
                {
                    newArea.Paused = bool.Parse(nd.InnerText.ToLower());
                }
                if (nd.Name.ToLower() == "d")
                {
                    newArea.Downloaded = bool.Parse(nd.InnerText.ToLower());
                }
            }

            newArea.FolderName = new FileInfo(areaDefPath).Directory.Name;
            newArea.SavedOnDisk = true;
            newArea.Changed = false;

            return newArea;
        }

        static public string getAreaName(string areaDefPath)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(areaDefPath);

            if (!doc.HasChildNodes || doc.ChildNodes[0].Name.ToLower() != "area")
            {
                return null;
            }

            XmlNode area = doc.FirstChild;

            if (!area.HasChildNodes)
            {
                return null;
            }

            foreach (XmlNode nd in area.ChildNodes)
            {
                if (nd.Name.ToLower() != "name") continue;
                return nd.InnerText;
            }

            return null;
        }

        public static void copyStream(Stream fromStream, Stream toStream)
        {
            byte[] buffer = new byte[4096];
            int bytesRead;

            do
            {
                bytesRead = fromStream.Read(buffer, 0, buffer.Length);
                toStream.Write(buffer, 0, bytesRead);
            }
            while (bytesRead != 0);

            fromStream.Flush();
            fromStream.Close();
            toStream.Flush();
            toStream.Close();
        }

        public static bool saveTMSDefFile(string areasFolder, Area area, string imageType)
        {
            XmlDocument doc = new XmlDocument();

            XmlNode gdalWMSNode = newXmlNode(doc, "GDAL_WMS");
            doc.AppendChild(gdalWMSNode);

            ///////////////////////////////////////////////////////////////////////////
            XmlNode serviceNode = newXmlNode(doc, "Service");
            ((XmlElement)serviceNode).SetAttribute("name", "TMS");

            XmlNode serverURLNode = newXmlNode(doc, "ServerUrl");
            serverURLNode.InnerText = "http://localhost/tiles/${z}/${x}/${y}." + imageType;

            serviceNode.AppendChild(serverURLNode);
            gdalWMSNode.AppendChild(serviceNode);
            ///////////////////////////////////////////////////////////////////////////

            XmlNode dataWindowNode = newXmlNode(doc, "DataWindow");

            XmlNode UpperLeftXNode = newXmlNode(doc, "UpperLeftX");
            UpperLeftXNode.InnerText = "-20037508.34";
            XmlNode UpperLeftYNode = newXmlNode(doc, "UpperLeftY");
            UpperLeftYNode.InnerText = "20037508.34";
            XmlNode LowerRightXNode = newXmlNode(doc, "LowerRightX");
            LowerRightXNode.InnerText = "20037508.34";
            XmlNode LowerRightYNode = newXmlNode(doc, "LowerRightY");
            LowerRightYNode.InnerText = "-20037508.34";
            XmlNode TileLevelNode = newXmlNode(doc, "TileLevel");
            TileLevelNode.InnerText = "18";
            XmlNode TileCountXNode = newXmlNode(doc, "TileCountX");
            TileCountXNode.InnerText = "1";
            XmlNode TileCountYNode = newXmlNode(doc, "TileCountY");
            TileCountYNode.InnerText = "1";
            XmlNode YOriginNode = newXmlNode(doc, "YOrigin");
            YOriginNode.InnerText = "top";

            dataWindowNode.AppendChild(UpperLeftXNode);
            dataWindowNode.AppendChild(UpperLeftYNode);
            dataWindowNode.AppendChild(LowerRightXNode);
            dataWindowNode.AppendChild(LowerRightYNode);
            dataWindowNode.AppendChild(TileLevelNode);
            dataWindowNode.AppendChild(TileCountXNode);
            dataWindowNode.AppendChild(TileCountYNode);
            dataWindowNode.AppendChild(YOriginNode);

            gdalWMSNode.AppendChild(dataWindowNode);

            ///////////////////////////////////////////////////////////////////////////

            XmlNode ProjectionNode = newXmlNode(doc, "Projection");
            ProjectionNode.InnerText = "EPSG:3857";
            XmlNode BlockSizeXNode = newXmlNode(doc, "BlockSizeX");
            BlockSizeXNode.InnerText = "256";
            XmlNode BlockSizeYNode = newXmlNode(doc, "BlockSizeY");
            BlockSizeYNode.InnerText = "256";
            XmlNode BandsCountNode = newXmlNode(doc, "BandsCount");
            BandsCountNode.InnerText = "3";
            XmlNode ZeroBlockHttpCodesNode = newXmlNode(doc, "ZeroBlockHttpCodes");
            ZeroBlockHttpCodesNode.InnerText = "204,303,404,400,500,501";
            XmlNode ZeroBlockOnServerExceptionNode = newXmlNode(doc, "ZeroBlockOnServerException");
            ZeroBlockOnServerExceptionNode.InnerText = "true";

            gdalWMSNode.AppendChild(ProjectionNode);
            gdalWMSNode.AppendChild(BlockSizeXNode);
            gdalWMSNode.AppendChild(BlockSizeYNode);
            gdalWMSNode.AppendChild(BandsCountNode);
            gdalWMSNode.AppendChild(ZeroBlockHttpCodesNode);
            gdalWMSNode.AppendChild(ZeroBlockOnServerExceptionNode);

            ///////////////////////////////////////////////////////////////////////////

            try
            {
                doc.Save(Path.Combine(areasFolder, area.FolderName, area.FolderName + " (" + area.DataSourceName + ").xml"));
                return true;
            }
            catch(IOException e)
            {
                return false;
            }
        }
    }
}
