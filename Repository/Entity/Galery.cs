using MongoDB.Bson;

namespace Repository.Entity
{
    public class Gallery
    {
        public ObjectId Id { get; set; }
        public required string Name { get; set; }
        
        public List<Picture> Pictures { get; set; } = new();
    }
}
