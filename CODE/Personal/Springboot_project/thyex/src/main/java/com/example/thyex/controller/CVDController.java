package com.example.thyex.controller;

import com.example.thyex.entity.CVD_19;
import com.example.thyex.repository.CVDRepository;
import com.google.gson.Gson;
import com.google.gson.JsonArray;
import com.google.gson.JsonObject;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;

import java.util.Iterator;
import java.util.List;

@Controller
@RequestMapping("CVD")
public class CVDController {
    @Autowired
    CVDRepository cvdRepository;
    @GetMapping("selectall")
    public String selectall(Model model){
        Gson gson = new Gson();
        JsonArray jArray = new JsonArray();
        List<CVD_19> list=cvdRepository.findAll();
        Iterator<CVD_19> it = list.iterator();
        while (it.hasNext()){
            CVD_19 cv9 = it.next();
            JsonObject object = new JsonObject();
            int pred = cv9.getPred();
            int pred_total = cv9.getPred_total();
            int cnt = cv9.getPred_cnt();
            object.addProperty("pred",pred);
            object.addProperty("pred_total", pred_total);
            object.addProperty("Count", cnt);
            jArray.add(object);
        }
        String json = gson.toJson(jArray);
        System.out.println(jArray.getClass().getName());

        model.addAttribute("CVD_list", json);

        return "CVD/selectall";
    }


}
