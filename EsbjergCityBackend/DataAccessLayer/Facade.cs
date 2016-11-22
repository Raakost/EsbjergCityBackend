﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Entities;
using DataAccessLayer.Repository;

namespace DataAccessLayer
{
    public class Facade
    {
        private IRepository<Customer> _customerRepository;
        private IRepository<Order> _orderRepository;
        private IRepository<Event> _eventRepository;
        private IRepository<Admin> _adminRepository;
        private IRepository<GiftCard> _giftCardRepository;

        public IRepository<Customer> GetCustomerRepo()
        {
            return _customerRepository ?? (_customerRepository = new CustomerRepo());
        }

        public IRepository<Order> GetOrderRepo()
        {
            return _orderRepository ?? (_orderRepository = new OrderRepo());
        }

        public IRepository<Event> GetEventRepo()
        {
            return _eventRepository ?? (_eventRepository = new EventRepo());
        }

        public IRepository<Admin> GetAdminRepo()
        {
            return _adminRepository ?? (_adminRepository = new AdminRepo());
        }

        public IRepository<GiftCard> GetGiftcardRepo()
        {
            return _giftCardRepository ?? (_giftCardRepository = new GiftCardRepo());
        }
    }
}
