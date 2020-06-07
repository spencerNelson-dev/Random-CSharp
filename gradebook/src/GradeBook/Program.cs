using System;
using System.Collections.Generic;
using GradeBook;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            DiskBook book = new DiskBook("Spencer's Gradebook");
            //book.GradeAdded += OnGradeAdded;


            while (true)
            {
                System.Console.WriteLine("Enter a grade or 'q' to quit:");
                var input = Console.ReadLine();

                if (input == "q")
                {
                    break;
                }

                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
                finally
                {
                    System.Console.WriteLine("****");
                }


            }

            var stats = book.GetStats();

            Console.WriteLine($"The lowest grade is {stats.Low}");
            Console.WriteLine($"The highest grade is {stats.High}");
            Console.WriteLine($"The average grade is {stats.Average}");
            System.Console.WriteLine($"The letter grade is {stats.Letter}");

        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            System.Console.WriteLine("Grade was added!");
        }
    }
}
