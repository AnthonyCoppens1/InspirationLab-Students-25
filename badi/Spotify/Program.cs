using System;
using System.Text.Encodings.Web;

namespace Spotify
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Zanger Drake = new Zanger("Drake",new List<Genre>{Genre.Rap, Genre.Pop});
            Zanger KendrickLamar = new Zanger("Kendrick Lamar",new List<Genre>{Genre.Rap, Genre.Pop});
            Zanger DonToliver = new Zanger("Don Toliver", new List<Genre>{Genre.Pop});
            Zanger Beyonce = new Zanger("Beyonce", new List<Genre>{Genre.RnB, Genre.Afrobeats, Genre.Country});
            Zanger RoxyDekker = new Zanger("Roxy Dekker", new List<Genre>{Genre.Pop});

            Song Hotlinebling = new Song("Hotline bling", 5, Drake, Genre.Rap);
            Song Toutsislide = new Song("Toutsislide", 3, Drake, Genre.Pop);
            Song GodsPlan = new Song("God's plan", 4, Drake, Genre.Rap);

            Song SwimmingPools = new Song("Swimming Pools", 3, KendrickLamar, Genre.Rap);
            Song Humble = new Song("Humble", 2, KendrickLamar, Genre.Pop);
            Song DNA = new Song("DNA", 5, KendrickLamar, Genre.Rap);

            Song NoPole = new Song("No Pole", 4, DonToliver, Genre.Pop);
            Song Tiramisu = new Song("Tiramisu", 2, DonToliver, Genre.Pop);

            Song CrazyInLove = new Song("Crazy in love", 4, Beyonce, Genre.RnB);
            Song DrunkInLove = new Song("Drunk in love", 2, Beyonce, Genre.RnB);
            Song TexasHoldem = new Song("Texas Holdem", 5, Beyonce, Genre.Country);

            Song SugarDaddy = new Song("Sugar daddy", 2, RoxyDekker, Genre.Pop);
            Song HoeHetIs = new Song("Hoe het is", 3, RoxyDekker, Genre.Pop);

            List<Song> beyoncehits = new List<Song>{CrazyInLove, DrunkInLove, TexasHoldem};
            Album Inlove = new Album("In love", Beyonce, beyoncehits);

            List<Song> songs = new List<Song>();
            songs.Add(Hotlinebling);songs.Add(Toutsislide);songs.Add(GodsPlan);songs.Add(SwimmingPools);
            songs.Add(Humble);songs.Add(DNA);songs.Add(NoPole);
            songs.Add(Tiramisu);songs.Add(CrazyInLove);songs.Add(DrunkInLove);songs.Add(TexasHoldem);
            songs.Add(SugarDaddy);songs.Add(HoeHetIs);

            /*foreach (var nummer in songs)
            {
                nummer.Play();
            }*/

            Playlist Goated = new Playlist("Goated", songs);
            Goated.Sort();
            Console.WriteLine(Goated);

            Console.WriteLine("-----------------------------------------");
            Goated.Shuffle();
            Goated.Play();
            
        }
    }
}