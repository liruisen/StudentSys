using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StudentSys.BLL;

using System.Text.RegularExpressions;

namespace StudentSys.UI
{
    /// <summary>
    /// DeleteStudentHandler 的摘要说明
    /// </summary>
    public class DeleteStudentHandler : IHttpHandler
    {
        StudentInfoBLL stuBll = new StudentInfoBLL();

        public void ProcessRequest(HttpContext context)
        {

            //0.从浏览器通过Url传递过来的学生ID
            string stuId = context.Request.QueryString["stuId"];
            //1.调用逻辑层，根据学生ID，删除数据库中的那条记录

            //判断是否为空
            if (!String.IsNullOrEmpty(stuId))
            {
                //判断是否为数字
                Regex regex=new Regex("^[0-9]*$");
                if (regex.IsMatch(stuId))
                {
                    int sId = int.Parse(stuId);
                    //获取该学生所在的班级ID，为删除后返回页面准备
                    int clsId = stuBll.GetStudentById(sId).ClassId;

                    if (stuBll.Delete(sId))
                    {
                        //2.跳转到被删除学生所在班级的学生信息列表页面
                        context.Response.Redirect("StudentHandler.ashx?clsId=" + clsId);
                    }
                }
                else
                {

                    context.Response.Write("参数有问题，<a href='ClassHandler.ashx'>点击这里</a>返回班级列表");

                }
            }
            else
            {
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