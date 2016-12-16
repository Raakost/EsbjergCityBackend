using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccessLayer.Entities;
using DataAccessLayer.Repository;
using DataAccessLayer;
using System.Collections.Generic;

namespace EsbjergCityBackend.Tests.RepoTest
{
    [TestClass]
    public class RepoTest
    {
        [TestMethod]
        public void CustomerTest()
        {
            CustomerRepo _cr = new Facade().GetCustomerRepo();
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
            //---- Create
            var createdCustomer = _cr.Create(c);
            Assert.IsTrue(createdCustomer.Id != 0);
            //---- Read
            var readByEmail = _cr.GetByEmail("test@test.dk");
            Assert.IsTrue(readByEmail != null);
            //---- Update
            readByEmail.Street = "Esbjerg Gade";
            _cr.Update(readByEmail);
            var readByEmailAgain = _cr.GetByEmail("test@test.dk");
            Assert.IsTrue(readByEmailAgain.Street == "Esbjerg Gade");
            //---- Delete
            var toDelete = _cr.GetByEmail("test@test.dk");
            _cr.Delete(toDelete);
            var isDeleted = _cr.GetByEmail("test@test.dk");
            Assert.IsTrue(isDeleted == null);

        }
        [TestMethod]
        public void EventTest()
        {
            IRepository<Event> _er = new Facade().GetEventRepo();
            Event c = new Event()
            {
                Title = "Test title",
                Description = "Test Description",
                Img = "Test img",
                DateOfEvent = DateTime.Now
            };
            //---- Read
            Assert.IsTrue(_er.GetAll() != null);
            //---- Create
            var created = _er.Create(c);
            int createdId = created.Id;
            Assert.IsTrue(createdId != 0);
            //---- Read
            var getById = _er.Get(createdId);
            Assert.IsTrue(getById != null);
            //---- Update
            getById.Title = "AnotherTestTitle";
            _er.Update(getById);
            var readByIdAgain = _er.Get(createdId);
            Assert.IsTrue(readByIdAgain.Title == "AnotherTestTitle");
            //---- Delete
            var toDelete = _er.Delete(readByIdAgain);
            var isDeleted = _er.Get(createdId);
            Assert.IsTrue(isDeleted == null);
        }
        [TestMethod]
        public void OrderTest()
        {
            IRepository<Order> _or = new Facade().GetOrderRepo();
            CustomerRepo _cr = new Facade().GetCustomerRepo();
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
            var createdCustomer = _cr.Create(c);
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
            //---- Read
            Assert.IsTrue(_or.GetAll() != null);
            //---- Create
            var created = _or.Create(o);
            int createdId = created.Id;
            Assert.IsTrue(createdId != 0);
            //---- Read
            var getById = _or.Get(createdId);
            Assert.IsTrue(getById != null);
            //---- Update
            getById.IsCompleted = true;
            _or.Update(getById);
            var readByIdAgain = _or.Get(createdId);
            Assert.IsTrue(readByIdAgain.IsCompleted == true);
            //---- Delete
            _or.Delete(readByIdAgain);
            var isDeleted = _or.Get(createdId);
            Assert.IsTrue(isDeleted == null);
            _cr.Delete(createdCustomer);
        }
        [TestMethod]
        public void GiftcardTest()
        {
            IRepository<GiftCard> _gr = new Facade().GetGiftcardRepo();
            GiftCard g = new GiftCard()
            {
                Amount = 111,
                CardNumber = "TestNumber0123"
            };
            //---- Read
            Assert.IsTrue(_gr.GetAll() != null);
            //---- Create
            var created = _gr.Create(g);
            int createdId = created.Id;
            Assert.IsTrue(createdId != 0);
            //---- Read
            var getById = _gr.Get(createdId);
            Assert.IsTrue(getById != null);
            //---- Update
            getById.CardNumber = "TestNumber1234";
            _gr.Update(getById);
            var readByIdAgain = _gr.Get(createdId);
            Assert.IsTrue(readByIdAgain.CardNumber == "TestNumber1234");
            //---- Delete
            _gr.Delete(readByIdAgain);
            var isDeleted = _gr.Get(createdId);
            Assert.IsTrue(isDeleted == null);
        }
    }
}
