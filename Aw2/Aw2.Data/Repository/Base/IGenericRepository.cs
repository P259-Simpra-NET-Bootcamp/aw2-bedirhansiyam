using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Aw2.Data.Repository;

public interface IGenericRepository<Entity> where Entity : class
{
    DbSet<Entity> Table { get; }
    IQueryable<Entity> GetAll();
    IQueryable<Entity> GetWhere(Expression<Func<Entity, bool>> predicate);
    Entity GetById(int id);
    Task<bool> AddAsync(Entity entity);
    bool Update(Entity entity);
    bool Delete(Entity entity);
    bool DeleteById(int id);

}
