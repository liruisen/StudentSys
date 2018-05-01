using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentSys.DLL;
using StudentSys.Model;


namespace StudentSys.BLL
{
    public class StudentInfoBLL
    {
        private StudentInfoDAL stuDal = new StudentInfoDAL();
        public List<StudentInfo> GetStudentByClsId(int clsId)
        {
            return stuDal.GetStudentsByClsId(clsId);
        }
    }
}
