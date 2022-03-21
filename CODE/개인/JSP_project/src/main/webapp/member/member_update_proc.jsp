
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<%@page import="com.example.ij_ryu_jsp.member.MemberDao" %>
<jsp:useBean id="dto" class="com.example.ij_ryu_jsp.member.MemberDto"></jsp:useBean>
<jsp:setProperty name="dto" property="*"></jsp:setProperty>
<%=dto%>

<%
    MemberDao dao = new MemberDao();
    dao.memberset(dto,true);
    response.sendRedirect("/RYU_JSP_war_exploded/member/member_list.jsp");
%>