using System;
using EZTV;
using EZTVTests.Annotations;
using NUnit.Framework;

namespace EZTVTests {
    [TestFixture]
    public class EpisodeParserTests {
        [Test, UsedImplicitly]
        public void TryParseEpisodeId_NullReturnsFalse_Test() {
            int id;
            var ret = EpisodeParser.TryParseEpisodeId(null, out id);

            Assert.IsFalse(ret);
        }
        [Test, UsedImplicitly]
        public void TryParseEpisodeId_EmptyReturnsFalse_Test() {
            const string input = "";
            int id;
            var ret = EpisodeParser.TryParseEpisodeId(input, out id);

            Assert.IsFalse(ret);
        }

        
        [Test, UsedImplicitly]
        public void TryParseEpisodeId_ValidUrlReturnsTrue_Test() {
            const string input = "https://eztv.it/ep/59833/the-big-bang-theory-s08e07-hdtv-x264-lol/";
            int id;
            var ret = EpisodeParser.TryParseEpisodeId(input, out id);

            Assert.IsTrue(ret);
        }
        [Test, UsedImplicitly]
        public void TryParseEpisodeId_ValidUrlOutCorrectID_Test() {
            const string input = "https://eztv.it/ep/59833/the-big-bang-theory-s08e07-hdtv-x264-lol/";
            const int expected = 59833;
            int id;
            EpisodeParser.TryParseEpisodeId(input, out id);

            Assert.AreEqual(expected,id);
        }
        
        [Test, UsedImplicitly]
        public void TryParseEpisodeId_InvalidUrlOutNegOneID_Test() {
            const string input = "https://eztv.it/ep/GARBAGE/the-big-bang-theory-s08e07-hdtv-x264-lol/";
            const int expected = -1;
            int id;
            EpisodeParser.TryParseEpisodeId(input, out id);

            Assert.AreEqual(expected, id);
        }

        [Test, UsedImplicitly]
        public void ParseTitle_Null_ThrowsArgumentNullException() {
            Assert.Throws<ArgumentNullException>(() => EpisodeParser.ParseTitle(null));
        }

        [Test, UsedImplicitly]
        public void ParseTitle_Empty_ThrowsInvalidOperationException() {
            Assert.Throws<InvalidOperationException>(() => {
                var ep = new EZTVEpisode {
                    Title = ""
                };
                EpisodeParser.ParseTitle(ep);
            });
        }

        [Test, UsedImplicitly]
        public void ParseTitle_BadTitle_ThrowsInvalidOperationException() {
            Assert.Throws<InvalidOperationException>(() => {
                var ep = new EZTVEpisode {
                    Title = "Garbage"
                };
                EpisodeParser.ParseTitle(ep);
            });
        }

        [Test, UsedImplicitly]
        public void ParseTitle_Title_sNeN_Success() {
            var ep = new EZTVEpisode {
                Title = "24 S09E12 HDTV x264-LOL"
            };
            EpisodeParser.ParseTitle(ep);
            Assert.AreEqual("24", ep.Show);
            Assert.AreEqual(9, ep.Season);
            Assert.AreEqual(12, ep.EpisodeNum);
        }
        [Test, UsedImplicitly]
        public void ParseTitle_Title_NxN_Success() {
            var ep = new EZTVEpisode {
                Title = "Ashes to Ashes 3x08 (HDTV-FoV) [VTV]"
            };
            EpisodeParser.ParseTitle(ep);
            Assert.AreEqual("Ashes to Ashes", ep.Show);
            Assert.AreEqual(3, ep.Season);
            Assert.AreEqual(8, ep.EpisodeNum);
        }
        //Klondike 2014 Part Two HDTV x264-2HD
        [Test, UsedImplicitly]
        public void ParseTitle_Title_PartN_Success() {
            var ep = new EZTVEpisode {
                Title = "Ascension Part 1 HDTV x264-SYS"
            };
            EpisodeParser.ParseTitle(ep);
            Assert.AreEqual("Ascension", ep.Show);
            Assert.AreEqual(1, ep.Season);
            Assert.AreEqual(1, ep.EpisodeNum);
        }
        [Test, UsedImplicitly]
        public void ParseTitle_Title_PartNWholeWord_Success() {
            var ep = new EZTVEpisode {
                Title = "Klondike 2014 Part Two HDTV x264-2HD"
            };
            EpisodeParser.ParseTitle(ep);
            Assert.AreEqual("Klondike 2014", ep.Show);
            Assert.AreEqual(1, ep.Season);
            Assert.AreEqual(2, ep.EpisodeNum);
        }
    }
}
