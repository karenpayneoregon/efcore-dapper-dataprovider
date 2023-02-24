# About

**Entity Framework Core** is one of the most recommended options suggested for applications working with relational database. EF Core is an object-relational mapper(ORM) that enables .NET developers to persist objects to and from a data source. It eliminates the need for most of the data access code developers would typically need to write.


**Dapper** is a simple object mapper for .NET and owns the title of King of Micro ORM in terms of speed and is virtually as fast as using a raw ADO.NET data reader. Dapper operates directly using the IDbConnection interface which is extended by database providers like SQL Server, Oracle, MySQL etc. for their database.

## NuGet packages


| Package    |   Description    |
|:------------- |:-------------|
| [Microsoft.EntityFrameworkCore.SqlServer](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.SqlServer/8.0.0-preview.1.23111.4) | EF Core  |  
| [Dapper](https://www.nuget.org/packages/Dapper) | Dapper is an open-source object-relational mapping (ORM) library for .NET and .NET Core applications |  
| [Microsoft.Data.SqlClient](https://www.nuget.org/packages/Microsoft.Data.SqlClient) |Native data provider  |  
| [ConfigurationLibrary](https://www.nuget.org/packages/ConfigurationLibrary) | Get connection string with dependency injection |  


## Code

All code was written with .NET Core 7

## Which one is best?

That is a personal opinion but unless tied to `Microsoft.Data.SqlClient` the choices are EF Core and Dapper as a personal opinion.

## NuGet trends

[Dapper, EF Core, SqlClient](https://nugettrends.com/packages?months=12&ids=Dapper&ids=Microsoft.EntityFrameworkCore&ids=System.Data.SqlClient) past year

