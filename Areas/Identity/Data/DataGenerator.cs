using Bogus;
using CRM.Data;
using CRM.Model;

namespace CRM.Areas.Identity.Data
{
    public class DataGenerator
    {
        public static void Seed(AppDbContext context)
        {
            var locale = "pl";
            var contactId = 1;
            var clientId = 1;
            var jobId = 1;

            var users = new List<User>()
            {
                new User
                {
                    Id = "1",
                    UserName = "Jórek Ogórek",
                    PasswordHash = null,
                    Email = "j.ogorek@gmail.com"
                },
                new User
                {
                    Id = "2",
                    UserName = "Czarek Czarecki",
                    PasswordHash = null,
                    Email = "c.czarecki@gmail.com"
                }
            };


            var clientGenerator = new Faker<Client>(locale)
                .RuleFor(m => m.Id, f => clientId++)
                .RuleFor(a => a.Name, f => f.Company.CompanyName())
                .RuleFor(a => a.NIP, f => f.Random.Long(1000000000, 9999999999).ToString())
                .RuleFor(a => a.REGON, f => f.Random.Long(100000000, 999999999).ToString())
                .RuleFor(a => a.StreetName, f => f.Address.StreetName())
                .RuleFor(a => a.StreetNumber, f => f.Address.StreetAddress())
                .RuleFor(a => a.PostCode, f => f.Address.ZipCode())
                .RuleFor(a => a.City, f => f.Address.City())
                .RuleFor(a => a.Country, "POLSKA")
                .RuleFor(a => a.CreatedDate, f => f.Date.Past(2));

            var clients = clientGenerator.Generate(100);

            var contactGenerator = new Faker<Contact>(locale)
                .RuleFor(m => m.Id, f => contactId++)
                .RuleFor(a => a.Name, f => f.Person.FullName)
                .RuleFor(a => a.Email, f => f.Person.Email)
                .RuleFor(a => a.PhoneNumber, f => f.Phone.PhoneNumber())
                .RuleFor(a => a.CreatedDate, f => f.Date.Past(2))
                //.RuleFor(a => a.Client, f => f.PickRandom(clients));
                .RuleFor(a => a.ClientId, f => f.Random.Int(1, 100));

            var contacts = contactGenerator.Generate(200);


            var jobGenerator = new Faker<Job>(locale)
                .RuleFor(m => m.Id, f => jobId++)
                .RuleFor(a => a.Subject, f => f.Commerce.ProductName())
                .RuleFor(a => a.Description, f => f.Commerce.ProductDescription())
                .RuleFor(a => a.CreatedDate, f => f.Date.Past(2))
                .RuleFor(a => a.SaleAmount, f => f.Finance.Amount(1000, 500000))
                .RuleFor(a => a.DateOfNextActivity, f => f.Date.Future(1))
                .RuleFor(a => a.DateOfNextActivity, f => f.Date.Future(1))
                .RuleFor(a => a.UserId, f => f.Random.Int(1, 2).ToString())
                .RuleFor(a => a.Type, f => f.PickRandom<TypeOfJob>())
                //.RuleFor(a => a.Client, f => f.PickRandom(clients));
                .RuleFor(a => a.ClientId, f => f.Random.Int(1, 100));

            var jobs = jobGenerator.Generate(500);


            context.AddRange(users);
            context.AddRange(clients);
            context.AddRange(jobs);
            context.SaveChanges();
        }
    }
}
