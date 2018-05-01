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
            string html = System.IO.File.ReadAllText(context.Request.MapPath("ClassList.html"));
            ClassInfoBLL clsBll = new ClassInfoBLL();
            List<ClassInfo> clsList = clsBll.GetClassList();
            StringBuilder sbTrs = new StringBuilder();
            foreach (ClassInfo cls in clsList)
            {
                sbTrs.Append("<tr>");
                sbTrs.Append("<td>" + cls.Id.ToString() + "</td>");
                sbTrs.Append("<td>" + cls.Name + "</td>");
                sbTrs.Append("<td>" + cls.Teacher + "</td>");
                sbTrs.Append("<td>" + cls.Remark + "</td>");
                sbTrs.Append("</tr>");
            }
            html = html.Replace("{@ClassContent}", sbTrs.ToString());
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