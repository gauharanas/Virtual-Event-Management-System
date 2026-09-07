\# Virtual Event Management System



A full-stack event management application built with \*\*ASP.NET Core Web API\*\* and \*\*Angular\*\*. The system provides authentication, event management, participant management, speaker assignment, and session management through a structured REST API and modern web interface.



\## Features



\### Authentication \& Authorization



\* User registration and login

\* JWT-based authentication

\* Role-based authorization

\* Protected API endpoints

\* JWT interceptor on the Angular frontend



\### Event Management



\* Create and manage events

\* View event details

\* Update event information

\* Delete events

\* Event listing and details pages



\### Participant Management



\* Manage event participants

\* Register participants for events

\* View participant-related information



\### Speaker Management



\* Manage speakers

\* Assign speakers to events/sessions

\* View speaker information



\### Session Management



\* Create and manage event sessions

\* View session details

\* Associate sessions with speakers/events



\### Frontend



\* Angular-based single-page application

\* Component-based architecture

\* Angular routing

\* Route guards

\* HTTP services for API communication

\* JWT authentication interceptor

\* Responsive user interface



\## Tech Stack



\### Backend



\* \*\*ASP.NET Core Web API\*\*

\* \*\*C#\*\*

\* \*\*.NET\*\*

\* RESTful APIs

\* JWT Authentication

\* Middleware

\* Service-based architecture



\### Frontend



\* \*\*Angular\*\*

\* TypeScript

\* HTML5

\* CSS3

\* Angular Router

\* Angular HTTP Client



\### Database



\* \*\*Microsoft SQL Server\*\*

\* Entity Framework Core



\### Development Tools



\* Visual Studio

\* Visual Studio Code

\* Git

\* GitHub



\## Project Structure



```text

Virtual-Event-Management-System/

│

├── Backend/

│   ├── EMS.API/

│   │   ├── Controllers/

│   │   ├── Middleware/

│   │   ├── Properties/

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

│   └── ems-frontend/

│       ├── src/

│       │   └── app/

│       │       ├── components/

│       │       ├── guards/

│       │       ├── interceptors/

│       │       ├── models/

│       │       └── services/

│       ├── public/

│       ├── angular.json

│       ├── package.json

│       └── package-lock.json

│

├── LICENSE

├── README.md

└── .gitignore

```



\## Backend API



The backend follows a layered structure separating API controllers, service interfaces, DTOs, and business logic.



\### Controllers



The API currently includes controllers for:



\* Authentication

\* Events

\* Participants

\* Sessions

\* Speakers



Example API routes include:



```text

/api/auth

/api/events

/api/participants

/api/sessions

/api/speakers

```



\## Authentication



The application uses \*\*JWT (JSON Web Token)\*\* authentication.



The general authentication flow is:



```text

User

&#x20; │

&#x20; ▼

Angular Login

&#x20; │

&#x20; ▼

ASP.NET Core API

&#x20; │

&#x20; ▼

Authentication Service

&#x20; │

&#x20; ▼

JWT Token

&#x20; │

&#x20; ▼

Angular Token Storage

&#x20; │

&#x20; ▼

JWT Interceptor

&#x20; │

&#x20; ▼

Authenticated API Requests

```



Protected routes are handled through Angular route guards and authenticated API requests include the JWT through the HTTP interceptor.



\## Getting Started



\### Prerequisites



Make sure the following are installed:



\* .NET SDK

\* Node.js

\* npm

\* Angular CLI

\* SQL Server or SQL Server LocalDB

\* Visual Studio or Visual Studio Code

\* Git



\### Clone the Repository



```bash

git clone https://github.com/gauharanas/Virtual-Event-Management-System.git

```



Navigate into the project:



```bash

cd Virtual-Event-Management-System

```



\## Running the Backend



Navigate to the backend:



```bash

cd Backend

```



Restore the .NET dependencies:



```bash

dotnet restore

```



Run the API:



```bash

dotnet run --project EMS.API

```



The API will start using the configured ASP.NET Core development settings.



\### Configuration



For local development, configure the database connection string and JWT settings in:



```text

Backend/EMS.API/appsettings.Development.json

```



Do \*\*not\*\* commit production credentials, database passwords, or JWT secrets to GitHub.



\## Running the Frontend



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



Then open the URL shown by Angular in your browser.



\## Development Workflow



```text

Frontend

&#x20;  │

&#x20;  │ HTTP Requests

&#x20;  ▼

Angular Services

&#x20;  │

&#x20;  ▼

ASP.NET Core Web API

&#x20;  │

&#x20;  ▼

Controllers

&#x20;  │

&#x20;  ▼

Services

&#x20;  │

&#x20;  ▼

Database

```



\## Security



The project uses several security mechanisms including:



\* JWT authentication

\* Authorization for protected endpoints

\* Password authentication

\* Angular route guards

\* JWT HTTP interceptor

\* Environment-specific application configuration



Sensitive configuration should always remain outside source control.



\## Testing



The repository contains application source code for the backend and frontend.



The `EMS.Tests` project is intentionally excluded from the GitHub repository.



\## Future Improvements



Potential future enhancements include:



\* Event registration workflow

\* Email notifications

\* Event reminders

\* Online event/live meeting integration

\* Advanced search and filtering

\* Pagination

\* Admin dashboard

\* Event analytics

\* Cloud deployment

\* Automated CI/CD pipeline

\* Comprehensive unit and integration testing



\## License



This project is licensed under the \*\*MIT License\*\*. See the \[LICENSE](LICENSE) file for details.



\## Author



\*\*Anas Gauhar\*\*



GitHub: https://github.com/gauharanas



