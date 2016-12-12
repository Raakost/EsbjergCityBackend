using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Entities;
using DataAccessLayer.Context;

namespace DataAccessLayer.Repository
{
    public class GiftCardRepo : IRepository<GiftCard>
    {

        public List<GiftCard> GetAll()
        {
            using (var db = new EsbjergCityContext())
            {
                return db.GiftCards.ToList();
            }
        }

        public GiftCard Get(int id)
        {
            using (var db = new EsbjergCityContext())
            {
                return db.GiftCards.FirstOrDefault(x => x.Id == id);
            }
        }

        public GiftCard GetByCardNumber(string cardNumber)
        {
            using (var db = new EsbjergCityContext())
            {
                return db.GiftCards.FirstOrDefault(x => x.CardNumber == cardNumber);
            }
        }

        public bool Delete(GiftCard t)
        {
            using (var db = new EsbjergCityContext())
            {
                db.Entry(t).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
                return true;
            }
        }

        public GiftCard Update(GiftCard t)
        {
            using (var db = new EsbjergCityContext())
            {
                db.Entry(t).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return t;
            }
        }

        public GiftCard Create(GiftCard t)
        {
            using (var db = new EsbjergCityContext())
            {
                db.GiftCards.Add(t);
                db.SaveChanges();
                return t;
            }
        }
    }
}