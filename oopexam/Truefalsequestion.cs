using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace oopexam
{


    public class TrueFalseQuestion : Question
    {
        public TrueFalseQuestion(string body, double mark, int rightAnswerId)
            : base("True / False Question", body, mark, 2)
        {
            AnswerList[0] = new Answer(1, "True");
            AnswerList[1] = new Answer(2, "False");
            RightAnswerId = rightAnswerId;
        }

        public override void DisplayQuestion()
        {
            Console.WriteLine($"{Header}\n{Body}");
            Console.WriteLine("1. True\t\t2. False");
        }
    }
}
