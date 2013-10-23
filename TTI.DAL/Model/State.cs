using System;
/*
* Legacy database entity dbo.tState
*/
namespace TTI.DAL.Model
{
    public class State
    {
        public virtual int StateID { get; set; }
        public virtual string Name { get; set; }
        public virtual string FullName { get; set; }
        public virtual string Code { get; set; }
        public virtual bool Active { get; set; }
        public virtual DateTime LastUpdated { get; set; }
        public virtual string LastUpdatedBy { get; set; }
        public virtual DateTime Created { get; set; }
        public virtual string CreatedBy { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
