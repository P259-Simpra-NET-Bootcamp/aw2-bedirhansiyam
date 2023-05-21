using Aw2.Data.Domains;
using Aw2.Data.Repository;

namespace Aw2.Data.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    IGenericRepository<Staff> StaffRepository { get; }

    void Complete();
    void CompleteWithTransaction();
}
