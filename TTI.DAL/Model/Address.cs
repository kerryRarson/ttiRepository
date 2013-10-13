using System;

namespace TTI.DAL.Model
{
    public class Address
    {
        public virtual long AddressID { get; set; }
        public virtual long StateID { get; set; }
        public virtual State State { get; set; }
        public virtual string Address1 { get; set; }
        public virtual string Address2 { get; set; }
        public virtual string City { get; set; }
        public virtual string Zip { get; set; }
        public virtual float Lat { get; set; }
        public virtual float Lon { get; set; }

        public override string ToString()
        {
            string addr = Address1;
            if (!string.IsNullOrEmpty(Address2))
                addr += " " + Address2;
            addr += " " + City;
            addr += ", " + State.ToString();
            addr += " " + Zip;

            return addr;
        }
    }
}
