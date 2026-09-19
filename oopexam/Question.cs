using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace oopexam

{
    public abstract class Question : ICloneable, IComparable<Question>
    {
        public string Header { get; set; }
        public string Body { get; set; }
        public double Mark { get; set; }

        public Answer[] AnswerList { get; set; }
        public Answer RightAnswer { get; set; }

        protected Question(string header, string body, double mark, Answer[] answerList, Answer rightAnswer)
        {
            Header = header;
            Body = body;
            Mark = mark;
            AnswerList = answerList;
            RightAnswer = rightAnswer;
        }

        /// <summary>
        /// Each concrete question type knows how to print itself (its header,
        /// body and its own set of choices).
        /// </summary>
        public abstract void DisplayQuestion();

        public bool IsCorrectAnswer(Answer candidate)
        {
            return candidate != null && candidate.AnswerId == RightAnswer.AnswerId;
        }

        // ICloneable: deep-clone the answers array + right answer so the clone
        // does not share references with the original question.
        public virtual object Clone()
        {
            Question clone = (Question)MemberwiseClone();

            var clonedAnswers = new Answer[AnswerList.Length];
            for (int i = 0; i < AnswerList.Length; i++)
                clonedAnswers[i] = (Answer)AnswerList[i].Clone();

            clone.AnswerList = clonedAnswers;
            clone.RightAnswer = (Answer)RightAnswer.Clone();
            return clone;
        }

        // IComparable: questions are naturally ordered by their Mark.
        public int CompareTo(Question  other)
        {
            if (other == null) return 1;
            return Mark.CompareTo(other.Mark);
        }

        public override string ToString()
        {
            return $"[{GetType().Name}] \"{Header}\" - {Body} (Mark: {Mark})";
        }
    }
}

