package com.example.thyex.dto;

import lombok.*;
import org.hibernate.validator.constraints.Length;

import javax.validation.constraints.Email;
import javax.validation.constraints.NotEmpty;

@Getter
@Setter
@ToString
@AllArgsConstructor
@RequiredArgsConstructor

public class MemberFormDto {

   private Long id;

   @NotEmpty(message = "필수 입력값")
   @Email(message = "이메일 형식으로 입력하세요")
   private String email;



   @NotEmpty(message = "필수 입력값")
   @Length(min = 4,max = 8,message = "비밀번호는 4~8사이의 값 입력")
   private  String pwd;




}
