using Microsoft.AspNetCore.Http;

namespace BookStore.Management.Infrastructure.Image
{
    public interface IImageService
    {
        Task<bool> SaveImage(List<IFormFile> images, string path, string? defautName);
    }
}