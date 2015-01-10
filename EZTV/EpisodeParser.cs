using System;
using System.Text.RegularExpressions;

namespace EZTV {
    public static class EpisodeParser {
        private static readonly Regex EpisodeUrlRegex = new Regex(@"/ep/(\d+)/.*/");
        private static readonly Regex TitleRegex1 = new Regex(@"(.+) (s)(\d+)(e|x)?(\d+)?(.*)", RegexOptions.IgnoreCase);
        private static readonly Regex TitleRegex2 = new Regex(@"(.+) (Part) (\d+)(e|x)?(\d+)?(.*)", RegexOptions.IgnoreCase);
        private static readonly Regex TitleRegex3 = new Regex(@"(.+) (Part) ([a-zA-Z]+)(e|x)?(\d+)?(.*)", RegexOptions.IgnoreCase);
        private static readonly Regex TitleRegex4 = new Regex(@"(.+) ()?(\d+)(e|x)?(\d+)?(.*)", RegexOptions.IgnoreCase);

        // ReSharper disable UnusedMember.Local
        private enum Numbers {
            One = 1,
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5,
            Six = 6,
            Seven = 7,
            Eight = 8,
            Nine = 9
        }
        // ReSharper restore UnusedMember.Local

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
            if (ep == null) {
                throw new ArgumentNullException("ep");
            }
            // ugly regex soup
            var m = TitleRegex1.Match(ep.Title);
            if (!m.Success) {
                m = TitleRegex2.Match(ep.Title);
                if (!m.Success) {
                    m = TitleRegex3.Match(ep.Title);
                    if (!m.Success) {
                        m = TitleRegex4.Match(ep.Title);
                        if (!m.Success) {
                            throw new InvalidOperationException("Could not parse EZTVEpisode.Title");
                        }
                    }
                }
            }

            ep.Show = m.Groups[1].Value;
            if (m.Groups[2].Value.Equals("s", StringComparison.InvariantCultureIgnoreCase)) {
                ep.Season = Convert.ToInt32(m.Groups[3].Value);
            } else if (m.Groups[4].Value.Equals("x", StringComparison.InvariantCultureIgnoreCase)) {
                ep.Season = Convert.ToInt32(m.Groups[3].Value);
            }
            else {
                ep.Season = 1;
            }
            if (m.Groups[2].Value.Equals("part", StringComparison.InvariantCultureIgnoreCase)) {
                try {
                    ep.EpisodeNum = Convert.ToInt32(m.Groups[3].Value);
                }
                catch (FormatException) {
                    Numbers n;
                    if (Enum.TryParse(m.Groups[3].Value, out n)) {
                        ep.EpisodeNum = (int) n;
                    }
                }
            }
            else {
                ep.EpisodeNum = Convert.ToInt32(m.Groups[5].Value);
            }
        }
    }
}