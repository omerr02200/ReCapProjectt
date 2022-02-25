using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        //List<Car> GetAll();
        ////Aşağıdaki metodları EntityFramework ü ve ilgili işlemleri yazdıktan sonra ekledik. Altyapıyı yazdıktan sonra istediğimiz şekilde metod ekliyoruz.
        //List<Car> GetCarsByBrandId(int brandId);
        //List<Car> GetCarsByColorId(int colorId);
        //Car GetById(int carId);
        //void Add(Car car);
        //void Update(Car car);
        //void Delete(Car car); //Result tan önce

        IDataResult<List<Car>> GetAll();
        IDataResult<List<Car>> GetCarsByBrandId(int brandId);
        IDataResult<List<Car>> GetCarsByColorId(int colorId);
        IDataResult<Car> GetById(int carId);
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);

        //List<CarDetailDto> GetCarDetails();
        IDataResult<List<CarDetailDto>> GetCarDetails();

        IResult TransactionalOperation(Car car);
    }
}
