namespace ischool_IEP.DetailContent
{
    partial class InputDataContent
    {
        /// <summary> 
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 元件設計工具產生的程式碼

        /// <summary> 
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.lvData = new DevComponents.DotNetBar.Controls.ListViewEx();
            this.colSchoolYear = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSemester = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCourseName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTeacherName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.textBoxX1 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.SuspendLayout();
            // 
            // lvData
            // 
            // 
            // 
            // 
            this.lvData.Border.Class = "ListViewBorder";
            this.lvData.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lvData.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colSchoolYear,
            this.colSemester,
            this.colCourseName,
            this.colTeacherName});
            this.lvData.FullRowSelect = true;
            this.lvData.Location = new System.Drawing.Point(13, 41);
            this.lvData.MultiSelect = false;
            this.lvData.Name = "lvData";
            this.lvData.Size = new System.Drawing.Size(524, 181);
            this.lvData.TabIndex = 0;
            this.lvData.UseCompatibleStateImageBehavior = false;
            this.lvData.View = System.Windows.Forms.View.Details;
            this.lvData.SelectedIndexChanged += new System.EventHandler(this.lvData_SelectedIndexChanged);
            this.lvData.DoubleClick += new System.EventHandler(this.lvData_DoubleClick);
            // 
            // colSchoolYear
            // 
            this.colSchoolYear.Text = "學年度";
            // 
            // colSemester
            // 
            this.colSemester.Text = "學期";
            // 
            // colCourseName
            // 
            this.colCourseName.Text = "課程名稱";
            this.colCourseName.Width = 300;
            // 
            // colTeacherName
            // 
            this.colTeacherName.Text = "教師姓名";
            this.colTeacherName.Width = 80;
            // 
            // textBoxX1
            // 
            // 
            // 
            // 
            this.textBoxX1.Border.Class = "TextBoxBorder";
            this.textBoxX1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxX1.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.textBoxX1.Location = new System.Drawing.Point(78, 10);
            this.textBoxX1.Name = "textBoxX1";
            this.textBoxX1.Size = new System.Drawing.Size(170, 25);
            this.textBoxX1.TabIndex = 3;
            this.textBoxX1.TextChanged += new System.EventHandler(this.textBoxX1_TextChanged);
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.Class = "";
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(13, 12);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(59, 21);
            this.labelX1.TabIndex = 2;
            this.labelX1.Text = "IEP 類別:";
            // 
            // InputDataContent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBoxX1);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.lvData);
            this.Name = "InputDataContent";
            this.Size = new System.Drawing.Size(550, 230);
            this.Load += new System.EventHandler(this.InputDataContent_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.ListViewEx lvData;
        private System.Windows.Forms.ColumnHeader colCourseName;
        private System.Windows.Forms.ColumnHeader colTeacherName;
        private System.Windows.Forms.ColumnHeader colSchoolYear;
        private System.Windows.Forms.ColumnHeader colSemester;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxX1;
        private DevComponents.DotNetBar.LabelX labelX1;

    }
}
