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
    public partial class Config : Form
    {
        public Config(int interval ,string rss,bool isBeep)
        {
            InitializeComponent();
            ddInterval.Text = interval.ToString();
            txtRss.Text = rss;
            comboBox1.SelectedValue = rss;
            comboBox1.Text = rss;
            chkBeep.Checked = isBeep;
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
                int intrv=0;
                int.TryParse(ddInterval.Text.Trim(), out intrv);

                return intrv;
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if( comboBox1.SelectedItem!=null)
                txtRss.Text = comboBox1.SelectedItem.ToString().Trim();        
        }
    }
}
