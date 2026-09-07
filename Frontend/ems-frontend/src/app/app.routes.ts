import { Routes } from '@angular/router';

import { Home } from './components/home/home';

import { Login } from './components/login/login';

import { Register } from './components/register/register';

import { Dashboard } from './components/dashboard/dashboard';

import { EventList } from './components/events/event-list/event-list';

import { EventForm } from './components/events/event-form/event-form';

import { SessionDetails } from './components/sessions/session-details/session-details';

import { Speaker } from './components/speakers/speaker/speaker';


import { EventDetails } from './components/events/event-details/event-details';

import { authGuard } from './guards/auth-guard';
import { SessionList } from './components/sessions/session-list/session-list';
import { SessionForm } from './components/sessions/session-form/session-form';

export const routes: Routes = [

  {
    path: '',
    redirectTo: 'home',
    pathMatch: 'full'
  },

  // Public Routes

  {
    path: 'home',
    component: Home
  },

  {
    path: 'login',
    component: Login
  },

  {
    path: 'register',
    component: Register
  },

  // Admin Routes

  {
    path: 'dashboard',
    component: Dashboard,
     canActivate: [authGuard],
  },

  {
    path: 'admin/events',
    component: EventList,
     canActivate: [authGuard]
  },

  {
    path: 'admin/events/add',
    component: EventForm,
     canActivate: [authGuard]
  },

  {
    path: 'admin/events/edit/:id',
    component: EventForm,
     canActivate: [authGuard]
  },

  // Participant Routes

  {
    path: 'participant/events',
    component: EventList,
     canActivate: [authGuard]
  },

  // Event Details

  {
    path: 'events/:id',
    component: EventDetails,
  },


  // Session Routes

  {
   path: 'admin/sessions',
  component: SessionList,
  canActivate: [authGuard]
  },

  {
    path: 'admin/sessions/add',
    component: SessionForm,
     canActivate: [authGuard]
  },

  // Speaker Routes

  {
    path: 'speakers',
    component: Speaker
  },

  // Invalid Route

  {
    path: '**',
    redirectTo: 'home'
  }
];