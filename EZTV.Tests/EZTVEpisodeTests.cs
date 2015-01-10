using EZTV;
using EZTVTests.Annotations;
using NUnit.Framework;

namespace EZTVTests {
    [TestFixture]
    public class EZTVEpisodeTests {
        [Test, UsedImplicitly]
        public void ParseEpisodeTest_Null_ReturnsNull() {
            var ep = EZTVEpisode.ParseEpisode(null);
            Assert.AreEqual(null, ep);
        }
        [Test, UsedImplicitly]
        public void ParseEpisodeTest_Garbage_ReturnsNull() {
            var ep = EZTVEpisode.ParseEpisode("garbage");
            Assert.AreEqual(null, ep);
        }
        [Test, UsedImplicitly]
        public void ParseEpisodeTest_NotEnoughTds_ReturnsNull() {
            var ep = EZTVEpisode.ParseEpisode("<tr><td>Garbage</td></tr>");
            Assert.AreEqual(null, ep);
        }
        [Test, UsedImplicitly]
        public void ParseEpisodeTest_SecondTdHasNoA_ReturnsNull() {
            var ep = EZTVEpisode.ParseEpisode("<tr><td>Garbage</td><td>Garbage</td></tr>");
            Assert.AreEqual(null, ep);
        }
        [Test, UsedImplicitly]
        public void ParseEpisodeTest_SecondTdAHasNoHref_ReturnsNull() {
            var ep = EZTVEpisode.ParseEpisode("<tr><td>Garbage</td><td><a>Garbage</a></td></tr>");
            Assert.AreEqual(null, ep);
        }
        /*
        "<tr name='hover' class='forum_header_border'>" +
                "<td width='35' class='forum_thread_post'><a href='/shows/16/ashes-to-ashes/'><img src='//ezimg.it/s/1/3/show_info.png' border='0' alt='Show' title='Show Description about Ashes to Ashes'></a><a href='http://www.tvrage.com/shows/id-15504/episodes/1064918969/' target='_blank' title='More info about Ashes to Ashes 3x08 (HDTV-FoV) at tvrage.com' alt='More info about Ashes to Ashes 3x08 (HDTV-FoV) at tvrage.com'><img src='//ezimg.it/s/2/1/tvrage.png' width='16' height='16' border='0'></a></td>" +
                "<td class='forum_thread_post'>" +
                "<a href='/ep/20676/ashes-to-ashes-3x08-hdtv-fov/' title='Ashes to Ashes 3x08 (HDTV-FoV) [VTV] (549.92 MB)' alt='Ashes to Ashes 3x08 (HDTV-FoV) [VTV] (549.92 MB)' class='epinfo'>Ashes to Ashes 3x08 (HDTV-FoV) [VTV]</a>" +
                "</td>" +
                "<td align='center' class='forum_thread_post'><a href='magnet:?xt=urn:btih:D5E3971FE5DB9C85135733FC63DB28319013F1A9&amp;dn=Ashes.to.Ashes.3x08.(HDTV-FoV)&amp;tr=udp://tracker.openbittorrent.com:80&amp;tr=udp://tracker.publicbt.com:80&amp;tr=udp://tracker.istole.it:80&amp;tr=udp://open.demonii.com:80&amp;tr=udp://tracker.coppersurfer.tk:80' class='magnet' title='Magnet Link'></a><a href='' data-file='Ashes.to.Ashes.3x08.(HDTV-FoV).torrent' data-url='http%3A%2F%2Fre.zoink.it%2Fg%2FD5E3971FE5DB9C85135733FC63DB28319013F1A9' target='_blank' class='gsf gsfc' title='Download Fast' onclick='ga('send','event','button','sponsored','torrent-link');'></a><a href='//torrent.zoink.it/Ashes.to.Ashes.3x08.(HDTV-FoV)[VTV].torrent' class='download_1' title='Download Mirror #1'></a><a href='http://www.bt-chat.com/download1.php?id=85763' class='download_2' title='Download Mirror #2'></a>	  </td>" +
                "<td align='center' class='forum_thread_post'>&gt;1 week</td>" +
                "<td align='center' class='forum_thread_post_end'><a href='/forum/15933/ashes-to-ashes-3x08-hdtv-fov/'><img src='//ezimg.it/s/1/3/chat_messages.png' border='0' width='16' height='16' alt='9 comments' title='9 forum comments'></a></td>" +
            "</tr>"
         */
        [Test, UsedImplicitly]
        public void ParseEpisodeTest_OnlyTwoTds_ReturnsNull() {
            var ep = EZTVEpisode.ParseEpisode(
            "<tr name='hover' class='forum_header_border'>" +
                "<td width='35' class='forum_thread_post'><a href='/shows/16/ashes-to-ashes/'><img src='//ezimg.it/s/1/3/show_info.png' border='0' alt='Show' title='Show Description about Ashes to Ashes'></a><a href='http://www.tvrage.com/shows/id-15504/episodes/1064918969/' target='_blank' title='More info about Ashes to Ashes 3x08 (HDTV-FoV) at tvrage.com' alt='More info about Ashes to Ashes 3x08 (HDTV-FoV) at tvrage.com'><img src='//ezimg.it/s/2/1/tvrage.png' width='16' height='16' border='0'></a></td>" +
                "<td class='forum_thread_post'>" +
                "<a href='/ep/20676/ashes-to-ashes-3x08-hdtv-fov/' title='Ashes to Ashes 3x08 (HDTV-FoV) [VTV] (549.92 MB)' alt='Ashes to Ashes 3x08 (HDTV-FoV) [VTV] (549.92 MB)' class='epinfo'>Ashes to Ashes 3x08 (HDTV-FoV) [VTV]</a>" +
                "</td>" +
            "</tr>"
            );
            Assert.AreEqual(null, ep);
        }
        [Test, UsedImplicitly]
        public void ParseEpisodeTest_ThreeTds_ThirdNoA_ReturnsNull() {
            var ep = EZTVEpisode.ParseEpisode(
            "<tr name='hover' class='forum_header_border'>" +
                "<td width='35' class='forum_thread_post'><a href='/shows/16/ashes-to-ashes/'><img src='//ezimg.it/s/1/3/show_info.png' border='0' alt='Show' title='Show Description about Ashes to Ashes'></a><a href='http://www.tvrage.com/shows/id-15504/episodes/1064918969/' target='_blank' title='More info about Ashes to Ashes 3x08 (HDTV-FoV) at tvrage.com' alt='More info about Ashes to Ashes 3x08 (HDTV-FoV) at tvrage.com'><img src='//ezimg.it/s/2/1/tvrage.png' width='16' height='16' border='0'></a></td>" +
                "<td class='forum_thread_post'>" +
                "<a href='/ep/20676/ashes-to-ashes-3x08-hdtv-fov/' title='Ashes to Ashes 3x08 (HDTV-FoV) [VTV] (549.92 MB)' alt='Ashes to Ashes 3x08 (HDTV-FoV) [VTV] (549.92 MB)' class='epinfo'>Ashes to Ashes 3x08 (HDTV-FoV) [VTV]</a>" +
                "</td>" +
                "<td align='center' class='forum_thread_post'>Garbage</td>" +
            "</tr>"
            );
            Assert.AreEqual(null, ep);
        }
        [Test, UsedImplicitly]
        public void ParseEpisodeTest_ThreeTds_ThirdNoMagnet_ReturnsNull() {
            var ep = EZTVEpisode.ParseEpisode(
            "<tr name='hover' class='forum_header_border'>" +
                "<td width='35' class='forum_thread_post'><a href='/shows/16/ashes-to-ashes/'><img src='//ezimg.it/s/1/3/show_info.png' border='0' alt='Show' title='Show Description about Ashes to Ashes'></a><a href='http://www.tvrage.com/shows/id-15504/episodes/1064918969/' target='_blank' title='More info about Ashes to Ashes 3x08 (HDTV-FoV) at tvrage.com' alt='More info about Ashes to Ashes 3x08 (HDTV-FoV) at tvrage.com'><img src='//ezimg.it/s/2/1/tvrage.png' width='16' height='16' border='0'></a></td>" +
                "<td class='forum_thread_post'>" +
                "<a href='/ep/20676/ashes-to-ashes-3x08-hdtv-fov/' title='Ashes to Ashes 3x08 (HDTV-FoV) [VTV] (549.92 MB)' alt='Ashes to Ashes 3x08 (HDTV-FoV) [VTV] (549.92 MB)' class='epinfo'>Ashes to Ashes 3x08 (HDTV-FoV) [VTV]</a>" +
                "</td>" +
                "<td align='center' class='forum_thread_post'><a href='#'>Garbage</a></td>" +
            "</tr>"
            );
            Assert.AreEqual(null, ep);
        }
        [Test, UsedImplicitly]
        public void ParseEpisodeTest_Valid_ReturnsNonNull() {
            var ep = EZTVEpisode.ParseEpisode(
            "<tr name='hover' class='forum_header_border'>" +
                "<td width='35' class='forum_thread_post'><a href='/shows/16/ashes-to-ashes/'><img src='//ezimg.it/s/1/3/show_info.png' border='0' alt='Show' title='Show Description about Ashes to Ashes'></a><a href='http://www.tvrage.com/shows/id-15504/episodes/1064918969/' target='_blank' title='More info about Ashes to Ashes 3x08 (HDTV-FoV) at tvrage.com' alt='More info about Ashes to Ashes 3x08 (HDTV-FoV) at tvrage.com'><img src='//ezimg.it/s/2/1/tvrage.png' width='16' height='16' border='0'></a></td>" +
                "<td class='forum_thread_post'>" +
                "<a href='/ep/20676/ashes-to-ashes-3x08-hdtv-fov/' title='Ashes to Ashes 3x08 (HDTV-FoV) [VTV] (549.92 MB)' alt='Ashes to Ashes 3x08 (HDTV-FoV) [VTV] (549.92 MB)' class='epinfo'>Ashes to Ashes 3x08 (HDTV-FoV) [VTV]</a>" +
                "</td>" +
                "<td align='center' class='forum_thread_post'><a href='magnet:?xt=urn:btih:D5E3971FE5DB9C85135733FC63DB28319013F1A9&amp;dn=Ashes.to.Ashes.3x08.(HDTV-FoV)&amp;tr=udp://tracker.openbittorrent.com:80&amp;tr=udp://tracker.publicbt.com:80&amp;tr=udp://tracker.istole.it:80&amp;tr=udp://open.demonii.com:80&amp;tr=udp://tracker.coppersurfer.tk:80' class='magnet' title='Magnet Link'></a><a href='' data-file='Ashes.to.Ashes.3x08.(HDTV-FoV).torrent' data-url='http%3A%2F%2Fre.zoink.it%2Fg%2FD5E3971FE5DB9C85135733FC63DB28319013F1A9' target='_blank' class='gsf gsfc' title='Download Fast' onclick='ga('send','event','button','sponsored','torrent-link');'></a><a href='//torrent.zoink.it/Ashes.to.Ashes.3x08.(HDTV-FoV)[VTV].torrent' class='download_1' title='Download Mirror #1'></a><a href='http://www.bt-chat.com/download1.php?id=85763' class='download_2' title='Download Mirror #2'></a>	  </td>" +
                "<td align='center' class='forum_thread_post'>&gt;1 week</td>" +
                "<td align='center' class='forum_thread_post_end'><a href='/forum/15933/ashes-to-ashes-3x08-hdtv-fov/'><img src='//ezimg.it/s/1/3/chat_messages.png' border='0' width='16' height='16' alt='9 comments' title='9 forum comments'></a></td>" +
            "</tr>"
            );
            Assert.AreNotEqual(null, ep);
        }
        [Test, UsedImplicitly]
        public void ParseEpisodeTest_Valid_EpisodeUrlCorrect() {
            var ep = EZTVEpisode.ParseEpisode(
            "<tr name='hover' class='forum_header_border'>" +
                "<td width='35' class='forum_thread_post'><a href='/shows/16/ashes-to-ashes/'><img src='//ezimg.it/s/1/3/show_info.png' border='0' alt='Show' title='Show Description about Ashes to Ashes'></a><a href='http://www.tvrage.com/shows/id-15504/episodes/1064918969/' target='_blank' title='More info about Ashes to Ashes 3x08 (HDTV-FoV) at tvrage.com' alt='More info about Ashes to Ashes 3x08 (HDTV-FoV) at tvrage.com'><img src='//ezimg.it/s/2/1/tvrage.png' width='16' height='16' border='0'></a></td>" +
                "<td class='forum_thread_post'>" +
                "<a href='/ep/20676/ashes-to-ashes-3x08-hdtv-fov/' title='Ashes to Ashes 3x08 (HDTV-FoV) [VTV] (549.92 MB)' alt='Ashes to Ashes 3x08 (HDTV-FoV) [VTV] (549.92 MB)' class='epinfo'>Ashes to Ashes 3x08 (HDTV-FoV) [VTV]</a>" +
                "</td>" +
                "<td align='center' class='forum_thread_post'><a href='magnet:?xt=urn:btih:D5E3971FE5DB9C85135733FC63DB28319013F1A9&amp;dn=Ashes.to.Ashes.3x08.(HDTV-FoV)&amp;tr=udp://tracker.openbittorrent.com:80&amp;tr=udp://tracker.publicbt.com:80&amp;tr=udp://tracker.istole.it:80&amp;tr=udp://open.demonii.com:80&amp;tr=udp://tracker.coppersurfer.tk:80' class='magnet' title='Magnet Link'></a><a href='' data-file='Ashes.to.Ashes.3x08.(HDTV-FoV).torrent' data-url='http%3A%2F%2Fre.zoink.it%2Fg%2FD5E3971FE5DB9C85135733FC63DB28319013F1A9' target='_blank' class='gsf gsfc' title='Download Fast' onclick='ga('send','event','button','sponsored','torrent-link');'></a><a href='//torrent.zoink.it/Ashes.to.Ashes.3x08.(HDTV-FoV)[VTV].torrent' class='download_1' title='Download Mirror #1'></a><a href='http://www.bt-chat.com/download1.php?id=85763' class='download_2' title='Download Mirror #2'></a>	  </td>" +
                "<td align='center' class='forum_thread_post'>&gt;1 week</td>" +
                "<td align='center' class='forum_thread_post_end'><a href='/forum/15933/ashes-to-ashes-3x08-hdtv-fov/'><img src='//ezimg.it/s/1/3/chat_messages.png' border='0' width='16' height='16' alt='9 comments' title='9 forum comments'></a></td>" +
            "</tr>"
            );
            Assert.AreEqual("/ep/20676/ashes-to-ashes-3x08-hdtv-fov/", ep.Url);
        }
        [Test, UsedImplicitly]
        public void ParseEpisodeTest_Valid_EpisodeIdCorrect() {
            var ep = EZTVEpisode.ParseEpisode(
            "<tr name='hover' class='forum_header_border'>" +
                "<td width='35' class='forum_thread_post'><a href='/shows/16/ashes-to-ashes/'><img src='//ezimg.it/s/1/3/show_info.png' border='0' alt='Show' title='Show Description about Ashes to Ashes'></a><a href='http://www.tvrage.com/shows/id-15504/episodes/1064918969/' target='_blank' title='More info about Ashes to Ashes 3x08 (HDTV-FoV) at tvrage.com' alt='More info about Ashes to Ashes 3x08 (HDTV-FoV) at tvrage.com'><img src='//ezimg.it/s/2/1/tvrage.png' width='16' height='16' border='0'></a></td>" +
                "<td class='forum_thread_post'>" +
                "<a href='/ep/20676/ashes-to-ashes-3x08-hdtv-fov/' title='Ashes to Ashes 3x08 (HDTV-FoV) [VTV] (549.92 MB)' alt='Ashes to Ashes 3x08 (HDTV-FoV) [VTV] (549.92 MB)' class='epinfo'>Ashes to Ashes 3x08 (HDTV-FoV) [VTV]</a>" +
                "</td>" +
                "<td align='center' class='forum_thread_post'><a href='magnet:?xt=urn:btih:D5E3971FE5DB9C85135733FC63DB28319013F1A9&amp;dn=Ashes.to.Ashes.3x08.(HDTV-FoV)&amp;tr=udp://tracker.openbittorrent.com:80&amp;tr=udp://tracker.publicbt.com:80&amp;tr=udp://tracker.istole.it:80&amp;tr=udp://open.demonii.com:80&amp;tr=udp://tracker.coppersurfer.tk:80' class='magnet' title='Magnet Link'></a><a href='' data-file='Ashes.to.Ashes.3x08.(HDTV-FoV).torrent' data-url='http%3A%2F%2Fre.zoink.it%2Fg%2FD5E3971FE5DB9C85135733FC63DB28319013F1A9' target='_blank' class='gsf gsfc' title='Download Fast' onclick='ga('send','event','button','sponsored','torrent-link');'></a><a href='//torrent.zoink.it/Ashes.to.Ashes.3x08.(HDTV-FoV)[VTV].torrent' class='download_1' title='Download Mirror #1'></a><a href='http://www.bt-chat.com/download1.php?id=85763' class='download_2' title='Download Mirror #2'></a>	  </td>" +
                "<td align='center' class='forum_thread_post'>&gt;1 week</td>" +
                "<td align='center' class='forum_thread_post_end'><a href='/forum/15933/ashes-to-ashes-3x08-hdtv-fov/'><img src='//ezimg.it/s/1/3/chat_messages.png' border='0' width='16' height='16' alt='9 comments' title='9 forum comments'></a></td>" +
            "</tr>"
            );
            Assert.AreEqual(20676, ep.ID);
        }
        [Test, UsedImplicitly]
        public void ParseEpisodeTest_Valid_EpisodeTitleCorrect() {
            var ep = EZTVEpisode.ParseEpisode(
            "<tr name='hover' class='forum_header_border'>" +
                "<td width='35' class='forum_thread_post'><a href='/shows/16/ashes-to-ashes/'><img src='//ezimg.it/s/1/3/show_info.png' border='0' alt='Show' title='Show Description about Ashes to Ashes'></a><a href='http://www.tvrage.com/shows/id-15504/episodes/1064918969/' target='_blank' title='More info about Ashes to Ashes 3x08 (HDTV-FoV) at tvrage.com' alt='More info about Ashes to Ashes 3x08 (HDTV-FoV) at tvrage.com'><img src='//ezimg.it/s/2/1/tvrage.png' width='16' height='16' border='0'></a></td>" +
                "<td class='forum_thread_post'>" +
                "<a href='/ep/20676/ashes-to-ashes-3x08-hdtv-fov/' title='Ashes to Ashes 3x08 (HDTV-FoV) [VTV] (549.92 MB)' alt='Ashes to Ashes 3x08 (HDTV-FoV) [VTV] (549.92 MB)' class='epinfo'>Ashes to Ashes 3x08 (HDTV-FoV) [VTV]</a>" +
                "</td>" +
                "<td align='center' class='forum_thread_post'><a href='magnet:?xt=urn:btih:D5E3971FE5DB9C85135733FC63DB28319013F1A9&amp;dn=Ashes.to.Ashes.3x08.(HDTV-FoV)&amp;tr=udp://tracker.openbittorrent.com:80&amp;tr=udp://tracker.publicbt.com:80&amp;tr=udp://tracker.istole.it:80&amp;tr=udp://open.demonii.com:80&amp;tr=udp://tracker.coppersurfer.tk:80' class='magnet' title='Magnet Link'></a><a href='' data-file='Ashes.to.Ashes.3x08.(HDTV-FoV).torrent' data-url='http%3A%2F%2Fre.zoink.it%2Fg%2FD5E3971FE5DB9C85135733FC63DB28319013F1A9' target='_blank' class='gsf gsfc' title='Download Fast' onclick='ga('send','event','button','sponsored','torrent-link');'></a><a href='//torrent.zoink.it/Ashes.to.Ashes.3x08.(HDTV-FoV)[VTV].torrent' class='download_1' title='Download Mirror #1'></a><a href='http://www.bt-chat.com/download1.php?id=85763' class='download_2' title='Download Mirror #2'></a>	  </td>" +
                "<td align='center' class='forum_thread_post'>&gt;1 week</td>" +
                "<td align='center' class='forum_thread_post_end'><a href='/forum/15933/ashes-to-ashes-3x08-hdtv-fov/'><img src='//ezimg.it/s/1/3/chat_messages.png' border='0' width='16' height='16' alt='9 comments' title='9 forum comments'></a></td>" +
            "</tr>"
            );
            Assert.AreEqual("Ashes to Ashes 3x08 (HDTV-FoV) [VTV]", ep.Title);
        }
        [Test, UsedImplicitly]
        public void ParseEpisodeTest_Valid_EpisodeMagnetCorrect() {
            var ep = EZTVEpisode.ParseEpisode(
            "<tr name='hover' class='forum_header_border'>" +
                "<td width='35' class='forum_thread_post'><a href='/shows/16/ashes-to-ashes/'><img src='//ezimg.it/s/1/3/show_info.png' border='0' alt='Show' title='Show Description about Ashes to Ashes'></a><a href='http://www.tvrage.com/shows/id-15504/episodes/1064918969/' target='_blank' title='More info about Ashes to Ashes 3x08 (HDTV-FoV) at tvrage.com' alt='More info about Ashes to Ashes 3x08 (HDTV-FoV) at tvrage.com'><img src='//ezimg.it/s/2/1/tvrage.png' width='16' height='16' border='0'></a></td>" +
                "<td class='forum_thread_post'>" +
                "<a href='/ep/20676/ashes-to-ashes-3x08-hdtv-fov/' title='Ashes to Ashes 3x08 (HDTV-FoV) [VTV] (549.92 MB)' alt='Ashes to Ashes 3x08 (HDTV-FoV) [VTV] (549.92 MB)' class='epinfo'>Ashes to Ashes 3x08 (HDTV-FoV) [VTV]</a>" +
                "</td>" +
                "<td align='center' class='forum_thread_post'><a href='magnet:?xt=urn:btih:D5E3971FE5DB9C85135733FC63DB28319013F1A9&dn=Ashes.to.Ashes.3x08.(HDTV-FoV)&tr=udp://tracker.openbittorrent.com:80&tr=udp://tracker.publicbt.com:80&tr=udp://tracker.istole.it:80&tr=udp://open.demonii.com:80&tr=udp://tracker.coppersurfer.tk:80' class='magnet' title='Magnet Link'></a><a href='' data-file='Ashes.to.Ashes.3x08.(HDTV-FoV).torrent' data-url='http%3A%2F%2Fre.zoink.it%2Fg%2FD5E3971FE5DB9C85135733FC63DB28319013F1A9' target='_blank' class='gsf gsfc' title='Download Fast' onclick='ga('send','event','button','sponsored','torrent-link');'></a><a href='//torrent.zoink.it/Ashes.to.Ashes.3x08.(HDTV-FoV)[VTV].torrent' class='download_1' title='Download Mirror #1'></a><a href='http://www.bt-chat.com/download1.php?id=85763' class='download_2' title='Download Mirror #2'></a>	  </td>" +
                "<td align='center' class='forum_thread_post'>&gt;1 week</td>" +
                "<td align='center' class='forum_thread_post_end'><a href='/forum/15933/ashes-to-ashes-3x08-hdtv-fov/'><img src='//ezimg.it/s/1/3/chat_messages.png' border='0' width='16' height='16' alt='9 comments' title='9 forum comments'></a></td>" +
            "</tr>"
            );
            Assert.AreEqual("magnet:?xt=urn:btih:D5E3971FE5DB9C85135733FC63DB28319013F1A9&dn=Ashes.to.Ashes.3x08.(HDTV-FoV)&tr=udp://tracker.openbittorrent.com:80&tr=udp://tracker.publicbt.com:80&tr=udp://tracker.istole.it:80&tr=udp://open.demonii.com:80&tr=udp://tracker.coppersurfer.tk:80", 
                ep.Magnet);
        }
    }
}
