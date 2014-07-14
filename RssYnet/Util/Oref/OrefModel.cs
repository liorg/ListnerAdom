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
    [DataContract]
    public class OrefModel
    {
        [DataMember]
        public string id { get; set; }
        [DataMember]
        public string title { get; set; }

        [DataMember]
        public string[] data { get; set; }

        public string Fields
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                if (data != null)
                {
                    foreach (var item in data)
                    {
                        sb.Append(item+",");
                    }
                }
                return sb.ToString();
            }
        }
     
        public string VerticalFields
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                if (data != null)
                {
                    foreach (var item in data)
                    {
                       sb.AppendLine(item);
                    }
                }
                return sb.ToString();
            }
        }

    }
    
}
