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
            Dictionary<string, StudentIEPData> sdataDict = new Dictionary<string, StudentIEPData>();
            if(!string.IsNullOrWhiteSpace(StudentID))
            {
                string strSQL = "select uid as uid,student.id as sid,student.name as studentname,course.course_name as coursename,course.subject as subjectname,(case nickname when '' then teacher.teacher_name else teacher.teacher_name ||'('||teacher.nickname||')' end) as teachername,course.school_year as schoolyear,course.semester as semester,course.id as cid,teacher.id as tid from $ischool.iep.input_data inner join student on $ischool.iep.input_data.ref_student_id = student.id inner join course on $ischool.iep.input_data.ref_course_id = course.id inner join teacher on $ischool.iep.input_data.ref_teacher_id = teacher.id where student.id =" + StudentID + " order by studentname,coursename";
                QueryHelper qh = new QueryHelper();
                DataTable dt = qh.Select(strSQL);

                foreach(DataRow dr in dt.Rows)
                {
                    try
                    {
                        StudentIEPData sd = new StudentIEPData();
                        sd.UID = dr["uid"].ToString();
                        sd.StudentID = int.Parse(dr["sid"].ToString());
                        sd.CourseName = dr["coursename"].ToString();
                        sd.StudentName = dr["studentname"].ToString();
                        sd.TeacherName = dr["teachername"].ToString();
                        sd.CourseID = int.Parse(dr["cid"].ToString());
                        sd.TeacherID = int.Parse(dr["tid"].ToString());
                        sd.SchoolYear = int.Parse(dr["schoolyear"].ToString());
                        sd.Semester = int.Parse(dr["semester"].ToString());

                        string key = sd.StudentID + "_" + sd.CourseID + "_" + sd.TeacherID;
                        if (!sdataDict.ContainsKey(key))
                            sdataDict.Add(key, sd);

                    }catch(Exception ex)
                    {

                    }
                }
                
                // 恩正建議穎驊改寫
                // 取得 UDT 資料並整理
                List<udt_input_data> dataList = UDTTransfer.GetIEPDataByStudentID(StudentID);

                foreach (udt_input_data data in dataList)
                {
                    string key = data.StudentID + "_" + data.CourseID + "_" + data.TeacherID;
                    if (sdataDict.ContainsKey(key))
                    {
                        if (!sdataDict[key].ExamContent.ContainsKey(data.Exam))
                            sdataDict[key].ExamContent.Add(data.Exam, new Dictionary<string, List<string>>());

                        if (!sdataDict[key].ExamContent[data.Exam].ContainsKey(data.Type))
                        {
                            sdataDict[key].ExamContent[data.Exam].Add(data.Type,new List<string>());

                            sdataDict[key].ExamContent[data.Exam][data.Type].Add(data.Value);                            
                        }
                        else
                        {                        
                            sdataDict[key].ExamContent[data.Exam][data.Type].Add(data.Value);                        
                        }                        
                    }
                }

                List<udt_input_memo> memoList = UDTTransfer.GetIEPDataMemoByStudentID(StudentID);
                foreach (udt_input_memo data in memoList)
                {
                    string key = data.StudentID + "_" + data.CourseID + "_" + data.TeacherID;
                    if (sdataDict.ContainsKey(key))
                    {
                        if (!sdataDict[key].ExamContent.ContainsKey(data.Exam))
                            sdataDict[key].ExamContent.Add(data.Exam, new Dictionary<string, List<string>>());

                        // memo 項的Type Key 通通設定為 "描述"，方便詳細資料排版
                        if (!sdataDict[key].ExamContent[data.Exam].ContainsKey("描述"))
                        {
                            sdataDict[key].ExamContent[data.Exam].Add("描述", new List<string>());

                            sdataDict[key].ExamContent[data.Exam]["描述"].Add(data.Content);

                        }

                        else
                        {
                            sdataDict[key].ExamContent[data.Exam]["描述"].Add(data.Content);
                                                
                        }                        
                    }
                }


                //舊的
                //// 取得 UDT 資料並整理
                //List<udt_input_data> dataList = UDTTransfer.GetIEPDataByStudentID(StudentID);
                
                //foreach(udt_input_data data in dataList)
                //{
                //    string key = data.StudentID + "_" + data.CourseID + "_" + data.TeacherID;
                //    if(sdataDict.ContainsKey(key))
                //    {
                //        if(!sdataDict[key].ExamContent.ContainsKey(data.Exam))
                //            sdataDict[key].ExamContent.Add(data.Exam, new Dictionary<string, StringBuilder>());

                //        if (!sdataDict[key].ExamContent[data.Exam].ContainsKey(data.Type))
                //            sdataDict[key].ExamContent[data.Exam].Add(data.Type, new StringBuilder());

                //        sdataDict[key].ExamContent[data.Exam][data.Type].AppendLine(data.Value);
                //    }
                //}

                //List<udt_input_memo> memoList = UDTTransfer.GetIEPDataMemoByStudentID(StudentID);
                //foreach (udt_input_memo data in memoList)
                //{
                //    string key = data.StudentID + "_" + data.CourseID + "_" + data.TeacherID;
                //    if (sdataDict.ContainsKey(key))
                //    {
                //        if (!sdataDict[key].ExamContent.ContainsKey(data.Exam))
                //            sdataDict[key].ExamContent.Add(data.Exam, new Dictionary<string, StringBuilder>());

                //        if (!sdataDict[key].ExamContent[data.Exam].ContainsKey(data.Type))
                //            sdataDict[key].ExamContent[data.Exam].Add(data.Type, new StringBuilder());

                //        sdataDict[key].ExamContent[data.Exam][data.Type].AppendLine(data.Content);
                //    }
                //}

            }

            foreach (StudentIEPData data in sdataDict.Values)
                value.Add(data);

            return value;
        }
    }
}
