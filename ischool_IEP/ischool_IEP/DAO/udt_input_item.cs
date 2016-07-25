using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FISCA.UDT;

namespace ischool_IEP.DAO
{
    [TableName("ischool.iep.input_items")]
    class udt_input_item:ActiveRecord
    {
        ///<summary>
        /// 評量名稱
        ///</summary>
        [Field(Field = "exam_name", Indexed = false)]
        public string ExamName { get; set; }

        ///<summary>
        /// 評量類別
        ///</summary>
        [Field(Field = "exam_types", Indexed = false)]
        public string ExamTypes { get; set; }

        ///<summary>
        /// 項目
        ///</summary>
        [Field(Field = "item", Indexed = false)]
        public string Item { get; set; }
    }
}
