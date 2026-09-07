import {
  Component,
  OnInit,
  inject
} from '@angular/core';

import { CommonModule } from '@angular/common';

import { RouterLink } from '@angular/router';

import { EventService } from '../../services/event.service';

import { Event } from '../../models/event.model';

@Component({
  selector: 'app-home',

  imports: [
    CommonModule,
    RouterLink
  ],

  templateUrl: './home.html'
})
export class Home implements OnInit {

  private eventService =
    inject(EventService);

  events: Event[] = [];

  ngOnInit(): void {

    this.loadEvents();

  }

  loadEvents(): void {

    this.eventService
      .getEvents()
      .subscribe({

        next: (response: any) => {

          this.events = response.data;

        }

      });
  }
}