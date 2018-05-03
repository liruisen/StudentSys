using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StudentSys.Common;
using StudentSys.Model;
using StudentSys.BLL;
using System.Text;

namespace StudentSys.aspx
{
    public partial class StudentList : System.Web.UI.Page
    {
        ClassInfoBLL clsBll = new ClassInfoBLL();
        protected string clsName;
        protected StringBuilder sbTrs;
        protected int clsId;
        protected void Page_Load(object sender, EventArgs e)
        {
            clsId = Convert.ToInt32(Request.QueryString["clsId"]);
            clsName = clsBll.GetClassNameById(Convert.ToInt32(clsId));
            if (!String.IsNullOrEmpty(clsId.ToString()))
            {
                StudentInfoBLL stuBll = new StudentInfoBLL();
                List<StudentInfo> stuList = stuBll.GetStudentByClsId(clsId);
                sbTrs = new StringBuilder();
                foreach (StudentInfo stu in stuList)
                {
                    sbTrs.Append("<tr>");
                    sbTrs.Append("<td>" + stu.Id.ToString() + "</td>");
                    sbTrs.Append("<td>" + stu.StuNo + "</td>");
                    sbTrs.Append("<td>" + stu.Name + "</td>");
                    sbTrs.Append("<td>" + stu.Gender + "</td>");
                    sbTrs.Append("<td>" + stu.Address + "</td>");
                    sbTrs.Append("<td>" + stu.Phone + "</td>");
                    sbTrs.Append("<td><a href='UpdateStudent.aspx?stuId=" + stu.Id + "'>修改</a><a href='javascript:void(0)' onclick='doDelete(" + stu.Id + ")'>删除</a></td>");
                    sbTrs.Append("</tr>");
                }
            }

        }
    }
}