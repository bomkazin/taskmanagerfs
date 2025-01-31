## Task Manager App

*Overview*

Task Manager is a simple CRUD (Create, Read, Update, Delete) application designed to help users efficiently manage their tasks. The application is built using ASP.NET Core for the backend and SQL Server as the database, running within a Docker container. The database is managed using Azure Data Studio, connected to a local SQL Server instance.


*Tech Stack*

Backend: ASP.NET Core
Frontend: Razor Pages
Database: SQL Server (running in Docker)
ORM: Entity Framework Core
Development Tools: Azure Data Studio / Visual Studio Code


*How It Works*

Task Management: Users can create, view, edit, and delete tasks.
Database Integration: Task data is stored in a SQL Server database running in a Docker container.
RESTful API (if applicable): The backend exposes APIs for task management.
Deployment: CI/CD pipelines in Azure DevOps ensure smooth deployment.


*Running the Project*

Prerequisites

Ensure you have the following installed on your machine:
Docker
.NET SDK (latest version)
Visual Studio / VS Code
Azure Data Studio
Setup and Run
1. Start SQL Server in Docker
docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=YourPassword123' -p 1433:1433 --name sqlserver -d mcr.microsoft.com/mssql/server:latest

2. Connect Azure Data Studio to SQL Server
Open Azure Data Studio
Connect to localhost,1433
Use username: sa, password: YourPassword123
Create a new database: TaskManager

3. Run Migrations
dotnet ef database update

4. Run the Application
dotnet run

The application will be available at the provided port number e.g (http://localhost:5000)