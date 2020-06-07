using System;
using Assortment;
using System.Linq;

namespace ConsoleApp
{
    public enum Color { Red, Green, Ivory, Yellow, Blue }

    class Program
    {
        static void Main(string[] args)
        {
            int[] houses = {1, 2, 3, 4, 5};

            // var perms = Perm.GetAllPerm(houses);

            var perms = Perm.GetPermutations(houses, houses.Length);

            foreach(var perm in perms)
            {

                Console.Write("(");

                foreach(var value in perm)
                {
                    Console.Write($"{value}, ");
                }

                Console.WriteLine("),");

                Console.WriteLine($"{Color.Red} at index {perm.ToList().IndexOf((int)Color.Red)}");
            }

            Console.WriteLine($"length of {perms.Count()}");
            Console.WriteLine($"{Color.Blue}");

            Console.WriteLine($"{(int)Color.Red}");
        }
    }
}
