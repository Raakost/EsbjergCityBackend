﻿using System;
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

namespace EsbjergCityBackend.Controllers
{
    public class OrdersController : ApiController
    {
        private readonly IRepository<Order> _or = new Facade().GetOrderRepo();

        [AllowAnonymous]
        //[Authorize(Roles = "Admin")]
        //[HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        public List<Order> GetOrders()
        {
            return _or.GetAll();
        }

        [AllowAnonymous]
        //[Authorize(Roles = "Admin")]
        //[HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
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

        [AllowAnonymous]
        //[Authorize(Roles = "Admin")]
        //[HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
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

        [AllowAnonymous]
        //[Authorize(Roles = "Admin")]
        //[HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        [ResponseType(typeof(Order))]
        public IHttpActionResult PostOrder(Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _or.Create(order);
            return CreatedAtRoute("DefaultApi", new { id = order.Id }, order);
        }

        [AllowAnonymous]
        //[Authorize(Roles = "Admin")]
        //[HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
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