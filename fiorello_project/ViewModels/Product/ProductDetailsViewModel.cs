using fiorello_project.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace fiorello_project.ViewModels.Product
{
    public class ProductDetailsViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }

        public string Weight { get; set; }
        public string Dimenesion { get; set; }

        public Category Category { get; set; }
        public ProductStatus Status { get; set; }

        public string MainPhoto { get; set; }


        public ICollection<Models.ProductPhoto> Photos { get; set; }
    }
}
