using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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
            _cars = new List<Car>
            {
                new Car{CarId=1, BrandId=1, ColorId=1, DailyPrice=350, Description="Passat 1.6 TSI", ModelYear=2010},
                new Car{CarId=2, BrandId=2, ColorId=2, DailyPrice=420, Description="Jetta 1.4 Full", ModelYear=2017},
                new Car{CarId=3, BrandId=3, ColorId=1, DailyPrice=350, Description="Golf 1.3", ModelYear=2019},
                new Car{CarId=4, BrandId=1, ColorId=3, DailyPrice=750, Description="BMW S320", ModelYear=2015},
                new Car{CarId=5, BrandId=4, ColorId=4, DailyPrice=1050, Description="Mercedes Jeep", ModelYear=2012},
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            //_cars.Remove(car); //çalışmaz

            //Car carToDelete = null;
            //foreach (var c in _cars)
            //{
            //    if(car.CarId==c.CarId)
            //    {
            //        carToDelete.CarId = c.CarId;
            //    }
            //}
            //_cars.Remove(carToDelete); //uzun yol

            Car carToDelete = _cars.SingleOrDefault(p => car.CarId == p.CarId);
            _cars.Remove(carToDelete);
        }

        //public List<Car> GetAll()
        //{
        //    return _cars;
        //}

        public List<Car> GetById(int carId)
        {
            return _cars.Where(p => carId == p.CarId).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(p => car.CarId == p.CarId);
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }

        //--------IEntityRepository oluşturduktan sonra, implemente ettiğimizde aşağıdaki metodlar geldi-----------------------------------

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }
    }
}
