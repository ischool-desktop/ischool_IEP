using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FISCA.Data;
using System.Data;

namespace ischool_IEP.DAO
{
    class QueryData
    {
        /// <summary>
        /// 透過學生ID 取得學生IEP資料
        /// </summary>
        /// <param name="StudentID"></param>
        /// <returns></returns>
        public static List<StudentIEPData> GetIEPDataByStudentID(string StudentID)
        {
            List<StudentIEPData> value = new List<StudentIEPData>();
            if(!string.IsNullOrWhiteSpace(StudentID))
            {
                string strSQL = "select uid as uid,student.id as sid,student.name as studentname,course.course_name as coursename,course.subject as subjectname,(case nickname when '' then teacher.teacher_name else teacher.teacher_name ||'('||teacher.nickname||')' end) as teachername,exam as exam,type as type,value as value from $ischool.iep.input_data inner join student on $ischool.iep.input_data.ref_student_id = student.id inner join course on $ischool.iep.input_data.ref_course_id = course.id inner join teacher on $ischool.iep.input_data.ref_teacher_id = teacher.id where student.id =" + StudentID + " order by studentname,coursename,exam,type,value";
                QueryHelper qh = new QueryHelper();
                DataTable dt = qh.Select(strSQL);

                foreach(DataRow dr in dt.Rows)
                {
                    StudentIEPData sd = new StudentIEPData();
                    sd.UID = dr["uid"].ToString();
                    sd.StudentID = int.Parse(dr["sid"].ToString());
                    sd.CourseName = dr["coursename"].ToString();
                    sd.StudentName = dr["studentname"].ToString();
                    sd.TeacherName = dr["teachername"].ToString();
                    sd.ExamName = dr["exam"].ToString();
                    sd.ExamTypes = dr["type"].ToString();
                    sd.ItemValue = dr["value"].ToString();
                    value.Add(sd);
                }
            }
            return value;
        }
    }
}
