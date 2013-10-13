using FluentNHibernate.Mapping;
using TTI.DAL.Model;

namespace TTI.DAL.Maps
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Table("tUser");
            Id(x => x.UserID).Column("iUser_ID");
            Map(x => x.UserName).Column("sUserName");
            Map(x => x.Active).Column("bActive");
            Map(x => x.LastUpdated).Column("dtLastUpdated");
            Map(x => x.LastUpdatedBy).Column("sLastUpdatedBy");
            References(x => x.Entity).Column("iEntity_ID");
            Map(x => x.LastLoginDate).Column("dtLastLoginDate");
        }
    }
}
