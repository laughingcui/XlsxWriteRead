using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

// NPOI  open source component
using NPOI.HPSF;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;
using NPOI.POIFS.FileSystem;

// MysqlHelper
using Mysql;

// chinese convert to pinyin
using Chinese2Pinyin;

namespace XlsxWriteRead
{
    /// <summary>
    /// each sheet data
    /// </summary>
    struct SsheetData
    {
        public string sheetName;
        public List<string> fieldsList; //sheet中第一行作为数据库表格字段值
    }

    /// <summary>
    /// each xls data
    /// </summary>
    struct SxlsData
    {
        public string fileName;
        public List<SsheetData> sheetsList;
    }

    /// <summary>
    /// excel data 2 mysql database;
    /// </summary>
    public class Excel2Mysql
    {
        /// <summary>
        /// 存储所有打开的xls
        /// </summary>
        static List<SxlsData> xlsDatasList = new List<SxlsData>();

        //本算法思路采用纵向方式(深入嵌套方式),  另一种是水平方式(扁平式)
        /// <summary>
        /// 本版本目前效果：遇到非正常格式时（比如有空白列等），会继续往下创建正常格式的表格
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>
        public static bool xls2mysql1(List<string> files)
        {
            int fileCount = files.Count;
            if (0 == fileCount)
                return false;

            #region  //第一步:获取当前目录所有xls文件 获取 文件名-sheet-field, chinese convert 2 pinyin

            try
            {
                for (int i_file = 0; i_file < fileCount; i_file++)
                {
                    string path_all = files[i_file];
                    HSSFWorkbook workBook;
                    using (FileStream fileStream = new FileStream(path_all, FileMode.Open, FileAccess.Read))
                    {
                        workBook = new HSSFWorkbook(fileStream);
                        if (null == workBook)
                        {
                            //write log
                            continue;
                            //return false;
                        }
                    }

                    //1. get file name and store
                    string fileName = path_all.Substring(path_all.LastIndexOf("\\") + 1, path_all.LastIndexOf(".") - (path_all.LastIndexOf("\\") + 1));
                    
                    SxlsData xlsData = new SxlsData();
                    xlsData.sheetsList = new List<SsheetData>();
                    fileName = EcanConvertToCh.convertCh(fileName);
                    xlsData.fileName = fileName;

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
                        SsheetData sheetData = new SsheetData();
                        sheetData.fieldsList = new List<string>();
                        sheetData.sheetName = fileName + "_" + EcanConvertToCh.convertCh(sheet.SheetName);

                        //3. get each column of first row as a field
                        IRow row = sheet.GetRow(0);
                        int rowCOunt = sheet.PhysicalNumberOfRows;
                        if (null == row)
                        {
                            // write log
                            continue;  //or return false ?
                        }

                        for (int i_column = 0; i_column < row.LastCellNum; i_column++)
                        {
                            ICell cell = row.GetCell(i_column);
                            if (null == cell)
                            {
                                // write log
                                continue;
                            }
                            string field = EcanConvertToCh.convertCh(cell.ToString());
                            sheetData.fieldsList.Add(field);
                        }

                        xlsData.sheetsList.Add(sheetData);
                    }

                    xlsDatasList.Add(xlsData);
                }
            }
            catch (Exception)
            {
                return false;
                //throw;
            }

            #endregion

            #region //create L1 db table and insert data , and create L2 db table
            
