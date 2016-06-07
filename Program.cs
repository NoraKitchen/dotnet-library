using System;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var library = new Library();
            var currentUser = library.Login();

            Start(library, currentUser);

        }

        public static void Start(Library library, Patron user)
        {
            Console.WriteLine("What would you like to do? Please enter a number.");
            Console.WriteLine("1. Doante a book");
            Console.WriteLine("2. Check in");
            Console.WriteLine("3. Check out");
            Console.WriteLine("4. View your checked out items");
            Console.WriteLine("5. Log out");
            Console.WriteLine("Press Q to quit.");

            var choice = Console.ReadLine();

            if (choice == "1")
            {
                library.DonateBook();
            }
            else if (choice == "2")
            {
                library.checkIn(user);
            }
            else if (choice == "3")
            {
                library.checkOut(user);
            }
            else if (choice == "4")
            {
                user.ViewItemsOut();
            }
            else if (choice == "5")
            {
                user = library.Login();
            }

            if (choice.ToLower() != "q")
            {
                Start(library, user);
            }
        }

    }
}
