using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using StudentSys.Common;
using StudentSys.Model;

namespace StudentSys.DLL
{
    public class StudentInfoDAL
    {
        public List<StudentInfo> GetStudentsByClsId(int clsId)
        {
            string sql = "select id,sName,sNo,sGender,sAddress,sPhone,sClsId from Students where sClsId=@clsId";
            SqlParameter sp=new SqlParameter("@clsId",SqlDbType.Int){Value=clsId};
            return StudentInfo.TableToList(DBHelper.GetDataSet(sql, CommandType.Text, sp).Tables[0]);
        }
        public StudentInfo GetStudentById(int id)
        {
            string sql = "select id,sName,sNo,sGender,sAddress,sPhone,sClsId from Students where id=@id";
            SqlParameter sp = new SqlParameter("@id", SqlDbType.Int) { Value = id };
            DataSet ds=DBHelper.GetDataSet(sql,CommandType.Text,sp);

            StudentInfo stu = new StudentInfo();

            if (ds.Tables.Count>0)
            {
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count >0)
                {
                    stu = StudentInfo.TableToList(dt)[0];
                }
            }
            return stu;
        }
    }
}
