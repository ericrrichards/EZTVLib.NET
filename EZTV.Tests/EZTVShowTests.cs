using EZTV;
using EZTVTests.Annotations;
using NUnit.Framework;

namespace EZTVTests {
    [TestFixture]
    public class EZTVShowTests {
        [Test, UsedImplicitly]
        public void ParseShow_Null_ReturnsNull() {
            var show = EZTVShow.ParseShow(null);
            Assert.AreEqual(null, show);
        }
        [Test, UsedImplicitly]
        public void ParseShow_Garbage_ReturnsNull() {
            var show = EZTVShow.ParseShow("garbage");
            Assert.AreEqual(null, show);
        }
        [Test, UsedImplicitly]
        public void ParseShow_TdNoA_ReturnsNull() {
            var show = EZTVShow.ParseShow("<tr><td>Garbage</td></tr>");
            Assert.AreEqual(null, show);
        }
        [Test, UsedImplicitly]
        public void ParseShow_TdANoHref_ReturnsNull() {
            var show = EZTVShow.ParseShow("<tr><td><a>Garbage</a></td></tr>");
            Assert.AreEqual(null, show);
        }
        [Test, UsedImplicitly]
        public void ParseShow_TdAHrefNoMatch_ReturnsNull() {
            var show = EZTVShow.ParseShow("<tr><td><a href='http://google.com'>Garbage</a></td></tr>");
            Assert.AreEqual(null, show);
        }
        [Test, UsedImplicitly]
        public void ParseShow_TdAHrefPartialMatch_ReturnsNull() {
            var show = EZTVShow.ParseShow("<tr><td><a href='/shows/1/'>Garbage</a></td></tr>");
            Assert.AreEqual(null, show);
        }
        [Test, UsedImplicitly]
        public void ParseShow_TdAHrefBadId_ReturnsNull() {
            var show = EZTVShow.ParseShow("<tr><td><a href='/shows/Garbage/Garbage'>Garbage</a></td></tr>");
            Assert.AreEqual(null, show);
        }
        [Test, UsedImplicitly]
        public void ParseShow_OnlyOneTd_ReturnsNull() {
            var show = EZTVShow.ParseShow("<tr><td><a href='/shows/1/24/'>24</a></td></tr>");
            Assert.AreEqual(null, show);
        }
        /*
        "<tr name='hover' class=''>"+
                "<td class='forum_thread_post' align='center'><a href='/shows/1/24/' class='thread_link'><img src='//ezimg.it/t/24/thumb_50_42.png' width='50' height='42'></a></td>" +
				"<td class='forum_thread_post'><a href='/shows/1/24/' class='thread_link'>24</a></td>"+
				"<td class='forum_thread_post'><font class='ended'>Ended</font></td>"+
				"<td class='forum_thread_post' align='center'>"+
                    "4.60<br>"+
                    "<span style='font-size: 10px;'>avg out of 1,075 votes</span>"+
                "</td>"+
			"</tr>"
         */
        [Test, UsedImplicitly]
        public void ParseShow_OnlyTwoTds_ReturnsNull() {
            var show = EZTVShow.ParseShow(
                "<tr name='hover' class=''>"+
                    "<td class='forum_thread_post' align='center'><a href='/shows/1/24/' class='thread_link'><img src='//ezimg.it/t/24/thumb_50_42.png' width='50' height='42'></a></td>" +
				    "<td class='forum_thread_post'><a href='/shows/1/24/' class='thread_link'>24</a></td>"+
			    "</tr>"
            );
            Assert.AreEqual(null, show);
        }
        [Test, UsedImplicitly]
        public void ParseShow_Valid_ShowUrlCorrect() {
            var show = EZTVShow.ParseShow(
                "<tr name='hover' class=''>" +
                    "<td class='forum_thread_post' align='center'><a href='/shows/1/24/' class='thread_link'><img src='//ezimg.it/t/24/thumb_50_42.png' width='50' height='42'></a></td>" +
                    "<td class='forum_thread_post'><a href='/shows/1/24/' class='thread_link'>24</a></td>" +
                    "<td class='forum_thread_post'><font class='ended'>Ended</font></td>" +
                    "<td class='forum_thread_post' align='center'>" +
                        "4.60<br>" +
                        "<span style='font-size: 10px;'>avg out of 1,075 votes</span>" +
                    "</td>" +
                "</tr>"
            );
            Assert.AreEqual("/shows/1/24/", show.Url);
        }
        [Test, UsedImplicitly]
        public void ParseShow_Valid_ShowIdCorrect() {
            var show = EZTVShow.ParseShow(
                "<tr name='hover' class=''>" +
                    "<td class='forum_thread_post' align='center'><a href='/shows/1/24/' class='thread_link'><img src='//ezimg.it/t/24/thumb_50_42.png' width='50' height='42'></a></td>" +
                    "<td class='forum_thread_post'><a href='/shows/1/24/' class='thread_link'>24</a></td>" +
                    "<td class='forum_thread_post'><font class='ended'>Ended</font></td>" +
                    "<td class='forum_thread_post' align='center'>" +
                        "4.60<br>" +
                        "<span style='font-size: 10px;'>avg out of 1,075 votes</span>" +
                    "</td>" +
                "</tr>"
            );
            Assert.AreEqual(1, show.Id);
        }
        [Test, UsedImplicitly]
        public void ParseShow_Valid_ShowSlugCorrect() {
            var show = EZTVShow.ParseShow(
                "<tr name='hover' class=''>" +
                    "<td class='forum_thread_post' align='center'><a href='/shows/1/24/' class='thread_link'><img src='//ezimg.it/t/24/thumb_50_42.png' width='50' height='42'></a></td>" +
                    "<td class='forum_thread_post'><a href='/shows/1/24/' class='thread_link'>24</a></td>" +
                    "<td class='forum_thread_post'><font class='ended'>Ended</font></td>" +
                    "<td class='forum_thread_post' align='center'>" +
                        "4.60<br>" +
                        "<span style='font-size: 10px;'>avg out of 1,075 votes</span>" +
                    "</td>" +
                "</tr>"
            );
            Assert.AreEqual("24", show.Slug);
        }
        [Test, UsedImplicitly]
        public void ParseShow_Valid_ShowTitleCorrect() {
            var show = EZTVShow.ParseShow(
                "<tr name='hover' class=''>" +
                    "<td class='forum_thread_post' align='center'><a href='/shows/1/24/' class='thread_link'><img src='//ezimg.it/t/24/thumb_50_42.png' width='50' height='42'></a></td>" +
                    "<td class='forum_thread_post'><a href='/shows/1/24/' class='thread_link'>24</a></td>" +
                    "<td class='forum_thread_post'><font class='ended'>Ended</font></td>" +
                    "<td class='forum_thread_post' align='center'>" +
                        "4.60<br>" +
                        "<span style='font-size: 10px;'>avg out of 1,075 votes</span>" +
                    "</td>" +
                "</tr>"
            );
            Assert.AreEqual("24", show.Title);
        }
        [Test, UsedImplicitly]
        public void ParseShow_Valid_ShowStatusCorrect() {
            var show = EZTVShow.ParseShow(
                "<tr name='hover' class=''>" +
                    "<td class='forum_thread_post' align='center'><a href='/shows/1/24/' class='thread_link'><img src='//ezimg.it/t/24/thumb_50_42.png' width='50' height='42'></a></td>" +
                    "<td class='forum_thread_post'><a href='/shows/1/24/' class='thread_link'>24</a></td>" +
                    "<td class='forum_thread_post'><font class='ended'>Ended</font></td>" +
                    "<td class='forum_thread_post' align='center'>" +
                        "4.60<br>" +
                        "<span style='font-size: 10px;'>avg out of 1,075 votes</span>" +
                    "</td>" +
                "</tr>"
            );
            Assert.AreEqual("ended", show.Status);
        }
        [Test, UsedImplicitly]
        public void ParseShow_ValidRearrangedTitle_ShowTitleCorrect() {
            var show = EZTVShow.ParseShow(
                "<tr name='hover' class='hover'>"+
                    "<td class='forum_thread_post' align='center'><a href='/shows/23/the-big-bang-theory/' class='thread_link'><img src='//ezimg.it/t/the_big_bang_theory/thumb_50_42.png' width='50' height='42'></a></td>" +
			        "<td class='forum_thread_post'><a href='/shows/23/the-big-bang-theory/' class='thread_link'>Big Bang Theory, The</a></td>"+
			        "<td class='forum_thread_post'><font class='airing'>Airing: Thursday</font></td>"+
			        "<td class='forum_thread_post' align='center'>"+
                        "4.74<br>"+
                        "<span style='font-size: 10px;'>avg out of 3,573 votes</span>"+
                    "</td>"+
		        "</tr>"
            );
            Assert.AreEqual("The Big Bang Theory", show.Title);
        }
    }
}
