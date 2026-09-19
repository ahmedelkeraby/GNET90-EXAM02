
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace oopexam
{
    public class FinalExam : Exam
    {
        public FinalExam(int timeInMinutes, int numberOfQuestions)
            : base(timeInMinutes, numberOfQuestions) { }

        public override void ShowExam()
        {
            double totalGrade = 0;
            double obtainedGrade = 0;

            Stopwatch timer = new Stopwatch();
            timer.Start();

            Console.Clear();
            Console.WriteLine("==================== FINAL EXAM ====================\n");

            for (int i = 0; i < Questions.Length; i++)
            {
                var q = Questions[i];
                totalGrade += q.Mark;

                Console.WriteLine($"Question {i + 1}:");
                q.DisplayQuestion();

                int userAnswer;
                do
                {
                    Console.Write("Your Answer (Enter Id): ");
                } while (!int.TryParse(Console.ReadLine(), out userAnswer));

                q.UserAnswerId = userAnswer;
                if (q.UserAnswerId == q.RightAnswerId)
                {
                    obtainedGrade += q.Mark;
                }

                Console.WriteLine("----------------------------------------------------\n");
            }

            timer.Stop();

            Console.Clear();
            Console.WriteLine("==================== EXAM RESULTS ====================\n");

            for (int i = 0; i < Questions.Length; i++)
            {
                var q = Questions[i];
                Console.WriteLine($"Q{i + 1}: {q.Body}");

                string userAnswerText = GetAnswerText(q, q.UserAnswerId);
                string rightAnswerText = GetAnswerText(q, q.RightAnswerId);

                Console.WriteLine($"Your Answer : {userAnswerText}");
                Console.WriteLine($"Right Answer: {rightAnswerText}\n");
            }

            Console.WriteLine($"Elapsed Time: {timer.Elapsed.Minutes}m {timer.Elapsed.Seconds}s");
            Console.WriteLine($"Your Grade  : {obtainedGrade} / {totalGrade}");
            Console.WriteLine("======================================================");
        }

        private string GetAnswerText(Question question, int answerId)
        {
            if (question.AnswerList != null)
            {
                foreach (var ans in question.AnswerList)
                {
                    if (ans.AnswerId == answerId)
                        return ans.AnswerText;
                }
            }
            return "N/A";
        }
    }
}