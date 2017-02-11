using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;

using Mysql;
using Chinese2Pinyin;

namespace XlsxWriteRead
{
    public class Algorithm
    {
        //规则数据结构
        public enum AlgType
        {
            //Exist = 1,      //存在碰撞
            //Common,         //共同碰撞

            notDefine = 0,
            isQQfriend = 1,     //QQ好友
            hasCommonQQfriend,  //有共同QQ好友
            mutualQQFried,  //互为共同QQ好友
            hasCommonQQteam,    //有共同QQ群
            isOneMachine        //同一个终端登录
        }

        #region 理想的数据结构

        public class CDataStruct<T>
        {
            #region 输入结构体

            private struct Sinput
            {
                public List<string> case_no;
                public List<string> file_name_Ch;
                public List<string> sheet_name_Ch;
                //public List<string>
            }

            #endregion
        }

        #endregion

        #region 算法输入结构体

        public struct STargetItem
        {
            public string case_no;
            public string file_name_Ch;
            public string sheet_name_Ch;
            public string field_name_Ch;          //数据结构缺陷：实现IP账号是否于一个终端登录时，需要同时选中3个字段值，需要list结构存放
        }

        public struct SSourceItem
        {
            public AlgType type;

            public string rule_name;

            public string case_no;
            public string file_name_Ch;
            public string sheet_name_Ch;
            public string field_name_Ch;           //数据结构缺陷：实现IP账号是否于一个终端登录时，需要同时选中3个字段值，需要list结构存放 public List<string> field_name_Ch;  
                                                   // 可能最自由的还不是限定在string类型，可能是自定义类型， public List<Iobject> field_name_Ch;  
                                                   //其他的sheet 或者excel甚至 case_no 都应该提供多选，这才是最自由的可视化选择
                                                   //这样的实现，规则就需要 一个 规则引擎才能实现业务规则的最自由
            public List<STargetItem> target_list;
        }

        #endregion

        #region 算法输出结构体

        public struct SMatchConditionTarget
        {
            public string case_no;
            public string file_name_Ch;
            public string sheet_name_Ch;
            public string field_name_Ch;

            public string field_value;   //符合条件的字段值（比如：相同的QQ群）
        }

        public struct SField
        {
            public string value;  //字段值（可以是多个，比如：加入多个QQ群；有多个QQ账号
            public List<SMatchConditionTarget> target_list;  //符合结果的
        }

        public struct SResult
        {
            public AlgType type;

            public string rule_name;

            public string case_no;
            public string file_name_Ch;
            public string sheet_name_Ch;
            public string field_name_Ch;

            public List<SField> field_values; //因为某列中可能存在多个字段值
        }

        #endregion

