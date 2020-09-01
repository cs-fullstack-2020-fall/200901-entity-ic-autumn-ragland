# 20 09 01 Entity Practice

#### Database Set Up
- create an MCV application called Practice using the .NET CLI
- add the required Entity Framework packages
```
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
```
- create a gamer model with properties id, name, age, and hoursPlayed
- create a gamer database context 
	- this dbcontext extends the base class DbContext imported from `Microsoft.EntityFrameworkCore`
	- the class constructor extends the base constructor passing options 
	- this class has one property gamers of type DbSet<ModelToReference>
- update the `appsettings.json` file to include a Connection Strings property
- update the `Startup.cs` file to include reference to created database context and connection string in the `ConfigurationSrevices` method
- add and apply migrations for initial creation
```
dotnet ef migrations add uniqueMigrationMessage
dotnet ef database update
```

#### CRUD Functionality
- create a gamer controller
- define one private readonly class property called `_context` and set the value of that property in the class constructor 
- Read All - GET
	- return a view displaying id, name and age of each gamer in the browser
	- if the gamer has played more than 500 hours display the text "Wow! This gamer has played over 500 hours" as well
- Create - POST
	- post method to add gamer to the database
	- return a view displaying id, name and age of each gamer in the browser
	- if the gamer has played more than 500 hours display the text "Wow! This gamer has played over 500 hours" as well
- Update - PUT
	- put method to update the `hoursPlayed` property of a gamer by ID
	- if a gamer can not be found by ID return the text "Gamer Not Found"
	- if a gamer can be found return a view displaying id, name and age of each gamer in the browser
	- if the gamer has played more than 500 hours display the text "Wow! This gamer has played over 500 hours" as well
- Delete - DELETE
	- delete method to delete a gamer from the database by ID
	- if a gamer can not be found by ID return the text "Gamer Not Found"
	- if a gamer can be found return a view displaying id, name and age of each gamer in the browser
	- if the gamer has played more than 500 hours display the text "Wow! This gamer has played over 500 hours" as well
 