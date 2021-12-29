using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarDal : IEntityRepository<Car>
    {
        //List<Car> GetAll();
        //void Add(Car car);
        //void Update(Car car);
        //void Delete(Car car);
        //List<Car> GetById(int carId); //*Ortak bir Generic interface tanımlamadan önce bu şekilde metodları yazardık. Artık bu metodlar
        //Generic interface den gelecek

        List<CarDetailDto> GetCarDetails();
    }
}
