<%@ page import="com.example.ij_ryu_jsp.member.MemberDao" %>
<%@ page import="com.example.ij_ryu_jsp.member.MemberDto" %>
<%@ page import="java.util.List" %><%--
  Created by IntelliJ IDEA.
  User: RYU
  Date: 2022-01-02
  Time: 오후 9:51
  To change this template use File | Settings | File Templates.
--%>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<%
    int idx = Integer.parseInt(request.getParameter("idx"));

    MemberDao dao=new MemberDao();
    MemberDto dto = dao.memberget(idx);
%>
<html>
<head>
    <title>Title</title>
    <%@include file="../head.jsp"%>
</head>
<body>
<%@include file="../navi.jsp"%>
<div class="container">
    <div class="jumbotron">
        <h1>회원 정보 수정 페이지</h1>
        <p>변경후 확인 버튼으로 수정!</p>
    </div>

</div>
<div class="container">
    <form action="member_update_proc.jsp">
        <%--        --%>
        <input type="hidden" name="idx" value="<%=dto.getIdx()%>">
        <div class="form-group">
            <label for="email">Email</label>
            <input type="email" class="form-control" placeholder="Enter email" id="email" name="email" value="<%=dto.getEmail()%>">
        </div>
        <div class="form-group">
            <label for="pwd">Pwd</label>
            <input type="password" class="form-control" placeholder="Enter password" id="pwd" name="pwd" value="<%=dto.getPwd()%>">
        </div>

        <button type="submit" class="btn btn-primary">확인</button>
    </form>
</div>

<footer>

    <%@include file="../foot.jsp"%>
</footer>
</body>
</html>
