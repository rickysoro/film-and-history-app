import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { User, LoginDTO, RegisterDTO } from '../../models/user';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  springBootUrl = 'http://localhost:8080/';

  constructor(private router: Router, private http: HttpClient) { }

  login(loginData: LoginDTO) {
    console.log('auth service.ts', loginData);
    return this.http.get(`${this.springBootUrl + 'users/login/'}${loginData.username}/${loginData.pasword}`);
  }

  register(registerData: RegisterDTO) {
    this.router.navigateByUrl('/');
    return this.http.post<RegisterDTO>(`${this.springBootUrl + 'utility/registration'}`, registerData);
  }

  logout() {
    localStorage.removeItem("user");
  }

  isAuthenticated() {
    return !!localStorage.getItem("user");
  }

  getCurrentUser() {
    const user = JSON.parse(localStorage.getItem("user") || '') as User;
    return user;
  }
}
