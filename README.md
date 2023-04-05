## 🍓 The Hidden Garden Api

#### By Molly Donegan, Sarah Andyshak, Erin Timlin, David Jandron, Kai Clausen, Asia Kaplanyan

#### An API specifically designed to be used in conjunction with  the HiddenGardenClient.Solution project in this resporitory

## Technologies Used

* C#
* .NET
* ASP.Net
* Entity Framework
* MySql

## Description

An API providing information entered by Hidden Garden users.  

## How To Run This Project

### Install Tools

Install the tools that are introduced in [this series of lessons on LearnHowToProgram.com](https://www.learnhowtoprogram.com/c-and-net/getting-started-with-c).

If you have not already, install the `dotnet-ef` tool by running the following command in your terminal:

```
dotnet tool install --global dotnet-ef --version 6.0.0
```

### Set Up and Run Project

1. Clone this repo.
2. Open the terminal and navigate to this project's production directory called "HiddenGarden".
3. Within the production directory "HiddenGarden", create two new files: `appsettings.json` and `appsettings.Development.json`.
4. Within `appsettings.json`, put in the following code. Make sure to replacing the `uid` and `pwd` values in the MySQL database connection string with your own username and password for MySQL.

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;database=hidden_garden_api;uid=YOUR-USER-NAME-HERE;pwd=YOUR-PASSWORD-HERE;"
  }
}
```

5. Within `appsettings.Development.json`, add the following code:

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Trace",
      "Microsoft.AspNetCore": "Information",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  }
}
```
6. Create the database using the migrations in the Hidden Garden API project. Open your shell (e.g., Terminal or GitBash) to the production directory "HiddenGarden", and run `dotnet ef database update`. You may need to run this command for each of the branches in this repo. 
    - To optionally create a migration, run the command `dotnet ef migrations add MigrationName` where `MigrationName` is your custom name for the migration in UpperCamelCase. To learn more about migrations, visit the LHTP lesson [Code First Development and Migrations](https://www.learnhowtoprogram.com/c-and-net-part-time/many-to-many-relationships/code-first-development-and-migrations).
7. Within the production directory "HiddenGarden", run `dotnet watch run --launch-profile "HiddenGarden-Production"` in the command line to start the project in production mode with a watcher. 
8. To optionally further build out this project in development mode, start the project with `dotnet watch run` in the production directory "HiddenGarden".
9. Use your program of choice to make API calls. In your API calls, use the domain _http://localhost:5000_. Keep reading to learn about all of the available endpoints.

## Testing the API Endpoints

You are welcome to test this API via [Postman](https://www.postman.com/) or [curl](https://curl.se/).

### Available Endpoints

```
GET http://localhost:5000/api/backyards/
GET http://localhost:5000/api/backyards/{id}
POST http://localhost:5000/api/backyards/
PUT http://localhost:5000/api/backyards/{id}
DELETE http://localhost:5000/api/backyards/{id}
```

Note: `{id}` is a variable and it should be replaced with the id number of the backyard you want to GET, PUT, or DELETE.

#### Optional Query String Parameters for GET Request

GET requests to `http://localhost:5000/api/backyards/` can optionally include query strings to filter or search backyards. For example:

| Parameter   | Type        |  Required    | Description |
| ----------- | ----------- | -----------  | ----------- |
| service     | String      | not required | Returns backyards with a matching service value |
| address     | String      | not required | Returns backyards with a matching address value |



The following query will return all backyards with the service "Fig Tree":

```
GET http://localhost:5000/api/backyards?breed=FigTree
```

You can include multiple query strings by separating them with an `&`:

```
GET http://localhost:5000/api/backyards?instructions=figtree&address=13704SEsalmonst,portlandor,97233
```

#### Additional Requirements for POST Request

When making a POST request to `http://localhost:5000/api/backyards/`, you need to include a **body**. Here's an example body in JSON:

```json
{
  "service": "Fig trees",
  "description": "Free fig tree fruit",
  "address": "13704 SE Salmon St, Portland OR, 97233",
  "instructions": "Pay $5, follow road signs"
}
```

#### Additional Requirements for PUT Request

When making a PUT request to `http://localhost:5000/api/backyards/{id}`, you need to include a **body** that includes the backyards's `backyardId` property. Here's an example body in JSON:

```json
{
  "backyardId": 1,
  "service": "Fig trees",
  "description": "Free fig tree fruit",
  "address": "13704 SE Salmon St, Portland OR, 97233",
  "instructions": "Pay $5, follow road signs"
}
```

And here's the PUT request we would send the previous body to:

```
http://localhost:5000/api/backyards/1
```

Notice that the value of `backyardId` needs to match the id number in the URL. In this example, they are both 1.

## Known Bugs

* No known issues.

## License
Enjoy the site!

[MIT](https://github.com/git/git-scm.com/blob/main/MIT-LICENSE.txt)

Copyright (c) 2023 Molly Donegan, Sarah Andyshak, Erin Timlin, David Jandron, Kai Clausen, Asia Kaplanyan