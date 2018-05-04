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
            if (context.Request.HttpMethod.ToUpper()=="GET")
            {
                this.DoGet(context);
            }
            else
            {
                this.DoPost(context);
            }
        }
        private void DoGet(HttpContext context)
        {

            //0.获取从学生列表页中传递过来的学生Id
            string stuId = context.Request.QueryString["stuId"];
            if (!String.IsNullOrEmpty(stuId))
            {
                int sId = int.Parse(stuId);
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
                if (stu.Gender == "男")
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
                    if (stu.ClassId == cls.Id)//这个班级应该作为默认选项
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

        private void DoPost(HttpContext context)
        {
            //0.获取表单元素
            //
            string stuId = context.Request.Form["stuId"];

            string stuName = context.Request.Form["stuName"];
            string stuNo = context.Request.Form["stuNo"];
            string stuGender = context.Request.Form["stuGender"];
            string stuPhone = context.Request.Form["stuPhone"];
            string stuAddress = context.Request.Form["stuAddress"];
            string stuClsId= context.Request.Form["stuClass"];

            StudentInfo stu = new StudentInfo();
            stu.Id = int.Parse(stuId);
            stu.Name = stuName;
            stu.Phone = stuPhone;
            stu.Address = stuAddress;
            stu.ClassId = int.Parse(stuClsId);
            stu.Gender = stuGender;
            stu.StuNo = stuNo;

            //1.调用StudnetInfoBll，完成修改的逻辑业务
            if (stuBll.Update(stu))
            {
                //跳转，也叫重定向
                context.Response.Redirect("StudentHandler.ashx?clsId="+stuClsId);
            }
            //else
            //{
            //    //跳转，也叫重定向
            //    context.Response.Redirect("ClassHandler.ashx");
            //}
            //2.跳转到StudnetUI.html上
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