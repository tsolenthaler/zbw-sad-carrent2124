using Microsoft.AspNetCore.Mvc;
using Zbw.Carrent.CarManagement.Api.Models;
using Zbw.Carrent.CarManagement.Domain;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Zbw.Carrent.CarManagement.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private ICarRepository _repository;

        public CarController(ICarRepository repository)
        {
            ArgumentNullException.ThrowIfNull(repository);
            _repository = repository;
        }
        // GET: api/<CarController>
        [HttpGet]
        public IEnumerable<CarResponse> Get()
        {
            var cars = _repository.GetAll();
            return cars.Select(c => new CarResponse(c.Id, c.CarNr, c.CarBrand, c.CarCategory, c.CarModel));
        }

        // GET api/<CarController>/5
        [HttpGet("{id}")]
        public CarResponse Get(Guid id)
        {
            var car = _repository.Get(id);
            if (car != null)
                return new CarResponse(car.Id, car.CarNr, car.CarBrand, car.CarCategory, car.CarModel);
            return null;
        }

        // POST api/<CarController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CarController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CarController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
