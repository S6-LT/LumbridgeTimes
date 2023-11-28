using ImageUploadService.Model;
using MongoDB.Driver;

namespace ImageUploadService.Services
{
    public class ImageService : IImageService
    {
        private readonly IMongoCollection<Image> _images;

        public ImageService(IImageDbSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName = "test");
            _images = database.GetCollection<Image>(settings.ImageCollectionName = "Images");
        }
        public Image Create(Image image)
        {
            _images.InsertOne(image);
            return image;
        }

        public List<Image> Get()
        {
            return _images.Find(image => true).ToList();
        }

        public Image Get(string id)
        {
            return _images.Find(image => image.id == id).FirstOrDefault();
        }

        public void Remove(string id)
        {
            _images.DeleteOne(image => image.id == id);
        }

        public void Update(string id, Image image)
        {
            _images.ReplaceOne(student => student.id == id, image);
        }
    }
}
