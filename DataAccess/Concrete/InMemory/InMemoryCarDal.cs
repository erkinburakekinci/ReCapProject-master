using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>{
            new Car { CarId = 1, BrandId = 1, ColorId = 1, ModelYear = 2010, DailyPrice = 85000, Description = "Açıklama" },
            new Car { CarId = 2, BrandId = 1, ColorId = 1, ModelYear = 2010, DailyPrice = 85000, Description = "Açıklama" },
            new Car { CarId = 3, BrandId = 2, ColorId = 2, ModelYear = 2018, DailyPrice = 250000, Description = "Açıklama" },
            new Car { CarId = 4, BrandId = 3, ColorId = 4, ModelYear = 1992, DailyPrice = 50000, Description = "Açıklama" },
            new Car { CarId = 5, BrandId = 2, ColorId = 2, ModelYear = 2004, DailyPrice = 75000, Description = "Açıklama" }
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(p => p.CarId == car.CarId);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAllByBrand(int brandId)
        {
            return _cars.Where(p => p.BrandId == brandId).ToList();
        }

        public List<Car> GetAllByColor(int colorId)
        {
            return _cars.Where(p => p.ColorId == colorId).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(p => p.CarId == car.CarId);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}
