# Design Consideration

* I restricted myself to a limited 4 hours to accomplish the assignment. Worth mentioning, writing this file cost me an extra 15 minutes.
* I tried to achieve a flexible/readable design and I intentionally kept the source code as simple as possible.
    * I didn't create separate projects/layers, I just focused on abstraction.
    * I kept the usage of the RabbitMQ as simple as possible with a very ordinary explicit handler registration.
* Unfortunately, I had no more time to create and test using a docker-compose file to get the application up and running easier.

# How To Build

Prerequisites:
* [.NET 5](https://dotnet.microsoft.com/download/dotnet/5.0) (or later) SDK
* [RabbitMQ](https://hub.docker.com/_/rabbitmq/)

* Run the `build.cmd` script file located in the root of the repository to build, and running the tests.
* Visit the folder `.\src\Effectory.Services.Questionnaire`
* Change the connection string for rabbitmq in `appsettings.json` file to match your rabbitmq instance connection
* Run the application using `dotnet run`
* Browse to https://localhost:5001/swagger/index.html