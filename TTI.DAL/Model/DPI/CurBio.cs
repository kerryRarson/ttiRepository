using System;

namespace TTI.DAL.Model
{
    public class CurBio
    {
        public virtual long PlayerId { get; set; }
        public virtual int Year { get; set; }
        public virtual string Name { get; set; }
        public virtual string Last { get; set; }
        public virtual string First { get; set; }
        public virtual string Use { get; set; }
        public virtual int TeamId { get; set; }
        public virtual string Team { get; set; }
        public virtual string Pos { get; set; }
        public virtual string Bats { get; set; }
        public virtual string Throws { get; set; }

    }
}
