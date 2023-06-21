using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksInTheLibrary
{
    internal class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public int Year { get; set; }
        public int CatalogNumber { get; set; }

        public Book(string title, string author, string publisher, int year, int catalogNumber)
        {
            this.Title = title;
            this.Author = author;
            this.Publisher = publisher;
            this.Year = year;
            this.CatalogNumber = catalogNumber;
        }
    }
}
