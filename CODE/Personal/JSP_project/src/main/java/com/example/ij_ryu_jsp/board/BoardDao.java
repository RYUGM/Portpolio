package com.example.ij_ryu_jsp.board;

import com.example.ij_ryu_jsp.DB.DB_ACCESS;
import com.example.ij_ryu_jsp.member.MemberDto;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.util.ArrayList;
import java.util.List;

public class BoardDao {
    public List<BoardDto> selectlist() {
        List<BoardDto> list = new ArrayList<>();
        Connection conn = null;
        PreparedStatement pstmt = null;
        ResultSet rs = null;

        try {
            // jar 파일 있는지 확인
            Class.forName(DB_ACCESS.jar);
            // DB 연결
            conn =
                    DriverManager.getConnection(DB_ACCESS.url, DB_ACCESS.user, DB_ACCESS.pw);

            //sql 구문 작성
            //DB 명령어 쿼리 sql => 대문자 소문자 구분을 안함..
            // aa@naver.com AA@naver.com 내용으로는 대문자 소문자를 구분합니다.
          pstmt = conn.prepareStatement("SELECT * FROM board\n" +
                    "ORDER BY idx desc LIMIT 0,10;");

            // sql 구문 실행 및 테이블 반환...
           rs = pstmt.executeQuery();
            // next() 함수...다음 행이 있으면 True 없으면 False 반환...
            // 반복자 처럼 위치 이동...
            while (rs.next()) {
                list.add(new BoardDto(
                        rs.getInt("idx")
                        , rs.getString("name")
                        , rs.getString("title")
                        , rs.getString("content")
                        , rs.getString("wdate")
                        , rs.getString("cate")
                        ,rs.getString("pwd")));

            }

        } catch (Exception e) {
            e.printStackTrace();
        }finally {
            try {
                if (rs != null) rs.close();
                if (pstmt != null) pstmt.close();
                if (conn != null) conn.close();
            }catch (Exception e){}
        }

        return list;
    }
    public List<BoardDto> selectlist_cate(String cate,int pagenum) {
        int slimit = (pagenum -1)*10;
//        pagenum = (pagenum*10);
        if(cate == null)
            cate = "%%";
        List<BoardDto> list = new ArrayList<>();
        Connection conn = null;
        PreparedStatement pstmt = null;
        ResultSet rs= null;

        try {
            // jar 파일 있는지 확인
            Class.forName(DB_ACCESS.jar);
            // DB 연결
            conn =
                    DriverManager.getConnection(DB_ACCESS.url, DB_ACCESS.user, DB_ACCESS.pw);

            //sql 구문 작성
            //DB 명령어 쿼리 sql => 대문자 소문자 구분을 안함..
            // aa@naver.com AA@naver.com 내용으로는 대문자 소문자를 구분합니다.
            pstmt = conn.prepareStatement("SELECT * FROM board WHERE cate like " +'?'+ " ORDER BY idx desc LIMIT "+slimit+",10");
            pstmt.setString(1,cate);
//            pstmt.setInt(2,pagenum-10);
//            pstmt.setInt(3, pagenum);


            // sql 구문 실행 및 테이블 반환...
           rs = pstmt.executeQuery();
            // next() 함수...다음 행이 있으면 True 없으면 False 반환...
            // 반복자 처럼 위치 이동...
            while (rs.next()) {
                list.add(new BoardDto(
                        rs.getInt("idx")
                        , rs.getString("name")
                        , rs.getString("title")
                        , rs.getString("content")
                        , rs.getString("wdate")
                        , rs.getString("cate")
                ,rs.getString("pwd")));

            }

        } catch (Exception e) {
            e.printStackTrace();
        }finally {
            try {
                if (rs != null)
                    rs.close();
                if (pstmt != null)
                    pstmt.close();
                if (conn != null)
                    conn.close();
            } catch (Exception e) {
            }
        }
        return list;
    }

    public String insert(BoardDto dto) {
        try {
            // jar 파일 있는지 확인
            Class.forName(DB_ACCESS.jar);
            // DB 연결
            Connection conn =
                    DriverManager.getConnection(DB_ACCESS.url, DB_ACCESS.user, DB_ACCESS.pw);

            //sql 구문 작성
            //DB 명령어 쿼리 sql => 대문자 소문자 구분을 안함..
            // aa@naver.com AA@naver.com 내용으로는 대문자 소문자를 구분합니다.


            // sql 구문 실행 및 테이블 반환...
            PreparedStatement pstmt =
                    conn.prepareStatement(
                            "INSERT INTO board " +
                                    "(name, title,content,wdate,cate,pwd) " +
                                    "VALUES " +
                                    "(?, ?,?,DATE_FORMAT(NOW(),'%Y-%m-%d %H:%i'),?,?)");
            pstmt.setString(1,dto.getName());
            pstmt.setString(2,dto.getTitle());
            pstmt.setString(3,dto.getContent());
            pstmt.setString(4,dto.getCate());
            pstmt.setString(5,dto.getPwd());
            pstmt.executeUpdate();
            return "true";

        }catch (Exception e){
            e.printStackTrace();
        }
        return "false";
    }

