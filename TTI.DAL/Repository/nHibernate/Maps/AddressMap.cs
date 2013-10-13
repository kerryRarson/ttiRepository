using FluentNHibernate.Mapping;
using TTI.DAL.Model;

namespace TTI.DAL.Maps
{
    public class AddressMap : ClassMap<Address>
    {
        public AddressMap()
        {
            Table("tAddress");
            Id(x=>x.AddressID).Column("iAddress_ID");
            Map(x => x.StateID).Column("iState_ID");
            References(x => x.State).Column("iState_ID");
            Map(x=>x.Address1).Column("sAddress1");
            Map(x=>x.Address2).Column("sAddress2");
            Map(x=>x.City).Column("sCity");
            Map(x=>x.Zip).Column("sZip");
            Map(x=>x.Lat).Column("fLatitude");
            Map(x=>x.Lon).Column("fLongitude");
        }
    }
}
