using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Offy.Core
{
    public class Area
    {
        private string name;
        private string folderName;
        private Extent extent;
        private int minzoom;
        private int maxzoom;
        private bool getExtentFromMap;
        private string dataSourceName;
        private Zxy firstTile;
        private Zxy currentTile;
        private Zxy lastTile;
        private bool downloaded;
        private bool paused;
        private bool locked;
        private bool changed;
        private bool savedOnDisk;

        public static Area createNewArea()
        {
            return new Area(
                "newArea", 
                new Extent(-7.75, 33.5, -7.47, 33.63),
                "Open Street Map", 
                new Zxy(-1, -1, -1), 
                new Zxy(-1, -1, -1), 
                new Zxy(-1, -1, -1));
        }

        public Area(string _name, Extent _extent, string _dataSourceName, 
            Zxy _firstTile, Zxy _currentTile, Zxy _lastTile, int _minZoom = 4, int _maxZoom = 8,
            bool _getExtentFromMap = true, bool _downloaded = false, bool _paused = false,
            bool _locked = false, bool _changed = false, bool _saved = false)
        {
            name = _name;
            extent = _extent;
            minzoom = _minZoom;
            maxzoom = _maxZoom;
            getExtentFromMap = _getExtentFromMap;
            dataSourceName = _dataSourceName;
            firstTile = _firstTile;
            currentTile = _currentTile;
            lastTile = _lastTile;
            downloaded = _downloaded;
            paused = _paused;
            locked = _locked;
            changed = _changed;
            savedOnDisk = _saved;
        }

        public Area() { }

        public Area Clone()
        {
            return new Area(
                name, 
                extent, 
                dataSourceName, 
                firstTile, 
                currentTile, 
                lastTile, 
                minzoom, 
                maxzoom, 
                getExtentFromMap, 
                downloaded, 
                paused, 
                locked);
        }

        public static Area loadAreaFomDisk(string areaFolder)
        {
            return null;
        }

        public bool Compare(Area area)
        {
            if (name != area.name) return false;
            if (dataSourceName != area.dataSourceName) return false;
            if (minzoom != area.minzoom) return false;
            if (maxzoom != area.maxzoom) return false;
            if (getExtentFromMap != area.getExtentFromMap) return false;
            if (downloaded != area.downloaded) return false;
            if (paused != area.paused) return false;
            if (locked != area.locked) return false;

            if (extent.Compare(area.Extent)) return false;
            if (firstTile.Compare(area.FirstTile)) return false;
            if (currentTile.Compare(area.CurrentTile)) return false;
            if (lastTile.Compare(area.LastTile)) return false;

            return true;
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public Extent Extent
        {
            get
            {
                return extent;
            }

            set
            {
                extent = value;
            }
        }

        public int Minzoom
        {
            get
            {
                return minzoom;
            }

            set
            {
                minzoom = value;
            }
        }

        public int Maxzoom
        {
            get
            {
                return maxzoom;
            }

            set
            {
                maxzoom = value;
            }
        }

        public bool GetExtentFromMap
        {
            get
            {
                return getExtentFromMap;
            }

            set
            {
                getExtentFromMap = value;
            }
        }

        public string DataSourceName
        {
            get
            {
                return dataSourceName;
            }

            set
            {
                dataSourceName = value;
            }
        }

        public Zxy FirstTile
        {
            get
            {
                return firstTile;
            }

            set
            {
                firstTile = value;
            }
        }

        public Zxy CurrentTile
        {
            get
            {
                return currentTile;
            }

            set
            {
                currentTile = value;
            }
        }

        public Zxy LastTile
        {
            get
            {
                return lastTile;
            }

            set
            {
                lastTile = value;
            }
        }

        public bool Downloaded
        {
            get
            {
                return downloaded;
            }

            set
            {
                downloaded = value;
            }
        }

        public bool Paused
        {
            get
            {
                return paused;
            }

            set
            {
                paused = value;
            }
        }

        public bool SavedOnDisk
        {
            get
            {
                return savedOnDisk;
            }

            set
            {
                savedOnDisk = value;
            }
        }

        public bool Changed
        {
            get
            {
                return changed;
            }

            set
            {
                changed = value;
            }
        }

        public bool Locked
        {
            get
            {
                return locked;
            }

            set
            {
                locked = value;
            }
        }

        public string FolderName
        {
            get
            {
                return folderName;
            }

            set
            {
                folderName = value;
            }
        }
    }
}
