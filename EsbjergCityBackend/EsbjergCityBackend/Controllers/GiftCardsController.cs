using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using DataAccessLayer.Context;
using DataAccessLayer.Entities;

namespace EsbjergCityBackend.Controllers
{
    public class GiftCardsController : ApiController
    {
        private EsbjergCityContext db = new EsbjergCityContext();

        // GET: api/GiftCards
        public IQueryable<GiftCard> GetGiftCards()
        {
            return db.GiftCards;
        }

        // GET: api/GiftCards/5
        [ResponseType(typeof(GiftCard))]
        public IHttpActionResult GetGiftCard(int id)
        {
            GiftCard giftCard = db.GiftCards.Find(id);
            if (giftCard == null)
            {
                return NotFound();
            }

            return Ok(giftCard);
        }

        // PUT: api/GiftCards/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGiftCard(int id, GiftCard giftCard)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != giftCard.Id)
            {
                return BadRequest();
            }

            db.Entry(giftCard).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GiftCardExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/GiftCards
        [ResponseType(typeof(GiftCard))]
        public IHttpActionResult PostGiftCard(GiftCard giftCard)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.GiftCards.Add(giftCard);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = giftCard.Id }, giftCard);
        }

        // DELETE: api/GiftCards/5
        [ResponseType(typeof(GiftCard))]
        public IHttpActionResult DeleteGiftCard(int id)
        {
            GiftCard giftCard = db.GiftCards.Find(id);
            if (giftCard == null)
            {
                return NotFound();
            }

            db.GiftCards.Remove(giftCard);
            db.SaveChanges();

            return Ok(giftCard);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GiftCardExists(int id)
        {
            return db.GiftCards.Count(e => e.Id == id) > 0;
        }
    }
}