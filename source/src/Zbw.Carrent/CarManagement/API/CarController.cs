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
        public CarResponse Post([FromBody] CarRequest value)
        {
            var newCar = new Car
            {
                Id = Guid.NewGuid(),
                CarNr = value.CarNr,
                CarBrand = value.carBrand,
                CarCategory = value.carCategory,
                CarModel = value.carModel
            };
            _repository.Add(newCar);
            return new CarResponse(newCar.Id, newCar.CarNr, newCar.CarBrand, newCar.CarCategory, newCar.CarModel);
        }

        // PUT api/<CarController>/5
        [HttpPut("{id}")]
        public CarResponse Put(Guid id, [FromBody] CarRequest value)
        {
            var car = _repository.Get(id);
            if (car != null)
            {
                car.CarNr = value.CarNr;
                car.CarBrand = value.carBrand;
                car.CarCategory = value.carCategory;
                car.CarModel = value.carModel;
                _repository.Update(car);
                return new CarResponse(car.Id, car.CarNr, car.CarBrand, car.CarCategory, car.CarModel);
            }
            return null;
        }

        // DELETE api/<CarController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            var car = _repository.Get(id);
            if (car != null)
                _repository.Remove(car);

        }
    }
}
