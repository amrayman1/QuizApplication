using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp
{
    public class PracticalExam : Exam, ICloneable
    {
        public override ExamType Type { get; set; } = ExamType.PracticalExam;

        public PracticalExam(int _time, int _numberOfQuestion) : base(_time, _numberOfQuestion)
        {
            Answers = new Answers[_numberOfQuestion];
        }

        public override void ShowExam()
        {
            base.ShowExam();
            ShowExamResult();
        }

        public void ShowExamResult()
        {
            Console.WriteLine("The Right Answer: ");
            double grade = 0;

            for (int i = 0; i < Questions?.Length; i++)
            {
                if (Questions[i].GetType().Name == "MCQQuestion")
                {
                    string answer = "";
                    string[] Arr = Questions[i].RightAnswer.AnswerText.Split(",");
                    for (int j = 0; j < Arr.Length; j++)
                    {
                        if (Arr[i] == Questions[i].AnswersList[j].AnswerText)
                            answer += Questions[i].AnswersList[j].AnswerText + " ";
                    }
                    Console.WriteLine($"Question {i + 1} {Questions[i].Body} : {answer}");
                }
                else
                    Console.WriteLine($"Question {i + 1} {Questions[i].Body} : {Questions[i].RightAnswer.AnswerText}");

                if (Answers[i].AnswerText == Questions[i].RightAnswer.AnswerText)
                    grade += Questions[i].Marks;

            }

            Console.WriteLine($"Your Grade is {grade} from {ExamGrade}");



        }

        public object Clone()
        {
            return new PracticalExam(Time, NumberOfQuestion);
        }
    }
}
