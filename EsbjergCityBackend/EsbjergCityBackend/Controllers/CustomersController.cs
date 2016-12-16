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
using Microsoft.AspNet.Identity;
using DataAccessLayer.Repository;

namespace EsbjergCityBackend.Controllers
{
    public class CustomersController : ApiController
    {
        private readonly CustomerRepo _cr = new Facade().GetCustomerRepo();

        [Authorize(Roles = "Admin")]        
        // GET: api/Customers
        public List<Customer> GetCustomers()
        {
            return _cr.GetAll();
        }
        // GET: api/Customers/5
        [Authorize(Roles = "Admin, User")]        
        [Route("api/customers/GetByEmail/{userName}/")]
        [ResponseType(typeof(Customer))]
        public IHttpActionResult GetByEmail(string userName)
        {
            Customer customer = _cr.GetByEmail(userName);
            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }


        [Authorize(Roles = "Admin")]        
        // GET: api/Customers/5
        [ResponseType(typeof(Customer))]
        public IHttpActionResult GetCustomer(int id)
        {
            Customer customer = _cr.Get(id);
            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        [Authorize(Roles = "Admin")]        
        // PUT: api/Customers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCustomer(int id, Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != customer.Id)
            {
                return BadRequest();
            }

            _cr.Update(customer);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Customers
        [ResponseType(typeof(Customer))]
        public IHttpActionResult PostCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _cr.Create(customer);

            return CreatedAtRoute("DefaultApi", new { id = customer.Id }, customer);
        }

        [Authorize(Roles = "Admin")]        
        // DELETE: api/Customers/5
        [ResponseType(typeof(Customer))]
        public IHttpActionResult DeleteCustomer(int id)
        {
            Customer customer = _cr.Get(id);
            if (customer == null)
            {
                return NotFound();
            }
            _cr.Delete(customer);
            return Ok(customer);
        }
    }
}