<%@ page import="com.example.ij_ryu_jsp.board.BoardDao" %>
<%@ page import="com.example.ij_ryu_jsp.board.BoardDto" %>
<%@ page import="java.util.List" %>


<%@ page contentType="text/html; charset=UTF-8" pageEncoding="UTF-8"%>


<%

    String cate = request.getParameter("cate");
    int pagenum = 1;
    Object pageNumber = request.getParameter("pageNumber");
    if(pageNumber != null){
        pagenum = Integer.parseInt((String)pageNumber);

    }


        BoardDao bd1 = new BoardDao();
        List<BoardDto> list1 = bd1.selectlist_cate(cate,pagenum);

        int pagecnt = bd1.page_cnt();

%>

<!DOCTYPE html>

<html>

<head>


    <style>
        *{
            margin: 0;
        padding: 0;}



    </style>

    <title>JSP - Hello World</title>
    <meta name ="google-signin-client_id" content="989151602175-ki81hag61nvfngoad9n53tm8bq4665o4.apps.googleusercontent.com">
    <%@ include file="head.jsp"%>
    <script>
        $('document').ready(function (){
            $('#log_out').on('click',function (){
                // window.location='login_out/log_out.jsp';
                window.location='log_out.jsp';
            });
        });
    </script>
    <script>

        let chk_login= function (){
            let id_chk = document.getElementById('email').value;
            let pwd_chk = document.getElementById('pwd').value;
            if(id_chk == ""){

                alert("아이디를 입력하세요!",id_chk)
                return false;
            }
            if(pwd_chk == ""){
                alert("비밀번호를 입력하세요!")
                return false;
            }

        }

    </script>
</head>
<body>

<%@ include file="navi.jsp"%>

<%--회전+로그인--%>
<div class="container">

    <div class="col-sm-3 col-md-10">

        <div id="myCarousel" class="carousel slide" data-ride="carousel" >
            <!-- Indicators -->
            <ol class="carousel-indicators">
                <li data-target="#myCarousel" data-slide-to="0" class="active" style="border: solid 1px darkred;"></li>
                <li data-target="#myCarousel" data-slide-to="1" style="border: solid 1px darkred"></li>
                <li data-target="#myCarousel" data-slide-to="2" style="border: solid 1px darkred"></li>
            </ol>

            <!-- Wrapper for slides -->
            <div class="carousel-inner">
                <div class="item active">
                    <img src="img/java2.png" alt="Java Project" style="height: 200px; width: 1450px;">
                </div>

                <div class="item">
                    <img src="img/py2.png" alt="Python Project"  style="height: 200px; width: 1450px;">
                </div>

                <div class="item">
                    <img src="img/visual4.png" alt="C Project" style="height: 200px; width: 1450px;">
                </div>
            </div>

            <!-- Left and right controls -->
            <a class="left carousel-control" href="#myCarousel" data-slide="prev">
                <span class="glyphicon glyphicon-chevron-left" style="color: darkred;"></span>
                <span class="sr-only" >Previous</span>
            </a>
            <a class="right carousel-control" href="#myCarousel" data-slide="next">
                <span class="glyphicon glyphicon-chevron-right" style="color: darkred;"></span>
                <span class="sr-only">Next</span>
            </a>
        </div></div>


    <div class="col-sm-3 col-md-2">
        <%
            String email= "";



            Cookie cos[] = request.getCookies();

            if(cos != null){

                for(Cookie co: cos) {

                    if (co.getName().equals("email"))
                        email = co.getValue();

                }
            }else
                System.out.println("쿠키없음");


            Object email_obj = session.getAttribute("email");
            if(email_obj == null){


        %>
<%--    <form action="login_out/log_in.jsp" method="get">--%>
        <form action="log_in.jsp" method="post" onsubmit="return chk_login()">
    <div class="form-group">
        <label for="email">Email address:</label>

        <input type="email" class="form-control" id="email" name="email" value="<%=email%>" style="width: 120%">
    </div>

    <div class="form-group">
        <label for="pwd">Password:</label>

        <input type="password" class="form-control" id="pwd" name="pwd" style="width: 120%">
    </div>
    <div class="checkbox">
        <label><input type="checkbox" value="true" name="login_save" id="login_save">ID 기억하기</label>
    </div>



    <button type="submit" class="btn btn-primary btn-block">로그인</button>

                  <button type="button" class="btn btn-primary btn-block" onclick="location='member/member_form.jsp'">가입</button>





    </form>
       <div style="margin: 6px"></div>
        <form action="log_in.jsp" method="post"></form>
        <li id="GgCustomLogin" style="list-style: none;" >

            <a href="javascript:void(0)">
                <button class="btn  btn-success btn-block btn-md" type="submit" id="login_save1" name="login_save1"><span >GooGle Login</span></button>
            </a>
        </li>

</div>
    <%
        }else{
    %>
<%--    <div class="col-lg-5"></div>--%>
    <div class="col-sm-2 pt5">

        <div class="col-sm-5">
        <img src="image/login.png" width="95" height="90"><hr>
        </div>
        <div class="col-sm-5">
            <p>Welcome!</p>
        <%=email_obj%>
       <br>

        </div>
        <div class="col-sm-5">
        <button class="btn btn-primary " id="log_out" style="margin: 10px">로그 아웃</button>
        </div>

    </div>
    <%
        }
    %>
</div>

<%--회전+로그인--%>
<a style="margin: 5px"></a>

<%--<div class="container">--%>
<%--    <iframe width="812" height="457" src="https://www.youtube.com/embed/UtFp8NVIZ1Y?list=PL-fIO_nINnoBW3lyYTo-CVgVVaj6P0WIp" title="YouTube video player" frameborder="0" allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture" allowfullscreen></iframe>--%>
<%--</div>--%>

