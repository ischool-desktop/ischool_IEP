﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FISCA.UDT;

namespace ischool_IEP.DAO
{
    /// <summary>
    /// IEP 老師輸入後值
    /// </summary>
    [TableName("ischool.iep.input_data")]
    class udt_input_data:ActiveRecord
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
        /// 項目
        ///</summary>
        [Field(Field = "item", Indexed = false)]
        public string Item { get; set; }

        ///<summary>
        /// 值
        ///</summary>
        [Field(Field = "value", Indexed = false)]
        public string Value { get; set; }
    }
}
