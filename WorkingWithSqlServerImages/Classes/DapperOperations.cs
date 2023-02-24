using Microsoft.Data.SqlClient;
using static ConfigurationLibrary.Classes.ConfigurationHelper;
using Dapper;
using System.Data;
using WorkingWithSqlServerImages.Models;


namespace WorkingWithSqlServerImages.Classes;

/// <summary>
/// Operations performed by Dapper package
/// </summary>
internal class DapperOperations
{
    public static void InsertImage(byte[] imageBytes)
    {

        var sql = "INSERT INTO [dbo].[Pictures1] ([Photo]) OUTPUT Inserted.Id VALUES (@ByteArray)  ";

        using var cn = new SqlConnection(ConnectionString());
        var parameters = new { ByteArray = imageBytes};
        var key = (int)cn.ExecuteScalar(sql, parameters);

    }

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
}
