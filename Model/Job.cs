using Microsoft.AspNetCore.Identity;

namespace CRM.Model
{
    public class Job // Zadanie
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public IdentityUser User { get; set; }
        public TypeOfJob Type { get; set; }

        public DateTime CreatedDate { get; set; }
        public decimal ? SaleAmount { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }

        public DateTime DateOfNextActivity { get; set; }


    }
}
