namespace XlsxWriteRead
{
    partial class CustomRuleForm
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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dGv_Sheets = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.dGv_Fields = new System.Windows.Forms.DataGridView();
            this.dGv_CaseList = new System.Windows.Forms.DataGridView();
            this.dGv_XlsFiles = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dGv_RuleDetail = new System.Windows.Forms.DataGridView();
            this.dGv_RuleList = new System.Windows.Forms.DataGridView();
            this.btn_CreateCustom = new System.Windows.Forms.Button();
            this.btn_DeleteCustom = new System.Windows.Forms.Button();
            this.btn_AddCollisionItems = new System.Windows.Forms.Button();
            this.btn_Ok = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dGv_Sheets)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGv_Fields)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGv_CaseList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGv_XlsFiles)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGv_RuleDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGv_RuleList)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("楷体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(756, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 19);
            this.label3.TabIndex = 8;
            this.label3.Text = "Sheet信息";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("楷体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(497, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 19);
            this.label2.TabIndex = 7;
            this.label2.Text = "Excel文件";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("楷体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(169, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 19);
            this.label1.TabIndex = 6;
            this.label1.Text = "案件";
            // 
            // dGv_Sheets
            // 
            this.dGv_Sheets.AllowUserToAddRows = false;
            this.dGv_Sheets.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dGv_Sheets.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dGv_Sheets.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dGv_Sheets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGv_Sheets.Location = new System.Drawing.Point(704, 40);
            this.dGv_Sheets.MultiSelect = false;
            this.dGv_Sheets.Name = "dGv_Sheets";
            this.dGv_Sheets.ReadOnly = true;
            this.dGv_Sheets.RowHeadersVisible = false;
            this.dGv_Sheets.RowTemplate.Height = 23;
            this.dGv_Sheets.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dGv_Sheets.Size = new System.Drawing.Size(209, 293);
            this.dGv_Sheets.TabIndex = 10;
            this.dGv_Sheets.SelectionChanged += new System.EventHandler(this.dGv_Sheets_SelectionChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("楷体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(985, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 19);
            this.label4.TabIndex = 8;
            this.label4.Text = "字段信息";
            // 
            // dGv_Fields
            // 
            this.dGv_Fields.AllowUserToAddRows = false;
            this.dGv_Fields.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dGv_Fields.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dGv_Fields.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGv_Fields.Location = new System.Drawing.Point(919, 40);
            this.dGv_Fields.Name = "dGv_Fields";
            this.dGv_Fields.ReadOnly = true;
            this.dGv_Fields.RowHeadersVisible = false;
            this.dGv_Fields.RowTemplate.Height = 23;
            this.dGv_Fields.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dGv_Fields.Size = new System.Drawing.Size(218, 293);
            this.dGv_Fields.TabIndex = 10;
            this.dGv_Fields.SelectionChanged += new System.EventHandler(this.dGv_Fields_SelectionChanged);
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
            this.dGv_CaseList.Size = new System.Drawing.Size(405, 293);
            this.dGv_CaseList.TabIndex = 15;
            this.dGv_CaseList.SelectionChanged += new System.EventHandler(this.dGv_CaseList_SelectionChanged);
            // 
            // dGv_XlsFiles
            // 
            this.dGv_XlsFiles.AllowUserToAddRows = false;
            this.dGv_XlsFiles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dGv_XlsFiles.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dGv_XlsFiles.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dGv_XlsFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGv_XlsFiles.Location = new System.Drawing.Point(417, 40);
            this.dGv_XlsFiles.MultiSelect = false;
            this.dGv_XlsFiles.Name = "dGv_XlsFiles";
            this.dGv_XlsFiles.ReadOnly = true;
            this.dGv_XlsFiles.RowHeadersVisible = false;
            this.dGv_XlsFiles.RowTemplate.Height = 23;
            this.dGv_XlsFiles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dGv_XlsFiles.Size = new System.Drawing.Size(281, 293);
            this.dGv_XlsFiles.TabIndex = 16;
            this.dGv_XlsFiles.SelectionChanged += new System.EventHandler(this.dGv_XlsFiles_SelectionChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.dGv_RuleDetail);
            this.groupBox1.Controls.Add(this.dGv_RuleList);
            this.groupBox1.Controls.Add(this.btn_CreateCustom);
            this.groupBox1.Controls.Add(this.btn_DeleteCustom);
            this.groupBox1.Controls.Add(this.btn_AddCollisionItems);
            this.groupBox1.Font = new System.Drawing.Font("新宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox1.Location = new System.Drawing.Point(6, 330);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1133, 362);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("楷体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.Location = new System.Drawing.Point(836, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 19);
            this.label6.TabIndex = 17;
            this.label6.Text = "范围";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("楷体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(216, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 19);
            this.label5.TabIndex = 16;
            this.label5.Text = "规则";
            // 
            // dGv_RuleDetail
            // 
            this.dGv_RuleDetail.AllowUserToAddRows = false;
            this.dGv_RuleDetail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dGv_RuleDetail.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dGv_RuleDetail.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dGv_RuleDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGv_RuleDetail.Location = new System.Drawing.Point(541, 33);
            this.dGv_RuleDetail.MultiSelect = false;
            this.dGv_RuleDetail.Name = "dGv_RuleDetail";
            this.dGv_RuleDetail.ReadOnly = true;
            this.dGv_RuleDetail.RowHeadersVisible = false;
            this.dGv_RuleDetail.RowTemplate.Height = 23;
            this.dGv_RuleDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dGv_RuleDetail.Size = new System.Drawing.Size(587, 321);
            this.dGv_RuleDetail.TabIndex = 15;
            // 
            // dGv_RuleList
            // 
            this.dGv_RuleList.AllowUserToAddRows = false;
            this.dGv_RuleList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dGv_RuleList.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dGv_RuleList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dGv_RuleList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGv_RuleList.Location = new System.Drawing.Point(5, 33);
            this.dGv_RuleList.MultiSelect = false;
            this.dGv_RuleList.Name = "dGv_RuleList";
            this.dGv_RuleList.ReadOnly = true;
            this.dGv_RuleList.RowHeadersVisible = false;
            this.dGv_RuleList.RowTemplate.Height = 23;
            this.dGv_RuleList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dGv_RuleList.Size = new System.Drawing.Size(530, 321);
            this.dGv_RuleList.TabIndex = 11;
            this.dGv_RuleList.SelectionChanged += new System.EventHandler(this.dGv_RuleList_SelectionChanged);
            // 
            // btn_CreateCustom
            // 
            this.btn_CreateCustom.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_CreateCustom.Location = new System.Drawing.Point(273, 11);
            this.btn_CreateCustom.Name = "btn_CreateCustom";
            this.btn_CreateCustom.Size = new System.Drawing.Size(89, 23);
            this.btn_CreateCustom.TabIndex = 13;
            this.btn_CreateCustom.Text = "添加规则";
            this.btn_CreateCustom.UseVisualStyleBackColor = true;
            this.btn_CreateCustom.Click += new System.EventHandler(this.btn_CreateCustom_Click);
            // 
            // btn_DeleteCustom
            // 
            this.btn_DeleteCustom.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_DeleteCustom.Location = new System.Drawing.Point(362, 11);
            this.btn_DeleteCustom.Name = "btn_DeleteCustom";
            this.btn_DeleteCustom.Size = new System.Drawing.Size(89, 23);
            this.btn_DeleteCustom.TabIndex = 13;
            this.btn_DeleteCustom.Text = "删除规则";
            this.btn_DeleteCustom.UseVisualStyleBackColor = true;
            this.btn_DeleteCustom.Click += new System.EventHandler(this.btn_DeleteCustom_Click);
            // 
            // btn_AddCollisionItems
            // 
            this.btn_AddCollisionItems.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_AddCollisionItems.Location = new System.Drawing.Point(893, 11);
            this.btn_AddCollisionItems.Name = "btn_AddCollisionItems";
            this.btn_AddCollisionItems.Size = new System.Drawing.Size(89, 23);
            this.btn_AddCollisionItems.TabIndex = 13;
            this.btn_AddCollisionItems.Text = "添加范围";
            this.btn_AddCollisionItems.UseVisualStyleBackColor = true;
            this.btn_AddCollisionItems.Click += new System.EventHandler(this.btn_AddCollisionItems_Click);
            // 
            // btn_Ok
            // 
            this.btn_Ok.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_Ok.Location = new System.Drawing.Point(452, 695);
            this.btn_Ok.Name = "btn_Ok";
            this.btn_Ok.Size = new System.Drawing.Size(89, 23);
            this.btn_Ok.TabIndex = 0;
            this.btn_Ok.Text = "确定";
            this.btn_Ok.UseVisualStyleBackColor = true;
            this.btn_Ok.Click += new System.EventHandler(this.btn_Ok_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_Cancel.Location = new System.Drawing.Point(547, 695);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(89, 23);
            this.btn_Cancel.TabIndex = 1;
            this.btn_Cancel.Text = "取消";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // CustomRuleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(1146, 719);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dGv_XlsFiles);
            this.Controls.Add(this.dGv_CaseList);
            this.Controls.Add(this.dGv_Fields);
            this.Controls.Add(this.dGv_Sheets);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Ok);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CustomRuleForm";
            this.Text = "CustomRuleForm";
            this.Load += new System.EventHandler(this.CustomRuleForm_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CustomRuleForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CustomRuleForm_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.dGv_Sheets)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGv_Fields)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGv_CaseList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGv_XlsFiles)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGv_RuleDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGv_RuleList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dGv_Sheets;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dGv_Fields;
        private System.Windows.Forms.DataGridView dGv_CaseList;
        private System.Windows.Forms.DataGridView dGv_XlsFiles;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dGv_RuleDetail;
        private System.Windows.Forms.DataGridView dGv_RuleList;
        private System.Windows.Forms.Button btn_CreateCustom;
        private System.Windows.Forms.Button btn_DeleteCustom;
        private System.Windows.Forms.Button btn_AddCollisionItems;
        private System.Windows.Forms.Button btn_Ok;
        private System.Windows.Forms.Button btn_Cancel;
    }
}