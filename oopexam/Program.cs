using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace oopexam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            {
                Subject subject = new Subject(101, "Object-Oriented Programming (C#)");

                Console.WriteLine($"Subject: {subject.SubjectName}");
                subject.CreateExam();

                Console.Clear();
                char startChoice;
                do
                {
                    Console.Write("Do You Want To Start The Exam? (Y|N): ");
                } while (!char.TryParse(Console.ReadLine(), out startChoice));

                if (char.ToUpper(startChoice) == 'Y')
                {
                    subject.Exam.ShowExam();
                }
                else
                {
                    Console.WriteLine("\nExam cancelled.");
                }
            }
        }
    }
}
    