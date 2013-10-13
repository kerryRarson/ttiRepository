using FluentNHibernate.Mapping;
using TTI.DAL.Model;

namespace TTI.DAL.Maps
{
    public class CompanyTypeMap : ClassMap<CompanyType>
    {
        public CompanyTypeMap()
        {
            Table("tCompanyType");
            Id(x => x.CompanyTypeID).Column("iCompanyType_ID").GeneratedBy.Assigned();
            Map(x => x.Name).Column("sCompanyType");
        }
    }
}
