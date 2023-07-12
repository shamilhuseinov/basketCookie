using fiorello_project.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace fiorello_project.Areas.Admin.ViewModels.Product
{
    public class ProductIndexViewModel
    {
        public List<Models.Product> Products { get; set; }

        #region Filter

        public string? Title { get; set; }

        public List<SelectListItem> Categories { get; set; }

        [Display(Name = "Category")]
        public int? CategoryId { get; set; }

        [Display(Name = "Minimum price")]
        public double? MinPrice { get; set; }

        [Display(Name = "Maximum price")]
        public double? MaxPrice { get; set; }

        [Display(Name = "Minimum quantity")]
        public int? MinQuantity { get; set; }

        [Display(Name = "Maximum quantity")]
        public int? MaxQuantity { get; set; }

        [Display(Name = "Created start date")]
        public DateTime? CreatedAtStart { get; set; }

        [Display(Name = "Created end date")]
        public DateTime? CreatedAtEnd { get; set; }

        public ProductStatus? Status { get; set; }
        #endregion

        #region Pagination

        public int Page { get; set; } = 1;

        public int Take { get; set; } = 5;

        public int PageCount { get; set; }

        #endregion
    }
}
