# MachiningTechHelperMVC

Web aplication for machining technologists. Components: Catalogue for storing parameters for machining tools (drills, endmills and solid endmills), simple parameters calculator and simple part cost calculator. Sections of applications are protected by user roles.

## Technologies used
* C#
* .NET 8
* ASP.NET Core
* Entity Framework Core
* SQL Server
* XUnit

## Instalation
1. Clone the repository
2. Update the `appsettings.json` file with your database connection string and authentication keys
3. Run the application

## Using The App
When the application launches it should look like this:
![Machining Tech Helper App ready to run](Screenshots/Screenshot1.png "Ready to run")

To get access to more options you need to login:
![login screen](Screenshots/Screenshot2.png "login screen")

When loged as admin role the main page should look like this:
![main page for admin](Screenshots/Screenshot3.png "main page for admin")

App includes simple calculator for machining parameters:
![simple machining calculator](Screenshots/Screenshot4.png "simple machining calculator")
![calculations results](Screenshots/Screenshot5.png "calculations results")

Another calculator included in app is machining cost calculator:
![machining cost calculator](Screenshots/Screenshot6.png "machining cost calculator")
![machining cost calculator results](Screenshots/Screenshot7.png "machining cost calculator results")

Application work with database to provide machining parameters catalogues for tools such as drills, mills and solid endmills:
![tools catalogue](Screenshots/Screenshot8.png "tools catalogue")
![tool detalis](Screenshots/Screenshot9.png "tool detalis")

