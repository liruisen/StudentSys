<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClassList.aspx.cs" Inherits="StudentSys.aspx.ClassList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="CSS/table.css" rel="stylesheet" />
    <title>班级信息</title>
</head>
<body>
    <table>
        <caption>安阳师范学院软件学院班级信息列表</caption>
        <thead>
            <tr>
                <th>班级编号</th>
                <th>班级名称</th>
                <th>班主任</th>
                <th>班级口号</th>
                <th>操作</th>
            </tr>
        </thead>
        <tbody>
            <%=this.sbTrs.ToString()%>
        </tbody>
    </table>
    <div class="divs">
        <div class="content">
            <a href="AddClass.aspx" class="submitBtn">添加班级</a>
        </div>
    </div>
</body>
</html>
