using System.Collections.Generic;
using System.Linq;
using NHibernate;
using NHibernate.Criterion;
using TTI.DAL.Model;

namespace TTI.DAL.Repository.NHibernate
{
    public class EntityRepository : NHibernateRepository<Entity>, IEntityRepository
    {

        public IList<Entity> GetEntitiesByParentId(long parentEntityID)
        {
            IList<Entity> returnVal = null;
            returnVal = _session.CreateCriteria<Entity>()
                    .Add(Restrictions.Eq("ParentEntityID", parentEntityID))
                    .Add(Restrictions.Eq("Active", true))
                    .AddOrder(new Order("Name", true))
                    .List<Entity>();
            
            return returnVal;
        }

        public IList<Entity> GetEntitiesByState(string stateAbbreviation)
        {
            IList<Entity> returnVal = null;
            string sql = "exec dbo.GetEntitiesByState @state=:state";
            returnVal = _session.CreateSQLQuery(sql)
                    .AddEntity(typeof(Entity))
                    .SetAnsiString("state", stateAbbreviation)
                    .List<Entity>()
                    .Select(x => new Entity()
                    {
                        EntityID = x.EntityID,
                        CompanyID = x.CompanyID,
                        Company = x.Company,
                        EntityType = x.EntityType,
                        ParentEntityID = x.ParentEntityID,
                        Name = x.Name,
                        LegalName = x.LegalName,
                        WebSite = x.WebSite,
                        Active = x.Active,
                        BrochureURL = x.BrochureURL,
                        SetupDate = x.SetupDate,
                        SpecialInstructions = x.SpecialInstructions,
                        StateLicenseNumber = x.StateLicenseNumber
                    })
                    .ToList();
            return returnVal;
        }

        public IList<State> GetStateList()
        {
            IList<State> states = null;
            //using (var session = sessionFactory.OpenSession())
            //{
                //states = _session.CreateCriteria<State>()
                //    .Add(Restrictions.Eq("Active", true))
                //    .List<State>();
            states = _session.QueryOver<State>()
                .Where(s => s.Active == true)
                .List();
            //}

            return states.OrderBy(x => x.Code).ToList();
        }

        public Company GetCompanyById(long companyId)
        {
            return _session.Get<Company>(companyId);
        }
        public Entity LoadEntity(long entityId)
        {
            //return _session.Get<Entity>(entityId);
            Entity rtn = _session.CreateCriteria<Entity>()
                    .Add(Restrictions.Eq("EntityID", entityId))
                    .SetFetchMode("EntityType", FetchMode.Eager)
                    .SetFetchMode("Company", FetchMode.Eager)
                    .UniqueResult<Entity>();
            return rtn;

        }


        public IList<Entity> SearchByName(string searchText)
        {
            IList<Entity> returnResults = null;
            returnResults = _session.QueryOver<Entity>()
                .WhereRestrictionOn(e => e.Name).IsInsensitiveLike(searchText)
                .OrderBy(e => e.Name).Asc()
                .List<Entity>();
            return returnResults;
        }
    }
}
