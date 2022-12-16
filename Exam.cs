using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace QuizApp
{
    public enum ExamType { PracticalExam = 1, FinalExam = 2}
    public abstract class Exam
    {
		public abstract ExamType Type { get; set; }
		private int time;
		private int numberOfQuestion;
		private double examGrade;
		BaseQuestion[] questions;
		Answers[] answers;

		public int Time
		{
			get { return time; }
			set { time = value; }
		}

		public int NumberOfQuestion
        {
			get { return numberOfQuestion; }
			set { numberOfQuestion = value; }
		}

		public double ExamGrade
		{
			get { return examGrade; }
			set { examGrade = value; }
		}

        public BaseQuestion[] Questions
        {
            get { return questions; }
            set { questions = value; }
        }
		
		public Answers[] Answers
        {
            get { return answers; }
            set { answers = value; }
        }

        public Exam(int _time, int _numberOfQuestion)
		{
			time = _time;
			numberOfQuestion = _numberOfQuestion;
			examGrade = 0;
			questions = new BaseQuestion[_numberOfQuestion];
			answers = new Answers[_numberOfQuestion];
		}

		public virtual void ShowExam()
		{
			for (int i = 0; i < questions?.Length; i++)
			{
				Console.WriteLine(questions[i]);
				Console.WriteLine("==========================================");

				int id;
				string answer = "";

				answers[i] = new Answers();

				if (questions[i].GetType().Name == "MCQQuestion")
				{
					do
					{
						answer = Console.ReadLine();
					} while (!(answer is string));

					answers[i].AnswerText = answer;
				}
				else
				{
					do
					{

					} while (!int.TryParse(Console.ReadLine(), out id));

					answers[i].AnswerId = id;

					for (int j = 0; j < questions[i].AnswersList?.Length; j++)
					{
						if (questions[i].AnswersList[j].AnswerId == id)
							answers[i].AnswerText = questions[i].AnswersList[j].AnswerText;
					}
				}
				Console.WriteLine("============================================");

            }


		}

	}
}
