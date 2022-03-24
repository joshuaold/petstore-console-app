### OVERVIEW

Clean Architecture was used to structure the solution with Domain Driven Design serving as an inspiration.
There are 4 layers: Petstore.ConsoleApp, Infrastructure, Core, Unit.Tests
Core is where the domain (business logic) lies
Infrastructure houses the data access layer 
Petstore.ConsoleApp is where the console app is and serves as the startup project
Unit.Tests is where unit tests can be found

### INSTRUCTIONS ON RUNNING THE APP

1. Open Terminal/CommandLine/Powershell
2. Navigate to the unit tests project by executing "cd .\petstore-console-app\Petstore\Unit.Tests"
3. Run "dotnet test"
4. Check for any errors in any of the test cases
5. If no errors are found, navigate to Petstore.ConsoleApp by executing "cd ..\Petstore.ConsoleApp"
6. Run "dotnet run"
7. Verify if the console output is as per requirement (Grouped by Category and Pets in each Category are in descending order)