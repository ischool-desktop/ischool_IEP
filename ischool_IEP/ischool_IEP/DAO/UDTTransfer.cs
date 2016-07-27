using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FISCA.UDT;

namespace ischool_IEP.DAO
{
    class UDTTransfer
    {

        /// <summary>
        /// 取得開放與結束時間
        /// </summary>
        /// <returns></returns>
        public static udt_open_datetime GetOpenDateTime ()
        {
            udt_open_datetime value = new udt_open_datetime();
            AccessHelper accHelper = new AccessHelper();
            List<udt_open_datetime> listdata = accHelper.Select<udt_open_datetime>();
            if(listdata.Count>0)
            {
                value = listdata[0];
            }

            return value;
        }

        /// <summary>
        /// 取得輸入選項項目
        /// </summary>
        /// <returns></returns>
        public static List<udt_input_item> GetInputItemList()
        {
            List<udt_input_item> value = new List<udt_input_item>();
            AccessHelper accHelper = new AccessHelper();
            value = accHelper.Select<udt_input_item>();
            return value;
        }

        /// <summary>
        /// 取得指定 IEP 學生
        /// </summary>
        /// <returns></returns>
        public static List<udt_student> GetIEPStudentByStudentIDList(List<int> idList)
        {
            List<udt_student> value = new List<udt_student>();
            if(idList.Count>0)
            {
                string qry = "ref_student_id in("+string.Join(",",idList.ToArray())+")";
                AccessHelper accHelper = new AccessHelper();
                value = accHelper.Select<udt_student>(qry);

            }
            return value;
        }
    }
}
