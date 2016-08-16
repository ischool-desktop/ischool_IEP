using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ischool_IEP.DAO;
using K12.Data;
using FISCA.UDT;


namespace ischool_IEP.DetailContent
{
    [FISCA.Permission.FeatureCode("ischool_IEP_InputDataContent", "IEP 輸入資料")]
    public partial class InputDataContent : FISCA.Presentation.DetailContent
    {
        //bool _isBGBusy = false;
        string _RunningID = "";

        BackgroundWorker _bgLoadData;

        List<StudentIEPData> _StudentIEPDataList;

        AccessHelper accessHelper = new AccessHelper();

        List<udt_student> list;

        public InputDataContent()
        {
            InitializeComponent();
            Group = "IEP輸入結果";
            _bgLoadData = new BackgroundWorker();
            _StudentIEPDataList = new List<StudentIEPData>();
            _bgLoadData.DoWork += _bgLoadData_DoWork;
            _bgLoadData.RunWorkerCompleted += _bgLoadData_RunWorkerCompleted;

            this.CancelButtonClick += delegate
            {
                OnPrimaryKeyChanged(new EventArgs());
            };
            this.SaveButtonClick += delegate
            {
                if (list.Count == 0)
                {
                    if (textBoxX1.Text != "")
                        new udt_student() { StudentID = int.Parse(PrimaryKey), Tag = textBoxX1.Text };
                }
                else
                {
                    if (textBoxX1.Text != "")
                    {
                        list[0].Tag = textBoxX1.Text;
                        list[0].Save();
                    }
                    else
                    {
                        list[0].Deleted = true;
                        list[0].Save();
                    }
                }
                OnPrimaryKeyChanged(new EventArgs());
            };
        }

        void _bgLoadData_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (_RunningID != PrimaryKey)
            {
                _RunningID = PrimaryKey;
                _bgLoadData.RunWorkerAsync();
                return;
            }
            this.Enabled = true;
            this.Loading = false;
            this.SaveButtonVisible = false;
            this.CancelButtonVisible = false;
            LoadDataToView();
            textBoxX1.Text = (list.Count == 0 ? "" : list[0].Tag);
        }

        private void LoadDataToView()
        {
            lvData.Items.Clear();
            foreach (StudentIEPData sd in _StudentIEPDataList)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Tag = sd;
                lvi.Text = sd.SchoolYear.ToString();
                lvi.SubItems.Add(sd.Semester.ToString());
                lvi.SubItems.Add(sd.CourseName);
                lvi.SubItems.Add(sd.TeacherName);

                lvData.Items.Add(lvi);
            }
        }

        void _bgLoadData_DoWork(object sender, DoWorkEventArgs e)
        {
            _StudentIEPDataList = QueryData.GetIEPDataByStudentID(_RunningID);
            list = accessHelper.Select<udt_student>("ref_student_id=" + _RunningID);
        }

        protected override void OnPrimaryKeyChanged(EventArgs e)
        {
            //BGRun();
            if (!_bgLoadData.IsBusy)
            {
                this.Enabled = false;
                this.Loading = true;
                _RunningID = PrimaryKey;
                _bgLoadData.RunWorkerAsync();
            }
        }

        //private void BGRun()
        //{
        //    if (_bgLoadData.IsBusy)
        //        _isBGBusy = true;
        //    else
        //        _bgLoadData.RunWorkerAsync();
        //}

        private void InputDataContent_Load(object sender, EventArgs e)
        {

        }

        private void lvData_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lvData_DoubleClick(object sender, EventArgs e)
        {
            if (lvData.SelectedItems.Count == 1)
            {
                StudentIEPData data = lvData.SelectedItems[0].Tag as StudentIEPData;
                if (data != null)
                {
                    UI.IEPInputDataForm iepIF = new UI.IEPInputDataForm();
                    iepIF.SetStudentData(data);
                    iepIF.ShowDialog();
                }
            }
        }

        private void textBoxX1_TextChanged(object sender, EventArgs e)
        {
            var orgText = (list.Count == 0 ? "" : list[0].Tag);
            if (textBoxX1.Text != orgText)
            {
                SaveButtonVisible = true;
                CancelButtonVisible = true;
            }
            else
            {
                SaveButtonVisible = false;
                CancelButtonVisible = false;
            }
        }
    }
}
