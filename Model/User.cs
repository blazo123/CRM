using Microsoft.AspNetCore.Identity;

namespace CRM.Model
{
    public class User : IdentityUser
    {
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
