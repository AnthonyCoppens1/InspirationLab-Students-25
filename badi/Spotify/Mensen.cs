using System;

namespace Spotify
{
    public class User
    {
        
    }

    public class Zanger
    {
        public string Naam { get; set; }
        public List<Song> Songs { get; set; }
        public List<Album> Albums { get; set; }
        public List<Genre> Genres { get; set; }
        public int AlbumCount { get; private set; }

        public Zanger(string naam, List<Genre> genres)
        {
            Naam = naam;
            Songs = new List<Song>();
            Albums = new List<Album>();
            Genres = genres;
            AlbumCount = 0;
        }

        public void RemoveSong(Song song)
        {
            Songs.Remove(song);
        }

        public void RemoveAlbum(Album album)
        {
            Albums.Remove(album);
        }

        public override string ToString()
        {
            //naam + genres --> daarna alle nummers niet in albums, daarna per album alle nummers
            string s = $"Artiest {Naam} - genres:";
            foreach (var genre in Genres)
            {
                s += $"{genre} ";
            }
            s += $"\n";

            List<Song> NietInAlbum = new List<Song>();

            foreach(var SO in Songs)
            {
                foreach(var AL in Albums)
                {
                    foreach(var LI in AL.Liedjes)
                    {
                        if (LI.Titel != SO.Titel)
                        {
                            NietInAlbum.Add(SO);
                        }
                    }
                }
            }

            foreach(var song in NietInAlbum)
            {
                s += $"- {song}\n";
            }

            foreach(var album in Albums)
            {
                s += $"- {album}\n";

                foreach (var song in album.Liedjes)
                {
                    s += $"\t *{song}\n";
                }
            }

            return s;

        }
    }
}