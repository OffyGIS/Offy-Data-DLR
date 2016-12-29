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
    public partial class UsagePolicy : Form
    {
        public UsagePolicy()
        {
            InitializeComponent();

            lbl_content.Text  = "• The provided services definitions are not <<HARD CODED>>. Take a look\n   at the application Config file.";
            lbl_content.Text += Environment.NewLine;
            lbl_content.Text += Environment.NewLine;
            lbl_content.Text += "• Data services definitions are provided << AS IS >> and are not validated\n   by the application authors.";
            lbl_content.Text += Environment.NewLine;
            lbl_content.Text += Environment.NewLine;
            lbl_content.Text += "• The Provided Data services are a << PROOF-OF-CONCEPT >> and for testing.";
            lbl_content.Text += Environment.NewLine;
            lbl_content.Text += Environment.NewLine;
            lbl_content.Text += "• Please take a look at the Usage Policy of any Service you use, contact the Server\n   Owner/Admin if needed or/and be sure you're eligible to download the data.";
            lbl_content.Text += Environment.NewLine;
            lbl_content.Text += Environment.NewLine;
            lbl_content.Text += "• Offy Data DLR does not guarantee the availability or the precision of provided\n   Data Services. Contact the service provider if there is something wrong.";
            lbl_content.Text += Environment.NewLine;
            lbl_content.Text += Environment.NewLine;
            lbl_content.Text += "• Do not select a large areas and unusefull detailed zoom levels (17,18) to download.\n   You may slow down the data service and your machine. In addition, the server may\n   block your requests at any time.";
            lbl_content.Text += Environment.NewLine;

        }
    }
}
