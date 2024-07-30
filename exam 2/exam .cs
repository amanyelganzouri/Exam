using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exam_2
{
    internal abstract class Exam
    {
        public int TimeOfExam { get; set; }
        public int NumberOfQuestions { get; set; }
        public Question[] Questions { get; set; }
        public int TotalMark { get; set; }

        protected Exam(int timeOfExam, int numberOfQuestions)
        {
            TimeOfExam = timeOfExam;
            NumberOfQuestions = numberOfQuestions;
            Questions = new Question[numberOfQuestions];
        }

        public abstract void ShowExam();
    
       

    }

    internal class Final : Exam
    {
        public Final(int timeOfExam, int numberOfQuestions) : base(timeOfExam, numberOfQuestions)
        {
        }

        public override void ShowExam()
        {
            Console.WriteLine("Final Exam:");
            foreach (var question in Questions)
            {
                Console.WriteLine(question);
                foreach (var answer in question.AnswerList)
                {
                    Console.WriteLine(answer);
                }
                Console.WriteLine("Right Answer: " + question.Rightanswer);
            }
        }
    }



    internal class Practical : Exam
    {
        public Practical(int timeOfExam, int numberOfQuestions) : base(timeOfExam, numberOfQuestions)
        {
        }

        public override void ShowExam()
        {
            Console.WriteLine("Practical Exam:");
            foreach (var question in Questions)
            {
                Console.WriteLine(question);
                Console.WriteLine("Right Answer: " + question.Rightanswer);
            }
        }
    }





}


         





        

