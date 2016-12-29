using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Offy.Core
{
    public class DownloadProgress : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int tilesCount;
        private int downloadedTilesCount;

        private Zxy currentTile;

        public DownloadProgress(int _tilesCount)
        {
            tilesCount = _tilesCount;
        }

        public int TilesCount
        {
            get { return tilesCount; }
        }

        public Zxy CurrentTile
        {
            get { return currentTile; }
            set { currentTile = value; }
        }

        public int DownloadedTilesCount
        {
            get {return downloadedTilesCount;}
            set
            {
                downloadedTilesCount = value;
                OnPropertyChanged("DownloadedTilesCount");
            }
        }

        protected void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
