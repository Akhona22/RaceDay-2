# RaceDay – Part 2

## Student Information

- **Name:** Akhona Lindumusa Khoza
- **Module:** PROG6212

## Project Overview

RaceDay is an ASP.NET Core Web API developed to manage race events and participant enrolments. The application allows event organisers to create and manage race events, define race categories, and capture race results. Participants can register for an account, log in, and enrol in available race events.

The project demonstrates the use of RESTful API development, database management, authentication, role-based access control, and automated testing.

## Technologies Used

- **ASP.NET Core Web API** – For building the RESTful API.
- **Entity Framework Core** – For database access and data management.
- **SQL Server** – For storing application data.
- **Swagger/OpenAPI** – For documenting and testing API endpoints.
- **xUnit** – For automated unit testing.
- **GitHub** – For source code management and version control.

## Features

### 1. Authentication

RaceDay provides authentication functionality to support user account management and access to the application.

- **User Registration:** Allows users to create an account.
- **User Login:** Allows registered users to authenticate.
- **User Logout:** Allows users to end their session.
- **Current User Session:** Provides functionality to identify the currently authenticated user.

### 2. Role-Based Access Control

The application supports different user roles, each with specific permissions and responsibilities.

#### Organiser

Organisers are responsible for managing race events and their results.

- Create race events.
- Create race categories.
- Capture race results.

#### Participant

Participants can take part in available race events.

- Enrol in race events.

### 3. Database Management

The application uses SQL Server to store information related to users, race events, categories, participant enrolments, and race results. Entity Framework Core facilitates communication between the application and the database.

### 4. API Documentation and Testing

Swagger/OpenAPI provides an interactive interface for viewing and testing the API endpoints. xUnit is used to write and execute automated tests to verify the application's functionality.

## Getting Started

### Prerequisites

Before running the application, ensure that you have installed:

- .NET SDK compatible with the project.
- SQL Server.
- Visual Studio or another compatible .NET development environment.
- Git.

### Installation and Setup

1. Clone the repository:

   ```bash
   git clone <repository-url>
   ```

2. Navigate to the project directory:

   ```bash
   cd <project-directory>
   ```

3. Configure the SQL Server connection string in the appropriate configuration file, such as `appsettings.json` or `appsettings.Development.json`.

4. Restore the project's dependencies:

   ```bash
   dotnet restore
   ```

5. Apply the Entity Framework Core database migrations, if configured:

   ```bash
   dotnet ef database update
   ```

6. Build the application:

   ```bash
   dotnet build
   ```

7. Run the application:

   ```bash
   dotnet run
   ```

### Accessing Swagger

Once the application is running, open the Swagger URL displayed in the application output. The URL typically ends with `/swagger`, depending on the project's configuration.

Swagger can be used to view available endpoints and send requests to test the API.

## Running Unit Tests

To execute the automated tests, run the following command from the solution directory:

```bash
dotnet test
```

The test results will indicate whether the tests pass or fail.

## Project Structure

The project may be organised into the following components, depending on the solution structure:

- **Controllers:** Handle incoming HTTP requests and API responses.
- **Models:** Define the application's data structures.
- **Data:** Contains database context and related database configuration.
- **Services:** Implement application logic and business rules.
- **Tests:** Contains automated tests for verifying application functionality.

## Version Control

GitHub is used to manage the project's source code and track changes throughout development.

## Demonstration Video
Video Link: https://youtu.be/cmGZhJrMRZ4
https://youtu.be/cmGZhJrMRZ4

## Conclusion

RaceDay Part 2 demonstrates the development of an ASP.NET Core Web API for managing race events, participant enrolments, race categories, and results. By combining authentication, role-based access control, Entity Framework Core, SQL Server, Swagger/OpenAPI, and xUnit testing, the project provides a foundation for a structured and maintainable race management system.

