import { Injectable, inject } from '@angular/core';

import { HttpClient } from '@angular/common/http';

import { Observable } from 'rxjs';

import { environment } from '../../environments/environment';

import { Event } from '../models/event.model';

@Injectable({
  providedIn: 'root'
})
export class EventService {

  private http = inject(HttpClient);

  private apiUrl =
    `${environment.apiUrl}/events`;

  // Get All Events
getEvents(
  page: number = 1,
  pageSize: number = 5
): Observable<any> {

  return this.http.get(
    `${this.apiUrl}?page=${page}&pageSize=${pageSize}&t=${new Date().getTime()}`
  );

}

  // Get Event By Id

  getEventById(id: string): Observable<Event> {

    return this.http.get<Event>(
      `${this.apiUrl}/${id}`
    );

  }

  // Add Event

  addEvent(event: Event): Observable<any> {

    return this.http.post(
      this.apiUrl,
      event,
      {
        responseType: 'text'
      }
    );

  }

  // Update Event

  updateEvent(
    id: string,
    event: Event
  ): Observable<any> {

    return this.http.put(
      `${this.apiUrl}`,
      event,
      {
        responseType: 'text'
      }
    );

  }

  // Delete Event

  deleteEvent(id: string): Observable<any> {

    return this.http.delete(
      `${this.apiUrl}/${id}`,
      {
        responseType: 'text'
      }
    );

  }
}