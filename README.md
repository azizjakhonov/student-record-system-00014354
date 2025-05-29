# Student Record System – Web Application Development Coursework

This GitHub repository contains the full-stack web application created for the Web Application Development coursework for the module 5COSC017C.

## 📚 Project Overview

The project is a Student Record Management System developed as part of the coursework. It allows managing students, courses, and enrolling students into specific courses.

The backend is built using **ASP.NET Core Web API**, and the frontend is created using **Angular**. The application follows clean architecture principles and includes full CRUD functionality.

---

## 🧩 Main Features

- Add, update, and delete students
- Add, update, and delete courses
- Assign students to courses
- View all enrolled courses for each student
- Swagger interface for testing the API
- Angular SPA with Bootstrap styling
- Uses Repository Pattern for better code structure

---

## 🧰 Technologies Used

**Backend:**
- ASP.NET Core 8
- Entity Framework Core
- SQL Server (LocalDB)
- Swagger

**Frontend:**
- Angular 17
- Bootstrap 5
- TypeScript, RxJS

**Tools:**
- Visual Studio 2022
- Visual Studio Code
- Git + GitHub

---

## ⚙️ How to Run the Project

### Backend (ASP.NET Core)

1. Open the solution in Visual Studio.
2. Run the following commands:

```bash
dotnet restore
dotnet ef database update
dotnet run
