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
        public int Update(StudentInfo stu)
        {
            string sql = "update Students set sName=@name,sNo=@no,sAddress=@address,sPhone=@phone , sClsId=@clsId ,sGender=@gender where id=@id";
            SqlParameter spName = new SqlParameter("@name", SqlDbType.NVarChar) { Value = stu.Name };
            SqlParameter spNo = new SqlParameter("@no", SqlDbType.VarChar) { Value = stu.StuNo };
            SqlParameter spAddress = new SqlParameter("@address", SqlDbType.NVarChar) { Value = stu.Address };
            SqlParameter spPhone = new SqlParameter("@phone", SqlDbType.VarChar) { Value = stu.Phone };
            SqlParameter spGender = new SqlParameter("@gender", SqlDbType.Bit) { Value = stu.Gender == "男" ? true : false };
            SqlParameter spClsId = new SqlParameter("@clsId", SqlDbType.Int) { Value = stu.ClassId };
            SqlParameter spId = new SqlParameter("@id", SqlDbType.Int) { Value = stu.Id};
           return DBHelper.ExcuteNonQuery(sql, CommandType.Text, spAddress, spClsId, spGender, spId, spName, spNo, spPhone);
        }
        public int Delete(int stuId)
        {
            string sql = "delete from Students where id=@id";
            SqlParameter sp = new SqlParameter("@id", SqlDbType.Int) { Value = stuId };
            return DBHelper.ExcuteNonQuery(sql, CommandType.Text, sp);
        }
        public int AddStudent(StudentInfo stu)
        {
            string sql = "insert into Students(sName,sNo,sAddress,sPhone,sClsId,sGender) values(@name,@no,@address,@phone,@clsId,@gender)";
            SqlParameter spName = new SqlParameter("@name", SqlDbType.NVarChar) { Value = stu.Name };
            SqlParameter spNo = new SqlParameter("@no", SqlDbType.VarChar) { Value = stu.StuNo };
            SqlParameter spAddress = new SqlParameter("@address", SqlDbType.NVarChar) { Value = stu.Address };
            SqlParameter spPhone = new SqlParameter("@phone", SqlDbType.VarChar) { Value = stu.Phone };
            SqlParameter spGender = new SqlParameter("@gender", SqlDbType.Bit) { Value = stu.Gender == "男" ? true : false };
            SqlParameter spClsId = new SqlParameter("@clsId", SqlDbType.Int) { Value = stu.ClassId };
            return DBHelper.ExcuteNonQuery(sql, CommandType.Text, spAddress, spClsId, spGender, spName, spNo, spPhone);
        }
    }
}
