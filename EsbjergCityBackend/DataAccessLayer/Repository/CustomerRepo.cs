using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Context;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Repository
{
    public class CustomerRepo : IRepository<Customer>
    {
        public List<Customer> GetAll()
        {
            using (var db = new EsbjergCityContext())
            {
                return db.Customers.Include(x => x.Orders.Select(y => y.GiftCards)).ToList();
            }
        }
        public Customer GetByEmail(string email)
        {
            using (var db = new EsbjergCityContext())
            {
                return db.Customers.FirstOrDefault(x => x.Email == email);
            }
        }
        public Customer Get(int id)
        {
            using (var db = new EsbjergCityContext())
            {
                return db.Customers.Include(x => x.Orders.Select(y => y.GiftCards)).FirstOrDefault(x => x.Id == id);
            }
        }

        public bool Delete(Customer t)
        {
            using (var db = new EsbjergCityContext())
            {
                var customer = db.Customers.Include(x => x.Orders.Select(y => y.GiftCards)).FirstOrDefault(x => x.Id == t.Id);
                var orders = customer.Orders.ToList();
                var giftCards = customer.Orders.SelectMany(x => x.GiftCards).ToList();
                if (giftCards.Count != 0)
                {
                    foreach (var giftCard in giftCards)
                    {
                        db.Entry(giftCard).State = EntityState.Deleted;
                    }
                }
                if (orders.Count != 0)
                {
                    foreach (var order in orders)
                    {
                        db.Entry(order).State = EntityState.Deleted;
                    }
                }

                db.Entry(customer).State = EntityState.Deleted;
                db.SaveChanges();
                return db.Orders.FirstOrDefault(x => x.Id == t.Id) == null;
            }
        }

        public Customer Update(Customer t)
        {
            using (var db = new EsbjergCityContext())
            {
                db.Entry(t).State = EntityState.Modified;
                db.SaveChanges();
                return t;
            }
        }

        public Customer Create(Customer t)
        {
            using (var db = new EsbjergCityContext())
            {
                db.Customers.Add(t);
                db.SaveChanges();
                return t;
            }
        }
    }
}
