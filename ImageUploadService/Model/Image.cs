using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Libmongocrypt;

namespace ImageUploadService.Model
{
    [BsonIgnoreExtraElements]
    public class Image
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; } = string.Empty;

        [BsonElement("userId")]
        public int userId { get; set; }

        [BsonElement("image")]
        public string? image { get; set; }

    }
}
