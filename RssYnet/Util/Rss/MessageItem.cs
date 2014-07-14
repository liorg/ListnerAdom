using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace rssYnet.Util
{
    public class MessageItem
    {
        public string Title { get; set; }
        public DateTime DateItem { get; set; }
        public bool IsSearch { get; set; }
        public int Index { get; set; }

        public override string ToString()
        {
            return String.Format("{0}> {1},{2} [{3}]", Index, Title, DateItem, IsSearch);
        }
    }
}