<%--게시판,이미지,본문--%>
<div class="container">
<%--    <div class="col-sm-3 col-md-2">--%>

<%--        <img style="cursor: pointer" src="http://www.kb.or.kr/data/banner/iL23rzMrjYwU9vd9jqcd_1625803324.gif" class="img-thumbnail" alt="Cinque Terre" onclick="location='https://kb.step.or.kr/main.do'">--%>
<%--    </div>--%>


    <div class="col-sm-3 col-md-10">
    <h2>게시판</h2>


<form action="" method="post">
        <label>카테고리 선택</label>
        <select id="cate" name="cate">
<%--            <option onclick="all_cate();">전부</option>--%>
            <option value="%%" selected="selected">전체</option>
            <option value="%Java%">Java</option>
            <option value="%HTML%">HTML</option>
            <option value="%Python%">Python</option>
            <option value="%Visual_C%">Visual_C</option>
            <option value="%ETC%">ETC</option>

        </select>
    <button type="submit" class="btn btn-primary">보기</button>
</form>


        <table class="table">
            <thead>
            <tr  class="info">
                <th>번호</th>
                <th>카테고리</th>

                <th>작성자</th>
                <th>제목</th>
                <th>작성일</th>



            </tr></thead>
            <tbody>
            <%
                for (BoardDto dto : list1){
            %>
            <tr class="success">
                <th><%=dto.getIdx()%></th>
                <th><%=dto.getCate()%></th>

                <th><%=dto.getName()%></th>
                <th><a href="board/board_view.jsp?idx=<%=dto.getIdx()%>"><%=dto.getTitle()%></a></th>

                <th><%=dto.getWdate()%></th>
            </tr>
            <%
                }
            %>
            </tbody>


<%--            <tbody>--%>
<%--            <%--%>
<%--                for (BoardDto dto : list){--%>
<%--            %>--%>
<%--            <tr>--%>
<%--                <th><%=dto.getIdx()%></th>--%>
<%--                <th><%=dto.getCate()%></th>--%>

<%--                <th><%=dto.getName()%></th>--%>
<%--                <th><a href="board/board_view.jsp?idx=<%=dto.getIdx()%>"><%=dto.getTitle()%></a></th>--%>

<%--                <th><%=dto.getWdate()%></th>--%>
<%--            </tr>--%>
<%--            <%--%>
<%--                }--%>
<%--            %>--%>
<%--            </tbody>--%>

        </table>
        <div class="container">
            <div class="col-sm-4"></div>
      <div class="col-sm-4">
        <ul class="pagination">
<%--            <li class="page-item <%=pagenum == 1 ? "disabled":""%>">--%>
<%--                <a class="page-link" href="index.jsp?pageNumber=<%=(pagenum-1)%>">이전 페이지</a></li>--%>
            <%
                for (int i = 1; i <= pagecnt; i++){
                    %>
            <li class="page-item <%=pagenum == i ? "active":""%>">
                <a class="page-link" href="index.jsp?pageNumber=<%=i%>"><%=i%></a></li>
                    <%
                }
            %>


<%--            <li class="page-item <%=pagenum == pagecnt ? "disabled":""%>">--%>
<%--                <a class="page-link" href="index.jsp?pageNumber=<%=(pagenum+1)%>">다음 페이지</a></li>--%>
        </ul>
      </div>
                <div class="col-sm-3" style="margin: 20px">
                    <button type="button" class="btn btn-primary "><a style="color: white" href="/RYU_JSP_war_exploded/board/board_insert_form.jsp">글쓰기</a></button>
                </div>
            </div>


    </div>
    <div class="col-sm-3 col-md-2">


        <img style="cursor: pointer; margin: 10px" src="http://www.kb.or.kr/data/banner/iL23rzMrjYwU9vd9jqcd_1625803324.gif" class="img-thumbnail" alt="Cinque Terre" onclick="location='http://www.kb.or.kr/'">
    </div>


</div>
</br>

<hr>
<script>

    //처음 실행하는 함수
    function init() {
        gapi.load('auth2', function() {
            gapi.auth2.init();
            options = new gapi.auth2.SigninOptionsBuilder();
            options.setPrompt('select_account');
            // 추가는 Oauth 승인 권한 추가 후 띄어쓰기 기준으로 추가
            options.setScope('email profile openid https://www.googleapis.com/auth/user.birthday.read');
            // 인스턴스의 함수 호출 - element에 로그인 기능 추가
            // GgCustomLogin은 li태그안에 있는 ID, 위에 설정한 options와 아래 성공,실패시 실행하는 함수들
            gapi.auth2.getAuthInstance().attachClickHandler('GgCustomLogin', options, onSignIn, onSignInFailure);
        })
    }

    function onSignIn(googleUser) {
        var access_token = googleUser.getAuthResponse().access_token
        $.ajax({
            // people api를 이용하여 프로필 및 생년월일에 대한 선택동의후 가져온다.
            url: 'https://people.googleapis.com/v1/people/me'
            // key에 자신의 API 키를 넣습니다.
            , data: {personFields:'birthdays', key:'AIzaSyATbiz96y3QuoZHesMNqy7SWz5hCTy_ouk', 'access_token': access_token}
            , method:'GET'
        })
            .done(function(e){
                //프로필을 가져온다.
                var profile = googleUser.getBasicProfile();


                alert("구글 로그인 "+profile.getEmail()+" 님 환영합니다!");

                return profile.getEmail();

            })



            .fail(function(e){
                console.log(e);
            })
    }
    function onSignInFailure(t){
        console.log(t);
    }
</script>




<footer>

    <%@include file="foot.jsp"%>
</footer>

</body>
</html>

