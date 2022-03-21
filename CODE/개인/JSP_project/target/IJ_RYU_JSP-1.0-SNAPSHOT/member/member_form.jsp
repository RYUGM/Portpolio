<%@ page import="com.example.ij_ryu_jsp.board.BoardDto" %>
<%@ page import="com.example.ij_ryu_jsp.board.BoardDao" %>
<%@ page import="java.util.List" %><%--
  Created by IntelliJ IDEA.
  User: RYU
  Date: 2022-01-02
  Time: 오후 9:37
  To change this template use File | Settings | File Templates.
--%>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>

<html>
<head>
    <title>Member Form</title>
    <%@include file="../head.jsp"%>
    <script>
        let pwd_chk =function (){
            let pwd = $('#pwd').val()
            if(pwd == ""){
                alert("비밀번호를 입력하세요!")
                return false
            }


        }
    </script>
    <script>
        let result = "false";
        function doChk(){
            let aobj={
                url:"member_chk.jsp",
                type: "get",
                cache:true ,
                dataType: "text",
                data: {id:$('#email').val(),b:20},
                success: function(data,result){

                        result=data.trim();
                        $('#result').html(result);

                },
                error: function (request, status){
                    alert(status);
                }
            };
            $.ajax(aobj);
        }
        function doSubmit(){
            let pw1 = document.getElementById('pwd').value;
            let pw2 = document.getElementById('pwd1').value;



            result = $('#result').html();
            if(pw1 != pw2) {
                alert("비밀번호가 다릅니다!")
                return false
            }
            if(result == "가입가능" && pw1.length > 5) {
                alert("가입을 환영합니다!");
                return true;
            }
            if(result == "중복 계정"){
                alert("이미 가입하신 회원입니다!")
                return false;
            }
            if(result == "아이디를 입력하세요!"){
                alert("아이디를 입력하세요!")
                return false;
            }

            else{
                 alert("중복체크를 하세요!")
                return false;
            }
        }


    </script>

</head>
<body>
<%@include file="../navi.jsp"%>
<div class="container">
    <div class="jumbotron">
        <h1>회원 가입 페이지</h1>
        <p>이메일,비밀번호를 입력하고 확인을 누르면 가입 완료!</p>
    </div>

</div>
<%--멤버--%>
<div class="container">
    <form action="member_proc.jsp" onsubmit="return doSubmit()">
        <div class="container">
            <div class="col-sm-3"></div>
        <div class="form-group col-sm-5">
            <label for="email">메일주소</label>
            <input type="email" class="form-control" style="width: 50%; display: inline;"
                   placeholder="Enter email" id="email" name="email" minlength="3" maxlength="20"
                    >

            <button type="button" class="btn btn-primary" onclick="doChk();">중복 체크</button><br>
            <div class="col-sm-3"></div>
            <div class="col-sm-6">
            <span id="result" style="color: black;  font-weight: bold;" ></span>
            </div>
        </div>



        <div class="col-sm-4"> </div>
        </div>

        <div class="container">
            <div class="col-sm-3"></div>
        <div class="form-group col-sm-5">
            <label for="pwd">비밀번호</label>
            <input type="password" class="form-control" style="width: 50%; display: inline;"
                   placeholder="Enter password" id="pwd" name="pwd" minlength="6" maxlength="12">
            <button type="submit" class="btn btn-primary" onclick="pwd_chk()">가입 신청</button>

<br>
            <label for="pwd1">번호확인</label>
            <input type="password" class="form-control" style="width: 50%; display: inline;"
                   placeholder="Enter password" id="pwd1" name="pwd1" minlength="6" maxlength="12">



        </div>
            <div class="col-sm-4"></div>

        </div>
        <div class="container">
<div class="col-sm-4"></div>
        <div class="col-sm-4"></div>
        <div class="col-sm-4"></div></div>

    </form>
</div>
<%--멤버--%>
<hr>
<footer>
<%@include file="../foot.jsp"%>
</footer>
</body>
</html>
