using Aw2.Data.Context;
using Aw2.Data.Domains;

namespace Aw2.Data.Repository;

public class StaffRepository : GenericRepository<Staff>, IStaffRepository
{
    public StaffRepository(Aw2DbContext context) : base(context)
    {

    }
}
