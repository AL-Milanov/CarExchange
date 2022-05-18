using MongoDB.Bson.Serialization.Attributes;

namespace CarExchange.Infrastructure.Data.Models
{
    public class Image
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id = Guid.NewGuid().ToString();

        public List<byte[]>? Images { get; set; }

        public Image()
        {
            Images = new List<byte[]>();
        }
    }
}