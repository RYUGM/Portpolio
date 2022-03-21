package com.example.thyex.controller;

import com.example.thyex.entity.Todo;
import com.example.thyex.repository.TodoRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.validation.BindingResult;
import org.springframework.web.bind.annotation.*;

import javax.validation.Valid;
import java.time.LocalDateTime;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

@Controller
@RequestMapping("todo")
public class TodoController {
    @Autowired
    TodoRepository todoRepository;
    @GetMapping("selectall")
    public String selectall(Model model){
//        todoRepository.save(new Todo(0L,"할일1", LocalDateTime.now()));
//        todoRepository.save(new Todo(1L,"할일2",LocalDateTime.now()));
        List<Todo> list=todoRepository.findAll();
        System.out.println(list);
        model.addAttribute("list",list);

        return "todo/selectall";
    }
    @PostMapping("insert")
    public String insert(@Valid Todo todo, BindingResult bindingResult){

        if(bindingResult.hasErrors()){
            return "todo/selectall";
        }
        todo.setWdate(LocalDateTime.now());
        todoRepository.save(todo);
//        System.out.println(todo);

        return "redirect:selectall";
    }
    @DeleteMapping("delete")
    @ResponseBody
    public Map<String,Object> delete(Long id){
        System.out.println(id);
        todoRepository.deleteById(id);

        Map<String,Object> map = new HashMap<>();
        map.put("code","ok");
        return map;
    }
}
