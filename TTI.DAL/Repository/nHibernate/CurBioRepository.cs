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
                .AddOrder(new Order("Name", true))
                .List<CurBio>();

            return returnVal;
        }


      
        public IList<string> GetClubs()
        {
            var criteria = _session.CreateCriteria(typeof(CurBio));
            criteria.SetProjection(
                Projections.Distinct(Projections.ProjectionList()
                .Add(Projections.Alias(Projections.Property("Team"), "Team"))
                )
            );
            criteria.SetResultTransformer(new NHibernate.Transform.AliasToBeanResultTransformer(typeof(CurBio)));
            var rtn = criteria.List<CurBio>();
            foreach (var item in rtn)
            {
                System.Diagnostics.Debug.WriteLine(string.Format("Team - {0}", item.Team));
            }
            return new List<string>() { "xxx"};
        }
    }
}
