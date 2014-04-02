using FluentNHibernate.Mapping;
using TTI.DAL.Model;

namespace TTI.DAL.Maps
{
    public class CurBioMap : ClassMap<CurBio>
    {
        public CurBioMap()
        {
            Schema("global");
            Table("curbio");
            Id(x => x.PlayerId).Column("ebis_player_id");
            Map(x => x.Year).Column("year");
            Map(x => x.Name).Column("name");
            Map(x => x.First).Column("first");
            Map(x => x.Last).Column("last");
            Map(x => x.Pos).Column("pos");
            Map(x => x.Team).Column("team_abbrev");
            Map(x => x.TeamId).Column("team_id");
            Map(x => x.Bats).Column("bats");
            Map(x => x.Throws).Column("throws");
        }

    }
}
