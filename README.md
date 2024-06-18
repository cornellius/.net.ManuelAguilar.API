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
    * [GET] /authors
    * [POST] /post
    * [GET] /post/[id]
        * use request header `WithAuthors` with some value to retrieve author related information
* To setup the database and seed with initial data (3 authors), please execute the following commands:
    * `dotnet ef migrations add InitialMigration`
    * `dotnet ef database update`

## Implementation & general notes

* Proper unit tests (with xUnit, Moq, FluentAssertions) are NOT YET implemented, because of pure time constrains. I will add sufficient unit tests in subsequent commits. I am totally conscious that unit testing and high code coverage are a MUST in software development, I just ran out of time for this first commit :-/ But I will add them later for sure!
* In general it's been a challenge (or complication) to learn to code in .NET because of the myriad of different .NET and library versions (which have different ways to set them up and use them), plus many different ways to do things (some of them obsolete, some others very recent) that appear in articles, training videos, etc. I have really enjoyed coding in C#, thought.
