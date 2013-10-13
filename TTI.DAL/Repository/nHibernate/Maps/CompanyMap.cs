using FluentNHibernate.Mapping;
using TTI.DAL.Model;

namespace TTI.DAL.Maps
{
    public class CompanyMap : ClassMap<Company>
    {
        public CompanyMap()
        {
            Table("tCompany");
            Id(x => x.CompanyID).Column("iCompany_ID");
            Map(x => x.WYO).Column("sWYO");
            Map(x => x.Name).Column("sName");
            Map(x => x.LegalName).Column("sLegalName");
            Map(x => x.Phone).Column("sPhone");
            Map(x => x.Website).Column("sWebsite");
            References(x => x.CompanyType).Column("iCompanyType_ID");//.Not.LazyLoad();
            References(x => x.MailingAddress).Column("iMailingAddress_ID");//.Not.LazyLoad();
            References(x => x.PrimaryAddress).Column("iAddress_ID");//.Not.LazyLoad();
            References(x => x.ResidencyState).Column("iResidencyState_ID");//.Not.LazyLoad();
            Map(x => x.AMBestRating).Column("sAmBestRating");
            Map(x => x.Active).Column("bActive");
            Map(x => x.RedirectURL).Column("sredirecturl");
            Map(x => x.TerminationMessage).Column("sTerminationMessage");
            Map(x => x.ShortName).Column("ShortName");
            Map(x => x.SetupDate).Column("dtSetup");
            Map(x => x.TerminationDate).Column("dtTermination");
            Map(x => x.Logo).Column("sLogo");
            Map(x => x.CreatedDate).Column("dtCreated");
            Map(x => x.CreatedBy).Column("icreatedbyUser_id");
            Map(x => x.PayCommissionsAtInception).Column("bPayCommissionsAtInception").Not.Nullable();
            Map(x => x.EnforceNonResLicensing).Column("bEnforceNonResLicensing").Not.Nullable();
            Map(x => x.CommissionOverage).Column("bCommissionOverage").Not.Nullable();
            Map(x => x.CommissionPaidAtInception).Column("bCommissionPaidAtInception").Not.Nullable();
            Map(x => x.NonResidentsLicense).Column("bNonResidentsLicense").Not.Nullable();
            Map(x => x.NewAgencySetup).Column("bNewAgencySetup").Not.Nullable();
            Map(x => x.Maintain1099).Column("bMaintain1099").Not.Nullable();
            Map(x => x.UpdateAgencyInfo).Column("bUpdateAgencyInfo").Not.Nullable();
            Map(x => x.RequireAgentEo).Column("bRequireAgentEo").Not.Nullable();
            Map(x => x.RequireAgentLicense).Column("bRequireAgentLicense").Not.Nullable();
            Map(x => x.PolicyTransfers).Column("bPolicyTransfers").Not.Nullable();
            Map(x => x.AgentTerminations).Column("bAgentTerminations").Not.Nullable();
            Map(x => x.BookOfBusinessTransfer).Column("bBookOfBusinessTransfer").Not.Nullable();
            Map(x => x.CommissionCap).Column("bCommissionCap").Not.Nullable();
            Map(x => x.CommissionCapAmount).Column("mCommissionCapAmount").Not.Nullable();
            Map(x => x.PayCommissionsToCompany).Column("bPayCommissionsToCompany").Not.Nullable();
        }
    }
}
