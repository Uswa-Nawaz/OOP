using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" <<< Music Streaming Service >>> ");

            // Create the Playlist
            Console.Write("Enter Playlist Name: ");
            string pName = Console.ReadLine();

            Playlist myPlaylist = new Playlist(pName);

            // add multiple songs
            bool adding = true;
            while (adding)
            {
                Console.WriteLine("<<< Adding a new song: ");
                Console.Write("Enter Song Title: ");
                string sTitle = Console.ReadLine();
                Console.Write("Enter Artist Name: ");
                string sArtist = Console.ReadLine();

                // Create song object and add to playlist
                Song newSong = new Song(sTitle, sArtist);
                myPlaylist.AddSong(newSong);

                Console.Write("Add another song? (y/n): ");
                string choice = Console.ReadLine().ToLower();
                if (choice != "y")
                {
                    adding = false;
                }
            }

            //Display 
            myPlaylist.DisplayPlaylist();

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
