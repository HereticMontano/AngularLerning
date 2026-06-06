namespace Repository.Entity
{
    public class Picture
    {
        [MongoDB.Bson.Serialization.Attributes.BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; } = MongoDB.Bson.ObjectId.GenerateNewId().ToString();
        public string? Title { get; set; }
        public string? Description { get; set; }
        public required string UrlLocationLowCuality { get; set; } 
        public required string UrlLocationHighCuality { get; set; } 
    }
}
