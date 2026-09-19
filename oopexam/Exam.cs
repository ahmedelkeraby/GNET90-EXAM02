
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace oopexam
{
    public abstract class Exam : ICloneable
    {
        public int TimeInMinutes { get; set; }
        public int NumberOfQuestions { get; set; }
        public Question[] Questions { get; set; }

        protected Exam(int timeInMinutes, int numberOfQuestions)
        {
            TimeInMinutes = timeInMinutes;
            NumberOfQuestions = numberOfQuestions;
            Questions = new Question[numberOfQuestions];
        }

        public abstract void ShowExam();

        public virtual object Clone()
        {
            Exam cloned = (Exam)this.MemberwiseClone();
            if (this.Questions != null)
            {
                cloned.Questions = new Question[this.Questions.Length];
                for (int i = 0; i < this.Questions.Length; i++)
                {
                    cloned.Questions[i] = (Question)this.Questions[i].Clone();
                }
            }
            return cloned;
        }

        public override string ToString()
        {
            return $"Exam Time: {TimeInMinutes} mins, Questions: {NumberOfQuestions}";
        }
    }
}