using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace StudentSys.Model
{
    public class ClassInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Teacher { get; set; }
        public string Remark { set; get; }

        public static List<ClassInfo> TableToList(DataTable dt)
        {
            List<ClassInfo> clsList = new List<ClassInfo>();
            foreach (DataRow row in dt.Rows)
            {
                ClassInfo cls = new ClassInfo();
                cls.Id = Convert.ToInt32(row["id"]);
                cls.Name = row["cName"].ToString();
                cls.Teacher = row["cTeacher"].ToString();
                cls.Remark = row["cRemark"].ToString();
                clsList.Add(cls);
            }

            return clsList;
        }
    }
}
