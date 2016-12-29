namespace Offy.ui
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.setting_panel = new System.Windows.Forms.Panel();
            this.drawOnMap = new System.Windows.Forms.Button();
            this.gb_source = new System.Windows.Forms.GroupBox();
            this.lbl_urlQuery = new System.Windows.Forms.Label();
            this.lbl_urlImageType = new System.Windows.Forms.Label();
            this.lbl_url = new System.Windows.Forms.Label();
            this.btn_previewDS = new System.Windows.Forms.Button();
            this.cbx_datasource = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.getFromMap = new System.Windows.Forms.CheckBox();
            this.lbl_tileCount = new System.Windows.Forms.Label();
            this.lbl_zoomCount = new System.Windows.Forms.Label();
            this.maxZoom = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.minZoom = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.xMax = new System.Windows.Forms.TextBox();
            this.yMin = new System.Windows.Forms.TextBox();
            this.xMin = new System.Windows.Forms.TextBox();
            this.yMax = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_areaName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_download = new System.Windows.Forms.Button();
            this.btn_resume = new System.Windows.Forms.Button();
            this.btn_pause = new System.Windows.Forms.Button();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.m_file = new System.Windows.Forms.ToolStripMenuItem();
            this.m_newArea = new System.Windows.Forms.ToolStripMenuItem();
            this.m_openArea = new System.Windows.Forms.ToolStripMenuItem();
            this.m_sep1 = new System.Windows.Forms.ToolStripSeparator();
            this.m_saveArea = new System.Windows.Forms.ToolStripMenuItem();
            this.m_sep2 = new System.Windows.Forms.ToolStripSeparator();
            this.m_exit = new System.Windows.Forms.ToolStripMenuItem();
            this.m_tools = new System.Windows.Forms.ToolStripMenuItem();
            this.m_area_folder = new System.Windows.Forms.ToolStripMenuItem();
            this.m_tilesFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.m_tilesSummary = new System.Windows.Forms.ToolStripMenuItem();
            this.m_browseDownloadedTiles = new System.Windows.Forms.ToolStripMenuItem();
            this.m_exportGdalWmsFile = new System.Windows.Forms.ToolStripMenuItem();
            this.m_initializeArea = new System.Windows.Forms.ToolStripMenuItem();
            this.m_sep3 = new System.Windows.Forms.ToolStripSeparator();
            this.m_copyExtent = new System.Windows.Forms.ToolStripMenuItem();
            this.m_getExtentWGS84 = new System.Windows.Forms.ToolStripMenuItem();
            this.m_getExtentWebMercator = new System.Windows.Forms.ToolStripMenuItem();
            this.m_mapScale = new System.Windows.Forms.ToolStripMenuItem();
            this.m_degrees = new System.Windows.Forms.ToolStripMenuItem();
            this.m_imperialInch = new System.Windows.Forms.ToolStripMenuItem();
            this.m_usInch = new System.Windows.Forms.ToolStripMenuItem();
            this.m_nauticalMile = new System.Windows.Forms.ToolStripMenuItem();
            this.m_metric = new System.Windows.Forms.ToolStripMenuItem();
            this.m_more = new System.Windows.Forms.ToolStripMenuItem();
            this.m_about = new System.Windows.Forms.ToolStripMenuItem();
            this.m_usagePolicy = new System.Windows.Forms.ToolStripMenuItem();
            this.right_panel = new System.Windows.Forms.Panel();
            this.lbl_alert = new System.Windows.Forms.Label();
            this.browser = new Gecko.GeckoWebBrowser();
            this.bottom = new System.Windows.Forms.Panel();
            this.lbl_downloading = new System.Windows.Forms.Label();
            this.lockArea = new System.Windows.Forms.CheckBox();
            this.lbl_levelZoom = new System.Windows.Forms.Label();
            this.lbl_xy = new System.Windows.Forms.Label();
            this.left_panel = new System.Windows.Forms.Panel();
            this.setting_panel.SuspendLayout();
            this.gb_source.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxZoom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minZoom)).BeginInit();
            this.menu.SuspendLayout();
            this.right_panel.SuspendLayout();
            this.bottom.SuspendLayout();
            this.left_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // setting_panel
            // 
            this.setting_panel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.setting_panel.BackColor = System.Drawing.Color.White;
            this.setting_panel.Controls.Add(this.drawOnMap);
            this.setting_panel.Controls.Add(this.gb_source);
            this.setting_panel.Controls.Add(this.label8);
            this.setting_panel.Controls.Add(this.label7);
            this.setting_panel.Controls.Add(this.label6);
            this.setting_panel.Controls.Add(this.label5);
            this.setting_panel.Controls.Add(this.getFromMap);
            this.setting_panel.Controls.Add(this.lbl_tileCount);
            this.setting_panel.Controls.Add(this.lbl_zoomCount);
            this.setting_panel.Controls.Add(this.maxZoom);
            this.setting_panel.Controls.Add(this.label4);
            this.setting_panel.Controls.Add(this.minZoom);
            this.setting_panel.Controls.Add(this.label3);
            this.setting_panel.Controls.Add(this.xMax);
            this.setting_panel.Controls.Add(this.yMin);
            this.setting_panel.Controls.Add(this.xMin);
            this.setting_panel.Controls.Add(this.yMax);
            this.setting_panel.Controls.Add(this.label2);
            this.setting_panel.Controls.Add(this.tb_areaName);
            this.setting_panel.Controls.Add(this.label1);
            this.setting_panel.Location = new System.Drawing.Point(0, 30);
            this.setting_panel.Name = "setting_panel";
            this.setting_panel.Size = new System.Drawing.Size(300, 370);
            this.setting_panel.TabIndex = 1;
            // 
            // drawOnMap
            // 
            this.drawOnMap.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.drawOnMap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.drawOnMap.ForeColor = System.Drawing.Color.White;
            this.drawOnMap.Location = new System.Drawing.Point(218, 150);
            this.drawOnMap.Name = "drawOnMap";
            this.drawOnMap.Size = new System.Drawing.Size(69, 23);
            this.drawOnMap.TabIndex = 18;
            this.drawOnMap.Text = "Draw >>";
            this.drawOnMap.UseVisualStyleBackColor = false;
            this.drawOnMap.Click += new System.EventHandler(this.drawOnMap_Click);
            // 
            // gb_source
            // 
            this.gb_source.Controls.Add(this.lbl_urlQuery);
            this.gb_source.Controls.Add(this.lbl_urlImageType);
            this.gb_source.Controls.Add(this.lbl_url);
            this.gb_source.Controls.Add(this.btn_previewDS);
            this.gb_source.Controls.Add(this.cbx_datasource);
            this.gb_source.Location = new System.Drawing.Point(12, 262);
            this.gb_source.Name = "gb_source";
            this.gb_source.Size = new System.Drawing.Size(275, 101);
            this.gb_source.TabIndex = 0;
            this.gb_source.TabStop = false;
            this.gb_source.Text = "Data source";
            // 
            // lbl_urlQuery
            // 
            this.lbl_urlQuery.AutoSize = true;
            this.lbl_urlQuery.Location = new System.Drawing.Point(6, 77);
            this.lbl_urlQuery.Name = "lbl_urlQuery";
            this.lbl_urlQuery.Size = new System.Drawing.Size(38, 13);
            this.lbl_urlQuery.TabIndex = 25;
            this.lbl_urlQuery.Text = "Query:";
            // 
            // lbl_urlImageType
            // 
            this.lbl_urlImageType.AutoSize = true;
            this.lbl_urlImageType.Location = new System.Drawing.Point(6, 60);
            this.lbl_urlImageType.Name = "lbl_urlImageType";
            this.lbl_urlImageType.Size = new System.Drawing.Size(65, 13);
            this.lbl_urlImageType.TabIndex = 24;
            this.lbl_urlImageType.Text = "Image type: ";
            // 
            // lbl_url
            // 
            this.lbl_url.AutoSize = true;
            this.lbl_url.Location = new System.Drawing.Point(6, 43);
            this.lbl_url.Name = "lbl_url";
            this.lbl_url.Size = new System.Drawing.Size(26, 13);
            this.lbl_url.TabIndex = 23;
            this.lbl_url.Text = "Url: ";
            // 
            // btn_previewDS
            // 
            this.btn_previewDS.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_previewDS.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_previewDS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_previewDS.ForeColor = System.Drawing.Color.White;
            this.btn_previewDS.Location = new System.Drawing.Point(211, 19);
            this.btn_previewDS.Name = "btn_previewDS";
            this.btn_previewDS.Size = new System.Drawing.Size(56, 23);
            this.btn_previewDS.TabIndex = 22;
            this.btn_previewDS.Text = "Preview";
            this.btn_previewDS.UseVisualStyleBackColor = false;
            this.btn_previewDS.Click += new System.EventHandler(this.btn_previewDS_Click);
            // 
            // cbx_datasource
            // 
            this.cbx_datasource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_datasource.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbx_datasource.FormattingEnabled = true;
            this.cbx_datasource.Location = new System.Drawing.Point(6, 19);
            this.cbx_datasource.Name = "cbx_datasource";
            this.cbx_datasource.Size = new System.Drawing.Size(171, 21);
            this.cbx_datasource.TabIndex = 0;
            this.cbx_datasource.SelectedIndexChanged += new System.EventHandler(this.cbx_datasource_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(133, 49);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Max Y";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(133, 140);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Min Y";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Min X";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(220, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Max X";
            // 
            // getFromMap
            // 
            this.getFromMap.AutoSize = true;
            this.getFromMap.Checked = true;
            this.getFromMap.CheckState = System.Windows.Forms.CheckState.Checked;
            this.getFromMap.Location = new System.Drawing.Point(12, 156);
            this.getFromMap.Name = "getFromMap";
            this.getFromMap.Size = new System.Drawing.Size(119, 17);
            this.getFromMap.TabIndex = 13;
            this.getFromMap.Text = "get extent from map";
            this.getFromMap.UseVisualStyleBackColor = true;
            this.getFromMap.CheckedChanged += new System.EventHandler(this.getFromMap_CheckedChanged);
            // 
            // lbl_tileCount
            // 
            this.lbl_tileCount.AutoSize = true;
            this.lbl_tileCount.Location = new System.Drawing.Point(103, 235);
            this.lbl_tileCount.Name = "lbl_tileCount";
            this.lbl_tileCount.Size = new System.Drawing.Size(50, 13);
            this.lbl_tileCount.TabIndex = 12;
            this.lbl_tileCount.Text = "Tiles = ...";
            // 
            // lbl_zoomCount
            // 
            this.lbl_zoomCount.AutoSize = true;
            this.lbl_zoomCount.Location = new System.Drawing.Point(12, 235);
            this.lbl_zoomCount.Name = "lbl_zoomCount";
            this.lbl_zoomCount.Size = new System.Drawing.Size(85, 13);
            this.lbl_zoomCount.TabIndex = 11;
            this.lbl_zoomCount.Text = "Zoom levels = ...";
            // 
            // maxZoom
            // 
            this.maxZoom.Location = new System.Drawing.Point(247, 203);
            this.maxZoom.Maximum = new decimal(new int[] {
            18,
            0,
            0,
            0});
            this.maxZoom.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.maxZoom.Name = "maxZoom";
            this.maxZoom.Size = new System.Drawing.Size(40, 20);
            this.maxZoom.TabIndex = 10;
            this.maxZoom.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.maxZoom.ValueChanged += new System.EventHandler(this.maxZoom_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(156, 205);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Max zoom:";
            // 
            // minZoom
            // 
            this.minZoom.Location = new System.Drawing.Point(73, 203);
            this.minZoom.Maximum = new decimal(new int[] {
            18,
            0,
            0,
            0});
            this.minZoom.Name = "minZoom";
            this.minZoom.Size = new System.Drawing.Size(40, 20);
            this.minZoom.TabIndex = 8;
            this.minZoom.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.minZoom.ValueChanged += new System.EventHandler(this.minZoom_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 205);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Min zoom:";
            // 
            // xMax
            // 
            this.xMax.Location = new System.Drawing.Point(187, 91);
            this.xMax.Name = "xMax";
            this.xMax.Size = new System.Drawing.Size(100, 20);
            this.xMax.TabIndex = 6;
            this.xMax.TextChanged += new System.EventHandler(this.xMax_TextChanged);
            // 
            // yMin
            // 
            this.yMin.Location = new System.Drawing.Point(99, 117);
            this.yMin.Name = "yMin";
            this.yMin.Size = new System.Drawing.Size(100, 20);
            this.yMin.TabIndex = 5;
            this.yMin.TextChanged += new System.EventHandler(this.yMin_TextChanged);
            // 
            // xMin
            // 
            this.xMin.Location = new System.Drawing.Point(12, 91);
            this.xMin.Name = "xMin";
            this.xMin.Size = new System.Drawing.Size(100, 20);
            this.xMin.TabIndex = 4;
            this.xMin.TextChanged += new System.EventHandler(this.xMin_TextChanged);
            // 
            // yMax
            // 
            this.yMax.Location = new System.Drawing.Point(99, 65);
            this.yMax.Name = "yMax";
            this.yMax.Size = new System.Drawing.Size(100, 20);
            this.yMax.TabIndex = 3;
            this.yMax.TextChanged += new System.EventHandler(this.maxY_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Extent:";
            // 
            // tb_areaName
            // 
            this.tb_areaName.Location = new System.Drawing.Point(87, 3);
            this.tb_areaName.Name = "tb_areaName";
            this.tb_areaName.Size = new System.Drawing.Size(200, 20);
            this.tb_areaName.TabIndex = 1;
            this.tb_areaName.TextChanged += new System.EventHandler(this.tb_areaName_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Area name:";
            // 
            // btn_download
            // 
            this.btn_download.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_download.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_download.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_download.ForeColor = System.Drawing.Color.White;
            this.btn_download.Location = new System.Drawing.Point(12, 414);
            this.btn_download.Name = "btn_download";
            this.btn_download.Size = new System.Drawing.Size(69, 23);
            this.btn_download.TabIndex = 19;
            this.btn_download.Text = "Download";
            this.btn_download.UseVisualStyleBackColor = false;
            this.btn_download.Click += new System.EventHandler(this.btn_download_Click);
            // 
            // btn_resume
            // 
            this.btn_resume.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_resume.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_resume.Enabled = false;
            this.btn_resume.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_resume.ForeColor = System.Drawing.Color.White;
            this.btn_resume.Location = new System.Drawing.Point(228, 414);
            this.btn_resume.Name = "btn_resume";
            this.btn_resume.Size = new System.Drawing.Size(59, 23);
            this.btn_resume.TabIndex = 21;
            this.btn_resume.Text = "Resume";
            this.btn_resume.UseVisualStyleBackColor = false;
            this.btn_resume.Click += new System.EventHandler(this.btn_resume_Click);
            // 
            // btn_pause
            // 
            this.btn_pause.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_pause.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_pause.Enabled = false;
            this.btn_pause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_pause.ForeColor = System.Drawing.Color.White;
            this.btn_pause.Location = new System.Drawing.Point(173, 414);
            this.btn_pause.Name = "btn_pause";
            this.btn_pause.Size = new System.Drawing.Size(49, 23);
            this.btn_pause.TabIndex = 20;
            this.btn_pause.Text = "Pause";
            this.btn_pause.UseVisualStyleBackColor = false;
            this.btn_pause.Click += new System.EventHandler(this.btn_pause_Click);
            // 
            // menu
            // 
            this.menu.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_file,
            this.m_tools,
            this.m_more});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menu.Size = new System.Drawing.Size(300, 24);
            this.menu.TabIndex = 2;
            // 
            // m_file
            // 
            this.m_file.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_newArea,
            this.m_openArea,
            this.m_sep1,
            this.m_saveArea,
            this.m_sep2,
            this.m_exit});
            this.m_file.ForeColor = System.Drawing.Color.White;
            this.m_file.Name = "m_file";
            this.m_file.Size = new System.Drawing.Size(37, 20);
            this.m_file.Text = "File";
            this.m_file.DropDownOpened += new System.EventHandler(this.m_file_DropDownOpened);
            // 
            // m_newArea
            // 
            this.m_newArea.Name = "m_newArea";
            this.m_newArea.Size = new System.Drawing.Size(130, 22);
            this.m_newArea.Text = "New Area";
            this.m_newArea.Click += new System.EventHandler(this.m_newArea_Click);
            // 
            // m_openArea
            // 
            this.m_openArea.Name = "m_openArea";
            this.m_openArea.Size = new System.Drawing.Size(130, 22);
            this.m_openArea.Text = "Open Area";
            // 
            // m_sep1
            // 
            this.m_sep1.Name = "m_sep1";
            this.m_sep1.Size = new System.Drawing.Size(127, 6);
            // 
            // m_saveArea
            // 
            this.m_saveArea.Name = "m_saveArea";
            this.m_saveArea.Size = new System.Drawing.Size(130, 22);
            this.m_saveArea.Text = "Save Area";
            this.m_saveArea.Click += new System.EventHandler(this.m_saveArea_Click);
            // 
            // m_sep2
            // 
            this.m_sep2.Name = "m_sep2";
            this.m_sep2.Size = new System.Drawing.Size(127, 6);
            // 
            // m_exit
            // 
            this.m_exit.Name = "m_exit";
            this.m_exit.Size = new System.Drawing.Size(130, 22);
            this.m_exit.Text = "Exit";
            this.m_exit.Click += new System.EventHandler(this.m_exit_Click);
            // 
            // m_tools
            // 
            this.m_tools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_area_folder,
            this.m_tilesFolder,
            this.m_tilesSummary,
            this.m_browseDownloadedTiles,
            this.m_exportGdalWmsFile,
            this.m_initializeArea,
            this.m_sep3,
            this.m_copyExtent,
            this.m_mapScale});
            this.m_tools.ForeColor = System.Drawing.Color.White;
            this.m_tools.Name = "m_tools";
            this.m_tools.Size = new System.Drawing.Size(48, 20);
            this.m_tools.Text = "Tools";
            // 
            // m_area_folder
            // 
            this.m_area_folder.Name = "m_area_folder";
            this.m_area_folder.Size = new System.Drawing.Size(254, 22);
            this.m_area_folder.Text = "Open Area folder";
            this.m_area_folder.ToolTipText = "Draw manual extent on map";
            this.m_area_folder.Click += new System.EventHandler(this.m_area_folder_Click);
            // 
            // m_tilesFolder
            // 
            this.m_tilesFolder.Name = "m_tilesFolder";
            this.m_tilesFolder.Size = new System.Drawing.Size(254, 22);
            this.m_tilesFolder.Text = "Open Tiles folder";
            this.m_tilesFolder.Click += new System.EventHandler(this.m_tilesFolder_Click);
            // 
            // m_tilesSummary
            // 
            this.m_tilesSummary.Name = "m_tilesSummary";
            this.m_tilesSummary.Size = new System.Drawing.Size(254, 22);
            this.m_tilesSummary.Text = "Tiles summary";
            this.m_tilesSummary.Click += new System.EventHandler(this.m_tilesSummary_Click);
            // 
            // m_browseDownloadedTiles
            // 
            this.m_browseDownloadedTiles.Name = "m_browseDownloadedTiles";
            this.m_browseDownloadedTiles.Size = new System.Drawing.Size(254, 22);
            this.m_browseDownloadedTiles.Text = "Browse downloaded Tiles";
            this.m_browseDownloadedTiles.Click += new System.EventHandler(this.m_browseDownloadedTiles_Click);
            // 
            // m_exportGdalWmsFile
            // 
            this.m_exportGdalWmsFile.Name = "m_exportGdalWmsFile";
            this.m_exportGdalWmsFile.Size = new System.Drawing.Size(254, 22);
            this.m_exportGdalWmsFile.Text = "Export your TMS service definition";
            this.m_exportGdalWmsFile.Click += new System.EventHandler(this.m_exportGdalWmsFile_Click);
            // 
            // m_initializeArea
            // 
            this.m_initializeArea.Name = "m_initializeArea";
            this.m_initializeArea.Size = new System.Drawing.Size(254, 22);
            this.m_initializeArea.Text = "Initialize download";
            this.m_initializeArea.Click += new System.EventHandler(this.m_initializeArea_Click);
            // 
            // m_sep3
            // 
            this.m_sep3.Name = "m_sep3";
            this.m_sep3.Size = new System.Drawing.Size(251, 6);
            // 
            // m_copyExtent
            // 
            this.m_copyExtent.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_getExtentWGS84,
            this.m_getExtentWebMercator});
            this.m_copyExtent.Name = "m_copyExtent";
            this.m_copyExtent.Size = new System.Drawing.Size(254, 22);
            this.m_copyExtent.Text = "Copy Extent to clipboard";
            // 
            // m_getExtentWGS84
            // 
            this.m_getExtentWGS84.Name = "m_getExtentWGS84";
            this.m_getExtentWGS84.Size = new System.Drawing.Size(242, 22);
            this.m_getExtentWGS84.Text = "WGS84 / Lon,Lat (EPSG:4326)";
            this.m_getExtentWGS84.Click += new System.EventHandler(this.m_getExtentWGS84_Click);
            // 
            // m_getExtentWebMercator
            // 
            this.m_getExtentWebMercator.Name = "m_getExtentWebMercator";
            this.m_getExtentWebMercator.Size = new System.Drawing.Size(242, 22);
            this.m_getExtentWebMercator.Text = "Web Mercator / X,Y (EPSG:3857)";
            this.m_getExtentWebMercator.Click += new System.EventHandler(this.m_getExtentWebMercator_Click);
            // 
            // m_mapScale
            // 
            this.m_mapScale.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_degrees,
            this.m_imperialInch,
            this.m_usInch,
            this.m_nauticalMile,
            this.m_metric});
            this.m_mapScale.Name = "m_mapScale";
            this.m_mapScale.Size = new System.Drawing.Size(254, 22);
            this.m_mapScale.Text = "Map scale units";
            // 
            // m_degrees
            // 
            this.m_degrees.CheckOnClick = true;
            this.m_degrees.Name = "m_degrees";
            this.m_degrees.Size = new System.Drawing.Size(144, 22);
            this.m_degrees.Text = "Degrees";
            this.m_degrees.CheckedChanged += new System.EventHandler(this.degrees_m_CheckedChanged);
            // 
            // m_imperialInch
            // 
            this.m_imperialInch.CheckOnClick = true;
            this.m_imperialInch.Name = "m_imperialInch";
            this.m_imperialInch.Size = new System.Drawing.Size(144, 22);
            this.m_imperialInch.Text = "Imperial inch";
            this.m_imperialInch.CheckedChanged += new System.EventHandler(this.imperialInch_m_CheckedChanged);
            // 
            // m_usInch
            // 
            this.m_usInch.CheckOnClick = true;
            this.m_usInch.Name = "m_usInch";
            this.m_usInch.Size = new System.Drawing.Size(144, 22);
            this.m_usInch.Text = "US inch";
            this.m_usInch.CheckedChanged += new System.EventHandler(this.uSInch_m_CheckedChanged);
            // 
            // m_nauticalMile
            // 
            this.m_nauticalMile.CheckOnClick = true;
            this.m_nauticalMile.Name = "m_nauticalMile";
            this.m_nauticalMile.Size = new System.Drawing.Size(144, 22);
            this.m_nauticalMile.Text = "Nautical mile";
            this.m_nauticalMile.CheckedChanged += new System.EventHandler(this.nauticalMile_m_CheckedChanged);
            // 
            // m_metric
            // 
            this.m_metric.Checked = true;
            this.m_metric.CheckOnClick = true;
            this.m_metric.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_metric.Name = "m_metric";
            this.m_metric.Size = new System.Drawing.Size(144, 22);
            this.m_metric.Text = "Metric";
            this.m_metric.CheckedChanged += new System.EventHandler(this.metric_m_CheckedChanged);
            // 
            // m_more
            // 
            this.m_more.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_about,
            this.m_usagePolicy});
            this.m_more.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_more.ForeColor = System.Drawing.Color.Red;
            this.m_more.Name = "m_more";
            this.m_more.Size = new System.Drawing.Size(24, 20);
            this.m_more.Text = "?";
            // 
            // m_about
            // 
            this.m_about.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_about.Name = "m_about";
            this.m_about.Size = new System.Drawing.Size(181, 22);
            this.m_about.Text = "About";
            this.m_about.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // m_usagePolicy
            // 
            this.m_usagePolicy.Name = "m_usagePolicy";
            this.m_usagePolicy.Size = new System.Drawing.Size(181, 22);
            this.m_usagePolicy.Text = "Data usage policy !!";
            this.m_usagePolicy.Click += new System.EventHandler(this.tilesUsagePolicyToolStripMenuItem_Click);
            // 
            // right_panel
            // 
            this.right_panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.right_panel.Controls.Add(this.lbl_alert);
            this.right_panel.Controls.Add(this.browser);
            this.right_panel.ForeColor = System.Drawing.SystemColors.Control;
            this.right_panel.Location = new System.Drawing.Point(300, 0);
            this.right_panel.Name = "right_panel";
            this.right_panel.Size = new System.Drawing.Size(384, 440);
            this.right_panel.TabIndex = 3;
            // 
            // lbl_alert
            // 
            this.lbl_alert.AutoSize = true;
            this.lbl_alert.BackColor = System.Drawing.Color.Transparent;
            this.lbl_alert.ForeColor = System.Drawing.Color.Red;
            this.lbl_alert.Location = new System.Drawing.Point(6, 79);
            this.lbl_alert.Name = "lbl_alert";
            this.lbl_alert.Size = new System.Drawing.Size(19, 13);
            this.lbl_alert.TabIndex = 25;
            this.lbl_alert.Text = "    ";
            this.lbl_alert.Visible = false;
            // 
            // browser
            // 
            this.browser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.browser.FrameEventsPropagateToMainWindow = false;
            this.browser.Location = new System.Drawing.Point(0, 0);
            this.browser.Name = "browser";
            this.browser.NoDefaultContextMenu = true;
            this.browser.Size = new System.Drawing.Size(384, 440);
            this.browser.TabIndex = 0;
            this.browser.UseHttpActivityObserver = false;
            this.browser.DomMouseOver += new System.EventHandler<Gecko.DomMouseEventArgs>(this.browser_DomMouseOver);
            this.browser.DomMouseMove += new System.EventHandler<Gecko.DomMouseEventArgs>(this.browser_DomMouseMove);
            this.browser.DOMContentLoaded += new System.EventHandler<Gecko.DomEventArgs>(this.browser_DOMContentLoaded);
            this.browser.DomClick += new System.EventHandler<Gecko.DomMouseEventArgs>(this.browser_DomClick);
            this.browser.CursorChanged += new System.EventHandler(this.browser_CursorChanged);
            // 
            // bottom
            // 
            this.bottom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bottom.Controls.Add(this.lbl_downloading);
            this.bottom.Controls.Add(this.lockArea);
            this.bottom.Controls.Add(this.lbl_levelZoom);
            this.bottom.Controls.Add(this.lbl_xy);
            this.bottom.Location = new System.Drawing.Point(0, 441);
            this.bottom.Name = "bottom";
            this.bottom.Size = new System.Drawing.Size(684, 21);
            this.bottom.TabIndex = 4;
            // 
            // lbl_downloading
            // 
            this.lbl_downloading.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_downloading.AutoSize = true;
            this.lbl_downloading.Location = new System.Drawing.Point(104, 4);
            this.lbl_downloading.Name = "lbl_downloading";
            this.lbl_downloading.Size = new System.Drawing.Size(125, 13);
            this.lbl_downloading.TabIndex = 24;
            this.lbl_downloading.Text = "Downloading: not started";
            // 
            // lockArea
            // 
            this.lockArea.AutoSize = true;
            this.lockArea.Location = new System.Drawing.Point(3, 3);
            this.lockArea.Name = "lockArea";
            this.lockArea.Size = new System.Drawing.Size(74, 17);
            this.lockArea.TabIndex = 22;
            this.lockArea.Text = "Lock area";
            this.lockArea.UseVisualStyleBackColor = true;
            this.lockArea.CheckedChanged += new System.EventHandler(this.lockArea_CheckedChanged);
            // 
            // lbl_levelZoom
            // 
            this.lbl_levelZoom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_levelZoom.AutoSize = true;
            this.lbl_levelZoom.Location = new System.Drawing.Point(472, 4);
            this.lbl_levelZoom.Name = "lbl_levelZoom";
            this.lbl_levelZoom.Size = new System.Drawing.Size(62, 13);
            this.lbl_levelZoom.TabIndex = 23;
            this.lbl_levelZoom.Text = "Zoom level:";
            // 
            // lbl_xy
            // 
            this.lbl_xy.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_xy.AutoSize = true;
            this.lbl_xy.Location = new System.Drawing.Point(568, 4);
            this.lbl_xy.Name = "lbl_xy";
            this.lbl_xy.Size = new System.Drawing.Size(55, 13);
            this.lbl_xy.TabIndex = 22;
            this.lbl_xy.Text = "0.00, 0.00";
            // 
            // left_panel
            // 
            this.left_panel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.left_panel.Controls.Add(this.setting_panel);
            this.left_panel.Controls.Add(this.btn_download);
            this.left_panel.Controls.Add(this.btn_resume);
            this.left_panel.Controls.Add(this.btn_pause);
            this.left_panel.Controls.Add(this.menu);
            this.left_panel.Location = new System.Drawing.Point(0, 0);
            this.left_panel.Name = "left_panel";
            this.left_panel.Size = new System.Drawing.Size(300, 440);
            this.left_panel.TabIndex = 22;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(684, 462);
            this.Controls.Add(this.left_panel);
            this.Controls.Add(this.bottom);
            this.Controls.Add(this.right_panel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menu;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.setting_panel.ResumeLayout(false);
            this.setting_panel.PerformLayout();
            this.gb_source.ResumeLayout(false);
            this.gb_source.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxZoom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minZoom)).EndInit();
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.right_panel.ResumeLayout(false);
            this.right_panel.PerformLayout();
            this.bottom.ResumeLayout(false);
            this.bottom.PerformLayout();
            this.left_panel.ResumeLayout(false);
            this.left_panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel setting_panel;
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem m_file;
        private System.Windows.Forms.TextBox tb_areaName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_tileCount;
        private System.Windows.Forms.Label lbl_zoomCount;
        private System.Windows.Forms.NumericUpDown maxZoom;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown minZoom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox xMax;
        private System.Windows.Forms.TextBox yMin;
        private System.Windows.Forms.TextBox xMin;
        private System.Windows.Forms.TextBox yMax;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel right_panel;
        private Gecko.GeckoWebBrowser browser;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox getFromMap;
        private System.Windows.Forms.GroupBox gb_source;
        private System.Windows.Forms.Button drawOnMap;
        private System.Windows.Forms.Button btn_resume;
        private System.Windows.Forms.Button btn_pause;
        private System.Windows.Forms.Button btn_download;
        private System.Windows.Forms.ToolStripMenuItem m_newArea;
        private System.Windows.Forms.ToolStripMenuItem m_openArea;
        private System.Windows.Forms.ToolStripSeparator m_sep1;
        private System.Windows.Forms.ToolStripMenuItem m_saveArea;
        private System.Windows.Forms.ToolStripSeparator m_sep2;
        private System.Windows.Forms.ToolStripMenuItem m_exit;
        private System.Windows.Forms.Button btn_previewDS;
        private System.Windows.Forms.ComboBox cbx_datasource;
        private System.Windows.Forms.Label lbl_urlQuery;
        private System.Windows.Forms.Label lbl_urlImageType;
        private System.Windows.Forms.Label lbl_url;
        private System.Windows.Forms.ToolStripMenuItem m_tools;
        private System.Windows.Forms.ToolStripMenuItem m_area_folder;
        private System.Windows.Forms.Panel bottom;
        private System.Windows.Forms.Label lbl_xy;
        private System.Windows.Forms.Label lbl_levelZoom;
        private System.Windows.Forms.Label lbl_downloading;
        private System.Windows.Forms.CheckBox lockArea;
        private System.Windows.Forms.Panel left_panel;
        private System.Windows.Forms.ToolStripMenuItem m_tilesFolder;
        private System.Windows.Forms.ToolStripMenuItem m_initializeArea;
        private System.Windows.Forms.ToolStripMenuItem m_browseDownloadedTiles;
        private System.Windows.Forms.ToolStripSeparator m_sep3;
        private System.Windows.Forms.ToolStripMenuItem m_mapScale;
        private System.Windows.Forms.ToolStripMenuItem m_degrees;
        private System.Windows.Forms.ToolStripMenuItem m_imperialInch;
        private System.Windows.Forms.ToolStripMenuItem m_usInch;
        private System.Windows.Forms.ToolStripMenuItem m_nauticalMile;
        private System.Windows.Forms.ToolStripMenuItem m_metric;
        private System.Windows.Forms.ToolStripMenuItem m_tilesSummary;
        private System.Windows.Forms.Label lbl_alert;
        private System.Windows.Forms.ToolStripMenuItem m_copyExtent;
        private System.Windows.Forms.ToolStripMenuItem m_getExtentWGS84;
        private System.Windows.Forms.ToolStripMenuItem m_getExtentWebMercator;
        private System.Windows.Forms.ToolStripMenuItem m_more;
        private System.Windows.Forms.ToolStripMenuItem m_about;
        private System.Windows.Forms.ToolStripMenuItem m_usagePolicy;
        private System.Windows.Forms.ToolStripMenuItem m_exportGdalWmsFile;
    }
}

