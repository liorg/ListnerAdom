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
        static object o = new object();
        private void rss_Listner(MessageItem obj)
        {
            lock (o)
            {
                listBox1.Items.Insert(0, obj);

                //if (obj.IsSearch) listBox1.SetItemColor(listBox1.Items.Count , Color.Red);
            }
            //listBox1.Items.Add(obj.ToString());
        }
        RssSearchKeys rss;
        string[] _searchKey=null;
        private void btnExcute_Click(object sender, EventArgs e)
        {
           // var search = Util.Utils.keySearchSplitter(txtSearch.Text.Trim());
            int interval = int.Parse(txtTS.Text.Trim()) * 1000;
            if (btnExcute.Text == "עצור")
            {
                txtSearch.Enabled = false;
                rss.Stop();

                btnExcute.Text = "הפעל";
             

            }
            else
            {
                if (_searchKey==null || !_searchKey.Any())
                {
                    MessageBox.Show("יש לבחור חיפוש");
                    return;
                }
                txtSearch.Enabled = true;
               
                rss.Play(interval, _searchKey);
                listBox1.Items.Clear();
                btnExcute.Text = "עצור";
            }

            //btnExcute.Text = timer1.Enabled ? "עצור" : "הפעל";
            
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSearch search = new frmSearch();
             DialogResult res= search.ShowDialog();
             if (res==System.Windows.Forms.DialogResult.OK)
             {
                 _searchKey = search.Items.ToArray();
             }

        }
    }
}
