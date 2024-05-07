import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../@core/services/auth.service';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})

export class LoginComponent implements OnInit {
  constructor(private authService: AuthService, private router: Router) {}

  ngOnInit(): void {
    if (this.authService.isAuthenticated()) {
      this.router.navigateByUrl("/");
    }
  }

  login(form: NgForm) {
    console.log("login component.ts", form.value)
    form.control.markAllAsTouched();
    if (form.valid) {
      this.authService.login(form.value).subscribe({
        next: (response) => {
          localStorage.setItem("user", JSON.stringify(response));
          this.router.navigateByUrl("/welcome");
        },
        error: () => alert("Login Errato"),
      });
    }
  }
}
