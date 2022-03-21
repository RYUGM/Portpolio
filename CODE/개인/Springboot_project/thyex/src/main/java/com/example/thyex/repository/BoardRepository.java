package com.example.thyex.repository;

import com.example.thyex.entity.Board_BOOT;
import org.springframework.data.jpa.repository.JpaRepository;

public interface BoardRepository extends JpaRepository<Board_BOOT, Long> {
}
