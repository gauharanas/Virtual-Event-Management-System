import { Injectable, inject } from '@angular/core';

import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class SpeakerService {
  private http = inject(HttpClient);

  private apiUrl = 'https://localhost:7247/api/v1/speakers';

  getAllSpeakers() {
    return this.http.get(this.apiUrl);
  }

  addSpeaker(data: any) {
    return this.http.post(this.apiUrl, data, {
      responseType: 'text' as 'json',
    });
  }

  deleteSpeaker(id: string) {
    return this.http.delete(`${this.apiUrl}/${id}`, {
      responseType: 'text' as 'json',
    });
  }
}
