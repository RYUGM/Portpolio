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
    BoardDao bd1 = new BoardDao();
    List<BoardDto> list = bd1.selectlist();
    System.out.println(list);
%>

<%
    int idx=Integer.parseInt(request.getParameter("idx"));
    BoardDao bd = new BoardDao();
    BoardDto row = bd.selectrow(idx);
%>
<html>
<head>
    <title>Title</title>
    <jsp:include page="../head.jsp"></jsp:include>

    <script>

        function board_update(idx){
            let pwd = $('#pwd').val()

            let mypwd =<%=row.getPwd()%>
          if(mypwd == pwd){
              location.href="board_update.jsp?idx="+idx;
            }
          else if(pwd == "")
          {  alert("비밀번호를 입력하세요!")}
          else
              alert("틀린 비밀번호!!")

        }
    </script>
</head>
<body>
<jsp:include page="../navi.jsp"></jsp:include>
<script>

    window.onload=function (){
        let cate1 = document.getElementById("cate_v").value

        let img_tag = document.createElement('img');

        if(cate1 == "Visual_C") {
              img_tag.src = "https://ryugm.github.io/RYU/visual4.png"

          }
        else if(cate1 == "Java") {
            img_tag.src = "https://ryugm.github.io/RYU/ij_eclipse.png"

        }
        else if(cate1 == "Python") {
            img_tag.src = "https://ryugm.github.io/RYU/pycharm.jpg"

        }
        else if(cate1 == "HTML") {
            img_tag.src = "https://ryugm.github.io/RYU/V_code.png"

        }
        else{
            img_tag.src = "https://ryugm.github.io/RYU/my_skill.png"
          }
        document.getElementById("src").appendChild(img_tag)

    }

</script>
<div class="container" style="width: 1250px; height: 250px;">
    <a id="src" ></a>


</div>

<div class="container">
<input type="hidden" id="cate_v" name="cate_v" value="<%=row.getCate()%>">
    <div class="form-group" style="border: 1px solid #ccc; padding: 0.5rem; background-color: lightskyblue">
        <table class="table table-bordered">
        <tr class="warning">
            <th>카테고리:<%=row.getCate()%></th>
            <th>글쓴이:<%=row.getName()%></th>
            <th>제목:<%=row.getTitle()%></th>
            <th>작성일: <%=row.getWdate()%></th>

        </tr>

        </table>

        <hr>
        <label style="display: block;">본문:<br><br><pre><%=row.getContent()%></pre></label>

        <hr>



    </div>
    <div class="container"></div>
    <div class="col-sm-3"></div>
    <div class="col-sm-8">
    <form action="board_update.jsp" method="post">

       <label>게시물 수정을 원하시면 비밀번호 입력(네 자리):</label> <input type="password" id="pwd" name="pwd" maxlength="4" minlength="4">

    <button type="button" class="btn btn-primary"  onclick="board_update(<%=row.getIdx()%>);">수정</button>
    </form>
    </div>

<div style="height: 100px;"></div>
<div>
    <table class="table">
        <thead>
        <tr class="info">
            <th>번호</th>
            <th>카테고리</th>

            <th>작성자</th>
            <th>제목</th>
            <th>작성일</th>


        </tr></thead>
        <tbody>
        <%
            for (BoardDto dto : list){
        %>
        <tr class="success">
            <th><%=dto.getIdx()%></th>
            <th><%=dto.getCate()%></th>
            <th><%=dto.getName()%></th>
            <th><a href="board_view.jsp?idx=<%=dto.getIdx()%>"><%=dto.getTitle()%></a></th>

            <th><%=dto.getWdate()%></th>


        </tr>
        <%
            }
        %>
        </tbody>

    </table>
    <div class="col-sm-11"></div>
    <div class="col-sm-1">
    <button type="button" class="btn btn-primary"><a style="color: white" href="/RYU_JSP_war_exploded/board/board_insert_form.jsp">글쓰기</a></button>
    </div>
    </div>

</div>
<hr>
<footer>
    <jsp:include page="../foot.jsp"></jsp:include>
</footer>
</body>
</html>
