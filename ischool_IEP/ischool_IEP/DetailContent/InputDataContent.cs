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


namespace ischool_IEP.DetailContent
{
    [FISCA.Permission.FeatureCode("ischool_IEP_InputDataContent", "IEP 輸入資料")]
    public partial class InputDataContent : FISCA.Presentation.DetailContent
    {
        bool _isBGBusy = false;
        BackgroundWorker _bgLoadData;

        List<StudentIEPData> _StudentIEPDataList;

        public InputDataContent()
        {
            InitializeComponent();
            Group = "IEP輸入結果";
            _bgLoadData = new BackgroundWorker();
            _StudentIEPDataList = new List<StudentIEPData>();
            _bgLoadData.DoWork += _bgLoadData_DoWork;
            _bgLoadData.RunWorkerCompleted += _bgLoadData_RunWorkerCompleted;
        }

        void _bgLoadData_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if(_isBGBusy)
            {
                _isBGBusy = false;
                _bgLoadData.RunWorkerAsync();
                return;
            }
            this.Loading = false;
            LoadDataToView();
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
            _StudentIEPDataList = QueryData.GetIEPDataByStudentID(PrimaryKey);
        }

        protected override void OnPrimaryKeyChanged(EventArgs e)
        {
            this.Loading = true;
            BGRun();
        }

        private void BGRun()
        {
            if (_bgLoadData.IsBusy)
                _isBGBusy = true;
            else
                _bgLoadData.RunWorkerAsync();
        }

        private void InputDataContent_Load(object sender, EventArgs e)
        {

        }

        private void lvData_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lvData_DoubleClick(object sender, EventArgs e)
        {
            if(lvData.SelectedItems.Count ==1)
            {
                StudentIEPData data = lvData.SelectedItems[0].Tag as StudentIEPData;
                if(data != null)
                {
                    UI.IEPInputDataForm iepIF = new UI.IEPInputDataForm();
                    iepIF.SetStudentData(data);
                    iepIF.ShowDialog();
                }
            }
        }

        
    }
}
