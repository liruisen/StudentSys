<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddStudent.aspx.cs" Inherits="StudentSys.aspx.AddStudent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="CSS/table.css" rel="stylesheet" />
    <title>添加学生</title>
</head>
<body>
    <form method="post" action="AddStudent.aspx" >
        <table>
            <caption>学生信息</caption>
            
            <tr>
                <td>学号</td>
                <td><input type="text" name="stuNo" value="" /></td>
            </tr>
            <tr>
                <td>姓名</td>
                <td><input type="text" name="stuName" value="" /></td>
            </tr>
            <tr>
                <td>性别</td>
                <td><input type="radio" name="stuGender" value="男"checked="checked" />男<input type="radio" name="stuGender" value="女" />女</td>
            </tr>
            <tr>
                <td>联系方式 </td>
                <td><input type="text" name="stuPhone" value="" /></td>
            </tr>
            <tr>
                <td>家庭住址</td>
                <td><input type="text" name="stuAddress" value="" /></td>
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
                <td colspan="2"><input type="submit" class="submitBtn" value=" 提交信息" /></td>
            </tr>
        </table>
    </form>
</body>
</html>
