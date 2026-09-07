import {
  Component,
  OnInit,
  inject
} from '@angular/core';

import { CommonModule } from '@angular/common';

import { RouterLink } from '@angular/router';

import { EventService } from '../../../services/event.service';

import { Event } from '../../../models/event.model';

@Component({
  selector: 'app-event-list',

  imports: [
    CommonModule,
    RouterLink
  ],

  templateUrl: './event-list.html'
})
export class EventList implements OnInit {

  private eventService =
    inject(EventService);

  events: Event[] = [];

  hasNextPage = true;

  isLoading = false;

  currentPage = 1;

  pageSize = 5;

  errorMessage = '';

  ngOnInit(): void {

    this.loadEvents();

  }
loadEvents(): void {

   this.isLoading = true;

  this.eventService
    .getEvents(
      this.currentPage,
      this.pageSize
    )
    .subscribe({

      next: (response: any) => {

        this.events = response.data;

        this.hasNextPage =
          response.data.length ===
          this.pageSize;

        this.isLoading = false;

      },

      error: () => {

        this.errorMessage =
          'Failed to load events';

        this.isLoading = false;

      }

    });
}

  deleteEvent(id: string): void {

    if (!confirm('Delete this event?')) {

      return;

    }

    this.eventService
      .deleteEvent(id)
      .subscribe({

        next: () => {

          this.loadEvents();

        }

      });
  }

  nextPage(): void {

  if (!this.hasNextPage) {

    return;

  }

  this.currentPage++;

  this.loadEvents();

}

previousPage(): void {

  if (this.currentPage > 1) {

    this.currentPage--;

    this.loadEvents();

  }
}
}