<%@ page import="com.example.ij_ryu_jsp.member.MemberDao" %><%--
  Created by IntelliJ IDEA.
  User: KB
  Date: 2022-01-06
  Time: 오후 4:07
  To change this template use File | Settings | File Templates.
--%>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<html>
<head>
    <title>Title</title>
</head>
<body>
<%
    session.removeAttribute("email");
    response.sendRedirect("/RYU_JSP_war_exploded/index.jsp");
%>
</body>
</html>