    public BoardDto selectrow(int idx) {
        try {

            Class.forName(DB_ACCESS.jar);

            Connection conn =
                    DriverManager.getConnection(DB_ACCESS.url, DB_ACCESS.user, DB_ACCESS.pw);

            PreparedStatement pstmt =
                    conn.prepareStatement(
                            "select * from board where idx=?");
            pstmt.setInt(1,idx);

            ResultSet re = pstmt.executeQuery();
            if(re.next()){
                return new BoardDto(re.getInt("idx"),
                        re.getString("name"),
                        re.getString("title"),
                        re.getString("content"),
                        re.getString("wdate"),
                        re.getString("cate"),
                        re.getString("pwd"));
            }

        }catch (Exception e){
            e.printStackTrace();
        }
        return new BoardDto();

    }
    public void board_update(BoardDto dto, boolean update) {
        PreparedStatement pstmt = null;
        try {
            Class.forName(DB_ACCESS.jar);
            Connection conn =
                    DriverManager.getConnection(DB_ACCESS.url, DB_ACCESS.user, DB_ACCESS.pw);

            pstmt=conn.prepareStatement("update board set title=?,content=?,cate=?,pwd=? where idx=?");
            pstmt.setString(1, dto.getTitle());

            pstmt.setString(2,dto.getContent());
            pstmt.setString(3,dto.getCate());
            pstmt.setString(4,dto.getPwd());
            pstmt.setInt(5,dto.getIdx());


            pstmt.executeUpdate();
        } catch (Exception e) {
            e.printStackTrace();
        }
    }
    public String board_del(String[] temp) {
        Connection conn = null;
        PreparedStatement pstmt =null;

        String idxs="";
        for(int i=0; i<temp.length; i++){
            if((temp.length-1)!=i)
                idxs=idxs+temp[i]+",";
            else idxs=idxs+temp[i];
        }
        System.out.println(idxs);
        try{
            // jar 파일 있는지 확인
            Class.forName(DB_ACCESS.jar);
            // DB 연결
             conn =
                    DriverManager.getConnection(DB_ACCESS.url,DB_ACCESS.user,DB_ACCESS.pw);

            //sql 구문 작성
            //DB 명령어 쿼리 sql => 대문자 소문자 구분을 안함..
            // aa@naver.com AA@naver.com 내용으로는 대문자 소문자를 구분합니다.
            pstmt = conn.prepareStatement("delete from board where idx in ("+idxs+")");
            pstmt.executeUpdate();
            // sql 구문 실행 및 테이블 반환... ResultSet rs = pstmt.executeQuery();
            // next() 함수...다음 행이 있으면 True 없으면 False 반환...
            // 반복자 처럼 위치 이동...
            return "true";

        }catch (Exception e){
            e.printStackTrace();
        }finally {
            try{
                if(pstmt != null)
                    pstmt.close();
                if(conn != null)
                    conn.close();


            }catch (Exception e){

            }

        }

        return "false";
    }

    public int page_cnt() {
        Connection conn = null;
        PreparedStatement pstmt = null;
        ResultSet rs= null;

        try {
            // jar 파일 있는지 확인
            Class.forName(DB_ACCESS.jar);
            // DB 연결
            conn =
                    DriverManager.getConnection(DB_ACCESS.url, DB_ACCESS.user, DB_ACCESS.pw);

            //sql 구문 작성
            //DB 명령어 쿼리 sql => 대문자 소문자 구분을 안함..
            // aa@naver.com AA@naver.com 내용으로는 대문자 소문자를 구분합니다.
            pstmt = conn.prepareStatement("SELECT COUNT(*) AS pagecnt FROM board;");


            // sql 구문 실행 및 테이블 반환...
            rs = pstmt.executeQuery();
            // next() 함수...다음 행이 있으면 True 없으면 False 반환...
            // 반복자 처럼 위치 이동...
            if (rs.next()) {
                int rowcnt = rs.getInt("pagecnt");
                int pagecnt = (rowcnt/10) + (rowcnt%10>0? 1:0);
                return pagecnt;

            }

        } catch (Exception e) {
            e.printStackTrace();
        }finally {
            try {
                if (rs != null)
                    rs.close();
                if (pstmt != null)
                    pstmt.close();
                if (conn != null)
                    conn.close();
            } catch (Exception e) {
            }
        }
        return 1;
    }
    }
