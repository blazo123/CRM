using Bogus;
using CRM.Data;
using CRM.Model;

namespace CRM.Areas.Identity.Data
{
    public class DataGenerator
    {
        public void Seed(AppDbContext context)
        {
            //var locale = "pl";

            //var users = new List<User>()
            //{
            //    new User
            //    {
            //        Id = "1",
            //        UserName = "Błażej Kołek",
            //        PasswordHash = "!SAPb1234",
            //        Email = "blazej.kolek@gmail.com"
            //    },
            //    new User
            //    {
            //        Id = "2",
            //        UserName = "Jeremi Kalecki",
            //        PasswordHash = "!SAPb1234",
            //        Email = "j.kalecki@gmail.com"
            //    }
            //};


            //var clientGenerator = new Faker<Client>(locale)
            //    .RuleFor(a => a.Name, f => f.Person.FullName)
            //    .RuleFor(a => a.StreetName, f => f.Address.StreetName())
            //    .RuleFor(a => a.StreetNumber, f => f.Address.StreetAddress())
            //    .RuleFor(a => a.PostCode, f => f.Address.ZipCode())
            //    .RuleFor(a => a.City, f => f.Address.City())
            //    .RuleFor(a => a.Country, "POLSKA")
            //    .RuleFor(a => a.CreatedDate, f => f.Date.Past(2));

            //var clients = clientGenerator.Generate(100);

            //var contactGenerator = new Faker<Contact>(locale)
            //    .RuleFor(a => a.Name, f => f.Person.FullName)
            //    .RuleFor(a => a.Email, f => f.Person.Email)
            //    .RuleFor(a => a.PhoneNumber, f => f.Phone.PhoneNumber())
            //    .RuleFor(a => a.CreatedDate, f => f.Date.Past(2))
            //    .RuleFor(a => a.Client, f => clientGenerator.Generate());

            //var contacts = contactGenerator.Generate(200);

            //var jobGenerator = new Faker<Job>(locale)
            //    .RuleFor(a => a.Subject, f => f.Commerce.ProductName())
            //    .RuleFor(a => a.Description, f => f.Commerce.ProductDescription())
            //    .RuleFor(a => a.CreatedDate, f => f.Date.Past(2))
            //    .RuleFor(a => a.SaleAmount, f => f.Finance.Amount(1000, 500000))
            //    .RuleFor(a => a.DateOfNextActivity, f => f.Date.Future(1))
            //    .RuleFor(a => a.DateOfNextActivity, f => f.Date.Future(1))
            //    .RuleFor(a => a.User, f => f.Random.ListItem(users))
            //    .RuleFor(a => a.Type, f => f.PickRandom<TypeOfJob>())
            //    .RuleFor(a => a.Client, f => clientGenerator.Generate());

            //var jobs = jobGenerator.Generate(500);
            //context.AddRange(users, clients, contacts, jobs);
            //context.SaveChanges();
        }
    }
}
