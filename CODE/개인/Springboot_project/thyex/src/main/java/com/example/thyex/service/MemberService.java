package com.example.thyex.service;


import com.example.thyex.entity.Member_BOOT;
import com.example.thyex.repository.MemberRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

@Service
public class MemberService {

    @Autowired
    MemberRepository memberRepository;

    public  void save(Member_BOOT memberBOOT) throws Exception{
        Member_BOOT db_memberBOOT = memberRepository.getByEmail(memberBOOT.getEmail());
        if(db_memberBOOT != null)
            throw new Exception("강제 예외");


        memberRepository.save(memberBOOT);



    }
}
