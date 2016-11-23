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
                //List<GiftCard> giftCards = new List<GiftCard>();
                return null;
            }
        }

        public Order Get(int id)
        {
            using (var db = new EsbjergCityContext())
            {
                return db.Orders.FirstOrDefault(x => x.Id == id);
            }
        }

        public List<Order> GetAll()
        {
            using (var db = new EsbjergCityContext())
            {
                return db.Orders.Include("GiftCards").ToList();
            }
        }

        public bool Remove(Order t)
        {
            throw new NotImplementedException();
        }

        public Order Update(Order t)
        {
            throw new NotImplementedException();
        }
    }
}