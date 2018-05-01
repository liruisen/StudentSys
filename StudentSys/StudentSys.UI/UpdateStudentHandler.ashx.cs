using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using StudentSys.BLL;
using StudentSys.Model;
using System.IO;

namespace StudentSys.UI
{
    /// <summary>
    /// UpdateStudentHandler 的摘要说明
    /// </summary>
    public class UpdateStudentHandler : IHttpHandler
    {
        StudentInfoBLL stuBll = new StudentInfoBLL();
        ClassInfoBLL clsBll = new ClassInfoBLL();
        public void ProcessRequest(HttpContext context)
        {
           //0.获取从学生列表页中传递过来的学生Id
            string stuId = context.Request.QueryString["stuId"];
            if (!String.IsNullOrEmpty(stuId))
            {
                int sId=int.Parse(stuId);
                //1.加载静态页模板
                string html = File.ReadAllText(context.Request.MapPath("UpdateStudent.html"));

                //2.从数据库中读取该Id的学生信息
                StudentInfo stu = stuBll.GetStudentById(sId);
                //3.替换模板中的占位符
                html = html.Replace("{@stuId}", stu.Id.ToString());
                html = html.Replace("{@stuNo}", stu.StuNo);
                html = html.Replace("{@stuName}", stu.Name);
                html = html.Replace("{@stuPhone}", stu.Phone);
                html = html.Replace("{@stuAddress}", stu.Address);
                //3.1替换 性别占位符
                if (stu.Gender=="男")
                {
                    html = html.Replace("{@male}", "checked").Replace("{@fmale}", "");
                }
                else
                {
                    html = html.Replace("{@male}", "").Replace("{@fmale}", "checked");
                }

                //3.2替换表单元素select中的班级选项
                //从数据库中读取所有的班级信息
                StringBuilder sbOpts = new StringBuilder();

                List<ClassInfo> clsList = clsBll.GetClassList();
                foreach (ClassInfo cls in clsList)
                {
                    if (stu.ClassId==cls.Id)//这个班级应该作为默认选项
                    {
                        sbOpts.Append("<option value='" + cls.Id + "' selected='selectes'>" + cls.Name + "</option>");
                    }
                    else
                    {
                        sbOpts.Append("<option value='" + cls.Id + "'>" + cls.Name + "</option>");
                    }
                }
                html = html.Replace("{@stuClass}", sbOpts.ToString());

                //4.把生成的html发送到客户端
                context.Response.Write(html);
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}