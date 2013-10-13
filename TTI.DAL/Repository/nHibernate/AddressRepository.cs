using System.Collections.Generic;
using System.Linq;
using NHibernate;
using NHibernate.Criterion;
using TTI.DAL.Model;

namespace TTI.DAL.Repository.NHibernate
{
    public class AddressRepository : NHibernateRepository<Address>, IAddressRepository
    {

    }
}
