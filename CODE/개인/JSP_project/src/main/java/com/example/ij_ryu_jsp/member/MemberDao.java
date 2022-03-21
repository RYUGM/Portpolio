package com.example.ij_ryu_jsp.member;
import com.example.ij_ryu_jsp.DB.DB_ACCESS;

import java.sql.*;
import java.util.ArrayList;
import java.util.List;

public class MemberDao {
    // db select...
    public List<MemberDto> memberlist() {
        Connection conn = null;
        PreparedStatement pstmt = null;
        ResultSet rs = null;
        List<MemberDto> list = new ArrayList<>();

        try {
            // jar 파일 있는지 확인
            Class.forName(DB_ACCESS.jar);
            // DB 연결
            conn =
                    DriverManager.getConnection(DB_ACCESS.url, DB_ACCESS.user, DB_ACCESS.pw);

            //sql 구문 작성
            //DB 명령어 쿼리 sql => 대문자 소문자 구분을 안함..
            // aa@naver.com AA@naver.com 내용으로는 대문자 소문자를 구분합니다.
           pstmt = conn.prepareStatement("SELECT * FROM RYU_MEMBER");

            // sql 구문 실행 및 테이블 반환...
           rs = pstmt.executeQuery();
            // next() 함수...다음 행이 있으면 True 없으면 False 반환...
            // 반복자 처럼 위치 이동...
            while (rs.next()) {
                list.add(new MemberDto(
                        rs.getInt("idx"),
                        rs.getString("email"),
                        rs.getString("pwd")
                        )
                );
            }

        } catch (Exception e) {
            e.printStackTrace();
        }finally {
            try{
                if(pstmt != null)
                    pstmt.close();
                if(rs != null)
                    rs.close();
                if(conn != null)
                    conn.close();

            }catch (Exception s){
                s.printStackTrace();
            }
        }

        return list;
    }
    public List<MemberDto> memberlist_personal(String email,String pwd) {
        Connection conn = null;
        PreparedStatement pstmt = null;
        ResultSet rs = null;
        List<MemberDto> list = new ArrayList<>();

        try {
            // jar 파일 있는지 확인
            Class.forName(DB_ACCESS.jar);
            // DB 연결
            conn =
                    DriverManager.getConnection(DB_ACCESS.url, DB_ACCESS.user, DB_ACCESS.pw);

            //sql 구문 작성
            //DB 명령어 쿼리 sql => 대문자 소문자 구분을 안함..
            // aa@naver.com AA@naver.com 내용으로는 대문자 소문자를 구분합니다.
            pstmt = conn.prepareStatement("SELECT * FROM RYU_MEMBER where email=? and pwd=?");
            pstmt.setString(1,email);
            pstmt.setString(2,pwd);

            // sql 구문 실행 및 테이블 반환...
            rs = pstmt.executeQuery();
            // next() 함수...다음 행이 있으면 True 없으면 False 반환...
            // 반복자 처럼 위치 이동...
            while (rs.next()) {
                list.add(new MemberDto(
                                rs.getInt("idx"),
                                rs.getString("email"),
                                rs.getString("pwd")
                        )
                );
            }

        } catch (Exception e) {
            e.printStackTrace();
        }finally {
            try{
                if(pstmt != null)
                    pstmt.close();
                if(rs != null)
                    rs.close();
                if(conn != null)
                    conn.close();

            }catch (Exception s){
                s.printStackTrace();
            }
        }

        return list;
    }

    public void memberset(MemberDto dto,boolean update) {
        PreparedStatement pstmt=null;
        try {
            Class.forName(DB_ACCESS.jar);
            Connection conn =
                    DriverManager.getConnection(DB_ACCESS.url, DB_ACCESS.user, DB_ACCESS.pw);

            pstmt=conn.prepareStatement("update ryu_member set email=?,pwd=? where idx=?");
            pstmt.setString(1, dto.getEmail());
            pstmt.setString(2, dto.getPwd());
            pstmt.setInt(3,dto.getIdx());


            pstmt.executeUpdate();
        } catch (Exception e) {
            e.printStackTrace();
        }
    }
    public void memberset(MemberDto dto){
        try {
            Class.forName(DB_ACCESS.jar);
            Connection conn =
                    DriverManager.getConnection(DB_ACCESS.url, DB_ACCESS.user, DB_ACCESS.pw);
            PreparedStatement pstmt =conn.prepareStatement("insert into ryu_member (email,pwd) values (?,?)");

            pstmt.setString(1, dto.getEmail());
            pstmt.setString(2, dto.getPwd());


            pstmt.executeUpdate();
        } catch (Exception e) {
            e.printStackTrace();
        }

    }

