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
    public partial class AddClass : System.Web.UI.Page
    {

        protected ClassInfo cls;

        ClassInfoBLL clsBll = new ClassInfoBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Request.HttpMethod.ToUpper() == "POST")
            {
                this.DoPost();

            }
            else
            {

            }
        }


        private void DoPost()
        {
            //0.获取表单元素
            //
            string clsName = Request.Form["clsName"];

            string clsTeacher = Request.Form["clsTeacher"];
            string clsRemark = Request.Form["clsRemark"];
            ClassInfo classInfo = new ClassInfo();

            classInfo.Name = clsName;
            classInfo.Teacher = clsTeacher;
            classInfo.Remark = clsRemark;

            if (clsBll.Add(classInfo))
            {
                Response.Redirect("ClassList.aspx");
            }
            else
            {
                Response.Redirect("ClassList.aspx");
            }

            
        }
    }
}