using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rssYnet
{
    public partial class OrefConfig : Form
    {
        public OrefConfig(int interval, string rss, bool isBeep)
        {
            InitializeComponent();
            numDuration.Value = interval;
            txtRss.Text = rss; chkBeep.Checked = isBeep;
        }
        public bool iSbeep
        {


            get
            {

                return chkBeep.Checked;
            }


        }
        public int Interval {


            get
            {
                return Convert.ToInt32(numDuration.Value);
            }
        
        
        }

        public string RssFeed
        {
            get
            {

                return txtRss.Text.Trim();
            }

        }

        private void Config_Load(object sender, EventArgs e)
        {

        }


        private void btnOk_Click(object sender, EventArgs e)
        {

        }

        
    }
}
