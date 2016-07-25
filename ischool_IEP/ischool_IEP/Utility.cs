using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FISCA.UDT;

namespace ischool_IEP
{
    class Utility
    {
        /// <summary>
        /// 建立　UDT Table
        /// </summary>
        public static void CreateUDTTable()
        {
            FISCA.UDT.SchemaManager Manager = new SchemaManager(new FISCA.DSAUtil.DSConnection(FISCA.Authentication.DSAServices.DefaultDataSource));
    //        Manager.SyncSchema(new DAO.udt_ConfigData());
        }
    }
}
