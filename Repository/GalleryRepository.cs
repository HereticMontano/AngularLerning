using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using Repository.Entity;
using Repository.Interface;

namespace Repository
{
    public class GalleryRepository : IGalleryRepository
    {
        private readonly GalleryDbContext _context;

        public GalleryRepository(GalleryDbContext context)
        {
            _context = context;
        }

        public async Task<Gallery> CreateAsync(Gallery gallery)
        {
            await _context.Gallery.AddAsync(gallery);
            await _context.SaveChangesAsync();
            return gallery;
        }

        public async Task<List<Gallery>> GetAllAsync()
        {
            return await _context.Gallery.ToListAsync();
        }

        public async Task<Gallery?> GetByIdAsync(ObjectId id)
        {
            return await _context.Gallery
                .FirstOrDefaultAsync(g => g.Id == id);
        }

        public async Task<Gallery?> UpdateAsync(ObjectId id, Gallery gallery)
        {
            var existing = await _context.Gallery
                .FirstOrDefaultAsync(g => g.Id == id);

            if (existing is null)
                return null;

            existing.Name = gallery.Name;
            existing.Pictures = gallery.Pictures;

            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(ObjectId id)
        {
            var existing = await _context.Gallery
                .FirstOrDefaultAsync(g => g.Id == id);

            if (existing is null)
                return false;

            _context.Gallery.Remove(existing);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
