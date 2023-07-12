using System.ComponentModel.DataAnnotations;

namespace fiorello_project.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        
        public string Title { get; set; }

        public List<Product> Products { get; set; }
    }
}
