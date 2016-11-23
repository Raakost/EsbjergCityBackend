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
    class CustomerRepo : IRepository<Customer>
    {
        public List<Customer> GetAll()
        {
            using (var db = new EsbjergCityContext())
            {
                return db.Customers.Include(x => x.Orders.Select(y => y.GiftCards)).ToList();
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
                db.Entry(db.Orders.FirstOrDefault(x => x.Id == t.Id)).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
                return db.Orders.FirstOrDefault(x => x.Id == t.Id) == null;
            }
        }

        public Customer Update(Customer t)
        {
            using (var db = new EsbjergCityContext())
            {
                db.Entry(t).State = System.Data.Entity.EntityState.Modified;
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
