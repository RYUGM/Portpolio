package com.example.thyex.entity;

import com.example.thyex.dto.BoardFormDto;
import lombok.Getter;
import lombok.Setter;
import org.hibernate.annotations.CreationTimestamp;

import javax.persistence.*;
import java.time.LocalDateTime;
import java.util.ArrayList;
import java.util.List;

@Entity
@Getter
@Setter
public class Board_BOOT {

    @Id
    @Column(name = "board_id", nullable = false)
    @GeneratedValue(strategy = GenerationType.AUTO)
    private Long id;

    private String name;
    private String title;
    private String content;

    @Column(name="wdate", updatable = false)
    @CreationTimestamp
    private LocalDateTime wdate;

    @OneToMany(mappedBy = "boardBOOT",
            cascade = CascadeType.ALL
            , orphanRemoval = true,
            fetch = FetchType.LAZY)
    List<BoardTail> boardTailList
            = new ArrayList<>();

    public static Board_BOOT createBoard(BoardFormDto boardformdto) {
        Board_BOOT board_boot = new Board_BOOT();
        board_boot.setContent(boardformdto.getContent());
        board_boot.setName(boardformdto.getName());
        board_boot.setTitle(boardformdto.getTitle());
        board_boot.setWdate(boardformdto.getWdate());
        return board_boot;


    }
}
