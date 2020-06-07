using System;
using Games.NumberGuess;

namespace Games
{
    class Program
    {
        static void Main(string[] args)
        {
            var choice = "";

            GameMenu menu = new GameMenu();

            while (true)
            {
                Console.ForegroundColor = System.ConsoleColor.White;
                Console.WriteLine("Choose a game (or q to quit):");

                menu.DisplayMenu();

                choice = Console.ReadLine();
                if(choice == "q")
                {
                    break;
                }

                switch (choice)
                {
                    case ("1"):
                        var game = new NumberGuessGame();
                        game.StartGame();
                        break;
                    default:
                        Console.WriteLine("Make a selection, or type 'q' to quit.");
                        break;
                }
            }
        }
    }
}
