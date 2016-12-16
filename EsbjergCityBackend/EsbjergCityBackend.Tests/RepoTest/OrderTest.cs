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
    public class OrderTest
    {
        public static int createdId;
        public static Customer createdCustomer = null;

        IRepository<Order> _or = new Facade().GetOrderRepo();
        CustomerRepo _cr = new Facade().GetCustomerRepo();

        [TestMethod]
        public void TestCreateOrder()
        {
            Customer c = new Customer()
            {
                Firstname = "Test",
                Lastname = "Test",
                Email = "test@test.dk",
                Street = "EsbjergGade",
                StreetNumber = 1,
                Zipcode = 1111,
                City = "Esbjerg"
            };
            createdCustomer = _cr.Create(c);
            Assert.IsTrue(createdCustomer.Id != 0);
            Order o = new Order()
            {
                Customer = createdCustomer,
                DateOfPurchase = DateTime.Now,
                GiftCards = new List<GiftCard>()
                {
                    new GiftCard() { Amount = 111, CardNumber = "1" },
                    new GiftCard() { Amount = 222, CardNumber = "2" },
                    new GiftCard() { Amount = 333, CardNumber = "3" },
                    new GiftCard() { Amount = 444, CardNumber = "4" }
                },
                IsCompleted = false
            };

            var created = _or.Create(o);
            createdId = created.Id;
            Assert.IsTrue(createdId != 0);
        }

        [TestMethod]
        public void TestReadAllOrders()
        {
            Assert.IsTrue(_or.GetAll() != null);
        }

        [TestMethod]
        public void TestReadOrder()
        {
            var getById = _or.Get(createdId);
            Assert.IsTrue(getById != null);
        }

        [TestMethod]
        public void UpdateOrder()
        {
            var getById = _or.Get(createdId);
            getById.IsCompleted = true;
            _or.Update(getById);
            var readByIdAgain = _or.Get(createdId);
            Assert.IsTrue(readByIdAgain.IsCompleted == true);
        }

        [TestMethod]
        public void TestDeleteOrder()
        {
            var readByIdAgain = _or.Get(createdId);
            _or.Delete(readByIdAgain);
            var isDeleted = _or.Get(createdId);
            Assert.IsTrue(isDeleted == null);
            _cr.Delete(createdCustomer);
        }
    }
}
