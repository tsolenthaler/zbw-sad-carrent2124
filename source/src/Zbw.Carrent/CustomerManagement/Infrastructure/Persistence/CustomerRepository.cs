namespace Zbw.Carrent.CustomerManagement.Infrastructure.Persistence
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using Zbw.Carrent.Context;
    using Zbw.Carrent.CustomerManagement.Domain;

    public class CustomerRepository : ICustomerRepository
    {
        private readonly CarrentContext _context;

        public CustomerRepository(CarrentContext context)
        {
            _context = context;
        }
        public IEnumerable<Customer> GetAll()
        {
            return _context.Customers
                .Include(c => c.CustomerNr)
                .Include(c => c.Name)
                .ToList();
        }

        public Customer Get(Guid id)
        {
            return _context.Customers
                .Include(c => c.CustomerNr)
                .Include(c => c.Name)
                .First(c => c.Id == id);
        }

        public void Add(Customer customer)
        {
            _context.Add(customer);
            _context.SaveChanges();
        }

        public Customer Update(Customer customer)
        {
            _context.Customers.Update(customer);
            _context.SaveChanges();
            return customer;
        }

        public void Remove(Customer customer)
        {
            _context.Customers.Remove(customer);
            _context.SaveChanges();
        }

        public void Remove(Guid id)
        {
            _context.Customers.Remove(Get(id));
            _context.SaveChanges();
        }
    }
}
