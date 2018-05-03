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
        public StudentInfo GetStudentById(int id)
        {
            return stuDal.GetStudentById(id);
        }
        public bool Update(StudentInfo stu)
        {
            return stuDal.Update(stu) > 0;
        }
        public bool Delete(int stuId)
        {
            return stuDal.Delete(stuId) > 0;
        }
        public bool Add(StudentInfo stu)
        {
            return stuDal.AddStudent(stu) > 0;
        }
    }
}
