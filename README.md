# 📒 Fundoo Notes - Microservices Based Notes Management Platform

A scalable and secure Notes Management Platform developed using **ASP.NET Core Microservices Architecture**. The application enables users to securely manage notes while demonstrating modern backend development concepts including **CQRS, RabbitMQ, Redis, API Gateway, JWT Authentication**, and **Clean Architecture**.

---

# 🚀 Features

- User Registration & Login
- JWT Authentication & Authorization
- Notes CRUD Operations
- Archive / Trash Notes
- Pin & Unpin Notes
- Reminder & Color Management
- Collaborator Management
- Welcome Note Creation using RabbitMQ Events
- Redis Distributed Caching
- Ocelot API Gateway
- CQRS using MediatR
- Clean Architecture
- Repository Pattern
- Dependency Injection

---

# 🏗️ Microservices Architecture

The project is developed using Microservices Architecture where each service has its own responsibility.

## Services

- User Service
- Notes Service
- Collaborator Service
- API Gateway (Ocelot)
- Shared Library

---

# 📐 Architecture Diagram

> *(Insert PlantUML Architecture Diagram Here)*

---

# 🛠️ Tech Stack

### Backend
- ASP.NET Core 8 Web API
- C#
- Entity Framework Core
- SQL Server

### Architecture
- Microservices
- Clean Architecture
- CQRS Pattern
- Repository Pattern
- Dependency Injection

### Communication
- RabbitMQ
- HttpClient

### Performance
- Redis Distributed Cache

### API Gateway
- Ocelot API Gateway

### Security
- JWT Authentication
- Authorization

### Tools
- Visual Studio 2022
- Postman
- RabbitMQ Management
- Redis
- Git & GitHub

---

# 📂 Project Structure

```
FundooNotes
│
├── ApiGateway
│
├── Services
│   ├── UserService
│   ├── NotesService
│   └── CollaboratorService
│
└── SharedLibrary
    ├── Contracts
    ├── Messaging
    └── Exceptions
```

---

# ⚙️ Design Patterns Used

- Clean Architecture
- CQRS Pattern (MediatR)
- Repository Pattern
- Dependency Injection
- Event Driven Architecture

---

# 🔄 Service Communication

## Synchronous Communication

- HttpClient
- Service-to-Service Communication
- User Validation before Notes Creation

## Asynchronous Communication

RabbitMQ is used for Event-Driven Communication.

### Event Flow

User Registration

⬇

Publish `UserRegisteredEvent`

⬇

RabbitMQ Queue

⬇

Notes Service Consumer

⬇

Automatically Create Welcome Note

---

# 🚀 API Gateway

Ocelot API Gateway is used for

- Centralized Routing
- Authentication
- Request Forwarding
- Service Abstraction

---

# ⚡ Redis Caching

Redis Distributed Cache is implemented to

- Cache Frequently Accessed Notes
- Reduce Database Queries
- Improve API Response Time

---

# 🔐 Authentication

JWT Authentication is implemented for

- User Login
- Token Generation
- Authorization
- Secure API Access

---

# 📦 RabbitMQ

RabbitMQ is used for asynchronous messaging.

Current Event

- UserRegisteredEvent

Consumer

- Automatically creates a Welcome Note after successful user registration.

---

# 📊 REST APIs

Implemented **25+ REST APIs** including

### User
- Register
- Login
- Email Verification

### Notes
- Create
- Update
- Delete
- Get
- Archive
- Trash
- Pin
- Reminder
- Color

### Collaborator
- Add Collaborator
- Remove Collaborator
- Update Collaborator

---

# 🧪 API Testing

All endpoints are tested using

- Postman

---

# 📈 Future Enhancements

- Label Microservice
- Forgot Password
- Reset Password
- xUnit Testing
- Azure Deployment
- CI/CD using Jenkins

---

# 👨‍💻 Author

**Amarnath Kolla**

B.Tech CSE (Cloud Computing)

Backend Developer | ASP.NET Core | Microservices | AWS

GitHub: *(Add your GitHub Profile)*

LinkedIn: *(Add your LinkedIn Profile)*
