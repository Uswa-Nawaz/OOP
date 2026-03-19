using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace self_assessment_task_02
{
    internal class Book
    {
        public string title;
        public List<string> chapters;
        //= new List<string>();
        public int pages;
        public int price;
        public string author;
        public bool isavailable;
        public int bookMark;

        //parameterized constructo to set the values
        public Book(string title,List<string> chapters, int pages, int prices, string author, bool isavailable, int bookMark)
        {
            this.title= title;
            this.chapters = chapters;
            this.pages = pages;
            this.price = prices;
            this.author = author;
            this.isavailable = isavailable;
            this.bookMark = bookMark;
        }
        //method to check if book is available
        public bool isBookAvailable()
        {
            return isavailable;
        }
        //method to get the chapter name
        public string getChapter(int chapterNumber)
        {
            int index=chapterNumber-1;
            if (index >= 0 && index < chapters.Count)
            {

                return chapters[index];
            }
            else
            {
                return "Chapter not found ! ";
            }
        }
        //method for bookmark
        public int getBookMark()
        {
            Console.WriteLine("Bookmark set at page: " + bookMark);
            return bookMark;
        }
        //method to display info
        public void displayBookInfo()
        {
            Console.WriteLine($"\n--- {title} ---");
            Console.WriteLine($"Author: {author} | Pages: {pages} | Price: {price}");
            Console.WriteLine($"Availability: {isavailable}");
            Console.WriteLine($"Bookmark at page: {bookMark}");
        }
    }
}
