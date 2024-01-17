using EllipticCurve.Utils;
using Microsoft.EntityFrameworkCore;
using Online_Ticket_System_forMVC_Sytem.Models;
using System.Data;
using System.Security;

namespace Online_Ticket_System_forMVC_Sytem.DataAcces
{
    public interface IApplicationDbContext
    {
        DbSet<Contact> Contacts { get; }
        DbSet<Customer> Customers { get; }
        DbSet<Organization> Organizations { get; }
        DbSet<Product> Products { get; }
        DbSet<SupportAgent> SupportAgents { get; }
        DbSet<SupportEngineer> SupportEngines { get; }
        DbSet<Ticket> Tickets { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}