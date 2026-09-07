import { Component, inject } from '@angular/core';

import {
  Router,
  RouterLink
} from '@angular/router';

import { CommonModule } from '@angular/common';

import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-navbar',

  imports: [
    RouterLink,
    CommonModule
  ],

  templateUrl: './navbar.html'
})
export class Navbar {

  private authService = inject(AuthService);

  private router = inject(Router);

  isLoggedIn(): boolean {

    return this.authService.isLoggedIn();

  }

  logout(): void {

    this.authService.logout();

    this.router.navigateByUrl('/login');

  }
}