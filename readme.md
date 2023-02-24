# Working with EF Core/Dapper/SqlClient basics

Learn how to read and insert images into a SQL-Server database using [Dapper](https://www.learndapper.com/), [Entity Framework Core](https://learn.microsoft.com/en-us/ef/core/) and [SqlClient](https://learn.microsoft.com/en-us/dotnet/api/system.data.sqlclient?view=dotnet-plat-ext-7.0) data provider.

For novice and even intermediate level developers working with images can be a daunting task simple because they either write code expecting it to immediately work with no regards to things like using the proper data types or copying pasting code from the Internet without changing much and expect the code to work.

To reach the main audiences three different approaches are used Dapper, EF Core and SqlClient data provider.  

## Using the proper data type

The developer with no experience with working with images will select Image verses varbinary(max) not realizing Image type most likely will be removed in future versions of SQL-Server. This means, do not use Image, instead use varbinary(max).

## Column definition for code samples

![table definition](assets/TableDefinition.png)

## Operations

The three methods used will both insert and read a single record.

What is important to know:

- Dapper and EF Core require less hand written code
- Dapper and SqlClient require decent knowledge of SQL syntax
- EF Core, in this case were configured using [EF Power Tools](https://dev.to/karenpayneoregon/ef-power-tools-tutorial-44d8) which means no manual configuration.
- Which to use is a personal choice

## Insert new record version 1

In the following samples a record is inserted but we do not get the new record key

### Insert new record with SqlClient data provider 

To insert a new record.

- Create a connection object with a connection string
- Create a command object
- Add a single parameter
- Open the connection
- Execute the command

```csharp
public static void InsertImage(byte[] imageBytes)
{
    var sql = "INSERT INTO [dbo].[Pictures1] ([Photo])  VALUES (@ByteArray)";

    using var cn = new SqlConnection(ConnectionString());
    using var cmd = new SqlCommand(sql, cn);

    cmd.Parameters.Add("@ByteArray", SqlDbType.VarBinary).Value = imageBytes;

    cn.Open();
    cmd.ExecuteNonQuery();
}
```

### Insert new record with Dapper

- Create a connection object with a connection string
- Add a single parameter
- Execute the command

```csharp
public static void InsertImage(byte[] imageBytes)
{

    var sql = "INSERT INTO [dbo].[Pictures1] ([Photo])  VALUES (@ByteArray)";

    using var cn = new SqlConnection(ConnectionString());
    var parameters = new { ByteArray = imageBytes};
    cn.Execute(sql, parameters);

}
```

### Insert new record with Dapper

- Create an instance of the DbContext
- Create an instance of the type 
- Save changes

```csharp
public static void InsertImage(byte[] imageBytes)
{

    using var context = new Context();
    context.Add(new Pictures() { Photo = imageBytes });
    context.SaveChanges();

}
```

## Insert new record version 2

In the following samples a record is inserted with the new record primary key

### SqlClient

We append `SELECT CAST(scope_identity() AS int)` to the insert and rather than `ExecuteNonQuery` use `ExecuteScalar` which returns an object, we cast to the same type as the primary key.

```csharp
public static void InsertImage(byte[] imageBytes)
{
    var sql = 
        """
        INSERT INTO [dbo].[Pictures1] ([Photo])  VALUES (@ByteArray);
        SELECT CAST(scope_identity() AS int);
        """;

    using var cn = new SqlConnection(ConnectionString());
    using var cmd = new SqlCommand(sql, cn);

    cmd.Parameters.Add("@ByteArray", SqlDbType.VarBinary).Value = imageBytes;

    cn.Open();
    var key = (int)cmd.ExecuteScalar();
}
```

### Dapper

The following `OUTPUT Inserted.Id` is added to the SQL, note `Id` needs to match the primary key name.

Rather then `Execute` method we use `ExecuteScalar` which is basically the same as SqlClient.

```csharp
public static void InsertImage(byte[] imageBytes)
{

    var sql = "INSERT INTO [dbo].[Pictures1] ([Photo]) OUTPUT Inserted.Id VALUES (@ByteArray)  ";

    using var cn = new SqlConnection(ConnectionString());
    var parameters = new { ByteArray = imageBytes};
    var key = (int)cn.ExecuteScalar(sql, parameters);

}
```

### EF Core

Simply move the Pictures object to a variable. After SaveChanges, `photoContainer.Id` will have the new primary key.


```csharp
public static void InsertImage(byte[] imageBytes)
{

    using var context = new Context();

    var photoContainer = new Pictures() { Photo = imageBytes };
    context.Add(photoContainer);
    context.SaveChanges();

}
```

## Read an image

What you will notice is that between the three methods, they are practically the same.

With EF Core there are a few extra lines to keep in sync with the return type to matach the other two methods.

The SqlClient has several more lines of code than the other two methods.


**SqlClient**

```csharp
public static (PhotoContainer container, bool success) ReadImage(int identifier)
{
    var photoContainer = new PhotoContainer() { Id = identifier };
    var sql = "SELECT id, Photo FROM dbo.Pictures1 WHERE dbo.Pictures1.id = @id;";

    using var cn = new SqlConnection(ConnectionString());
    using var cmd = new SqlCommand(sql, cn);

    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = identifier;

    cn.Open();

    var reader = cmd.ExecuteReader();
    reader.Read();

    if (!reader.HasRows)
    {
        return (null, false);
    }

    var imageData = (byte[])reader[1];
    using (var ms = new MemoryStream(imageData, 0, imageData.Length))
    {
        ms.Write(imageData, 0, imageData.Length);
        photoContainer.Picture = Image.FromStream(ms, true);
    }

    return (photoContainer, true);
}
```

**Dapper**

```csharp
public static (PhotoContainer container, bool success) ReadImage(int identifier)
{

    var photoContainer = new PhotoContainer() { Id = identifier };
    var sql = "SELECT id, Photo FROM dbo.Pictures1 WHERE dbo.Pictures1.id = @id";

    using var cn = new SqlConnection(ConnectionString());
    var parameters = new { id = identifier };
    var container = cn.QueryFirstOrDefault<ImageContainer>(sql, parameters);

    if (container is null)
    {
        return (null, false);
    }

    var imageData = container.Photo;

    using (var ms = new MemoryStream(imageData, 0, imageData.Length))
    {
        ms.Write(imageData, 0, imageData.Length);
        photoContainer.Picture = Image.FromStream(ms, true);
    }

    return (photoContainer, true);
}
```

**EF Core**

```csharp
public static (PhotoContainer container, bool success) ReadImage(int identifier)
{
    var photoContainer = new PhotoContainer() { Id = identifier };
    using var context = new Context();

    var item = context.Pictures1.FirstOrDefault(item => item.Id == identifier);

    if (item is null)
    {
        return (null, false);
    }

    var imageData = item.Photo;

    using (var ms = new MemoryStream(imageData, 0, imageData.Length))
    {
        ms.Write(imageData, 0, imageData.Length);
        photoContainer.Picture = Image.FromStream(ms, true);
    }

    return (photoContainer, true);

}
```

## Special note

> **Note**
> There is no exception handling in any of the code as the code was written properly, this does not by any means to not implement exception handling in your code as many things can go wrong, so implement exception handling

## Preparing the project to run

Using the script under the folder Scripts, create the database, create the single table and populate.

## Why you a Windows Forms project?

Well the code had been done in an ASP.NET Core, Blazor, MAUI or unit test while using a Windows Forms project bypasses things such as securty issues and is very easy to read and understand.


## Source code

Clone the following [GitHub repository](https://github.com/karenpayneoregon/efcore-dapper-dataprovider)
