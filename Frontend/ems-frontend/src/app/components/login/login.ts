import { Component, inject } from '@angular/core';

import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';

import { Router } from '@angular/router';

import { AuthService } from '../../services/auth.service';

import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-login',
  imports: [ReactiveFormsModule, CommonModule],
  templateUrl: './login.html',
})
export class Login {
  private fb = inject(FormBuilder);

  private authService = inject(AuthService);

  private router = inject(Router);

  errorMessage = '';

  loginForm = this.fb.group({
    emailId: ['', [Validators.required, Validators.email]],

    password: ['', Validators.required],
  });

  onSubmit(): void {
    if (this.loginForm.invalid) {
      return;
    }

    this.authService.login(this.loginForm.value as any).subscribe({
      next: (response) => {
        console.log(response);

        this.authService.saveToken(response.token);

        console.log(localStorage.getItem('token'));

        this.router.navigateByUrl('/dashboard');
      },

      error: () => {
        this.errorMessage = 'Invalid Email or Password';
      },
    });
  }
}
