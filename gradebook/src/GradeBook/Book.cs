using System.Collections.Generic;
using System;
using System.IO;

namespace GradeBook
{

    public interface IBook
    {
        void AddGrade(double grade);
        Statistics GetStats();
        string Name { get; }
        //event GradeAddedDelegate GradeAdded;
    }

    public abstract class Book
    {
        public abstract void AddGrade(double grade);
    }

    public class DiskBook : Book, IBook
    {
        public string Name;

        public DiskBook(string name)
        {
            Name = name;
        }

        string IBook.Name => throw new NotImplementedException();

        public override void AddGrade(double grade)
        {
            using (var writer = File.AppendText($"./{this.Name}.txt"))
            {
                writer.WriteLine(grade);
            }
        }

        public Statistics GetStats()
        {
            var result = new Statistics();

           using(var reader = File.OpenText($"./{this.Name}.txt"))
           {
               var line = reader.ReadLine();

               while(line != null)
               {
                   var number = double.Parse(line);
                   result.Add(number);
                   line = reader.ReadLine();
               }
           }

           return result;
        }
    }

    public class InMemoryBook : Book, IBook
    {
        public delegate void GradeAddedDelegate(object sender, EventArgs args);

        public InMemoryBook(string name)
        {
            grades = new List<double>();
            Name = name;
        }

        public void AddGrade(char letter)
        {
            switch (letter)
            {
                case 'A':
                    AddGrade(90);
                    break;

                case 'B':
                    AddGrade(90);
                    break;

                case 'C':
                    AddGrade(70);
                    break;
                case 'D':
                    AddGrade(60);
                    break;

                default:
                    AddGrade(0);
                    break;
            }
        }

        public override void AddGrade(double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
                grades.Add(grade);

                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}.");
            }
        }

        public List<double> getGrades()
        {
            return this.grades;
        }

        public event GradeAddedDelegate GradeAdded;

        public Statistics GetStats()
        {
            var result = new Statistics();

            foreach (var grade in grades)
            {
                result.Add(grade);
            }

            return result;
        }

        List<double> grades;

        public string Name { get; set; }

        const string category = "Science";


    }
}