using Offy.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Offy.ui
{
    public partial class TilesBrowser : Form
    {
        string viewer_folder = Path.Combine(Application.StartupPath, "Config", "areaviewer");
        string tilesPath;
        string imgType;
        Area area;


        public TilesBrowser(Area _area, string _imgType, string _tilesPath)
        {
            InitializeComponent();

            Gecko.Xpcom.Initialize("Xul");

            tilesPath = _tilesPath;
            area = _area;
            imgType = _imgType;
        }

        private void TilesBrowser_Load(object sender, EventArgs e)
        {
            browser.Navigate(Path.Combine(viewer_folder, "index.html"));
        }

        private void browser_DOMContentLoaded(object sender, Gecko.DomEventArgs e)
        {
            using (Gecko.AutoJSContext context = new Gecko.AutoJSContext(browser.Window))
            {
                string path = Path.Combine(tilesPath, "{z}", "{x}", "{y}." + imgType);
                Uri uri = new Uri(path);

                var result = context.EvaluateScript("javascript:addTileLayer('" + uri + "');");

                result = context.EvaluateScript("javascript:fitMapToExtent(" + area.Extent.getString() + ");");
                result = context.EvaluateScript("javascript:setZoom(" + (int)((area.Maxzoom + area.Minzoom)/2) + ");");
            }
        }
    }
}
