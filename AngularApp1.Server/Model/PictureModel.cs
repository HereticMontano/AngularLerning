namespace AngularApp1.Server.Model
{
    public class PictureModel
    {
        public string? Id { get; set; }
        public required string URLLocationLowCuality { get; set; }
        public required string URLLocationHighCuality { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
    }
}
