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
    }
}
