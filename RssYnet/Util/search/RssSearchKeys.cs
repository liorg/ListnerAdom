using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace rssYnet.Util
{
    public class RssSearchKeys
    {
        string[] _search;
        List<int> _eventsRead = new List<int>();
        public event Action<MessageItem> Listner = null;
        RssAsync _reader;
        System.Windows.Forms.Timer _timer;
        int _rowid;
        string _rss;

        public string Rss
        {

            get
            {
                return _rss;
            }


            set
            {
                _rss = value;

            }

        }
        
        public RssSearchKeys(string rss)
        {
            _rss = rss;
            _eventsRead = new List<int>();
            _reader = new RssAsync(_rss);
            _timer = new System.Windows.Forms.Timer();
            _rowid = 0; _timer.Tick += OnTimerTick;

        }
     
        public void Play(int interval, string[] search)
        {
            _rowid = 0; 
            _search = search;
            _eventsRead.Clear();
            _timer.Enabled = true;
           
            _timer.Interval = interval * 1000;
            _timer.Start();

        }

        private void OnTimerTick(object sender, EventArgs e)
        {
            GetData();
        }

        public void Pause()
        {
            _timer.Enabled = false;
        }

        public void Stop()
        {
            _rowid = 0; _timer.Enabled = false;
            _eventsRead.Clear();
        }

        public void Resume()
        {
            _timer.Enabled = true;
        }

        void GetData()
        {

            _reader.Excute();
            var data = _reader.Items.OrderBy(d => d.Date).ToList();
            foreach (var item in data)
            {

                bool isFound = false;
                int hashLink = item.Link.GetHashCode();
                if (_eventsRead.Contains(hashLink))
                    continue;
                Console.WriteLine(item.Title);
                foreach (var searchItem in _search)
                {
                  if (Utils.SearchContent(item.Title.Trim(),searchItem))
                 //   if (item.Title.Trim().Contains(searchItem.Trim()))
                    {
                      //  Console.WriteLine(item.Title);
                        isFound = true;
                    }

                }
                _rowid++;
                if (!_eventsRead.Contains(hashLink))
                    _eventsRead.Add(item.Link.GetHashCode());
                //  var d = item.Title + "(" + item.Date.ToString() + ") " + isFound.ToString();
                //  listBox1.Items.Add(d);
                //listBox1.Items.Insert(0, d);
                //if (isFound) listBox1.SetItemColor(i, Color.Red);

                if (Listner != null)
                {
                    MessageItem message = new MessageItem { Index = _rowid, IsSearch = isFound, Title = item.Title, DateItem = item.Date };
                    Listner(message);
                }


            }
        }


    }
}
