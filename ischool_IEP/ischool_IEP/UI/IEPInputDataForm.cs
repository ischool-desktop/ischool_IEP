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

            StringBuilder sb = new StringBuilder();
            foreach (string examName in _StudentIEPData.ExamContent.Keys)
            {
                sb.AppendLine(examName);

                foreach (string type in _StudentIEPData.ExamContent[examName].Keys)
                {                    
                    //sb.AppendLine(type+"："+_StudentIEPData.ExamContent[examName][type]);
                    sb.AppendLine("\t" + (type == "" ? "描述內容" : type) + "：");

                    foreach (string content in _StudentIEPData.ExamContent[examName][type])
                    {
                        sb.AppendLine("\t\t" + content.ToString().Replace("\",\"", "").Trim('[', ']', '"'));
                    }                    
                }
            }

            txtItemValue.Text = sb.ToString();
        }
    }
}
