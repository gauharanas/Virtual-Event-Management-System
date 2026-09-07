import { Component, inject, OnInit } from '@angular/core';

import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';

import { CommonModule } from '@angular/common';

import { Router } from '@angular/router';

import { SessionService } from '../../../services/session.service';

import { EventService } from '../../../services/event.service';

import { SpeakerService } from '../../../services/speaker.service';

import { Event } from '../../../models/event.model';

@Component({
  selector: 'app-session-form',

  standalone: true,

  imports: [CommonModule, ReactiveFormsModule],

  templateUrl: './session-form.html',
})
export class SessionForm implements OnInit {

  private eventService = inject(EventService);

  private speakerService = inject(SpeakerService);

  private fb = inject(FormBuilder);

  private sessionService = inject(SessionService);

  private router = inject(Router);

  events: Event[] = [];

  speakers: any[] = [];

  successMessage = '';

  sessionForm = this.fb.group({

    eventId: ['', Validators.required],

    speakerId: [''],

    sessionTitle: ['', Validators.required],

    description: [''],

    sessionStart: ['', Validators.required],

    sessionEnd: ['', Validators.required],

    sessionUrl: [''],
  });

  ngOnInit(): void {

    this.loadEvents();

    this.loadSpeakers();

  }

  loadEvents(): void {

    this.eventService
      .getEvents(1, 100)
      .subscribe({

        next: (response: any) => {

          this.events = response.data;

        },

        error: (err) => {

          console.log(err);

        }

      });

  }

  loadSpeakers(): void {

    this.speakerService
      .getAllSpeakers()
      .subscribe({

        next: (response: any) => {

          console.log(response);

          this.speakers = response;

        },

        error: (err) => {

          console.log(err);

        }

      });

  }

  onSubmit(): void {

    if (this.sessionForm.invalid) {

      return;

    }

    this.sessionService
      .addSession(this.sessionForm.value as any)
      .subscribe({

        next: () => {

          this.successMessage =
            'Session Added Successfully';

          setTimeout(() => {

            this.router.navigate(['/admin/sessions']);

          }, 1500);

        },

        error: (err) => {

          console.log(err);

        }

      });

  }

}