<%@ page import="com.example.ij_ryu_jsp.board.BoardDao" %><%--
  Created by IntelliJ IDEA.
  User: RYU
  Date: 2022-01-06
  Time: 오전 12:06
  To change this template use File | Settings | File Templates.
--%>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<%
    String[] temp = request.getParameterValues("delidx");
    BoardDao bd= new BoardDao();
    String retu = bd.board_del(temp);

    if(retu.equals("true"))
      response.sendRedirect("/RYU_JSP_war_exploded/index.jsp");


%>