import { Injectable, inject } from '@angular/core';

import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class SessionService {
  private http = inject(HttpClient);

  private apiUrl = 'https://localhost:7247/api/v1/sessions';

  getAllSessions() {
    return this.http.get(this.apiUrl);
  }

  getSessionById(id: string) {
    return this.http.get(`${this.apiUrl}/${id}`);
  }

  getSessionsByEventId(eventId: string) {
    return this.http.get(`${this.apiUrl}/event/${eventId}`);
  }

  addSession(data: any) {
    return this.http.post(this.apiUrl, data, {
      responseType: 'text' as 'json',
    });
  }

  updateSession(data: any) {
    return this.http.put(this.apiUrl, data, {
      responseType: 'text' as 'json',
    });
  }

  deleteSession(id: string) {
    return this.http.delete(`${this.apiUrl}/${id}`, {
      responseType: 'text' as 'json',
    });
  }
}
