package com.example.ij_ryu_jsp.board;

public class BoardDto {
    private int idx;
    private String name;
    private  String title;
    private  String content;
    private  String wdate;
    private String cate;
    private String pwd;

    public  BoardDto(){}

    public BoardDto(int idx, String name, String title, String content, String wdate,String cate,String pwd) {
        this.idx = idx;
        this.name = name;
        this.title = title;
        this.content = content;
        this.wdate = wdate;
        this.cate=cate;
        this.pwd=pwd;
    }

    public String getPwd() {
        return pwd;
    }

    public void setPwd(String pwd) {
        this.pwd = pwd;
    }

    public String getCate() {
        return cate;
    }

    public void setCate(String cate) {
        this.cate = cate;
    }

    public int getIdx() {
        return idx;
    }

    public void setIdx(int idx) {
        this.idx = idx;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getTitle() {
        return title;
    }

    public void setTitle(String title) {
        this.title = title;
    }

    public String getContent() {
        return content;
    }

    public void setContent(String content) {
        this.content = content;
    }

    public String getWdate() {
        return wdate;
    }

    public void setWdate(String wdate) {
        this.wdate = wdate;
    }

//    @Override
//    public String toString() {
//        return "BoardDto{" +
//                "idx=" + idx +
//                ", name='" + name + '\'' +
//                ", title='" + title + '\'' +
//                ", content='" + content + '\'' +
//                ", wdate='" + wdate + '\'' +
//                '}';
//    }

//    @Override
//    public String toString() {
//        return "BoardDto{" +
//                "idx=" + idx +
//                ", name='" + name + '\'' +
//                ", title='" + title + '\'' +
//                ", content='" + content + '\'' +
//                ", wdate='" + wdate + '\'' +
//                ", cate='" + cate + '\'' +
//                '}';
//    }

    @Override
    public String toString() {
        return "BoardDto{" +
                "idx=" + idx +
                ", name='" + name + '\'' +
                ", title='" + title + '\'' +
                ", content='" + content + '\'' +
                ", wdate='" + wdate + '\'' +
                ", cate='" + cate + '\'' +
                ", pwd='" + pwd + '\'' +
                '}';
    }
}

