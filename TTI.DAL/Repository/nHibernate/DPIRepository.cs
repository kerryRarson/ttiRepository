using System.Collections.Generic;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace TTI.DAL.Repository.nHibernate
{
    public class DPIRepository<T> : IRepository<T> where T : class
    {
        protected Configuration config;
        protected ISessionFactory sessionFactory;
        protected readonly ISession _session;


        public DPIRepository()
        {
            log4net.Config.XmlConfigurator.Configure();
            // TODO  - this should be in a .config somewhere!
            config = Fluently.Configure()
                .Database(
                    MsSqlConfiguration
                    .MsSql2008
                    .DefaultSchema("dbo")
                    .ConnectionString(CONN))
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<DPIRepository<T>>())
                .BuildConfiguration();
            if (sessionFactory == null)
            {
                sessionFactory = config.BuildSessionFactory();
                _session = sessionFactory.OpenSession();
            }
        }

        public T Get(object id)
        {

            T returnVal = _session.Get<T>(id);
            return returnVal;
        }

        public void Save(T value)
        {
            using (var transaction = _session.BeginTransaction())
            {
                _session.Save(value);
                transaction.Commit();
            }
        }

        public void Update(T value)
        {
            using (var session = sessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                session.Update(value);
                transaction.Commit();
            }
        }

        public void Delete(T value)
        {
            using (var transaction = _session.BeginTransaction())
            {
                _session.Delete(value);
                transaction.Commit();
            }
        }

        public IList<T> GetAll()
        {
            using (var session = sessionFactory.OpenSession())
            {
                IList<T> returnVal = session.CreateCriteria<T>().List<T>();
                return returnVal;
            }
        }

        public void GenerateSchema(SanityCheck AreYouSure)
        {
            new SchemaExport(config).Execute(true, true, false);
        }
    }

   
}
