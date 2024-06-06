using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using ShuttleZone.Common.Attributes;
using ShuttleZone.Common.Exceptions;
using ShuttleZone.Common.Settings;

namespace ShuttleZone.Application.Services.File;
[AutoRegister]
public class FileService : IFileService
{
    private readonly BlobServiceClient _blobServiceClient;
    private readonly AzureSettings _azureSettings;g

    public FileService(IConfiguration config)
    {
        _azureSettings = config.GetSection(nameof(AzureSettings)).Get<AzureSettings>() ?? throw new MissingAzureSettingsConfiguration();
        _blobServiceClient = new BlobServiceClient(_azureSettings.AzureBlobStorage);
    }

    public async Task<string> UploadSingleFileAsync(IFormFile file)
    {
        var containerInstance = _blobServiceClient.GetBlobContainerClient(_azureSettings.BlobContainer);
        var blobInstance =
            containerInstance.GetBlobClient(file.FileName);
        await blobInstance.UploadAsync(file.OpenReadStream());
        return blobInstance.Uri.ToString();
    }

    public async Task<ICollection<string>> UploadMultipleFileAsync(List<IFormFile> files)
    {
        var urlList = new List<string>();
        var containerInstance = _blobServiceClient.GetBlobContainerClient(_azureSettings.BlobContainer);
        foreach (var file in files)
        {
            var blobInstance = containerInstance.GetBlobClient(file.FileName);
            await blobInstance.UploadAsync(file.OpenReadStream());
            urlList.Add(blobInstance.Uri.ToString());
        }
        return urlList;
    }
}

