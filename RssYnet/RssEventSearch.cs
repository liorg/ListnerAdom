using rssYnet.Util;
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
    public partial class RssEventSearch : Form
    {
        public RssEventSearch()
        {
            InitializeComponent();
            rss = new RssSearchKeys(); 
            rss.Listner +=rss_Listner;
        }

        private void rss_Listner(MessageItem obj)
        {
            listBox1.Items.Add(obj.ToString());
        }
        RssSearchKeys rss;
        private void btnExcute_Click(object sender, EventArgs e)
        {
            var search = Util.Utils.keySearchSplitter(txtSearch.Text.Trim());
            int interval = int.Parse(txtTS.Text.Trim()) * 1000;
            if (btnExcute.Text == "עצור")
            {
                txtSearch.Enabled = false;
                rss.Stop();

                btnExcute.Text = "הפעל";
             

            }
            else
            {
                txtSearch.Enabled = true;
                rss.Play(interval, search);
                listBox1.Items.Clear();
                btnExcute.Text = "עצור";
            }

            //btnExcute.Text = timer1.Enabled ? "עצור" : "הפעל";
            
        }
    }
}
