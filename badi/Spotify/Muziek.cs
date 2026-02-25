using System;

namespace Spotify
{
    public class Album
    {
        public string Titel { get; set; }
        public Zanger Artiest { get; set; }
        public int Duur { get; private set; }
        public List<Song> Liedjes { get; set; }
        public bool Like { get; private set; }

        public Album(string titel, Zanger artiest)
        {
            Titel = titel;
            Artiest = artiest;
            Liedjes = new List<Song>();
            Duur = 0;
        }

        public Album(string titel, Zanger artiest, List<Song> liedjes)
        {
            Titel = titel;
            Artiest = artiest;
            Liedjes = liedjes;
            Duur = 0;
            
            foreach (var liedje in Liedjes)
            {
                Duur += liedje.Duur;
            }
        }

        public void AddSong(Song song)
        {
            Liedjes.Add(song);
            Duur += song.Duur;
        }
        public void RemoveSong(Song song)
        {
            Liedjes.Remove(song);
            Duur -= song.Duur;
        }

        public void Play()
        {
            foreach(var song in Liedjes)
            {
                song.Play();
            }
        }



    }


    public enum Genre
    {
        HipHop, Pop, Rap, Kpop, Afrobeats, Jazz, RnB, Klassiek, House, Techno, Dubstep, DnB,
        Country, Trap, Trance, Experimental, Alternative, Rock, Soul, Folk, Metal, Punk, UKDril,
        Electronic, Indie, Ska, Swing, Disco, Funk, Latin, World, NewAge, SoundTrack, AudioBook,
        Cher, Kinder, HeavyMetal, BlackMetal, DeathMetal, Blues, Reggae
    }

    public class Song
    {
        public string Titel { get; set; }
        public int Duur { get; set; }
        public Zanger Artiest { get; set; }
        public Genre G { get; set; }
        public bool Like { get; private set; }

        public Song(string titel, int duur, Zanger artiest, Genre g)
        {
            Titel = titel; Duur = duur; Artiest = artiest; G = g; Like = false;
            Artiest.Songs.Add(this);
        }

        public override string ToString()
        {
            return $"NUMMER: {Titel} van {Artiest.Naam}, duur: {Duur} - genre: {G}";
        }

        public void Play()
        {
            //simuleren van afspelen nummer, adhv een sleep functie.

            Console.WriteLine($"Now playing: {Titel} by {Artiest.Naam}\n");
            for (int i = 0; i < Duur; i++)
            {
                Console.Write(". ");
                Console.Beep();
                Thread.Sleep(1000);
            }
            Console.WriteLine($"\nFinished playing: {Titel}\n\n");
        }
    }
}