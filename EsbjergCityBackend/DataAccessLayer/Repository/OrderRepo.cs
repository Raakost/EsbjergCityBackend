using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using DataAccessLayer.Context;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Repository
{
    class OrderRepo : IRepository<Order>
    {
        public Order Create(Order t)
        {
            using (var db = new EsbjergCityContext())
            {
                List<GiftCard> giftCards = new List<GiftCard>();
                foreach (var i in t.GiftCards)
                {
                    giftCards.Add(db.GiftCards.FirstOrDefault(x => x.Id == t.Id));
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
                db.Entry(db.Orders.FirstOrDefault(x => x.Id == t.Id)).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
                return db.Orders.FirstOrDefault(x => x.Id == t.Id) == null;
            }
        }

        public Order Update(Order t)
        {
            using (var db = new EsbjergCityContext())
            {
                db.Entry(t).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return t;
            }
        }
    }
}