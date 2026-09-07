import { Component, OnInit, inject } from '@angular/core';

import { CommonModule } from '@angular/common';

import { FormsModule } from '@angular/forms';
import { NgFor } from '@angular/common';
import { SpeakerService } from '../../../services/speaker.service';

@Component({
  selector: 'app-speaker',

  standalone: true,

  imports: [
    CommonModule,
    FormsModule
  ],

  templateUrl: './speaker.html',

  styleUrl: './speaker.css',
})
export class Speaker implements OnInit {

  private speakerService =
    inject(SpeakerService);

  speakers: any[] = [];

  speakerName = '';

  successMessage = '';

  errorMessage = '';

  ngOnInit(): void {

    this.loadSpeakers();

  }
loadSpeakers(): void {

  this.speakerService
    .getAllSpeakers()
    .subscribe({

      next: (response: any) => {

        console.log(response);

        this.speakers =
          response;

      },

      error: (err) => {

        console.log(err);

      }

    });

}

  addSpeaker(): void {

    const payload = {

      speakerName: this.speakerName

    };

    this.speakerService
      .addSpeaker(payload)
      .subscribe({

        next: () => {

          this.successMessage =
            'Speaker Added Successfully';

          this.errorMessage = '';

          this.speakerName = '';

          this.loadSpeakers();

        },

        error: () => {

          this.errorMessage =
            'Failed to add speaker';

        }

      });

  }

  deleteSpeaker(id: string): void {

    if (!confirm(
      'Delete this speaker?'
    )) {
      return;
    }

    this.speakerService
      .deleteSpeaker(id)
      .subscribe({

        next: () => {

          this.successMessage =
            'Speaker Deleted';

          this.loadSpeakers();

        },

        error: () => {

          this.errorMessage =
            'Failed to delete speaker';

        }

      });

  }

}