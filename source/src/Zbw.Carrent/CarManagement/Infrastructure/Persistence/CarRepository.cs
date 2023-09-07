using Microsoft.EntityFrameworkCore;
using Zbw.Carrent.CarManagement.Domain;
using Zbw.Carrent.Context;

namespace Zbw.Carrent.CarManagement.Infrastructure.Persistence
{
    public class CarRepository : ICarRepository
    {
        private readonly CarrentContext _context;

        public CarRepository(CarrentContext context) 
        {
            _context = context;
        }
        public IEnumerable<Car> GetAll()
        {
            return _context.Cars
                .Include(c => c.CarBrand)
                .Include(c => c.CarModel)
                .ToList();
        }
        public Car Get(Guid id)
        {
            return _context.Cars
                .Include(c => c.CarBrand)
                .Include(c => c.CarModel)
                .First(c => c.Id == id);
        }
        public void Add(Car car)
        {
            _context.Add(car);
            _context.SaveChanges();
        }
        public Car Update(Car car)
        {
            _context.Cars.Update(car);
            _context.SaveChanges();
            return car;
        }
        public void Remove(Car car)
        {
            _context.Cars.Remove(car);
            _context.SaveChanges();
        }
        public void Remove(Guid id)
        {
            _context.Cars.Remove(Get(id));
            _context.SaveChanges();
        }
    }
}
