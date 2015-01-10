using System.Collections.Generic;
using System.Linq;
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
}