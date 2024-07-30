using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exam_2
{
    internal class Subject
    {

        public int SubjectId { get; set; }

        public string SubjectName { get; set; }

        public Exam Examofsubject { get; set; }

        public Subject(int subjectid, string subjectname)
        {
            SubjectId = subjectid;
            SubjectName = subjectname;
            
        }

        public void SubExam(Exam exam)
        {

            Examofsubject = exam;


        }

        public override string ToString()
        {
            return "Subject Id" + SubjectId + "Subject Name Is" + SubjectName + "Exam:" + Examofsubject;

        }




    }



}

