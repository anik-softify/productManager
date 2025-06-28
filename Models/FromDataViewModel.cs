using Microsoft.AspNetCore.Mvc.Rendering;

namespace productManager.Models
{
    public class FormDataViewModel
    {
        public List<ProductInfo> Products { get; set; }
        public List<SelectListItem> Stores { get; set; }
    }

    public class ProductInfo
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string Gender { get; set; }
    }

}
