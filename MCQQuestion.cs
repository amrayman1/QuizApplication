using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp
{
    public class MCQQuestion : BaseQuestion, ICloneable
    {
        public override string Header { get; } = "Multiple Choose Question";

        public MCQQuestion(string _body = "", double _marks = 0) : base(_body, _marks)
        {
            AnswersList = new Answers[3];
        }

        public override string ToString()
        {
            return $"{Header} \n{Body}\n Marks: {Marks}\n" +
                $"1- {AnswersList[0].AnswerText} \t\t 2- {AnswersList[1].AnswerText} \t\t 2- {AnswersList[2].AnswerText}";
        }

        public static MCQQuestion AddMCQQuestion()
        {
            MCQQuestion question = new MCQQuestion();

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
            string answer = "";
            do
            {
                Console.WriteLine("Please Enter the Right Answer for this Question: ");
                answer = Console.ReadLine();
            } while (!(answer is string));

            question.RightAnswer.AnswerText = answer;

            return question;
        }

        public object Clone()
        {
            return new MCQQuestion(body, marks);
        }
    }
}
