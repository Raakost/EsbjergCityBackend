using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DataAccessLayer.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EsbjergCityBackend.Tests.RepoTest
{
    [TestClass]
    public class EventTest
    {
        public static int createdId;
        IRepository<Event> _er = new Facade().GetEventRepo();
        Event c = new Event()
        {
            Title = "Test title",
            Description = "Test Description",
            Img = "Test img",
            DateOfEvent = DateTime.Now
        };

        [TestMethod]
        public void TestCreateEvent()
        {
            var created = _er.Create(c);
            createdId = created.Id;
            Assert.IsTrue(createdId != 0);
        }

        [TestMethod]
        public void TestReadAllEvents()
        {
            Assert.IsTrue(_er.GetAll() != null);
        }

        [TestMethod]
        public void TestReadEvent()
        {
            var getById = _er.Get(createdId);
            Assert.IsTrue(getById != null);
        }

        [TestMethod]
        public void UpdateEvent()
        {
            var getById = _er.Get(createdId);
            getById.Title = "AnotherTestTitle";
            _er.Update(getById);
            var readByIdAgain = _er.Get(createdId);
            Assert.IsTrue(readByIdAgain.Title == "AnotherTestTitle");
        }

        [TestMethod]
        public void TestDeleteEvent()
        {
            var readByIdAgain = _er.Get(createdId);
            var toDelete = _er.Delete(readByIdAgain);
            var isDeleted = _er.Get(createdId);
            Assert.IsTrue(isDeleted == null);
        }

    }
}
