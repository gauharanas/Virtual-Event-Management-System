import { Component, inject } from '@angular/core';

import {
  FormBuilder,
  ReactiveFormsModule,
  Validators
} from '@angular/forms';

import { CommonModule } from '@angular/common';

import { Router } from '@angular/router';

import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-register',
  imports: [
    CommonModule,
    ReactiveFormsModule
  ],
  templateUrl: './register.html'
})
export class Register {

  private fb = inject(FormBuilder);

  private authService = inject(AuthService);

  private router = inject(Router);

  successMessage = '';

  registerForm = this.fb.group({

    userName: ['', Validators.required],

    emailId: ['', [Validators.required, Validators.email]],

    password: ['', Validators.required],

    role: ['Participant']
  });

 onSubmit(): void {

  if (this.registerForm.invalid) {

    return;

  }

  this.authService
    .register(this.registerForm.value as any)
    .subscribe({

      next: () => {

        this.successMessage =
          'Registration Successful';

        setTimeout(() => {
          console.log('redirecting...');
          this.router.navigateByUrl('/login');

        }, 1500);

      },

      error: (err) => {

        console.log(err);

      }

    });
}
}