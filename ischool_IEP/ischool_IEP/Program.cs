using FISCA.Permission;
using FISCA.Presentation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace ischool_IEP
{
    public class Program
    {
         static BackgroundWorker _bgLLoadUDT = new BackgroundWorker();

         [FISCA.MainMethod()]
         public static void Main()
         {
             _bgLLoadUDT.DoWork += _bgLLoadUDT_DoWork;
             _bgLLoadUDT.RunWorkerCompleted += _bgLLoadUDT_RunWorkerCompleted;
             _bgLLoadUDT.RunWorkerAsync();
         }

         static void _bgLLoadUDT_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
         {
             throw new NotImplementedException();
         }

         static void _bgLLoadUDT_DoWork(object sender, DoWorkEventArgs e)
         {
             Utility.CreateUDTTable();
         }


    }
}
