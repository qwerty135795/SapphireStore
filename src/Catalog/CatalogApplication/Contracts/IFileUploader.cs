namespace CatalogApplication.Contracts;

public interface IFileUploader
{
    Task<string?> Upload(Stream stream, string fileName);
}