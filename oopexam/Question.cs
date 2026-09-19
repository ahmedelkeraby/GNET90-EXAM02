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
        public int RightAnswerId { get; set; }
        public int UserAnswerId { get; set; }

        protected Question(string header, string body, double mark, int answerCount)
        {
            Header = header;
            Body = body;
            Mark = mark;
            AnswerList = new Answer[answerCount];
        }

        public abstract void DisplayQuestion();

        public virtual object Clone()
        {
            Question cloned = (Question)this.MemberwiseClone();
            if (this.AnswerList != null)
            {
                cloned.AnswerList = new Answer[this.AnswerList.Length];
                for (int i = 0; i < this.AnswerList.Length; i++)
                {
                    cloned.AnswerList[i] = (Answer)this.AnswerList[i].Clone();
                }
            }
            return cloned;
        }

        public int CompareTo(Question other)
        {
            if (other == null) return 1;
            return this.Mark.CompareTo(other.Mark);
        }

        public override string ToString()
        {
            return $"[{Header}]\n{Body} (Mark: {Mark})";
        }
    }
}

