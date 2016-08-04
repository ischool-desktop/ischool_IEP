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
            foreach (udt_input_item data in _InputItemList)
            {
                int RowIdx = dgData.Rows.Add();
                dgData.Rows[RowIdx].Cells[colExamName.Index].Value = data.ExamName;
                dgData.Rows[RowIdx].Cells[colExamTypes.Index].Value = data.ExamTypes;
                dgData.Rows[RowIdx].Cells[colItem.Index].Value = data.Item;
                dgData.Rows[RowIdx].Cells[colOrder.Index].Value = data.Order;               
            }
            dgData.ResumeLayout(false);
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = false;
            SaveData();
            btnSave.Enabled = true;
        }

        private void SaveData()
        {
            bool hasError = false;
            List<string> chkStr = new List<string>();
            // 檢查資料是否重複
            foreach (DataGridViewRow row in dgData.Rows)
            {
                row.ErrorText = "";
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
                    row.ErrorText = "資料重複";
                    hasError = true;
                }
            }

            if(hasError)
            {
                FISCA.Presentation.Controls.MsgBox.Show("資料有問題無法儲存。");
                return;
            }

            // 儲存資料
            try
            {
                // 新增資料
                List<udt_input_item> addItemList = new List<udt_input_item>();
                foreach(DataGridViewRow drv in dgData.Rows)
                {
                    if (drv.IsNewRow)
                        continue;

                    udt_input_item item = new udt_input_item();
                    if (drv.Cells[colExamName.Index].Value == null)
                        item.ExamName = "";
                    else
                        item.ExamName = drv.Cells[colExamName.Index].Value.ToString();

                    if (drv.Cells[colExamTypes.Index].Value == null)
                        item.ExamTypes = "";
                    else
                        item.ExamTypes = drv.Cells[colExamTypes.Index].Value.ToString();

                    if (drv.Cells[colItem.Index].Value == null)
                        item.Item = "";
                    else
                        item.Item = drv.Cells[colItem.Index].Value.ToString();

                    if (drv.Cells[colOrder.Index].Value == null)
                        item.Order = null;
                    else
                    {
                        int num;
                        if(int.TryParse(drv.Cells[colOrder.Index].Value.ToString(),out num))
                        {
                            item.Order = num;
                        }
                    }

                    addItemList.Add(item);
                }

                addItemList.SaveAll();

                // 清除舊資料
                if(_InputItemList.Count > 0)
                {
                    foreach (udt_input_item item in _InputItemList)
                        item.Deleted = true;

                    _InputItemList.SaveAll();
                }
                lblMsg.Text = "";
                FISCA.Presentation.Controls.MsgBox.Show("儲存完成。");
                this.Close();
            }catch(Exception ex)
            {
                FISCA.Presentation.Controls.MsgBox.Show("儲存過程發生錯誤："+ex.Message);
            }

            
        }
        private void btnExport_Click(object sender, EventArgs e)
        {
            btnExport.Enabled = false;
            ExportDataGridViewToExcel();
            btnExport.Enabled = true;
        }

        private void ExportDataGridViewToExcel()
        {
            Workbook wb = new Workbook();
            Worksheet wst = wb.Worksheets[0];
            
            foreach(DataGridViewColumn col in dgData.Columns)
            {
                wst.Cells[0, col.Index].PutValue(col.HeaderText);                
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
            btnImport.Enabled = false;
            LoadExcelDataToForm();
            btnImport.Enabled = true;

        }

        private void LoadExcelDataToForm()
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Excel(*.xls)|*.xls";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    Workbook wb = new Workbook(ofd.FileName);
                    Worksheet wst = wb.Worksheets[0];

                    dgData.SuspendLayout();
                    dgData.Rows.Clear();
                    // 建立欄位對照
                    Dictionary<string, int> colIdxDict = new Dictionary<string, int>();
                    for (int col = 0; col <= wst.Cells.MaxDataColumn; col++)
                    {
                        string colName = wst.Cells[0, col].StringValue;
                        if (!colIdxDict.ContainsKey(colName))
                            colIdxDict.Add(colName, col);
                    }


                    // 讀取資料
                    for (int row = 1; row <= wst.Cells.MaxDataRow; row++)
                    {
                        int dgRowIdx = dgData.Rows.Add();
                        foreach (DataGridViewColumn dc in dgData.Columns)
                        {
                            if (colIdxDict.ContainsKey(dc.HeaderText))
                            {
                                dgData.Rows[dgRowIdx].Cells[dc.Index].Value = wst.Cells[row, colIdxDict[dc.HeaderText]].StringValue;
                            }
                        }
                    }

                    dgData.ResumeLayout(false);

                    lblMsg.Text = "資料已匯入畫面，尚未儲存!";
                }

            }catch(Exception ex)
            {
                FISCA.Presentation.Controls.MsgBox.Show("匯入過程發生錯誤：" + ex.Message);
            }
        }

        private void SetInputItemsForm_Load(object sender, EventArgs e)
        {
            _bgLoadData.RunWorkerAsync();
        }

    }
}
