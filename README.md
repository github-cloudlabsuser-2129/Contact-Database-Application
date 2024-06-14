# CRUD Application 2

This is a simple CRUD (Create, Read, Update, Delete) application built with ASP.NET MVC.

## Project Structure

```
.
├── App_Start/
├── bin/
├── Content/
├── Controllers/
├── CRUD application 2.csproj
├── CRUD application 2.csproj.user
├── CRUD application 2.sln
├── deploy.json
├── deploy.parameters.json
├── fonts/
├── Global.asax
├── Global.asax.cs
├── Models/
├── obj/
├── packages/
├── packages.config
├── Properties/
├── Scripts/
├── Tests/
├── Views/
├── Web.config
├── Web.Debug.config
└── Web.Release.config
```

## Key Components

- [`Global.asax.cs`](Global.asax.cs): This file contains the [`MvcApplication`](command:_github.copilot.openSymbolFromReferences?%5B%7B%22%24mid%22%3A1%2C%22path%22%3A%22%2Fc%3A%2FUsers%2Fazureuser%2Fsource%2Frepos%2Fgithub-cloudlabsuser-2129%2FContact-Database-Application%2FGlobal.asax.cs%22%2C%22scheme%22%3A%22file%22%7D%2C%7B%22line%22%3A10%2C%22character%22%3A17%7D%5D "Global.asax.cs") class which is responsible for application-level events such as [`Application_Start`](command:_github.copilot.openSymbolFromReferences?%5B%7B%22%24mid%22%3A1%2C%22path%22%3A%22%2Fc%3A%2FUsers%2Fazureuser%2Fsource%2Frepos%2Fgithub-cloudlabsuser-2129%2FContact-Database-Application%2FGlobal.asax.cs%22%2C%22scheme%22%3A%22file%22%7D%2C%7B%22line%22%3A12%2C%22character%22%3A23%7D%5D "Global.asax.cs").

- [`Controllers/`](Controllers/): This directory contains all the controllers for the application.

- [`Models/`](Models/): This directory contains all the models for the application.

- [`Views/`](Views/): This directory contains all the views for the application.

- [`Tests/`](Tests/): This directory contains all the unit tests for the application.

- [`Scripts/`](Scripts/): This directory contains all the JavaScript files for the application.

- [`deploy.json`](deploy.json): This file is an Azure Resource Manager (ARM) template for deploying the application to Azure.

## Running Tests

The tests for this application are located in the [`Tests/`](Tests/) directory. You can run these tests using a test runner that supports Xunit, such as the Visual Studio Test Explorer.

## Deployment

This application can be deployed to Azure using the provided ARM template in [`deploy.json`](deploy.json). You will need to provide the necessary parameters in [`deploy.parameters.json`](deploy.parameters.json).

## Built With

- ASP.NET MVC
- Xunit for testing
- Azure for deployment

## Authors

- [Your Name]

## License

This project is licensed under the MIT License.