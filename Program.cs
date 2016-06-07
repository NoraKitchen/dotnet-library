﻿using System;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var library = new Library();

            // Console.WriteLine("Welcome to the library. Please enter your name.");
            // var name = Console.ReadLine();
            // Console.WriteLine("Hello, " + name);

            Start(library);

        }

        public static void Start(Library library){
                Console.WriteLine("Press 1 to donate a book, press 2 check in a book, or 3 to check out a book.  Press Q to quit.");
                var choice = Console.ReadLine();

                if (choice == "1"){
                    donateBook(library);
                }
                else if (choice == "2"){
                    checkIn(library);
                } else if (choice == "3") {
                    checkOut(library);
                }

            if (choice.ToLower() != "q"){
                Start(library);
            }
        }


        public static void donateBook(Library library){
            Console.WriteLine("Enter the title of the book:");
            var title = Console.ReadLine();

            Console.WriteLine("Enter the author of the book:");
            var author = Console.ReadLine();

            var book = new Book(title, author);
            library.Books.Add(book);

            Console.WriteLine("Thank you!");
        }

        public static void checkOut(Library library) {
            if (library.Books.Count == 0) {
                Console.WriteLine("Our library is empty!  Please donate!");
            } else {
                library.LogCollection();
                Console.WriteLine("Enter the number of the book you want to check out.");
                var choice = Console.ReadLine();
                int index = int.Parse(choice);

                if(library.Books[index].CheckedOut) {
                    Console.WriteLine("Sorry, this book is unavailable.");
                } else {
                    library.Books[index].CheckedOut = true;
                    Console.WriteLine(library.Books[index].CheckedOut);
                }
            }
            
        }

        public static void checkIn(Library library) {
            if (library.Books.Count == 0) {
                Console.WriteLine("We don't have books in our catalogue!  Please donate!");
            } else {
                library.LogCollection();
                Console.WriteLine("What is the number of the book you are checking in?");
                var choice = Console.ReadLine();
                int index = int.Parse(choice);

                foreach(var book in library.Books) {
                    if (book.CheckedOut) {
                        if (book == library.Books[index]) {
                            book.CheckedOut = false;
                            Console.WriteLine(book.CheckedOut);
                        } else if(library.Books.IndexOf(book) == library.Books.Count-1) {
                            Console.WriteLine("That book is not in our system.");
                        }
                    } else {
                        Console.WriteLine("That book has already been checked in!");
                    }
                }
            }
        }
    }
}