package com.filmandhistory.login.controller;

import com.filmandhistory.login.model.Login;
import com.filmandhistory.login.model.User;
import com.filmandhistory.login.service.UserService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@CrossOrigin
@RequestMapping("/users")
public class UserController {
    private UserService userService;

    @Autowired
    public UserController(UserService userService) {
        this.userService = userService;
    }

    @GetMapping("/{id}")
    public User getUser(@PathVariable("id") int id) {
        return userService.getUser(id);
    }

    @GetMapping("/")
    public Iterable<User> getAllUsers() {
        return userService.getAllUsers();
    }

    @PostMapping("/")
    public String addUser(@RequestBody User user) {
        return userService.addUser((user));
    }

    @PutMapping("/{id}")
    public User updateUser(@PathVariable("id") int id, User user) {
        return userService.updateUser(id, user);
    }

    @DeleteMapping("/{id}")
    public String deleteUser(@PathVariable("id") int id) {
        return userService.deleteUser(id);
    }

    @GetMapping("/user/{username}")
    public List<User> findByUsernameContains(@PathVariable("username") String username) {
        return userService.findByUsernameContains(username);
    }

    @GetMapping("/login/{username}/{password}")
    public ResponseEntity<User> login(@PathVariable("username") String username, @PathVariable("password") String password) {
        User userToLogin = userService.loginUser(new Login(username, password));
        System.out.println("user" + userToLogin);
        if (userToLogin != null) {
            return ResponseEntity.status(HttpStatus.OK).body(userToLogin);
        } else {
            return ResponseEntity.status(HttpStatus.NOT_FOUND.value()).body(userToLogin);
        }
    }
}
