using CatalogDomain.Aggregates;
using CatalogDomain.Common;
using CatalogDomain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CatalogInfrastructure.Persistence;

public class CatalogDbContext : DbContext
{
    public DbSet<CatalogItem> Items { get; set; }
    public DbSet<Size> Sizes { get; set; }
    public CatalogDbContext(DbContextOptions<CatalogDbContext> options) :base(options)
    {
        
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CatalogItem>().OwnsMany(i => i.Colors);
        modelBuilder.Entity<CatalogItem>().HasMany(x => x.Sizes).WithMany(o => o.Items);
        modelBuilder.Entity<Size>().HasMany(o => o.Items).WithMany(x => x.Sizes);
        base.OnModelCreating(modelBuilder);
    }
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entities = ChangeTracker.Entries().Where(e => e.Entity is EntityBase 
            && (e.State == EntityState.Added || e.State ==  EntityState.Modified));
        foreach (var entity in entities) 
        {
            ((EntityBase)entity.Entity).LastModifiedDate = DateTime.UtcNow;

            if (entity.State != EntityState.Added) continue;
            ((EntityBase)entity.Entity).CreatedDate = DateTime.UtcNow;
            ((EntityBase)entity.Entity).CreatedBy = "admin";
        }
        return await base.SaveChangesAsync(cancellationToken);
    }
}
