namespace AngularApp1.Server.Model
{
    public class AddPictureRequest
    {
        public required string IdGallery { get; set; }         
        public string? Title { get; set; }
        public string? Description { get; set; }
        public required string Base64Picture { get; set; }
    }
}
