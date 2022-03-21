package com.example.thyex.entity;

import com.example.thyex.dto.MemberFormDto;
import lombok.Getter;
import lombok.Setter;
import lombok.ToString;

import javax.persistence.*;

@Entity
@Getter
@Setter
@ToString
public class Member_BOOT {
    @Id
    @Column(name = "id", nullable = false)
    @GeneratedValue(strategy = GenerationType.AUTO)

    private Long id;

    private String email;
    private String pwd;

    public static Member_BOOT createMember(MemberFormDto memberFormDto){
        Member_BOOT memberBOOT = new Member_BOOT();

        memberBOOT.setEmail(memberFormDto.getEmail());

        memberBOOT.setPwd(memberFormDto.getPwd());

        return memberBOOT;
    }





}
