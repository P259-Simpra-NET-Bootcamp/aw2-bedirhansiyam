using Aw2.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace Aw2.Data.Repository;

public class GenericRepository<Entity> : IGenericRepository<Entity> where Entity : class
{
    private readonly Aw2DbContext _context;

    public GenericRepository(Aw2DbContext context)
    {
        _context = context;
    }

    public DbSet<Entity> Table => _context.Set<Entity>();

    public IQueryable<Entity> GetAll()
    => Table;

    public Entity GetById(int id)
    {
        return Table.Find(id);
    }
    public IQueryable<Entity> GetWhere(Expression<Func<Entity, bool>> predicate)
    {
        return Table.Where(predicate);
    }
    public async Task<bool> AddAsync(Entity entity)
    {
        entity.GetType().GetProperty("CreatedBy").SetValue(entity, "aw2@aw2.com");

        EntityEntry<Entity> entityEntry = await Table.AddAsync(entity);
        return entityEntry.State == EntityState.Added;
    }

    public bool Delete(Entity entity)
    {
        EntityEntry entityEntry = Table.Remove(entity);
        return entityEntry.State == EntityState.Deleted;
    }

    public bool DeleteById(int id)
    {
        Entity model = Table.Find(id);
        return Delete(model);
    }


    public bool Update(Entity entity)
    {

        entity.GetType().GetProperty("CreatedBy").SetValue(entity, "aw2@aw2.com");

        EntityEntry entityEntry = Table.Update(entity);
        return entityEntry.State == EntityState.Modified;
    }
}
