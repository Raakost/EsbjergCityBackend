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
    public class GiftCardTest
    {
        IRepository<GiftCard> _gr = new Facade().GetGiftcardRepo();

        public static int createdId;
        private GiftCard g = null;

        [TestMethod]
        public void TestCreateGiftCard()
        {
            g = new GiftCard()
            {
                Amount = 111,
                CardNumber = "TestNumber0123"
            };
            var created = _gr.Create(g);
            createdId = created.Id;
            Assert.IsTrue(createdId != 0);
        }

        [TestMethod]
        public void TestReadAllGiftCards()
        {
            Assert.IsTrue(_gr.GetAll() != null);
        }

        [TestMethod]
        public void TestReadGiftCard()
        {
            var getById = _gr.Get(createdId);
            Assert.IsTrue(getById != null);
        }

        [TestMethod]
        public void UpdateGiftCard()
        {
            var getById = _gr.Get(createdId);
            getById.CardNumber = "TestNumber1234";
            _gr.Update(getById);
            var readByIdAgain = _gr.Get(createdId);
            Assert.IsTrue(readByIdAgain.CardNumber == "TestNumber1234");
        }

        [TestMethod]
        public void TestDeleteGiftCard()
        {
            var readByIdAgain = _gr.Get(createdId);
            _gr.Delete(readByIdAgain);
            var isDeleted = _gr.Get(createdId);
            Assert.IsTrue(isDeleted == null);
        }
    }
}
