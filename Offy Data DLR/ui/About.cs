using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Offy.ui
{
    public partial class About : Form
    {
        public About(string _productName)
        {
            InitializeComponent();

            lbl_productName.Text = _productName;
            lbl_version.Text = Application.ProductVersion;
            lbl_copyR.Text = "© 2017 OffyGIS";
            lbl_doneBy.Text = "Designed and developed by Offy (Youssef YASSINI)";
            lbl_link.Text = "https://github.com/OffyGIS/Offy-Data-DLR";

            lbl_link.LinkClicked += new LinkLabelLinkClickedEventHandler(linkCliked);
        }

        private void linkCliked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(lbl_link.Text);
        }
    }
}
