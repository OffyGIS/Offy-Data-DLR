using Offy.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Offy.ui
{
    public partial class Main : Form
    {
        private string config_Folder = Path.Combine(Application.StartupPath, "Config");
        private string viewer_Folder = Path.Combine(Application.StartupPath, "Config", "appviewer");
        private string areas_Folder = Path.Combine(Application.StartupPath, "Areas");
        
        private CultureInfo usC;
        private List<DataSource> dataSources;

        string AppName = "Offy Data DLR";
        private Area area;
        private int TilesCount;
        private DataSource selectedDataSource;

        DownloadProgress dlProgress;
        Thread downloadTilesThread;
        private bool isDownloading;
        private bool isOpeningArea;

        public Main()
        {
            InitializeComponent();
            usC = CultureInfo.CreateSpecificCulture("en-US");

            Gecko.Xpcom.Initialize("Xul");
        }

        private void initComboBox()
        {
            cbx_datasource.DataSource = dataSources;
            cbx_datasource.DisplayMember = "name";
        }

        private void Main_Load(object sender, EventArgs e)
        {
            browser.Navigate(Path.Combine(viewer_Folder, "index.html"));

            dataSources = FileManager.LoadDataSources(Path.Combine(config_Folder, "config.xml"));

            initComboBox();
        }

        private void LoadArea(Area _area)
        {
            if (_area == null) return;

            this.area = _area;

            this.tb_areaName.Text = area.Name;
            this.xMin.Text = area.Extent.Xmin.ToString(usC);
            this.yMin.Text = area.Extent.Ymin.ToString(usC);
            this.xMax.Text = area.Extent.Xmax.ToString(usC);
            this.yMax.Text = area.Extent.Ymax.ToString(usC);
            this.minZoom.Value = area.Minzoom;
            this.maxZoom.Value = area.Maxzoom;

            selectedDataSource = dataSources.Find(ds => ds.Name == area.DataSourceName);

            cbx_datasource.SelectedIndex = dataSources.IndexOf(selectedDataSource);

            this.Text = area.Name + "  -  " + this.AppName;

            setBaseMapFromUrl(selectedDataSource);

            drawExtentOnMap();
        }

        private void browser_DomClick(object sender, Gecko.DomMouseEventArgs e)
        {
            if (!getFromMap.Checked || lockArea.Checked) return;

            using (Gecko.AutoJSContext context = new Gecko.AutoJSContext(browser.Window))
            {
                var result = context.EvaluateScript("javascript:isDrawing();");
                if (result.ToBoolean()) return;

                result = context.EvaluateScript("javascript:getRectangleExtent();");
                
                if (result.ToString().ToLower() == "x") return;

                string[] list = result.ToString().Split(',');

                if (list.Length != 4) return;

                xMin.Text = list[0];
                yMin.Text = list[1];
                xMax.Text = list[2];
                yMax.Text = list[3];
            }
        }

        private void drawOnMap_Click(object sender, EventArgs e)
        {
            drawExtentOnMap();
        }

        private void btn_previewDS_Click(object sender, EventArgs e)
        {
            setBaseMapFromUrl(this.selectedDataSource);
        }

        private void browser_DOMContentLoaded(object sender, Gecko.DomEventArgs e)
        {
            setBaseMapFromUrl(this.selectedDataSource);

            if(area == null) LoadArea(Area.createNewArea());
        }

        private void setBaseMapFromUrl(DataSource ds)
        {
            if (cbx_datasource.SelectedIndex == -1) return;

            using (Gecko.AutoJSContext context = new Gecko.AutoJSContext(browser.Window))
            {
                var result = context.EvaluateScript("javascript:addTileLayer('" + ds.Url + (string.IsNullOrWhiteSpace(ds.Query) ? "" : "?" + ds.Query) + "');");
            }
        }

        private void drawExtentOnMap()
        {
            double min_x, min_y, max_x, max_y;

            if (!fieldValuesAreOK()) return;

            CultureInfo usC = CultureInfo.CreateSpecificCulture("en-US"); ;

            min_x = double.Parse(xMin.Text, NumberStyles.Number, usC);
            min_y = double.Parse(yMin.Text, NumberStyles.Number, usC);
            max_x = double.Parse(xMax.Text, NumberStyles.Number, usC);
            max_y = double.Parse(yMax.Text, NumberStyles.Number, usC);

            using (Gecko.AutoJSContext context = new Gecko.AutoJSContext(browser.Window))
            {
                var result = context.EvaluateScript("javascript:newBoxFromExtent(" + min_x.ToString(usC) + "," + min_y.ToString(usC) + "," + max_x.ToString(usC) + "," + max_y.ToString(usC) + ");");

                updateCounts();
            }
        }

        private void browser_DomMouseMove(object sender, Gecko.DomMouseEventArgs e)
        {
            updateMapLonLat();
            updateMapZoomLevel();
        }

        private void browser_CursorChanged(object sender, EventArgs e)
        {
            updateMapZoomLevel();
        }

        private void updateMapLonLat()
        {
            using (Gecko.AutoJSContext context = new Gecko.AutoJSContext(browser.Window))
            {
                var result = context.EvaluateScript("javascript:getMousePosition();");
                lbl_xy.Text = !result.Equals("undefined") ? result.ToString() : "0.00, 0.00";
            }
        }

        private void updateMapZoomLevel()
        {
            using (Gecko.AutoJSContext context = new Gecko.AutoJSContext(browser.Window))
            {
                var result = context.EvaluateScript("javascript:getZoom();");
                lbl_levelZoom.Text = "Zoom level:" + (!result.Equals("undefined") ? result.ToString() : "?");
            }
        }     

        private void browser_DomMouseOver(object sender, Gecko.DomMouseEventArgs e)
        {
            browser.Focus();
        }

        private void m_file_DropDownOpened(object sender, EventArgs e)
        {
            if (area == null) return;
            m_saveArea.Enabled = area.Changed;

            updateOpenAreaList();
        }

        private void updateOpenAreaList()
        {
            m_openArea.DropDownItems.Clear();

            foreach(var d in Directory.GetDirectories(areas_Folder))
            {
                string areaName = FileManager.getAreaName(Path.Combine(d, "area.areadef"));

                if (string.IsNullOrEmpty(areaName)) continue;

                DirectoryInfo dir = new DirectoryInfo(d);

                ToolStripMenuItem item = new ToolStripMenuItem();
                item.Text = areaName + ",  Directory: /" + dir.Name;
                item.ToolTipText = dir.Name;
                item.Click += new EventHandler(OpenAreaItem_Click);

                m_openArea.DropDownItems.Add(item);  
            }
        }

        private void OpenAreaItem_Click(object sender, EventArgs e)
        {
            if (this.isDownloading)
            {
                Message_Box("Please wait until the download is completed, or pause it, to be able to reset the download");
                return;
            }

            this.isOpeningArea = true;

            ToolStripMenuItem item = (ToolStripMenuItem)sender;

            string path = Path.Combine(areas_Folder, item.ToolTipText);

            if (File.Exists(Path.Combine(path, "area.areadef")))
            {
                LoadArea(FileManager.openArea(Path.Combine(path, "area.areadef")));
            }
            else
            {
                Message_Box("Invalid area! No \"area.areadef\" file found.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (area.Paused) updateButtons('p');
            if (area.Downloaded) updateButtons('c');
            if (!area.Paused && !area.Downloaded) updateButtons('i');

            this.Text = area.Name + ",  Directory: /" + item.ToolTipText + "  -  " + this.AppName;

            this.isOpeningArea = false;

            updateCounts();

            saveArea();
        }

        private void lockArea_CheckedChanged(object sender, EventArgs e)
        {
            area.Changed = true;

            if (lockArea.Checked)
            {
                setting_panel.Enabled = false;
                return;
            }

            if(!lockArea.Checked)
            {
                setting_panel.Enabled = true;
                return;
            }
        }

        private void m_newArea_Click(object sender, EventArgs e)
        {
            if (this.isDownloading)
            {
                Message_Box("Please wait until the download is completed, or pause it, to be able to reset the download");
                return;
            }
            if (area.Changed)
            {
                DialogResult result = Message_Box("Current area not saved! \nDo you want to save it ?", MessageBoxButtons.YesNoCancel);

                if (result == DialogResult.Cancel) return;

                if (result == DialogResult.OK) saveArea();
            }

            LoadArea(Area.createNewArea());

            updateButtons('i');

            this.Text = area.Name + "  -  " + this.AppName;
        }

        private void m_saveArea_Click(object sender, EventArgs e)
        {
            saveArea();

            this.Text = area.Name + "  -  " + this.AppName;
        }

        private void saveArea()
        {
            if (!stringIsAlphaNumeric(tb_areaName.Text)) return;

            area.Name = tb_areaName.Text;

            if (!fieldValuesAreOK()) return;

            double min_x, min_y, max_x, max_y;
            CultureInfo usC = CultureInfo.CreateSpecificCulture("en-US"); ;

            min_x = double.Parse(xMin.Text, NumberStyles.Number, usC);
            min_y = double.Parse(yMin.Text, NumberStyles.Number, usC);
            max_x = double.Parse(xMax.Text, NumberStyles.Number, usC);
            max_y = double.Parse(yMax.Text, NumberStyles.Number, usC);

            area.Extent = new Extent(min_x, min_y, max_x, max_y);

            area.Minzoom = (int)minZoom.Value;
            area.Maxzoom = (int)maxZoom.Value;

            area.DataSourceName = selectedDataSource.Name;

            area.GetExtentFromMap = getFromMap.Checked;
            area.Locked = lockArea.Checked;

            FileManager.saveArea(areas_Folder, area);

            area.Changed = false;
            area.SavedOnDisk = true;
        }

        private bool stringIsAlphaNumeric(string value)
        {
            if (string.IsNullOrEmpty(value)) return false;

            for (int i = 0; i < value.Length; i++)
            {
                if (!char.IsLetter(value[i]) && !char.IsNumber(value[i]))
                {
                    Message_Box("Area name should contain olny alpha-numeric characters !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            return true;
        }

        private bool fieldValuesAreOK()
        {
            double dVal;
            int iVal;

            CultureInfo usC = CultureInfo.CreateSpecificCulture("en-US"); ;

            if (!double.TryParse(xMin.Text, NumberStyles.Number, usC, out dVal)) return false;
            if (!double.TryParse(yMin.Text, NumberStyles.Number, usC, out dVal)) return false;
            if (!double.TryParse(xMax.Text, NumberStyles.Number, usC, out dVal)) return false;
            if (!double.TryParse(yMax.Text, NumberStyles.Number, usC, out dVal)) return false;
            if (!int.TryParse(minZoom.Text, NumberStyles.Number, usC, out iVal)) return false;
            if (!int.TryParse(maxZoom.Text, NumberStyles.Number, usC, out iVal)) return false;

            return true;
        }

        private DialogResult Message_Box(string message, MessageBoxButtons btns = MessageBoxButtons.OK, MessageBoxIcon icon = MessageBoxIcon.Information)
        {
            return MessageBox.Show(message, this.AppName, btns, icon);
        }

        private void tb_areaName_TextChanged(object sender, EventArgs e)
        {
            settingsChanged();
        }
        private void maxY_TextChanged(object sender, EventArgs e)
        {
            settingsChanged();

            if (area.Downloaded || area.Paused) alertSettingsChanged("Y max");
        }

        private void yMin_TextChanged(object sender, EventArgs e)
        {
            settingsChanged();

            if (area.Downloaded || area.Paused) alertSettingsChanged("Y min");
        }

        private void xMin_TextChanged(object sender, EventArgs e)
        {
            settingsChanged();

            if (area.Downloaded || area.Paused) alertSettingsChanged("X min");
        }

        private void xMax_TextChanged(object sender, EventArgs e)
        {
            settingsChanged();

            if (area.Downloaded || area.Paused) alertSettingsChanged("X max");
        }

        private void minZoom_ValueChanged(object sender, EventArgs e)
        {
            settingsChanged();

            if (area.Downloaded || area.Paused) alertSettingsChanged("Zoom min");
        }

        private void maxZoom_ValueChanged(object sender, EventArgs e)
        {
            settingsChanged();

            if (area.Downloaded || area.Paused) alertSettingsChanged("Zoom max");
        }

        private void settingsChanged()
        {
            updateCounts();
            area.Changed = true;
        }

        private void cbx_datasource_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbx_datasource.SelectedIndex == -1) return;

            lbl_url.Text = "Url: " + ((DataSource)cbx_datasource.SelectedItem).Url;

            string imgType = (((DataSource)cbx_datasource.SelectedItem)).Url.Substring((((DataSource)cbx_datasource.SelectedItem)).Url.LastIndexOf(".") + 1);
            if (imgType.Length > 9) imgType = "jpg";
            lbl_urlImageType.Text = "Image type: " + imgType.ToUpper();

            lbl_urlQuery.Text = "Query: " + ((DataSource)cbx_datasource.SelectedItem).Query;

            if (area != null)
            {
                area.Changed = true;

                if (area.Downloaded || area.Paused) alertSettingsChanged("Data source");
            }

            selectedDataSource = ((DataSource)cbx_datasource.SelectedItem);
        }

        private void updateCounts()
        {
            double min_x, min_y, max_x, max_y;
            int min_z, max_z;

            if (!fieldValuesAreOK()) return;

            CultureInfo usC = CultureInfo.CreateSpecificCulture("en-US"); ;

            min_x = double.Parse(xMin.Text, NumberStyles.Number, usC);
            min_y = double.Parse(yMin.Text, NumberStyles.Number, usC);
            max_x = double.Parse(xMax.Text, NumberStyles.Number, usC);
            max_y = double.Parse(yMax.Text, NumberStyles.Number, usC);

            min_z = (int)minZoom.Value;
            max_z = (int)maxZoom.Value;

            lbl_zoomCount.Text = "Zoom levels = " + (maxZoom.Value - minZoom.Value + 1).ToString();
            this.TilesCount = TileManager.getTilesCount(new Extent(min_x, min_y, max_x, max_y), min_z, max_z);
            lbl_tileCount.Text = "Tiles = " + this.TilesCount;

            area.FirstTile = TileManager.getFirstTileAtZ(new Extent(min_x, min_y, max_x, max_y), min_z);
            area.LastTile = TileManager.getLastTileAtZ(new Extent(min_x, min_y, max_x, max_y), max_z);

            lbl_alert.Text = "";
            lbl_alert.Visible = false;

            if (this.TilesCount > 300000)
            {
                lbl_alert.Text += "The number of tiles is very big. It will slow down the tile server.\nYour machine may be affected too !";
                lbl_alert.Visible = true; 
            }
            if (maxZoom.Value > 16)
            {
                if (this.TilesCount > 300000) lbl_alert.Text += "\n\n";
                lbl_alert.Text += "In general zoom level 16 is more than enough to have more than 90% of details.\nPlease use 17 and 18 levels only for a very small areas.";
                lbl_alert.Visible = true;
            }
        }

        private void alertSettingsChanged(string propertyName)
        {
            if (this.isOpeningArea) return;

            Message_Box("\"" + propertyName + "\"" + " changed! This will affect the downloaded tiles."
                + "\n\nIf you want to download tiles using new settings, make sure you empty the \"Tiles\" folder before starting the new download.");
        }

        private void getFromMap_CheckedChanged(object sender, EventArgs e)
        {
            area.Changed = true;
        }

        private void btn_download_Click(object sender, EventArgs e)
        {
            if(area.Changed || !area.SavedOnDisk)
            {
                Message_Box("Please save the area before start downloading!");
                return;
            }
            if (minZoom.Value > maxZoom.Value)
            {
                Message_Box("Min zoom value sould be less than the max zoom!");
                return;
            }
            if (!NetManager.checkInternetConnection())
            {
                Message_Box("Please verify your internet connection and try again!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!NetManager.checkUrl(selectedDataSource))
            {
                Message_Box("The selected datasource is not found or temporary unavailable !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            updateButtons('d');

            downloadTilesThread = new Thread(new ThreadStart(downloadTiles));
            downloadTilesThread.Name = this.AppName + " Downloader";
            downloadTilesThread.Start();
        }

        private void DlProgress_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (dlProgress.TilesCount != dlProgress.DownloadedTilesCount)
            {
                lbl_downloading.Invoke((MethodInvoker)(() => lbl_downloading.Text =
                    "Downloading... " + dlProgress.DownloadedTilesCount + "/" + dlProgress.TilesCount +
                    " (" + (Math.Floor(((dlProgress.DownloadedTilesCount * 1d / dlProgress.TilesCount) * 100d))) + "%)"));
                
                return;
            }

            lbl_downloading.Invoke((MethodInvoker)(() => lbl_downloading.Text =
                    "Download completed. " + dlProgress.DownloadedTilesCount + "/" + dlProgress.TilesCount +
                    " (" + (Math.Floor(((dlProgress.DownloadedTilesCount / dlProgress.TilesCount) * 100d))) + "%)."));
        }

        private void btn_resume_Click(object sender, EventArgs e)
        {
            if (area.Changed)
            {
                Message_Box("You cannot resume downloading if the area settings were changed! You could cancel changes and resume your downloading. Otherwise, initialize the area download, clear the \"Tiles\" folder and start the download again.");
                return;
            }
            if (minZoom.Value > maxZoom.Value)
            {
                Message_Box("Min zoom value sould be less than the max zoom!");
                return;
            }
            if (!NetManager.checkInternetConnection())
            {
                Message_Box("Please verify your internet connection and try again !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!NetManager.checkUrl(selectedDataSource))
            {
                Message_Box("The selected data source is inaccessible or temporary unavailable !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            updateButtons('r');

            downloadTilesThread = new Thread(new ThreadStart(downloadTiles));
            downloadTilesThread.Name = this.AppName + " Downloader";
            downloadTilesThread.Start();
        }

        private void downloadTiles()
        {
            dlProgress = new DownloadProgress(TilesCount);

            if (area.Paused)
            {
                dlProgress.DownloadedTilesCount = TileManager.getTilesCountToTile(area.Extent, area.CurrentTile, area.Minzoom);
            }

            dlProgress.PropertyChanged += new PropertyChangedEventHandler(DlProgress_PropertyChanged);

            string tilesFolder = Path.Combine(areas_Folder, area.FolderName, "Tiles");

            DataSource ds = dataSources.Find(DataSource => DataSource.Name == area.DataSourceName);

            string urlLastPart = "";

            if (!string.IsNullOrWhiteSpace(ds.Query)) urlLastPart += "?" + ds.Query;

            if(!TileManager.downloadTiles(area, selectedDataSource.Url, urlLastPart, tilesFolder, dlProgress))
            {
                Message_Box("Download paused automatically!!\n\nThere was an error when downloading current tile. Be sure:"
                    + "   \n- You have internet connexion."
                    + "   \n- Your Security system is allowing you to access the tile server."
                    + "   \n- the tile server is not blocking your Ip Address.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (area.Downloaded) updateButtons('c');// download completed
            if (area.Paused) updateButtons('p');// download completed

            saveArea();
        }

        private void btn_pause_Click(object sender, EventArgs e)
        {
            updateButtons('p');

            area.Paused = true;
        }

        private void updateButtons(char c)
        {
            if (c == 'd') //start downloading
            {
                btn_download.Enabled = false;
                btn_pause.Enabled = true;
                btn_resume.Enabled = false;

                this.isDownloading = true;
                lockArea.Checked = true;
                lockArea.Enabled = false;
            }
            else if (c == 'p') //pause downloading
            {
                btn_pause.Invoke((MethodInvoker)(() => btn_pause.Enabled = false));
                btn_resume.Invoke((MethodInvoker)(() => btn_resume.Enabled = true));
                btn_download.Invoke((MethodInvoker)(() => btn_download.Enabled = false));

                lockArea.Invoke((MethodInvoker)(() => lockArea.Enabled = false));
                lockArea.Invoke((MethodInvoker)(() => lockArea.Checked = true));

                this.isDownloading = false;

                lbl_downloading.Invoke((MethodInvoker)(() => lbl_downloading.Text = "Downloading: paused"));
            }
            else if (c == 'r') //resume downloading
            {
                btn_resume.Enabled = false;
                btn_pause.Enabled = true;
                btn_download.Enabled = false;

                this.isDownloading = true;

                lockArea.Checked = true;
                lockArea.Enabled = false;

                lbl_downloading.Text = "Downloading...";
            }
            else if (c == 'c') //download completed
            {
                btn_download.Invoke((MethodInvoker)(() => btn_download.Enabled = false));
                btn_pause.Invoke((MethodInvoker)(() => btn_pause.Enabled = false));
                btn_resume.Invoke((MethodInvoker)(() => btn_resume.Enabled = false));

                this.isDownloading = false;

                lockArea.Invoke((MethodInvoker)(() => lockArea.Enabled = false));
                lockArea.Invoke((MethodInvoker)(() => lockArea.Checked = true));

                lbl_downloading.Invoke((MethodInvoker)(() => lbl_downloading.Text = "Download completed"));
            }
            else // initial status
            {
                btn_download.Invoke((MethodInvoker)(() => btn_download.Enabled = true));
                btn_pause.Invoke((MethodInvoker)(() => btn_pause.Enabled = false));
                btn_resume.Invoke((MethodInvoker)(() => btn_resume.Enabled = false));

                this.isDownloading = false;

                lockArea.Invoke((MethodInvoker)(() => lockArea.Enabled = true));
                lockArea.Invoke((MethodInvoker)(() => lockArea.Checked = area.Locked));


                lbl_downloading.Invoke((MethodInvoker)(() => lbl_downloading.Text = "Downloading: not started"));
            }
        }

        private void degrees_m_CheckedChanged(object sender, EventArgs e)
        {
            manageScaleUnitsToolStris((ToolStripMenuItem)sender);
            changeMapScaleUnits("degrees");
        }

        private void imperialInch_m_CheckedChanged(object sender, EventArgs e)
        {
            manageScaleUnitsToolStris((ToolStripMenuItem)sender);
            changeMapScaleUnits("imperial");
        }

        private void uSInch_m_CheckedChanged(object sender, EventArgs e)
        {
            manageScaleUnitsToolStris((ToolStripMenuItem)sender);
            changeMapScaleUnits("us");
        }

        private void nauticalMile_m_CheckedChanged(object sender, EventArgs e)
        {
            manageScaleUnitsToolStris((ToolStripMenuItem)sender);
            changeMapScaleUnits("nautical");
        }

        private void metric_m_CheckedChanged(object sender, EventArgs e)
        {
            manageScaleUnitsToolStris((ToolStripMenuItem)sender);
            changeMapScaleUnits("metric");
        }

        private void manageScaleUnitsToolStris(ToolStripMenuItem selectedItem)
        {
            foreach(ToolStripMenuItem item in m_mapScale.DropDownItems)
            {
                if (item.Equals(selectedItem)) continue;
                item.Checked = false;
            }
        }

        private void changeMapScaleUnits(string units)
        {
            using (Gecko.AutoJSContext context = new Gecko.AutoJSContext(browser.Window))
            {
                context.EvaluateScript("javascript:changeScaleUnits('" + units + "');");
            }
        }

        private void m_area_folder_Click(object sender, EventArgs e)
        {
            if (area == null || !area.SavedOnDisk) return;
            System.Diagnostics.Process.Start(Path.Combine(this.areas_Folder, area.FolderName));
        }

        private void m_tilesFolder_Click(object sender, EventArgs e)
        {
            if (area == null || string.IsNullOrEmpty(area.FolderName) || !area.SavedOnDisk) return;

            System.Diagnostics.Process.Start(Path.Combine(this.areas_Folder, area.FolderName, "Tiles"));
        }

        private void m_initializeArea_Click(object sender, EventArgs e)
        {
            if (area == null) return;
            if (!area.SavedOnDisk) return;
            if (!area.Downloaded && !area.Paused) return;
            if(this.isDownloading)
            {
                Message_Box("Please wait until the download is completed, or pause it, to be able to reset the download");
                return;
            }

            area.Downloaded = false;
            area.Paused = false;
            area.CurrentTile = new Zxy(-1, -1, -1);

            updateButtons('i');

            saveArea();

            Message_Box("The download is initialized. Now, you could change your settings, but make sure you delete the old content from the \"Tiles\" folder, before starting a new download.");
        }

        private void m_browseDownloadedTiles_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(area.FolderName)) return;

            string tilesDir = Path.Combine(areas_Folder, area.FolderName, "Tiles");

            TilesBrowser areaViewer = new TilesBrowser(area, selectedDataSource.ImageType, tilesDir);
            areaViewer.ShowDialog(this);
        }

        private void m_tilesSummary_Click(object sender, EventArgs e)
        {
            double min_x, min_y, max_x, max_y;
            CultureInfo usC = CultureInfo.CreateSpecificCulture("en-US");

            min_x = double.Parse(xMin.Text, NumberStyles.Number, usC);
            min_y = double.Parse(yMin.Text, NumberStyles.Number, usC);
            max_x = double.Parse(xMax.Text, NumberStyles.Number, usC);
            max_y = double.Parse(yMax.Text, NumberStyles.Number, usC);

            Extent extent = new Extent(min_x, min_y, max_x, max_y);

            Message_Box(TileManager.getTilesSummary(extent, (int)minZoom.Value, (int)maxZoom.Value));
        }

        private void m_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            closeApp(e);
        }

        private void closeApp(FormClosingEventArgs arg)
        {
            if (this.isDownloading)
            {
                if(arg.CloseReason == CloseReason.WindowsShutDown || arg.CloseReason == CloseReason.TaskManagerClosing)
                {
                    area.Paused = true; //to terminate the download thread process and wait to force closing by the system

                    while(downloadTilesThread.ThreadState == ThreadState.Running) { Thread.Sleep(5000); }

                    downloadTilesThread.Interrupt();
                    downloadTilesThread = null;

                    return;
                }

                Message_Box("Please wait until the download is completed, or pause it, to be able to close the application");
                arg.Cancel = true;

                return;
            }

            if(area.Changed)
            {
                if (arg.CloseReason == CloseReason.WindowsShutDown || arg.CloseReason == CloseReason.TaskManagerClosing)
                {
                    saveArea();
                }
                else
                {
                    var result = Message_Box("Do you want to save this area before closing the application ?", MessageBoxButtons.YesNoCancel);

                    if (result == DialogResult.Yes)
                    {
                        saveArea();

                        Message_Box("Area saved successfully.");
                    }
                    else if (result == DialogResult.Cancel)
                    {
                        if (arg != null) arg.Cancel = true;
                    }
                }
            }
        }

        enum Proj
        {
            WGS84 = 0,
            WEBMERCA = 1,
            PVMERCA = 2
        }

        private void m_getExtentWGS84_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(getExtent(Proj.WGS84));
        }

        private void m_getExtentWebMercator_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(getExtent(Proj.WEBMERCA));
        }

        private string getExtent(Proj proj)
        {
            double min_x, min_y, max_x, max_y;
            CultureInfo usC = CultureInfo.CreateSpecificCulture("en-US"); ;

            min_x = double.Parse(xMin.Text, NumberStyles.Number, usC);
            min_y = double.Parse(yMin.Text, NumberStyles.Number, usC);
            max_x = double.Parse(xMax.Text, NumberStyles.Number, usC);
            max_y = double.Parse(yMax.Text, NumberStyles.Number, usC);

            Extent extent = new Extent(min_x, min_y, max_x, max_y);

            if (proj == Proj.WGS84) return extent.getString();

            string toProj = "";

            if (proj == Proj.WEBMERCA)
                toProj = "EPSG:3857";
            else if (proj == Proj.PVMERCA)
                toProj = "EPSG:3785";

            using (Gecko.AutoJSContext context = new Gecko.AutoJSContext(browser.Window))
            {
                var result = context.EvaluateScript("ol.proj.transformExtent([" + extent.getString() + "],'EPSG:4326','" + toProj + "');");

                return result.ToString();
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About frm = new About(this.AppName);
            frm.ShowDialog(this);
        }

        private void tilesUsagePolicyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UsagePolicy frm = new UsagePolicy();
            frm.ShowDialog(this);
        }

        private void m_exportGdalWmsFile_Click(object sender, EventArgs e)
        {
            if (area == null || !area.SavedOnDisk) return;
            string msg;

            if (FileManager.saveTMSDefFile(this.areas_Folder, area, selectedDataSource.ImageType))
                msg = "TMS file definition created successfully.";
            else
                msg = "The TMS file was not created! Verify if an old version is opened by another program.";

            Message_Box(msg);
        }
    }
}