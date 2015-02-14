using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using CsQuery;

namespace EZTV {
    public static class EZTV {
        private const string ShowListPath = "showlist/";
        public static string baseUrl1 = "http://eztv.it/";
        public static string baseUrl2 = "https://eztv-proxy.net/";

        public static List<EZTVShow> GetShows(string query = "") {
            var wc = new WebClient();
            string url = Path.Combine(baseUrl1, ShowListPath);
            string page;
            try {
                page = wc.DownloadString(url);
            } catch (Exception) {
                url = Path.Combine(baseUrl2, ShowListPath);
                page = wc.DownloadString(url);
            }
            CQ dom = page;
            var elements = dom["table.forum_header_border tr[name=hover]"].Select(e => e.OuterHTML);
            var showList = elements.Select(EZTVShow.ParseShow).Where(show => show != null).ToList();

            if (string.IsNullOrEmpty(query)) {
                return showList;
            }
            return showList.Where(s => s.Title.ToLowerInvariant().Contains(query.ToLowerInvariant())).ToList();
        }

        public static EZTVEpisodeList GetEpisodes(int showId) {
            var url = string.Format("{1}shows/{0}/", showId, baseUrl1);
            var wc = new WebClient();
            string page;
            try {
                page = wc.DownloadString(url);
            } catch {
                url = string.Format("{1}shows/{0}/", showId, baseUrl2);
                page = wc.DownloadString(url);
            }

            CQ dom = page;
            string title = dom["td.section_post_header"].First().Find("b").Text();
            var eps = dom["table.forum_header_noborder tr[name=hover]"].Select(e => e.OuterHTML);

            var episodes = new EZTVEpisodeList {
                ShowID = showId,
                ShowTitle = title,
                Episodes = eps.Select(EZTVEpisode.ParseEpisode).Where(ep => ep != null).ToList()
            };
            return episodes;
        }
    }
}