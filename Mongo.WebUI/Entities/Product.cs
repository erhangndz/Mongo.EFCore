namespace Mongo.WebUI.Entities
{
    public class Product : BaseEntity
    {
        public string Brand { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
    }
}
