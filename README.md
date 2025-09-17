# Recipe Bazaar

A full-stack demo application to explore React 18+ frontend with .NET 9 backend integration.  
This project focuses on building a **scalable, component-driven UI** with React while connecting to a .NET API for data persistence.  
The frontend is a **Single Page Application (SPA)**.

---

## Overview

Recipe Bazaar is a fully functional recipe application that demonstrates:

- **Component-Driven Frontend Architecture**: Build reusable, maintainable React components with TypeScript  
- **Single Page Application (SPA)**: Smooth, client-side navigation with React Router  
- **Full-Stack Integration**: Connect React frontend to a .NET 9 backend API  
- **UI Testing**: Includes both component and end-to-end tests using Cypress  
- **Dockerized Backend**: Run the API in a Docker container for easy setup  
- **Database Persistence**: Uses SQLite by default, easily switchable to SQL Server  


---

## Features

- Dynamic recipe list fetched from the API  
- Detailed recipe view with instructions and image  
- Comment section for user feedback  
- Responsive, mobile-first UI  
- Five users, multiple categories, and sample recipes with comments  
- Easily extendable for CRUD operations (Delete is pending)  
- SPA navigation with no page reloads  

---

## Tech Stack

- **Frontend**: React 19, TypeScript, React Router, Bootstrap, CSS, Flexbox  
- **Backend**: .NET 9 API with Entity Framework Core and SQLite (or SQL Server)  
- **Testing**: Cypress for E2E and component tests  
- **Containerization**: Docker + Docker Compose  

---

## Project Structure

```text
RecipeBazaar/
│
├─ app/                        # React frontend
│  ├─ src/
│  ├─ tests/
│  ├─ cypress/
│  ├─ package.json
│
├─ RecipeMaster/               # .NET 9 backend API
│  ├─ RecipeMaster.Api/
│  ├─ RecipeMaster.Domain/
│  ├─ RecipeMaster.Application/
│  ├─ RecipeMaster.Infrastructure/
│  ├─ Dockerfile
│  ├─ docker-compose.yml
│
├─ tests/                      # Cypress tests
│  ├─ components/
│  ├─ e2e/
│
└─ README.md
```
---

### Prerequisites

- **Frontend**: **Node.js 22+** 
- **Backend**: **Docker & Docker Compose**


### Backend Setup
* cd RecipeMaster
* docker-compose up --build
    * API available at: http://localhost:4005/swagger or https://localhost:4004
    * The .http file is pre-configured with a host variable for easy environment switching.
    * SQLite database persists in sqlite_data Docker volume.
    * To switch to SQL Server, update DI (startup.cs) and connection string in appsettings.json.

### Frontend Setup

```bash
* cd app
* npm install
* npm run dev
```
---

### UI Testing
#### Component Tests
    * npx cypress open --component 
    * npx cypress run --component

#### End-to-End Tests
    * npx cypress open --e2e
    * npx cypress run --e2e


---

#### Screenshots
- [Home Page](screenshots/home.png)
- [Detail page](screenshots/detail.png)
- [About Page](screenshots/about.png)
- [UI tests - component](screenshots/component.png)
- [UI tests - e2e](screenshots/e2e.png)
