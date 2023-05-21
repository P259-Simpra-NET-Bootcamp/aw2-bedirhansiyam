using Aw2.Base.Models;
using Aw2.Data.Context;
using Aw2.Data.Domains;
using Aw2.Data.Repository;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Aw2.Data.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    public IGenericRepository<Staff> StaffRepository { get; private set; }

    private readonly Aw2DbContext _context;

    private bool disposed;

    public UnitOfWork(Aw2DbContext context)
    {
        _context = context;

        StaffRepository = new GenericRepository<Staff>(context);
    }

    public void Complete()
    {
        _context.SaveChanges();
    }

    public void CompleteWithTransaction()
    {
        using(var dbContextTransaction = _context.Database.BeginTransaction())
        {
            try
            {
                _context.SaveChanges();
                dbContextTransaction.Commit();
            }
            catch (Exception ex)
            {
                dbContextTransaction.Rollback();
            }
        }
    }

    public void Clean(bool disposing)
    {
        if(!disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
        disposed = true;
        GC.SuppressFinalize(this);
    }

    public void Dispose()
    {
        Clean(true);
    }

}

