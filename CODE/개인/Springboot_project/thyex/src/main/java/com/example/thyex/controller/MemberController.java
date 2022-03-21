package com.example.thyex.controller;

import com.example.thyex.dto.MemberFormDto;
import com.example.thyex.entity.Member_BOOT;
import com.example.thyex.repository.MemberRepository;
import com.example.thyex.service.MemberService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.PageRequest;
import org.springframework.data.domain.Pageable;
import org.springframework.data.domain.Sort;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.validation.BindingResult;
import org.springframework.web.bind.annotation.*;

import javax.validation.Valid;
import java.util.Arrays;
import java.util.List;

@Controller
@RequestMapping(value = "members")
public class MemberController {
    @Autowired
//    MemberService memberService = new MemberService();<-메모리 낭비
    MemberService memberService;


    @Autowired
    MemberRepository memberRepository;

    @PostMapping("delete")
    public String delete(Long id[]){
        List<Long> ids = Arrays.asList(id);
        memberRepository.deleteAllByIdIn(ids);

        return "redirect:selectall";
    }

    @GetMapping("selectall")
    public String selectall(Model model,

                            @RequestParam(defaultValue = "0",required = false) int pageNum,
                            @RequestParam(defaultValue = "5",required = false) int size,
                            @RequestParam(defaultValue = "",required = false) String email
                            ){
        Pageable page= PageRequest.of(pageNum,size,Sort.by(Sort.Direction.DESC,"id"));
//        Page<Member> members= memberRepository.findAll(page);
        Page<Member_BOOT> members= memberRepository.findByEmailContaining(email,page);

        System.out.println("gettotal_page"+members.getTotalPages());
//        System.out.println("getnumber"+members.getNumber());
//        System.out.println("members.getPageable().getPageNumber()"+members.getPageable().getPageNumber());


        model.addAttribute("members",members);


        return "members/selectall";
    }

//    @GetMapping("update")
//    public String update(Model model , @RequestParam() Long id){
//        Member member=memberRepository.findById(id).orElse(new Member());
//        System.out.println(id);
//        model.addAttribute("id",id);
//        model.addAttribute("memberFormDto",new MemberFormDto(member.getEmail(),member.getPwd()));
//
//
//        return "members/update";
//    }
@GetMapping("update")
public String update(Model model, @RequestParam() Long id){
    Member_BOOT memberBOOT = memberRepository.findById(id).orElse(new Member_BOOT());
    model.addAttribute("memberFormDto", new MemberFormDto(id, memberBOOT.getEmail(), memberBOOT.getPwd()));
    return "members/update";
}

    @GetMapping("insert")
    public String insert(Model model) {

        model.addAttribute("memberFormDto",new MemberFormDto());
        return "members/insert";
    }
    @PostMapping("update")
//    @RequestMapping(value="insert",method = RequestMethod.POST)
    public String update(@Valid MemberFormDto memberFormDto, BindingResult bindingResult, Model model, Long id) {
        model.addAttribute("id",id.toString());
//        model.addAttribute("memberFormDto",memberFormDto);

        if(bindingResult.hasErrors()){
            System.out.println(bindingResult.getFieldError());
            return "members/update";

        }
//        System.out.println("post member "+dto);
        Member_BOOT memberBOOT = Member_BOOT.createMember(memberFormDto);
        memberBOOT.setId(id);
        try {
            memberService.save(memberBOOT);
        }catch (Exception e){
            System.out.println("중복"+e.toString());
            model.addAttribute("errorMessage","Email중복");

            return "members/update";
        }



//        Member member= Member.createMember(dto);

        return "redirect:selectall";
    }

    @PostMapping("insert")
//    @RequestMapping(value="insert",method = RequestMethod.POST)
    public String insert(@Valid MemberFormDto memberFormDto, BindingResult bindingResult, Model model) {
        model.addAttribute("exif",false);
//        model.addAttribute("memberFormDto",memberFormDto);

        if(bindingResult.hasErrors()){
            System.out.println(bindingResult.getFieldError());
            return "members/insert";

        }
//        System.out.println("post member "+dto);
        Member_BOOT memberBOOT = Member_BOOT.createMember(memberFormDto);
        try {
            memberService.save(memberBOOT);
        }catch (Exception e){
            System.out.println("중복"+e.toString());
            model.addAttribute("errorMessage","Email중복");

            return "members/insert";
        }



//        Member member= Member.createMember(dto);

        return "redirect:selectall";
    }
}
