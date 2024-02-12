using MongoDB.Bson.Serialization.Attributes;

namespace Mongo.WebUI.Entities
{
    public class Category:BaseEntity
    {
        
        public string Name { get; set; }
    }
}
