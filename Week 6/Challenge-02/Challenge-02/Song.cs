using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_02
{
    internal class Song
    {
        private string title;
        private string artist;

        // Constructor
        public Song(string title, string artist)
        {
            setTitle(title);
            setArtist(artist);
        }

        // Getters
        public string getTitle()
        {
            return title;
        }
        public string getArtist()
        {
            return artist;
        }
        public void setTitle(string title)
        {
            this.title = title;
        }
        public void setArtist(string artist)
        {
            this.artist = artist;
        }

        public void DisplaySong()
        {
            Console.WriteLine($" {title} by {artist}");
        }

    }
}
