using System.ComponentModel.DataAnnotations;

namespace fiorello_project.ViewModels.MyAccount
{
    public class AccountLoginViewModel
    {
        [Required]
        public string Username { get; set; }

        [Required, MaxLength(100), DataType(DataType.Password)]
        public string Password { get; set; }

        public string? ReturnUrl { get; set; }
    }
}
