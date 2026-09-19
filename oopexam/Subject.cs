using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace oopexam
{


    public class Subject
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public Exam Exam { get; set; }

        public Subject(int subjectId, string subjectName)
        {
            SubjectId = subjectId;
            SubjectName = subjectName ?? string.Empty;
        }

        public void CreateExam()
        {
            int examType;
            do
            {
                Console.Write("Enter Exam Type (1 for Practical, 2 for Final): ");
            } while (!int.TryParse(Console.ReadLine(), out examType) || (examType != 1 && examType != 2));

            int time;
            do
            {
                Console.Write("Enter Time of Exam (in minutes): ");
            } while (!int.TryParse(Console.ReadLine(), out time) || time <= 0);

            int numQuestions;
            do
            {
                Console.Write("Enter Number of Questions: ");
            } while (!int.TryParse(Console.ReadLine(), out numQuestions) || numQuestions <= 0);

            if (examType == 1)
            {
                Exam = new PracticalExam(time, numQuestions);
            }
            else
            {
                Exam = new FinalExam(time, numQuestions);
            }

            Console.Clear();

            for (int i = 0; i < numQuestions; i++)
            {
                Console.WriteLine($"--- Creating Question {i + 1} ---");

                int qType = 1;
                if (examType == 2)
                {
                    do
                    {
                        Console.Write("Enter Question Type (1 for True/False, 2 for MCQ): ");
                    } while (!int.TryParse(Console.ReadLine(), out qType) || (qType != 1 && qType != 2));
                }

                Console.Write("Enter Question Body: ");
                string body = Console.ReadLine();

                double mark;
                do
                {
                    Console.Write("Enter Question Mark: ");
                } while (!double.TryParse(Console.ReadLine(), out mark) || mark <= 0);

                if (qType == 1)
                {
                    int rightAns;
                    do
                    {
                        Console.Write("Enter Right Answer Id (1 for True, 2 for False): ");
                    } while (!int.TryParse(Console.ReadLine(), out rightAns) || (rightAns != 1 && rightAns != 2));

                    Exam.Questions[i] = new TrueFalseQuestion(body, mark, rightAns);
                }
                else
                {
                    int numChoices;
                    do
                    {
                        Console.Write("Enter Number of Choices: ");
                    } while (!int.TryParse(Console.ReadLine(), out numChoices) || numChoices <= 1);

                    Answer[] choices = new Answer[numChoices];
                    for (int j = 0; j < numChoices; j++)
                    {
                        Console.Write($"Enter Choice {j + 1} Text: ");
                        string choiceText = Console.ReadLine();
                        choices[j] = new Answer(j + 1, choiceText);
                    }

                    int rightAns;
                    do
                    {
                        Console.Write("Enter Right Answer Id: ");
                    } while (!int.TryParse(Console.ReadLine(), out rightAns) || rightAns < 1 || rightAns > numChoices);

                    Exam.Questions[i] = new MCQQuestion(body, mark, choices, rightAns);
                }

                Console.WriteLine();
            }
        }

        public override string ToString()
        {
            return $"Subject ID: {SubjectId}, Name: {SubjectName}";
        }
    }
}