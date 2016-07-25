using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FISCA.UDT;

namespace ischool_IEP.DAO
{
    [TableName("ischool.iep.open_datetime")]
    class udt_open_datetime:ActiveRecord
    {
        ///<summary>
        /// 開始日期時間
        ///</summary>
        [Field(Field = "begin_date", Indexed = false)]
        public DateTime BeginDate { get; set; }

        ///<summary>
        /// 結束日期時間
        ///</summary>
        [Field(Field = "end_date", Indexed = false)]
        public DateTime EndDate { get; set; }

    }
}