            // L1 db table create and insert data(L2 table's name) , and create L2 db table
            int xlsCount = xlsDatasList.Count;
            try
            {
                for (int i_L1table = 0; i_L1table < xlsCount; i_L1table++)
                {
                    //1-1. create L1 db table
                    SxlsData xlsData = xlsDatasList[i_L1table];
                    string sql_create_table = "create table " + xlsData.fileName + " (id int(11) NOT NULL auto_increment, sheet varchar(60) not null, primary key(id))ENGINE= MYISAM CHARACTER SET utf8;";  //id自动增长, 一级表表名 = 文件名
                    MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, System.Data.CommandType.Text, sql_create_table);

                    int sheetCount = xlsData.sheetsList.Count;
                    for (int i_L1table_value = 0; i_L1table_value < sheetCount; i_L1table_value++)
                    {
                        //1-2. insert data into L1 db table
                        string sql_insert = "insert into " + xlsData.fileName + "(sheet) values(";
                        sql_insert += "'" + xlsData.sheetsList[i_L1table_value].sheetName + "');";
                        MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, System.Data.CommandType.Text, sql_insert);

                        // 2-1. create L2 db table
                        SsheetData sheetData = xlsData.sheetsList[i_L1table_value];
                        string sql_create_L2table = "create table " + sheetData.sheetName + "(id int(20) not null auto_increment,";  //二级表的表名 = 文件名 + sheet名

                        int L2_table_field_count = sheetData.fieldsList.Count;
                        for (int i_field = 0; i_field < L2_table_field_count; i_field++)
                        {
                            sql_create_L2table += sheetData.fieldsList[i_field] + " varchar(60),";
                        }

                        sql_create_L2table += " primary key(id))ENGINE= MYISAM CHARACTER SET utf8;";
                        MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, System.Data.CommandType.Text, sql_create_L2table);  //创建二级表
                    }
                }
            }
            catch (Exception)
            {
                return false;
                //throw;
            }

            

            #endregion

            #region // insert data into L2 db table

            //这块算法写的比较通用,是直接从另一个算法实现中直接拷贝过来，
            try
            {
                //二级表插入数据
                // 执行过程思路描述：
                // 遍历打开xls文件，取得
                //
                //
                for (int i_file = 0; i_file < fileCount; i_file++)
                {
                    string path_str_all = files[i_file];

                    HSSFWorkbook workbook;
                    using (FileStream file = new FileStream(path_str_all, FileMode.Open, FileAccess.Read))
                    {
                        workbook = new HSSFWorkbook(file);

                        if (workbook == null)
                        {
                            //MessageBox.Show("打开xls文件失败");
                            return false;
                        }
                    }

                    //1、获取文件名
                    string path_str_path = path_str_all.Substring(0, path_str_all.LastIndexOf("\\") + 1); //文件路径
                    string path_str_fileName = path_str_all.Substring(path_str_all.LastIndexOf("\\") + 1, path_str_all.LastIndexOf(".") - (path_str_all.LastIndexOf("\\") + 1));//文件名称
                    string path_str_fileExc = path_str_all.Substring(path_str_all.LastIndexOf(".") + 1, path_str_all.Length - path_str_all.LastIndexOf(".") - 1); //文件扩展名

                    //第一步：存储文件名
                    _TableInfo tableInfo = new _TableInfo();
                    tableInfo.sheetList = new List<_SheetToFields>();
                    path_str_fileName = EcanConvertToCh.convertCh(path_str_fileName);
                    tableInfo.fileName = path_str_fileName;  //保存文件名


                    //获取所有的sheet名
                    int sheetCount = workbook.NumberOfSheets;
                    for (int i_sheet = 0; i_sheet < sheetCount; i_sheet++)
                    {
                        ISheet _sheet = workbook.GetSheetAt(i_sheet);
                        string _sheetName = EcanConvertToCh.convertCh(_sheet.SheetName);

                        _SheetToFields sheetInfo = new _SheetToFields();
                        sheetInfo.fieldsList = new List<string>();
                        sheetInfo.sheetName = tableInfo.fileName + "_" + _sheetName;  //二级表的名称 = 文件名 + sheet名

                        string sql_init = "insert into " + sheetInfo.sheetName + "(";

                        //取字段属性值
                        IRow _fieldRow = _sheet.GetRow(0);
                        int _fieldRowCount = _fieldRow.LastCellNum;
                        for (int i_fieldRow = 0; i_fieldRow < _fieldRow.LastCellNum; i_fieldRow++)
                        {
                            ICell _fieldcell = _fieldRow.GetCell(i_fieldRow);
                            if (i_fieldRow == (_fieldRow.LastCellNum - 1))
                            {
                                sql_init += EcanConvertToCh.convertCh(_fieldcell.ToString()) + ") ";
                                break;
                            }
                            sql_init += EcanConvertToCh.convertCh(_fieldcell.ToString()) + ",";
                        }

                        //int ii = 0;

                        ////////////////////////////////////////////// 按照表头的列数取（数据行中如果有缺少列的，按照赋值 'NO' 处理，多出的ignore////////////////////////////////////////
                        for (int i_value_row = _sheet.FirstRowNum + 1; i_value_row <= _sheet.LastRowNum; i_value_row++)
                        {
                            string sql = sql_init;
                            string tmpSql = "values('";
                            IRow _value_row = _sheet.GetRow(i_value_row);

                            for (int i_value_cell = 0; i_value_cell < _fieldRowCount; i_value_cell++)
                            {
                                string _tmp_value = "NO";


                                ////////////////////////////////////////////////////////////////////////// 异常情况采取默认值处理 ////////////////////////////////////////////////////////
                                if (_value_row == null)  //情况2：有行号，但是里面都是空值
                                {
                                    _tmp_value = "NO";
                                }
                                else
                                {
                                    ICell _value_cell = _value_row.GetCell(i_value_cell);

                                    if (_value_cell == null) //情况1：列标题有，但是下面的数据行该列没有值
                                    {
                                        _tmp_value = "NO";
                                    }
                                    else
                                    {
                                        _tmp_value = _value_cell.ToString();
                                        if (_tmp_value == "")
                                            _tmp_value = "NO";
                                    }
                                }
                                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                                //经过上面可能存在的异常处理后，最后的拼接
                                if (i_value_cell == (_fieldRowCount - 1))
                                {
                                    tmpSql += _tmp_value + "');";
                                    break;
                                }
                                tmpSql += _tmp_value + "', '";
                            }

                            sql += tmpSql;
                            MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, System.Data.CommandType.Text, sql);
                        }
                    }
                }
            }
            catch (Exception)
            {
                //MessageBox.Show("step2: insert into L2 table error");
                return false;
                //throw;
            }

            #endregion

            return true;
        }
    }
}
