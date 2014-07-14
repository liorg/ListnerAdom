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
    public class Location
    {
        [DataMember]
        public string Key { get; set; }

        [DataMember]
        public string[] Yeshovim { get; set; }

    }



}
