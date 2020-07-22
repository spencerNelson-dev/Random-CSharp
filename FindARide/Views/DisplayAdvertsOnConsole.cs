using System;
using System.Collections.Generic;
using FindARide.Models;

namespace FindARide.Views
{
    public static class DisplayAdvertsOnConsole
    {

        public static void Display(List<Advert> adverts)
        {
            foreach (var advert in adverts)
            {
                try
                {
                if (advert.Sold) continue;

                System.Console.WriteLine("-----------------------------------------------------");

                Console.ForegroundColor = ConsoleColor.Cyan;
                System.Console.WriteLine(advert.Title + (advert.Sold ? " ***SOLD***" : ""));

                Console.ForegroundColor = ConsoleColor.Green;
                System.Console.WriteLine(advert.Price);

                Console.ForegroundColor = ConsoleColor.Yellow;
                System.Console.WriteLine(
                    advert.Description
                    .Replace("<p>", "")
                    .Replace("</p>", "")
                    .Replace("<span>", "")
                    .Replace("</span>", "")
                    .Trim() + "\n");

                Console.ForegroundColor = ConsoleColor.White;
                System.Console.WriteLine(advert.Url + "\n");
                }
                catch
                {
                    System.Console.WriteLine("Advert failed");
                }
            }
        }
    }
}