using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FISCA.Presentation.Controls;
using FISCA.UDT;
using ischool_IEP.DAO;
using Aspose.Cells;

namespace ischool_IEP.UI
{
    public partial class SetInputItemsForm : BaseForm
    {
        BackgroundWorker _bgLoadData;
        List<udt_input_item> _InputItemList;

        public SetInputItemsForm()
        {
            InitializeComponent();
            _bgLoadData = new BackgroundWorker();
            _bgLoadData.DoWork += _bgLoadData_DoWork;
            _bgLoadData.RunWorkerCompleted += _bgLoadData_RunWorkerCompleted;
        }

        void _bgLoadData_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            LoadDataToForm();
        }

        void _bgLoadData_DoWork(object sender, DoWorkEventArgs e)
        {
            // 取得項目資料
            _InputItemList = UDTTransfer.GetInputItemList();
        }

        private void LoadDataToForm()
        {
            dgData.Rows.Clear();
            dgData.SuspendLayout();
            foreach(var data in _InputItemList)
            {
                int RowIdx = dgData.Rows.Add();
                dgData.Rows[RowIdx].Cells[colExamName.Index].Value = data.ExamName;
                dgData.Rows[RowIdx].Cells[colExamTypes.Index].Value = data.ExamTypes;
                dgData.Rows[RowIdx].Cells[colItem.Index].Value = data.Item;
            }
            dgData.ResumeLayout(false);
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void SaveData()
        {
            List<string> chkStr = new List<string>();
            // 檢查資料是否重複
            foreach (DataGridViewRow row in dgData.Rows)
            {
                if (row.IsNewRow)
                    continue;

                string key = "";
                foreach(DataGridViewCell cell in row.Cells)
                {
                    if(cell.Value != null)
                     key += cell.Value.ToString();
                }

                if (!chkStr.Contains(key))
                    chkStr.Add(key);
                else
                {
                    MsgBox.Show("資料重複!");
                    return;
                }
            }

            // 儲存資料
            
        }
        private void btnExport_Click(object sender, EventArgs e)
        {
            ExportDataGridViewToExcel();
        }

        private void ExportDataGridViewToExcel()
        {
            Workbook wb = new Workbook();
            Worksheet wst = wb.Worksheets[0];
            
            foreach(DataGridViewColumn col in dgData.Columns)
            {
                wst.Cells[0, col.Index].PutValue(col.Name);                
            }

            int rowIdx = 1;
            foreach(DataGridViewRow data in dgData.Rows)
            {
                if (data.IsNewRow)
                    continue;
                
                foreach(DataGridViewCell cell in data.Cells)
                {
                    if (cell.Value !=null)
                    {
                        wst.Cells[rowIdx, cell.ColumnIndex].PutValue(cell.Value.ToString());
                    }
                }

                rowIdx++;
            }

            Utility.ExprotXls("匯出輸入項目選項", wb);
        }

        private void btnImport_Click(object sender, EventArgs e)
        {

        }

        private void LoadExcelDataToForm()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Excel(*.xls)|*.xls";
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                Workbook wb = new Workbook(ofd.FileName);
                dgData.Rows.Clear();

                
                
            }
        }
    }
}
