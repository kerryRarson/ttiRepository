using FluentNHibernate.Mapping;
using TTI.DAL.Model;

namespace TTI.DAL.Maps
{
    public class EntityTypeMap : ClassMap<EntityType>
    {
        public EntityTypeMap()
        {
            Schema("lookup");
            Table("entityType");
            Id(x => x.EntityTypeId);
            Map(x => x.EntityTypeDescription).Column("entityTypeDesc");
        }
    }
}
