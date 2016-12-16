using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DataAccessLayer.Entities;
using DataAccessLayer.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EsbjergCityBackend.Tests.RepoTest
{
    [TestClass]
    public class CustomerTest
    {
        CustomerRepo _cr = new Facade().GetCustomerRepo();
        Customer c = null;

        [TestMethod]
        public void TestCreateCustomer()
        {
            c = new Customer()
            {
                Firstname = "Test",
                Lastname = "Test",
                Email = "test@test.dk",
                Street = "EsbjergGade",
                StreetNumber = 1,
                Zipcode = 1111,
                City = "Esbjerg"
            };
            var createdCustomer = _cr.Create(c);
            Assert.IsTrue(createdCustomer.Id != 0);
        }

        [TestMethod]
        public void TestReadAllCustomers()
        {
            Assert.IsTrue(_cr.GetAll() != null);
        }

        [TestMethod]
        public void TestReadCustomer()
        {
            var readByEmail = _cr.GetByEmail("test@test.dk");
            Assert.IsTrue(readByEmail != null);
        }

        [TestMethod]
        public void UpdateCustomer()
        {
            var readByEmail = _cr.GetByEmail("test@test.dk");
            readByEmail.Street = "Esbjerg Gade";
            _cr.Update(readByEmail);
            var readByEmailAgain = _cr.GetByEmail("test@test.dk");
            Assert.IsTrue(readByEmailAgain.Street == "Esbjerg Gade");
        }

        [TestMethod]
        public void TestDeleteCustomer()
        {
            var toDelete = _cr.GetByEmail("test@test.dk");
            _cr.Delete(toDelete);
            var isDeleted = _cr.GetByEmail("test@test.dk");
            Assert.IsTrue(isDeleted == null);
        }
    }
}
