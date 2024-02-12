using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Mongo.WebUI.Entities
{
    public class BaseEntity
    {
        
        public ObjectId Id { get; set; }
    }
}
