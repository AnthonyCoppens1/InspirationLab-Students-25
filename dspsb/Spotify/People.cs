using System;

namespace Spotify
{
    public class Artist
    {
        public string Name { get; set; }
        public List<Album> Albums { get; set; }
        public List<Song> Songs { get; set; }
        public List<Genre> Genres { get; set; }
        public int AlbumCount { get; private set; }

        public Artist(string name, List<Genre> genres)
        {
            Name = name;
            Albums = new List<Album>();
            Songs = new List<Song>();
            Genres = genres;
            AlbumCount = 0;
        }

        public void AddAlbum(Album album)
        {
            Albums.Add(album);
            AlbumCount++;
        }
        public void RemoveAlbum(Album album)
        {
            Albums.Remove(album);
            AlbumCount--;
        }

        public void RemoveSong(Song song)
        {
            Songs.Remove(song);
        }

        public override string ToString()
        {
            string s =  $"{Name} - Genre(s):";
            foreach (Genre g in Genres)
            {
                s += $"{g} ";
            }
            return s;
        }

    }
}