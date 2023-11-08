namespace ImageUploadService.Model
{
    public interface IImageDbSettings
    {
        string ImageCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
