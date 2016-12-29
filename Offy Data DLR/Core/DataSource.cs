using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Offy.Core
{
    public class DataSource
    {
        private string name;
        private string url;
        private string query;
        private string imageType;

        public DataSource(string _url, string _name, string _query, string _imageType)
        {
            url = _url;
            name = _name;
            query = _query;
            imageType = _imageType;

            url = url.ToLower();

            url = url.Replace("${", "{");
            url = url.Replace("${", "{");
            url = url.Replace("${", "{");
        }

        public static DataSource defaultDataSource()
        {
            return new DataSource(
                "http://a.tile.openstreetmap.com/${z}/${x}/${y}.png",
                "Open Street Map",
                "",
                "png");
        }

        public string Url
        {
            get { return url; }
            set { url = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Query
        {
            get { return query; }
            set { query = value; }
        }

        public string ImageType
        {
            get { return imageType; }
            set { imageType = value; }
        }
    }
}
