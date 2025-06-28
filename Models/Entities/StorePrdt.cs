namespace productManager.Models.Entities
{
    public class StorePrdt
    {
        public Guid Id { get; set; }
        public Guid PrdtId { get; set; }
        public Guid StoreId { get; set; }
        public Product Product { get; set; }
        public Store Store { get; set; }

    }
}
