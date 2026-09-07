import {
  CanActivateFn,
  Router
} from '@angular/router';

import { inject } from '@angular/core';

import { AuthService }
from '../services/auth.service';

export const authGuard:
CanActivateFn = () => {

  const router =
    inject(Router);

  const authService =
    inject(AuthService);

  const token =
    localStorage.getItem('token');

  if (!token) {

    router.navigate(['/login']);

    return false;

  }

  const role =
    authService.getUserRole();

  if (role !== 'Admin') {

    router.navigate(['/home']);

    return false;

  }

  return true;

};