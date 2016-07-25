using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FISCA.UDT;

namespace ischool_IEP.DAO
{
      [TableName("ischool.iep.open_datetime")]
    class udt_student:ActiveRecord
    {
        ///<summary>
        /// 學生系統編號
        ///</summary>
        [Field(Field = "ref_student_id", Indexed = false)]
        public int StudentID { get; set; }

        ///<summary>
        /// 學生分類標籤
        ///</summary>
        [Field(Field = "tag", Indexed = false)]
        public string Tag { get; set; }

    }
}
