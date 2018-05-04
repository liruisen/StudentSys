<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentList.aspx.cs" Inherits="StudentSys.aspx.StudentList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="CSS/table.css" rel="stylesheet" />
    <title><%=this.clsName %></title>
    <script>
        function doDelete(id) {
            if (confirm("您真的要删除id为：" + id + "的学生吗？"))
                window.location = "DeleteStudentHandler.ashx?stuId=" + id;
        }

    </script>
</head>
<body>
    <div class="divs">
        <table>
            <caption><%=this.clsName %>学生信息列表</caption>
            <thead>
                <tr>
                    <th>编号</th>
                    <th>学号</th>
                    <th>姓名</th>
                    <th>性别</th>
                    <th>家庭住址</th>
                    <th>联系电话</th>
                    <th>操作</th>
                </tr>
            </thead>
            <tbody>
                <%=this.sbTrs.ToString() %>
            </tbody>
        </table>
    </div>

    <div class="divs">
        <div class="content">
            <a href="AddStudent.aspx?clsId=<%=this.clsId.ToString() %>" class="submitBtn">添加学生</a>
            <a href="ClassList.aspx " class="submitBtn">返回班级</a>
        </div>
    </div>

</body>
</html>
