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
        
    }
}
