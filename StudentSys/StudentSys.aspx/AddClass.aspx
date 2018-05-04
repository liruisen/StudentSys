<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddClass.aspx.cs" Inherits="StudentSys.aspx.AddClass" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="CSS/table.css" rel="stylesheet" />
    <title>添加班级</title>
</head>
<body>
    <form method="post" action="AddClass.aspx" >
        <table>
            <caption>添加班级</caption>
           
            <tr>
                <td>班级名称</td>
                <td><input type="text" name="clsName" value="" /></td>
            </tr>
            <tr>
                <td>班主任</td>
                <td><input type="text" name="clsTeacher" value="" /></td>
            </tr>
           
            <tr>
                <td>班级口号 </td>
                <td><input type="text" name="clsRemark" value="" /></td>
            </tr>
           
            <tr>
                <td colspan="2"><input type="submit" class="submitBtn" value="提交" /></td>
            </tr>
        </table>
    </form>
</body>
</html>
