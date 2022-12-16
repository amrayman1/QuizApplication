using System;

namespace QuizApp
{
    public class Answers : ICloneable
    {
		private int answerId;
		public int AnswerId
		{
			get { return answerId; }
			set { answerId = value; }
		}

		private string answerText;
		public string AnswerText
		{
			get { return answerText; }
			set { answerText = value; }
		}
		public Answers(int _answerId, string _answerText)
		{
			answerId = _answerId;
			answerText = _answerText;
		}

        public Answers()
        {
        }

        public object Clone()
        {
			return new Answers(answerId, answerText);
        }
    }
}