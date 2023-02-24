using WorkingWithSqlServerImages.Data;
using WorkingWithSqlServerImages.Models;

namespace WorkingWithSqlServerImages.Classes;

/// <summary>
/// Operations performed by EF Core
/// </summary>
internal class EntityOperations
{
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

    public static void InsertImage(byte[] imageBytes)
    {

        using var context = new Context();

        var photoContainer = new Pictures() { Photo = imageBytes };
        context.Add(photoContainer);
        context.SaveChanges();

    }
}
