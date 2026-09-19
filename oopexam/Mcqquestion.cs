using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oopexam
{
    public class MCQQuestion : Question
    {
        public MCQQuestion(string body, double mark, Answer[] choices, int rightAnswerId)
            : base("Choose One Answer Question", body, mark, choices?.Length ?? 0)
        {
            AnswerList = choices;
            RightAnswerId = rightAnswerId;
        }

        public override void DisplayQuestion()
        {
            Console.WriteLine($"{Header}\n{Body}");
            if (AnswerList != null)
            {
                foreach (var answer in AnswerList)
                {
                    Console.WriteLine(answer);
                }
            }
        }
    }
}