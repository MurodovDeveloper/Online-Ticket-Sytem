using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Online_Ticket_System_forMVC_Sytem.Models;

namespace Online_Ticket_System_forMVC_Sytem.DataAcces
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Organization> Organizations { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<SupportAgent> SupportAgents { get; set; }

        public DbSet<SupportEngineer> SupportEngines {  get; set; }

        public DbSet<Ticket> Tickets { get; set; }
    }
}
