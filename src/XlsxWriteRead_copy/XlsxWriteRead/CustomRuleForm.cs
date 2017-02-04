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
    public partial class CustomRuleForm : Form
    {
        public CustomRuleForm()
        {
            InitializeComponent();
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;

            this.Close();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;

            this.Close();
        }

        private void CustomRuleForm_MouseDown(object sender, MouseEventArgs e)
        {
            Common.MouseDownForm(this, e);
        }

        private void CustomRuleForm_MouseMove(object sender, MouseEventArgs e)
        {
            Common.MouseMoveForm(this, e);
        }

        private void CustomRuleForm_Load(object sender, EventArgs e)
        {
            //加载案件信息
            string sql = "select case_name,case_no,case_date,author from case_list;";
            DataSet data_set = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, sql);
            dGv_CaseList.DataSource = data_set.Tables[0];

            if (dGv_CaseList.RowCount >= 2)
                dGv_CaseList.Rows[0].Selected = true;

            dGv_CaseList.Columns[0].HeaderText = "名称";
            dGv_CaseList.Columns[1].HeaderText = "编号";
            dGv_CaseList.Columns[2].HeaderText = "日期";
            dGv_CaseList.Columns[3].HeaderText = "创建人";


            //加载规则数据
            sql = "select * from rule_list;";
            data_set = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, sql);
            dGv_RuleList.DataSource = data_set.Tables[0];

            //if (dGv_RuleList.RowCount >= 2)
            //{
            //    dGv_RuleList.Rows[0].Selected = true;
            //}

            dGv_RuleList.Columns[0].Visible = false;
            dGv_RuleList.Columns[1].HeaderText = "名称";
            dGv_RuleList.Columns[2].HeaderText = "类型";
            dGv_RuleList.Columns[3].Visible = false;  //外键不显示
            dGv_RuleList.Columns[4].HeaderText = "案件编号";
            dGv_RuleList.Columns[5].HeaderText = "文件名";
            dGv_RuleList.Columns[6].HeaderText = "Sheet信息";
            dGv_RuleList.Columns[7].HeaderText = "字段";
        }

        private void dGv_CaseList_SelectionChanged(object sender, EventArgs e)
        {
            if (dGv_CaseList.CurrentRow == null)
            {
                return;
            }

            int index = dGv_CaseList.CurrentRow.Index;
            string case_no = dGv_CaseList.Rows[index].Cells[1].Value.ToString();  //foreign key

            if (case_no.Trim() == "")
                return;

            //刷新其余的datagridview
            dGv_XlsFiles.DataSource = null;
            dGv_Sheets.DataSource = null;
            dGv_Fields.DataSource = null;

            //string sql = "select file_name,case_no from excel_list where case_no='" + case_no + "';";
            string sql = "select * from excel_list where case_no='" + case_no + "';";
            DataSet data_set = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, sql);

            dGv_XlsFiles.DataSource = data_set.Tables[0];

            if (dGv_XlsFiles.RowCount >= 2)
                dGv_XlsFiles.Rows[0].Selected = true;
            dGv_XlsFiles.Columns[0].Visible = false;
            dGv_XlsFiles.Columns[1].HeaderText = "名称";
            dGv_XlsFiles.Columns[2].Visible = false;

            //取案件编号
            g_case_no = case_no;
        }

        private void dGv_XlsFiles_SelectionChanged(object sender, EventArgs e)
        {
            if (dGv_XlsFiles.CurrentRow == null)
            {
                return;
            }

            int excel_id = Convert.ToInt32(dGv_XlsFiles.CurrentRow.Cells[0].Value); //foreign key

            string sql = "select * from sheet_list where excel_id='" + excel_id + "';";
            DataSet data_set = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, sql);
            dGv_Sheets.DataSource = data_set.Tables[0];

            if (dGv_Sheets.RowCount >= 2)
            {
                dGv_Sheets.Rows[0].Selected = true;
            }

            dGv_Sheets.Columns[0].Visible = false;
            dGv_Sheets.Columns[1].HeaderText = "信息类型";
            dGv_Sheets.Columns[2].Visible = false;

            //取excel_id
            g_excel_id = excel_id;
            //取文件名
            g_file_name = dGv_XlsFiles.CurrentRow.Cells[1].Value.ToString();
        }

        private void dGv_Sheets_SelectionChanged(object sender, EventArgs e)
        {
            if (dGv_Sheets.CurrentRow == null)
            {
                return;
            }

            int sheet_id = Convert.ToInt32(dGv_Sheets.CurrentRow.Cells[0].Value);

            string sql = "select * from field_list where sheet_id='" + sheet_id + "';";
            DataSet data_set = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, sql);
            dGv_Fields.DataSource = data_set.Tables[0];

            if (dGv_Fields.RowCount >= 2)
                dGv_Fields.Rows[0].Selected = true;

            dGv_Fields.Columns[0].Visible = false;
            dGv_Fields.Columns[1].HeaderText = "字段值";
            dGv_Fields.Columns[2].Visible = false;

            //取sheet名
            g_sheet_name = dGv_Sheets.CurrentRow.Cells[1].Value.ToString();
        }

        private void dGv_Fields_SelectionChanged(object sender, EventArgs e)
        {
            if (dGv_Fields.CurrentRow == null)
                return;

            //取字段名
            g_field_name = dGv_Fields.CurrentRow.Cells[1].Value.ToString();
        }

        private static int g_excel_id = 0;
        private static string g_case_no = "";
        private static string g_file_name = "";
        private static string g_sheet_name = "";
        private static string g_field_name = "";



        //测试算法：是否为好友
        private void btn_friends_Click(object sender, EventArgs e)
        {

        }

        //测试算法：是否在同一个群
        private void btn_teams_Click(object sender, EventArgs e)
        {

        }

        //测试算法：是否在同一个终端登录
        private void btn_machine_Click(object sender, EventArgs e)
        {

        }

        //新建规则
        private void btn_CreateCustom_Click(object sender, EventArgs e)
        {
            //获取当前选中项：案件编号、文件名、sheet名称、字段field名
            if (g_case_no.Trim() == "" || g_file_name.Trim() == "" || g_sheet_name.Trim() == "" || g_field_name.Trim() == "")
            {
                MessageBox.Show("选择的信息出现空字符串");
                return;
            }

            RuleInfoForm form = new RuleInfoForm();
            if (form.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
            {
                return;
            }

            string rule_name = form.g_rule_name;
            int rule_type = Convert.ToInt32(form.g_rule_type);

            int excel_id = g_excel_id;
            string case_no = g_case_no;
            string file_name = g_file_name;
            string sheet_name = g_sheet_name;
            string field_name = g_field_name;

            string sql = "insert into rule_list(name, type, excel_id, case_no, excel, sheet, field) ";
            sql += "values('" + rule_name + "', '" + rule_type + "', '" + excel_id + "', '" + case_no + "', '";
            sql += file_name + "', '" + sheet_name + "', '" + field_name + "');";

            MySqlHelper.ExecuteScalar(MySqlHelper.Conn, CommandType.Text, sql);

            sql = "select * from rule_list;";
            DataSet data_set = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, sql);
            dGv_RuleList.DataSource = data_set.Tables[0];

            dGv_RuleList.Columns[0].Visible = false;
            dGv_RuleList.Columns[1].HeaderText = "名称";
            dGv_RuleList.Columns[2].HeaderText = "类型";
            dGv_RuleList.Columns[3].Visible = false;  //外键不显示
            dGv_RuleList.Columns[4].HeaderText = "案件编号";
            dGv_RuleList.Columns[5].HeaderText = "文件名";
            dGv_RuleList.Columns[6].HeaderText = "Sheet信息";
            dGv_RuleList.Columns[7].HeaderText = "字段";

            //当前选中项的 案件编号 和 文件名
            //rule_list_current_case_no = dGv_RuleList.CurrentRow.Cells[4].Value.ToString();
            //rule_list_current_file_name = dGv_RuleList.CurrentRow.Cells[5].Value.ToString();
        }


        string rule_list_current_case_no = "";   //dGv_RuleList 当前选中的
        string rule_list_current_file_name = "";
        //添加详细项
        private void btn_AddCollisionItems_Click(object sender, EventArgs e)
        {
            //获取当前选中项：案件编号、文件名、sheet名称、字段field名
            if (g_case_no.Trim() == "" || g_file_name.Trim() == "" || g_sheet_name.Trim() == "" || g_field_name.Trim() == "")
            {
                MessageBox.Show("选择的信息不完整");
                return;
            }

            //当前是否选中或防止为空
            if (dGv_RuleList.CurrentRow == null)
            {
                MessageBox.Show("未选择规则");
                return;
            }

            //当前选中项的 案件编号 和 文件名
            rule_list_current_case_no = dGv_RuleList.CurrentRow.Cells[4].Value.ToString();
            rule_list_current_file_name = dGv_RuleList.CurrentRow.Cells[5].Value.ToString();

            //判断是否属于同一个案件
            if (!rule_list_current_case_no.Equals(g_case_no))
            {
                MessageBox.Show("不能添加不同案件的信息");
                return;
            }

            //判断是否添加自身条件：案件编号 + 文件名
            if (rule_list_current_case_no.Equals(g_case_no) && rule_list_current_file_name.Equals(g_file_name))
            {
                MessageBox.Show("不能添加自身作为规则详细项");
                return;
            }

            //判断是否已经添加过了
            string sql = "select count(*) from rule_detail where case_no='" + g_case_no + "' and excel='" + g_file_name + "' and sheet='" + g_sheet_name + "'";
            sql += " and field='" + g_field_name + "' and rule_id='" + g_rule_id + "';";
            int count = Convert.ToInt32(MySqlHelper.ExecuteScalar(MySqlHelper.Conn, CommandType.Text, sql));
            if (count >= 1)
            {
                MessageBox.Show("当前规则已经添加该明细项");
                return;
            }

            sql = "insert into rule_detail(case_no, excel, sheet, field, rule_id) values";
            sql += "('" + g_case_no + "', '" + g_file_name + "', '" + g_sheet_name + "', '" + g_field_name + "', '" + g_rule_id + "');";

            MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sql);

            sql = "select * from rule_detail where rule_id='" + g_rule_id + "';";
            DataSet data_set = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, sql);
            dGv_RuleDetail.DataSource = data_set.Tables[0];
        }


        static int g_rule_id = 0;
        private void dGv_RuleList_SelectionChanged(object sender, EventArgs e)
        {
            if (dGv_RuleList.CurrentRow == null)
            {
                return;
            }

            int rule_id = Convert.ToInt32(dGv_RuleList.CurrentRow.Cells[0].Value);
            g_rule_id = rule_id;

            string sql = "select * from rule_detail where rule_id='" + rule_id + "';";
            DataSet data_set = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, sql);
            dGv_RuleDetail.DataSource = data_set.Tables[0];

            dGv_RuleDetail.Columns[0].Visible = false;
            dGv_RuleDetail.Columns[1].HeaderText = "案件编号";
            dGv_RuleDetail.Columns[2].HeaderText = "文件名";
            dGv_RuleDetail.Columns[3].HeaderText = "Sheet信息";
            dGv_RuleDetail.Columns[4].HeaderText = "字段";
            dGv_RuleDetail.Columns[5].Visible = false;
        }
    }
}
