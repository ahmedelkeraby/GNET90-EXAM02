using ExaminationSystem.Models;
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
        public int TimeOfExam { get; set; }          // in minutes
        public int NumberOfQuestions { get; set; }
        public List<Question> Questions { get; set; }

        // "Every Exam object is associated to a Subject."
        public Subject Subject { get; set; }

        protected Exam(int timeOfExam, List<Question> questions, Subject subject)
        {
            TimeOfExam = timeOfExam;
            Questions = questions;
            NumberOfQuestions = questions.Count;
            Subject = subject;
        }

        /// <summary>
        /// Implementation differs per exam type (Final vs Practical), so it is abstract here.
        /// </summary>
        public abstract void ShowExam();

        public abstract object Clone();

        public override string ToString()
        {
            return $"Exam for '{Subject.SubjectName}' - Duration: {TimeOfExam} min, " +
                   $"Questions: {NumberOfQuestions}";
        }
    }
}

