using System;

namespace VinylCollection
{
    internal class Vinyl
    {
        public string NameOfAlbum { get; set; }
        public string NameOfArtist { get; set; }
        public int ReleaseYear { get; set; }

        public Vinyl(string nameOfAlbum, string nameOfArtist, int releaseYear)
        {
            NameOfAlbum = nameOfAlbum;
            NameOfArtist = nameOfArtist;
            ReleaseYear = releaseYear;
        }

        internal void Print()
        {
            Console.WriteLine("{0} by {1} released in {2}", NameOfAlbum, NameOfArtist, ReleaseYear);
        }

        internal void Edit()
        {
            Console.Clear();
            Console.Write("Editing ");
            Print();
            Console.WriteLine("Enter new name of album (leave blank to remain unchanged)");
            string newNameOfAlbum = Console.ReadLine();
            if (newNameOfAlbum != "") NameOfAlbum = newNameOfAlbum;
            Console.WriteLine("Enter new name of artist on album (leave blank to remain unchanged)");
            string newNameOfArtist = Console.ReadLine();
            if (newNameOfArtist != "") NameOfArtist = newNameOfArtist;
            Console.WriteLine("Enter new release date of album (leave blank to remain unchanged)");
            int newReleaseYear = ReleaseYear;
            bool isNumber = false;
            while (!isNumber)
            {
                string input = Console.ReadLine();
                if (input == "") return;
                isNumber = int.TryParse(input, out newReleaseYear);
                if (!isNumber) Console.WriteLine("Please enter a number");
            }
             
            ReleaseYear = newReleaseYear;

        }
    }
}