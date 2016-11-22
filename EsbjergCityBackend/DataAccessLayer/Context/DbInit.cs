using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Context
{
    public class DbInit : CreateDatabaseIfNotExists<EsbjergCityContext>
    {
        protected override void Seed(EsbjergCityContext db)
        {
            var g1 = new GiftCard() { Amount = 200.00, Id = 1, CardNumber = "123" };
            var g2 = new GiftCard() { Amount = 500.00, Id = 2, CardNumber = "789" };
            var g3 = new GiftCard() { Amount = 1000.00, Id = 3, CardNumber = "456" };

            var o1 = new Order() { DateOfPurchase = DateTime.Now, GiftCards = new List<GiftCard>() { g1, g2 } };
            var o2 = new Order() { DateOfPurchase = DateTime.Now, GiftCards = new List<GiftCard>() { g3 } };

            var a1 = new Admin()
            {
                Email = "admin@esbjerg.dk",
                Firstname = "Brigitta",
                Lastname = "Jensen",
                Password = "pw"
            };

            var e1 = new Event()
            {
                DateOfEvent = DateTime.Now,
                Description = "Test Event description",
                Title = "event title",
                Img = "img test"
            };

            var c1 = new Customer()
            {
                Firstname = "jens",
                Lastname = "bobbo",
                City = "Esbjerg",
                Zipcode = 6700,
                Email = "jens@esbjerg.dk",
                Password = "",
                Orders = new List<Order>() { o1 }
            };

            var c2 = new Customer()
            {
                Firstname = "Hans",
                Lastname = "Hansen",
                City = "Esbjerg",
                Zipcode = 6700,
                Email = "hans@esbjerg.dk",
                Password = "",
                Orders = new List<Order>() { o2 }
            };

            var c3 = new Customer()
            {
                Firstname = "Lars",
                Lastname = "Larsen",
                City = "Esbjerg",
                Zipcode = 6700,
                Email = "lars@esbjerg.dk",
                Password = "",
                Orders = new List<Order>() { }
            };

            db.Customers.Add(c1);
            db.Customers.Add(c2);
            db.Customers.Add(c3);
            db.Events.Add(e1);
            db.Admins.Add(a1);

            base.Seed(db);
        }
    }
}
