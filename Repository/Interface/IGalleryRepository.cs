using MongoDB.Bson;
using Repository.Entity;

namespace Repository.Interface
{
    public interface IGalleryRepository
    {
        Task<Gallery> CreateAsync(Gallery gallery);
        Task<bool> DeleteAsync(ObjectId id);
        Task<Gallery?> GetByIdAsync(ObjectId id);
        Task<List<Gallery>> GetAllAsync();
        Task<Gallery?> UpdateAsync(ObjectId id, Gallery gallery);
    }
}
