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
        public TrueFalseQuestion(string header, string body, double mark, Answer rightAnswer)
            // Constructor chaining: builds the fixed True/False answer list once,
            // then hands everything up to the base Question constructor.
            : base(header, body, mark, new Answer[]
  {
      new Answer(1, "True"),
      new Answer(2, "False")
  }, rightAnswer)
        {
        }

        public override void DisplayQuestion()
        {
            Console.WriteLine($"Q: {Body}  ({Mark} mark(s))");
            foreach (var answer in AnswerList)
            {
                Console.WriteLine($"{answer}");
            }
        }

        public override object Clone()
        {
            var clonedRightAnswer = (Answer)RightAnswer.Clone();
            return new TrueFalseQuestion(Header, Body, Mark, clonedRightAnswer);
        }

        public override string ToString()
        {
            return base.ToString() + " [True/False]";
        }
    }
}

}

