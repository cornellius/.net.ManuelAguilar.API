# .NET 8 exercise

The aim of this exercise is to implement a couple of fake blogging end-points, using:

* Microsoft Entity Framework Core,
* Clean Architecture (by the means of Vertical slice),
* CQRS,
* Docker,
* PostgreSQL

## Installation & usage notes

* The REST API should be serving at port :8080
* PostgreSQL is containerised and responding on port 5433
* A small subset of API end-points and CRUD operations are available:
    * [GET] /health 
    * [GET] /authors
    * [POST] /post
    * [GET] /post/[id]
        * (i) use request header `WithAuthors` with some value to retrieve author related information
* To setup the database and seed with initial data (3 authors), please execute the following commands:
    * `dotnet ef migrations add InitialMigration`
    * `dotnet ef database update`
* To spin up Docker containers:
    * `cd ManuelAguilar.API`
    * `docker build --file ManuelAguilar.API/Dockerfile --rm --no-cache -t manuelaguilar:latest .`
    * `docker-compose up`

## Known/potential issues

* [bug, pending] Using a non-existent post ID on [GET] /post/[id] triggers an exception that is not properly captured and provokes a 500 server error. I am investigating why the exception is not managed as a NotFoundException, then fix it.
* ~~[fixed] After upgrading to .NET 8 I switched from Docker to local testing to speed up things. I am testing now that everything works fine with Docker, again.~~
* [pending] add unit tests to cover controllers, handlers and data operations. Also aiming to have a code coverage of 90%

## Implementation & general notes

* Proper unit tests (with xUnit, Moq, FluentAssertions) **are NOT YET implemented**, because of me still learning how to set them up in .NET, and pure time constrains. My aim is to add sufficient unit tests in subsequent commits, if time permits. Nonwithstanding, I am **totally conscious that unit testing and high code coverage are a MUST in software development**, and as such I would expect to have them for any software change that could potentially go to production. This is both from the perspective of a manager and a developer.
* In general it's been a challenge (a nice one for the most part!) to learn how to code in .NET and determine which is the most up to date documentation and followed standards/best practices; this is because of the myriad of different .NET versions out there, plus all the tutorials recommending very varied implementations, some of them wrong or considered obsolete by now. Continuous triage of information has been a constant. There are usually many different ways to achieve things with .NET (multiple libraries for the same purpose), which is something to be expected because of .Net wide usage and popularity. Other programming languages like Elixir (I know, a very different one, and with a very small community) seem to have a much better documentation online.
* I have really enjoyed coding in C#, thought. Thanks for the opportunity!
