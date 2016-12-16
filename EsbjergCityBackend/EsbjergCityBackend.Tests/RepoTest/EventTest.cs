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
        public void TestReadAllEvent()
        {
            Assert.IsTrue(_er.GetAll() != null);
        }

        [TestMethod]
        public void TestReadEvent()
        {
            var getById = _er.Get(createdId);
            Assert.IsTrue(getById != null);
        }

    }
}
