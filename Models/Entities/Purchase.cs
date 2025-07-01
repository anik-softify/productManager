namespace productManager.Models.Entities
{
    public class Purchase
    {
        public Guid Id { get; set; }
        public Guid prdtId { get; set; }
        public Guid CusId { get; set; }
        public Product Product { get; set; }
        public User User { get; set; }
    }
}
