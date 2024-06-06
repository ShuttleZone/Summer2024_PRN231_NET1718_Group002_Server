using Microsoft.AspNetCore.Http;

namespace ShuttleZone.Application.Services.File;

public interface IFileService
{
    Task<string> UploadSingleFileAsync(IFormFile file);
    Task<ICollection<string>> UploadMultipleFileAsync(List<IFormFile> files);
}