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
        if (choice == "1"){
            Console.WriteLine("Please enter your name.");
            var name = Console.ReadLine();
            return FindPatron(name);
        }
        else if (choice == "2"){
            Console.WriteLine("Please enter your name.");
            var name = Console.ReadLine();
            return CreatePatron(name);
        }
        else{
            Console.WriteLine("Please enter a valid number.");
            Login();
            return null;
        }
    }


}