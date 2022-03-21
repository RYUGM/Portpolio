<%@ page import="com.example.ij_ryu_jsp.member.MemberDao" %><%--
  Created by IntelliJ IDEA.
  User: RYU
  Date: 2022-01-02
  Time: 오후 9:38
  To change this template use File | Settings | File Templates.
--%>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<html>
<head>
    <title>Title</title>
</head>
<body>
<%
    String[] temp = request.getParameterValues("delidx");
    MemberDao bd= new MemberDao();
    String retu = bd.delete(temp);
    if(retu.equals("true"))
        response.sendRedirect("/RYU_JSP_war_exploded/index.jsp");
%>
</body>
</html>
