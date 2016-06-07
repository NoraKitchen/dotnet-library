using System;
using System.Collections.Generic;

public class Patron
{
    public string Name { get; set; }
    public List<Book> BorrowedBooks { get; set; }


    public Patron(string name)
    {
        Name = name;
        BorrowedBooks = new List<Book>();
    }

    public void ViewItemsOut()
    {
        if (BorrowedBooks.Count > 0)
        {
            Console.WriteLine("Items currently checked out to" + Name + ":");
            foreach (var book in BorrowedBooks)
            {
                Console.WriteLine(book.Title);
            }
        }
        else {
            Console.WriteLine(Name + " has no books checked out!");
        }
    }
}

