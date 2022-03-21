
<%@ page import="com.example.ij_ryu_jsp.member.MemberDao" %>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>

<%
    String id = request.getParameter("id");
    System.out.println("id=??"+id);
    MemberDao md = new MemberDao();
if(id != ""){
    String ret = md.memberchk(id);

//    out.println(id);
    if(ret.equals("true")) {
        out.println("가입가능");
    }
    else
        out.println("중복 계정");
}else
    out.println("아이디를 입력하세요!");
%>