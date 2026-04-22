using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_02
{
    internal class Playlist
    {
        private string playlistName;
        private List<Song> songs; //association One-to-Many

        // Constructor
        public Playlist(string name)
        {
            setPlaylistName(name);
            this.songs = new List<Song>(); // Initialize the list
        }

        public string getPlaylistName()
        {
            return playlistName;
        }
        public void setPlaylistName(string name)
        {
            this.playlistName = name;
        }

        // Method to add a song to the list
        public void AddSong(Song song)
        {
                songs.Add(song);
        }

        //method to display playlist
        public void DisplayPlaylist()
        {
            Console.WriteLine($"Playlist: {playlistName}");
            if (songs.Count == 0)
            {
                Console.WriteLine("Empty Playlist.");
            }
            else
            {
                foreach (Song s in songs)
                {
                    s.DisplaySong();
                }
            }
            Console.WriteLine("--------------------------");
        }
    }
}
