using FluentNHibernate.Mapping;
using TTI.DAL.Model;

namespace TTI.DAL.Maps
{
    public class EntityMap : ClassMap<Entity>
    {
        public EntityMap()
        {
            Table("tEntity");
            Id(x => x.EntityID).Column("iEntity_ID");
            Map(x => x.CompanyID).Column("iCompany_ID");
            References(x => x.Company).Column("iCompany_ID");//.Not.LazyLoad();
            //Map(x => x.EntityTypeID).Column("iEntityType_ID");
            References(x => x.EntityType).Column("iEntityType_ID").Not.Update();
            Map(x => x.ParentEntityID).Column("iParent_ID").Not.Update();
            Map(x => x.Name).Column("sName");
            Map(x => x.LegalName).Column("sLegalName");
            Map(x => x.WebSite).Column("sWebsite");
            Map(x => x.Active).Column("bActive");
            Map(x => x.SpecialInstructions).Column("sSpecialInstructions");
            Map(x => x.StateLicenseNumber).Column("sStateLicenseNumber");
            Map(x => x.SetupDate).Column("dtSetup");
            Map(x => x.BrochureURL).Column("BrochureURL");
        }
    }
}
