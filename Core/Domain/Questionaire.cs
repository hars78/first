using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain
{
    public class Questionaire
    {
        public IQuestion Success() => new TerminalQuestion("Success");
        public IQuestion Failure() => new TerminalQuestion("Failure");
        public IQuestion FoodQuestion() => "How do you Rate Pasta on a scale of 10".Range(Success().UpTo(0).Question(Success()).UpTo(3).Question(Success()).UpTo(7).Question(Failure()).UpTo(10).Otherwise(Failure()));
        public IQuestion ColorQuestion() => "What is your Favorite Color?".MultiQuestion(Failure(), "white".Question(FoodQuestion()), "red".Question(Failure()));
        public IQuestion AgeQuestion() => "What is your age?".Numeric(ColorQuestion());
        public IQuestion NameQuestion() => "Are you Human??".Boolean(AgeQuestion(), Success());
    }
}
