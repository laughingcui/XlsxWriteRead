namespace XlsxWriteRead
{
    partial class NewRuleForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btn_Ok = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.dGv_RuleDetail = new System.Windows.Forms.DataGridView();
            this.dGv_RuleList = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tBx_ResultInfo = new System.Windows.Forms.TextBox();
            this.btn_Analysis = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dGv_RuleDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGv_RuleList)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Ok
            // 
            this.btn_Ok.Location = new System.Drawing.Point(477, 631);
            this.btn_Ok.Name = "btn_Ok";
            this.btn_Ok.Size = new System.Drawing.Size(75, 23);
            this.btn_Ok.TabIndex = 0;
            this.btn_Ok.Text = "确定";
            this.btn_Ok.UseVisualStyleBackColor = true;
            this.btn_Ok.Click += new System.EventHandler(this.btn_Ok_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(582, 631);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 1;
            this.btn_Cancel.Text = "取消";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // dGv_RuleDetail
            // 
            this.dGv_RuleDetail.AllowUserToAddRows = false;
            this.dGv_RuleDetail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dGv_RuleDetail.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dGv_RuleDetail.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dGv_RuleDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dGv_RuleDetail.DefaultCellStyle = dataGridViewCellStyle1;
            this.dGv_RuleDetail.Location = new System.Drawing.Point(606, 34);
            this.dGv_RuleDetail.MultiSelect = false;
            this.dGv_RuleDetail.Name = "dGv_RuleDetail";
            this.dGv_RuleDetail.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.MenuHighlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dGv_RuleDetail.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dGv_RuleDetail.RowHeadersVisible = false;
            this.dGv_RuleDetail.RowTemplate.Height = 23;
            this.dGv_RuleDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dGv_RuleDetail.Size = new System.Drawing.Size(540, 315);
            this.dGv_RuleDetail.TabIndex = 17;
            // 
            // dGv_RuleList
            // 
            this.dGv_RuleList.AllowUserToAddRows = false;
            this.dGv_RuleList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dGv_RuleList.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dGv_RuleList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dGv_RuleList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGv_RuleList.Location = new System.Drawing.Point(6, 34);
            this.dGv_RuleList.MultiSelect = false;
            this.dGv_RuleList.Name = "dGv_RuleList";
            this.dGv_RuleList.ReadOnly = true;
            this.dGv_RuleList.RowHeadersVisible = false;
            this.dGv_RuleList.RowTemplate.Height = 23;
            this.dGv_RuleList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dGv_RuleList.Size = new System.Drawing.Size(500, 315);
            this.dGv_RuleList.TabIndex = 16;
            this.dGv_RuleList.SelectionChanged += new System.EventHandler(this.dGv_RuleList_SelectionChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("楷体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.Location = new System.Drawing.Point(607, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 19);
            this.label6.TabIndex = 19;
            this.label6.Text = "范围";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("楷体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(2, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 19);
            this.label5.TabIndex = 18;
            this.label5.Text = "规则";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("楷体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(4, 362);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 19);
            this.label1.TabIndex = 20;
            this.label1.Text = "分析结果";
            // 
            // tBx_ResultInfo
            // 
            this.tBx_ResultInfo.BackColor = System.Drawing.SystemColors.Info;
            this.tBx_ResultInfo.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tBx_ResultInfo.Location = new System.Drawing.Point(8, 384);
            this.tBx_ResultInfo.Multiline = true;
            this.tBx_ResultInfo.Name = "tBx_ResultInfo";
            this.tBx_ResultInfo.ReadOnly = true;
            this.tBx_ResultInfo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tBx_ResultInfo.Size = new System.Drawing.Size(1138, 241);
            this.tBx_ResultInfo.TabIndex = 21;
            // 
            // btn_Analysis
            // 
            this.btn_Analysis.Location = new System.Drawing.Point(520, 326);
            this.btn_Analysis.Name = "btn_Analysis";
            this.btn_Analysis.Size = new System.Drawing.Size(75, 23);
            this.btn_Analysis.TabIndex = 22;
            this.btn_Analysis.Text = "分析";
            this.btn_Analysis.UseVisualStyleBackColor = true;
            this.btn_Analysis.Click += new System.EventHandler(this.btn_Analysis_Click);
            // 
            // NewRuleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(1152, 660);
            this.Controls.Add(this.btn_Analysis);
            this.Controls.Add(this.tBx_ResultInfo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dGv_RuleDetail);
            this.Controls.Add(this.dGv_RuleList);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Ok);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "NewRuleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "NewRuleForm";
            this.Load += new System.EventHandler(this.NewRuleForm_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.NewRuleForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.NewRuleForm_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.dGv_RuleDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGv_RuleList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Ok;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.DataGridView dGv_RuleDetail;
        private System.Windows.Forms.DataGridView dGv_RuleList;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tBx_ResultInfo;
        private System.Windows.Forms.Button btn_Analysis;
    }
}