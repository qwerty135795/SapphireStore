using CatalogApplication.Contracts;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.Extensions.Configuration;

namespace CatalogInfrastructure.Contracts;

public class FileUploader : IFileUploader
{
    private readonly Cloudinary _cloudinary;
    public FileUploader(IConfiguration config)
    {
        var acc = new Account(config["cloud"], config["cloudToken"], config["apiSecret"]);
        _cloudinary = new Cloudinary(acc);
    }
    public async Task<string?> Upload(Stream stream, string fileName)
    {
        var file = new FileDescription(fileName, stream);
        var parametrs = new ImageUploadParams
        {
            File = file,
            PublicId = fileName
        };
        var result = await _cloudinary.UploadAsync(parametrs);
        return result.SecureUrl.AbsoluteUri;
    }
}