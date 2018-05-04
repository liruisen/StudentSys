using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentSys.Model;
using StudentSys.DAL;

namespace StudentSys.BLL
{
    public class ClassInfoBLL
    {
        private ClassInfoDAL clsDal = new ClassInfoDAL();
        public List<ClassInfo> GetClassList()
        {
            return clsDal.GetClassList();
        }
        public string  GetClassNameById(int id)
        {
            return clsDal.GetClassById(id).Name;
        }

        public ClassInfo GetClassById(int id)
        {
            return clsDal.GetClassById(id);
        }
        public bool Update(ClassInfo cls)
        {
            return clsDal.Update(cls) > 0;
        }
        public bool Add(ClassInfo cls)
        {
            return clsDal.Add(cls) > 0;
        }
    }
}
