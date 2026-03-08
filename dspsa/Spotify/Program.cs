using System;

namespace Spotify
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Artist MylesSmith = new Artist("Myles Smith");
            Artist BadBunny = new Artist("Bad Bunny");
            Artist Scorpios = new Artist("Scorpios");
            Artist Rihanna = new Artist("Rihanna");

            Song Stargazing = new Song("Stargazing", 3000, MylesSmith, Genre.FolkPop, 2024);
            Song NiceToMeetYou = new Song("Nice to meet you", 4000, MylesSmith, Genre.FolkPop, 2024);
            Song MyHome = new Song("My Home", 2000, MylesSmith, Genre.FolkPop, 2024);
            Song DtMF = new Song("DtMF", 5000, BadBunny, Genre.Latin, 2025);
            Song Dakiti = new Song("Dakiti", 2000, BadBunny, Genre.Latin, 2020);
            Song BornToTouchYourFeelings = new Song("Born to touch your feeling", 4000, Scorpios, Genre.Rock, 1975);
            Song StillLovingYou = new Song("Still loving you", 3000, Scorpios, Genre.Rock, 1970);
            Song Umbrella = new Song("Umbrella", 4000, Rihanna, Genre.HipHip, 2007);
            Song Diamonds = new Song("Diamonds", 2000, Rihanna, Genre.Rap, 2012);
            Song Rehab = new Song("Rehab", 5000, Rihanna, Genre.HipHip, 2007);
            Song ManDown = new Song("Man down", 2000, Rihanna, Genre.HipHip, 2011);

            List<Song> songs = new List<Song>();
            songs.Add(Stargazing);songs.Add(NiceToMeetYou);songs.Add(MyHome);songs.Add(DtMF);
            songs.Add(Dakiti);songs.Add(BornToTouchYourFeelings);
            songs.Add(StillLovingYou);songs.Add(Umbrella);songs.Add(Diamonds);songs.Add(Rehab);
            songs.Add(ManDown);

            /*foreach (var item in songs)
            {
                item.Play();
            }*/

            Album YonisFavourteSongs = new Album("Yonis favourite Rihanna songs");
            YonisFavourteSongs.AddSong(Umbrella);YonisFavourteSongs.AddSong(Diamonds);
            Album YonisHatesTheHeating = new Album("Yonis hates the heating");
            YonisHatesTheHeating.AddSong(Rehab);YonisHatesTheHeating.AddSong(ManDown);
            Rihanna.AddAlbum(YonisFavourteSongs);Rihanna.AddAlbum(YonisHatesTheHeating);

            Album Stargazer = new Album("Stargazer");
            Stargazer.AddSong(Stargazing);
            MylesSmith.AddAlbum(Stargazer);

            Console.WriteLine();
            Playlist JosephsFavouriteTunes = new Playlist("Joseph's favourite Tunes", songs);

            JosephsFavouriteTunes.Sort();
            Console.WriteLine(JosephsFavouriteTunes);
            
            //JosephsFavouriteTunes.Shuffle();
            //JosephsFavouriteTunes.Play();

        }
    }
}