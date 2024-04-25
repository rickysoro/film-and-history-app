package com.filmandhistory.login.dao;

import com.filmandhistory.login.model.User;
import jakarta.persistence.criteria.CriteriaBuilder;
import org.springframework.data.repository.CrudRepository;
import org.springframework.stereotype.Repository;

import java.util.List;

@Repository("dbUserDAO")
public interface UserRepositoryDAO extends CrudRepository<User, Integer> {
    public User findUserByUsername(String username);
    public User findByUsernameAndPassword(String username, String password);
    public List<User> findByUsernameContains(String username);
}
