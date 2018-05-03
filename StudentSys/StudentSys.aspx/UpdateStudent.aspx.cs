using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using StudentSys.BLL;
using StudentSys.Common;
using StudentSys.Model;

namespace StudentSys.aspx
{
    public partial class UpdateStudent : System.Web.UI.Page
    {
        protected StringBuilder sbOpts;

        protected StudentInfo stu;

        ClassInfoBLL clsBll = new ClassInfoBLL();
        StudentInfoBLL stuBll = new StudentInfoBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.HttpMethod.ToUpper()=="GET")
            {
                this.DoGet();
            }
            else
            {
                this.DoPost();
            }
        }
        private void DoGet()
        {

            //0.获取从学生列表页中传递过来的学生Id
            string stuId =  Request.QueryString["stuId"];
            if (!String.IsNullOrEmpty(stuId))
            {
                int sId = int.Parse(stuId);

                //2.从数据库中读取该Id的学生信息
                stu = stuBll.GetStudentById(sId);
               
                //3.2替换表单元素select中的班级选项
                //从数据库中读取所有的班级信息
                sbOpts = new StringBuilder();

                List<ClassInfo> clsList = clsBll.GetClassList();
                foreach (ClassInfo cls in clsList)
                {
                    if (stu.ClassId == cls.Id)//这个班级应该作为默认选项
                    {
                        sbOpts.Append("<option value='" + cls.Id + "' selected='selectes'>" + cls.Name + "</option>");
                    }
                    else
                    {
                        sbOpts.Append("<option value='" + cls.Id + "'>" + cls.Name + "</option>");
                    }
                }
               
            }
        }

        private void DoPost()
        {
            //0.获取表单元素
            //
            string stuId =  Request.Form["stuId"];

            string stuName =  Request.Form["stuName"];
            string stuNo =  Request.Form["stuNo"];
            string stuGender =  Request.Form["stuGender"];
            string stuPhone =  Request.Form["stuPhone"];
            string stuAddress =  Request.Form["stuAddress"];
            string stuClsId =  Request.Form["stuClass"];

            StudentInfo student = new StudentInfo();

            student.Id = int.Parse(stuId);
            student.Name = stuName;
            student.Phone = stuPhone;
            student.Address = stuAddress;
            student.ClassId = int.Parse(stuClsId);
            student.Gender = stuGender;
            student.StuNo = stuNo;

            //1.调用StudnetInfoBll，完成修改的逻辑业务
            if (stuBll.Update(student))
            {
                //跳转，也叫重定向
                 Response.Redirect("StudentList.aspx?clsId=" + stuClsId);
            }
           
        }
    }
}