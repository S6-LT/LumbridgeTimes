using ImageUploadService.Model;
using MongoDB.Driver;
using static System.Net.Mime.MediaTypeNames;

namespace ImageUploadService.Services
{
    public class ImageService : IImageService
    {
        private readonly IMongoCollection<Model.Image> _images;

        public ImageService(IImageDbSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName = "test");
            _images = database.GetCollection<Model.Image>(settings.ImageCollectionName = "Images");
        }
        public Model.Image Create(Model.Image image)
        {
            _images.InsertOne(image);
            return image;
        }

        public List<Model.Image> Get()
        {
            return _images.Find(image => true).ToList();
        }

        public Model.Image Get(string id)
        {
            return _images.Find(image => image.id == id).FirstOrDefault();
        }

        public void Remove(string id)
        {
            _images.DeleteOne(image => image.id == id);
        }

        public void Update(string id, Model.Image image)
        {
            _images.ReplaceOne(student => student.id == id, image);
        }
    }
}
