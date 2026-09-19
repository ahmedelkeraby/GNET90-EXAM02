
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oopexam
{
    public class PracticalExam : Exam
    {
        public PracticalExam(int timeInMinutes, int numberOfQuestions)
            : base(timeInMinutes, numberOfQuestions) { }

        public override void ShowExam()
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();

            Console.Clear();
            Console.WriteLine("================== PRACTICAL EXAM ==================\n");

            for (int i = 0; i < Questions.Length; i++)
            {
                var q = Questions[i];

                Console.WriteLine($"Question {i + 1}:");
                q.DisplayQuestion();

                int userAnswer;
                do
                {
                    Console.Write("Your Answer (Enter Id): ");
                } while (!int.TryParse(Console.ReadLine(), out userAnswer));

                q.UserAnswerId = userAnswer;
                Console.WriteLine("----------------------------------------------------\n");
            }

            timer.Stop();

            Console.Clear();
            Console.WriteLine("================== RIGHT ANSWERS ==================\n");

            for (int i = 0; i < Questions.Length; i++)
            {
                var q = Questions[i];
                Console.WriteLine($"Q{i + 1}: {q.Body}");

                string rightAnswerText = "N/A";
                if (q.AnswerList != null)
                {
                    foreach (var ans in q.AnswerList)
                    {
                        if (ans.AnswerId == q.RightAnswerId)
                        {
                            rightAnswerText = ans.AnswerText;
                            break;
                        }
                    }
                }

                Console.WriteLine($"Right Answer: {rightAnswerText}\n");
            }

            Console.WriteLine($"Elapsed Time: {timer.Elapsed.Minutes}m {timer.Elapsed.Seconds}s");
            Console.WriteLine("===================================================");
        }
    }
}