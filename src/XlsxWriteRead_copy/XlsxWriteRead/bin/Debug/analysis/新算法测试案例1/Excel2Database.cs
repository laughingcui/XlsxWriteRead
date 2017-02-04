using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
    public class Excel2Database
    {
        /// <summary>
        /// each sheet data
        /// </summary>
        public struct Ssheet
        {
            public string sheetName;
            public List<string> fieldsList; //sheet中第一行作为数据库表格字段值
        }

        /// <summary>
        /// each xls data
        /// </summary>
        public struct SxlsFile
        {
            public string fileName;
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
            string filePYName = "";
            //string sheetPYName = "";

            xlsFile.sheetsList = new List<Ssheet>();
            filePYName = EcanConvertToCh.convertCh(fileChName);
            xlsFile.fileName = filePYName;

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
                sheetData.fieldsList = new List<string>();
                //sheetData.sheetName = filePYName + "_" + EcanConvertToCh.convertCh(sheet.SheetName);
                sheetData.sheetName = EcanConvertToCh.convertCh(sheet.SheetName);

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
                        string field = "No" + i_column; //由于excel处理的方式有些诡异(允许空行，不允许空列)，确保数据不丢失, "No" + 列号作为字段避免字段属性重复mysql出现错误
                        if (null != cell) //列不为空
                        {
                            // write log
                            if (cell.ToString().Trim() != "")
                            {
                                field = EcanConvertToCh.convertCh(cell.ToString());
                            }
                            //continue;
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

                    xlsFiles.Add(xlsFile);
                }
                catch (Exception)
                {
                    continue;
                    //throw;
                }

            }

            return true;
        }

        //create db  tables
        public static bool CreateDBTable(ref List<SxlsFile> xlsFiles)
        {
            int xlsFilesCount = xlsFiles.Count;
            if (0 == xlsFilesCount)
                return false;

            try
            {
                for (int i_xlsFile = 0; i_xlsFile < xlsFilesCount; i_xlsFile++)
                {
                    SxlsFile xlsFile = xlsFiles[i_xlsFile];
                    string fileName = xlsFile.fileName;

                    StringBuilder sqlCreate_L1Table = new StringBuilder();
                    sqlCreate_L1Table.Append("create table ");
                    sqlCreate_L1Table.Append(fileName);
                    sqlCreate_L1Table.Append(" (id int(11) NOT NULL auto_increment, sheet varchar(60) not null, primary key(id))ENGINE= MYISAM CHARACTER SET utf8;");

                    MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sqlCreate_L1Table.ToString());

                    int sheetCount = xlsFile.sheetsList.Count;
                    for (int i_sheet = 0; i_sheet < sheetCount; i_sheet++)
                    {
                        Ssheet sheet = xlsFile.sheetsList[i_sheet];
                        string sheetName = sheet.sheetName;

                        //insert data(L2 table name) into L1 table
                        StringBuilder sqlInsert_L1Table = new StringBuilder();
                        sqlInsert_L1Table.Append("insert into ");
                        sqlInsert_L1Table.Append(fileName);
                        sqlInsert_L1Table.Append("(sheet) values('");
                        sqlInsert_L1Table.Append(fileName + "_" + sheetName + "');");
                        MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sqlInsert_L1Table.ToString());

                        StringBuilder sqlCreate_L2Table = new StringBuilder();
                        sqlCreate_L2Table.Append("create table ");
                        sqlCreate_L2Table.Append(fileName + "_" + sheetName);
                        sqlCreate_L2Table.Append("(id int(20) not null auto_increment,");

                        int fieldCount = sheet.fieldsList.Count;
                        if (0 == fieldCount)
                            continue;

                        for (int i_field = 0; i_field < fieldCount; i_field++)
                        {
                            sqlCreate_L2Table.Append(sheet.fieldsList[i_field]);
                            sqlCreate_L2Table.Append(" varchar(60),");
                        }

                        sqlCreate_L2Table.Append(" primary key(id))ENGINE= MYISAM CHARACTER SET utf8;");
                        MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sqlCreate_L2Table.ToString());


                        //insert data(L2 table name) into L1 table
                        //StringBuilder sqlInsert_L1Table = new StringBuilder();
                        //sqlInsert_L1Table.Append("insert into ");
                        //sqlInsert_L1Table.Append(fileName);
                        //sqlInsert_L1Table.Append("(sheet) values('");
                        //sqlInsert_L1Table.Append(fileName + "_" + sheetName + "');");
                        //MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sqlInsert_L1Table.ToString());
                    }
                }
            }
            catch (Exception)
            {
                //write log
                return false;
                //throw;
            }

            return true;
        }

        public static bool InsertData(ref List<string> files, ref List<SxlsFile> xlsFiles)
        {
            int fileCount = files.Count;
            int xlsCount = xlsFiles.Count;
            if (0 == fileCount || 0 == xlsCount)
                return false;

            for (int i_file = 0; i_file < xlsCount; i_file++)
            {
                string filePath = files[i_file];
                HSSFWorkbook workBook;
                try
                {
                    using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                    {
                        workBook = new HSSFWorkbook(fileStream);
                        if (null == workBook)
                            continue;
                    }
                }
                catch (Exception)
                {
                    continue;
                }

                string fileName = xlsFiles[i_file].fileName; //从解析好的list中取

                int sheetCount = workBook.NumberOfSheets;
                for (int i_sheet = 0; i_sheet < sheetCount; i_sheet++)
                {
                    ISheet sheet = workBook.GetSheetAt(i_sheet);
                    if (null == sheet)
                        continue;

                    int fieldCount = xlsFiles[i_file].sheetsList[i_sheet].fieldsList.Count;
                    if (0 == fieldCount)
                        continue;

                    string sheetName = xlsFiles[i_file].sheetsList[i_sheet].sheetName;
                    //StringBuilder sql_header = new StringBuilder();
                    string sql_header = "insert into " + fileName + "_" + sheetName + "(";
                    for (int i_field = 0; i_field < fieldCount; i_field++)
                    {
                        string fieldName = xlsFiles[i_file].sheetsList[i_sheet].fieldsList[i_field];
                        if (i_field == (fieldCount - 1))
                        {
                            sql_header += (fieldName + ") ");
                            break;
                        }

                        sql_header += (fieldName + ",");
                    }

                    //int ii = 0;
                    int rowCount = sheet.PhysicalNumberOfRows;
                    for (int i_row = 1; i_row < rowCount; i_row++)
                    {
                        StringBuilder sql = new StringBuilder();
                        sql.Append(sql_header);
                        sql.Append("values('");

                        IRow row = sheet.GetRow(i_row);

                        for (int i_cell = 0; i_cell < fieldCount; i_cell++)
                        {
                            string unit = "No";

                            if (null == row)
                                unit = "No";
                            else
                            {
                                ICell cell = row.GetCell(i_cell);

                                if (null == cell)
                                    unit = "No";
                                else
                                {
                                    unit = cell.ToString();
                                    if ("" == unit.Trim())
                                        unit = "No";
                                }
                            }

                            if (i_cell == (fieldCount - 1))  //到达末尾
                            {
                                sql.Append(unit + "');");
                                break;
                            }

                            sql.Append(unit + "', '");  //未到达末尾
                        }

                        //int ii = 0;
                        MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, System.Data.CommandType.Text, sql.ToString());
                    }
                }
            }

            return true;
        }
    }
}
