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

        //builder.Entity<Client>()
        //    .HasMany(c => c.Contacts)
        //    .WithOne(e => e.Client);

        //builder.Entity<Contact>()
        //    .HasOne(o => o.Client)
        //    .WithMany(e => e.Contacts);
            

        builder.Entity<Department>().HasData(
                new Department { DepartmentId = 1, DepartmentName = "IT" },
                new Department { DepartmentId = 2, DepartmentName = "Finansowy" },
                new Department { DepartmentId = 3, DepartmentName = "HR" },
                new Department { DepartmentId = 4, DepartmentName = "Zarząd" });




        builder.Entity<Client>().HasData(

        new Client { Id = 1, NIP = "8481786247", REGON = "", Name = "Błażej Kołek", CreatedDate = DateTime.Now, Country = "Polska", PostCode = "19-300", City = "Ełk", StreetName = "Zamkowa", StreetNumber = "8a", ApartmentNumber = "1" },
        new Client { Id = 2, NIP = "5862323956", REGON = "", Name = "Incata", CreatedDate = DateTime.Now, Country = "Polska", PostCode = "81-451", City = "Gdynia", StreetName = "Zwycięstwa", StreetNumber = "96/98", ApartmentNumber = "" }
        );

        builder.Entity<Contact>().HasData(
        new Contact { Id = 1,ClientId = 1, CreatedDate = DateTime.Now, Email = "blazej.kolek@gmail.com", Name = "Błażej Kołek", PhoneNumber = "501208073" },
        new Contact { Id = 2 , ClientId = 2, CreatedDate = DateTime.Now, Email = "andrzej.jarocki@gmail.com", Name = "Andrzej Jarocki", PhoneNumber = "505187692" },
        new Contact { Id = 3, ClientId = 1, CreatedDate = DateTime.Now, Email = "anna.marianna@gmail.com", Name = "Anna Mariann", PhoneNumber = "511983458" },
        new Contact { Id = 4, ClientId = 2, CreatedDate = DateTime.Now, Email = "jozef.karczmarczyk@gmail.com", Name = "Józef Karczmarczyk", PhoneNumber = "509833145" }
        );

    }
}
