using System.Collections.Generic;
using System.Linq;
using NHibernate;
using NHibernate.Criterion;
using TTI.DAL.Model;

namespace TTI.DAL.Repository.NHibernate
{
    public class UserRepository : NHibernateRepository<User>, IUserRepository
    {
        public IList<User> GetByEntityId(long entityID)
        {
            return _session.QueryOver<User>()
                .JoinQueryOver(u => u.Entity)
                .Where(u => u.EntityID == entityID)
                .And(u => u.Active == true)
                .List().OrderByDescending(u => u.LastLoginDate).ToList();
        }
    }
}
