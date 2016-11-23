using System;
using System.Collections.Generic;
using System.Linq;
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
                return db.Customers.Include("Orders").ToList();
            }
        }

        public Customer Get(int id)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Customer t)
        {
            throw new NotImplementedException();
        }

        public Customer Update(Customer t)
        {
            throw new NotImplementedException();
        }

        public Customer Create(Customer t)
        {
            throw new NotImplementedException();
        }
    }
}
