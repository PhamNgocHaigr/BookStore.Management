using Microsoft.AspNetCore.Http;

namespace BookStore.Management.Application.Services
{
    public class ImageService : IImageService
    {

        public async Task<bool> SaveImage(List<IFormFile> images, string path, string? defautName)
        {
            try
            {
                if (images?.Count == 0 || string.IsNullOrEmpty(path))
                {
                    return default;
                }

                string pathImage = Path.Combine(Directory.GetCurrentDirectory(), path);

                if (!Directory.Exists(pathImage))
                {
                    Directory.CreateDirectory(pathImage);
                }
                foreach (var image in images)
                {
                    if (image is not null)
                    {
                        string originalPath = Path.Combine(pathImage, !string.IsNullOrEmpty(defautName) ? defautName : image.Name);

                        using (var fileStream = new FileStream(originalPath, FileMode.Create))
                        {
                            await image.CopyToAsync(fileStream);
                        }
                    }
                }
            }
            catch (Exception)
            {
                return default;
            }

            return true;



        }
    }
}
