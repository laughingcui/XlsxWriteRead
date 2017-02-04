namespace XlsxWriteRead
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.dataSet1 = new System.Data.DataSet();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tbx_database = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbx_pswd = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbx_user = new System.Windows.Forms.TextBox();
            this.btn_AnalysisForm = new System.Windows.Forms.Button();
            this.btn_CustomRule = new System.Windows.Forms.Button();
            this.btn_ImportData = new System.Windows.Forms.Button();
            this.btn_CreateCase = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_quit = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "NewDataSet";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // tbx_database
            // 
            this.tbx_database.Location = new System.Drawing.Point(65, 49);
            this.tbx_database.Name = "tbx_database";
            this.tbx_database.Size = new System.Drawing.Size(100, 21);
            this.tbx_database.TabIndex = 12;
            this.tbx_database.Text = "casedata";
            this.tbx_database.TextChanged += new System.EventHandler(this.tbx_database_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 13;
            this.label1.Text = "数据库：";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(319, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 14;
            this.label2.Text = "密码：";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // tbx_pswd
            // 
            this.tbx_pswd.Location = new System.Drawing.Point(360, 49);
            this.tbx_pswd.Name = "tbx_pswd";
            this.tbx_pswd.Size = new System.Drawing.Size(100, 21);
            this.tbx_pswd.TabIndex = 15;
            this.tbx_pswd.Text = "123456";
            this.tbx_pswd.TextChanged += new System.EventHandler(this.tbx_pswd_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(169, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 17;
            this.label3.Text = "用户名：";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // tbx_user
            // 
            this.tbx_user.Location = new System.Drawing.Point(215, 48);
            this.tbx_user.Name = "tbx_user";
            this.tbx_user.Size = new System.Drawing.Size(100, 21);
            this.tbx_user.TabIndex = 18;
            this.tbx_user.Text = "root";
            this.tbx_user.TextChanged += new System.EventHandler(this.tbx_user_TextChanged);
            // 
            // btn_AnalysisForm
            // 
            this.btn_AnalysisForm.BackgroundImage = global::XlsxWriteRead.Properties.Resources.analysis;
            this.btn_AnalysisForm.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.btn_AnalysisForm.Location = new System.Drawing.Point(516, 42);
            this.btn_AnalysisForm.Name = "btn_AnalysisForm";
            this.btn_AnalysisForm.Size = new System.Drawing.Size(128, 128);
            this.btn_AnalysisForm.TabIndex = 0;
            this.btn_AnalysisForm.Text = "分析";
            this.btn_AnalysisForm.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_AnalysisForm.UseVisualStyleBackColor = true;
            this.btn_AnalysisForm.Click += new System.EventHandler(this.btn_AnalysisForm_Click);
            // 
            // btn_CustomRule
            // 
            this.btn_CustomRule.BackgroundImage = global::XlsxWriteRead.Properties.Resources.custom;
            this.btn_CustomRule.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.btn_CustomRule.Location = new System.Drawing.Point(348, 42);
            this.btn_CustomRule.Name = "btn_CustomRule";
            this.btn_CustomRule.Size = new System.Drawing.Size(128, 128);
            this.btn_CustomRule.TabIndex = 0;
            this.btn_CustomRule.Text = "定制规则";
            this.btn_CustomRule.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_CustomRule.UseVisualStyleBackColor = true;
            this.btn_CustomRule.Click += new System.EventHandler(this.btn_CustomRule_Click);
            // 
            // btn_ImportData
            // 
            this.btn_ImportData.BackgroundImage = global::XlsxWriteRead.Properties.Resources.import;
            this.btn_ImportData.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.btn_ImportData.Location = new System.Drawing.Point(180, 42);
            this.btn_ImportData.Name = "btn_ImportData";
            this.btn_ImportData.Size = new System.Drawing.Size(128, 128);
            this.btn_ImportData.TabIndex = 0;
            this.btn_ImportData.Text = "导入数据";
            this.btn_ImportData.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_ImportData.UseVisualStyleBackColor = true;
            this.btn_ImportData.Click += new System.EventHandler(this.btn_ImportData_Click);
            // 
            // btn_CreateCase
            // 
            this.btn_CreateCase.BackgroundImage = global::XlsxWriteRead.Properties.Resources._new;
            this.btn_CreateCase.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_CreateCase.Location = new System.Drawing.Point(12, 42);
            this.btn_CreateCase.Name = "btn_CreateCase";
            this.btn_CreateCase.Size = new System.Drawing.Size(128, 128);
            this.btn_CreateCase.TabIndex = 0;
            this.btn_CreateCase.Text = "创建案件";
            this.btn_CreateCase.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_CreateCase.UseVisualStyleBackColor = true;
            this.btn_CreateCase.Click += new System.EventHandler(this.btn_CreateCase_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_quit);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.tbx_database);
            this.groupBox1.Controls.Add(this.tbx_user);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbx_pswd);
            this.groupBox1.Location = new System.Drawing.Point(5, 183);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(646, 100);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "数据库配置";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btn_quit
            // 
            this.btn_quit.BackgroundImage = global::XlsxWriteRead.Properties.Resources.quit;
            this.btn_quit.Location = new System.Drawing.Point(574, 25);
            this.btn_quit.Name = "btn_quit";
            this.btn_quit.Size = new System.Drawing.Size(64, 64);
            this.btn_quit.TabIndex = 24;
            this.btn_quit.UseVisualStyleBackColor = true;
            this.btn_quit.Click += new System.EventHandler(this.btn_quit_Click);
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::XlsxWriteRead.Properties.Resources.dbset;
            this.button1.Location = new System.Drawing.Point(478, 25);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(64, 64);
            this.button1.TabIndex = 16;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(656, 309);
            this.Controls.Add(this.btn_AnalysisForm);
            this.Controls.Add(this.btn_CustomRule);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_ImportData);
            this.Controls.Add(this.btn_CreateCase);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Excel Analysis Demo";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Data.DataSet dataSet1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox tbx_database;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbx_pswd;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbx_user;
        private System.Windows.Forms.Button btn_CreateCase;
        private System.Windows.Forms.Button btn_CustomRule;
        private System.Windows.Forms.Button btn_ImportData;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_quit;
        private System.Windows.Forms.Button btn_AnalysisForm;
    }
}

