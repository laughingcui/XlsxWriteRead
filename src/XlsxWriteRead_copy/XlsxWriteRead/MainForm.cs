using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

//excel
using NPOI.HSSF.UserModel;
using NPOI.HPSF;
using NPOI.POIFS.FileSystem;
using NPOI.SS.UserModel;

//zip
using ZipDemo;

//mysql
using Mysql;

//
using Chinese2Pinyin;

namespace XlsxWriteRead
{
    /// <summary>
    /// sheet 对应 field 字段
    /// </summary>
    struct _SheetToFields
    {
        public string sheetName;
        public List<string> fieldsList;
    }

    /// <summary>
    /// excel文件名到sheet对应关系
    /// </summary>
    struct _TableInfo
    {
        public string fileName;  //excel文件名(个人信息)
        public List<_SheetToFields> sheetList; //存放sheet列表
    }

    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        /// <summary>
        /// 分析目录
        /// </summary>
        static string _analysisPath = @".\\analysis";
        /// <summary>
        /// 分析目录下所有xls文件
        /// </summary>
        static List<string> _filesList = new List<string>();  

        /// <summary>
        /// 目录下所有excel文件转换成拼音后存储列表
        /// </summary>
        static List<_TableInfo> DataBaseTableNameList = new List<_TableInfo>();


        private void button1_Click(object sender, EventArgs e)
        {
            //string time_string = "1/19/17 10:20";        //error
            //string time_string = "2017-01-19 10:20:01";  //ok
            //string time_string = "2017-01-19 10:20";       //ok
            //string time_string = "17-01-19 10:20";       //ok
            //string time_string = "2017年01月19日 10:20";       //ok
            //string time_string = "17/01/19 10:20";       //ok

            //DateTime time = new DateTime();
            //time = Convert.ToDateTime(time_string);

            if (tbx_database.Text == "")
            {
                MessageBox.Show("数据库名称不能为空");
                return;
            }
            if (tbx_user.Text == "")
            {
                MessageBox.Show("用户名不能为空");
                return;
            }
            if (tbx_pswd.Text == "")
            {
                MessageBox.Show("密码不能为空");
                return;
            }

            string conn = "Database='" + tbx_database.Text + "';Data Source='localhost';User Id='" + tbx_user.Text + "';Password='" + tbx_pswd.Text + "';charset='utf8';pooling=true";
            MySqlHelper.Conn = conn;
            
        }

        //创建案件
        private void btn_CreateCase_Click(object sender, EventArgs e)
        {
            CaseForm form = new CaseForm();
            form.StartPosition = FormStartPosition.CenterParent;
            if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

            }

            form.Dispose();
        }

        //导入数据
        private void btn_ImportData_Click(object sender, EventArgs e)
        {
            ImportDataForm form = new ImportDataForm();
            form.StartPosition = FormStartPosition.CenterParent;
            if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //MessageBox.Show("OK");
            }

            //form.Dispose();
        }

        //创建分析规则
        private void btn_CustomRule_Click(object sender, EventArgs e)
        {
            CustomRuleForm form = new CustomRuleForm();
            form.StartPosition = FormStartPosition.CenterParent;
            if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                
            }

            form.Dispose();
        }

        private void btn_AnalysisForm_Click(object sender, EventArgs e)
        {
            NewRuleForm form = new NewRuleForm();
            if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                
            }
        }

        private void btn_quit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            Common.MouseDownForm(this, e);
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            Common.MouseMoveForm(this, e);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void tbx_database_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbx_user_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void tbx_pswd_TextChanged(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }
    }
}
