package com.filmandhistory.login.service;

import com.filmandhistory.login.dao.UserRepositoryDAO;
import com.filmandhistory.login.model.Login;
import com.filmandhistory.login.model.User;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Qualifier;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Service;

import java.util.Iterator;
import java.util.List;

@Service
public class UserService {
    UserRepositoryDAO userDAO;

    @Autowired
    public UserService(@Qualifier("dbUserDAO") UserRepositoryDAO userDAO) {
        this.userDAO = userDAO;
    }

    public String addUser(User user) {
        User userToAdd = userDAO.save(user);
        if (userToAdd != null) {
            return "User successfully saved";
        } else {
            return "Could not save the user data";
        }
    }

    public Iterable<User> getAllUsers() {
        return userDAO.findAll();
    }

    public User getUser(int id) {
        return userDAO.findById(id).orElseGet(null);
    }

    public User updateUser(int id, User user) {
        User userToUpdate = userDAO.findById(id).get();
        if (userToUpdate != null) {
            userToUpdate.setName(user.getName());
            userToUpdate.setLastName(user.getLastName());
            userToUpdate.setUsername(user.getUsername());
            userToUpdate.setPassword(user.getPassword());
            userToUpdate.setId(id);
            return userToUpdate;
        }
        return null;
    }

    public String deleteUser(int id) {
        User userToDelete = userDAO.findById(id).get();
        if (userToDelete == null) {
            return "User not found";
        } else {
            userDAO.delete(userToDelete);
            return "User successfully deleted";
        }
    }

    public ResponseEntity<User> registerUser(User user) {
        User userDB = userDAO.findUserByUsername(user.getUsername());
        if (userDB != null) {
            return ResponseEntity.status(HttpStatus.BAD_REQUEST).build();
        }
        User userToRegister = userDAO.save(user);
        if (userToRegister != null) {
            return ResponseEntity.status(HttpStatus.OK).body(userToRegister);
        } else {
            return ResponseEntity.status(HttpStatus.BAD_REQUEST).build();
        }
    }

    public User loginUser(Login login) {
        return userDAO.findByUsernameAndPassword(login.getUsername(), login.getPassword());
    }

    public List<User> findByUsernameContains(String username) {
        return userDAO.findByUsernameContains(username);
    }
}
