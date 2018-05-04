using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace StudentSys.Common
{
    public class DBHelper
    {
        private static string connString;
        static DBHelper()
        {
            connString = ConfigurationManager.AppSettings["StudentSysConnStr"];
        }
        /// <summary>
        /// 对连接执行T-SQL语句，并返回受影响的行数
        /// </summary>
        /// <param name="cmdText">SQL语句</param>
        /// <param name="parameters">参数化查询可变长变量名</param>
        /// <returns>int类型的受影响行数</returns>
        static public int ExcuteNonQuery(string cmdText, CommandType cmdType, params SqlParameter[] parameters)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connString))
                {
                    using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                    {
                        cmd.CommandType = cmdType;
                        connection.Open();
                        if (parameters.Length > 0)
                        {
                            cmd.Parameters.AddRange(parameters);
                        }
                        return cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        //static public object ExcuteScalar(string cmdText, params SqlParameter[] parameters)
        //{
        //    using (SqlConnection connection = new SqlConnection(connString))
        //    {
        //        using (SqlCommand cmd = new SqlCommand(cmdText, connection))
        //        {
        //            connection.Open();
        //            if (parameters.Length > 0)
        //            {
        //                cmd.Parameters.AddRange(parameters);
        //            }

        //            return cmd.ExecuteScalar();
        //        }
        //    }
        //}



        /// <summary>
        /// 封装泛型ExcuteScalar
        /// </summary>
        /// <typeparam name="T">需要返回的数据类型</typeparam>
        /// <param name="cmdText">SQL语句</param>
        /// <param name="cmdType">SQL语句类型</param>
        /// <param name="parameters">SQL参数</param>
        /// <returns>一条指定类型的SQL查询结果</returns>
        static public T ExcuteScalar<T>(string cmdText, CommandType cmdType, params SqlParameter[] parameters)
        {
            using (SqlConnection connection = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    cmd.CommandType = cmdType;
                    connection.Open();
                    if (parameters.Length > 0)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }

                    return (T)cmd.ExecuteScalar();
                }
            }
        }
        /// <summary>
        /// 封装ExcuteReader，执行一条查询结果为表值结果集的select语句
        /// </summary>
        /// <param name="cmdText">SQL语句</param>
        /// <param name="parameters">SQL参数</param>
        /// <returns>返回一个SqlDataReader类型的对象</returns>
        static public SqlDataReader ExcuteReader(string cmdText, CommandType cmdType, params SqlParameter[] parameters)
        {
            using (SqlConnection connection = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    cmd.CommandType = cmdType;
                    connection.Open();
                    if (parameters.Length > 0)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    return cmd.ExecuteReader(CommandBehavior.CloseConnection);
                }
            }
        }
        /// <summary>
        /// 封装DataSet
        /// </summary>
        /// <param name="cmdText">SQL语句</param>
        /// <param name="parameters">SQL参数</param>
        /// <returns>DataSet</returns>
        static public DataSet GetDataSet(string cmdText, CommandType cmdType, params SqlParameter[] parameters)
        {
            DataSet ds = new DataSet();
            using (SqlConnection connection = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    cmd.CommandType = cmdType;
                    
                    using (SqlDataAdapter adpater = new SqlDataAdapter(cmd))
                    {
                        if (parameters.Length > 0)
                        {
                            adpater.SelectCommand.Parameters.AddRange(parameters);
                        }
                        adpater.Fill(ds);
                    }
                }
            }
            return ds;
        }

        static public DataTable GetDataTable(string cmdText, CommandType cmdType, params SqlParameter[] parameters)
        {
            return GetDataSet(cmdText, cmdType, parameters).Tables[0];
        }
        static public DataTable GetDataTable(string cmdText, CommandType cmdType)
       {
           DataTable myTable = new DataTable();
           using (SqlConnection connection = new SqlConnection(connString))
           {

               using (SqlCommand cmd = new SqlCommand(cmdText, connection))
               {
                   cmd.CommandType = cmdType;
                   using (SqlDataAdapter adpater = new SqlDataAdapter(cmd))
                   {
                       adpater.Fill(myTable);
                   }
               }
               
           }
           return myTable;

        }
    }
}

