using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Text;
using StudentSys.BLL;
using StudentSys.Model;

namespace StudentSys.UI
{
    /// <summary>
    /// StudentHandler 的摘要说明
    /// </summary>
    public class StudentHandler : IHttpHandler
    {
        ClassInfoBLL clsBll = new ClassInfoBLL();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";

            //0.接收从ClassInfoUI传递来的参数
            int clsId = Convert.ToInt32(context.Request.QueryString["clsId"]);
            string clsName = clsBll.GetClassNameById(Convert.ToInt32(clsId));
            if (!String.IsNullOrEmpty(clsId.ToString()))
            {
                string html = File.ReadAllText(context.Request.MapPath("StudentInfoUI.html"));
                StudentInfoBLL stuBll = new StudentInfoBLL();
                List<StudentInfo> stuList = stuBll.GetStudentByClsId(clsId);
                StringBuilder sbTrs = new StringBuilder();
                foreach (StudentInfo stu in stuList)
                {
                    sbTrs.Append("<tr>");
                    sbTrs.Append("<td>" + stu.Id.ToString() + "</td>");
                    sbTrs.Append("<td>" + stu.StuNo + "</td>");
                    sbTrs.Append("<td>" + stu.Name + "</td>");
                    sbTrs.Append("<td>" + stu.Gender + "</td>");
                    sbTrs.Append("<td>" + stu.Address + "</td>");
                    sbTrs.Append("<td>" + stu.Phone + "</td>");
                    sbTrs.Append("<td><a href='UpdateStudentHandler.ashx?stuId=" + stu.Id + "'>修改    </a><a href='javascript:void(0)' onclick='doDelete(" + stu.Id + ")'>删除</a></td>");
                    sbTrs.Append("</tr>");
                }


                //4.把生成的字符串，嵌入到静态页的tbody标签里
                html = html.Replace("{@tableContent}", sbTrs.ToString());
                html = html.Replace("{@clsName}", clsName);

                //5.把拼写完整的html页面内容输出到客户端
                context.Response.Write(html);
            }
            else
            {
                //跳转，也叫重定向
                context.Response.Redirect("ClassHandler.ashx");
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