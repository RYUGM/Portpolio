package com.example.thyex.dto;

import lombok.*;
import org.hibernate.annotations.CreationTimestamp;
import org.hibernate.validator.constraints.Length;

import javax.persistence.Column;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.validation.constraints.NotEmpty;
import java.time.LocalDateTime;

@Getter
@Setter
@AllArgsConstructor
@NoArgsConstructor
@ToString

public class BoardFormDto {

    private Long id;

    @Length(min=2 , max = 8, message = "2~8")
    @NotEmpty(message = "필수 입력 값")
    private String name;

    @Length(min=1 , max = 10, message = "1~10")
    @NotEmpty(message = "필수 입력 값")
    private String title;

    @Length(min=5 , max = 100, message = "5~100")
    @NotEmpty(message = "필수 입력 값")
    private String content;


    private LocalDateTime wdate;
}
