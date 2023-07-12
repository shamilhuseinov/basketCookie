using System.ComponentModel.DataAnnotations;

namespace fiorello_project.Areas.Admin.ViewModels.Account
{
    public class AccountLoginViewModel
    {
        [Required]
        public string Username { get; set; }
        [Required,DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
