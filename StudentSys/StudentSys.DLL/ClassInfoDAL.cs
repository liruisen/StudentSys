using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
