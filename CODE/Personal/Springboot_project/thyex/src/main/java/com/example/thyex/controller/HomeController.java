package com.example.thyex.controller;

import com.example.thyex.entity.Member_BOOT;
import com.example.thyex.repository.MemberRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;

import java.util.List;

@Controller
public class HomeController {
    @Autowired
    MemberRepository memberRepository;

    @GetMapping("main")
    public String index(Model model){

//        memberRepository.save(new Member().createMember(new MemberFormDto("123@123","1234")));

        List<Member_BOOT> list = memberRepository.findAll();
        System.out.println(list);
        model.addAttribute("myname","honggildong");

        return "main";
    }

}
