<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateStudent.aspx.cs" Inherits="StudentSys.aspx.UpdateStudent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="CSS/table.css" rel="stylesheet" />
    <title>修改学生信息</title>
</head>
<body>
    <form method="post" action="UpdateStudent.aspx" >
        <table>
            <caption>修改学生信息</caption>
            <tr>
                <td>编号</td>
                <input type="hidden" name="stuId" value="<%=stu.Id %>" />
                <td><%=stu.Id %></td>
            </tr>
            <tr>
                <td>学号</td>
                <td><input type="text" name="stuNo" value="<%=stu.StuNo %>" /></td>
            </tr>
            <tr>
                <td>姓名</td>
                <td><input type="text" name="stuName" value="<%=stu.Name %>" /></td>
            </tr>
            <tr>
                <td>性别</td>
                <td><input type="radio" name="stuGender" value="男"  <%=stu.Gender=="男"?"checked":"" %>/>男<input type="radio" name="stuGender" value="女" <%=stu.Gender=="女"?"checked":"" %> />女</td>
            </tr>
            <tr>
                <td>联系方式 </td>
                <td><input type="text" name="stuPhone" value="<%=stu.Phone %>" /></td>
            </tr>
            <tr>
                <td>家庭住址</td>
                <td><input type="text" name="stuAddress" value="<%=stu.Address %>" /></td>
            </tr>
            <tr>
                <td>所在班级</td>
                <td>
                    <select name="stuClass">
                        <%=sbOpts.ToString() %>
                    </select>
                </td>
            </tr>
            <tr>
                <td colspan="2"><input type="submit" class="submitBtn" value="提交" /></td>
            </tr>
        </table>
    </form>
</body>
</html>
