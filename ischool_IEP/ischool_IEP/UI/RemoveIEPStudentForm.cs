using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FISCA.Presentation.Controls;
using ischool_IEP.DAO;

namespace ischool_IEP.UI
{
    public partial class RemoveIEPStudentForm : BaseForm
    {
        List<int> _StudentIDList = new List<int>();
        List<udt_student> _iepStudentList = new List<udt_student>();
        BackgroundWorker _bgLoadData;
        BackgroundWorker _bgSaveData;

        public RemoveIEPStudentForm()
        {
            InitializeComponent();
            _bgLoadData = new BackgroundWorker();
            _bgSaveData = new BackgroundWorker();
            _bgLoadData.DoWork += _bgLoadData_DoWork;
            _bgLoadData.RunWorkerCompleted += _bgLoadData_RunWorkerCompleted;
            _bgLoadData.RunWorkerAsync();
            _bgSaveData.DoWork += _bgSaveData_DoWork;
            _bgSaveData.RunWorkerCompleted += _bgSaveData_RunWorkerCompleted;
        }

        void _bgSaveData_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if(e.Error == null)
            {
                FISCA.Presentation.Controls.MsgBox.Show("移除完成。");
                this.Close();            
            }else
            {
                FISCA.Presentation.Controls.MsgBox.Show("移除過程發生錯誤，" + e.Error.Message);
                btnSave.Enabled = true;
            }            
        }

        void _bgSaveData_DoWork(object sender, DoWorkEventArgs e)
        {
            btnSave.Enabled = false;
            foreach (udt_student data in _iepStudentList)
                data.Deleted = true;

            _iepStudentList.SaveAll();

        }

        void _bgLoadData_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnSave.Enabled = true;
        }

        public void SetStudentIDList(List<string> idList)
        {
            foreach (string data in idList)
                _StudentIDList.Add(int.Parse(data));
        }

        void _bgLoadData_DoWork(object sender, DoWorkEventArgs e)
        {
            _iepStudentList = UDTTransfer.GetIEPStudentByStudentIDList(_StudentIDList);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = false;
            _bgSaveData.RunWorkerAsync();
        }

        private void RemoveIEPStudentForm_Load(object sender, EventArgs e)
        {
            this.MaximumSize = this.MinimumSize = this.Size;
            btnSave.Enabled = false;
        }
    }
}
