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
using DataAccessLayer;
using Microsoft.AspNet.Identity;
using DataAccessLayer.Repository;

namespace EsbjergCityBackend.Controllers
{
    public class GiftCardsController : ApiController
    {
        private readonly GiftCardRepo _gr = new Facade().GetGiftcardRepo();

        [Authorize(Roles = "Admin")]
        // GET: api/GiftCards
        public List<GiftCard> GetGiftCards()
        {
            return _gr.GetAll();
        }

        [Authorize(Roles = "Admin")]
        // GET: api/GiftCards/5
        [ResponseType(typeof(GiftCard))]
        public IHttpActionResult GetGiftCard(int id)
        {
            GiftCard giftCard = _gr.Get(id);
            if (giftCard == null)
            {
                return NotFound();
            }

            return Ok(giftCard);
        }

        [Authorize(Roles = "Admin")]
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

            _gr.Update(giftCard);

            return StatusCode(HttpStatusCode.NoContent);
        }

        [AllowAnonymous]
        // GET: api/GiftCards
        [Route("api/giftcards/GetByCardNumber/{cardNumber}")]
        public IHttpActionResult GetByCardNumber(string cardNumber)
        {
            GiftCard giftCard = _gr.GetByCardNumber(cardNumber);
            if (giftCard == null)
            {
                return NotFound();
            }

            return Ok(giftCard);
        }

        // POST: api/GiftCards
        [Authorize(Roles = "Admin, User")]
        [ResponseType(typeof(GiftCard))]
        public IHttpActionResult PostGiftCard(GiftCard giftCard)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _gr.Create(giftCard);

            return CreatedAtRoute("DefaultApi", new { id = giftCard.Id }, giftCard);
        }

        [Authorize(Roles = "Admin")]
        // DELETE: api/GiftCards/5
        [ResponseType(typeof(GiftCard))]
        public IHttpActionResult DeleteGiftCard(int id)
        {
            GiftCard giftCard = _gr.Get(id);
            if (giftCard == null)
            {
                return NotFound();
            }

            _gr.Delete(giftCard);
            return Ok(giftCard);
        }
    }
}