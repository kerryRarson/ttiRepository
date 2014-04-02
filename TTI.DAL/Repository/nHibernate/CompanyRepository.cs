using System.Collections.Generic;
using System.Linq;
using NHibernate;
using NHibernate.Criterion;
using TTI.DAL.Model;

namespace TTI.DAL.Repository.nHibernate
{
    public class CompanyRepository : NHibernateRepository<Company>, ICompanyRepository
    {

        public IList<Company> GetCompaniesByState(string state)
        {
            var companies = _session.QueryOver<Company>()
                .JoinQueryOver(x => x.ResidencyState)
                .Where(s => s.Name == state)
                .List();
            return companies;
        }
    }
}
