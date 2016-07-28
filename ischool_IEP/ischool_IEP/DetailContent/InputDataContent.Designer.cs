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
            this.colCourseName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTeacherName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colExamName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colExamTypes = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colItemValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
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
            this.colCourseName,
            this.colTeacherName,
            this.colExamName,
            this.colExamTypes,
            this.colItemValue});
            this.lvData.FullRowSelect = true;
            this.lvData.Location = new System.Drawing.Point(28, 24);
            this.lvData.MultiSelect = false;
            this.lvData.Name = "lvData";
            this.lvData.Size = new System.Drawing.Size(492, 150);
            this.lvData.TabIndex = 0;
            this.lvData.UseCompatibleStateImageBehavior = false;
            this.lvData.View = System.Windows.Forms.View.Details;
            this.lvData.SelectedIndexChanged += new System.EventHandler(this.lvData_SelectedIndexChanged);
            this.lvData.DoubleClick += new System.EventHandler(this.lvData_DoubleClick);
            // 
            // colCourseName
            // 
            this.colCourseName.Text = "課程名稱";
            this.colCourseName.Width = 100;
            // 
            // colTeacherName
            // 
            this.colTeacherName.Text = "教師姓名";
            this.colTeacherName.Width = 80;
            // 
            // colExamName
            // 
            this.colExamName.Text = "試別名稱";
            this.colExamName.Width = 80;
            // 
            // colExamTypes
            // 
            this.colExamTypes.Text = "試別類型";
            this.colExamTypes.Width = 80;
            // 
            // colItemValue
            // 
            this.colItemValue.Text = "輸入內容";
            this.colItemValue.Width = 150;
            // 
            // InputDataContent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lvData);
            this.Name = "InputDataContent";
            this.Size = new System.Drawing.Size(550, 195);
            this.Load += new System.EventHandler(this.InputDataContent_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.ListViewEx lvData;
        private System.Windows.Forms.ColumnHeader colCourseName;
        private System.Windows.Forms.ColumnHeader colTeacherName;
        private System.Windows.Forms.ColumnHeader colExamName;
        private System.Windows.Forms.ColumnHeader colExamTypes;
        private System.Windows.Forms.ColumnHeader colItemValue;

    }
}
