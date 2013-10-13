
namespace TTI.DAL.Model
{
    public class CompanyType
    {
        public virtual int CompanyTypeID { get; set; }
        public virtual string Name { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
