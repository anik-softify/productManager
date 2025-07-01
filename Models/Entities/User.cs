using productManager.Models.Entities;

namespace productManager.Models.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }
        public List<Purchase> Purchase { get; set; }
    }
}