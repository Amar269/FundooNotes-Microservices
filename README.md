># 📒 Fundoo Notes – Microservices-Based Notes Management Platform

## 📌 Project Overview

Fundoo Notes is a scalable and secure **Notes Management Platform** developed using **ASP.NET Core Microservices Architecture**.

The application provides users with a centralized platform to create, organize, and manage their notes, along with features such as authentication, collaboration, reminders, pinning, archiving, and trash management.

The project is designed using independent microservices to separate business responsibilities and improve **scalability, maintainability, service independence, and system reliability**.

The platform demonstrates modern backend development practices including **Clean Architecture, CQRS, RESTful APIs, Ocelot API Gateway, RabbitMQ, Redis Distributed Caching, JWT Authentication, Entity Framework Core, SQL Server, Docker, and SMTP-based communication**.

### 🎯 Main Objective

The primary objective of this project is to design and implement a production-oriented backend system using **Microservices Architecture**, demonstrating both synchronous and asynchronous communication between independently deployable services.

## 🏗️ Microservices Architecture

The application follows a **Microservices Architecture**, where the system is divided into independent services based on business responsibilities.

Each microservice is designed as a separate application with its own **API, Application, Domain, and Infrastructure layers**, allowing individual services to be developed, maintained, and scaled independently.

### 🔹 Core Services

- **User Service** – Handles user registration, login, authentication, and user-related operations.
- **Notes Service** – Manages note creation, retrieval, updating, deletion, reminders, pinning, archiving, and trash operations.
- **Collaborator Service** – Handles collaboration-related operations between users and notes.
- **Ocelot API Gateway** – Acts as the centralized entry point for client requests and routes them to the appropriate microservice.
- **Shared Library** – Contains shared contracts, messaging components, and common functionality used across services.

### 🔄 Communication Between Services

The microservices communicate using two approaches:

- **Synchronous communication** using `HttpClient` when an immediate response is required.
- **Asynchronous communication** using `RabbitMQ` for event-driven operations.

This separation reduces coupling between services and makes the overall system easier to maintain and extend.

### 🧱 Service Layering

Each service follows a layered structure:

```text
API
 ↓
Application
 ↓
Domain
 ↓
Infrastructure
 ↓
Database / External Services

## 🏗️ System Architecture

The system is organized around multiple independent microservices with **Ocelot API Gateway** as the entry point for client requests.

The architecture combines synchronous and asynchronous communication:

- **Ocelot** handles API routing and forwards requests to the appropriate service.
- **User, Notes, and Collaborator Services** contain their respective business functionality.
- **HttpClient** enables synchronous service-to-service communication when an immediate response is required.
- **RabbitMQ** handles asynchronous event-driven communication between services.
- **Redis** provides distributed caching for frequently accessed data.
- **SQL Server** is used for persistent relational data storage.
- **SMTP** is used for email-based communication.
- **Docker** provides containerized infrastructure for supporting components such as RabbitMQ and Redis.

The separation of services and infrastructure components allows the application to remain modular, maintainable, and scalable.
<img width="2816" height="1536" alt="arch _diagram fundoo" src="https://github.com/user-attachments/assets/dd536534-af33-446f-91ec-0431a4f8f1cf" />

## 🔄 Request Flow

A client request enters the system through the **Ocelot API Gateway**, which identifies the target route and forwards the request to the appropriate microservice.

Inside the microservice, the request passes through the API layer and is handled by the Application layer using **CQRS and MediatR**. The handler performs the required business operation through the repository and infrastructure layer, which communicates with the database or other required infrastructure components.

The processed result is then returned through the same request pipeline back to the client.

### Request Flow

```text
Client
  ↓
Ocelot API Gateway
  ↓
Microservice API
  ↓
Controller
  ↓
CQRS / MediatR
  ↓
Command / Query Handler
  ↓
Repository
  ↓
SQL Server
  ↓
Response
  ↑
API Gateway
  ↑
Client

<img width="2816" height="1536" alt="reuest flow _diagram" src="https://github.com/user-attachments/assets/7b181612-9067-4a0c-8755-6fe07b2a12f6" />

