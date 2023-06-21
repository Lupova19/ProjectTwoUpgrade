using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksInTheLibrary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Book> books = new List<Book>();
            int command = 0;

            while (command != 11)
            {
                Console.WriteLine("1 - Добави книга");
                Console.WriteLine("2 - Извади цялата информация за книгите");
                Console.WriteLine("3 - Търсене на книга по заглавие");
                Console.WriteLine("4 - Търсене на книга по автор");
                Console.WriteLine("5 - Актуализиране на книга");
                Console.WriteLine("6 - Изтриване на книга");
                Console.WriteLine("7 - Изчисляване на средната година на книгите");
                Console.WriteLine("8 - Извеждане на най-старата книга");
                Console.WriteLine("9 - Извеждане на най-новата книга от автор");
                Console.WriteLine("10 - Сортиране на книгите по автор и номер в каталога");
                Console.WriteLine("11 - Изход от програмата");
                Console.Write("Въведи команда: ");
                command = int.Parse(Console.ReadLine());
                Console.WriteLine();

                switch (command)
                {

                    case 1:
                        Console.Write("Въведи заглавие: ");
                        string title = Console.ReadLine();
                        Console.Write("Въведи автор: ");
                        string author = Console.ReadLine();
                        Console.Write("Въведи издател: ");
                        string publisher = Console.ReadLine();
                        Console.Write("Въведи година: ");
                        int year = int.Parse(Console.ReadLine());
                        Console.Write("Въведи номер в каталога: ");
                        int catalogNumber = int.Parse(Console.ReadLine());
                        books.Add(new Book(title, author, publisher, year, catalogNumber));
                        Console.WriteLine();
                        break;

                    case 2:
                        DisplayBooks(books);
                        break;

                    case 3:
                        Console.Write("Въведи заглавие: ");
                        string searchTitle = Console.ReadLine();
                        SearchByTitle(books, searchTitle);
                        Console.WriteLine();
                        break;

                    case 4:
                        Console.Write("Въведи автор: ");
                        string searchAuthor = Console.ReadLine();
                        SearchByAuthor(books, searchAuthor);
                        Console.WriteLine();
                        break;

                    case 5:
                        Console.Write("Въведи заглавие на книгата за да се актуализира: ");
                        string updateTitle = Console.ReadLine();
                        UpdateInformationAboutBook(books, updateTitle);
                        Console.WriteLine();
                        break;

                    case 6:
                        Console.Write("Въведи заглавие на книгата за да се изтрие: ");
                        string deleteTitle = Console.ReadLine();
                        DeleteBook(books, deleteTitle);
                        break;

                    case 7:
                        double averageYear = AverageYear(books);
                        Console.WriteLine($"Средна година на книгите: {averageYear}");
                        Console.WriteLine();
                        break;

                    case 8:
                        Book oldestBook = OldestBook(books);
                        if (oldestBook != null)
                        {
                            Console.WriteLine($"Най-стара книга: {oldestBook.Title}");
                        }
                        else
                        {
                            Console.WriteLine("Няма въведени книги в библиотеката!");
                        }
                        Console.WriteLine();
                        break;

                    case 9:
                        Console.Write("Въведи автор за да се изведе най-новата книга: ");
                        string authorNewestBook = Console.ReadLine();
                        Book newestBook = NewestBookByAuthor(books, authorNewestBook);
                        if (newestBook != null)
                        {
                            Console.WriteLine($"Най-новата книга от {authorNewestBook} е {newestBook.Title}");
                        }
                        else
                        {
                            Console.WriteLine($"Няма въведени книги от {authorNewestBook} в библиотеката!");
                        }
                        Console.WriteLine();
                        break;

                    case 10:
                        SortByAuthorAndCatalogNumber(books);
                        Console.WriteLine("Сортираните книги по автор и номер в каталога:");
                        DisplayBooks(books);
                        break;
                    case 11:
                        Console.WriteLine("Изход от програмата.");
                        break;

                }

            }
        }
        public static void DisplayBooks(List<Book> books)
        {
            foreach (Book item in books)
            {
                Console.WriteLine($"Заглавие:{item.Title} | Автор:{item.Author} | Издател:{item.Publisher} | Година:{item.Year} | Номер в каталога:{item.CatalogNumber}");
            }
        }
        public static void SearchByTitle(List<Book> books, string title)
        {
            foreach (Book item in books)
            {
                if (item.Title == title)
                {
                    Console.WriteLine($"Заглавие: {item.Title}");
                    Console.WriteLine($"Автор: {item.Author}");
                    Console.WriteLine($"Издател: {item.Publisher}");
                    Console.WriteLine($"Година: {item.Year}");
                    Console.WriteLine($"Номер в каталога: {item.CatalogNumber}");
                    Console.WriteLine();
                    return;
                }
            }
            Console.WriteLine("Няма въведени книги с това заглавие!");
        }
        public static void SearchByAuthor(List<Book> books, string author)
        {
            foreach (Book item in books)
            {
                if (item.Author == author)
                {
                    Console.WriteLine($"Заглавие: {item.Title}");
                    Console.WriteLine($"Автор: {item.Author}");
                    Console.WriteLine($"Издател: {item.Publisher}");
                    Console.WriteLine($"Година: {item.Year}");
                    Console.WriteLine($"Номер в каталога: {item.CatalogNumber}");
                    Console.WriteLine();
                }
            }
        }
        public static void UpdateInformationAboutBook(List<Book> books, string title)
        {
            foreach (Book item in books)
            {
                if (item.Title == title)
                {
                    Console.Write("Въведи ново заглавие: ");
                    item.Title = Console.ReadLine();
                    Console.Write("Въведи нов автор: ");
                    item.Author = Console.ReadLine();
                    Console.Write("Въведи нов издател: ");
                    item.Publisher = Console.ReadLine();
                    Console.Write("Въведи нова година: ");
                    item.Year = int.Parse(Console.ReadLine());
                    Console.Write("Въведи нов номер в каталога: ");
                    item.CatalogNumber = int.Parse(Console.ReadLine());
                    Console.WriteLine("Книгата е актуализирана успешно!");
                    return;
                }
            }
            Console.WriteLine("Няма въведени книги с това заглавие!");
        }
        public static void DeleteBook(List<Book> books, string title)
        {
            int countOfBook = books.Count;
            books.RemoveAll(book => book.Title == title);

            if (books.Count < countOfBook)
            {
                Console.WriteLine("Книгата е изтрита успешно!");
            }
            else
            {
                Console.WriteLine("Няма въведени книги с това заглавие!");
            }
        }

        public static double AverageYear(List<Book> books)
        {
            if (books.Count == 0)
            {
                return 0;
            }

            double averageYear = books.Average(book => book.Year);
            return averageYear;
        }
        public static Book OldestBook(List<Book> books)
        {
            if (books.Count == 0)
            {
                return null;
            }

            Book oldestBook = books.OrderBy(book => book.Year).First();
            return oldestBook;
        }
        public static Book NewestBookByAuthor(List<Book> books, string author)
        {
            Book newestBook = books.Where(book => book.Author == author)
                                   .OrderByDescending(book => book.Year)
                                   .FirstOrDefault();
            return newestBook;
        }
        public static void SortByAuthorAndCatalogNumber(List<Book> books)
        {
            books = books.OrderBy(book => book.Author)
                         .ThenBy(book => book.CatalogNumber)
                         .ToList();
        }
    }
}

