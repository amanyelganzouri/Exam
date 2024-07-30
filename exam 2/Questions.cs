using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exam_2
{
    internal class Question
    {
        //public string Header { get; set; }

        public string Body { get; set; }

        public int Mark { get; set; }
        public Answer[] AnswerList { get; set; }
        public Answer  Rightanswer { get; set; }

        public Question( string body, int mark , int numofans)
        {
            //Header = header;
            Body = body;
            Mark = mark;

            AnswerList = new Answer[numofans];


        }


        public override string ToString()
        {
            return $" Body: {Body}, Mark: {Mark}";
        }

    }

    internal class TrueOrFalse :  Question

    {
        public TrueOrFalse( string body, int mark) : base( body, mark, 2) 
        {
        }



    }

    internal class MCQ : Question

    {
        public MCQ( string body, int mark) : base(body, mark, 3)
        {
        }




    }
}
