using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Repository.Entity
{
    public class Gallery
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public required string Title { get; set; }
        
        public List<Picture> Pictures { get; set; } = new();
    }
}
