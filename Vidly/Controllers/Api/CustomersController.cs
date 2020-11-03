using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;
using AutoMapper;

namespace Vidly.Controllers.Api
{
    public class CustomersController : ApiController
    {

        private EntContext _context;

        public CustomersController()
        {
            _context = new EntContext();    
        }

        public IEnumerable<CustomerDto> GetCustomers()
        {
            return _context.Customers
                .Include(c => c.MembershipType)
                .ToList()
                .Select(Mapper.Map<Customer, CustomerDto>);
        }

        public IHttpActionResult getCustomer(int id)
        {
            var customer = _context.Customers
                .Include(c => c.MembershipType)
                .SingleOrDefault(m => m.id == id);

            if(customer  == null)
            {
                return NotFound();
            }
            return Ok(Mapper.Map<Customer, CustomerDto>(customer));
        }

        [HttpPost]
        public IHttpActionResult CreateCustumer(CustomerDto customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var cust = Mapper.Map<CustomerDto, Customer>(customer);
            _context.Customers.Add(cust);
            _context.SaveChanges();

            customer.id = cust.id;

            return Created(Request.RequestUri + "/" + customer.id, customer);
        }

        [HttpPut]
        public void UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var cust = _context.Customers.SingleOrDefault(m => m.id == id);
            if(cust == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            Mapper.Map<CustomerDto, Customer>(customerDto, cust);

            _context.SaveChanges();

        }

        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var cust = _context.Customers.SingleOrDefault(m => m.id == id);
            if(cust == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(cust);
            _context.SaveChanges();

            return Ok(cust);

        }
    }
}
