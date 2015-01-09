using System;
using System.Linq;
using System.Text.RegularExpressions;
using CsQuery;

namespace EZTV {
    public class EZTVShow {
        private static readonly Regex ShowUrlRegex = new Regex("/shows/(.+)/(.*)/");

        public string Url { get; set; }
        public int Id { get; set; }
        public string Slug { get; set; }
        public string Title { get; set; }
        public string Status { get; set; }

        

        public static EZTVShow ParseShow(string element) {
            CQ row = element;
            var showUrl = row.Find("td").First().Find("a").Attr("href");

            if (String.IsNullOrEmpty(showUrl)) {
                return null;
            }
            
            var m = ShowUrlRegex.Match(showUrl);
            if (!m.Success) {
                return null;
            }
            var id = Convert.ToInt32(m.Groups[1].Value);
            var slug = m.Groups[2].Value;

            var title = row.Find("td").Skip(1).First().Cq().Text();
            if (title.EndsWith(", The")) {
                title = "The " + title.Substring(0, title.Length - 5);
            }

            var status = row.Find("td").Skip(2).First().Cq().Find("font").Attr("class");

            var show = new EZTVShow {
                Url = showUrl,
                Id = id,
                Slug = slug,
                Title = title,
                Status = status
            };
            return show;
        }
    }
}