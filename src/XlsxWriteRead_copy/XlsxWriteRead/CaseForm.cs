using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Mysql;

namespace XlsxWriteRead
{
    public partial class CaseForm : Form
    {
        public CaseForm()
        {
            InitializeComponent();
        }

        private void btn_CreateCase_Click(object sender, EventArgs e)
        {
            //创建案件
            string case_name = tBx_CaseName.Text;
            string case_no = tBx_CaseNo.Text;
            string case_author = tBx_Creator.Text;
            string case_date = dt_Date.Value.ToString("yyyy-MM-dd HH:mm:ss");  //c#中存储数据库时间按照这个格式
            

            if (case_name.Trim() == "" || case_no.Trim() == "" || case_author.Trim() == "")
            {
                MessageBox.Show("请填写完成信息");
                return;
            }

            StringBuilder sql_builder = new StringBuilder();
            
            //验证案件编号是否存在
            sql_builder.Append("select count(*) from case_list where case_no='");
            sql_builder.Append(case_no + "';");

            string sql = sql_builder.ToString();
            int case_no_count = Convert.ToInt32(MySqlHelper.ExecuteScalar(MySqlHelper.Conn, CommandType.Text, sql).ToString());
            if (case_no_count >= 1)
            {
                MessageBox.Show("案件编号已存在,重新输入");
                return;
            }

            //插入数据
            sql_builder.Clear();
            sql_builder.Append("insert into case_list(case_name, case_no, case_date, author) ");
            sql_builder.Append("values('" + case_name + "', '" + case_no + "', '" + case_date + "', '" + case_author + "');");
            sql = sql_builder.ToString();

            MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sql);

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void CaseForm_MouseDown(object sender, MouseEventArgs e)
        {
            Common.MouseDownForm(this, e);
        }

        private void CaseForm_MouseMove(object sender, MouseEventArgs e)
        {
            Common.MouseMoveForm(this, e);
        }
    }
}
