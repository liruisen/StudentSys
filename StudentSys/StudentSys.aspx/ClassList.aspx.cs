using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using StudentSys.BLL;
using StudentSys.Model;
using StudentSys.Common;

namespace StudentSys.aspx
{
    public partial class ClassList : System.Web.UI.Page
    {
        protected StringBuilder sbTrs;
        protected void Page_Load(object sender, EventArgs e)
        {
            ClassInfoBLL clsBll = new ClassInfoBLL();
            List<ClassInfo> clsList = clsBll.GetClassList();
            //3把Datatable中的数据，拼写成由html标记包裹住的字符串
            sbTrs= new StringBuilder();
            foreach (ClassInfo cls in clsList)
            {
                sbTrs.Append("<tr>");
                sbTrs.Append("<td>" + cls.Id.ToString() + "</td>");
                sbTrs.Append("<td>" + cls.Name + "</td>");
                sbTrs.Append("<td>" + cls.Teacher + "</td>");
                sbTrs.Append("<td>" + cls.Remark + "</td>");
                sbTrs.Append("<td><a href='StudentList.aspx?clsId=" + cls.Id.ToString() + "' style='text-decoration:none;'>查看学生</a></td>");
                sbTrs.Append("</tr>");
            }
        }

    }
}