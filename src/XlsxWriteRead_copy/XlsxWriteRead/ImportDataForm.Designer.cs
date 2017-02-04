namespace XlsxWriteRead
{
    partial class ImportDataForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dGv_XlsFiles = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.dGv_CaseList = new System.Windows.Forms.DataGridView();
            this.btn_DeleteCase = new System.Windows.Forms.Button();
            this.btn_DeleteFile = new System.Windows.Forms.Button();
            this.btn_ImportExcel = new System.Windows.Forms.Button();
            this.btn_ImportZip = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dGv_XlsFiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGv_CaseList)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(667, 578);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 23);
            this.btn_OK.TabIndex = 0;
            this.btn_OK.Text = "确定";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(761, 578);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 1;
            this.btn_Cancel.Text = "取消";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("楷体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(124, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 19);
            this.label1.TabIndex = 3;
            this.label1.Text = "案件";
            // 
            // dGv_XlsFiles
            // 
            this.dGv_XlsFiles.AllowUserToAddRows = false;
            this.dGv_XlsFiles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dGv_XlsFiles.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dGv_XlsFiles.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dGv_XlsFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGv_XlsFiles.Location = new System.Drawing.Point(354, 40);
            this.dGv_XlsFiles.MultiSelect = false;
            this.dGv_XlsFiles.Name = "dGv_XlsFiles";
            this.dGv_XlsFiles.ReadOnly = true;
            this.dGv_XlsFiles.RowHeadersVisible = false;
            this.dGv_XlsFiles.RowTemplate.Height = 23;
            this.dGv_XlsFiles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dGv_XlsFiles.Size = new System.Drawing.Size(307, 532);
            this.dGv_XlsFiles.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("楷体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(444, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 19);
            this.label2.TabIndex = 11;
            this.label2.Text = "Excel文件";
            // 
            // dGv_CaseList
            // 
            this.dGv_CaseList.AllowUserToAddRows = false;
            this.dGv_CaseList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dGv_CaseList.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dGv_CaseList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dGv_CaseList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGv_CaseList.Location = new System.Drawing.Point(6, 40);
            this.dGv_CaseList.MultiSelect = false;
            this.dGv_CaseList.Name = "dGv_CaseList";
            this.dGv_CaseList.ReadOnly = true;
            this.dGv_CaseList.RowHeadersVisible = false;
            this.dGv_CaseList.RowTemplate.Height = 23;
            this.dGv_CaseList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dGv_CaseList.Size = new System.Drawing.Size(343, 532);
            this.dGv_CaseList.TabIndex = 13;
            this.dGv_CaseList.SelectionChanged += new System.EventHandler(this.dGv_CaseList_SelectionChanged);
            // 
            // btn_DeleteCase
            // 
            this.btn_DeleteCase.Location = new System.Drawing.Point(128, 578);
            this.btn_DeleteCase.Name = "btn_DeleteCase";
            this.btn_DeleteCase.Size = new System.Drawing.Size(91, 23);
            this.btn_DeleteCase.TabIndex = 14;
            this.btn_DeleteCase.Text = "删除选中案件";
            this.btn_DeleteCase.UseVisualStyleBackColor = true;
            this.btn_DeleteCase.Click += new System.EventHandler(this.btn_DeleteCase_Click);
            // 
            // btn_DeleteFile
            // 
            this.btn_DeleteFile.Location = new System.Drawing.Point(435, 578);
            this.btn_DeleteFile.Name = "btn_DeleteFile";
            this.btn_DeleteFile.Size = new System.Drawing.Size(90, 23);
            this.btn_DeleteFile.TabIndex = 15;
            this.btn_DeleteFile.Text = "删除选中文件";
            this.btn_DeleteFile.UseVisualStyleBackColor = true;
            this.btn_DeleteFile.Click += new System.EventHandler(this.btn_DeleteFile_Click);
            // 
            // btn_ImportExcel
            // 
            this.btn_ImportExcel.Location = new System.Drawing.Point(761, 40);
            this.btn_ImportExcel.Name = "btn_ImportExcel";
            this.btn_ImportExcel.Size = new System.Drawing.Size(75, 23);
            this.btn_ImportExcel.TabIndex = 16;
            this.btn_ImportExcel.Text = "导入excel";
            this.btn_ImportExcel.UseVisualStyleBackColor = true;
            this.btn_ImportExcel.Click += new System.EventHandler(this.btn_ImportExcel_Click);
            // 
            // btn_ImportZip
            // 
            this.btn_ImportZip.Location = new System.Drawing.Point(667, 40);
            this.btn_ImportZip.Name = "btn_ImportZip";
            this.btn_ImportZip.Size = new System.Drawing.Size(75, 23);
            this.btn_ImportZip.TabIndex = 19;
            this.btn_ImportZip.Text = "导入压缩包";
            this.btn_ImportZip.UseVisualStyleBackColor = true;
            this.btn_ImportZip.Click += new System.EventHandler(this.btn_ImportZip_Click);
            // 
            // ImportDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(850, 610);
            this.Controls.Add(this.btn_ImportZip);
            this.Controls.Add(this.btn_ImportExcel);
            this.Controls.Add(this.btn_DeleteFile);
            this.Controls.Add(this.btn_DeleteCase);
            this.Controls.Add(this.dGv_CaseList);
            this.Controls.Add(this.dGv_XlsFiles);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_OK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ImportDataForm";
            this.Text = "ImportData";
            this.Load += new System.EventHandler(this.ImportDataForm_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ImportDataForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ImportDataForm_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.dGv_XlsFiles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGv_CaseList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dGv_XlsFiles;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dGv_CaseList;
        private System.Windows.Forms.Button btn_DeleteCase;
        private System.Windows.Forms.Button btn_DeleteFile;
        private System.Windows.Forms.Button btn_ImportExcel;
        private System.Windows.Forms.Button btn_ImportZip;
    }
}