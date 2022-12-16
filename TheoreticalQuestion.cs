using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp
{
    public class TheoreticalQuestion : BaseQuestion, ICloneable
    {
        public override string Header { get; } = "Theoretical Question";

        public TheoreticalQuestion(string _body = "", double _marks = 0) : base(_body, _marks)
        {
            AnswersList = new Answers[3];
        }

        public override string ToString()
        {
            return $"{Header} \n{Body}\n Marks: {Marks}\n" +
                $"1- {AnswersList[0].AnswerText} \t\t 2- {AnswersList[1].AnswerText} \t\t 2- {AnswersList[2].AnswerText}";
        }

        public static TheoreticalQuestion AddTheoreticalQuestion()
        {
            TheoreticalQuestion question = new TheoreticalQuestion();

            Console.WriteLine(question.Header);

            Console.WriteLine("Please Enter the Body of the Question: ");
            question.Body = Console.ReadLine();

            int mark;
            do
            {
                Console.WriteLine("Please Enter the Marks of the Question: ");
            } while (!int.TryParse(Console.ReadLine(), out mark));
            
            question.Marks = mark;

            Console.WriteLine("The Choices of the Question: ");
            for (int i = 0; i < question.AnswersList.Length; i++)
            {
                question.AnswersList[i] = new Answers();
                Console.WriteLine($"Please Enter the Choice Number{i + 1}: ");
                question.AnswersList[i].AnswerText = Console.ReadLine();
                question.AnswersList[i].AnswerId = i + 1;

            }

            question.RightAnswer = new Answers();
            int id;
            do
            {
                Console.WriteLine("Please Enter the Right Answer for this Question (1, 2 or 3): ");
            } while (!int.TryParse(Console.ReadLine(), out id) || id < 1 || id > 3);

            question.RightAnswer.AnswerId = id;
            question.RightAnswer.AnswerText = question.AnswersList[id - 1].AnswerText;

            return question;
        }

        public object Clone()
        {
            return new TheoreticalQuestion(body, marks);
        }
    }
}
