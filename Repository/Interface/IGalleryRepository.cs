using Repository.Entity;

namespace Repository.Interface
{
    public interface IGalleryRepository
    {
        Task<Gallery> CreateAsync(Gallery gallery);
        Task<bool> DeleteAsync(string id);
        Task<Gallery?> GetByIdAsync(string id);
        Task<List<Gallery>> GetAllAsync();
        Task<Gallery?> UpdateAsync(string id, Gallery gallery);

        Task<bool> AddPictureToGalleryAsync(string galleryId, Picture picture);
    }
}
