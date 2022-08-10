using System.ComponentModel.DataAnnotations;

namespace CRM.Model
 {
        public class Client
        {
            //[Key]
            public int Id { get; set; }

            [MinLength(6)]
            [Required]
            public string Name { get; set; }

            [RegularExpression(@"[0-9]{10}", ErrorMessage = "Expression isn't a NIP")]
            [Required]
            public string NIP { get; set; }

            //[RegularExpression(@"[0-9]{9}", ErrorMessage = "Expression isn't a REGON")]
            public string? REGON { get; set; }

            public string? StreetName { get; set; }
            public string? StreetNumber { get; set; }
            public string? ApartmentNumber { get; set; }
            public string? PostCode { get; set; }
            public string? City { get; set; }

            public string? Country { get; set; }

            public DateTime CreatedDate { get; set; }
            public DateTime UpdateDate { get; set; }

            public ICollection<Contact> Contacts { get; set; }
            public ICollection<Job> Jobs { get; set; }

    }
}

