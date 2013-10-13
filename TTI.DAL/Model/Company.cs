using System;

namespace TTI.DAL.Model
{
    public class Company
    {
        public virtual long CompanyID { get; set; }
        public virtual CompanyType CompanyType {get; set;}
        public virtual string WYO { get; set; }
        public virtual string Name { get; set; }
        public virtual string LegalName { get; set; }
        public virtual string Phone { get; set; }
        public virtual string Website { get; set; }
        public virtual State ResidencyState { get; set; }
        public virtual Address MailingAddress { get; set; }
        public virtual Address PrimaryAddress { get; set; }
        public virtual string AMBestRating {get;set;}
        public virtual bool Active { get; set; }
        public virtual string RedirectURL { get; set; }
        public virtual string TerminationMessage { get; set; }
        public virtual string ShortName { get; set; }
        public virtual DateTime SetupDate { get; set; }
        public virtual DateTime TerminationDate { get; set; }
        public virtual string Logo { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual long CreatedBy { get; set; }
        public virtual bool MpppOnFile { get; set; }
        public virtual bool GenerateCommissions { get; set; }
        public virtual bool PayCommissionsAtInception { get; set; }
        public virtual bool EnforceNonResLicensing { get; set; }
        public virtual bool CommissionOverage { get; set; }
        public virtual bool CommissionPaidAtInception { get; set; }
        public virtual bool NonResidentsLicense { get; set; }
        public virtual bool NewAgencySetup { get; set; }
        public virtual bool Maintain1099 { get; set; }
        public virtual bool UpdateAgencyInfo { get; set; }
        public virtual bool RequireAgentEo { get; set; }
        public virtual bool RequireAgentLicense { get; set; }
        public virtual bool PolicyTransfers { get; set; }
        public virtual bool AgentTerminations { get; set; }
        public virtual bool BookOfBusinessTransfer { get; set; }
        public virtual bool CommissionCap { get; set; }
        public virtual decimal CommissionCapAmount { get; set; }
        public virtual bool PayCommissionsToCompany { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
