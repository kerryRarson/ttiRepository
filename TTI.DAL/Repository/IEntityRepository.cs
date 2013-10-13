using System.Collections.Generic;
using TTI.DAL.Model;

namespace TTI.DAL.Repository
{
    public interface IEntityRepository : IRepository<Entity>
    {
        /// <summary>
        /// Extending IRepository is appropriate when you need class-specific
        /// functionality that IRepository doesn't provide. Therefore, the
        /// function name should be named to fit the business requirement.
        /// </summary>
        IList<Entity> GetEntitiesByParentId(long parentEntityID);
        IList<Entity> GetEntitiesByState(string stateAbbreviation);
        IList<State> GetStateList();
        Entity LoadEntity(long entityID);
        IList<Entity> SearchByName(string searchText);

    }
}
