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
    String email = request.getParameter("email");
    String pwd = request.getParameter("pwd");
    Object login_save = request.getParameter("login_save");
%>
<%=email%>
<%=pwd%>
<%=login_save%>
<%
    MemberDao dao = new MemberDao();
    boolean ret = dao.member_login(email,pwd);

    if(ret){

        session.setAttribute("email",email);
        session.setAttribute("pwd",pwd);

        if(login_save != null)
        {

            Cookie co1 = new Cookie("email",email);
            Cookie co2 = new Cookie("pwd",pwd);
            co1.setMaxAge(60*1);
            co2.setMaxAge(60*1);

            response.addCookie(co1);
            response.addCookie(co2);
            System.out.println("co1,2"+co1.getName()+co1.getValue()+co2.getName()+co2.getValue());
        };
        response.sendRedirect("/RYU_JSP_war_exploded/index.jsp");


    } else  {


        response.sendRedirect("/RYU_JSP_war_exploded/member/member_form.jsp");

    }

%>


</body>
</html>
