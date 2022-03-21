
<%@ page import="com.example.ij_ryu_jsp.board.BoardDao" %>
<%@ page import="com.example.ij_ryu_jsp.board.BoardDto" %><%--
  Created by IntelliJ IDEA.
  User: RYU
  Date: 2022-01-05
  Time: 오후 11:14
  To change this template use File | Settings | File Templates.
--%>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<%
    int idx = Integer.parseInt(request.getParameter("idx"));
    BoardDao dao= new BoardDao();
    BoardDto dto = dao.selectrow(idx);


%>
<html>
<head>
    <title>Title</title>
    <jsp:include page="../head.jsp"></jsp:include>

</head>
<script>
    let check =function (){


    }

</script>
<body>
<jsp:include page="../navi.jsp"></jsp:include>
<div class="container">
    <div class="jumbotron">
        <h1>게시물 정보 수정 페이지</h1>
        <p>변경후 확인 버튼으로 수정!</p>
        <p>지우고 싶으면 삭제버튼!</p>
    </div>

</div>
<div class="container">
    <form action="board_update_proc.jsp" method="post">
        <%--        --%>
        <input type="hidden" name="idx" value="<%=dto.getIdx()%>">
        <div class="form-group">
            <label>카테고리 수정</label>
            <select id="cate" name="cate">

                <option value="<%=dto.getCate()%>" selected="selected"><%=dto.getCate()%></option>
                <option value="Java">Java</option>
                <option value="HTML">HTML</option>
                <option value="Python">Python</option>
                <option value="Visual_C">Visual_C</option>
                <option value="ETC">ETC</option>
            </select>
            <br>
            <label for="pwd" style="margin: 5px">비밀번호 수정</label>
            <input type="password" class="form-control" id="pwd" name="pwd" style="width: 25%;" value="<%=dto.getPwd()%>">
            <br>

            <label for="title" style="margin: 5px">제목 수정</label>
            <input type="text" class="form-control" id="title" name="title" style="width: 25%;" value="<%=dto.getTitle()%>">
            <br>


            <label for="content" style="margin: 5px">본문 수정</label><br>
            <textarea rows="20" cols="80" style="background-color: lightgoldenrodyellow" class="from-conrtol" id="content" name="content"><%=dto.getContent()%></textarea>
<br>

        </div>
           <div class="col-sm-3">
            <button type="submit" class="btn btn-primary btn-block" style="margin: 10px">수정</button>
           </div>
    </form>

    <div class="col-sm-3">
    <form action="board_del.jsp" method="post" name="remove">
        <button type="submit" id="delidx" name="delidx" class="btn btn-danger btn-block" style="margin: 10px" value="<%=dto.getIdx()%>"
                onclick="if(!confirm('정말 삭제 하시겠습니까?')){return false;}">삭제</button>
    </form>
    </div>



</div>
<hr>
<footer>
    <jsp:include page="../foot.jsp"></jsp:include>

</footer>
</body>
</html>
