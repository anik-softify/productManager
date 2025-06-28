namespace productManager.Models.Entities
{
    public class Store
    {
        public Guid Id { get; set; }
        public string StorName { get; set; }

        public List<StorePrdt> StorePrdt { get; set; }
    }
}
