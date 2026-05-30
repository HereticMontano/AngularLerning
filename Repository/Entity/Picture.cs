namespace Repository.Entity
{
    public class Picture
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public required string UrlLocationLowCuality { get; set; } 
        public required string UrlLocationHighCuality { get; set; } 
    }
}
