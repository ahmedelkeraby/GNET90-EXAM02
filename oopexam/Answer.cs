using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oopexam
{
    public class Answer : ICloneable, IComparable<Answer>
    {
        public int AnswerId { get; set; }
        public string AnswerText { get; set; }

        public Answer() : this(0, string.Empty)
        {
        }

        public Answer(int answerId, string answerText)
        {
            AnswerId = answerId;
            AnswerText = answerText;
        }

        // ICloneable: a shallow copy is enough here since Answer only holds value types/strings.
        public object Clone()
        {
            return new Answer(AnswerId, AnswerText);
        }

        // IComparable: order answers by their Id.
        public int CompareTo(Answer other)
        {
            if (other is null) return 1;
            return AnswerId.CompareTo(other.AnswerId);
        }

        public override string ToString()
        {
            return $"({AnswerId}) {AnswerText}";
        }
    }
}


