using System;

namespace Games.NumberGuess
{
    public class NumberGuessGame
    {
        public void StartGame()
        {
            var input = "";

            var score = 0;

            var random = new Random();

            Console.ForegroundColor = System.ConsoleColor.Cyan;

            while (true)
            {
                Console.WriteLine("Guess a number between 1 and 10. or q to quit.");

                var number = random.Next(11);

                input = Console.ReadLine();

                try
                {
                    if (int.Parse(input) == number)
                    {
                        score++;
                        Console.WriteLine("You guessed it!");
                    }
                    else
                    {
                        Console.WriteLine($"You guessed {input} but the number was {number}");
                    }
                }
                catch
                {
                    if (input != "q")
                    {
                        Console.WriteLine("Please enter a number");
                    }

                }


                if (input == "q")
                {
                    break;
                }
            }

            Console.WriteLine($"Your score was {score}");
        }
    }
}