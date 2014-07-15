using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace rssYnet.Util
{


    public class MessageAlert:MessageItem
    {
        public string Id { get; set; }
       public string VerticalMessage { get; set; }

       public string[] Data { get; set; }
        //public DateTime DateItem { get; set; }
        //public bool IsSearch { get; set; }
        //public int Index { get; set; }

        public override string ToString()
        {
            return String.Format("{0}>{1}= {2},{3} [{4}]", Index, Id, Title, DateItem, IsSearch);
        }
    }
}