    public String delete(String[] temp) {
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
            Connection conn =
                    DriverManager.getConnection(DB_ACCESS.url,DB_ACCESS.user,DB_ACCESS.pw);

            //sql 구문 작성
            //DB 명령어 쿼리 sql => 대문자 소문자 구분을 안함..
            // aa@naver.com AA@naver.com 내용으로는 대문자 소문자를 구분합니다.
            PreparedStatement pstmt = conn.prepareStatement("delete from ryu_member where idx in ("+idxs+")");
            pstmt.executeUpdate();
            // sql 구문 실행 및 테이블 반환... ResultSet rs = pstmt.executeQuery();
            // next() 함수...다음 행이 있으면 True 없으면 False 반환...
            // 반복자 처럼 위치 이동...
          return "true";

        }catch (Exception e){
            e.printStackTrace();
        }
        return "false";
    }
    public MemberDto memberget(int idx) {
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
            pstmt = conn.prepareStatement("SELECT * FROM RYU_MEMBER WHERE idx=?");
            pstmt.setInt(1, idx);

            // sql 구문 실행 및 테이블 반환...
            rs = pstmt.executeQuery();
            // next() 함수...다음 행이 있으면 True 없으면 False 반환...
            // 반복자 처럼 위치 이동...
            while (rs.next()) {
                return new MemberDto(
                        rs.getInt("idx"),
                        rs.getString("email"),
                        rs.getString("pwd"));

            }

        } catch (Exception e) {
            e.printStackTrace();
        }finally {
            try{
                if(pstmt != null)
                    pstmt.close();
                if(rs != null)
                    rs.close();
                if(conn != null)
                    conn.close();


            }catch (Exception e){
                e.printStackTrace();
            }

        }

        return new MemberDto();

    }
    public String memberchk(String id) {

        Connection conn = null;
        PreparedStatement pstmt = null;
        ResultSet rs= null;


        try{
            Class.forName(DB_ACCESS.jar);
            conn = DriverManager.getConnection(DB_ACCESS.url,DB_ACCESS.user,DB_ACCESS.pw);
            pstmt = conn.prepareStatement("SELECT COUNT(*) AS cnt FROM ryu_member WHERE email=?");
            pstmt.setString(1,id);

            rs=pstmt.executeQuery();
            if(rs.next()){
                int cnt = rs.getInt("cnt");
                if(cnt == 0)
                    return "true";
            }

        }catch (Exception e){
            e.printStackTrace();
        }
        finally {

            try {
                rs.close();
            } catch (SQLException e) {
                e.printStackTrace();
            }
            try {
                pstmt.close();
            } catch (SQLException e) {
                e.printStackTrace();
            }
            try {
                conn.close();
            } catch (SQLException e) {
                e.printStackTrace();
            }
        }
        return "false";
    }
    public boolean member_login(String email,String pwd){

        Connection conn = null;
        PreparedStatement pstmt = null;
        ResultSet rs = null;
        try{
            Class.forName(DB_ACCESS.jar);
            conn= DriverManager.getConnection(DB_ACCESS.url,DB_ACCESS.user,DB_ACCESS.pw);
            pstmt= conn.prepareStatement("select * from ryu_member where email=? and pwd=?");
            pstmt.setString(1,email);

            pstmt.setString(2,pwd);

            rs=pstmt.executeQuery();

            if(rs.next()) {
                return true;
            }


        }catch (Exception e) {
            e.printStackTrace();

        }

        finally {
            try{
                if(rs != null)
                    rs.close();
                if(pstmt != null)
                    pstmt.close();
                if(conn != null)
                    conn.close();

            }catch (Exception e){}

            }
            return false;

    }
}