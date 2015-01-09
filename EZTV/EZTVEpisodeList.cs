using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using CsQuery;

namespace EZTV {
    public class EZTVEpisodeList {
        public int ID { get; set; }
        public string Title { get; set; }
        public List<EZTVEpisode> Episodes { get; set; }
    }
    
    public class EZTVEpisode {
        public int ID { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public string Show { get; set; }
        public int Season { get; set; }
        public int EpisodeNum { get; set; }
        public string Magnet { get; set; }


        public static EZTVEpisode ParseEpisode(string episode) {
            CQ o = episode;
            
            var episodeUrl = o.Find("td").Skip(1).First().Cq().Find("a").Attr("href");
            
            int id;
            if (!EpisodeParser.TryParseEpisodeId(episodeUrl, out id)) {
                return null;
            }
            var ep = new EZTVEpisode {
                Url = episodeUrl,
                ID = id,
                Title = o.Find("td").Skip(1).First().Cq().Find("a").Text(),
                Magnet = o.Find("td").Skip(2).First().Cq().Find("a.magnet").Attr("href")
            };
            EpisodeParser.ParseTitle(ep);

            return ep;
        }
    }

    public static class EpisodeParser {
        private static readonly Regex EpisodeUrlRegex = new Regex(@"/ep/(\d+)/.*/");
        private static readonly Regex TitleRegex = new Regex(@"(.+) (Part|s)(\d+)(e|x)?(\d+)?(.*)", RegexOptions.IgnoreCase);

        public static bool TryParseEpisodeId(string episodeUrl, out int id) {
            id = -1;
            if (episodeUrl == null) {
                return false;
            }
            var m = EpisodeUrlRegex.Match(episodeUrl);
            if (!m.Success) {
                return false;
            }
            id = Convert.ToInt32(m.Groups[1].Value);
            return true;
        }

        public static void ParseTitle(EZTVEpisode ep) {
            var m = TitleRegex.Match(ep.Title);
            if (!m.Success) return;

            ep.Show = m.Groups[1].Value;
            ep.Season = m.Groups[2].Value.Equals("s", StringComparison.InvariantCultureIgnoreCase)
                ? Convert.ToInt32(m.Groups[3].Value)
                : 1;
            ep.EpisodeNum = m.Groups[2].Value.Equals("part", StringComparison.InvariantCultureIgnoreCase)
                ? Convert.ToInt32(m.Groups[3].Value)
                : Convert.ToInt32(m.Groups[5].Value);
        }
    }
    
}