using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

// NPOI  open source component
using NPOI.HPSF;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;
using NPOI.POIFS.FileSystem;
using System.Data;
using System.IO;

using Mysql;
using Chinese2Pinyin;

namespace XlsxWriteRead
{
    /// <summary>
    /// version 3.0  2017-1-12 craigtao
    /// </summary>
    public class Excel2Database
    {
        public struct Sfield
        {
            /// <summary>
            /// 汉字
            /// </summary>
            public string field_name_Ch;
            //拼音
            public string field_name_PY;
        }

        /// <summary>
        /// each sheet data
        /// </summary>
        public struct Ssheet
        {
            /// <summary>
            /// 汉字
            /// </summary>
            public string sheet_name_Ch;
            /// <summary>
            /// 拼音
            /// </summary>
            public string sheet_name_PY;
            public List<Sfield> fieldsList; //sheet中第一行作为数据库表格字段值
        }

        /// <summary>
        /// each xls data
        /// </summary>
        public struct SxlsFile
        {
            //包含全路径
            public string file_name_Full;
            /// <summary>
            /// 汉字
            /// </summary>
            public string file_name_Ch;
            /// <summary>
            /// 拼音
            /// </summary>
            public string file_name_PY;
            public List<Ssheet> sheetsList;
        }

        //parse one xls file
        private static bool GetXls(string filePath, ref SxlsFile xlsFile)
        {
            HSSFWorkbook workBook;

            try
            {
                using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    workBook = new HSSFWorkbook(fileStream);
                    if (null == workBook)
                    {
                        //write log
                        return false;
                    }
                }
            }
            catch (Exception)
            {
                //write file path into log or notice user,  and read next xls file
                return false;
                //throw;
            }

            //1. get file name and store
            string fileChName = filePath.Substring(filePath.LastIndexOf("\\") + 1, filePath.LastIndexOf(".") - (filePath.LastIndexOf("\\") + 1));
            //string fileChName = filePath.Substring(filePath.LastIndexOf("\\") + 1, filePath.LastIndexOf(".") - (filePath.LastIndexOf("\\") + 1));
            string filePYName = "";
            //string sheetPYName = "";

            xlsFile.sheetsList = new List<Ssheet>();
            filePYName = EcanConvertToCh.convertCh(fileChName);
            xlsFile.file_name_Ch = fileChName;
            xlsFile.file_name_PY = filePYName;

            //2. get each one sheet and store
            int sheetCount = workBook.NumberOfSheets;
            for (int i_sheet = 0; i_sheet < sheetCount; i_sheet++)
            {
                ISheet sheet = workBook.GetSheetAt(i_sheet);
                if (null == sheet)
                {
                    //write log
                    continue;
                    //return false ; //?
                }

                //sheet name
                Ssheet sheetData = new Ssheet();
                sheetData.fieldsList = new List<Sfield>();
                //sheetData.sheetName = filePYName + "_" + EcanConvertToCh.convertCh(sheet.SheetName);
                sheetData.sheet_name_Ch = sheet.SheetName;
                sheetData.sheet_name_PY = EcanConvertToCh.convertCh(sheet.SheetName);

                
                //3. get each column of first row as a field
                IRow row = sheet.GetRow(0);
                //int rowCOunt = sheet.PhysicalNumberOfRows;
                //int columnCount = row.PhysicalNumberOfCells;
                if (null != row)  //default the sheet no value（meet no L2 db table)
                {
                    // write log
                    //continue;  //or return false ?

                    for (int i_column = 0; i_column < row.LastCellNum; i_column++)
                    {
                        ICell cell = row.GetCell(i_column);
                        Sfield field = new Sfield();
                        string field_str = "No" + i_column; //由于excel处理的方式有些诡异(允许空行，不允许空列)，确保数据不丢失, "No" + 列号作为字段避免字段属性重复mysql出现错误
                        if (null != cell) //列不为空
                        {
                            // write log
                            if (cell.ToString().Trim() != "")
                            {
                                field.field_name_Ch = cell.ToString();
                                field_str = EcanConvertToCh.convertCh(cell.ToString());
                                field.field_name_PY = field_str;
                            }
                            //continue;
                        }
                        else
                        {
                            field.field_name_Ch = field_str;
                            field.field_name_PY = field_str;
                        }

                        sheetData.fieldsList.Add(field);
                    }
                }

                xlsFile.sheetsList.Add(sheetData);
            }

            return true;
        }

        
        //parse multi xls files
        public static bool GetXlss(List<string> files, ref List<SxlsFile> xlsFiles)
        {
            int fileCount = files.Count;
            if (0 == fileCount)
                return false;

            for (int i_file = 0; i_file < fileCount; i_file++)
            {
                try
                {
                    string filePath = files[i_file];
                    SxlsFile xlsFile = new SxlsFile();
                    

                    if (false == GetXls(filePath, ref xlsFile))
                    {
                        continue;
                    }

                    xlsFile.file_name_Full = filePath;

                    xlsFiles.Add(xlsFile);
                }
                catch (Exception e)
                {
                    MessageBox.Show("parse multi xls files 异常");
                    MessageBox.Show(e.Source);
                    MessageBox.Show(e.HelpLink);
                    MessageBox.Show(e.Message.ToString());
                    MessageBox.Show(e.ToString());
                    continue;
                    //throw;
                }

            }

            return true;
        }

