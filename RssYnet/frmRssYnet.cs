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
    public partial class frmRssYnet : Form
    {
        public frmRssYnet()
        {        
            InitializeComponent();
        }

        string[] search;
        List<int> eventsRead = new List<int>();
        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Interval = int.Parse(txtTS.Text.Trim())* 1000;
            if (btnExcute.Text == "עצור")
            {
                txtSearch.Enabled = false; 
                timer1.Enabled = false;
                btnExcute.Text = "הפעל"; 
                Run();
                
            }
            else
            {
                txtSearch.Enabled = true;
                timer1.Enabled = true;
                listBox1.Items.Clear();
                btnExcute.Text =  "עצור";
            }

            //btnExcute.Text = timer1.Enabled ? "עצור" : "הפעל";
            search = Util.Utils.keySearchSplitter(txtSearch.Text.Trim());

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            Run();
        }

        void Run()
        {
            RssReader reader = new RssReader("http://www.ynet.co.il/Integration/StoryRss1854.xml");
            reader.Execute();
            int i = 0;
            // RssReader reader =RssReader.CreateAndCache("http://www.ynet.co.il/Integration/StoryRss1854.xml",TimeSpan.FromSeconds(10));
            foreach (var item in reader.Items)
            {

                bool isFound = false;
                int hashLink = item.Link.GetHashCode();
                if (eventsRead.Contains(hashLink))
                    continue;
                Console.WriteLine(item.Title);
                foreach (var searchItem in search)
                {

                    if (item.Title.Trim().Contains(searchItem.Trim()))
                    {
                        Console.WriteLine(item.Title);
                        isFound = true;

                    }


                }
                if (!eventsRead.Contains(hashLink))
                    eventsRead.Add(item.Link.GetHashCode());
                var d = item.Title + "(" + item.Date.ToString() + ") " + isFound.ToString();
              //  listBox1.Items.Add(d);
                listBox1.Items.Insert(0, d);
                if (isFound) listBox1.SetItemColor(i, Color.Red);
                i++;

                //// insert all the items into the listview at the last available row
                //lstDataSearchResult.Items.Add(lstDataSearchResult.Count, item.Title, 0, myItems);
                //System.Media.SoundPlayer player = new System.Media.SoundPlayer();
                //player.SoundLocation = "http://www.wavsource.com/snds_2014-07-06_8028356563048763/tv/a-team/a-team_crazy_fool_x.wav";
                //player.Play();

            }
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
           
        }
    }
}
