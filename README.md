# "AdoptCare" Pet Adoption Facility CRM

### _By Alexandra Holcombe_

**ASP.NET Core Web Application for use by animal shelters and rescues.  Intended to be only accessible to registered users; app has open registration for demo purposes only.**

[AdoptCare Pet Adoption CRM on Azure](http://petadoptioncrm.azurewebsites.net/)

## Specifications
* User must login to access application
* User can add, update, or delete pets
* User can view all pets
* Application has simple, tablet-like functionality
* Application is ready to scale

### Upcoming features
* Pet can be marked as adopted
* File uploading
* Each pet has "timeline" - notes, medical updates, etc.
* User administration for facility manager
* Incorporate Identity features such as email validation and password reset
* Facility can track interested parties, foster homes, etc.

## Getting Started

### Installing
* Clone solution to local machine  
`> git clone https://github.com/alexandraholcombe/PetAdoptionCRM.git`  
* Configure database connections in `appsettings.json` and `Startup.cs`  
`kljlk`

#### If using .NET Core CLI
[.NET Core command-line interface (CLI) tools](https://docs.microsoft.com/en-us/dotnet/articles/core/tools/)  
* Apply database migrations from inside `src/PetAdoptionCRM` directory  
`> dotnet ef database update`
* Restore NuGet packages  
`> dotnet restore`  
* Build project  
`> dotnet build`  
* Compile SCSS using [WebCompiler](https://marketplace.visualstudio.com/items?itemName=MadsKristensen.WebCompiler)

#### If using Visual Studio
* Apply database migrations using Package Manager Console  
`> Update-Database`
* Restore NuGet packages by right-clicking project in Solution Explorer then selecting `Restore`
* Build project by right-clicking project in Solution Explorer then selecting `Build`
* Compile SCSS using [WebCompiler](https://marketplace.visualstudio.com/items?itemName=MadsKristensen.WebCompiler)

### Requirements
* Microsoft .NET Core Tools (Preview 2)
* (If using Visual Studio) Visual Studio 2015 Update 3

[Microsoft .NET Core 1.0.0 Release Notes](https://github.com/dotnet/core/blob/master/release-notes/1.0/1.0.0.md)  
[Release Announcement](https://blogs.msdn.microsoft.com/dotnet/2016/06/27/announcing-net-core-1-0/)

## Technologies Used
* C#
* Visual Studio 2015 Update 3
* .NET Core 1.0.0 Preview 2 003131
* Entity Framework ORM
* ASP.NET Core Identity - *membership system*
* Bower - *front-end package management*

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details

**Copyright (c) Alexandra Holcombe 2017**
