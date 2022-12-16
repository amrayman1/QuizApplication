using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp
{
    public class Subject
    {
		private int id;
		private string name;
		private Exam subjectExam;

		public int Id
		{
			get { return id; }
			set { id = value; }
		}

		public string Name
		{
			get { return name; }
			set { name = value; }
		}


		public Exam SubjectExam
		{
			get { return subjectExam; }
			set { subjectExam = value; }
		}

		public Subject(int _id, string _name, Exam _subjectExam)
		{
			id = _id;
			name = _name;
			subjectExam = _subjectExam;
		}

        public Subject(int _id, string _name) : this(_id, _name, new PracticalExam(60, 3))
        {

        }

        public override string ToString()
        {
            return $"Subject Name {Name} \nSubject Id {Id} \n Exam Type {SubjectExam}";
        }

		public void CreateExam()
		{

			int time, type;
			do
			{
				Console.WriteLine("Please Choose the Type of The Exam (1- Practical Exam, 2- Final Exam): ");
			} while (!int.TryParse(Console.ReadLine(),out type) || type < 1 || type > 2);

			subjectExam.Type = (ExamType)type;

			do
			{
                Console.WriteLine("Please Choose the Time of The Exam in Minutes: ");
            } while (!int.TryParse(Console.ReadLine(), out time));

			subjectExam.Time = time;

			Console.WriteLine("Please Enter Number of Question: ");
			int numberOfQuestions = int.Parse(Console.ReadLine());

			if(subjectExam.Type == ExamType.PracticalExam)
			{
				subjectExam = new PracticalExam(time, numberOfQuestions);
				subjectExam.Questions = BaseQuestion.CreateBaseQuestion(numberOfQuestions);
			}
			else
			{
                subjectExam = new FinalExam(time, numberOfQuestions);
                subjectExam.Questions = BaseQuestion.CreateBaseQuestion(numberOfQuestions);
            }

			for (int i = 0; i < subjectExam.Questions?.Length; i++)
			{
				subjectExam.ExamGrade += subjectExam.Questions[i].Marks;
			}
		}

    }
}
