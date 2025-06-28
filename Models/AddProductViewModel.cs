using Microsoft.AspNetCore.Mvc.Rendering;

namespace productManager.Models
{
    public class AddProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }

        public int TypeId { get; set; }

        public List<SelectListItem>? GenderList { get; set; } // Dropdown data
        public List<SelectListItem>? StorName { get; set; }
    }

}
