# .NET 8 exercise

The aim of this exercise is to implement a couple of fake blogging end-points, using:

* Microsoft Entity Framework Core,
* Clean Architecture (by the means of Vertical slice),
* CQRS,
* Docker,
* PostgreSQL

## Installation & usage notes

* The API should be responding at port :8080
* PostgreSQL is contanerized and responding on port 5433
* A small subset of end-points and CRUD operations are available:
    * [GET] /health 
    * [GET] /authors
    * [POST] /post
    * [GET] /post/[id]
        * use request header `WithAuthors` with some value to retrieve author related information
* To setup the database and seed with initial data (3 authors), please execute the following commands:
    * `dotnet ef migrations add InitialMigration`
    * `dotnet ef database update`
* To spin up Docker containers:
    * `cd ManuelAguilar.API`
    * `docker build --file ManuelAguilar.API/Dockerfile --rm --no-cache -t manuelaguilar:latest .`
    * `docker-compose up`

## Known/potential issues

* [bug, pending] Using a non-existent post ID on [GET] /post/[id] triggers an exception that is not properly captured and provokes a 500 server error. I am investigating why the exception is not managed as a NotFoundException, and fix it.
* ~~[fixed] After upgrading to .NET 8 I switched from Docker to local testing to speed up things. I am testing now that everything works fine with Docker, again.~~
* [pending] add unit tests to cover controllers, handlers and data operations.

## Implementation & general notes

* Proper unit tests (with xUnit, Moq, FluentAssertions) **are NOT YET implemented**, because of me still learning how to set them up in .NET, and pure time constrains. My aim is to add sufficient unit tests in subsequent commits, if time permits. Nonwithstanding, I am **totally conscious that unit testing and high code coverage are a MUST in software development**, and as such I would expect to have them for any software change that could go to production. This is both from the perspective of a manager or a developer.
* In general it's been a challenge (a nice one for the most part!) to learn how to code in .NET and determine which is the most up to date documentation and followed standards/best practices, because of the myriad of different .NET versions out there, plus all the tutorials recommending very varied implementations, some of them considered obsolete by now. Constant triage of information has been a constant. There are also many different ways to achieve things with .NET (multiple libraries for the same purpose), which is something I have not found in other development languages like Elixir (I know, a very different one, and with a very small community).
* I have really enjoyed coding in C#, thought. Thanks for the opportunity!
