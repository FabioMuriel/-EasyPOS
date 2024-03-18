using Domain.Customers;
using Microsoft.EntityFrameworkCore;

namespace Aplication.Data;

public interface IAplicationDbContext
{
    DbSet<Customer> Customers { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}