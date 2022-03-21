<%@page import="com.example.ij_ryu_jsp.member.MemberDao" %>
<%@page import="com.example.ij_ryu_jsp.member.MemberDto" %>
<%@ page import="java.util.List" %>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<%
  String email=  request.getParameter("email");

   String pwd= request.getParameter("pwd");
    MemberDao dao = new MemberDao();
    List<MemberDto> list = dao.memberlist_personal(email,pwd);
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
        <h1>회원 정보 관리 페이지</h1>
        <p>1.이메일,비밀번호를 입력해서 조회</p>
        <p>2.회원정보 변경은 이메일을 클릭!</p>
        <p>3.회원 탈퇴는 이메일 체크 선택후 삭제버튼 클릭!</p>
    </div>

</div>
<div class="container">
<form action="member_list_each.jsp">
    <div class="col-sm-4">
        <label for="email">이메일 </label>
        <input type="email" class="form-control" id="email" name="email">
    </div>
    <div class="col-sm-4">
        <label>비밀번호</label>
        <input type="password" class="form-control" id="pwd" name="pwd">
    </div>

    <div class="col-sm-4">
        <div style="margin: 24px"></div>
        <button type="submit" class="btn btn-primary">조회</button>
    </div>
</form>
</div>



<div style="margin: 30px"></div>
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


        <div >
        <button class="btn btn-danger btn-block" type="submit" value="삭제" style="margin: 0 20px; width: 20%"
               onclick="if(!confirm('탈퇴 하시겠습니까?')){return false;}">삭제</button>
        </div>

    </form>

</div>



<footer>
    <%@include file="../foot.jsp"%>

</footer>
</body>
</html>
