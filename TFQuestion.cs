using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp
{
    public class TFQuestion : BaseQuestion, ICloneable
    {
        public override string Header { get; } = "True or False Question";

        public TFQuestion(string _body = "", double _marks = 0) : base(_body, _marks)
        {
            AnswersList = new Answers[2];
            AnswersList[0] = new Answers(1, "True");
            AnswersList[1] = new Answers(2, "False");
        }

        public override string ToString()
        {
            return $"{Header} \n{Body}\n Marks: {Marks}" +
                $"1- {AnswersList[0].AnswerText} \t\t 2- {AnswersList[1].AnswerText}";
        }

        public static TFQuestion AddTFQuestion()
        {
            TFQuestion question = new TFQuestion();
            Console.WriteLine(question.Header);

            Console.WriteLine("Please Enter the Body of the Question: ");
            question.Body = Console.ReadLine();
            
            int mark;
            do
            {
                Console.WriteLine("Please Enter the Marks of the Question: ");
            } while (!int.TryParse(Console.ReadLine(), out mark));

            question.Marks = mark;

            question.RightAnswer = new Answers();
            int id;
            do
            {
                Console.WriteLine("Please Enter the Right Answer for this Question (1- True, 2- False): ");
            } while (!int.TryParse(Console.ReadLine(), out id) || id < 1 || id > 2);

            question.RightAnswer.AnswerId = id;
            question.RightAnswer.AnswerText = question[id].AnswerText;

            return question;


        }

        public object Clone()
        {
            return new TFQuestion(body, marks);
        }
    }
}
