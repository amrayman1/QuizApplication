using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp
{
    public abstract class BaseQuestion
    {
        protected string body;
        protected double marks;
        Answers[] answersList;
        private Answers rightAnswer;

        public abstract string Header { get; }

        public string Body
        {
            get { return body; }
            set { body = value; }
        }

        public double Marks
        {
            get { return marks; }
            set { marks = value; }
        }

        public Answers RightAnswer
        {
            get { return rightAnswer; }
            set { rightAnswer = value; }
        }
        public Answers[] AnswersList
        {
            get { return answersList; }
            set { answersList = value; }
        }
        public BaseQuestion(string _body, double _marks)
        {
            marks = _marks;
            body = _body;
        }

        public Answers this[int id]
        {
            get
            {
                for (int i = 0; i < answersList?.Length; i++)
                {
                    if (answersList[i].AnswerId == id)
                        return answersList[i];
                }
                return new Answers();
            }
        }

        public Answers this[string text]
        {
            get
            {
                for (int i = 0; i < answersList?.Length; i++)
                {
                    if (answersList[i].AnswerText == text)
                        return answersList[i];
                }
                return new Answers();
            }
        }


        public static BaseQuestion[] CreateBaseQuestion(int size)
        {
            BaseQuestion[] questions = new BaseQuestion[size];
            for (int i = 0; i < questions.Length; i++)
            {
                int questionType;
                do
                {
                    
                    Console.WriteLine($"Choose Type of Question Number{i+1} (1- T/F Question, " +
                        $"2- Theoretical Question, 3- MCQ Question): ");
                } while (!int.TryParse(Console.ReadLine(), out questionType) || questionType < 1 || questionType > 3);

                if(questionType == 1)
                {
                    Console.WriteLine($"Data of True or False Question Number {i + 1}");
                    questions[i] = TFQuestion.AddTFQuestion();
                }
                else if(questionType == 2)
                {
                    Console.WriteLine($"Data of Theoretical Question Number {i + 1}");
                    questions[i] = TheoreticalQuestion.AddTheoreticalQuestion();
                }
                else if (questionType == 3)
                {
                    Console.WriteLine($"Data of MCQ Question Number {i + 1}");
                    questions[i] = MCQQuestion.AddMCQQuestion();
                }

            }
            return questions;
        }




    }
}
