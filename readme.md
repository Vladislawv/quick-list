# QuickList

This is a small todo web-project.

Here you can manage your daily goals or sort them as you wish.

## What's inside

### Full-stack project

An ASP .NET Core full-stack application based on MVC architecture than contains all necessary endpoints and views.

## Installation

### What must be installed

- .NET 8
- Postgre SQL Server
    - Created database

### How to install and run

1) Install Docker, open cmd and run command to run the Postgre SQL Server:

- `docker run --name <your_container_name> -e POSTGRES_PASSWORD=<your_password> -p <your_port> -d postgres`


   example values:
   - `your_container_name` - `quicklist-postgre-server`
   - `your_password` - `s1mpleA!`
   - `your_port` - `5432:5432`

2) Download/Clone the solution from repository
    - If download make sure to have the solution directory unarchived


3) Open QuickList.MVC project in terminal


4) Run command:

- `dotnet user-secrets init`
- `dotnet user-secrets set "ConnectionStrings:QuickListDbConnectionString" "<your_connection_string>"`  
   
where:
    - `<your_connection_string>` - Connection String to your Postgre SQL Server database

   It's highly recommended to use the next one pattern:
   
- `Host=<your_host>;Port=<your_port>;Database=<your_database>;User Id=<your_user_id>;Password=<your_password>`

example values:
- `<your_host>` - `localhost`
- `<your_port>` - `5432`
- `<your_database>` - `postgres`
- `<your_user_id>` - `postgres`
- `<your_password>` - `s1mpleA!`


5) Be sure your database is run


6) Open QuickList.Infrastructure project in terminal and run command:

- `dotnet ef database update -s QuickList.MVC`


7) Open QuickList.MVC project in terminal again and run command:

- `dotnet run`

## What technologies were used

- .NET 8 + ASP.NET Core MVC
- Entity Framework Core
- Ajax for interface reactivity