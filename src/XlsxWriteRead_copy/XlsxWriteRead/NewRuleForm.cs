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
    public partial class NewRuleForm : Form
    {
        public NewRuleForm()
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

        private void NewRuleForm_MouseDown(object sender, MouseEventArgs e)
        {
            Common.MouseDownForm(this, e);
        }

        private void NewRuleForm_MouseMove(object sender, MouseEventArgs e)
        {
            Common.MouseMoveForm(this, e);
        }

        private void NewRuleForm_Load(object sender, EventArgs e)
        {
            //加载
            string sql = "select * from rule_list;";
            DataSet data_set = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, sql);
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

        //一键自动分析时
        List<Algorithm.SSourceItem> g_rule_list = new List<Algorithm.SSourceItem>();
        string[] type = { "寻找QQ好友", "共同QQ好友", "互为共同QQ好友", "共同QQ群", "同一个终端" };

        private void btn_Analysis_Click(object sender, EventArgs e)
        {
            if (dGv_RuleList.CurrentRow == null)
            {
                MessageBox.Show("未选中规则");
                return;
            }

            if (dGv_RuleDetail.RowCount < 1)
            {
                MessageBox.Show("规则范围为空");
                return;
            }

            Algorithm.SSourceItem rule = new Algorithm.SSourceItem();
            rule.target_list = new List<Algorithm.STargetItem>();

            string rule_name = dGv_RuleList.CurrentRow.Cells[1].Value.ToString();//获取规则
            int rule_type = Convert.ToInt32(dGv_RuleList.CurrentRow.Cells[2].Value);

            string src_case_no = dGv_RuleList.CurrentRow.Cells[4].Value.ToString();
            string src_file_name = dGv_RuleList.CurrentRow.Cells[5].Value.ToString();
            string src_sheet_name = dGv_RuleList.CurrentRow.Cells[6].Value.ToString();
            string src_field_name = dGv_RuleList.CurrentRow.Cells[7].Value.ToString();

            rule.type = (Algorithm.AlgType)rule_type;
            rule.rule_name = rule_name;
            rule.case_no = src_case_no;
            rule.file_name_Ch = src_file_name;
            rule.sheet_name_Ch = src_sheet_name;
            rule.field_name_Ch = src_field_name;

            /*获取选中的规则对应的范围*/
            int target_count = dGv_RuleDetail.RowCount;
            
            for (int i_target = 0; i_target < target_count; i_target++)
            {
                Algorithm.STargetItem target = new Algorithm.STargetItem();
                target.case_no = dGv_RuleDetail.Rows[i_target].Cells[1].Value.ToString();
                target.file_name_Ch = dGv_RuleDetail.Rows[i_target].Cells[2].Value.ToString();
                target.sheet_name_Ch = dGv_RuleDetail.Rows[i_target].Cells[3].Value.ToString();
                target.field_name_Ch = dGv_RuleDetail.Rows[i_target].Cells[4].Value.ToString();

                rule.target_list.Add(target);//将取出的规则集放入list中，目前是只取出选中的规则
            }

            List<Algorithm.SSourceItem> rule_list = new List<Algorithm.SSourceItem>();
            List<Algorithm.SResult> result_list = new List<Algorithm.SResult>();

            rule_list.Add(rule);//将选中的规则对应的范围重新赋值给rule_list

            //对规则内部的范围重新建规则，即将选中的规则所包含的范围进行重新规则和范围的赋值
            for (int i_target = 0; i_target < rule.target_list.Count - 1; i_target++)
            {
                Algorithm.SSourceItem reDefineRule = new Algorithm.SSourceItem();
                reDefineRule.target_list = new List<Algorithm.STargetItem>();

                //新建组规则
                reDefineRule.type = (Algorithm.AlgType)rule_type;
                reDefineRule.rule_name = rule_name;
                reDefineRule.case_no = rule.case_no;
                reDefineRule.file_name_Ch = rule.target_list[i_target].file_name_Ch;
                reDefineRule.sheet_name_Ch = rule.target_list[i_target].sheet_name_Ch;
                reDefineRule.field_name_Ch = rule.target_list[i_target].field_name_Ch;

                //新建范围
                for (int i_i_target = (i_target + 1); i_i_target < rule.target_list.Count; i_i_target++)
                {
                    Algorithm.STargetItem reDefineDetail = new Algorithm.STargetItem();
                    reDefineDetail.case_no = rule.case_no;
                    reDefineDetail.file_name_Ch = rule.target_list[i_i_target].file_name_Ch;
                    reDefineDetail.sheet_name_Ch = rule.target_list[i_i_target].sheet_name_Ch;
                    reDefineDetail.field_name_Ch = rule.target_list[i_i_target].field_name_Ch;

                    reDefineRule.target_list.Add(reDefineDetail);
                }

                rule_list.Add(reDefineRule);
            }

            //调用分析方法
            Algorithm.Analysis(ref rule_list, ref result_list);
            //将分析结果进行输出显示
            int result_count = result_list.Count;
            for (int i_result = 0; i_result < result_count; i_result++)
			{
                Algorithm.SResult result = result_list[i_result];
                string result_info = "\r\n--------------- 规则: " + result.rule_name + " ---------------\r\n";
                result_info += "分析类型：" + type[Convert.ToInt32(result.type) - 1] + "\r\n";
                result_info += "符合条件项：" + "\r\n";

                int field_count = result.field_values.Count;
                for (int i_field = 0; i_field < field_count; i_field++)
                {
                    Algorithm.SField field = result.field_values[i_field];
                    int match_count = field.target_list.Count;

                    for (int i_match = 0; i_match < match_count; i_match++)
                    {
                        Algorithm.SMatchConditionTarget match_target = field.target_list[i_match];
                        result_info += "\t" + match_target.case_no + "   " + match_target.file_name_Ch + "  " +  match_target.field_value  + "\r\n";
                    }
                }
                tBx_ResultInfo.Text += result_info;
			}
        }

        private void dGv_RuleList_SelectionChanged(object sender, EventArgs e)
        {
            if (dGv_RuleList.CurrentRow == null)
            {
                return;
            }

            int rule_id = Convert.ToInt32(dGv_RuleList.CurrentRow.Cells[0].Value);
            //g_rule_id = rule_id;

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
