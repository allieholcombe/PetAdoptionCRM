using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PetAdoptionCRM.Models
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationContext()
        {

        }

        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Species> Species { get; set; }

        public ApplicationContext(DbContextOptions options) : base(options)
        {

        }

        //Connects to Azure SQL Server
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=tcp:petadoptioncrm.database.windows.net,1433;Initial Catalog=PetAdoptionCRM_db;Persist Security Info=False;User ID=AllieH;Password=Thispw12!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}