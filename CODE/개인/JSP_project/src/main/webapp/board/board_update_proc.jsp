
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<%@page import="com.example.ij_ryu_jsp.member.MemberDao" %>
<%@ page import="com.example.ij_ryu_jsp.board.BoardDao" %>
<jsp:useBean id="dto" class="com.example.ij_ryu_jsp.board.BoardDto"></jsp:useBean>
<jsp:setProperty name="dto" property="*"></jsp:setProperty>
<%=dto%>

<%
    BoardDao dao = new BoardDao();
    dao.board_update(dto,true);
    response.sendRedirect("/RYU_JSP_war_exploded/index.jsp");
%>