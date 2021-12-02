using CarDB.Client;
using System;
using System.Collections.Generic;
using VUY9FY_HFT_2021221.Models;

namespace VUY9FY_HFT_2021221
{
    public class Program
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.Sleep(8000);

            RestService rest = new RestService("http://localhost:13442");

            bool fut = true;
            while (fut)
            {
                Console.WriteLine();
                Console.WriteLine("Press F to quit");
                Console.WriteLine("-----------------------------------");
                Console.WriteLine("Songs table   - S");                Console.WriteLine("Artists talbe - A");
                Console.WriteLine("Lists table   - L");
                Console.WriteLine("-----------------------------------");
                Console.WriteLine("Non-crud:         (use the numbers to select one)");
                Console.WriteLine("1. Was song nominated in the specific year?");
                Console.WriteLine("2. Was song nominated in the year it was released?");
                Console.WriteLine("3. Every song that were rated 5");
                Console.WriteLine("4. Every song that was made by a band");
                Console.WriteLine("5. Number of songs that were made by a band");
                Console.WriteLine("6. Score average ");
                Console.WriteLine("-----------------------------------");
                string input = Console.ReadLine();
                Console.WriteLine();
                if (input == "f" || input == "F")
                {
                    fut = false;
                }
                else if (input == "s" || input == "S")
                {
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("Song Cruds:      (use the numbers to select one)");
                    Console.WriteLine("1. Get one by ID");
                    Console.WriteLine("2. Get all");
                    Console.WriteLine("3. Update one");
                    Console.WriteLine("4. Create one");
                    Console.WriteLine("5. Delete one");
                    Console.WriteLine("-----------------------------------");
                    string input2 = Console.ReadLine();
                    if (input2 == "1")
                    {
                        Console.WriteLine("Enter an ID!");
                        int id = int.Parse(Console.ReadLine());
                        song song = rest.GetSingle<song>("song/" + id); //aláhúzza a sima getet
                        Console.WriteLine($"Artist ID: {song.ArtistId} Title: {song.Title} Release: {song.Release}");
                        Console.WriteLine();
                        Console.WriteLine("Press enter to proceed");
                        Console.ReadKey();
                    }
                    else if (input2 == "2")
                    {
                        List<song> list = rest.Get<song>("song");
                        foreach (song song in list)
                        {
                            Console.WriteLine($"Artist ID: {song.ArtistId} Title: {song.Title} Release: {song.Release}");
                        }
                        Console.WriteLine();
                        Console.WriteLine("Press enter to proceed");
                        Console.ReadKey();
                    }
                    else if (input2 == "3")
                    {
                        Console.WriteLine("Enter an ID!");
                        int id = int.Parse(Console.ReadLine());
                        song song = rest.GetSingle<song>("song/" + id);

                        Console.WriteLine("Enter a new title");
                        string title = Console.ReadLine();
                        Console.WriteLine("Enter a new release");
                        int year = int.Parse(Console.ReadLine());
                        song.Release = year;
                        song.Title = title;
                        rest.Put<song>(song, "/song");
                        Console.WriteLine("Success");
                        Console.WriteLine();
                        Console.WriteLine("Press enter to proceed");
                        Console.ReadKey();
                    }
                    else if (input2 == "4")
                    {
                        Console.WriteLine("Enter an ID!");
                        int id = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter a new title");
                        string title = Console.ReadLine();
                        Console.WriteLine("Enter a new release");
                        int year = int.Parse(Console.ReadLine());
                        song song = new song() { SongId = id, Title = title, Release = year };
                        rest.Post<song>(song, "song");
                        Console.WriteLine("Success");
                        Console.WriteLine();
                        Console.WriteLine("Press enter to proceed");
                        Console.ReadKey();
                    }
                    else if(input2 == "5")
                    {
                        Console.WriteLine("Enter an ID!");
                        int id = int.Parse(Console.ReadLine());
                        rest.Delete(id,"song");
                        Console.WriteLine("Success");
                        Console.WriteLine();
                        Console.WriteLine("Press enter to proceed");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Wrong input.");
                        Console.WriteLine();
                        Console.WriteLine("Press enter to proceed");
                        Console.ReadKey();
                    }

                }
                else if (input == "a" || input == "A")
                {
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("Song Cruds:      (use the numbers to select one)");
                    Console.WriteLine("1. Get one by ID");
                    Console.WriteLine("2. Get all");
                    Console.WriteLine("3. Update one");
                    Console.WriteLine("4. Create one");
                    Console.WriteLine("5. Delete one");
                    Console.WriteLine("-----------------------------------");
                    string input2 = Console.ReadLine();
                    if (input2 == "1")
                    {
                        Console.WriteLine("Enter an ID!");
                        int id = int.Parse(Console.ReadLine());
                        artist artist = rest.GetSingle<artist>("artist/" + id); //aláhúzza a sima getet
                        Console.WriteLine($"Artist ID: {artist.Id} Name: {artist.Name} " + (artist.IsBand ? "It is a band" : "It is not a band"));
                        Console.WriteLine();
                        Console.WriteLine("Press enter to proceed");
                        Console.ReadKey();
                    }
                    else if (input2 == "2")
                    {
                        List<artist> list = rest.Get<artist>("artist");
                        foreach (artist artist in list)
                        {
                            Console.WriteLine($"Artist ID: {artist.Id} Name: {artist.Name} " + (artist.IsBand ? "It is a band" : "It is not a band"));
                        }
                        Console.WriteLine();
                        Console.WriteLine("Press enter to proceed");
                        Console.ReadKey();
                    }
                    else if (input2 == "3")
                    {
                        Console.WriteLine("Enter an ID!");
                        int id = int.Parse(Console.ReadLine());
                        artist artist = rest.GetSingle<artist>("artist/" + id);

                        Console.WriteLine("Enter a new name");
                        string name = Console.ReadLine();
                        Console.WriteLine("Is it a band? (y/n)");
                        string yon = Console.ReadLine();
                        bool yn = true;
                        if (yon == "y" || yon == "yes" || yon == "Yes")
                        {
                            yn = true;
                        }
                        else if (yon == "n" || yon == "no" || yon == "No")
                        {
                            yn = false;
                        }
                        artist.Name = name;
                        artist.IsBand = yn;
                        rest.Put<artist>(artist, "/artist");
                        Console.WriteLine("Success");
                        Console.WriteLine();
                        Console.WriteLine("Press enter to proceed");
                        Console.ReadKey();
                    }
                    else if (input2 == "4")
                    {
                        Console.WriteLine("Enter an ID!");
                        int id = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter a new name");
                        string name = Console.ReadLine();
                        Console.WriteLine("Is it a band? (y/n)");
                        string yon = Console.ReadLine();
                        bool yn = true;
                        if (yon == "y" || yon == "yes" || yon == "Yes")
                        {
                            yn = true;
                        }
                        else if (yon == "n" || yon == "no" || yon == "No")
                        {
                            yn = false;
                        }
                        artist artist = new artist() { Id = id, Name = name, IsBand = yn };
                        rest.Post<artist>(artist, "/artist");
                        Console.WriteLine("Success");
                        Console.WriteLine();
                        Console.WriteLine("Press enter to proceed");
                        Console.ReadKey();
                    }
                    else if (input2 == "5")
                    {
                        Console.WriteLine("Enter an ID!");
                        int id = int.Parse(Console.ReadLine());
                        rest.Delete(id, "/artist");
                        Console.WriteLine("Success");
                        Console.WriteLine();
                        Console.WriteLine("Press enter to proceed");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Wrong input.");
                        Console.WriteLine();
                        Console.WriteLine("Press enter to proceed");
                        Console.ReadKey();
                    }
                }
                else if (input == "l" || input == "L")
                {
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("Song Cruds:      (use the numbers to select one)");
                    Console.WriteLine("1. Get one by ID");
                    Console.WriteLine("2. Get all");
                    Console.WriteLine("3. Create one");
                    Console.WriteLine("4. Delete one");
                    Console.WriteLine("-----------------------------------");
                    string input2 = Console.ReadLine();
                    if (input2 == "1")
                    {
                        Console.WriteLine("Enter a score!");
                        string id = Console.ReadLine();
                        Console.WriteLine("Enter a year!");
                        string year = Console.ReadLine();
                        list list = rest.GetSingle<list>("artist/" + id + year); //aláhúzza a sima getet
                        Console.WriteLine($"Song ID: {list.SongId} Title: {list.Song.Title} Release: {list.Song.Release}");
                        Console.WriteLine();
                        Console.WriteLine("Press enter to proceed");
                        Console.ReadKey();
                    }
                    else if (input2 == "2")
                    {
                        List<list> list = rest.Get<list>("list");
                        foreach (list alist in list)
                        {
                            Console.WriteLine($"Song ID: {alist.SongId} Title: {alist.Song.Title} Release: {alist.Song.Release}");
                        }
                        Console.WriteLine();
                        Console.WriteLine("Press enter to proceed");
                        Console.ReadKey();
                    }
                    else if (input2 == "3")
                    {
                        Console.WriteLine("Enter a score!");
                        string score = Console.ReadLine();
                        Console.WriteLine("Enter a year!");
                        string year = Console.ReadLine();
                        Console.WriteLine("Enter a song ID!");
                        string id = Console.ReadLine();
                        list list = new list() { Score = int.Parse(score), Year = int.Parse(year), SongId = int.Parse(id) };
                        rest.Post<list>(list, "/artist");
                        Console.WriteLine("Success");
                        Console.WriteLine();
                        Console.WriteLine("Press enter to proceed");
                        Console.ReadKey();
                    }
                    else if (input2 == "4")
                    {
                        Console.WriteLine("Enter a score!");
                        string score = Console.ReadLine();
                        Console.WriteLine("Enter a year!");
                        string year = Console.ReadLine();
                        string id = score + year;
                        rest.Delete(int.Parse(id), "/artist");
                        Console.WriteLine("Success");
                        Console.WriteLine();
                        Console.WriteLine("Press enter to proceed");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Wrong input.");
                        Console.WriteLine();
                        Console.WriteLine("Press enter to proceed");
                        Console.ReadKey();
                    }
                }
                else if (input == "2")
                {
                    Console.WriteLine("Enter a song title: ");
                    string title = Console.ReadLine();
                    bool tof = rest.GetSingle<bool>("query/WasSongNominatedInSameYear/" + title);
                    if (tof)
                    {
                        Console.WriteLine("Yes.");
                    }
                    else
                    {
                        Console.WriteLine("No.");
                    }
                    Console.WriteLine();
                    Console.WriteLine("Press enter to proceed");
                    Console.ReadKey();
                }
                else if (input == "1")
                {
                    Console.WriteLine("Enter a song title: ");
                    string title = Console.ReadLine();
                    Console.WriteLine("Enter a  year: ");
                    int year = int.Parse(Console.ReadLine());
                    bool tof = rest.GetSingle<bool>("query/WasSongsNominatedInYear/" + title + ", " + year);
                    if (tof)
                    {
                        Console.WriteLine("Yes.");
                    }
                    else
                    {
                        Console.WriteLine("No.");
                    }
                    Console.WriteLine();
                    Console.WriteLine("Press enter to proceed");
                    Console.ReadKey();
                }
                else if (input == "3")
                {
                    List<string> list = rest.GetSingle<List<string>>("query/SongsScored5");
                    foreach (string title in list)
                    {
                        Console.WriteLine(title);
                    }
                    Console.WriteLine();
                    Console.WriteLine("Press enter to proceed");
                    Console.ReadKey();

                }
                else if (input == "4")
                {
                    List<string> list = rest.GetSingle<List<string>>("query/SongsByBands");
                    foreach (string title in list)
                    {
                        Console.WriteLine(title);
                    }
                    Console.WriteLine();
                    Console.WriteLine("Press enter to proceed");
                    Console.ReadKey();
                }
                else if (input == "5") 
                {
                    int num = rest.GetSingle<int>("query/SongsByBandsCount");
                    Console.WriteLine("Number of songs by bands: "+ num);
                    Console.WriteLine();
                    Console.WriteLine("Press enter to proceed");
                    Console.ReadKey();
                }
                else if (input == "6")
                {
                    double num = rest.GetSingle<double>("query/SongScoreAvg");
                    Console.WriteLine("Score average: " + num);
                    Console.WriteLine();
                    Console.WriteLine("Press enter to proceed");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Wrong input.");
                    Console.WriteLine();
                    Console.WriteLine("Press enter to proceed");
                    Console.ReadKey();
                }
            }
        }
    }
}
