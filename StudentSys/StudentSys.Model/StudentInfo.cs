using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace StudentSys.Model
{
   public  class StudentInfo
    {
       public int Id { get; set; }
       public string Name { get; set; }
       public string StuNo { get; set; }
       private bool gender;
       public string Gender
       {
           get
           {
               return this.gender ? "男" : "女";
           }
           set
           {
               this.gender = value == "男" ? true : false;
           }
       }
       public string Address { get; set; }
       public string Phone { get; set; }
       public int ClassId { get; set; }


       public static List<StudentInfo> TableToList(DataTable dt)
       {
           List<StudentInfo> stuList = new List<StudentInfo>();
           foreach (DataRow row in dt.Rows)
           {
               StudentInfo stu = new StudentInfo();
               stu.Id = Convert.ToInt32(row["id"]);
               stu.Name = row["sName"].ToString();
               stu.StuNo = row["sNo"].ToString();
               stu.gender = Convert.ToBoolean(row["sGender"]);
               stu.Address = row["sAddress"].ToString();
               stu.Phone = row["sPhone"].ToString();
               stu.ClassId = Convert.ToInt32(row["sClsId"]);
               stuList.Add(stu);

           }
           return stuList;
       }
    }
}
