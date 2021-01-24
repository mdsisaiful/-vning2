using System;
using System.Text.RegularExpressions;

namespace Övning2
{
    /// <summary>
    /// Hantera menyn
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // Den här Loop körs oändlig till användaren väljer att avsluta
            do
            {
                DisplayMainMenu();
                UserAction();

            } while (true);
        }

        private static void UserAction()
        {
            // Skapar en Switch-sats för att ta ett värde från användaren
            switch (Console.ReadLine())
            {
                case "1":
                    BuyTickets(); 
                    break;

                case "2":
                    RepeatTenTimes();   
                    break;

                case "3":
                    SearchString(); 
                    break;
                case "4":
                    Environment.Exit(0); // Stänger ner programmet.
                    break;
                default:
                    Console.WriteLine("Invalid input! Please try again...\n"); // Informerar användaren att det är felaktig input.
                    break;
            }
        }

        private static void SearchString()  // Den här metoder hanterar Menyval 3: Det tredje ordet
        {
            do
            {
                Console.WriteLine("\nPlease write sentence (atleast three words) or " +
                    "press \"q\" for returning to the MainMenu: ");
                
                string textInput = Console.ReadLine();
                string trimText = Regex.Replace(textInput, @"\s+", " ");    // Extra uppgifter
                //Console.WriteLine(trimText);

                string[] subs = trimText.Split(' ', '\t');
                if (trimText.Equals("q")) break;
                string thirdString = subs[2];
                Console.WriteLine($"\n Thrid string: {thirdString}");

            } while (true);
        }

        private static void RepeatTenTimes()    // Den här metoder hanterar Menyval 2: Upprepa tio gånger
        {

            do
            {
                Console.WriteLine("\nPlease enter any text or press \"q\" for returning to the MainMenu: ");
                string userInput = Console.ReadLine();
                if (userInput.Equals("q")) break;

                for (int i = 1; i <= 10; i++)
                {
                    Console.Write(i + " " + userInput + " ");
                }
                Console.WriteLine();

            } while (true);
        }

        private static void BuyTickets() // Den här metoder hanterar Menyval 1: Ungdom eller pensionär
        {

            do
            {
                Console.WriteLine("\nNumber of People or press \"q\" for returning to the MainMenu: ");
                string input = Console.ReadLine();
                if (input.Equals("q")) break;
                int numberOfPeople = int.Parse(input);
                int i = 1;
                int totalPrice = 0;

                do
                {
                    Console.WriteLine("\nAge by person: ");
                    int age = int.Parse(Console.ReadLine());
                    int price;
                    if (age < 20 && age > 5)
                    {
                        Console.WriteLine("Youth price: SEK 80");
                        price = 80;
                    }
                    else if (age > 64 && age < 100)
                    {
                        Console.WriteLine("Retirement price: SEK 90");
                        price = 90;
                    }
                    else if (age < 5 || age > 100) // Extra uppgifter
                    {
                        Console.WriteLine("FREE"); ;
                        price = 0;
                    }
                    else
                    {
                        Console.WriteLine("Standard price: SEK 120");
                        price = 120;
                    }
                    totalPrice += price;
                    i++;
                } while (i <= numberOfPeople);

                Console.WriteLine($"\nTotal number of people: {numberOfPeople}");
                Console.WriteLine($"Total price for the tickets: {totalPrice} kronor");

            } while (true);

        }

        private static void DisplayMainMenu()
        {
            // Informerar användaren om huvudmeny så att de kan navigera genom att skriva in siffror 
            // för att testa olika funktioner.

            Console.WriteLine("Welcome to the MainMenu!");
            Console.WriteLine("Please choose one menu from the following, thank you!");
            Console.WriteLine("\n1) Buy tickets");
            Console.WriteLine("2) Repeat ten times");
            Console.WriteLine("3) Search string");
            Console.WriteLine("4) Exit!\n");

        }
    }
}
