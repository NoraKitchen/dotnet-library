using System;
using System.Collections.Generic;

public class Library
{
    public List<Book> Books { get; set; }
    public List<Patron> Patrons { get; set; }

    public Library()
    {
        Books = new List<Book>();
        Patrons = new List<Patron>();
    }

    public void LogCollection()
    {
        foreach (var book in Books)
        {
            Console.WriteLine(Books.IndexOf(book) + ":" + "Title: " + book.Title + " | Author: " + book.Author);
        }
    }

    public Patron FindPatron(string name)
    {
        foreach (var patron in Patrons)
        {
            if (patron.Name == name)
            {
                return patron;
            }
        }
        Console.WriteLine("No patron found.");
        Login();
        return null;
    }

    public Patron CreatePatron(string name)
    {
        var newPatron = new Patron(name);
        Patrons.Add(newPatron);
        return newPatron;
    }

    public Patron Login()
    {
        Console.WriteLine("Welcome to the library!");
        Console.WriteLine("What would you like to do? Please enter a number.");
        Console.WriteLine("1. Login");
        Console.WriteLine("2. Create Patron Account");

        var choice = Console.ReadLine();
        if (choice == "1")
        {
            Console.WriteLine("Please enter your name.");
            var name = Console.ReadLine();
            return FindPatron(name);
        }
        else if (choice == "2")
        {
            Console.WriteLine("Please enter your name.");
            var name = Console.ReadLine();
            return CreatePatron(name);
        }
        else
        {
            Console.WriteLine("Please enter a valid number.");
            Login();
            return null;
        }
    }

    public void DonateBook()
    {
        Console.WriteLine("Enter the title of the book:");
        var title = Console.ReadLine();

        Console.WriteLine("Enter the author of the book:");
        var author = Console.ReadLine();

        var book = new Book(title, author);
        Books.Add(book);

        Console.WriteLine("Thank you!");
    }

    public void checkOut(Patron user)
    {
        if (Books.Count == 0)
        {
            Console.WriteLine("Our library is empty!  Please donate!");
        }
        else
        {
            LogCollection();
            Console.WriteLine("Enter the number of the book you want to check out.");
            var choice = Console.ReadLine();
            //error thrown here if don't enter value, consider try/catch
            {
                try
                {
                    int index = int.Parse(choice);

                    if (Books[index].CheckedOut)
                    {
                        Console.WriteLine("Sorry, this book is unavailable.");
                    }
                    else
                    {
                        user.BorrowedBooks.Add(Books[index]);
                        Books[index].CheckedOut = true;
                        Console.WriteLine(Books[index].CheckedOut);
                    }
                }
                catch (System.FormatException)
                {
                    Console.WriteLine("Please enter a valid number!");
                }
            }
        }
    }

    public void checkIn(Patron user)
    {
        if (Books.Count == 0)
        {
            Console.WriteLine("We don't have books in our catalogue!  Please donate!");
        }
        else
        {
            LogCollection();
            Console.WriteLine("What is the number of the book you are checking in?");
            var choice = Console.ReadLine();
            //error thrown here if don't enter value, consider try/catch --System.FormatException
            try
            {
                int index = int.Parse(choice);

                foreach (var book in Books)
                {
                    if (book.CheckedOut)
                    {
                        if (book == Books[index])
                        {
                            user.BorrowedBooks.Remove(Books[index]);
                            book.CheckedOut = false;
                            Console.WriteLine(book.CheckedOut);
                        }
                        else if (Books.IndexOf(book) == Books.Count - 1)
                        {
                            Console.WriteLine("That book is not in our system.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("That book has already been checked in!");
                    }
                }
            }
            catch (System.FormatException)
            {
                Console.WriteLine("Please enter a valid number!");
            }
        }
    }


}