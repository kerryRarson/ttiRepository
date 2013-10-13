using System.Collections.Generic;
using TTI.DAL.Model;

namespace TTI.DAL.Repository
{
    public interface ICompanyRepository : IRepository<Company>
    {
        /// <summary>
        /// Extending IRepository is appropriate when you need class-specific
        /// functionality that IRepository doesn't provide. Therefore, the
        /// function name should be named to fit the business requirement.
        /// </summary>
        //Company GetCompanyByName(string companyName);
        IList<Company> GetCompaniesByState(string state);
    }
}
