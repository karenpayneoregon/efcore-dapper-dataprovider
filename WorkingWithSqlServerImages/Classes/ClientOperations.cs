using System.Data;
using Microsoft.Data.SqlClient;
using WorkingWithSqlServerImages.Models;
using static ConfigurationLibrary.Classes.ConfigurationHelper;

namespace WorkingWithSqlServerImages.Classes;

/// <summary>
/// Operations performed by SqlClient provider
/// </summary>
internal class ClientOperations
{

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

    /// <summary>
    /// Provides a reset
    /// </summary>
    public static void TruncateTable()
    {
        var sql = "TRUNCATE TABLE dbo.Pictures1;";
        using var cn = new SqlConnection(ConnectionString());
        using var cmd = new SqlCommand(sql, cn);
        cn.Open();
        cmd.ExecuteNonQuery();
    }

}