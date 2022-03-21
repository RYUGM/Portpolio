package com.example.thyex.entity;


import lombok.*;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Id;

@Entity
@Getter
@Setter
@ToString
@AllArgsConstructor
@NoArgsConstructor

public class CVD_19 {
    @Id

//    private int total;
//    private int total_death;
//    private int total_cnt;
//    private int wdate;
    @Column(name = "pred_cnt")
    private int pred_cnt;

    @Column(name = "pred")
    private int pred;

    @Column(name = "pred_total")
    private int pred_total;




}