## 🔗 Service-to-Service Communication

The Fundoo Notes platform uses two communication patterns between microservices depending on whether an immediate response is required.

### 🌐 Synchronous Communication – HttpClient

`HttpClient` is used when one microservice needs an immediate response from another microservice.

For example, before creating a note, the Notes Service can communicate with the User Service to verify whether the requested user exists.

```text
Notes Service
      │
      │ HTTP Request
      ▼
User Service
      │
      ▼
User Database
      │
      │ HTTP Response
      ▼
Notes Service

<img width="2762" height="1504" alt="service communication _diagram" src="https://github.com/user-attachments/assets/58a8c7fb-453d-4d3c-90e1-7d5125be9ad7" />

## 🗄️ Database Design

The application uses **Microsoft SQL Server** as the relational database, with **Entity Framework Core** handling data access and persistence.

The database is organized around the core business entities of the platform.

### 👤 User

Stores user account and authentication information.

```text
User
├── UserId
├── FirstName
├── LastName
├── Email
└── PasswordHash

Notes
├── NotesId
├── Title
├── Description
├── Reminder
├── Colour
├── Image
├── IsArchive
├── IsPin
├── IsTrash
├── CreatedAt
├── UpdatedAt
└── UserId

Collaborator
├── CollaboratorId
├── NoteId
├── UserId
└── Collaboration-related information

User
 │
 │ 1 : N
 ▼
Notes
 │
 │
 │ N : N
 ▼
Collaborator
 ▲
 │
 │
User


<img width="2816" height="1536" alt="er diagram" src="https://github.com/user-attachments/assets/2a034e94-265c-4535-9df3-4a696d565e74" />

## 📁 Project Structure

The project is organized as a multi-service .NET solution. Each microservice follows a consistent layered structure using **API, Application, Domain, and Infrastructure** projects.

```text
FundooNotes-Microservices
│
├── 📁 ApiGateway
│   └── Ocelot API Gateway
│
├── 📁 Services
│   │
│   ├── 📁 UserService
│   │   ├── UserService.API
│   │   ├── UserService.Application
│   │   ├── UserService.Domain
│   │   └── UserService.Infrastructure
│   │
│   ├── 📁 NotesService
│   │   ├── NotesService.API
│   │   ├── NotesService.Application
│   │   ├── NotesService.Domain
│   │   └── NotesService.Infrastructure
│   │
│   ├── 📁 CollaboratorService
│   │   ├── CollaboratorService.API
│   │   ├── CollaboratorService.Application
│   │   ├── CollaboratorService.Domain
│   │   └── CollaboratorService.Infrastructure
│   │
│   └── 📁 LabelService
│       ├── LabelService.API
│       ├── LabelService.Application
│       ├── LabelService.Domain
│       └── LabelService.Infrastructure
│
├── 📁 SharedLibrary
│   ├── Contracts
│   ├── Messaging
│   └── Configuration
│
└── 📄 FundooNotes.slnx


## ✨ Application Features

### 👤 User Management
- User registration with secure password hashing
- User login with JWT-based authentication
- Authentication and authorization for protected APIs
- Email-based user communication using SMTP

### 📝 Notes Management
- Create, retrieve, update, and delete notes
- Pin and unpin notes
- Archive and restore notes
- Move notes to and manage trash
- Set reminders for notes
- Customize note colours
- Retrieve notes with user-specific access control

### 🤝 Collaboration
- Add collaborators to notes
- Remove collaborators
- Manage shared note access between users

### 📨 Event-Driven Features
- Publishes a `UserRegisteredEvent` after successful user registration
- Consumes registration events through RabbitMQ
- Automatically creates a default welcome note for newly registered users

### ⚡ Performance
- Redis distributed caching for frequently accessed note data
- Reduced repetitive database queries through cache-based retrieval

### 🚪 API Gateway
- Centralized API entry point using Ocelot
- Routes client requests to the appropriate microservice
- Provides service abstraction from the client

### 🔐 Security
- JWT-based authentication
- Password hashing using BCrypt
- Protected API endpoints through authorization



