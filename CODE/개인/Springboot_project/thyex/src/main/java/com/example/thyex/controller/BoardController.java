package com.example.thyex.controller;

import com.example.thyex.dto.BoardFormDto;
import com.example.thyex.dto.MemberFormDto;
import com.example.thyex.entity.Board_BOOT;
import com.example.thyex.repository.BoardRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.validation.BindingResult;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestMapping;

import javax.validation.Valid;
import java.util.List;

@RequestMapping("board")
@Controller
public class BoardController {

    @Autowired
    BoardRepository boardRepository;
    @GetMapping("selectall")
    public String selecaAll(Model model){
      List<Board_BOOT> list= boardRepository.findAll();
      model.addAttribute("list",list);

        return "board/selectall";
    }
    @GetMapping("insert")
    public String insert(Model model){
        model.addAttribute("boardformdto",new BoardFormDto());
        return "board/insert";
    }

    @GetMapping("view")
    public String view(Model model,long id){
      Board_BOOT board_boot=  boardRepository.findById(id).orElse(new Board_BOOT());
      model.addAttribute("board",board_boot);
        return "board/view";
    }

    @PostMapping("insert")
    public String insert(@Valid BoardFormDto boardformdto , BindingResult bindingResult,
                         Model model){
        if(bindingResult.hasErrors()){
            model.addAttribute("errorMessage","ERROR!");
            return "board/insert";
        }
        Board_BOOT board_boot = Board_BOOT.createBoard(boardformdto);
        boardRepository.save(board_boot);
//        Board
//        boardRepository.save();


        return "redirect:selectall";
    }


}
