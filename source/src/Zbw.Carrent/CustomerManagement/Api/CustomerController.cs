namespace Zbw.Carrent.CustomerManagement.Api
{
    using Microsoft.AspNetCore.Mvc;

    using Zbw.Carrent.CustomerManagement.Api.Models;
    using Zbw.Carrent.CustomerManagement.Domain;

    [Route("api/customers")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _repository;

        public CustomerController(ICustomerRepository repository)
        {
            ArgumentNullException.ThrowIfNull(repository);

            _repository = repository;
        }

        // GET: api/<CustomerController>
        [HttpGet]
        public IEnumerable<CustomerResponse> Get()
        {
            var customers = _repository.GetAll();
            return customers.Select(x => new CustomerResponse(x.Id, x.CustomerNr, x.Name, null));
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public CustomerResponse Get(Guid id)
        {
            var customer = _repository.Get(id);
            if (customer != null)
            {
                return new CustomerResponse(customer.Id, customer.CustomerNr, customer.Name, null);
            }
            return null;
        }

        // POST api/<CustomerController>
        [HttpPost]
        public CustomerResponse Post([FromBody] CustomerRequest value)
        {
            var newCustomer = new Customer
            {
                Id = Guid.NewGuid(),
                CustomerNr = value.CustomerNr,
                Name = value.Name
            };
            _repository.Add(newCustomer);
            return new CustomerResponse(newCustomer.Id, newCustomer.CustomerNr, newCustomer.Name, null);
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public CustomerResponse Put(Guid id, [FromBody] CustomerRequest value)
        {
            var customer = _repository.Get(id);
            if (customer != null)
            {
                customer.CustomerNr = value.CustomerNr;
                customer.Name = value.Name;
                _repository.Update(customer);
                return new CustomerResponse(customer.Id, customer.CustomerNr, customer.Name, null);
            }
            return null;
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
        }
    }
}
