using System;

namespace TTI.DAL.Model
{
    public class Entity
    {
        public virtual long EntityID { get; set; }
        public virtual long CompanyID {get;set;}
        public virtual Company Company { get; set; }
        public virtual EntityType EntityType { get; set; }
        public virtual long ParentEntityID { get; set; }
        public virtual string Name { get; set; }
        public virtual string LegalName { get; set; }
        public virtual string WebSite { get; set; }
        public virtual bool Active { get; set; }
        public virtual string SpecialInstructions { get; set; }
        public virtual string StateLicenseNumber { get; set; }
        public virtual DateTime SetupDate { get; set; }
        public virtual string BrochureURL { get; set; }

        public override string ToString()
        {
            return this.Name;
        }

    }
}
