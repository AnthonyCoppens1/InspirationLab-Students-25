using System;

namespace Spotify
{
    public class Playlist
    {
        public string Name { get; set; }
        public List<Song> Songs { get; set; }
        public int Duration { get; private set; }

        public Playlist(string name)
        {
            Name = name;
            Songs = new List<Song>();
            Duration = 0;
        }

        public Playlist(string name, List<Song> songs)
        {
            Name = name;
            Songs = songs;
            Duration = 0;
            foreach (var item in Songs)
            {
                Duration += item.Duration;
            }
        }
    }


    public class Album
    {
        public string Name { get; set; }
        public List<Song> Songs { get; set; }
        public int Duration { get; set; }

        public Album(string name)
        {
            Name = name;
            Songs = new List<Song>();
            Duration = 0;
        }

        public Album(string name, List<Song> songs)
        {
            Name = name;
            Songs = songs;
            Duration = 0;
            foreach(Song s in Songs)
            {
                Duration += s.Duration;
            }
        }

        public override string ToString()
        {
            string s = $"ALBUM: {Name}\n";
            s += $"Songs:\n";
            foreach (var item in Songs)
            {
                s += $"\t- {item}";
            }

            return s;
        }
        
        public void AddSong(Song song)
        {
            Songs.Add(song);
        }
        public void RemoveSong(Song song)
        {
            Songs.Remove(song);
        }
    }


    public enum Genre
    {
        Rock, Pop,Jazz,Classical,Country, FolkPop,
        Blues,Reggae,HipHip,Rap,RnB,Soul,
        Folk,Metal,Punk, Electronic,Techno, House, Trance, Dubstep, DrumAndBass,
        Indie,Alternative, Ska, Swing, Disco, Funk, Latin, World, NewAge, SoundTrack, Childrens, Cher,
        AfroBeats, AnatoliaRock, Flamenco

    }

    public class Song
    {
        public string Title { get; set; }
        public int Duration { get; set; }
        public Artist Performer { get; set; }
        public Genre G { get; set; }
        public int Year { get; set; }
        public bool IsLiked { get; private set; }
        

        public Song(string title, int duration, Artist performer, Genre g, int year)
        {
            Title = title;
            Duration = duration;
            Performer = performer;
            G = g;
            Year = year;
            IsLiked = false;
        }

        public override string ToString()
        {
            return $"SONG: {Title}, performed by {Performer.Name}, duration: {Duration}";
        }

        public void Play()
        {
            //wait for a second --> while playing the song, we won't be able to do anything at all
            Console.WriteLine($"NOW PLAYING: {Title}, by {Performer.Name}");
            for (int i = 0; i < Duration/1000; i++)
            {
                Console.Write(".");
                Console.Beep();
                Thread.Sleep(1000);
            }
            Console.WriteLine($"FINISHED PLAYING: {Title}, by {Performer.Name}");            
        }

        public void Liked()
        {
            IsLiked = true;
        }

    }
}