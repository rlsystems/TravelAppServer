using ServerApp.Application.Common.Interfaces;
using ServerApp.Domain.Common;
using ServerApp.Shared.DTOs.Storage;

namespace ServerApp.Application.Storage;

public interface IFileStorageService : ITransientService
{
    public Task<string> UploadAsync<T>(FileUploadRequest request, FileType supportedFileType)
    where T : class;
}