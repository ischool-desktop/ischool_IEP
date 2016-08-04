using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FISCA.UDT;

namespace ischool_IEP.DAO
{
    /// <summary>
    /// IEP 老師輸入後值
    /// </summary>
    [TableName("ischool.iep.input_memo")]
    class udt_input_memo:ActiveRecord
    {
        ///<summary>
        /// 學生系統編號
        ///</summary>
        [Field(Field = "ref_student_id", Indexed = true)]
        public int StudentID { get; set; }

        ///<summary>
        /// 課程系統編號
        ///</summary>
        [Field(Field = "ref_course_id", Indexed = true)]
        public int CourseID { get; set; }

        ///<summary>
        /// 教師系統編號
        ///</summary>
        [Field(Field = "ref_teacher_id", Indexed = true)]
        public int TeacherID { get; set; }

        ///<summary>
        /// 評量名稱
        ///</summary>
        [Field(Field = "exam", Indexed = false)]
        public string Exam { get; set; }

        ///<summary>
        /// 評量類別
        ///</summary>
        [Field(Field = "type", Indexed = false)]
        public string Type { get; set; }    

        ///<summary>
        /// 內容
        ///</summary>
        [Field(Field = "content", Indexed = false)]
        public string Content { get; set; }
    }
}
