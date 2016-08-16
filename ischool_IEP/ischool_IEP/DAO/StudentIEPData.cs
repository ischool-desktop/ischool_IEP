using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ischool_IEP.DAO
{
    public class StudentIEPData
    {
        public string UID { get; set; }

        public int StudentID { get; set; }

        public int CourseID { get; set; }

        public int TeacherID { get; set; }

        public string StudentName { get; set; }

        public int SchoolYear { get; set; }

        public int Semester { get; set; }

        public string CourseName { get; set; }

        public string TeacherName { get; set; }

        //舊的
        //public Dictionary<string, Dictionary<string, StringBuilder>> ExamContent = new Dictionary<string, Dictionary<string, StringBuilder>>();
        
        //穎驊改寫
        public Dictionary<string, Dictionary<string, List<string>>> ExamContent = new Dictionary<string, Dictionary<string, List<string>>>();


    }
}
