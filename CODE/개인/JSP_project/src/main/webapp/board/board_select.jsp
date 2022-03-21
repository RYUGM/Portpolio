<%@ page import="com.example.ij_ryu_jsp.board.BoardDao" %>
<%@ page import="com.example.ij_ryu_jsp.board.BoardDto" %>
<%@ page import="java.util.List" %><%--
  Created by IntelliJ IDEA.
  User: RYU
  Date: 2022-01-03
  Time: 오후 9:32
  To change this template use File | Settings | File Templates.
--%>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<%
    BoardDao bd = new BoardDao();
    List<BoardDto> list = bd.selectlist();
    System.out.println(list);
%>
<html>
<head>
    <title>Title</title>
    <jsp:include page="../head.jsp"></jsp:include>
</head>
<body>
<jsp:include page="../navi.jsp"></jsp:include>


<hr>
<footer>
    <jsp:include page="../foot.jsp"></jsp:include>
</footer>
</body>
</html>
