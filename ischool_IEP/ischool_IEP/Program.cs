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

             // IEP 設定開放時間
             string regCodeSetOpenDatetimeForm = "ischool_IEP_SetOpenDatetimeForm";
             Catalog catalog01 = RoleAclSource.Instance["學生"]["IEP"];
             catalog01.Add(new RibbonFeature(regCodeSetOpenDatetimeForm, "設定開放時間"));

             RibbonBarItem item01 = K12.Presentation.NLDPanels.Student.RibbonBarItems["IEP"];
            // item01["設定"].Image = Properties.Resources.Report;
             item01["設定"].Size = RibbonBarButton.MenuButtonSize.Large;
             item01["設定"]["設定開放時間"].Enable = UserAcl.Current[regCodeSetOpenDatetimeForm].Executable;
             item01["設定"]["設定開放時間"].Click += delegate
             {
                 UI.SetOpenDatetimeForm sof = new UI.SetOpenDatetimeForm();
                 sof.ShowDialog();
             };

             // 設定輸入選項
             string regCodeSetInputItem = "ischool_IEP_SetInputItemsForm";
             catalog01.Add(new RibbonFeature(regCodeSetInputItem, "設定輸入選項"));
             RibbonBarItem item02 = K12.Presentation.NLDPanels.Student.RibbonBarItems["IEP"];
             // item02["設定"].Image = Properties.Resources.Report;
             item02["設定"].Size = RibbonBarButton.MenuButtonSize.Large;
             item02["設定"]["設定輸入選項"].Enable = UserAcl.Current[regCodeSetInputItem].Executable;
             item02["設定"]["設定輸入選項"].Click += delegate
             {
                 UI.SetInputItemsForm sif = new UI.SetInputItemsForm();
                 sif.ShowDialog();
             };


             // 設定輸入選項
             string regCodeAddRStudent = "ischool_IEP_AddRemoveStudent";
             catalog01.Add(new RibbonFeature(regCodeAddRStudent, "指定/移除 IEP 學生"));

             K12.Presentation.NLDPanels.Student.ListPaneContexMenu["指定IEP學生"].Enable = UserAcl.Current[regCodeAddRStudent].Executable;
             K12.Presentation.NLDPanels.Student.ListPaneContexMenu["指定IEP學生"].Click += delegate { 
                if(K12.Presentation.NLDPanels.Student.SelectedSource.Count>0)
                {
                    UI.AddIEPStudentForm aif = new UI.AddIEPStudentForm();
                    aif.SetStudentIDList(K12.Presentation.NLDPanels.Student.SelectedSource);
                    aif.ShowDialog();
                }             
             };

             K12.Presentation.NLDPanels.Student.ListPaneContexMenu["移除IEP學生"].Enable = UserAcl.Current[regCodeAddRStudent].Executable;
             K12.Presentation.NLDPanels.Student.ListPaneContexMenu["移除IEP學生"].Click += delegate
             {
                 if (K12.Presentation.NLDPanels.Student.SelectedSource.Count > 0)
                 {
                     UI.RemoveIEPStudentForm rif = new UI.RemoveIEPStudentForm();
                     rif.SetStudentIDList(K12.Presentation.NLDPanels.Student.SelectedSource);
                     rif.ShowDialog();
                 }             

             };


         }

         static void _bgLLoadUDT_DoWork(object sender, DoWorkEventArgs e)
         {
             Utility.CreateUDTTable();
         }


    }
}
