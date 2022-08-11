using Microsoft.AspNetCore.Identity;

namespace CRM.Model
{
    public class User : IdentityUser
    {
        public ICollection<Job> Jobs { get; set; }
    }
}
