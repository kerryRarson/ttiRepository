using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TTI.DAL.Tests
{
    [TestClass]
    public class DALTests
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

            Console.WriteLine("returned {0} entities", entities.Count.ToString());
            
            Model.Address address = null;
            foreach (var entity in entities)
            {
                rowCount++;
                if (rowCount > 2) break;
                address = repository.Get(entity.Company.MailingAddress.AddressID);
                Assert.IsNotNull(address);
                Console.WriteLine(" row {0}: {1}   state: {2}", rowCount, address, address.State.FullName);
            }

            Console.WriteLine();
            Console.WriteLine("Getting Entity by Id...");

            var entityById = entityRepository.LoadEntity(entities.First().EntityID);
            Assert.IsNotNull(entityById);
            Console.WriteLine("returned {0} - type {1}", entityById, entityById.EntityType.EntityTypeDescription);
            Assert.IsTrue(entities.First().GetType().Name.Equals(entityById.GetType().Name));
            Assert.AreEqual(entities.First().EntityID, entityById.EntityID);


        }
    }
}
