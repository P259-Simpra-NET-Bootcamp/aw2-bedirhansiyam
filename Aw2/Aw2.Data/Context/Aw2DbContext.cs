using Aw2.Base.Models;
using Aw2.Data.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Net.Http;

namespace Aw2.Data.Context;

public class Aw2DbContext : DbContext
{
    public Aw2DbContext(DbContextOptions<Aw2DbContext> options) : base(options)
    {

    }

    public DbSet<Staff> Staff { get; set; }

    public override int SaveChanges()
    {
        AddTimestamps();
        return base.SaveChanges();
    }

    private void AddTimestamps()
    {
        var entities = ChangeTracker.Entries().Where(x => x.Entity is BaseModel && (x.State == EntityState.Added || x.State == EntityState.Modified));

        foreach (var entity in entities)
        {
            if (entity.State == EntityState.Added)
            {
                ((BaseModel)entity.Entity).CreatedAt = DateTime.UtcNow;
            }
            else if(entity.State == EntityState.Modified)
            {
                ((BaseModel)entity.Entity).UpdatedAt = DateTime.UtcNow;
            }
        }
    }
}