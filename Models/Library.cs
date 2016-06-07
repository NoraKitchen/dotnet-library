using System;
using System.Collections.Generic;

public class Library{
    public List<Book> Books { get; set; }

    public Library(){
        Books = new List<Book>();
    }

    public void LogCollection(){
        foreach (var book in Books){
            Console.WriteLine(Books.IndexOf(book) + ":" + "Title: " + book.Title + " | Author: " + book.Author);
        }
    }


}