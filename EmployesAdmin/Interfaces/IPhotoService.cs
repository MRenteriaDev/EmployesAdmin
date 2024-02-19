using CloudinaryDotNet.Actions;

namespace EmployesAdmin.Interfaces
{
    public interface IPhotoService
    {
        Task<ImageUploadResult> AddPhotoAsync(IFormFile file);
        Task<DeletionResult> DeletePhotoAsync(string imagePublicId);
    }
}
