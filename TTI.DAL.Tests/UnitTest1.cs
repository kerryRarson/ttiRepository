using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TTI.DAL.Tests
{
    [TestClass]
    public class IntegrationTests
    {
        [TestMethod]
        public void AddressRepositoryTests()
        {
            var entityRepository = new TTI.DAL.Repository.NHibernate.EntityRepository();
            var repository = new TTI.DAL.Repository.NHibernate.AddressRepository();

            //get some entities
            var entities = entityRepository.GetEntitiesByState("MT");
            int rowCount = 0;
            Assert.IsTrue(entities.Count > 0);
        }
    }
}
