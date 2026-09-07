import {
  Component,
  OnInit,
  inject
} from '@angular/core';

import { CommonModule }
from '@angular/common';

import {
  RouterLink
}
from '@angular/router';

import {
  SessionService
}
from '../../../services/session.service';

@Component({
  selector: 'app-session-list',

  standalone: true,

  imports: [
    CommonModule,
    RouterLink
  ],

  templateUrl: './session-list.html'
})
export class SessionList implements OnInit {

  private sessionService =
    inject(SessionService);

  sessions: any[] = [];

  errorMessage = '';

  ngOnInit(): void {

    this.loadSessions();

  }

  loadSessions(): void {

    this.sessionService
      .getAllSessions()
      .subscribe({

        next: (response: any) => {

          console.log(response);

          this.sessions =
            response.data;

        },

        error: (err) => {

          console.log(err);

          this.errorMessage =
            'Failed to load sessions';

        }

      });

  }

  deleteSession(id: string): void {

    if (!confirm(
      'Delete session?'
    )) {

      return;

    }

    this.sessionService
      .deleteSession(id)
      .subscribe({

        next: () => {

          alert(
            'Session Deleted Successfully'
          );

          this.loadSessions();

        },

        error: (err) => {

          console.log(err);

        }

      });

  }

}