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
    public partial class AddStudent : System.Web.UI.Page
    {
        protected StringBuilder sbOpts;
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
            sbOpts = new StringBuilder();
            string clsId = Request.QueryString["clsId"];
            List<ClassInfo> clsList = clsBll.GetClassList();
            foreach (ClassInfo cls in clsList)
            {
                if (int.Parse(clsId) == cls.Id)//这个班级应该作为默认选项
                {
                    sbOpts.Append("<option value='" + cls.Id + "' selected='selectes'>" + cls.Name + "</option>");
                }
                else
                {
                    sbOpts.Append("<option value='" + cls.Id + "'>" + cls.Name + "</option>");
                }
            }
        }
        private void DoPost()
        {
            //0.获取表单元素
            //

            string stuName = Request.Form["stuName"];
            string stuNo = Request.Form["stuNo"];
            string stuGender = Request.Form["stuGender"];
            string stuPhone = Request.Form["stuPhone"];
            string stuAddress = Request.Form["stuAddress"];
            string stuClsId = Request.Form["stuClass"];

            StudentInfo student = new StudentInfo();

            student.Name = stuName;
            student.Phone = stuPhone;
            student.Address = stuAddress;
            student.ClassId = int.Parse(stuClsId);
            student.Gender = stuGender;
            student.StuNo = stuNo;

            if (stuBll.Add(student))
            {
                Response.Redirect("StudentList.aspx?clsId=" + stuClsId);                
            }
        }
       
    }

}