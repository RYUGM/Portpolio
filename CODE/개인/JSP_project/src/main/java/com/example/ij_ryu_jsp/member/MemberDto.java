package com.example.ij_ryu_jsp.member;

public class MemberDto {
    private int idx;
    private String email;
    private String pwd;

    public MemberDto(){}

    @Override
    public String toString() {
        return "MemberDto{" +
                "idx=" + idx +
                ", email='" + email + '\'' +
                ", pwd='" + pwd + '\'' +
                '}';
    }

    public int getIdx() {
        return idx;
    }

    public void setIdx(int idx) {
        this.idx = idx;
    }

    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        this.email = email;
    }

    public String getPwd() {
        return pwd;
    }

    public void setPwd(String pwd) {
        this.pwd = pwd;
    }

    public MemberDto(int idx, String email, String pwd) {
        this.idx = idx;
        this.email = email;
        this.pwd = pwd;
    }
}
