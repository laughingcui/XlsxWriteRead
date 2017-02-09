using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using Mysql;
using MySql.Data.MySqlClient;
using ZipDemo;

using NPOI.HPSF;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;
using NPOI.POIFS.FileSystem;

namespace XlsxWriteRead
{
    public partial class ImportDataForm : Form
    {
        public ImportDataForm()
        {
            InitializeComponent();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void ImportDataForm_MouseDown(object sender, MouseEventArgs e)
        {
            Common.MouseDownForm(this, e);
        }

        private void ImportDataForm_MouseMove(object sender, MouseEventArgs e)
        {
            Common.MouseMoveForm(this, e);
        }

        //
        private void ImportDataForm_Load(object sender, EventArgs e)
        {
            //加载案件信息
            string sql = "select case_name,case_no,case_date,author from case_list;";
            DataSet data_set = Mysql.MySqlHelper.GetDataSet(Mysql.MySqlHelper.Conn, CommandType.Text, sql);
            dGv_CaseList.DataSource = data_set.Tables[0];

            if (dGv_CaseList.RowCount >= 2)
                dGv_CaseList.Rows[0].Selected = true;

            dGv_CaseList.Columns[0].HeaderText = "名称";
            dGv_CaseList.Columns[1].HeaderText = "编号";
            dGv_CaseList.Columns[2].HeaderText = "日期";
            dGv_CaseList.Columns[3].HeaderText = "创建人";
        }

        private void dGv_CaseList_SelectionChanged(object sender, EventArgs e)
        {
            if (dGv_CaseList.CurrentRow == null)
            {
                return;
            }

            int index = dGv_CaseList.CurrentRow.Index;
            string case_no = dGv_CaseList.Rows[index].Cells[1].Value.ToString();

            if (case_no.Trim() == "")
                return;

            string sql = "select file_name,case_no from excel_list where case_no='" + case_no + "';";
            DataSet data_set = Mysql.MySqlHelper.GetDataSet(Mysql.MySqlHelper.Conn, CommandType.Text, sql);
            dGv_XlsFiles.DataSource = data_set.Tables[0];

            if (dGv_XlsFiles.RowCount >= 2)
                dGv_XlsFiles.Rows[0].Selected = true;
            dGv_XlsFiles.Columns[0].HeaderText = "名称";
            dGv_XlsFiles.Columns[1].Visible = false;
            
        }

        //删除当前选中案件
        private void btn_DeleteCase_Click(object sender, EventArgs e)
        {
         //删除案件时，需要删除对应的数据表
            
         if (dGv_CaseList.CurrentRow == null)
         {
             return;
         }
         int index = dGv_CaseList.CurrentRow.Index;
         string case_no = dGv_CaseList.Rows[index].Cells[1].Value.ToString();
         string sql = "delete from case_list where case_no ='" + case_no + "';";
        //MySQL中，根据表名的前缀删除符合条件的表
         string sql_delete_table = "select concat('drop table ', table_name, ';') from information_schema.tables where table_name like '"+ case_no + "%';";
         if (case_no.Trim() == "")
             return;

         DataSet data_set = Mysql.MySqlHelper.GetDataSet(Mysql.MySqlHelper.Conn, CommandType.Text, sql);
         
         MySqlDataReader reader = Mysql.MySqlHelper.ExecuteReader(Mysql.MySqlHelper.Conn, CommandType.Text, sql_delete_table);
         while (reader.Read())
         {
             string sql_drop = "";
             sql_drop = reader[0].ToString();
             DataSet data_set1 = Mysql.MySqlHelper.GetDataSet(Mysql.MySqlHelper.Conn, CommandType.Text, sql_drop);
         }
            MessageBox.Show("案件已删除");
            ImportDataForm_Load(sender, e);
        }

        //删除当前选中文件
        private void btn_DeleteFile_Click(object sender, EventArgs e)
        {
            //删除文件时，需要删除对应的数据表
        }

        //导入excel
        private void btn_ImportExcel_Click(object sender, EventArgs e)
        {

        }

        static string file_name = "";
        static string analy_path = @".\\analysis";
        static List<string> file_list = new List<string>();
        //导入压缩包
        private void btn_ImportZip_Click(object sender, EventArgs e)
        {
            int row_count = dGv_CaseList.RowCount;
            if (row_count < 1)
            {
                MessageBox.Show("请先创建案件");
                return;
            }
            //选中案件
            if (dGv_CaseList.CurrentRow == null)
            {
                MessageBox.Show("请正确选择案件");
                return;
            }
            
            string case_no = dGv_CaseList.CurrentRow.Cells[1].Value.ToString();
            if (case_no.Trim() == "")
            {
                MessageBox.Show("错误！案件编号为空");
                return;
            }

            try
            {
                //1 打开压缩包
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "zip数据包(*.zip)|*.zip";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    file_name = dialog.FileName;
                }
                else
                {
                    return;
                }

                //2 解压
                ZipHelper.UnZip(file_name, analy_path);

                //3 获取当前目前所有文件
                DirectoryInfo folder = new DirectoryInfo(analy_path);
                file_list.Clear();

                foreach (FileInfo file in folder.GetFiles("*.xls"))
                {
                    file_list.Add(file.FullName);
                }

                //解析导入数据
                AnalysisXls(case_no);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private bool AnalysisXls(string case_no)
        {
            List<Excel2Database.SxlsFile> xls_files = new List<Excel2Database.SxlsFile>();
            Excel2Database.GetXlss(file_list, ref xls_files);
            //Excel2Database.CreateDBTable(ref xls_files);

            // 1 建立案件索引
            CreateIndex(case_no, ref xls_files);

            // 2 建数据库表
            CreateTable(case_no, ref xls_files);

            // 3 插入数据
            XlsIntoTable(case_no, ref xls_files);  //数据是全部覆盖方式还是追加更新？

            //清理现场
            //删除当前导入的xls文件，生成的数据结构清空
            Common.DeleteFileFromList(ref file_list);
            xls_files.Clear();
            file_list.Clear();

            return true;
        }

        private bool CreateIndex(string case_no, ref List<Excel2Database.SxlsFile> xls_file)
        {
            // 健壮判断 -- 省略
            int file_count = xls_file.Count;
            for (int i_file = 0; i_file < file_count; i_file++)
            {
                // 插入excel_list
                string file_name_Ch = xls_file[i_file].file_name_Ch;
                string file_name_PY = xls_file[i_file].file_name_PY;

                //判断当前excel文件是否在当前
                string sql = "select count(*) from excel_list where file_name='" + file_name_Ch + "' and case_no='" + case_no + "';";
                int count = Convert.ToInt32(Mysql.MySqlHelper.ExecuteScalar(Mysql.MySqlHelper.Conn, CommandType.Text, sql));
                if (count >= 1)
                {
                    MessageBox.Show("当前案件中已存在：" + file_name_Ch);
                    //更新？先不实现
                    continue;
                }

                sql = "insert into excel_list(file_name, case_no) values('";
                sql += file_name_Ch + "', '" + case_no + "');";
                Mysql.MySqlHelper.ExecuteNonQuery(Mysql.MySqlHelper.Conn, CommandType.Text, sql);

                sql = "select id from excel_list where file_name='" + file_name_Ch + "' and case_no='" + case_no + "';";
                int file_id = Convert.ToInt32(Mysql.MySqlHelper.ExecuteScalar(Mysql.MySqlHelper.Conn, CommandType.Text, sql));  //foreign key

                int sheet_count = xls_file[i_file].sheetsList.Count;
                for (int i_sheet = 0; i_sheet < sheet_count; i_sheet++)
                {
                    string sheet_name_Ch = xls_file[i_file].sheetsList[i_sheet].sheet_name_Ch;
                    string sheet_name_PY = xls_file[i_file].sheetsList[i_sheet].sheet_name_PY;

                    sql = "insert into sheet_list(sheet, excel_id) values('";
                    sql += sheet_name_Ch + "', '" + file_id + "');";
                    Mysql.MySqlHelper.ExecuteNonQuery(Mysql.MySqlHelper.Conn, CommandType.Text, sql);

                    sql = "select id from sheet_list where sheet='" + sheet_name_Ch + "' and excel_id='" + file_id + "';";
                    int sheet_id = Convert.ToInt32(Mysql.MySqlHelper.ExecuteScalar(Mysql.MySqlHelper.Conn, CommandType.Text, sql));  //foreign key

                    int field_count = xls_file[i_file].sheetsList[i_sheet].fieldsList.Count;
                    for (int i_field = 0; i_field < field_count; i_field++)
                    {
                        string field_name_Ch = xls_file[i_file].sheetsList[i_sheet].fieldsList[i_field].field_name_Ch;
                        string field_name_PY = xls_file[i_file].sheetsList[i_sheet].fieldsList[i_field].field_name_PY;

                        sql = "insert into field_list(field, sheet_id) values('";
                        sql += field_name_Ch + "', '" + sheet_id + "');";
                        Mysql.MySqlHelper.ExecuteNonQuery(Mysql.MySqlHelper.Conn, CommandType.Text, sql);
                    }
                }
            }

            return true;
        }

        private bool CreateTable(string case_no, ref List<Excel2Database.SxlsFile> xls_files)
        {
            Excel2Database.CreateDBtable(case_no, ref xls_files);

            return true;
        }

        private bool XlsIntoTable(string case_no, ref List<Excel2Database.SxlsFile> xls_files)
        {
            Excel2Database.XlssIntoDBtable(case_no, ref xls_files);

            return true;
        }
    }
}
