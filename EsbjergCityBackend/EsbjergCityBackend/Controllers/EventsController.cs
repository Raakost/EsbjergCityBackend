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

namespace EsbjergCityBackend.Controllers
{
    public class EventsController : ApiController
    {
        private readonly IRepository<Event> _er = new Facade().GetEventRepo();

        // GET: api/Events
        public List<Event> GetEvents()
        {
            return _er.GetAll();
        }

        // GET: api/Events/5
        [ResponseType(typeof(Event))]
        public IHttpActionResult GetEvent(int id)
        {
            Event _event = _er.Get(id);
            if (_event == null)
            {
                return NotFound();
            }

            return Ok(_event);
        }

        // PUT: api/Events/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEvent(int id, Event _event)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != _event.Id)
            {
                return BadRequest();
            }

            _er.Update(_event);
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Events
        [ResponseType(typeof(Event))]
        public IHttpActionResult PostEvent(Event _event)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _er.Create(_event);

            return CreatedAtRoute("DefaultApi", new { id = _event.Id }, _event);
        }

        // DELETE: api/Events/5
        [ResponseType(typeof(Event))]
        public IHttpActionResult DeleteEvent(int id)
        {
            Event _event = _er.Get(id);
            if (_event == null)
            {
                return NotFound();
            }

            _er.Delete(_event);

            return Ok(_event);
        }
    }
}