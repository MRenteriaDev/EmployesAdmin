using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using EmployesAdmin.Helpers;
using EmployesAdmin.Interfaces;
using Microsoft.Extensions.Options;

namespace EmployesAdmin.Service
{
    public class PhotoService : IPhotoService
    {
        private readonly Cloudinary _cloudinary;
        public PhotoService(IOptions<CloudinarySettings> config)
        {
            var acc = new Account
            (
                config.Value.CloudName,
                config.Value.ApiKey,
                config.Value.ApiSecret
            );

            _cloudinary = new Cloudinary(acc);
        }
        public async Task<ImageUploadResult> AddPhotoAsync(IFormFile file)
        {
            var uploadResult = new ImageUploadResult();
            if (file.Length > 0)
            {
                using var stream = file.OpenReadStream();
                var uploadParameters = new ImageUploadParams
                {
                    File = new FileDescription(file.FileName, stream),
                    Transformation = new Transformation().Height(300)
                            .Width(300).Crop("fill")
                            .Gravity("face"),
                    Folder = "ImagesEmployees"
                };

                uploadResult = await _cloudinary.UploadAsync(uploadParameters);
            }

            return uploadResult;
        }

        public async Task<DeletionResult> DeletePhotoAsync(string imagePublicId)
        {
            var deletedParams = new DeletionParams(imagePublicId);

            return await _cloudinary.DestroyAsync(deletedParams);
        }
    }
}
