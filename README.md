# Community Mapping

Welcome to the application for Community Information Support Services, Community Mapping! Below is an overview of the source code to help you get started. It provides an overview of the main concepts you need to be familiar with in order to continue development. 

The application framework was developed with the assitance of model driven code application Codebots. The bot version can be seen below. 

**Bot version:** 2.6.1.0 ([Release notes are here](https://forum.codebots.com/t/c-bot-release-2-6-1-0))

----

## Contents

- [Getting started](#getting-started)
	- [Docker quick start](#docker-quick-start)
	- [Installation](#installation)
	- [Running your app](#running-your-app)
- [Customising bot-written code](#customising-bot-written-code)
- [Project features](#project-features)
	- [Server-side](#server-side)
	- [GraphQL](#graphql)
	- [REST API](#rest-api)
	- [Security](#security)
	- [Client-side - React](#client-side)
	- [Database type - POSTGRES](#database)
	- [Redis and Caching](#redis-and-caching)
	- [Export](#export)
	- [Docker deployment](#docker-deployment)
	- [Scheduled tasks](#scheduled-tasks)
	- [Emails](#emails)
	- [Auditing](#auditing)
	- [Admin CMS](#admin-cms)
	- [Design system docs](#design-system-docs)
	- [Registration](#registration)
	- [Login](#login)
	- [Theme](#theme)

	- [Amazon S3](#amazon-s3)
	- [Scheduled task storage](#scheduled-task-storage)
	- [Swagger UI](#swagger-ui)
	- [GraphiQl](#graphiql)
	- [ApiTests](#api-tests)
	- [UnitTests](#unit-tests)
	- [SeleniumTests](#selenium-tests)

----

## Getting started

### Docker quick start (best for **viewing** your application)

We generally use Docker to run applications locally since it is both quick and easy to use. The first step, is to make sure you have [Docker installed](https://docs.docker.com/get-docker/) on your computer and that the code is pulled down from Git. To start the application, use your OS start command script in the `_shortcuts` folder. Once running, it will be available at [localhost:8000](localhost:8000).

Alternatively, in the main directory of the project you can run 

```
docker-compose up -d
```

to start the project running in docker. To stop the containers, run `docker-compose down`

### Installing it locally (best for coding)

While the Docker method is the easiest way to get your application running locally, it is not necessarily the best configuration when you want to **write** code. The instructions below will run through the process of setting up your application locally, so you can start writing code.

#### Installation requirements

Before you can run your application, you will need to have the following installed on your local machine:

* [.NET 5 SDK](https://dotnet.microsoft.com/download/dotnet/5.0)
* [dotnet-ef 5](https://www.nuget.org/packages/dotnet-ef/)
* [Node.js](https://nodejs.org/en/download/)
* [Yarn](https://classic.yarnpkg.com/en/docs/install)
* [PostgreSQL](https://www.postgresql.org/download/)

#### Installation

Once the dependencies have been installed, you can install your application.

1. Install the dependencies for the client-side with by running `yarn install` from within the `clientside` directory.
2. Update your connection string to match your database configuration (see the [database](#database) section for details).
3. Create your initial migration with `dotnet ef migrations add initial` from within the `serverside/src` directory.
4. Apply your initial migration with `dotnet ef database update`, this will initialise your database schema.

> Note: these steps are not needed to run the project as they were competed at the beginning of development by the dev team APEs. However, should the project be started again from scratch these are good starting steps. 

#### Running your app

You can now start you application by running `dotnet run` in the `serverside/src/` directory. If you start the application with this command, both the server-side and the client-side will be launched.
If it runs successfully, you will be able to access your application at [localhost:5000](https://localhost:5000).

----

## Customising bot-written code

The application framework was generated using a model driven approach with the platform Codebots. The Bot writes the base code to be built upon and edited in all files and ensures that all generated code is liscenced to the user. Protected regions appear in files like below;

```
// % protected region % [Add any additional imports here] off begin

// % protected region % [Add any additional imports here] end
```
Protected regions are areas where you can write code that the bots will not touch, if the code was regenerated. To use a protected region, change the first comment to say `on` instead of `off`. However, for the purpose of future development all files can be edited external to protected regions. 

----

## Project features

### Server-side

The server-side is the back-end of your application. It handles the majority of the data processing as well as other tasks such as user management, security and control. The server-side can also be used to integrate with third party API's.

The server side uses `ASP.Net Core`. ASP.NET is an open source web framework which is free for everyone to use. 

There are several maintenance tasks a developer will need to use when building their applications. One such task is maintaining your local database, this is managed through the [dotnet entity framework CLI tool](https://docs.microsoft.com/en-us/ef/core/miscellaneous/cli/dotnet). You can run this tool in the root of your web server project (`/serverside/src`) using your command line.

If you need to drop your local database at any point you can run the following command.

```shell
dotnet ef database drop
```

If you are setting up your project for the first time, or have created made some model changes you can use the following two commands to first create a migration for your local database and then apply the migration updates.

```shell
dotnet ef migrations add <MigrationName>
dotnet ef database update
```

### GraphQL

With GraphQL enabled, you get a fully functional and extensible GraphQL CRUD API based on the entities Regional Area, Service and Service Commissioning Body. This API allows you to Create, Read, Update and Delete data for all entities, based on the security defined for each entity. The API is a fully functioning API that makes the application's data available to other applications

There is a GraphQl controller found in the `/serverside/src/Controllers/GraphQlController.cs` file. This is the entry point for all GraphQl requests.

The GraphQL schema can be found at `/serverside/src/Graphql/Schema.cs`. This contains all the resolve functions for the GraphQl service.

### REST API

The REST API controllers provide additional functionality for interacting with the server of your application using CRUD (create, read, update, delete) operations. Similar to the GraphQL API, the REST API is also a popular choice for creating a fully functioning API that makes the application's data available to other applications.

The [Export](#export) functionality makes use of the REST API to assist with the exporting process.

Entity Controllers can be found at `serverside/src/Controllers/Entities` and can be called from the client-side using [Axios](https://github.com/axios/axios).

### Security

Security is configured through the ACL (Access Control List) files found in the `serverside/src/Security/Acl` folder. If you want to adjust security permissions you can can configure them in the appropriate file.

The naming convention is `{UserType}{EntityType}.cs`.

The client-side security is also configured through ACL's. These are found in `clientiside/src/models/security/acl`. The naming convention and configuration in these files mirrors the server-side. These ACLs primarily control access to routes, and data cannot be retrieved from the server unless the server-side ACLs allow for it.

### Client-side

The client-side comes bundled as a separate React application that can be found under the `clientside` directory. Acting as the interaction layer (front-end), it is responsible for displaying information to users and for sending any information they submit back to the server for processing.

The [SECURITY](./SECURITY.md) document is supplied to provide a guidance on the security considerations of your application.

#### Components

The client-side comes with a collection of pre-built UI components that you can use to further build out the application. You can use small components like buttons, or larger components like modals, to save yourself time and effort. The included elements all have a consistent structure and are easy to style. These components were also designed with accessibility in mind, so when used, many features required to make your site accessible are already done for you.

### Database

The application has been configured to use a POSTGRES database.

PostgreSQL is an open source Relational Database Management System. PostgreSQL can be integrated with many programming languages, including C#, and it is compatible with all operating systems. Compared to other database types it supports multiple features by default that are either not supported or require a third party plugin to enable. As a result, it is the best choice for a database which is expected to have a high number of concurrent users.

You can configure your database connection by going to `serverside/src/appsettings.Development.xml` and changing the line:

`<DbConnectionString>Server=localhost;Database=Cis;Username=postgres;Password=pass;</DbConnectionString>`

### Redis and Caching

For caching data, your application is configured to use a [Redis](https://redis.io/) database.

Redis is a high performance key value store capable of quickly storing and retrieving data. Redis is used  for caching and storing Hangfire jobs if there is a Redis instance configured. If there is no Redis instance, then the application will fall back to in memory caching. In a production environment, it is strongly recommended to configure a Redis instance, so the cache is persistent and can be shared across application instances.

To configure your Redis connection string, you need to update the `RedisConnectionString` property in `appsettings.xml` to point to your Redis instance. The default configuration (shown below) points to a Redis instance running on `localhost`.

```xml
<RedisConnectionString>localhost</RedisConnectionString>
```

### Export

Export allows you to export selected entity records from a Data Table component into a downloadable CSV file. The Export button will be displayed whenever any records are selected in a Data Table. Clicking the button will create a CSV file containing all the selected records, which can then be downloaded from the browser.

### Docker deployment

Your application comes with a Docker file for deployment purposes.

> If you haven't already installed Docker, go to [Get Docker](https://docs.docker.com/get-docker/) for details on downloading and installing Docker onto your local environment.

To prepare an image to deploy, navigate to the root of your project and run the following command:

```shell
docker build -t Cis:1.0.0 .
```

Once this build has completed, you should be able to run your image. Update your environment variables found in `docker.env`, then run your image using `docker run`. See an example below.

```shell
docker run --env-file ./docker.env --publish 80:80 Cis:1.0.0
```

> For more details on building Docker images see the [docker build documentation](https://docs.docker.com/engine/reference/commandline/build/).
> For more details on what options can be configured when running, see the [Docker run reference](https://docs.docker.com/engine/reference/run/).

Most major hosting providers will have first party support for docker containers; review your provider's documentation for details on deploying your application into their infrastructure. The common ones are listed below:

- [Amazon Web Services](https://aws.amazon.com/getting-started/hands-on/deploy-docker-containers/)
- [Google Cloud](https://cloud.google.com/kubernetes-engine/docs/tutorials/hello-app)
- [Azure](https://docs.microsoft.com/en-us/learn/modules/deploy-run-container-app-service/)

### Scheduled tasks

Create and manage background tasks within your application with [Hangfire](https://www.hangfire.io/).

You can access the Hangfire dashboard in your target application by going to `/api/hangfire`. Here, you can view all the tasks managed by Hangfire. Scheduled tasks can be configured in the code by adding the following `Schedular` configuration into `appsettings.xml`.

```xml
<Scheduler>
	<DisableTaskRunner>true</DisableTaskRunner>
	<DisableDashboard>false</DisableDashboard>
</Scheduler>
```

> These properties are already configured for the test profile by default.

#### Scheduled task storage

For the persistence and multi node processing of scheduled tasks, Hangfire requires that it's job queue is stored in a centralised location. If there is a [Redis database](#redis-and-caching) configured, then the application will use that for the storage. Otherwise, it will default to the main application database.

> For more details on the integration, please see [Hangfire.Redis.StackExchange](https://github.com/marcoCasamento/Hangfire.Redis.StackExchange) and [Hangfire.EntityFrameworkCore](https://github.com/sergezhigunov/Hangfire.EntityFrameworkCore).

### Emails

Your project comes with SMTP email support. This means that you can send emails using the Email Service.

User management utilises this service for account related emails for registration and password reset.

To configure the email service, you need to set your SMTP settings in `appsettings.xml`.

```xml
<EmailAccount>
	<Host>HOST@EXAMPLE.COM</Host>
	<Username>EMAIL_SERVER_USERNAME</Username>
	<Password>EMAIL_SERVER_PASSWORD</Password>
	<FromAddress>MAIL@EXAMPLE.COM</FromAddress>
	<FromAddressDisplayName>NOREPLY@EXAMPLE.COM</FromAddressDisplayName>
	<Port>25</Port>
	<EnableSsl>true</EnableSsl>
	<RedirectToAddress></RedirectToAddress>
	<BypassCertificateValidation>false</BypassCertificateValidation>
	<SaveToLocalFile>false</SaveToLocalFile>
</EmailAccount>
```

### Auditing

Auditing has been enabled for your application. All CRUD (create, read, update and delete) events are logged directly to the system logger with mutation events (create, update and delete) being logged using [Audit.Net](https://github.com/thepirat000/Audit.NET). Read audits are handled separately but are also redirected to the system logger.

### Admin CMS

The admin section of your application allows users with administrator access to access the backend of the application. This includes data management tables for every entity in the application.  This ensures that even if an entity is not directly manageable in the application's front-end, the data can still be handled by admin users. The following additional services are also included:

* Data tables for user management

To access the admin section of the application, you can either click the button in the top bar or navigate to the `/admin` route directly. Both of these options will only be available when the user is logged in and they have been granted administrator access, otherwise the top bar won't be shown, and any attempt to access the route directly will redirect to the 403 page.

### Design system docs

The Style Guide is a page in the admin section which details all of the UI components supported in your application. The Style Guide shows you the code which you can use to implement or manipulate a component, along with all of the options available to be worked with. It can also be used to test new styles and how they effect each component.

You can see and interact with it at `/admin/styleguide`. The code which runs it can be found at `clientside/src/Views/Pages/Admin/StyleguidePage.tsx`.

### Registration

This project has user registration enabled.

Registration uses the [Email service](#emails) to send registration confirmation emails using the template found at `serverside\src\Assets\Emails\RegisterEmail.template.html`.

#### Registration API

Registration adds API registration endpoints (at `/api/register`) which are managed by the `RegisterController` (found at `serverside\src\Controllers\RegisterController.cs`). Each entity which has the User extension will get their own registration endpoint (i.e for a user type _Admin_ an endpoint will exist at `/api/register/admin-entity`).

For more details, look at the `RegisterController` file. Alternatively, given your project comes bundled with the [Swagger UI](#swagger-ui), you can also use Swagger to explore your registration endpoints.
#### Registration form

In addition to your API, your project also has a registration form that can be accessed either from the [Login](#login) page or from `/register`. This enables visitors to register themselves for accounts with the system.

The page exists in the `RegistrationPage` component found at `clientside\src\Views\Pages\RegistrationPage.tsx`.

### Login

The Login functionality allows your users to be authenticated when accessing the application, and lets you make use of the Security diagram to grant different permissions to different user types.

The login page code can be found at `clientside\src\Views\Pages\LoginPage.tsx` and accessed at `/login`.

The login feature will also include functionality for resetting passwords. The password reset page code can be found at `clientside\src\Views\Pages\ResetPasswordRequestPage.tsx` and accessed at `/reset-password`.

This feature integrates with the [email](#email) service to send password reset emails using the template found at `serverside\src\Assets\Emails\ResetPassword.template.html`.

### Theme

The styling of the application is implemented using [Sass](https://sass-lang.com/), a CSS pre-processor which makes it easier to work with the code. Your project uses a plain theme, which is designed to be neutral to allow for easier SCSS customisations. 

### Amazon S3

The Amazon S3 storage provider is available to be used within this project for uploading and retrieving files.

You can confiure S3 by going to `appsettings.xml` (or `appsettings.Development.xml` if in dev environment) and adding in the configuration options shown below.

```xml
<StorageProvider>
	<Provider>S3</Provider>
</StorageProvider>
<S3StorageProvider>
	<AccessKey></AccessKey>
	<SecretKey></SecretKey>
	<RegionEndpoint></RegionEndpoint>
	<BucketName></BucketName>
</S3StorageProvider>
```

The settings from `appsettings.xml` map to the class `serverside/src/Configuration/S3StorageProviderConfiguration.cs`. You can view this class directly to see more about the options.

### Swagger UI

[Swagger](https://swagger.io/) is a technology for documenting OpenAPI compliant REST API's. This tool creates fully-fledged documentation about the API, including available endpoints and actions you can take against them.

The Swagger docs can be accessed by launching your application and going to `/api/swagger/index.html`.

### GraphiQL

[GraphiQL](https://github.com/graphql/graphiql) is a GraphQL IDE built into the client-side of your application, used for executing GraphQL queries and accessing GraphQL schema documentation. You can access GraphiQL by launching your application and going to `/admin/graphiql`.

### API Tests

API tests can be used to test the API's in your application.

Tests for the  GraphQL and REST API endpoints were automatically written by the Bot, and custom tests are based on this framework. 

To run the API tests in your server-side, navigate to the `testtarget` directory within your project and run the following command:

```shell
dotnet test .\APITests.csproj
```

> All server-side tests can be run with `dotnet test`.

### Unit Tests

Unit Testing test suites are useful for verifying that the application is working as intended. They are powerful tools often used in development practices, most notably in test driven development (TDD).

To run the Unit tests included in your server-side, navigate to the `testtarget` directory within your project and run the following command:

```shell
dotnet test .\ServersideTests.csproj
```

> All server-side tests can be run with `dotnet test`.

A client-side unit testing suite has been created for you to test the features and components of your client-side.

To run your client-side tests, navigate to the `clientside` directory and run the following:

```shell
yarn run test
```

> This requires your application to have previously been installed. See [Client-side](#client-side) for details.

### Selenium Tests

Selenium allows you to create web browser automation tests to check that your application is functioning as expected from end to end. They utilise a behaviour driven development tool (BDD) called [SpecFlow](https://docs.specflow.org/en/latest/) for test definitions and Selenium for the web browser automation.

They are stored in `testtarget\Selenium`. To run the Selenium tests included in your server-side, navigate to the `testtarget` directory within your project and run the following command:

```shell
dotnet test .\Selenium.csproj
```

> All server-side tests can be run with `dotnet test`.

