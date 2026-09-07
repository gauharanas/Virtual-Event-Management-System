import { Injectable, inject } from '@angular/core';

import { HttpClient } from '@angular/common/http';

import { Observable } from 'rxjs';

import { environment } from '../../environments/environment';

import { User } from '../models/user.model';

import { jwtDecode } from 'jwt-decode';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private http = inject(HttpClient);

  private apiUrl = `${environment.apiUrl}/auth`;
  

  getUserRole(): string | null {

  const token =
    localStorage.getItem('token');

  if (!token) {

    return null;

  }

  const decoded: any =
    jwtDecode(token);

  return decoded[
    'http://schemas.microsoft.com/ws/2008/06/identity/claims/role'
  ];
}

  // Login

  login(user: User): Observable<any> {

    return this.http.post(
      `${this.apiUrl}/login`,
     user,
   
    );
  }

  // Register

  register(user: User): Observable<any> {

    return this.http.post(
      `${this.apiUrl}/register`,
    user,
    {
      responseType: 'text'
    }
    );
  }

  // Save Token

  saveToken(token: string): void {

     console.log('Saving Token:', token);
    localStorage.setItem('token', token);

  }

  // Get Token

  getToken(): string | null {

    return localStorage.getItem('token');

  }

  // Logout

  logout(): void {

    localStorage.removeItem('token');

  }

  // Check Login

  isLoggedIn(): boolean {

    return !!this.getToken();

  }
}