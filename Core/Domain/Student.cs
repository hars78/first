using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Interfaces;

namespace Core.Domain
{
    public class Student
    {
        public Student(IQuestion initialQuestion)
        {
            AnsweringQuestion = initialQuestion;
        }

        public IQuestion AnsweringQuestion { get; set; }

        public readonly Dictionary<string, string> Answers = new();

        public void StoreAnswers(string question, string answer)
        {
            Answers[question] = answer;
        }

    }
}
