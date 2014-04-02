using System.Collections.Generic;
using TTI.DAL.Model;

namespace TTI.DAL.Repository
{
    public interface ICurBioRepository : IRepository<CurBio>
    {
        IList<CurBio> GetPlayersByClub(string club);
        IList<string> GetClubs();
    }
}