        //本次使用switch实现，应该使用工厂模式
        public static bool Analysis(ref List<SSourceItem> input, ref List<SResult> output)
        {
            if (input == null || output == null)
            {
                return false;
            }

            int count = input.Count;
            for (int i_input = 0; i_input < count; i_input++)
            {
                SSourceItem source = input[i_input];
                SResult result = new SResult();
                result.field_values = new List<SField>();

                if (source.type == AlgType.isQQfriend)
                {
                    if (!Alg_isQQfriend(ref source, ref result))
                    {
                        return false;
                    }
                    result.rule_name = source.rule_name;
                    result.type = source.type;
                    result.case_no = source.case_no;
                    result.file_name_Ch = source.file_name_Ch;
                    result.sheet_name_Ch = source.sheet_name_Ch;
                    result.field_name_Ch = source.field_name_Ch;
                    output.Add(result);
                }
                else if (source.type == AlgType.hasCommonQQfriend)
                {
                    if (!Alg_hasCommonQQfriend(ref source, ref result))
                    {
                        return false;
                    }
                    result.rule_name = source.rule_name;
                    result.type = source.type;
                    result.case_no = source.case_no;
                    result.file_name_Ch = source.file_name_Ch;
                    result.sheet_name_Ch = source.sheet_name_Ch;
                    result.field_name_Ch = source.field_name_Ch;
                    output.Add(result);
                }
                else if (source.type == AlgType.mutualQQFried)
                {
                    if (!isMutualQQFried(ref source, ref result))
                    {
                        return false;
                    }
                    result.rule_name = source.rule_name;
                    result.type = source.type;
                    result.case_no = source.case_no;
                    result.file_name_Ch = source.file_name_Ch;
                    result.sheet_name_Ch = source.sheet_name_Ch;
                    result.field_name_Ch = source.field_name_Ch;
                    output.Add(result);
                    
                    MessageBox.Show("调用互为共同好友的方法");
                }
                else if (source.type == AlgType.hasCommonQQteam)
                {
                    if (!Alg_hasCommonQQteam(ref source, ref result))
                    {
                        return false;
                    }
                    result.rule_name = source.rule_name;
                    result.type = source.type;
                    result.case_no = source.case_no;
                    result.file_name_Ch = source.file_name_Ch;
                    result.sheet_name_Ch = source.sheet_name_Ch;
                    result.field_name_Ch = source.field_name_Ch;
                    output.Add(result);
                }
                else if (source.type == AlgType.isOneMachine)
                {

                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        #region 寻找QQ好友

        public static bool Alg_isQQfriend(ref SSourceItem source,ref SResult result)
        {
            string src_case_no = source.case_no;
            string src_file_PY = EcanConvertToCh.convertCh(source.file_name_Ch);
            string src_sheet_PY = EcanConvertToCh.convertCh(source.sheet_name_Ch);
            string src_field_PY = EcanConvertToCh.convertCh(source.field_name_Ch);

            string src_table = src_case_no + src_file_PY + src_sheet_PY;

            string sql = "select " + src_field_PY + " from " + src_table + ";";
            //string src_field_value = Convert.ToString(MySqlHelper.ExecuteScalar(MySqlHelper.Conn, System.Data.CommandType.Text, sql));  //只有一个QQ时

            //可能存在注册多个QQ
            DataSet data_set = MySqlHelper.GetDataSet(MySqlHelper.Conn, System.Data.CommandType.Text, sql);
            foreach (DataTable dt in data_set.Tables)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    foreach (DataColumn dc in dt.Columns)
                    {
                        string src_field_value = dr[dc].ToString();  //取得其中一个QQ

                        //进行遍历其他范围
                        int target_count = source.target_list.Count;
                        for (int i_target = 0; i_target < target_count; i_target++)
                        {
                            STargetItem target = source.target_list[i_target];

                            string target_case_no = target.case_no;
                            string target_file_PY = EcanConvertToCh.convertCh(target.file_name_Ch);
                            string target_sheet_PY = EcanConvertToCh.convertCh(target.sheet_name_Ch);
                            string target_field_PY = EcanConvertToCh.convertCh(target.field_name_Ch);

                            string target_table = target_case_no + target_file_PY + target_sheet_PY;


                            if (hasExist(src_field_value, target_table, target_field_PY))
                            {
                                //记录其中一个QQ找到了互为好友的
                                SField field = new SField();
                                field.value = src_field_value;
                                field.target_list = new List<SMatchConditionTarget>();

                                //记录符合条件的信息
                                SMatchConditionTarget match_target = new SMatchConditionTarget();
                                match_target.case_no = target.case_no;
                                match_target.file_name_Ch = target.file_name_Ch;
                                match_target.sheet_name_Ch = target.sheet_name_Ch;
                                match_target.field_name_Ch = target.field_name_Ch;
                                match_target.field_value = src_field_value;

                                field.target_list.Add(match_target);  //字段 对应 符合条件信息
                                result.field_values.Add(field);   // 将其中的一个字段值对比结果符合条件的记录
                            }
                            else
                            {

                            }
                        }
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// 判断某个值在其他表的某个字段列中存在否，对于存在碰撞是通用的
        /// </summary>
        /// <param name="field"></param>
        /// <param name="target_table"></param>
        /// <param name="target_field"></param>
        /// <returns></returns>
        private static bool hasExist(string field, string target_table, string target_field)
        {
            string sql = "select count(*) from " + target_table + " where " + target_field + "='" + field + "';";
            int count = Convert.ToInt32(MySqlHelper.ExecuteScalar(MySqlHelper.Conn, CommandType.Text, sql));

            if (count >= 1)
            {
                return true;
            }
            return false;
        }

        #endregion

        #region 与规则源存在共同QQ好友 (规则中源和目标的共同好友，不是规则中所有的共同好友)

        public static bool Alg_hasCommonQQfriend(ref SSourceItem source, ref SResult result)
        {
            string src_case_no = source.case_no;
            string src_file_PY = EcanConvertToCh.convertCh(source.file_name_Ch);
            string src_sheet_PY = EcanConvertToCh.convertCh(source.sheet_name_Ch);
            string src_field_PY = EcanConvertToCh.convertCh(source.field_name_Ch);

            string src_table = src_case_no + src_file_PY + src_sheet_PY;

            string sql = "select " + src_field_PY + " from " + src_table + ";";

            //QQ好友列表中存在多数
            DataSet data_set = MySqlHelper.GetDataSet(MySqlHelper.Conn, System.Data.CommandType.Text, sql);
            foreach (DataTable dt in data_set.Tables)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    foreach (DataColumn dc in dt.Columns)
                    {
                        string src_field_value = dr[dc].ToString();  //取得其中一个QQ

                        //进行遍历其他范围
                        int target_count = source.target_list.Count;
                        for (int i_target = 0; i_target < target_count; i_target++)
                        {
                            STargetItem target = source.target_list[i_target];

                            string target_case_no = target.case_no;
                            string target_file_PY = EcanConvertToCh.convertCh(target.file_name_Ch);
                            string target_sheet_PY = EcanConvertToCh.convertCh(target.sheet_name_Ch);
                            string target_field_PY = EcanConvertToCh.convertCh(target.field_name_Ch);

                            string target_table = target_case_no + target_file_PY + target_sheet_PY;


                            if (hasExist(src_field_value, target_table, target_field_PY))
                            {
                                //记录其中一个QQ找到了互为好友的
                                SField field = new SField();
                                field.value = src_field_value;
                                field.target_list = new List<SMatchConditionTarget>();

                                //记录符合条件的信息
                                SMatchConditionTarget match_target = new SMatchConditionTarget();
                                match_target.case_no = target.case_no;
                                match_target.file_name_Ch = target.file_name_Ch;
                                match_target.sheet_name_Ch = target.sheet_name_Ch;
                                match_target.field_name_Ch = target.field_name_Ch;
                                match_target.field_value = src_field_value;

                                field.target_list.Add(match_target);  //字段 对应 符合条件信息
                                result.field_values.Add(field);   // 将其中的一个字段值对比结果符合条件的记录
                            }
                            else
                            {

                            }
                        }
                    }
                }
            }

            return true;
        }

        #endregion

        #region 互为共同QQ好友
        public static bool isMutualQQFried(ref SSourceItem source, ref SResult result)
        {
            MessageBox.Show("把我调用啦！");
            return true;
            /*
            string src_case_no = source.case_no;
            string src_file_PY = EcanConvertToCh.convertCh(source.file_name_Ch);
            string src_sheet_PY = EcanConvertToCh.convertCh(source.sheet_name_Ch);
            string src_field_PY = EcanConvertToCh.convertCh(source.field_name_Ch);
            string src_table = src_case_no + src_file_PY + src_sheet_PY;

            string sql = "select " + src_field_PY + " from " + src_table + ";";
            DataSet data_set = MySqlHelper.GetDataSet(MySqlHelper.Conn, System.Data.CommandType.Text, sql);

            foreach (DataTable dt in data_set.Tables)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    foreach (DataColumn dc in dt.Columns)
                    {
                        string src_field_value = dr[dc].ToString();  //取得其中一个QQ

                        //进行遍历其他范围
                        int target_count = source.target_list.Count;
                        for (int i_target = 0; i_target < target_count; i_target++)
                        {
                            STargetItem target = source.target_list[i_target];

                            string target_case_no = target.case_no;
                            string target_file_PY = EcanConvertToCh.convertCh(target.file_name_Ch);
                            string target_sheet_PY = EcanConvertToCh.convertCh(target.sheet_name_Ch);
                            string target_field_PY = EcanConvertToCh.convertCh(target.field_name_Ch);

                            string target_table = target_case_no + target_file_PY + target_sheet_PY;


                            if (hasExist(src_field_value, target_table, target_field_PY))
                            {
                                //记录其中一个QQ找到了互为好友的
                                SField field = new SField();
                                field.value = src_field_value;
                                field.target_list = new List<SMatchConditionTarget>();

                                //记录符合条件的信息
                                SMatchConditionTarget match_target = new SMatchConditionTarget();
                                match_target.case_no = target.case_no;
                                match_target.file_name_Ch = target.file_name_Ch;
                                match_target.sheet_name_Ch = target.sheet_name_Ch;
                                match_target.field_name_Ch = target.field_name_Ch;
                                match_target.field_value = src_field_value;

                                field.target_list.Add(match_target);  //字段 对应 符合条件信息
                                result.field_values.Add(field);   // 将其中的一个字段值对比结果符合条件的记录
                            }
                            else
                            {

                            }
                        }
                        //进行第二次遍历
                        
                    }
                }
            }
            return true;*/
        }
        #endregion

        #region 与规则中的源存在共同QQ群

        public static bool Alg_hasCommonQQteam(ref SSourceItem source, ref SResult result)
        {
            string src_case_no = source.case_no;
            string src_file_PY = EcanConvertToCh.convertCh(source.file_name_Ch);
            string src_sheet_PY = EcanConvertToCh.convertCh(source.sheet_name_Ch);
            string src_field_PY = EcanConvertToCh.convertCh(source.field_name_Ch);

            string src_table = src_case_no + src_file_PY + src_sheet_PY;

            string sql = "select " + src_field_PY + " from " + src_table + ";";

            //QQ好友列表中存在多数
            DataSet data_set = MySqlHelper.GetDataSet(MySqlHelper.Conn, System.Data.CommandType.Text, sql);
            foreach (DataTable dt in data_set.Tables)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    foreach (DataColumn dc in dt.Columns)
                    {
                        string src_field_value = dr[dc].ToString();  //取得其中一个QQ

                        //进行遍历其他范围
                        int target_count = source.target_list.Count;
                        for (int i_target = 0; i_target < target_count; i_target++)
                        {
                            STargetItem target = source.target_list[i_target];

                            string target_case_no = target.case_no;
                            string target_file_PY = EcanConvertToCh.convertCh(target.file_name_Ch);
                            string target_sheet_PY = EcanConvertToCh.convertCh(target.sheet_name_Ch);
                            string target_field_PY = EcanConvertToCh.convertCh(target.field_name_Ch);

                            string target_table = target_case_no + target_file_PY + target_sheet_PY;


                            if (hasExist(src_field_value, target_table, target_field_PY))
                            {
                                //记录其中一个QQ找到了互为好友的
                                SField field = new SField();
                                field.value = src_field_value;
                                field.target_list = new List<SMatchConditionTarget>();

                                //记录符合条件的信息
                                SMatchConditionTarget match_target = new SMatchConditionTarget();
                                match_target.case_no = target.case_no;
                                match_target.file_name_Ch = target.file_name_Ch;
                                match_target.sheet_name_Ch = target.sheet_name_Ch;
                                match_target.field_name_Ch = target.field_name_Ch;
                                match_target.field_value = src_field_value;

                                field.target_list.Add(match_target);  //字段 对应 符合条件信息
                                result.field_values.Add(field);   // 将其中的一个字段值对比结果符合条件的记录
                            }
                            else
                            {

                            }
                        }
                    }
                }
            }

            return true;
        }

        #endregion

        #region 同一个终端登录过

        /// <summary>
        /// 算法思路
        /// 1、先读取规则中源的
        /// 
        /// </summary>
        /// <returns></returns>
        public static bool Alg_isOneMachine()
        {
            

            return true;
        }

        #endregion
    }
}
