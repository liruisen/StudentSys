using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using StudentSys.Model;
using StudentSys.BLL;

namespace StudentSys.UI
{
    /// <summary>
    /// ClassHandler 的摘要说明
    /// </summary>
    public class ClassHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            //context.Response.Write("Hello World");
            //1.把静态页ClassInfoUi.html中读取到内存中，这个静态页就是一个模板
            string html = System.IO.File.ReadAllText(context.Request.MapPath("ClassInfoUI.html"));
            //2.把班级信息从数据库中读取出来
            ClassInfoBLL clsBll = new ClassInfoBLL();
            List<ClassInfo> clsList = clsBll.GetClassList();
            //3把Datatable中的数据，拼写成由html标记包裹住的字符串
            StringBuilder sbTrs = new StringBuilder();
            foreach (ClassInfo cls in clsList)
            {
                sbTrs.Append("<tr>");
                sbTrs.Append("<td>" + cls.Id.ToString() + "</td>");
                sbTrs.Append("<td>" + cls.Name + "</td>");
                sbTrs.Append("<td>" + cls.Teacher + "</td>");
                sbTrs.Append("<td>" + cls.Remark + "</td>");
                sbTrs.Append("<td><a href='StudentHandler.ashx?clsId="+cls.Id.ToString()+"' style='text-decoration:none;'>查看学生</a></td>");
                sbTrs.Append("</tr>");
            }
            //4.把生成的字符串，嵌入到静态页的tbody标签里
            html = html.Replace("{@ClassContent}", sbTrs.ToString());
            //5.把拼写完整的html页面内容输出到客户端
            context.Response.Write(html);
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