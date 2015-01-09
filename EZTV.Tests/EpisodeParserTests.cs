using NUnit.Framework;
namespace EZTV.Tests {
    [TestFixture()]
    public class EpisodeParserTests {
        [Test()]
        public void TryParseEpisodeId_NullReturnsFalse_Test() {
            string input = null;
            int id;
            var ret = EpisodeParser.TryParseEpisodeId(input, out id);

            Assert.IsFalse(ret);
        }
        [Test()]
        public void TryParseEpisodeId_EmptyReturnsFalse_Test() {
            string input = "";
            int id;
            var ret = EpisodeParser.TryParseEpisodeId(input, out id);

            Assert.IsFalse(ret);
        }

        
        [Test()]
        public void TryParseEpisodeId_ValidUrlReturnsTrue_Test() {
            string input = "https://eztv.it/ep/59833/the-big-bang-theory-s08e07-hdtv-x264-lol/";
            int id;
            var ret = EpisodeParser.TryParseEpisodeId(input, out id);

            Assert.IsTrue(ret);
        }
        [Test()]
        public void TryParseEpisodeId_ValidUrlOutCorrectID_Test() {
            string input = "https://eztv.it/ep/59833/the-big-bang-theory-s08e07-hdtv-x264-lol/";
            int expected = 59833;
            int id;
            var ret = EpisodeParser.TryParseEpisodeId(input, out id);

            Assert.AreEqual(expected,id);
        }
        [Test()]
        public void TryParseEpisodeId_InvalidUrlOutNegOneID_Test() {
            string input = "https://eztv.it/ep/GARBAGE/the-big-bang-theory-s08e07-hdtv-x264-lol/";
            int expected = -1;
            int id;
            var ret = EpisodeParser.TryParseEpisodeId(input, out id);

            Assert.AreEqual(expected, id);
        }
    }
}
