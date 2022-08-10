using Bogus;
using CRM.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CRM.Data;

public class AppDbContext : IdentityDbContext<IdentityUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Client> Clients { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Job> Jobs { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);

        builder.Entity<Client>()
            .HasMany(c => c.Contacts)
            .WithOne(e => e.Client)
            .HasForeignKey(s => s.ClientId);
           

        builder.Entity<Job>()
            .HasOne(c => c.Client)
            .WithMany(j => j.Jobs)
            .HasForeignKey(f => f.ClientId)
            .HasForeignKey(u => u.UserId);


        builder.Entity<User>()
            .HasMany(c => c.Jobs)
            .WithOne(u => u.User);



        //builder.Entity<Department>().HasData(
        //        new Department { DepartmentId = 1, DepartmentName = "IT" },
        //        new Department { DepartmentId = 2, DepartmentName = "Finansowy" },
        //        new Department { DepartmentId = 3, DepartmentName = "HR" },
        //        new Department { DepartmentId = 4, DepartmentName = "Zarząd" });




        //builder.Entity<Client>().HasData(

        //new Client { Id = 1, NIP = "8481786247", REGON = "", Name = "Błażej Kołek", CreatedDate = DateTime.Now, Country = "Polska", PostCode = "19-300", City = "Ełk", StreetName = "Zamkowa", StreetNumber = "8a", ApartmentNumber = "1" },
        //new Client { Id = 2, NIP = "5862323956", REGON = "", Name = "Incata", CreatedDate = DateTime.Now, Country = "Polska", PostCode = "81-451", City = "Gdynia", StreetName = "Zwycięstwa", StreetNumber = "96/98", ApartmentNumber = "" }
        //);

        //builder.Entity<Contact>().HasData(
        //new Contact { Id = 1,ClientId = 1, CreatedDate = DateTime.Now, Email = "blazej.kolek@gmail.com", Name = "Błażej Kołek", PhoneNumber = "501208073" },
        //new Contact { Id = 2 , ClientId = 2, CreatedDate = DateTime.Now, Email = "andrzej.jarocki@gmail.com", Name = "Andrzej Jarocki", PhoneNumber = "505187692" },
        //new Contact { Id = 3, ClientId = 1, CreatedDate = DateTime.Now, Email = "anna.marianna@gmail.com", Name = "Anna Mariann", PhoneNumber = "511983458" },
        //new Contact { Id = 4, ClientId = 2, CreatedDate = DateTime.Now, Email = "jozef.karczmarczyk@gmail.com", Name = "Józef Karczmarczyk", PhoneNumber = "509833145" }
        //);


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
            .RuleFor(a => a.NIP, f => f.Random.Long(1000000000,9999999999).ToString())
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
            .RuleFor(a => a.Client, f => f.PickRandom(clients));

        var contacts = contactGenerator.Generate(200);


        var jobGenerator = new Faker<Job>(locale)
            .RuleFor(m => m.Id, f => jobId++)
            .RuleFor(a => a.Subject, f => f.Commerce.ProductName())
            .RuleFor(a => a.Description, f => f.Commerce.ProductDescription())
            .RuleFor(a => a.CreatedDate, f => f.Date.Past(2))
            .RuleFor(a => a.SaleAmount, f => f.Finance.Amount(1000, 500000))
            .RuleFor(a => a.DateOfNextActivity, f => f.Date.Future(1))
            .RuleFor(a => a.DateOfNextActivity, f => f.Date.Future(1))
            .RuleFor(a => a.User, f => f.Random.ListItem(users))
            .RuleFor(a => a.Type, f => f.PickRandom<TypeOfJob>())
            .RuleFor(a => a.Client, f => f.PickRandom(clients));

        var jobs = jobGenerator.Generate(500);

        builder.Entity<User>().HasData(users);
        builder.Entity<Client>().HasData(clients);
        builder.Entity<Contact>().HasData(contacts);
        builder.Entity<Job>().HasData(jobs);
    }
}
