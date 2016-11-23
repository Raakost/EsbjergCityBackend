using System.Collections.Generic;
using DataAccessLayer;
using DataAccessLayer.Entities;
using DataAccessLayer.Context;
using System.Linq;

namespace DataAccessLayer.Repository
{
     class EventRepo : IRepository<Event>
    {
         public List<Event> GetAll()
         {
            using (var db = new EsbjergCityContext())
            {
                return db.Events.ToList();
            }
        }

         public Event Get(int id)
         {
            using (var db = new EsbjergCityContext())
            {
                return db.Events.FirstOrDefault(x => x.Id == id);
            }
        }

         public bool Remove(Event t)
         {
            using (var db = new EsbjergCityContext())
            {
                db.Entry(t).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
                return true;
            }
        }

         public Event Update(Event t)
         {
            using (var db = new EsbjergCityContext())
            {
                db.Entry(t).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return t;
            }
        }

         public Event Create(Event t)
         {
            using (var db = new EsbjergCityContext())
            {
                db.Events.Add(t);
                db.SaveChanges();
                return t;
            }
        }
    }
}