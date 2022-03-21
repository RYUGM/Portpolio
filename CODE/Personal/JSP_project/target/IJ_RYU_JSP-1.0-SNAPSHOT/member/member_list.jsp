<%@page import="com.example.ij_ryu_jsp.member.MemberDao" %>
<%@page import="com.example.ij_ryu_jsp.member.MemberDto" %>
<%@ page import="java.util.List" %>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<%
    MemberDao dao = new MemberDao();
    List<MemberDto> list = dao.memberlist();
    System.out.println("list"+list);
%>
<html>
<head>
    <style>
        .onmouse:hover{
            cursor: pointer;
            background-color: gray;
        }
    </style>
    <script>
        function memberupdate(idx){
            location.href="member_form_update.jsp?idx="+idx;
        }
    </script>
    <title>Memberlist</title>
    <%@include file="../head.jsp"%>
</head>
<body>
<%@include file="../navi.jsp"%>

<div class="container">
    <div class="jumbotron">
        <h1>회원 리스트 페이지</h1>
        <p>탈퇴 : 체크박스로 선택후 삭제버튼 <br>
        정보 변경: 변경하고싶은 이메일 클릭</p>
    </div>

</div>

<div class="container">
    <form action="member_delete.jsp">
        <table class="table">
            <thead style="background-color: silver">
            <tr>
                <th></th> <th>이메일</th><th>비밀번호</th><th></th>

            </tr>
            </thead>
            <tbody>
            <%
                for(MemberDto dto : list){
            %>
            <td><input style="position: absolute; margin-left: 1.0rem;" class="form-check-input" type="checkbox" name="delidx" value="<%=dto.getIdx()%>"></td>
            <td  onclick="memberupdate(<%=dto.getIdx()%>);" class="onmouse"><%=dto.getEmail()%></td>
            <td><%=dto.getPwd()%></td>

            </tr>

            <%
                }
            %>
            </tbody>

        </table>
        <hr>
        <input class="btn btn-primary" type="submit" value="삭제" style="margin: 0 20px; ">
    </form>

</div>



<footer>
    <%@include file="../foot.jsp"%>

</footer>
</body>
</html>
