using System;
namespace TTI.DAL.Model
{
    public class User
    {
        public virtual long UserID { get; set; }
        public virtual string UserName { get; set; }
        public virtual bool Active { get; set; }
        public virtual DateTime LastUpdated { get; set; }
        public virtual string LastUpdatedBy { get; set; }
        public virtual Entity Entity { get; set; }
        public virtual DateTime LastLoginDate { get; set; }
    }
}
