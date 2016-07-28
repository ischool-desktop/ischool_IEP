using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ischool_IEP.DAO;

namespace ischool_IEP.UI
{
    public partial class IEPInputDataForm : FISCA.Presentation.Controls.BaseForm
    {
        StudentIEPData _StudentIEPData = new StudentIEPData();
        
        public IEPInputDataForm()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void SetStudentData(StudentIEPData data)
        {
            _StudentIEPData = data;
        }

        private void IEPInputDataForm_Load(object sender, EventArgs e)
        {
            LoadDataToForm();
        }

        private void LoadDataToForm()
        {
            txtCourseName.Text = _StudentIEPData.CourseName;
            txtTeacherName.Text = _StudentIEPData.TeacherName;
            txtExamName.Text = _StudentIEPData.ExamName;
            txtExamTypes.Text = _StudentIEPData.ExamTypes;
            txtItemValue.Text = _StudentIEPData.ItemValue;
        }
    }
}
