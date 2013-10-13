using System;

namespace TTI.DAL.Model
{
    public class EntityType
    {
        public virtual int EntityTypeId { get; set; }
        public virtual string EntityTypeDescription { get; set; }

        public override string ToString()
        {
            return this.EntityTypeDescription;
        }
    }

    
}
