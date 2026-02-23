using System;

namespace Spotify
{
    public class Artist
    {
        public string Name { get; set; }
        public List<Song> Songs { get; set; }
        public List<Album> Albums { get; set; }
        public int AlbumCount { get; private set; }

        public Artist(string name)
        {
            Name = name;
            Songs = new List<Song>();
            Albums = new List<Album>();
            AlbumCount = 0;
        }

        public Artist(string name, List<Song> songs, List<Album> albums)
        {
            Name = name;
            Songs = songs;
            Albums = albums;
            AlbumCount = albums.Count;
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

        public override string ToString()
        {
            return $"Artist {Name} currently has {AlbumCount} albums.\n Look up the songs, if you want to know more.";
        }

    }
}