        //create db  tables


        public static bool CreateDBtable(string case_no, ref List<SxlsFile> xls_files)
        {
            int file_count = xls_files.Count;
            if (0 == file_count)
                return false;

            for (int i_file = 0; i_file < file_count; i_file++)
            {
                SxlsFile xls_file = xls_files[i_file];
                string file_name_PY = xls_file.file_name_PY;
                //string table_name = "";  // case_no + file_nam_PY + sheet_name;  only one tanle

                int sheet_count = xls_file.sheetsList.Count;
                if (sheet_count == 0)
                    continue;

                for (int i_sheet = 0; i_sheet < sheet_count; i_sheet++)
                {
                    Ssheet sheet = xls_file.sheetsList[i_sheet];
                    string sheet_name_PY = sheet.sheet_name_PY;

                    string table_name = case_no + file_name_PY + sheet_name_PY;  //表名
                    //先判断是否存在该表格
                    string sql = "show tables like '" + table_name + "';";
                    Object table_exists = MySqlHelper.ExecuteScalar(MySqlHelper.Conn, CommandType.Text, sql);
                    if (null != table_exists)
                    {
                        //write log
                        continue;
                    }

                    int field_count = sheet.fieldsList.Count;
                    if (field_count == 0)
                        continue;

                    sql = "create table " + table_name;
                    sql += "(id int(20) not null auto_increment,";

                    for (int i_field = 0; i_field < field_count; i_field++)
                    {
                        Sfield field = sheet.fieldsList[i_field];
                        string field_name_PY = field.field_name_PY;

                        sql += field_name_PY + " varchar(60),";
                    }

                    sql += "primary key(id))ENGINE= MYISAM CHARACTER SET utf8;";

                    MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sql);
                }
            }

            return true;
        }


        //
        public static bool XlssIntoDBtable(string case_no, ref List<SxlsFile> xls_files)
        {
            int file_count = xls_files.Count;
            if (0 == file_count)
                return false;

            for (int i_file = 0; i_file < file_count; i_file++)
            {
                SxlsFile xls_file = xls_files[i_file];
                XlsIntoDBtable(case_no, ref xls_file);
            }

            return true;
        }

        public static bool XlsIntoDBtable(string case_no, ref SxlsFile xls_file)
        {
            string file_path = xls_file.file_name_Full;
            HSSFWorkbook work_book;
            try
            {
                using (FileStream file_stream = new FileStream(file_path, FileMode.Open, FileAccess.Read))
                {
                    work_book = new HSSFWorkbook(file_stream);
                    if (null == work_book)
                        return false;
                }
            }
            catch (Exception)
            {
                //continue
                throw;
            }

            string file_name_PY = xls_file.file_name_PY;     //文件名

            int sheet_count = xls_file.sheetsList.Count;
            for (int i_sheet = 0; i_sheet < sheet_count; i_sheet++)
            {
                ISheet sheet = work_book.GetSheetAt(i_sheet);
                if (null == sheet)
                    continue;

                string sheet_name_PY = xls_file.sheetsList[i_sheet].sheet_name_PY;  //sheet名

                int field_count = xls_file.sheetsList[i_sheet].fieldsList.Count;
                if (0 == field_count)
                    continue;

                //表名
                string table_name = case_no + file_name_PY + sheet_name_PY;
                //字段属性值
                string sql_header = "insert into " + table_name + "(";
                for (int i_field = 0; i_field < field_count; i_field++)
                {
                    string field_name = xls_file.sheetsList[i_sheet].fieldsList[i_field].field_name_PY;
                    if (i_field == (field_count - 1))  //最后一个字段
                    {
                        sql_header += (field_name + ") ");
                        break;
                    }

                    sql_header += (field_name + ",");
                }

                //内容value
                int row_count = sheet.PhysicalNumberOfRows;
                for (int i_row = 1; i_row < row_count; i_row++)
                {
                    string sql_values = sql_header;
                    sql_values += "values('";

                    IRow row = sheet.GetRow(i_row);
                    if (null == row)
                        continue;

                    for (int i_cell = 0; i_cell < field_count; i_cell++)
                    {
                        string unit = "No";
                        ICell cell = row.GetCell(i_cell);

                        if (null == cell)
                        {
                            unit = "No";
                        }
                        else
                        {

                            // 2017-1-20 excel中读取出来的数据格式需要做处理（如果是时间格式）
                            if (cell.CellType == CellType.Numeric && DateUtil.IsCellDateFormatted(cell))
                            {
                                unit = cell.DateCellValue.ToString();
                            }
                            else
                            {
                                unit = cell.ToString();
                                if ("" == unit.Trim())
                                {
                                    unit = "No";
                                }
                            }


                            //原来的处理方式
                            //unit = cell.ToString();
                            //if ("" == unit.Trim())
                            //    unit = "No";
                        }

                        if (i_cell == (field_count - 1))  //到达最后一个字段
                        {
                            sql_values += unit + "');";
                            break;
                        }

                        sql_values += unit + "', '";
                    }

                    MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sql_values.ToString());
                }
            }

            return true;
        }
    }
}
