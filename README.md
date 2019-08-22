# Online University
Online University is a sample application build using 
* Asp.Net Core 3.0,
* Domain Driving Design
* CQRS and Event sourcing.
* RabbitMQ,
* Redis,
* MediatR

The architecture and design of the project is explained below


## Prerequisites
You will need the following tools:

* [Visual Studio Code or Visual Studio 2019](https://visualstudio.microsoft.com/vs/) (version 16.3 or later)
* [.NET Core SDK 3](https://dotnet.microsoft.com/download/dotnet-core/3.0)


## Setup
Follow these steps to get your development environment set up:

## To Make Ready Web API
* At the `OnlineUniversity/src/OnlineUniversity.Web` directory, restore required packages by running:
 
     ```
     dotnet restore
     ```
	 
* Next, build the solution by running:
 
     ```
     dotnet build
     ```	 
	 
* Launch the Web API by running:
 
     ```
     dotnet run
     ```	 
	 
* It should be hosted at http://localhost:5000 and http://localhost:5001. 

### Run Unit Tests

1. To run tests go to each following directories
	
	`OnlineUniversity/src/OnlineUniversity.Application.UnitTests`
	`OnlineUniversity/src/OnlineUniversity.Domain.UnitTests`
	`OnlineUniversity/src/OnlineUniversity.Infrastructure.UnitTests`

	then execute the line code blow. 

	 ```
	 dotnet test
	 ```

### Architectural overview (knowledge of distributed services, cloud platforms)

![Image of Layers](https://github.com/musaalp/Online-University/blob/master/assets/ddd-layers.png)

Application mainly consist of 4 layers. 
* **Presentation Layer** : Responsible to communication with clients.
* **Application Layer** : An application service acts as a facade through which clients will interact with the domain model.
* **Domain Layer** : Basically where all the business rules live. It doesn’t know any other layer, therefore, has no dependencies, and is the easier to test.
* **Infrastructure Layer** : Responsible for every communication with external systems such as Redis, RabbitMQ, Quartz etc..

### Explanation of solutions for both parts

#### Part 1: Massive Growth
`CourseController/sign-up` end point takes the request with paremeter creates `SignUpCourseCommand` and routes it `SignUpCourseCommandHandler`.
If parameters are valid then domain entity `Course`, adds `StudentSignedUpEvent` to itself. After then `IDomainEventsDispatcher` dispatches events on the domain entity. In this case it dispatch `StudentSignedUpEvent` to its handler which is `StudentSignedUpEventHandler`. 
This handler takes `StudentSignedUpEvent` as a parameter and publish it on to bus provider. Finally `SignUpCourseCommandHandler` returns a friendly message to client. 

Scheduled worker subscribes to bus provider and listen for incoming events.
When new event received it converts to `StudentSignUpProcessedEvent` and publish it to `StudentSignUpProcessedEventHandler`. This handler takes `StudentSignUpProcessedEvent` as a parameter and check course capacity via `ICourseSignUpPolicy` and send result to student email.
All executions perform asynchronously and task based. I intentionally didnt implement a quarzt worker.

#### Part 2: Aggregating & Querying data
`StatisticsController/get` end point takes the request without any parameters, creates `GetStatisticsQuery` and routes it `GetStatisticsQueryHandler` via mediator. 
`GetStatisticsQueryHandler` firstly checks cache provider with given key if data exists with given key then it returns from cache provider, if data is not exists with given key then course statistics get calculated from persisted data and set to cache provider and returns calculated statistics.
There are cache time to keep it on cache provider. All executions perform asynchronously and task based.


#### Technologies and Libraries

* MediatR 8.0.0
* Moq 4.13.1
* Quartz 3.0.7
* MediatR.Extensions.Microsoft.DependencyInjection 8.0.0
* Microsoft.EntityFrameworkCore 3.0.0
* Microsoft.EntityFrameworkCore.InMemory 3.0.0
* Microsoft.Extensions.DependencyInjection 3.0.0
* Newtonsoft.Json 12.0.3
* Microsoft.NET.Test.Sdk 16.2.0
* MSTest.TestAdapter 1.4.0
* MSTest.TestFramework 1.4.0
* MockRedis
* MockRabbitMQ

#### Open improvement points
* **Authentication** : OAuth, JWT etc.. could be implement.
* **Authorization** :  Role based action execute could be implement.
* **Resiliency Pattern** : To protect the entire pipeline when an error is encountered.
* **Accident Managerment** : To be notified whenever an anomaly happen or something goes wrong
* **Mapper** : To map object to object and improve readability.
* **Validator** : Request parameter must be validated for the consistency. FluentValication could be a good choice.
* **Static Code Analyzer** : For continuous inspection of code quality. SonarQube could be a good choice.
* **Performance Monitoring** : To effectively scale application, performance tools can give us good idea. Datadog, Traceview, New Relic etc..
* **Dockerize** : Utility to simplify running applications in docker containers.
* **Docker Orchestraation Tools** : Kubernetes, Docker Swarm etc..
* **Healt Check** : Keeps your application environment tuned and running flawlessly.
* **Documentation** : There could be better documentation that includes, sequence diagram, class diagram etc..

