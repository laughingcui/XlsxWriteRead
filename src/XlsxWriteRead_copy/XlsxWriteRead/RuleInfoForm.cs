using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace XlsxWriteRead
{
    public partial class RuleInfoForm : Form
    {
        public RuleInfoForm()
        {
            InitializeComponent();
        }

        public string g_rule_name = "";
        //public string g_rule_type = "";
        public Algorithm.AlgType g_rule_type;

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            g_rule_name = tBx_RuleName.Text;
            //g_rule_type = cBx_RuleType.Text;

            if (g_rule_name.Trim() == "" || g_rule_type == Algorithm.AlgType.notDefine)
            {
                MessageBox.Show("请正确填写信息");
                return;
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        string[] type = { "寻找QQ好友", "共同QQ好友","互为共同QQ好友", "共同QQ群", "同一个终端" };
        private void RuleInfoForm_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                cBx_RuleType.Items.Add(type[i]);   
            }
        }

        private void cBx_RuleType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string text = cBx_RuleType.Text;
            if (text.Equals("寻找QQ好友"))
            {
                g_rule_type = Algorithm.AlgType.isQQfriend;
            }
            else if (text.Equals("共同QQ好友"))
            {
                g_rule_type = Algorithm.AlgType.hasCommonQQfriend;
            }
            else if (text.Equals("互为共同QQ好友"))
            {
                g_rule_type = Algorithm.AlgType.mutualQQFried;
            }
            else if (text.Equals("共同QQ群"))
            {
                g_rule_type = Algorithm.AlgType.hasCommonQQteam;
            }
            else if (text.Equals("同一个终端"))
            {
                g_rule_type = Algorithm.AlgType.isOneMachine;
            }
            else
                g_rule_type = Algorithm.AlgType.notDefine;
        }
    }
}
