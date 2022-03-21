package com.example.thyex.entity;


import lombok.*;
import org.hibernate.annotations.CreationTimestamp;

import javax.persistence.*;
import javax.validation.constraints.NotEmpty;
import java.time.LocalDateTime;

@Entity
@Getter
@Setter
@ToString
@AllArgsConstructor
@NoArgsConstructor

public class Todo {
    @Id
    @Column(name = "id", nullable = false)
    @GeneratedValue(strategy = GenerationType.AUTO)
    private Long id;

    @NotEmpty(message = "필수 입력값")
    private String content;
//    private String wdate;
    @Column(name = "wdate",updatable = false)
    @CreationTimestamp
    private LocalDateTime wdate;
    //1단계 entity


}
