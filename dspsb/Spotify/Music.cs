using System;
using System.Runtime.InteropServices;

namespace Spotify
{   
    public class Playlist
    {
        public string Name { get; set; }
        public List<Song> Songs { get; set; }
        public int Duration { get; set; }

        public Playlist(string name) //the we go to a roadtrip to south France with my new partner playlist
        {
            Name = name;
            Duration = 0;
            Songs = new List<Song>();
        }

        public Playlist(string name, List<Song> songs)
        {
            Name = name;
            Songs = songs;
            Duration = 0;
            foreach (var song in songs)
            {
                Duration += song.Duration;
            }
        }

        public void Play()
        {
            foreach (var song in Songs)
            {
                song.Play();
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

        public override string ToString()
        {
            string s = $"{Name} - Length: {Duration}\n";
            foreach (var song in Songs)
            {
                s += $"- {song}\n";
            }

            return s;
        }

        public void Shuffle()
        {
            Random r = new Random();
            for (int i = Songs.Count-1; i >= 0; i--)
            {
                int nr = r.Next(0, i+1);
                Song temp = Songs[nr];
                Songs[nr] = Songs[i];
                Songs[i] = temp;
            }
        }

        public void Sort()
        {
            Songs.Sort();// --> crashes --> too difficult to Sort complex objects
        }

    }


    public class Album
    {
        public string Name { get; set; }
        public List<Song> Songs { get; set; }
        public int Amount { get; private set; }
        public DateOnly ReleaseDate { get; set; }
        public int Duration { get; private set; }
        public Artist Artist { get; set; }

        public Album(string name, DateOnly releasedate, Artist artist)
        {
            Name = name; Songs = new List<Song>();
            Amount = 0; ReleaseDate = releasedate; Artist = artist;
            Duration = 0;
        }

        public void Play()
        {
            Console.WriteLine($"Playing ALBUM: {Name} by {Artist.Name}\n");
            foreach (Song songo in Songs)
            {
                songo.Play();
            }
            Console.WriteLine("\nEnd of Album\n");
        }

        public void AddSong(Song song)
        {
            Songs.Add(song);
            Duration += song.Duration;
            Amount++;
        }
        public void RemoveSong(Song song)
        {
            Songs.Remove(song);
            Duration -= song.Duration;
            Amount--;
        }

        public override string ToString()
        {
            string s = $"ALBUM {Name}, by {Artist.Name}\n";
            foreach (var item in Songs)
            {
                s += $"\t {item}\n";
            }
            return s;
        }
    }



    public enum Genre
    {
        Latin, Rock, Pop, Metal, Reggae, DnB, Dubstep, HipHop, RnB, Electronic,
        Techno, House, Trance, Folk, Soul, Classical, Childrens, Funk, World,
        Alternative, Jazz, Country, Blues, Rap, Punk, Indie, Ska, Swing, Disco, BlackMetal,
        DeathMetal, Altrock, DroneRock, Underground, Ambience
    }

    public class Song: IComparable
    {
        public string Name { get; set; }
        public Artist Owner { get; set; }
        public bool HasLyrics { get; private set; }
        public int Duration { get; set; }
        public Genre G { get; set; }
        public bool Like { get; set; }

        public Song(string name, Artist owner, int duration, Genre g)
        {
            Name = name;
            Owner = owner;
            HasLyrics = true;
            Duration = duration;
            G = g;
            Like = false;
            Owner.Songs.Add(this);
        }

        public void Play()
        {
            //we will be playing the starting title, followed by x seconds of nothing
            //pc cannot do anything while Thread.Sleep()

            Console.WriteLine($"NOW PLAYING: {Name} by {Owner.Name}");
            for (int i = 0; i < Duration; i++)
            {
                Console.Write(".");
                Thread.Sleep(1000);
            }
            Console.WriteLine($"\nFinished playing: {Name}\n");
        }

        public override string ToString()
        {
            return $"SONG: {Name}, by {Owner.Name} - Genre: {G}, {Duration}s";
        }

        public void Liked()
        {
            Like = true;
        }

        public void RemoveLike()
        {
            Like = false;
        }

        public int CompareTo(object? obj)
        {
            if (obj is Song)
            {
                Song othersong = (Song) obj;
                return this.Name.CompareTo(othersong.Name);
            }
            return 0;

            /*underneath here, I will show the working
            if (this.Name > song.Name){
                return -1;
            }
            else if (this.Name == song.Name)
            {
                return 0;
            }
            else
            {
                return 1;
            }*/

        }
    }
}