


using Microsoft.AspNetCore.Mvc.Rendering;

namespace PCDoctor.Models.Models.ViewModels
{
    public class ProductVM
    {
        public Product Product { get; set; }
        public IEnumerable<SelectListItem> CategoryList { get; set; }
    }
}
