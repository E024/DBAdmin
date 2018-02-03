using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace DBAdmin
{
    public class SqlHelper
    {
        private static readonly string RETURNVALUE = "RETURNVALUE";
        public static bool isView = true;
        //数据库连接字符串
        public static string SQLCONSTR = "";

        #region 数据库的连接操作
        /// <summary>
        /// 打开数据库连接
        /// </summary>
        /// <param name="myConection"></param>
        public static bool Open(SqlConnection myConection)
        {
            bool isFire = false;
            if (myConection == null)
            {
                myConection = new SqlConnection(SQLCONSTR);
            }
            if (myConection.State == ConnectionState.Closed)
            {
                try
                {
                    //打开数据库连接
                    myConection.Open();
                    isFire = true;
                }
                catch (Exception ex)
                {
                    if (ex.Message.Equals("在与 SQL Server 建立连接时出现与网络相关的或特定于实例的错误。未找到或无法访问服务器。请验证实例名称是否正确并且 SQL Server 已配置为允许远程连接。 (provider: 命名管道提供程序, error: 40 - 无法打开到 SQL Server 的连接)"))
                    {
                        MessageBox.Show("打开连接失败，请确保您已经开启了SQL服务！\n \n------------------------------\n您可以尝试在右边执行 \"net start mssqlserver\" 命令来启动SQL服务！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show(ex.Message, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            return isFire;
        }

        /// <summary>
        /// 关闭数据库连接
        /// </summary>
        public static void Close(SqlConnection myConnection)
        {
            ///判断连接是否已经创建
            if (myConnection != null)
            {
                ///判断连接状态是否打开
                if (myConnection.State == ConnectionState.Open)
                {
                    myConnection.Close();
                }
            }
        }

        /// <summary>
        /// 关闭数据库连接
        /// </summary>
        public static void Close()
        {
            SqlConnection myConnection = new SqlConnection(SQLCONSTR);
            Close(myConnection);
        }

        /// <summary>
        /// 释放资源
        /// </summary>
        public static void Dispose(SqlConnection myConnection)
        {
            //确认连接是否已经关闭
            if (myConnection != null)
            {
                myConnection.Dispose();
                myConnection = null;

            }
        }
        #endregion

        #region 执行存储教程的重载方法

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="procName">存储过程的名称</param>
        /// <returns>返回存储过程的返回值</returns>
        public static int RunProc(string procName)
        {
            int count;
            using (SqlConnection myConnection = null)
            {
                using (SqlCommand cmd = CreateProcCommand(procName, null, myConnection))
                {
                    //try
                    //{
                    count = cmd.ExecuteNonQuery();

                    //}
                    //catch (Exception ex)
                    //{
                    //    MessageBox.Show(ex.Message);
                    //}
                    //finally
                    //{
                    Close(myConnection);

                    //}
                }
            }

            return count;
        }


        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="procName">存储过程名称</param>
        /// <param name="prams">存储过程所需参数</param>
        /// <returns>返回存储过程返回值</returns>
        public static int RunProc(string procName, SqlParameter[] prams)
        {
            int count;
            using (SqlConnection myConnection = null)
            {
                using (SqlCommand cmd = CreateProcCommand(procName, prams, myConnection))
                {
                    //try
                    //{
                    count = cmd.ExecuteNonQuery();

                    //}
                    //catch (Exception ex)
                    //{
                    //    MessageBox.Show(ex.Message);
                    //}
                    //finally
                    //{
                    Close(myConnection);
                    //}

                }
            }
            return count;

        }

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="procName">存储过程的名称</param>
        /// <param name="dataReader">存储过程返回DataReader对象</param>
        public static void RunProc(string procName, out SqlDataReader dataReader)
        {
            SqlConnection myConnection = new SqlConnection(SQLCONSTR);

            using (SqlCommand cmd = CreateProcCommand(procName, null, myConnection))
            {
                try
                {
                    dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                }
                catch (Exception ex)
                {
                    dataReader = null;
                    MessageBox.Show(ex.Message);
                    //frmError fe = new frmError(ex.Message);
                    //fe.Show();
                }
            }

        }

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="procName">存储过程的名称</param>
        /// <param name="prams">存储过程所需参数</param>
        /// <param name="dataReader">返回DataReader对象</param>
        public static void RunProc(string procName, SqlParameter[] prams, out SqlDataReader dataReader)
        {
            SqlConnection myConnection = null;

            using (SqlCommand cmd = CreateProcCommand(procName, prams, myConnection))
            {
                try
                {
                    dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                }
                catch (Exception ex)
                {
                    dataReader = null;
                    MessageBox.Show(ex.Message);
                    //frmError fe = new frmError(ex.Message);
                    //fe.Show();
                }
            }

        }

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="procName">存储过程的名称</param>
        /// <param name="dataSet">返回DataSet对象</param>
        public static void RunProc(string procName, ref DataSet dataSet)
        {
            if (dataSet == null)
            {
                dataSet = new DataSet();
            }
            using (SqlConnection myConnection = new SqlConnection(SQLCONSTR))
            {

                SqlDataAdapter da = CreateProcDataAdapter(procName, null, myConnection);

                try
                {
                    da.Fill(dataSet);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    //frmError fe = new frmError(ex.Message);
                    //fe.Show();
                }
                finally
                {
                    Close(myConnection);
                }
            }
        }

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="procName">存储过程的名称</param>
        /// <param name="prams">存储过程所需参数</param>
        /// <param name="dataSet">返回DataSet对象</param>
        public static void RunProc(string procName, SqlParameter[] prams, ref DataSet dataSet)
        {

            if (dataSet == null)
            {
                dataSet = new DataSet();
            }
            using (SqlConnection myConnection = null)
            {
                SqlDataAdapter da = CreateProcDataAdapter(procName, prams, myConnection);

                try
                {
                    da.Fill(dataSet);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    //frmError fe = new frmError(ex.Message);
                    //fe.Show();
                }
                finally
                {
                    Close(myConnection);
                }
            }
        }

        #endregion



        #region 创建一个SqlCommand对象以此来执行存储过程
        /// <summary>
        /// 创建一个SqlCommand对象以此来执行存储过程
        /// </summary>
        /// <param name="procName">存储过程的名称</param>
        /// <param name="prams">存储过程所需的参数</param>
        /// <returns>返回SqlCommand对象</returns>
        private static SqlCommand CreateProcCommand(string procName, SqlParameter[] prams, SqlConnection myConnection)
        {
            ///打开数据库连接
            Open(myConnection);

            ///设置Command
            SqlCommand cmd = new SqlCommand(procName, myConnection);
            cmd.CommandType = CommandType.StoredProcedure;

            ///添加存储过程的参数
            if (prams != null)
            {
                foreach (SqlParameter parameter in prams)
                {
                    cmd.Parameters.Add(parameter);
                }

            }

            ///添加返回参数ReturnValue
            cmd.Parameters.Add(new SqlParameter(RETURNVALUE, SqlDbType.Int, 4, ParameterDirection.ReturnValue,
                false, 0, 0, string.Empty, DataRowVersion.Default, null));

            ///返回创建的SqlCommand对象
            return cmd;
        }

        #endregion



        #region 创建一个SqlDataAdapter对象，用此来执行存储过程
        /// <summary>
        /// 创建一个SqlDataAdapter对象，用此来执行存储过程
        /// </summary>
        /// <param name="procName">存储过程的名称</param>
        /// <param name="prams">存储过程所需参数</param>
        /// <returns>返回SqlDataAdapter对象</returns>
        private static SqlDataAdapter CreateProcDataAdapter(string procName, SqlParameter[] prams, SqlConnection myConnection)
        {
            Open(myConnection);
            SqlDataAdapter da = new SqlDataAdapter(procName, myConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            if (prams != null)
            {
                foreach (SqlParameter parameter in prams)
                {
                    da.SelectCommand.Parameters.Add(parameter);
                }
            }

            da.SelectCommand.Parameters.Add(
                new SqlParameter(RETURNVALUE, SqlDbType.Int, 4, ParameterDirection.ReturnValue,
                false, 0, 0, string.Empty, DataRowVersion.Default, null));

            return da;
        }
        #endregion

        #region 创建一个SqlDataAdapter对象，用此来执行SQL语句

        /// <summary>
        /// 创建一个SqlDataAdapter对象，用此来执行SQL语句
        /// </summary>
        /// <param name="cmdText">SQL语句</param>
        /// <param name="prams">SQL语句所需参数</param>
        /// <returns>返回SqlDataAdapter对象</returns>
        public static SqlDataAdapter CreateSQLDataAdapter(string cmdText, SqlParameter[] prams, SqlConnection myConnection)
        {
            Open(myConnection);
            SqlDataAdapter da = new SqlDataAdapter(cmdText, myConnection);
            if (prams != null)
            {
                foreach (SqlParameter parameter in prams)
                {
                    da.SelectCommand.Parameters.Add(parameter);
                }
            }
            da.SelectCommand.Parameters.Add(
                new SqlParameter(RETURNVALUE, SqlDbType.Int, 4, ParameterDirection.ReturnValue,
                false, 0, 0, string.Empty, DataRowVersion.Default, null));

            return da;

        }
        #endregion

        #region 生成存储过程参数
        /// <summary>
        /// 生成存储过程参数
        /// </summary>
        /// <param name="ParamName">存储过程名称</param>
        /// <param name="DbType">参数类型</param>
        /// <param name="Size">参数大小</param>
        /// <param name="Direction">参数方向</param>
        /// <param name="Value">参数值</param>
        /// <returns>新的parameter对象</returns>
        public static SqlParameter CreateParam(string ParamName, SqlDbType DbType, Int32 Size, ParameterDirection Direction, object Value)
        {
            SqlParameter param;

            ///当参数大小为0时，不使用该参数大小值
            if (Size > 0)
            {
                param = new SqlParameter(ParamName, DbType, Size);
            }
            else
            {
                param = new SqlParameter(ParamName, DbType);
            }
            ///创建输出类型的参数
            param.Direction = Direction;
            if (!(Direction == ParameterDirection.Output && Value == null))
            {
                param.Value = Value;
            }
            ///返回创建的参数
            return param;
        }
        #endregion


        #region 传入输入、返回值参数
        /// <summary>
        /// 传入输入参数
        /// </summary>
        /// <param name="ParamName">存储过程名称</param>
        /// <param name="DbType">参数类型</param>
        /// <param name="Size">参数大小</param>
        /// <param name="Value">参数值</param>
        /// <returns>新的parameter对象</returns>
        public static SqlParameter CreateInParam(string ParamName, SqlDbType DbType, int Size, object Value)
        {
            return CreateParam(ParamName, DbType, Size, ParameterDirection.Input, Value);
        }

        public static SqlParameter CreateInParam(string ParamName, SqlDbType DbType, object Value)
        {
            return CreateParam(ParamName, DbType, 0, ParameterDirection.Input, Value);
        }


        /// <summary>
        /// 创建一个输出型参数
        /// </summary>
        /// <param name="ParamName">存储过程名称</param>
        /// <param name="DbType">参数类型</param>
        /// <param name="Size">参数大小</param>
        /// <returns>新的parameter对象</returns>
        public static SqlParameter CreateOutParam(string ParamName, SqlDbType DbType, int Size)
        {
            return CreateParam(ParamName, DbType, Size, ParameterDirection.Output, null);
        }

        /// <summary>
        /// 创建一个输出型参数
        /// </summary>
        /// <param name="ParamName">存储过程名称</param>
        /// <param name="DbType">参数类型</param>
        /// <returns>新的parameter对象</returns>
        public static SqlParameter CreateOutParam(string ParamName, SqlDbType DbType)
        {
            return CreateParam(ParamName, DbType, 0, ParameterDirection.Output, null);
        }

        /// <summary>
        /// 传入返回值参数
        /// </summary>
        /// <param name="ParamName">存储过程名称</param>
        /// <param name="DbType">参数类型</param>
        /// <param name="Size">参数大小</param>
        /// <returns>新的parameter对象</returns>
        public static SqlParameter CreateReturnParam(string ParamName, SqlDbType DbType, int Size)
        {
            return CreateParam(ParamName, DbType, Size, ParameterDirection.ReturnValue, null);
        }
        #endregion


        /// <summary>
        /// 获取连接数据库的名称
        /// </summary>
        /// <returns></returns>
        public static string GetTableName()
        {
            SqlConnection myConnection = new SqlConnection(SQLCONSTR);
            if (myConnection.Database == string.Empty)
            {
                return "无连接";
            }
            else
            {
                return myConnection.Database;
            }
        }


        //创建数据集
        public static SqlDataReader ResultSet(string sql)
        {
            SqlConnection con = new SqlConnection(SQLCONSTR);
            con.Open();
            SqlCommand com = new SqlCommand(sql, con);
            return com.ExecuteReader(CommandBehavior.CloseConnection);
        }

        /// <summary>
        /// 填充数据集
        /// </summary>
        public static SqlDataAdapter da;
        public static void FillDataSet(string sql, DataSet ds)
        {
            SqlConnection con = new SqlConnection(SQLCONSTR);
            da = new SqlDataAdapter(sql, con);
            da.Fill(ds);
        }

    }

}
