# Virtual Event Management System

A full-stack **Virtual Event Management System** built with **ASP.NET Core Web API** and **Angular**.

The application provides a centralized platform for managing events, participants, speakers, and event sessions, with **JWT-based authentication and authorization**.

---

## Tech Stack

<p align="center">

![C#](https://img.shields.io/badge/C%23-ASP.NET%20Core-512BD4?style=for-the-badge\&logo=csharp\&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-ASP.NET%20Core-512BD4?style=for-the-badge\&logo=dotnet\&logoColor=white)
![Angular](https://img.shields.io/badge/Angular-TypeScript-DD0031?style=for-the-badge\&logo=angular\&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL%20Server-Database-CC2927?style=for-the-badge\&logo=microsoftsqlserver\&logoColor=white)
![JWT](https://img.shields.io/badge/JWT-Authentication-000000?style=for-the-badge\&logo=jsonwebtokens\&logoColor=white)

</p>

| Layer             | Technology                       |
| ----------------- | -------------------------------- |
| Frontend          | Angular, TypeScript, HTML5, CSS3 |
| Backend           | ASP.NET Core Web API, C#         |
| Authentication    | JWT                              |
| Database          | Microsoft SQL Server             |
| ORM / Data Access | Entity Framework Core            |
| API Style         | REST                             |
| Version Control   | Git & GitHub                     |
| IDE               | Visual Studio / VS Code          |

---

## Features

### Authentication

* User registration
* User login
* JWT-based authentication
* Protected API endpoints
* Angular authentication guard
* JWT HTTP interceptor
* Role-based authorization

### Event Management

* Create events
* View events
* View event details
* Update events
* Delete events

### Participant Management

* Manage event participants
* Participant-related event operations
* Protected participant endpoints

### Speaker Management

* Manage speakers
* View speaker information
* Assign speakers to sessions/events

### Session Management

* Create sessions
* View sessions
* View session details
* Update session information
* Delete sessions
* Speaker/session association

---

# Architecture

The application follows a **frontend–API–service–database architecture**, keeping the Angular presentation layer separate from the ASP.NET Core API and business logic.

```text
┌─────────────────────────────────────────────────────────────┐
│                       Angular Frontend                      │
│                                                             │
│  Components → Services → HTTP Client → JWT Interceptor     │
│                         │                                   │
│                    Route Guards                             │
└─────────────────────────┬───────────────────────────────────┘
                          │
                          │ HTTP / REST API
                          ▼
┌─────────────────────────────────────────────────────────────┐
│                    ASP.NET Core Web API                     │
│                                                             │
│  Controllers                                                │
│      │                                                      │
│      ▼                                                      │
│  Service Interfaces                                         │
│      │                                                      │
│      ▼                                                      │
│  Business Services                                          │
│      │                                                      │
│      ▼                                                      │
│  Data Access Layer / EF Core                                │
└─────────────────────────┬───────────────────────────────────┘
                          │
                          │ SQL
                          ▼
┌─────────────────────────────────────────────────────────────┐
│                      SQL Server                             │
└─────────────────────────────────────────────────────────────┘
```

---

# Project Structure

```text
Virtual-Event-Management-System/
│
├── Backend/
│   │
│   ├── EMS.API/
│   │   ├── Controllers/
│   │   │   ├── AuthController.cs
│   │   │   ├── EventsController.cs
│   │   │   ├── ParticipantController.cs
│   │   │   ├── SessionsController.cs
│   │   │   └── SpeakersController.cs
│   │   │
│   │   ├── Middleware/
│   │   │   └── ExceptionMiddleware.cs
│   │   │
│   │   ├── Properties/
│   │   │   └── launchSettings.json
│   │   │
│   │   ├── Program.cs
│   │   ├── appsettings.json
│   │   └── EMS.API.csproj
│   │
│   ├── EMS.Services/
│   │   ├── Common/
│   │   ├── DTOs/
│   │   ├── Interfaces/
│   │   ├── Services/
│   │   └── EMS.Services.csproj
│   │
│   └── EMS.slnx
│
├── Frontend/
│   │
│   └── ems-frontend/
│       ├── src/
│       │   └── app/
│       │       ├── components/
│       │       │   ├── dashboard/
│       │       │   ├── events/
│       │       │   ├── home/
│       │       │   ├── login/
│       │       │   ├── navbar/
│       │       │   ├── register/
│       │       │   ├── sessions/
│       │       │   └── speakers/
│       │       │
│       │       ├── guards/
│       │       ├── interceptors/
│       │       ├── models/
│       │       └── services/
│       │
│       ├── public/
│       ├── angular.json
│       ├── package.json
│       └── package-lock.json
│
├── LICENSE
├── README.md
└── .gitignore
```

---

# Backend API

The backend is implemented using **ASP.NET Core Web API**.

## API Controllers

| Controller              | Responsibility                  |
| ----------------------- | ------------------------------- |
| `AuthController`        | Registration and authentication |
| `EventsController`      | Event management                |
| `ParticipantController` | Participant management          |
| `SessionsController`    | Session management              |
| `SpeakersController`    | Speaker management              |

### API Base Routes

| Resource       | Route              |
| -------------- | ------------------ |
| Authentication | `/api/auth`        |
| Events         | `/api/events`      |
| Participants   | `/api/participant` |
| Sessions       | `/api/sessions`    |
| Speakers       | `/api/speakers`    |

> Exact HTTP operations and parameters are defined in the respective controller implementations.

---

# Authentication Flow

JWT is used to secure authenticated API requests.

```text
┌──────────────┐
│    User      │
└──────┬───────┘
       │
       │ Login
       ▼
┌──────────────────────┐
│ Angular Login        │
│ Component            │
└──────────┬───────────┘
           │
           │ HTTP Request
           ▼
┌──────────────────────┐
│ ASP.NET Core API     │
│ AuthController       │
└──────────┬───────────┘
           │
           ▼
┌──────────────────────┐
│ Authentication       │
│ Service              │
└──────────┬───────────┘
           │
           │ JWT
           ▼
┌──────────────────────┐
│ Angular              │
│ Authentication       │
└──────────┬───────────┘
           │
           │ Authorization: Bearer <token>
           ▼
┌──────────────────────┐
│ Protected API        │
│ Endpoints             │
└──────────────────────┘
```

The Angular application uses:

* `auth.service.ts`
* `auth-guard.ts`
* `jwt-interceptor.ts`

to manage authentication and protected requests.

---

# Frontend

The frontend is built using Angular and follows a component/service-based structure.

### Major Angular Modules

| Area           | Components                                  |
| -------------- | ------------------------------------------- |
| Authentication | Login, Register                             |
| Events         | Event List, Event Details, Event Form       |
| Sessions       | Session List, Session Details, Session Form |
| Speakers       | Speaker                                     |
| General        | Home, Dashboard, Navbar                     |

The frontend communicates with the ASP.NET Core backend through Angular services.

---

# Backend Services

The `EMS.Services` project contains the application's service layer.

### Service Interfaces

```text
IAuthService
IEventService
IParticipantService
ISessionService
ISpeakerService
```

### Service Implementations

```text
AuthService
EventService
ParticipantService
SessionService
SpeakerService
```

DTOs are used to transfer structured request/response data between the API and application layers.

---

# Getting Started

## Prerequisites

Install the following before running the project:

* [.NET SDK](https://dotnet.microsoft.com/download)
* [Node.js](https://nodejs.org/)
* Angular CLI
* SQL Server / SQL Server LocalDB
* Git
* Visual Studio or VS Code

---

## Clone the Repository

```bash
git clone https://github.com/gauharanas/Virtual-Event-Management-System.git
```

```bash
cd Virtual-Event-Management-System
```

---

# Running the Backend

Navigate to the backend directory:

```bash
cd Backend
```

Restore dependencies:

```bash
dotnet restore
```

Run the API:

```bash
dotnet run --project EMS.API
```

The API will start using the configured ASP.NET Core development settings.

### Local Configuration

For local development, configure your connection string and JWT settings in:

```text
Backend/EMS.API/appsettings.Development.json
```

This file should remain outside source control.

---

# Running the Frontend

Open another terminal and navigate to:

```bash
cd Frontend/ems-frontend
```

Install dependencies:

```bash
npm install
```

Start the Angular development server:

```bash
ng serve
```

Open the local URL displayed by Angular.

---

# Configuration

The repository intentionally does not contain local development secrets.

Typical development configuration includes:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "your-connection-string"
  },
  "Jwt": {
    "Key": "your-development-secret",
    "Issuer": "EMS_API",
    "Audience": "EMS_CLIENT"
  }
}
```

**Never commit real passwords, database credentials, API keys, or JWT secrets to GitHub.**

---

# Development Workflow

```text
              GitHub Repository
                     │
                     ▼
             ┌───────────────┐
             │    Angular    │
             │   Frontend    │
             └───────┬───────┘
                     │
                     │ REST / HTTP
                     ▼
             ┌───────────────┐
             │ ASP.NET Core  │
             │      API      │
             └───────┬───────┘
                     │
                     ▼
             ┌───────────────┐
             │   Services    │
             │ Business Logic│
             └───────┬───────┘
                     │
                     ▼
             ┌───────────────┐
             │ SQL Server DB │
             └───────────────┘
```

---

# Security

The application incorporates:

* JWT authentication
* Authorization for protected endpoints
* Angular route guards
* JWT HTTP interceptor
* Environment-specific configuration
* Centralized exception middleware

Development secrets and local configuration files are excluded from source control.

---

# Repository

**GitHub:**
https://github.com/gauharanas/Virtual-Event-Management-System

---

# License

This project is licensed under the **MIT License**.

See the [`LICENSE`](LICENSE) file for more information.

---

# Author

### Anas Gauhar

Full Stack Developer | Java | .NET | Angular

[GitHub](https://github.com/gauharanas)
