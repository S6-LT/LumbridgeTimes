namespace ImageUploadService.Model
{
    public class ImageDbSettings : IImageDbSettings
    {
        public string ImageCollectionName { get; set; } = string.Empty;
        public string ConnectionString { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty;
    }
}
