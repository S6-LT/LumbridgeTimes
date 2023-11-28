using ImageUploadService.Model;

namespace ImageUploadService.Services
{
    public interface IImageService
    {
        List<Image> Get();
        Image Get(string id);
        Image Create(Image image);
        void Update(string id, Image image);
        void Remove(string id);
    }
}
