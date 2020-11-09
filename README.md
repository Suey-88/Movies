# phonebookapp
A small movies project to demonstrate .net core 3 with angular 8 and entity framework core
ASP.NET Core 3.0 or later great features in Single Page Apps (SPAs) 

## Getting Started
Use these instructions to get the project up and running.

### Prerequisites
You will need the following tools:

* [Visual Studio Code or Visual Studio 2019 Preview](https://visualstudio.microsoft.com/vs/preview/)
* [.NET Core SDK 3](https://dotnet.microsoft.com/download/dotnet-core/3.0)
* [Node.js](https://nodejs.org/en/) (version 10 or later) with npm (version 6.9.0 or later)
* [Yarn](https://yarnpkg.com/en/docs/install#windows-stable) (latest version)

 ### Setup
Follow these steps to get your development environment set up:

  1. Clone the repository
  2. Go to ClientApp folder in the .Web project and run Yarn to restore node modules
  Using vs code (Not tested)
  3. Update connection string in appsettings.json to your local sql server if necessary 
	 ("PhoneBookDb": "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PhoneBookDb;Integrated Security=True")
  Using Visual Studio (Use this option)
  5. Launch the project using:
	 ```
	 run a rebuild 
	 go to package manager console select the model project and run
	 update-database -verbose (migration has already been run)
	 run the project 
	 ```
  6. Browser will open with web app [https://localhost:44395/](https://localhost:44395/) for the Web UI
  7. Navigate to here for the Swagger UI (https://localhost:44395/swagger/index.html)

## Technologies
* ASP.NET Core 3 
* Entity Framework Core 3 
* Angular 8
* Swagger by SmartBear 

