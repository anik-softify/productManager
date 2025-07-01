namespace productManager.Models.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public int TypeId { get; set; }
        public Types Types { get; set; }
        
        
        public List<StorePrdt> StorePrdts { get; set; }
        public List<Purchase> Purchases { get; set; }
    }
}
