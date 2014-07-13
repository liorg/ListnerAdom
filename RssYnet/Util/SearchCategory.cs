using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rssYnet.Util
{
    
    [Serializable]
    public class SearchCategory
    {
        public List<string> SearchKeywords { get; set; }
        public string Category { get; set; }
    }


}
