<%--
  Created by IntelliJ IDEA.
  User: KB
  Date: 2022-01-07
  Time: 오전 10:42
  To change this template use File | Settings | File Templates.
--%>

<%@ page contentType="text/html; charset=UTF-8" pageEncoding="UTF-8"%>
<%
    Cookie coo1 = new Cookie("myname","javaking");
    Cookie coo2=new Cookie("age","22");

    coo1.setMaxAge(60*1);
    coo2.setMaxAge(60*1);

    response.addCookie(coo1);
    response.addCookie(coo2);
%>