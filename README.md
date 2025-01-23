# loan-management-system
Loan Management System A full-stack application for calculating loan interests based on client data using .NET Core and Angular. Includes personalized interest rates, JWT authentication, and a dynamic client list from a clients.json file.

Project Setup and Running Instructions
1.	Clone the Repository:
o	Clone this repository to your local machine using the following command:
git clone https://github.com/DimaYer-sketch/loan-management-system.git
2.	Server-Side Setup (C# .NET 8):
o	Navigate to the server-side directory (/Server).
o	Install the necessary dependencies:
dotnet restore
o	Build the project:
dotnet build
o	Run the project:
dotnet run
o	The API will be available at https://localhost:7099.
3.	Client-Side Setup (Angular):
o	Navigate to the client-side directory (/Client).
o	Install the Angular dependencies:
npm install
o	Start the Angular application:
ng serve
o	The client application will be available at http://localhost:4200.
________________________________________
About the Project:
This project includes a loan calculator API built with .NET 8, with Angular as the frontend. The API calculates loan interests based on various client scenarios (age, amount, and period). It includes JWT authentication, logging, middleware, and filters.
Data Handling: Instead of manually entering the client ID, the project uses a clients.json file located in the Data directory of the server-side project as the data source. The file contains a list of clients, which is used to populate the client dropdown in the frontend, improving the user experience. This allows the user to select a client directly from the list, avoiding the need to input an ID manually, which can be unknown or inconvenient.
The clients.json file includes the following structure:
[
  {
    "Id": 1,
    "Name": "Alice",
    "Age": 18
  },
  {
    "Id": 2,
    "Name": "Bob",
    "Age": 25
  }
]
This logic enhances the interface by providing a cleaner, more intuitive way to choose clients.
________________________________________
About the Developer:
Dmitriy Yeruchimovitch
I am an experienced Full Stack Engineer with expertise in C#, .NET Core, Angular, and database management. I have extensive experience in developing scalable solutions, mentoring teams, and optimizing performance for large-scale projects.

