using ImageUploadService.Model;
using static System.Net.Mime.MediaTypeNames;

namespace ImageUploadService.Services
{
    public interface IImageService
    {
        List<Model.Image> Get();
        Model.Image Get(string id);
        Model.Image Create(Model.Image image);
        void Update(string id, Model.Image image);
        void Remove(string id);
    }
}
