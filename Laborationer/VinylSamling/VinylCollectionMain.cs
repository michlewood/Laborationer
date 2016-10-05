﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VinylCollection
{
    class VinylCollectionMain
    {
        List<Vinyl> vinylCollection = new List<Vinyl>();

        VinylCollectionMain()
        {
            getCollection();
            Menu();
        }

        private void Menu() 
        {
            Console.Clear();
            while (true)
            {

                int choice = 0;
                bool validChoice = false;
    
                    Console.WriteLine("1. See collection");
                    Console.WriteLine("2. edit collection");
                    Console.WriteLine("3. add vinyl to collection");
                    Console.WriteLine("4. remove vinyl from collection");
                    validChoice = int.TryParse(Console.ReadLine(), out choice);
                    Console.Clear();
            
                switch (choice)
                {
                    case 1:
                        ShowCollection();
                        break;
                    case 2:
                        EditAlbum();
                        break;
                    case 3:
                        AddAlbum();
                        break;
                    case 4:
                        RemoveAlbum();
                        break;
                        
                    default:
                        Console.Clear();
                        Console.WriteLine("Enter a valid choice");
                        break;
                }
            }
        }

        private void ShowCollection()
        {
            ListVinyls();
            Console.ReadLine();
            Console.Clear();
        }

        private void EditAlbum()
        {
            ListVinyls();
            Console.Write("Enter the number of the album to edit: ");
            int indexToEdit = FindIndex();
            if(indexToEdit != -1)
            { 
                vinylCollection[indexToEdit].Edit(); ;
                UpdateFile();
                Console.WriteLine("Album edited");
            }
            else Console.WriteLine("No file has been edited");

            Console.ReadLine();
            Console.Clear();
        }    

        private void AddAlbum()
        {
            Console.Clear();
            Console.Write("Please enter name of album: ");
            string albumName = Console.ReadLine();

            Console.Write("Please enter name of artist: ");
            string artistName = Console.ReadLine();

            Console.Write("Please enter the year of release: ");
            int releaseYear = 0;
            bool isNumber = false;
            while (!isNumber)
            {
                string input = Console.ReadLine();
                isNumber = int.TryParse(input, out releaseYear);
                if (!isNumber) Console.WriteLine("Please enter a number");
            }

            vinylCollection.Add(new Vinyl(albumName, artistName, releaseYear));

            UpdateFile();

            Console.WriteLine("Album added.");
            Console.ReadLine();
            Console.Clear();

        }

        private void RemoveAlbum()
        {
            ListVinyls();
            Console.Write("Enter the number of the album to remove: ");
            int indexToRemove = FindIndex();
            if (indexToRemove != -1)
            {
                vinylCollection.RemoveAt(indexToRemove);
                UpdateFile();
                Console.WriteLine("Album removed");
            }
            else Console.WriteLine("No file has been removed");

            Console.ReadLine();
            Console.Clear();
        }

        private void ListVinyls()
        {
            Console.Clear();
            for (int i = 0; i < vinylCollection.Count; i++)
            {
               
                Console.Write(i + 1 + ". ");
                vinylCollection[i].Print();
            }

            
        }

        private int FindIndex()
        {
            bool validChoice = true;
            int indexToUse = 0;

            do
            {
                if (!validChoice) Console.WriteLine("Please enter a number");
                validChoice = int.TryParse(Console.ReadLine(), out indexToUse);
            } while (!validChoice);

            if (indexToUse <= vinylCollection.Count && indexToUse > 0) return --indexToUse;
            else return -1;
        }

        private void UpdateFile()
        {
            string[] toFile = new string[vinylCollection.Count*3];
            for (int i = 0; i < vinylCollection.Count; i++)
            {
                toFile[i*3] = vinylCollection[i].NameOfAlbum;
                toFile[i * 3 + 1] = vinylCollection[i].NameOfArtist;
                toFile[i * 3 + 2] = "" + vinylCollection[i].ReleaseYear;
            }

            File.WriteAllLines(FindFileLocation(), toFile);
        }

        private void getCollection()
        {
            string[] fromFile;

            try
            {
                fromFile = File.ReadAllLines(FindFileLocation());
            }
            catch (FileNotFoundException)
            {
                File.WriteAllText(FindFileLocation(), "");
                fromFile = File.ReadAllLines(FindFileLocation());
            }
            
            for (int i = 0; i < fromFile.Length; i += 3)
            {
                vinylCollection.Add(new Vinyl(fromFile[i], fromFile[i + 1], int.Parse(fromFile[i + 2])));
            }
        }

        private string FindFileLocation()
        {
            string filePath = Environment.CurrentDirectory;
            filePath = filePath.Remove(filePath.Length - 9, 9) + @"vinylCollection.txt";
            return filePath;
        }

        static void Main(string[] args)
        {
            new VinylCollectionMain();
        }
    }
}
