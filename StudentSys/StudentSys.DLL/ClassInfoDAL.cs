using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using StudentSys.Common;
using StudentSys.Model;


namespace StudentSys.DAL
{
    public class ClassInfoDAL
    {
        public List<ClassInfo> GetClassList()
        {
            string sql = "select id,cName,cTeacher,cRemark from Classes";
            return ClassInfo.TableToList(DBHelper.GetDataSet(sql, System.Data.CommandType.Text).Tables[0]);
        }
        public ClassInfo GetClassById(int id)
        {
            ClassInfo cls = new ClassInfo();
            string sql = "select id,cName,cTeacher,cRemark from Classes where id=@id";
            SqlParameter sp = new SqlParameter("@id", id);

            List<ClassInfo> clsList = ClassInfo.TableToList(DBHelper.GetDataSet(sql, CommandType.Text, sp).Tables[0]);
            if (clsList.Count>0)
            {
                cls= clsList[0];
            }
            return cls;
        }

        public int Update(ClassInfo cls)
        {
            string sql = "update Classes set cName=@name,cTeacher=@teacher,cRemark=@remark where id=@clsId";
            SqlParameter spName = new SqlParameter("@name", SqlDbType.NVarChar) { Value = cls.Name };
            SqlParameter spTeacher = new SqlParameter("@teacher", SqlDbType.NVarChar) { Value = cls.Teacher };
            SqlParameter spRemark = new SqlParameter("@remark", SqlDbType.NVarChar) { Value = cls.Remark };
            SqlParameter spId = new SqlParameter("@clsId", SqlDbType.Int) { Value = cls.Id };
            return DBHelper.ExcuteNonQuery(sql, CommandType.Text, spId, spName, spRemark, spTeacher);
        }
        public int Add(ClassInfo cls)
        {
            string sql = "insert into Classes(cName,cTeacher,cRemark) values(@name,@teacher,@remark)";
            SqlParameter spName = new SqlParameter("@name", SqlDbType.NVarChar) { Value = cls.Name };
            SqlParameter spTeacher = new SqlParameter("@teacher", SqlDbType.NVarChar) { Value = cls.Teacher };
            SqlParameter spRemark = new SqlParameter("@remark", SqlDbType.NVarChar) { Value = cls.Remark };
            return DBHelper.ExcuteNonQuery(sql, CommandType.Text,  spName, spRemark, spTeacher);
        }
    }
}
