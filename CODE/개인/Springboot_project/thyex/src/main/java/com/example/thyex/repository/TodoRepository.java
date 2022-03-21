package com.example.thyex.repository;

import com.example.thyex.entity.Todo;
import org.springframework.data.jpa.repository.JpaRepository;

public interface TodoRepository extends JpaRepository<Todo,Long> {
    //2단계crud
}
