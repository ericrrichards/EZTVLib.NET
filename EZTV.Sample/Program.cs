using System;

namespace EZTV.Sample {
    

    class Program {
        static void Main() {
            
            var shows = EZTV.GetShows("archer");
            foreach (var show in shows) {
                Console.WriteLine("{0}\t{1}\t{2}\t{3}", show.Id, show.Title, show.Status, show.Url);
            }
            
            var episodes = EZTV.GetEpisodes(609);
            foreach (var eztvEpisode in episodes.Episodes) {
                Console.WriteLine("{0} S{1}E{2}",eztvEpisode.Show, eztvEpisode.Season, eztvEpisode.EpisodeNum);
            }

            Console.ReadLine();
        }
    }
}
