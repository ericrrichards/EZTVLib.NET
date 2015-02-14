using System.Collections.Generic;
using System.Linq;
using CsQuery;

namespace EZTV {
    public class EZTVEpisodeList {
        public int ShowID { get; set; }
        public string ShowTitle { get; set; }
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
        public bool InLibrary { get; set; }
        public int LibId { get; set; }


        public static EZTVEpisode ParseEpisode(string episode) {
            if (episode == null) {
                return null;
            }
            CQ o = episode;

            var tds = o.Find("td");
            if (tds.Length == 0) {
                return null;
            }
            var secondTd = tds.Skip(1).FirstOrDefault();
            if (secondTd == null) {
                return null;
            }
            var episodeUrl = secondTd.Cq().Find("a").Attr("href");
            
            int id;
            if (!EpisodeParser.TryParseEpisodeId(episodeUrl, out id)) {
                return null;
            }
            var thirdTd = tds.Skip(2).FirstOrDefault();
            if (thirdTd == null) {
                return null;
            }
            var magnetLink = thirdTd.Cq().Find("a.magnet");
            if (magnetLink.Length == 0) {
                return null;
            }
            var ep = new EZTVEpisode {
                Url = episodeUrl,
                ID = id,
                Title = secondTd.Cq().Find("a").Text(),
                Magnet = magnetLink.Attr("href")
            };
            EpisodeParser.ParseTitle(ep);

            return ep;
        }
    }
}