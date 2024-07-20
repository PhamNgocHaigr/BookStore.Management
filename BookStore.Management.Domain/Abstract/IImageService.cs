using Microsoft.AspNetCore.Http;

namespace BookStore.Management.Domain.Abstracts
{
    public interface IImageService
    {
        Task<bool> SaveImage(List<IFormFile> images, string path, string? defautName);
    }
}