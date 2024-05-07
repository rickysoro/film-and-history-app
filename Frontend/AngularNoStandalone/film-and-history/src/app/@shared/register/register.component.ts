import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../@core/services/auth.service';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrl: './register.component.scss'
})
export class RegisterComponent implements OnInit {

  constructor(private authService: AuthService, private router: Router) { }

  ngOnInit(): void {
    if (this.authService.isAuthenticated()) {
      this.router.navigateByUrl("/");
    }
  }

  register(form: NgForm) {
    form.control.markAllAsTouched();
    if (form.valid) {
      this.authService.register(form.value).subscribe({
        next: (response) => {
          this.router.navigateByUrl("/profile")
        },
        error: () => alert('registrazione errata')
      });
    }
  }

}
