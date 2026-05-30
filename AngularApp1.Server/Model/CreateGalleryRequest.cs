namespace AngularApp1.Server.Model
{
    public class CreateGalleryRequest
    {        
        public required string Title { get; set; }
        public string? Description { get; set; }
    }
}
