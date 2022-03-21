<%@ page import="com.example.ij_ryu_jsp.board.BoardDto" %>
<%@ page import="com.example.ij_ryu_jsp.board.BoardDao" %><%--
  Created by IntelliJ IDEA.
  User: RYU
  Date: 2022-01-03
  Time: 오후 9:33
  To change this template use File | Settings | File Templates.
--%>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<jsp:useBean id="dto" class="com.example.ij_ryu_jsp.board.BoardDto"></jsp:useBean>
<jsp:setProperty name="dto" property="*"></jsp:setProperty>
<%
    BoardDao bd = new BoardDao();
    String retu = bd.insert(dto);
    if(retu.equals("true"))
        response.sendRedirect("/RYU_JSP_war_exploded/index.jsp");
    else {
        %>
      <%=retu%>가 나와서 insert 실패
<%

    }

%>
