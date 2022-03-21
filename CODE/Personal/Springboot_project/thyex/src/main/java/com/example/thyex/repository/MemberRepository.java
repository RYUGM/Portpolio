package com.example.thyex.repository;

import com.example.thyex.entity.Member_BOOT;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.Pageable;
import org.springframework.data.jpa.repository.JpaRepository;

import javax.transaction.Transactional;
import java.util.List;

public interface MemberRepository extends JpaRepository<Member_BOOT,Long> {

    Member_BOOT getByEmail(String email);
    Page<Member_BOOT> findByEmailContaining(String email, Pageable pageable);


//    long deleteAllByIdIn(List<Long> id);
//    Member getByPwd(String pwd);
@Transactional
long deleteAllByIdIn(List<Long> id);
//    Member ByEmailOrPwd(String email,String pwd);


}
