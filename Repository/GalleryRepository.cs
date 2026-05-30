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
            if (string.IsNullOrWhiteSpace(gallery.Id))
                gallery.Id = "6a1accca753932b2217171d2";//ObjectId.GenerateNewId().ToString();

            await _context.Gallery.AddAsync(gallery);
            await _context.SaveChangesAsync();
            return gallery;
        }

        public async Task<List<Gallery>> GetAllAsync()
        {
            return await _context.Gallery.ToListAsync();
        }

        public async Task<Gallery?> GetByIdAsync(string id)
        {
            return await _context.Gallery
                .FirstOrDefaultAsync(g => g.Id == id);
        }

        public async Task<Gallery?> UpdateAsync(string id, Gallery gallery)
        {
            var existing = await _context.Gallery
                .FirstOrDefaultAsync(g => g.Id == id);

            if (existing is null)
                return null;

            existing.Title = gallery.Title;
            existing.Pictures = gallery.Pictures;

            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var existing = await _context.Gallery
                .FirstOrDefaultAsync(g => g.Id == id);

            if (existing is null)
                return false;

            _context.Gallery.Remove(existing);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AddPictureToGalleryAsync(string galleryId, Picture picture)
        {
            var gallery = await _context.Gallery
                .FirstOrDefaultAsync(g => g.Id == galleryId);
            
            if (gallery is null)
                return false;

            gallery.Pictures.Add(picture);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
