using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using DataAccessLayer.Context;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Repository
{
    class OrderRepo : IRepository<Order>
    {
        public CustomerRepo _cr = new CustomerRepo();
        public Order Create(Order t)
        {
            using (var db = new EsbjergCityContext())
            {
                db.Customers.Attach(t.Customer);
                List<GiftCard> giftCards = new List<GiftCard>();
                foreach (var i in t.GiftCards)
                {
                    giftCards.Add(i);
                }
                t.GiftCards = giftCards;
                db.Orders.Add(t);
                db.SaveChanges();
                return t;
            }
        }

        public Order Get(int id)
        {
            using (var db = new EsbjergCityContext())
            {
                return db.Orders.Include("GiftCards").FirstOrDefault(x => x.Id == id);
            }
        }
        public List<Order> GetAll()
        {
            using (var db = new EsbjergCityContext())
            {
                return db.Orders.Include("GiftCards").ToList();
            }
        }

        public bool Delete(Order t)
        {
            using (var db = new EsbjergCityContext())
            {
                var order = db.Orders.Include("GiftCards").FirstOrDefault(x => x.Id == t.Id);
                foreach (var giftcard in order.GiftCards.ToList())
                {
                    db.Entry(giftcard).State = EntityState.Deleted;
                }
                db.Entry(order).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
                return db.Orders.FirstOrDefault(x => x.Id == t.Id) == null;
            }
        }

        public Order Update(Order t)
        {
            using (var db = new EsbjergCityContext())
            {
                var orderToUpdate = db.Orders.Include("GiftCards").FirstOrDefault(x => x.Id == t.Id);
                if (orderToUpdate != null)
                {
                    orderToUpdate.DateOfPurchase = t.DateOfPurchase;
                    orderToUpdate.IsCompleted = t.IsCompleted;
                }
                db.SaveChanges();
                return t;
            }
        }
    }
}
