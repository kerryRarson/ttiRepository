using System.Collections.Generic;
using TTI.DAL.Model;

namespace TTI.DAL.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        IList<User> GetByEntityId(long entityId);
    }
}
