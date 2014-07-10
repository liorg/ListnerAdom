//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Timers;

//namespace rssYnet
//{
//    public class MessageItem
//    {
//        public string Title { get; set; }
//        public DateTime DateItem { get; set; }
//        public bool IsSearch { get; set; }
//        public int Index { get; set; }

//    }


//    public class RssYnet
//    {
//        string[] search;
//        List<int> eventsRead = new List<int>();
//        public event Action<MessageItem> Listner;
//        RssReader reader = new RssReader("http://www.ynet.co.il/Integration/StoryRss1854.xml");
//        System.Windows.Forms.Timer timer;
//        int rowid;
//        public RssYnet()
//        {
//            eventsRead = new List<int>();
//            reader = new RssReader("http://www.ynet.co.il/Integration/StoryRss1854.xml");
//            timer = new System.Windows.Forms.Timer();
//           rowid=0;

//        }
//        public void Play(int Interval)
//        {
//            GetData();
//            foreach (var item in reader.Items)
//            {
//              //  Listner(new MessageItem {Index=rowid,DateItem=item.Date
//            }
//            timer.Tick += OnTimerTick;
//            timer.Interval = 10000;
//            timer.Start();

//        }

//        private void OnTimerTick(object sender, EventArgs e)
//        {
//            GetData();
//        }
//        public void Pause()
//        {
//        }
//        public void Stop()
//        {
//            eventsRead.Clear();
//        }
//        public void Resume()
//        {
//        }

//        void GetData()
//        {

//            reader.Execute();
//            int i = 0;
//            // RssReader reader =RssReader.CreateAndCache("http://www.ynet.co.il/Integration/StoryRss1854.xml",TimeSpan.FromSeconds(10));
//            foreach (var item in reader.Items)
//            {

//                bool isFound = false;
//                int hashLink = item.Link.GetHashCode();
//                if (eventsRead.Contains(hashLink))
//                    continue;
//                Console.WriteLine(item.Title);
//                foreach (var searchItem in search)
//                {

//                    if (item.Title.Trim().Contains(searchItem.Trim()))
//                    {
//                        Console.WriteLine(item.Title);
//                        isFound = true;
//                      ..  item.IsSearch = true;

//                    }


//                }
//                rowid++;
//                if (!eventsRead.Contains(hashLink))
//                    eventsRead.Add(item.Link.GetHashCode());
//              //  var d = item.Title + "(" + item.Date.ToString() + ") " + isFound.ToString();
//                //  listBox1.Items.Add(d);
//                //listBox1.Items.Insert(0, d);
//                //if (isFound) listBox1.SetItemColor(i, Color.Red);
//                i++;

//                //// insert all the items into the listview at the last available row
//                //lstDataSearchResult.Items.Add(lstDataSearchResult.Count, item.Title, 0, myItems);
//                //System.Media.SoundPlayer player = new System.Media.SoundPlayer();
//                //player.SoundLocation = "http://www.wavsource.com/snds_2014-07-06_8028356563048763/tv/a-team/a-team_crazy_fool_x.wav";
//                //player.Play();

//            }
//        }

//    }

//}
