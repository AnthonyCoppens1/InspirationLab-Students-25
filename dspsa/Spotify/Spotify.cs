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

        public void AddSong(Song song)
        {
            Songs.Add(song);
            Duration += song.Duration;
        }

        public void RemoveSong(Song song)
        {
            Songs.Remove(song);
            Duration -= song.Duration;
        }

        public void Play()
        {
            foreach (var song in Songs)
            {
                song.Play();
            }
        }

        public override string ToString()
        {
            string s = $"{Name} - Length: {Duration}\n";
            foreach (Song song in Songs)
            {
                s += $"- {song}\n";
            }
            return s;
        }

        public void Shuffle()
        {
            Random rd = new Random();
            for (int i = Songs.Count-1; i >= 0; i--)
            {
                int nr = rd.Next(0, i+1);
                Song temp = Songs[nr];
                Songs[nr] = Songs[i]; //count - 1 aka current last position
                Songs[i] = temp;
            }
        }

        public void Sort()
        {
            Songs.Sort();
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

    public class Song : IComparable
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

        public int CompareTo(object? obj)
        {
            
            return this.Title.CompareTo(((Song)obj).Title);
            
            /* inner working of the CompareTo
            if (this.Title < song.Title){
                return -1;
            }
            else if (this.Title == song.Title){
                return 0;
            }
            else
            {
                return 1;
            }*/

            /*if (obj is Song)
            {
                Song otherSong = (Song)obj;
                return this.Title.CompareTo(otherSong.Title);
            }
            return 0;*/
        }

    }
}