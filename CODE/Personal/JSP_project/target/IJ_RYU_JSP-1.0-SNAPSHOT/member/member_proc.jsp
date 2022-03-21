<%@ page import="com.example.ij_ryu_jsp.member.MemberDao" %>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<jsp:useBean id="dto" class="com.example.ij_ryu_jsp.member.MemberDto"></jsp:useBean>
<jsp:setProperty name="dto" property="*"></jsp:setProperty>
<%=dto%>

<%
    MemberDao dao = new MemberDao();
    dao.memberset(dto);
    response.sendRedirect("/RYU_JSP_war_exploded/index.jsp");
%>

