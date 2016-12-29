using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace Offy.Core
{
    public static class TileManager
    {
        public class PointT
        {
            public int X;
            public int Y;
        }

        public static int getTilesCount(Extent extent, int minZoom, int maxZoom)
        {
            int counter = 0;

            for(int z = minZoom; z <= maxZoom; z++)
            {
                Zxy firstT = getFirstTileAtZ(extent , z);
                Zxy lastT = getLastTileAtZ(extent, z);

                int h = 0, v = 0;

                h = lastT.X - firstT.X + 1;
                v = lastT.Y - firstT.Y + 1;

                counter += h * v;
            }

            return counter;
        }

        public static int getTilesCountFromTile(Extent extent, Zxy fromTile, int maxZoom)
        {
            int counter = 0;

            for (int z = fromTile.Z; z <= maxZoom; z++)
            {
                Zxy firstT = z == fromTile.Z ? fromTile : getFirstTileAtZ(extent, z);
                Zxy lastT = getLastTileAtZ(extent, z);

                int h = 0, v = 0;

                h = lastT.X - firstT.X + 1;
                v = lastT.Y - firstT.Y + 1;

                counter += h * v;
            }

            return counter;
        }

        public static int getTilesCountToTile(Extent extent, Zxy toTile, int minZoom)
        {
            int counter = 0;

            for (int z = minZoom; z <= toTile.Z; z++)
            {
                Zxy firstT = getFirstTileAtZ(extent, z);
                Zxy lastT = getLastTileAtZ(extent, z);

                int h = 0, v = 0;

                h = lastT.X - firstT.X + 1;
                v = lastT.Y - firstT.Y + 1;

                if (z == toTile.Z)
                {
                    int colNumb = toTile.X - firstT.X + 1; //count columns until tile X

                    counter += v * (colNumb - 1) + toTile.Y - firstT.Y + 1;
                }
                else
                    counter += h * v;
            }

            return (counter - 1); // current tile shouldn't be included -> it wasn't downloaded
        }

        public static string getTilesSummary(Extent extent, int minZoom, int maxZoom)
        {
            string summ = "";

            summ += "Tiles summary:";

            summ += Environment.NewLine;
            summ += Environment.NewLine;

            int counter = 0;

            for (int z = minZoom; z <= maxZoom; z++)
            {
                summ += "   Zoom level (z): " + z;
                
                Zxy firstT = getFirstTileAtZ(extent, z);
                Zxy lastT = getLastTileAtZ(extent, z);

                int h = 0, v = 0;

                h = lastT.X - firstT.X + 1;
                v = lastT.Y - firstT.Y + 1;

                summ += "-   Columns (x): " + v + "  -  Rows (y): " + h + "  |  Tiles count: " + (h * v);
                summ += Environment.NewLine;

                counter += h * v;
            }

            summ += Environment.NewLine;
            summ += "Total tiles count: " + counter;

            return summ;
        }

        public static PointT getTilePoint(double xLon, double yLat, int zoom)
        {   
            PointT p = new PointT();

            p.X = (int)Math.Floor((xLon + 180.0) / 360.0 * (1 << zoom));
            p.Y = (int)Math.Floor((1.0 - Math.Log(Math.Tan(yLat * Math.PI / 180.0) + 1.0 / Math.Cos(yLat * Math.PI / 180.0)) / Math.PI) / 2.0 * (1 << zoom));

            return p;
        }

        public static Zxy getFirstTileAtZ(Extent extent, int zoom)
        {
            return new Zxy(zoom, getTilePoint(extent.Xmin, extent.Ymax, zoom));
        }

        public static Zxy getLastTileAtZ(Extent extent, int zoom)
        {
            return  new Zxy(zoom, getTilePoint(extent.Xmax, extent.Ymin, zoom));
        }

        public static bool downloadTiles(Area area, string url, string query, string TilesFolder, DownloadProgress dlProgress)
        {
            int startZ = area.Paused ? area.CurrentTile.Z : area.FirstTile.Z;
            int endZ = area.LastTile.Z;
            
            for (int z = startZ; z <= endZ; z++)
            {
                string zDir = Path.Combine(TilesFolder, z.ToString());

                if (!Directory.Exists(zDir)) Directory.CreateDirectory(zDir);

                int startX, startY;

                if (area.Paused)
                {
                    startX = area.CurrentTile.X;
                    startY = area.CurrentTile.Y;
                    area.Paused = false;
                }
                else
                {
                    startX = getFirstTileAtZ(area.Extent, z).X;
                    startY = getFirstTileAtZ(area.Extent, z).Y;
                }

                int endX = getLastTileAtZ(area.Extent, z).X;
                int endY = getLastTileAtZ(area.Extent, z).Y;
                
                for (int x = startX; x <= endX; x++)
                {
                    string xDir = Path.Combine(TilesFolder, z.ToString(), x.ToString());

                    if (!Directory.Exists(xDir)) Directory.CreateDirectory(xDir);

                    for (int y = startY; y <= endY; y++)
                    {
                        if (area.Paused) //set this tile as current to resume from it next time
                        {
                            area.CurrentTile = new Zxy(z, x, y);

                            return true;
                        }

                        string fullUrl = url + (string.IsNullOrWhiteSpace(query) ? "" : "?" + query);

                        fullUrl = fullUrl.ToLower();
                        fullUrl = fullUrl.Replace("{z}", z.ToString());
                        fullUrl = fullUrl.Replace("{x}", x.ToString());
                        fullUrl = fullUrl.Replace("{y}", y.ToString());

                        string imgType = url.Substring(url.LastIndexOf(".") + 1);

                        if (imgType.Length > 9) imgType = "jpg";

                        string fullPath = Path.Combine(xDir, y + "." + imgType);

                        if(!NetManager.downloadTile(new Uri(fullUrl), fullPath))
                        {
                            area.Paused = true;
                            
                            area.CurrentTile = new Zxy(z, x, y);

                            return false;
                        }

                        dlProgress.DownloadedTilesCount++;
                    }
                }
            }

            area.Downloaded = true;
            return true;
        }
    }
}
