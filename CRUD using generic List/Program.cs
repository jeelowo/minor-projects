using System;
using System.Collections.Generic;
using System.Linq;

public class Book
{
    public int Id { get; set; }          // Column 1
    public string Title { get; set; }    // Column 2
    public string Author { get; set; }   // Column 3
    public int Year { get; set; }        // Column 4
    public decimal Price { get; set; }   // Column 5
}

class Program
{
    // Pre-populated with 5 initial records
    static List<Book> books = new List<Book>()
    {
        new Book { Id = 1, Title = "C# in Depth", Author = "Jon Skeet", Year = 2019, Price = 49.99m },
        new Book { Id = 2, Title = "Clean Code", Author = "Robert C. Martin", Year = 2008, Price = 37.50m },
        new Book { Id = 3, Title = "The Pragmatic Programmer", Author = "Andrew Hunt", Year = 2019, Price = 45.00m },
        new Book { Id = 4, Title = "Design Patterns", Author = "Erich Gamma", Year = 1994, Price = 55.00m },
        new Book { Id = 5, Title = "Refactoring", Author = "Martin Fowler", Year = 2018, Price = 50.00m }
    };

    static int nextId = 6;

    static void Main(string[] args)
    {
        bool running = true;
        while (running)
        {
            Console.Clear();
            Console.WriteLine("=== LIBRARY BOOK MANAGER ===");
            Console.WriteLine("1. Create (Add Book)");
            Console.WriteLine("2. Read (View All Books)");
            Console.WriteLine("3. Update Book");
            Console.WriteLine("4. Delete Book");
            Console.WriteLine("5. Exit");
            Console.Write("\nSelect an option: ");
            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    CreateBook();
                    break;
                case "2":
                    ReadBooks();
                    break;
                case "3":
                    UpdateBook();
                    break;
                case "4":
                    DeleteBook();
                    break;
                case "5":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }

            if (running) { Console.WriteLine("\nPress Enter to continue..."); Console.ReadLine(); }
        }
    }

    static void CreateBook()
    {
        Console.WriteLine("--- Add New Book ---");
        Console.Write("Enter Title: ");
        string title = Console.ReadLine();
        Console.Write("Enter Author: ");
        string author = Console.ReadLine();
        Console.Write("Enter Publication Year: ");
        int.TryParse(Console.ReadLine(), out int year);
        Console.Write("Enter Price: ");
        decimal.TryParse(Console.ReadLine(), out decimal price);

        books.Add(new Book
        {
            Id = nextId++,
            Title = title,
            Author = author,
            Year = year,
            Price = price
        });

        Console.WriteLine("\nBook added successfully!");
    }

    static void ReadBooks()
    {
        Console.WriteLine("--- Current Library Catalog ---");
        if (books.Count == 0)
        {
            Console.WriteLine("No books found.");
            return;
        }

        Console.WriteLine($"{"ID",-4}{"Title",-28}{"Author",-20}{"Year",-6}{"Price",8}");
        Console.WriteLine(new string('-', 66));
        foreach (var b in books)
        {
            Console.WriteLine($"{b.Id,-4}{b.Title,-28}{b.Author,-20}{b.Year,-6}{b.Price,8:F2}");
        }
    }

    static void UpdateBook()
    {
        ReadBooks();
        Console.Write("\nEnter the ID of the book to update: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            Book book = books.FirstOrDefault(b => b.Id == id);
            if (book != null)
            {
                Console.Write($"Enter new title (current: {book.Title}): ");
                string newTitle = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(newTitle)) book.Title = newTitle;

                Console.Write($"Enter new author (current: {book.Author}): ");
                string newAuthor = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(newAuthor)) book.Author = newAuthor;

                Console.Write($"Enter new year (current: {book.Year}): ");
                if (int.TryParse(Console.ReadLine(), out int newYear))
                    book.Year = newYear;

                Console.Write($"Enter new price (current: {book.Price}): ");
                if (decimal.TryParse(Console.ReadLine(), out decimal newPrice))
                    book.Price = newPrice;

                Console.WriteLine("\nBook updated successfully!");
            }
            else
            {
                Console.WriteLine("\nBook not found.");
            }
        }
        else
        {
            Console.WriteLine("\nInvalid ID format.");
        }
    }

    static void DeleteBook()
    {
        ReadBooks();
        Console.Write("\nEnter the ID of the book to delete: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            books.RemoveAll(b => b.Id == id);
            Console.WriteLine("\nBook deleted successfully (if ID existed).");
        }
        else
        {
            Console.WriteLine("\nInvalid ID format.");
        }
    }
}