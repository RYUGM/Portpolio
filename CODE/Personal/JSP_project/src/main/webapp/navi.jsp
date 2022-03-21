<%--<%@ page contentType="text/html; charset=UTF-8" pageEncoding="UTF-8"%>--%>
<nav class="navbar navbar-inverse">
    <div class="container-fluid">
        <div class="navbar-header">
            <a class="navbar-brand" href="#">RYU-HomePage</a>
        </div>
<%--        <ul class="nav navbar-nav">--%>

<%--        </ul>--%>
        <ul class="nav navbar-nav">
            <li class="active"><a href="/RYU_JSP_war_exploded/index.jsp">Home</a></li>


            <li class="dropdown">
                <a class="dropdown-toggle" data-toggle="dropdown" href="#">My HomePages
                    <span class="caret"></span></a>
                <ul class="dropdown-menu">
                    <li><a href="https://ryugm.github.io/RYUGM/">First HomePage</a></li>
                    <li><a href="/RYU_JSP_war_exploded/HTML/Second_web.html">Second HomePage</a></li>

                </ul>
            </li>

            <li class="dropdown">
                <a class="dropdown-toggle" data-toggle="dropdown" href="#">My ProJect
                    <span class="caret"></span></a>
                <ul class="dropdown-menu">
                    <li><a href="#">Java Project</a></li>
                    <li><a href="#">Python Project</a></li>
                    <li><a href="#">C Project</a></li>
                    <li><a href="#">HTML Project</a></li>

                </ul>
            </li>

            <li><a href="https://github.com/RYUGM?tab=repositories">My GitHub</a></li>





            <li><a href="#">ETC</a></li>



        </ul>
        <ul class="nav navbar-nav navbar-right">
            <li><a href="/RYU_JSP_war_exploded/member/member_list_each.jsp">Account</a></li>
            <li><a href="#">About RYU</a></li>
            <li><a href="#">&nbsp;&nbsp;&nbsp;</a></li>


        </ul>
    </div>
</nav>