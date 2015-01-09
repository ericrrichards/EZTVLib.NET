using System.Collections.Generic;
using System.Linq;
using System.Net;
using CsQuery;

namespace EZTV {
    public static class EZTV {
        public static List<EZTVShow> GetShows(string query = "") {
            var wc = new WebClient();
            const string url = "http://eztv.it/showlist/";

            var page = wc.DownloadString(url);

            CQ dom = page;
            var elements = dom["table.forum_header_border tr[name=hover]"].Select(e=>e.OuterHTML);
            var showList = elements.Select(EZTVShow.ParseShow).Where(show => show != null).ToList();

            if (string.IsNullOrEmpty(query)) {
                return showList;
            }
            return showList.Where(s => s.Title.ToLowerInvariant().Contains(query.ToLowerInvariant())).ToList();
        }

        public static EZTVEpisodeList GetEpisodes(int showId) {
            var url = string.Format("http://eztv.it/shows/{0}/", showId);
            var wc = new WebClient();
            string page;
            try {
                page = wc.DownloadString(url);
            } catch {
                return null;
            }

            CQ dom = page;
            string title = dom["td.section_post_header"].First().Find("b").Text();
            var eps = dom["table.forum_header_noborder tr[name=hover]"].Select(e => e.OuterHTML);

            var episodes = new EZTVEpisodeList {
                ID = showId,
                Title = title,
                Episodes = eps.Select(EZTVEpisode.ParseEpisode).Where(ep => ep != null).ToList()
            };
            return episodes;
        }
    }
}