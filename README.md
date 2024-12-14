#   <p align="center"> 🅹🅾🅱 🅵 🅸 🅽 🅳 🅴 🆁 🅰🅿🅸 🚀</p> 

JobFinderAPI is a .NET Core-based API designed for job seekers and employers. Built using the CQRS pattern, it ensures a clean separation of concerns, maintainability, and scalability. This architecture facilitates efficient job posting, application management, and applicant tracking. 🌍

The project is structured following the principles of Onion Architecture, promoting separation of concerns, maintainability, and testability. This structure ensures that the core business logic remains independent of external frameworks and technologies. 🔑


## Technologies Used 🛠️

- **.NET Core 8 🚀:** Backend framework for building APIs.
- **Entity Framework Core 🔗:** ORM for database operations.
- **SQL Server 💾:** Database for storing data.
- **Swagger 📜:** For API documentation.
- **Visual Studio 2022 💻:** IDE
- **Gmail SMTP ✉️:** For sending emails through Gmail's SMTP server.
- **JWT Authentication 🔑:** For securing API endpoints with token-based authentication.

## Design Patterns 🧩

- **CQRS (Command Query Responsibility Segregation) 🎯:** The project separates write (commands) and read (queries) operations. MediatR is used to handle both commands and queries.
- **Result Pattern 🏆:** The project standardizes operation results by wrapping success or error information in a consistent response object, making error handling and data retrieval more structured.
- **Unit of Work Pattern 🔧:** The project manages transactions and ensures that changes across multiple repositories are committed or rolled back together, maintaining data consistency.
- **Repository Pattern 📂:** The project abstracts data access by providing a clean interface for querying and persisting data
- **TPT (Table-Per-Type) Inheritance 🏷️:** The project uses TPT inheritance at the database level to handle entity inheritance. For example, SystemUser serves as the base class for different user types, with Admin, Applicant, and Employer inheriting from it. Each class has its own table in the database, ensuring clear separation of data for each type while allowing them to share common properties (like Email, PhoneNumber, etc.) defined in the base class.

## Libraries 📚

- **FluentValidation 📝:** The project uses FluentValidation for request validation, ensuring that incoming data meets specific criteria before being processed by the system.
- **MediatR ⚡:** The project utilizes MediatR to implement the CQRS pattern, handling commands and queries in a clean, decoupled manner.
- **NewtonsoftJson 🔄:** The project uses Newtonsoft.Json for JSON serialization and deserialization.
- **Entity Framework Core (EF Core) 🗄️:** The project employs EF Core as an ORM to interact with the SQL Server database, simplifying data access and CRUD operations.

## Swagger Documentation 📖

- JobFinderAPI 📝
  - [Documentation](https://app.swaggerhub.com/apis-docs/Birkan/job-finder-api/1.0 "Swagger Documentation") 📜
