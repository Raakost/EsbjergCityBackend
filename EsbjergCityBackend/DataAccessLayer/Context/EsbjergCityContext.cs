using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Context
{
    public class EsbjergCityContext : DbContext
    {
        public EsbjergCityContext() : base("EsbjergCity")
        {
            Configuration.ProxyCreationEnabled = false;
            Database.SetInitializer(new DbInit());
        }

        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<GiftCard> GiftCards { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Customer>().HasMany<Order>(o => o.Orders);
            modelbuilder.Entity<Order>().HasMany(g => g.GiftCards);
            base.OnModelCreating(modelbuilder);
        }
    }
}
