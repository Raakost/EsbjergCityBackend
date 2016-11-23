﻿using System;
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
            //GIFTCARD
            var g1 = new GiftCard { Amount = 200.00, CardNumber = "123" };
            var g2 = new GiftCard { Amount = 500.00, CardNumber = "789" };
            var g3 = new GiftCard { Amount = 1000.00, CardNumber = "456" };

            //ORDER
            var o1 = new Order { DateOfPurchase = DateTime.Now, GiftCards = new List<GiftCard> { g1, g2 } };
            var o2 = new Order { DateOfPurchase = DateTime.Now, GiftCards = new List<GiftCard> { g3 } };

            //ADMIN
            var a1 = new Admin
            {
                Email = "admin@esbjerg.dk",
                Firstname = "Brigitta",
                Lastname = "Jensen",
                Password = "pw"
            };

            //EVENT
            var e1 = new Event
            {
                DateOfEvent = DateTime.Now,
                Description = "Test Event description",
                Title = "event title",
                Img = "img test"
            };

            //CUSTOMER
            var c1 = new Customer
            {
                Firstname = "jens",
                Lastname = "bobbo",
                City = "Esbjerg",
                Zipcode = 6700,
                Street = "EsbjergGade",
                StreetNumber = 1,
                Email = "jens@esbjerg.dk",
                Password = "",
                Orders = new List<Order> { o1 }
            };

            var c2 = new Customer
            {
                Firstname = "Hans",
                Lastname = "Hansen",
                City = "Esbjerg",
                Zipcode = 6700,
                Street = "EsbjergGade",
                StreetNumber = 2,
                Email = "hans@esbjerg.dk",
                Password = "",
                Orders = new List<Order> { o1, o2 }
            };

            var c3 = new Customer
            {
                Firstname = "Lars",
                Lastname = "Larsen",
                City = "Esbjerg",
                Zipcode = 6700,
                Street = "EsbjergGade",
                StreetNumber = 3,
                Email = "lars@esbjerg.dk",
                Password = "",
                Orders = new List<Order> { }
            };

            //SEED DB
            db.Customers.Add(c1);
            db.Customers.Add(c2);
            db.Customers.Add(c3);
            db.Events.Add(e1);
            db.Admins.Add(a1);

            base.Seed(db);
        }
    }
}
