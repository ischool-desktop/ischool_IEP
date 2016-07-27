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
    public partial class AddIEPStudentForm : BaseForm
    {

        List<int> _StudentIDList = new List<int> ();
        string _Tag = "";

        Dictionary<int, udt_student> _iepStudentDict = new Dictionary<int, udt_student>();

        BackgroundWorker _bgSave;

        public AddIEPStudentForm()
        {
            InitializeComponent();
            _bgSave = new BackgroundWorker();
            _bgSave.DoWork += _bgSave_DoWork;
            _bgSave.RunWorkerCompleted += _bgSave_RunWorkerCompleted;
      
        }

        void _bgSave_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnSave.Enabled = true;
            if(e.Error == null)
            {
                FISCA.Presentation.Controls.MsgBox.Show("共有"+_StudentIDList.Count+"位學生指定完成。");
                this.Close();
            }else
            {
                FISCA.Presentation.Controls.MsgBox.Show("指定過程發生錯誤，" + e.Error.Message);
            }
        }

        void _bgSave_DoWork(object sender, DoWorkEventArgs e)
        {
            LoadIEPStudent();
            SaveIEPStudent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void SetStudentIDList(List<string> idList)
        {
            foreach(string data in idList)
                _StudentIDList.Add(int.Parse(data));
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _Tag = txtTag.Text;
            btnSave.Enabled = false;
            _bgSave.RunWorkerAsync();
        }

        private void LoadIEPStudent()
        {
            _iepStudentDict.Clear();
            // 透過所選學生系統編號取得已有iep學生
            List<udt_student> iep_studentList = UDTTransfer.GetIEPStudentByStudentIDList(_StudentIDList);

            // 建立 Dict
            foreach(udt_student data in iep_studentList)
            {
                if (!_iepStudentDict.ContainsKey(data.StudentID))
                    _iepStudentDict.Add(data.StudentID, data);
            }
        }

        private void SaveIEPStudent()
        {
            List<udt_student> iepStudList = new List<udt_student>();
            foreach(int key in _StudentIDList)
            {
                udt_student stud;

                if(_iepStudentDict.ContainsKey(key))
                {
                    stud = _iepStudentDict[key];
                }else
                {
                    // 新增
                    stud = new udt_student();
                    stud.StudentID = key;                    
                }

                stud.Tag = _Tag;
                iepStudList.Add(stud);
            }

            // 儲存
            iepStudList.SaveAll();
        }

        private void AddIEPStudentForm_Load(object sender, EventArgs e)
        {
            this.MaximumSize = this.MinimumSize = this.Size;
        }
    }
}
