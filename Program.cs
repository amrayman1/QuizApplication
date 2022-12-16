using System;
using System.Diagnostics;

namespace QuizApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Subject subject = new Subject(1, "Programming");
            subject.CreateExam();
            Console.Clear();

            Console.WriteLine("Do You Want to Take the Exam Now?(Y | N)");
            if(char.Parse(Console.ReadLine()) == 'Y')
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                
                subject.SubjectExam.ShowExam();

                stopwatch.Stop();
                Console.WriteLine($"The Elapsed Time = {stopwatch.Elapsed}");

            }


        }
    }
}
