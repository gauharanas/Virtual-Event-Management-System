import { Component, OnInit, inject } from '@angular/core';

import { CommonModule } from '@angular/common';

import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';

import { ActivatedRoute, Router } from '@angular/router';

import { EventService } from '../../../services/event.service';

@Component({
  selector: 'app-event-form',

  imports: [CommonModule, ReactiveFormsModule],

  templateUrl: './event-form.html',
})
export class EventForm implements OnInit {
  private fb = inject(FormBuilder);

  private eventService = inject(EventService);

  private router = inject(Router);

  private route = inject(ActivatedRoute);

  isEditMode = false;

  eventId = '';
  successMessage = '';

  eventForm = this.fb.group({
    eventName: ['', Validators.required],

    eventCategory: ['', Validators.required],

    eventDate: ['', Validators.required],

    status: ['', Validators.required],

    description: [''],
  });

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');

    if (id) {
      this.isEditMode = true;

      this.eventId = id;

      this.loadEvent(this.eventId);
    }
  }

  loadEvent(id: string): void {
    this.eventService.getEventById(id).subscribe({
      next: (response: any) => {
        const eventData = response.data;

        eventData.eventDate = eventData.eventDate.split('T')[0];

        this.eventForm.patchValue(eventData);
      },
    });
  }

  onSubmit(): void {
    if (this.eventForm.invalid) {
      return;
    }

    if (this.isEditMode) {
      this.eventService.updateEvent(this.eventId, this.eventForm.value as any).subscribe({
        next: () => {
          this.successMessage = this.isEditMode
            ? 'Event Updated Successfully'
            : 'Event Added Successfully';

          setTimeout(() => {
            this.router.navigateByUrl('/dashboard', { skipLocationChange: true }).then(() => {
              this.router.navigateByUrl('/admin/events');
            });
          }, 1500);
        },
      });
    } else {
      this.eventService.addEvent(this.eventForm.value as any).subscribe({
        next: () => {
          this.router.navigateByUrl('/dashboard', { skipLocationChange: true }).then(() => {
            this.router.navigateByUrl('/admin/events');
          });
        },
      });
    }
  }
}
