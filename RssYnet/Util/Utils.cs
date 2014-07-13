using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace rssYnet.Util
{
    public static class Utils
    {
        public static bool SearchContent(string rssItem, string keyword)
        {

            int indexOfOr = 0; int metrixIndex = 0; int indexOfSave = -1;
           // var searchKey = new string[] { "  אזעקה | אזעקת + תל אביב| פתח תקווה| בני ברק |רמת גן | תל-אביב | תל - אביב  " };
            bool[] metrixSectionFound = null;
            //foreach (var key in searchKey)
            //{
                metrixIndex = 0;
                var section = keyword.Split(new[] { "+" }, StringSplitOptions.None).ToList();
                metrixSectionFound = new bool[section.Count()];
                foreach (var itemSection in section)
                {
                    var wordOr = itemSection.Split(new[] { "|" }, StringSplitOptions.None).ToList();
                    foreach (var wordOrItem in wordOr)
                    {
                        indexOfOr = rssItem.IndexOf(wordOrItem.Trim());
                        if (indexOfOr >= 0 && indexOfSave < indexOfOr)
                        {
                            metrixSectionFound[metrixIndex] = true;
                            indexOfSave = indexOfOr;
                            break;
                        }
                    }
                    metrixIndex++;
              //  }
            }

            if (metrixSectionFound == null || !metrixSectionFound.Any() || metrixSectionFound.Where(b => b == false).Any())
            {
                //Console.WriteLine("no found");
                return false;
            }
            else
            {
              //  Console.WriteLine(" found");
                return true;
            }

        }
        public static string[] keySearchSplitter(string s)
        {
            // List<string> keySearch = new List<string>();
            //var pattern = @"\|\| | \&\& ";
            //var pattern = @"\+";  
            //    var s = "lior && dd || ttt llll || 222 x && ss || ss";
            // var data = s.Split(new[] { "&&", "||" }, StringSplitOptions.None).ToList();
            //var data = s.Split(new[] { "+"}, StringSplitOptions.None).ToList();
            return s.Split(new[] { "+" }, StringSplitOptions.None);


            //Regex rgx = new Regex(pattern, RegexOptions.IgnoreCase);

            //MatchCollection matches = rgx.Matches(s);
            //var ch = data.GetEnumerator();
            //var opeartor = matches.GetEnumerator();
            //while (ch.MoveNext())
            //{
            //    if (!String.IsNullOrWhiteSpace(ch.Current))
            //    {
            //        keySearch.Add(ch.Current);
            //        bool isMoveNextOpeartor = opeartor.MoveNext();
            //        if (isMoveNextOpeartor)
            //            keySearch.Add(opeartor.Current.ToString());
            //    }
            //    else
            //        opeartor.MoveNext();
            //}
            //return keySearch.ToArray();
        }
    }
}
