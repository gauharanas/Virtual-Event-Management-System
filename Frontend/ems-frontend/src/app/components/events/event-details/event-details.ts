import { Component, OnInit, inject } from '@angular/core';

import { CommonModule } from '@angular/common';

import { ActivatedRoute } from '@angular/router';

import { EventService } from '../../../services/event.service';

import { SessionService } from '../../../services/session.service';

import { Event } from '../../../models/event.model';

import { Session } from '../../../models/session.model';

@Component({
  selector: 'app-event-details',

  imports: [CommonModule],

  templateUrl: './event-details.html',

  styleUrls: ['./event-details.css'],
})
export class EventDetails implements OnInit {
  private route = inject(ActivatedRoute);

  private eventService = inject(EventService);

  private sessionService = inject(SessionService);

  event?: Event;

  sessions: Session[] = [];

  errorMessage = '';

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    
    if (id) {
   
      this.loadEvent(id);

      this.loadSessions(id);
    }
  }

  loadEvent(id: string): void {
    this.eventService.getEventById(id).subscribe({
      next: (response: any) => {
        this.event = response.data;
        console.log(response)
      },

      error: () => {
        this.errorMessage = 'Failed to load event';
      },
    });
  }

  loadSessions(eventId: string): void {
    this.sessionService.getSessionsByEventId(eventId).subscribe({
      next: (response: any) => {
        console.log(response)
        this.sessions = response;
      },

      error: () => {
        this.errorMessage = 'Failed to load sessions';
      },
    });
  }
}
