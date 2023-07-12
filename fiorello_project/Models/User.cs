using Microsoft.AspNetCore.Identity;

namespace fiorello_project.Models
{
    public class User :IdentityUser
    {
        public string FullName { get; set; }

    }
}
