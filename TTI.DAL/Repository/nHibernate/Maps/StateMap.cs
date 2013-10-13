using FluentNHibernate.Mapping;
using TTI.DAL.Model;

namespace TTI.DAL.Maps
{
    public class StateMap : ClassMap<State>
    {
        public StateMap()
        {
            Table("tState");
            Id(x => x.StateID).Column("iState_ID");
            Map(x => x.Name).Column("sName");
            Map(x => x.FullName).Column("sFullName");
            Map(x => x.Code).Column("sCode");
            Map(x => x.Active).Column("bActive");
            Map(x => x.LastUpdated).Column("dtLastUpdated");
            Map(x => x.LastUpdatedBy).Column("sLastUpdatedBy");
            Map(x => x.Created).Column("dtCreated");
            Map(x => x.CreatedBy).Column("sCreatedBy");
        }
    }
}
