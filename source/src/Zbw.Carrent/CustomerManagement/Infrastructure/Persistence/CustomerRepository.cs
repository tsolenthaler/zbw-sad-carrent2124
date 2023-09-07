namespace Zbw.Carrent.CustomerManagement.Infrastructure.Persistence
{
    using System;
    using System.Collections.Generic;
    using Zbw.Carrent.Context;
    using Zbw.Carrent.CustomerManagement.Domain;

    public class CustomerRepository : ICustomerRepository
    {
        private readonly List<Customer> _customers;
        private readonly CarrentContext _context;

        public CustomerRepository(CarrentContext context)
        {
            _context = context;
        }

        public void Add(Customer customer)
        {
            _context.Add(customer);

            throw new NotImplementedException();
        }

        public Customer Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetAll()
        {
            return _customers;
        }

        public void Remove(Customer customer)
        {
            throw new NotImplementedException();
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
