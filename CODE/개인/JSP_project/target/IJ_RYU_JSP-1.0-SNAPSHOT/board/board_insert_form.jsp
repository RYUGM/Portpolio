
<%@ page contentType="text/html;charset=UTF-8" language="java" %>

<%

%>
<html>
<head>

    <title>board_write</title>
    <jsp:include page="../head.jsp"></jsp:include>
    <%--    게시판--%>
    <script>
        function chk() {
            let title = $('#title').val();

            let content = $('#content').val();
            let pwd = $('#pwd').val();
            if (!title) {
                alert("제목을 입력하세요!");

            }
             else if (!content) {
                alert("내용을 입력하세요!");
            } else if(!pwd){
                alert("비밀번호를 입력하세요!")
            }
            else
                return true;

            return false;
        }

    </script>
    <script>
        window.onload=function (){
            let email_id=<%=session.getAttribute("email")%>
            if(email_id == null){
                $('#name').val("익명");
            }
        }

    </script>
    <%--    게시판--%>
</head>
<body>
<jsp:include page="../navi.jsp"></jsp:include>
<div class="container">
    <div class="jumbotron">
        <h1>게시글 작성</h1>
        <p>제목,이름,내용을 입력!</p>
    </div>

    <form action="board_insert_proc.jsp" onsubmit="return chk()">
        <div class="form-group">
            <label>Category</label>

            <select id="cate" name="cate">

                <option value="Java">Java</option>
                <option value="HTML">HTML</option>
                <option value="Python">Python</option>
                <option value="Visual_C">Visual_C</option>
                <option value="ETC" selected="selected">ETC</option>
            </select>
            <br>
            <label for="title" style="margin: 3px">제목</label>
            <input type="text" class="form-control" id="title" name="title" style="width: 25%;">
            <label for="name" style="margin: 3px">이름</label>
            <input type="text" class="form-control" id="name" name="name" style="width: 25%;"
                   value="<%=session.getAttribute("email")%>">
            <label for="pwd" style="margin: 3px" >패스워드(네 자리)</label>
            <input type="password" class="form-control" id="pwd" name="pwd" style="width: 25%" minlength="4" maxlength="4">
        </div>
        <%--        <div class="form-group">--%>
        <%--           --%>
        <%--        </div>--%>
        <label for="content">content</label>
        <div class="form-group">

            <textarea rows="7" cols="50" class="from-conrtol" id="content" name="content" ></textarea>
        </div>
        <button type="submit" class="btn btn-primary">글쓰기</button>

    </form>

<hr>
<footer>
    <jsp:include page="../foot.jsp"></jsp:include>
</footer>
</body>
</html>
