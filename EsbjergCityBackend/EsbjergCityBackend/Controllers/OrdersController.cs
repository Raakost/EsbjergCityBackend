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
using DataAccessLayer;
using DataAccessLayer.Context;
using DataAccessLayer.Entities;

namespace EsbjergCityBackend.Controllers
{
    public class OrdersController : ApiController
    {        
        private readonly IRepository<Order> _or = new Facade().GetOrderRepo();

        [HttpGet]
        public List<Order> GetOrders()
        {
            return _or.GetAll();
        }

        [HttpGet]
        [ResponseType(typeof(Order))]
        public IHttpActionResult GetOrder(int id)
        {
            Order order = _or.Get(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOrder(int id, Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != order.Id)
            {
                return BadRequest();
            }
            _or.Update(order);
            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpPost]
        [ResponseType(typeof(Order))]
        public IHttpActionResult PostOrder(Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _or.Create(order);
            return CreatedAtRoute("DefaultApi", new {id = order.Id}, order);
        }

        [HttpDelete]
        [ResponseType(typeof(Order))]
        public IHttpActionResult DeleteOrder(int id)
        {
            Order order = _or.Get(id);
            if (order == null)
            {
                return NotFound();
            }
            _or.Delete(order);
            return Ok(order);
        }
    }
}