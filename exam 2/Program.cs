using System.Reflection.PortableExecutable;
using static exam_2.Final;

namespace exam_2
{
    internal class Program
    {
        static Answer[] StudentAnswers(Exam exam)
        {
            Answer[] stanswer = new Answer[exam.NumberOfQuestions];

            for (int i = 0; i < exam.NumberOfQuestions; i++)
            {
                var question = exam.Questions[i];
                Console.WriteLine($"Question {i + 1}: {question.Body}");

                for (int j = 0; j < question.AnswerList.Length; j++)
                {
                    Console.WriteLine($"{j + 1}. {question.AnswerList[j].AnswerText}");
                }

                Console.Write("What is your answer (enter the answer number): ");
                int ansId = int.Parse(Console.ReadLine()) - 1;
                stanswer[i] = question.AnswerList[ansId];

                Console.WriteLine($"Your Answer: {stanswer[i].AnswerText}");
                Console.WriteLine($"Correct Answer: {question.Rightanswer.AnswerText}");
            }
            return stanswer;
        }
            static int CalculateGrade(Exam exam, Answer[] studentAnswers)
            {
                int grade = 0;

                for (int i = 0; i < exam.NumberOfQuestions; i++)
                {
                    if (studentAnswers[i].AnswerId == exam.Questions[i].Rightanswer.AnswerId)
                    {
                        grade += exam.Questions[i].Mark;
                    }
                }

                return grade;
            }
            static void Main(string[] args)
            {
                Console.WriteLine("please enter type of exam (1 practical | 2 final)");
                int TypeOfExam = int.Parse(Console.ReadLine());
                Exam exam;

                Console.WriteLine(" enter time of exam (60 min to 180 min) ");
                int timeofexam = int.Parse(Console.ReadLine());



                Console.WriteLine(" enter Num of Question ");
                int numberOfQuestions = int.Parse(Console.ReadLine());

                //final

                if (TypeOfExam == 2)
                {
                    exam = new Final(timeofexam, numberOfQuestions);

                    Question[] questions = new Question[numberOfQuestions];

                    for (int i = 0; i < exam.NumberOfQuestions; i++)
                    {
                        Console.WriteLine($"Enter type of question {i + 1} (1 MCQ | 2 True or False): ");
                        int typeofquestion = int.Parse(Console.ReadLine());

                        if (typeofquestion == 1)
                        {


                            Console.WriteLine("Enter question body: ");
                            string body = Console.ReadLine();

                            Console.WriteLine("Enter question mark: ");
                            int mark = int.Parse(Console.ReadLine());

                            MCQ mcq = new MCQ(body, mark);
                            Console.WriteLine("please enter question choicess ?");

                            //Answer[] answer = new Answer[3];
                            string choicess;
                            for (int j = 0; j < 3; j++)
                            {
                                Console.WriteLine($"Please enter choice num {j + 1}");

                                choicess = Console.ReadLine();

                                mcq.AnswerList[j] = new Answer(j + 1, choicess);
                            }




                            Console.WriteLine("Enter the correct answer number (1-4): ");
                            int correctAnswer = int.Parse(Console.ReadLine());

                            mcq.Rightanswer = mcq.AnswerList[correctAnswer];


                            exam.Questions[i] = mcq;
                        }







                        else if (typeofquestion == 2)
                        {


                            Console.WriteLine("true or false Question");

                            Console.WriteLine("enter question body");
                            string body = Console.ReadLine();

                            Console.WriteLine("enter question mark ");
                            int mark = int.Parse(Console.ReadLine());
                            // make t or fale 
                            // then take the right ans
                            TrueOrFalse trueOrFalseQuestion = new TrueOrFalse(body, mark);


                            trueOrFalseQuestion.AnswerList[0] = new Answer(1, "True");
                            trueOrFalseQuestion.AnswerList[1] = new Answer(2, "False");
                            Console.WriteLine("Enter the correct answer (1 for true| 2 for false): ");
                            int correctanswer = int.Parse(Console.ReadLine());
                            trueOrFalseQuestion.Rightanswer = trueOrFalseQuestion.AnswerList[correctanswer - 1];

                            exam.Questions[i] = trueOrFalseQuestion;

                        }
                    }

                }

                //============================================practical 



                else
                {
                    exam = new Practical(timeofexam, numberOfQuestions);

                    Console.WriteLine("Enter time of exam ( 60 min to 180 min ): ");
                    int timeOfExam = int.Parse(Console.ReadLine());

                    Console.WriteLine("Enter number of questions: ");
                    int numberofquestions = int.Parse(Console.ReadLine());

                    exam = new Practical(timeOfExam, numberofquestions);

                    //just mcq question


                    for (int i = 0; i < exam.NumberOfQuestions; i++)
                    {

                        Console.WriteLine("Enter question body: ");
                        string body = Console.ReadLine();

                        Console.WriteLine("Enter question mark: ");
                        int mark = int.Parse(Console.ReadLine());


                        Console.WriteLine("please enter question choicess ?");
                        MCQ mcq = new MCQ(body, mark);

                        //Answer[] answer = new Answer[3];
                        string choicess;
                        for (int j = 0; j < 3; j++)
                        {
                            Console.WriteLine($"Please enter choice num {j + 1}");

                            choicess = Console.ReadLine();

                            mcq.AnswerList[j] = new Answer(j + 1, choicess);
                        }




                        Console.WriteLine("Enter the correct answer number (1-4): ");
                        int correctAnswer = int.Parse(Console.ReadLine());

                        mcq.Rightanswer = mcq.AnswerList[correctAnswer];


                        exam.Questions[i] = mcq;
                    }



                }

                Console.WriteLine("do u want to start exam(Y|N) ");
                char ans = char.Parse(Console.ReadLine());
                if (ans == '1' || ans == 'y')
                {
                    exam.ShowExam();
                    StudentAnswers(exam);
                    if (TypeOfExam==2) 
                    {
                    Answer[]  stanswer = StudentAnswers(exam);
                    CalculateGrade(exam , stanswer);


                    }


                    //بيعرضلها الاجابه بتاعتها والاجابه الصح
                    //grade
                    //time take in exxam // still not coded
                    // thank u 


                }
                else
                {
                    Console.WriteLine("thank u ");
                }


            }
        
    }
}
