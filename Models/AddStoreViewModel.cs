using Microsoft.AspNetCore.Mvc.Rendering;


namespace productManager.Models
{
    public class AddStoreViewModel
    {
        public Guid Id { get; set; }
         public string StorName { get; set; }

        public List<AddStoreViewModel> StoreList { get; set; } = new List<AddStoreViewModel>();
    }
}
