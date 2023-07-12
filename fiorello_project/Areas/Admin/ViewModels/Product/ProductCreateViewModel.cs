using fiorello_project.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace fiorello_project.Areas.Admin.ViewModels.Product
{
    public class ProductCreateViewModel
    {
        public string Title { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }

        public string Weight { get; set; }
        public string Dimenesion { get; set; }

        public int CategoryId { get; set; }
        public List<SelectListItem>? Categories { get; set; }
        public ProductStatus Status { get; set; }

        public IFormFile MainPhoto { get; set; }


        public List<IFormFile> Photos { get; set; }
    }
}
