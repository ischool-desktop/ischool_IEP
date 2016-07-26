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

namespace ischool_IEP.UI
{
    public partial class SetOpenDatetimeForm : BaseForm
    {
        udt_open_datetime _udt_open_datetime;
        string _DTFormat = "yyyy/MM/dd HH:mm:ss";
        public SetOpenDatetimeForm()
        {
            InitializeComponent();
            _udt_open_datetime = new udt_open_datetime();
        }

        private void SetOpenDatetimeForm_Load(object sender, EventArgs e)
        {
            this.MaximumSize = this.MinimumSize = this.Size;
            LoadUDTDataToForm();
        }

        private void LoadUDTDataToForm()
        {
            _udt_open_datetime = UDTTransfer.GetOpenDateTime();

            // 如果西元年過小初始給當天           
            if (_udt_open_datetime.BeginDate.Year < 2000)
                _udt_open_datetime.BeginDate = DateTime.Now;

            if (_udt_open_datetime.EndDate.Year < 2000)
                _udt_open_datetime.EndDate = DateTime.Now;
                
            txtBeginDate.Text = _udt_open_datetime.BeginDate.ToString(_DTFormat);
            txtEndDate.Text = _udt_open_datetime.EndDate.ToString(_DTFormat);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveData()
        {
            // 檢查資料是否輸入
            DateTime bt, edt;
            
            if(DateTime.TryParse(txtBeginDate.Text,out bt))
            {
                _udt_open_datetime.BeginDate = bt;
            }
            else
            {
                FISCA.Presentation.Controls.MsgBox.Show("開始日期有錯誤，無法儲存。");
                return;
            }

            if(DateTime.TryParse(txtEndDate.Text,out edt))
            {
                _udt_open_datetime.EndDate = edt;
            }
            else
            {
                FISCA.Presentation.Controls.MsgBox.Show("結束日期有錯誤，無法儲存。");
                return;
            }

            try
            {
                _udt_open_datetime.Save();
                FISCA.Presentation.Controls.MsgBox.Show("儲存成功");
                this.Close();
                
            }catch (Exception ex)
            {
                FISCA.Presentation.Controls.MsgBox.Show("儲存失敗。" + ex.Message);
                return;
            }            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveData();
        }
    }
}
