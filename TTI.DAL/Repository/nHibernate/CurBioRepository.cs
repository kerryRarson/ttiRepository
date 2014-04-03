using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NHibernate;
using NHibernate.Criterion;
using TTI.DAL.Model;

namespace TTI.DAL.Repository.nHibernate
{
    public class CurBioRepository : DPIRepository<CurBio>, ICurBioRepository
    {
        public IList<CurBio> GetPlayersByClub(string club)
        {
            IList<CurBio> returnVal = null;
            returnVal = _session.CreateCriteria<CurBio>()
                .Add(Restrictions.Eq("Team", club))
                .Add(Restrictions.Eq("Year", System.DateTime.Now.Year))
                .AddOrder(new Order("Name", true))
                .List<CurBio>();
            //var criteria = _session.CreateCriteria(typeof(CurBio));
            //criteria.SetProjection(
            //    Projections.Distinct(Projections.ProjectionList()
            //    .Add(Projections.Alias(Projections.Property("Team"), "Team"))
            //    )
            //);
            
            return returnVal;
        }


      
        public IList<string> GetClubs()
        {
            var sql = string.Format("select distinct name_abbrev from global.team_history where sport_code = 'mlb'  and year = {0} order by name_abbrev", 2014);
            var query = _session.CreateSQLQuery(sql);
            //var result = query.UniqueResult();
            var result = query.List<string>();
            return result;
        }
    }
}
