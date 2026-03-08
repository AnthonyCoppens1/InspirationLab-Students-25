using System;
using System.Reflection;

namespace Spotify
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Artist ImagineDragons = new Artist("Imagine Dragons", new List<Genre>{Genre.Pop, Genre.Rock});
            Artist BoweryElectric = new Artist("Bowery Electric", new List<Genre>{Genre.Altrock, Genre.DroneRock});
            Artist Dusanvlk = new Artist("Dusanvlk", new List<Genre>{Genre.Underground, Genre.Rap});
            Artist Rammstein = new Artist("Rammstein", new List<Genre>{Genre.Metal, Genre.Rock});

            Song Bones = new Song("Bones", ImagineDragons, 3, Genre.Rock );
            Song Enemy = new Song("Enemy", ImagineDragons, 5, Genre.Pop);
            Song Believer = new Song("Believer", ImagineDragons, 4, Genre.Pop);
            Song Thunder = new Song("Thunder", ImagineDragons, 2, Genre.Rap);

            Song Beat = new Song("Beat", BoweryElectric, 4, Genre.Altrock);
            Song EmptyWords = new Song("Empty Words", BoweryElectric, 5, Genre.Ambience);
            Song WithoutStopping = new Song("Without Stopping", BoweryElectric, 2, Genre.Altrock);

            Song VeganJunkies = new Song("Vegan Junkies", Dusanvlk, 3, Genre.Underground);
            Song EastSentinel = new Song("East Sentinel", Dusanvlk, 2, Genre.Underground);
            Song Bez = new Song("Bez", Dusanvlk, 5, Genre.Underground);

            Song Sonne = new Song("Sonne", Rammstein, 5, Genre.Metal);

            Album Slovakia = new Album("Slovakia", new DateOnly(2026, 02,23), Dusanvlk);
            Slovakia.AddSong(VeganJunkies);
            Slovakia.AddSong(EastSentinel);
            Slovakia.AddSong(Bez);

            Console.WriteLine(Slovakia);

            List<Song> songs = new List<Song>();
            songs.Add(Bones);songs.Add(Enemy);songs.Add(Believer);songs.Add(Thunder);songs.Add(Beat);
            songs.Add(EmptyWords);songs.Add(WithoutStopping);songs.Add(VeganJunkies);songs.Add(EastSentinel);
            songs.Add(Bez);songs.Add(Sonne);

            /*foreach (var song in songs)
            {
                song.Play();
            }*/

            Playlist shoe = new Playlist("Shoe", songs);

            shoe.Sort();
            Console.WriteLine(shoe);
            //shoe.Shuffle();

            shoe.Play();

        }
    }
}