using BankApiRESTful.Application.Interfaces;
using BankApiRESTful.Domain.Common;
using BankApiRESTful.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BankApiRESTful.Persintence.Contexts
{
    public class AppDbContext : DbContext
    {
        private readonly IDateTimeService _dateTimeService;

        public AppDbContext(DbContextOptions<AppDbContext> options, IDateTimeService dateTime, IDateTimeService dateTimeService) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            _dateTimeService = dateTimeService;
        }

        public DbSet<Customer> customers { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableBaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Created = _dateTimeService.NowUtc;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModified = _dateTimeService.NowUtc;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
