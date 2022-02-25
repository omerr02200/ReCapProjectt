using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        //public List<Car> GetAll()
        //{
        //    InMemoryCarDal inMemoryCarDal = new InMemoryCarDal();
        //    return inMemoryCarDal.GetAll();
        //}

        ICarDal _iCarDal;
        IBrandService _iBrandService; //

        public CarManager(ICarDal carDal, IBrandService brandService)
        {
            _iCarDal = carDal;
            _iBrandService = brandService;
        }

        //public List<Car> GetAll()
        //{
        //    return _iCarDal.GetAll();
        //}
        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<List<Car>> GetAll()
        {
            if(DateTime.Now.Hour==22)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>>(_iCarDal.GetAll(),Messages.CarsListed);
        }

        //public List<Car> GetCarsByBrandId(int brandId)
        //{
        //    return _iCarDal.GetAll(p => p.BrandId == brandId);
        //}
        [CacheAspect]
        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_iCarDal.GetAll(p => p.BrandId == brandId));
        }

        //public List<Car> GetCarsByColorId(int colorId)
        //{
        //    return _iCarDal.GetAll(p => p.ColorId == colorId);
        //}
        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_iCarDal.GetAll(p => p.ColorId == colorId));
        }

        //public void Add(Car car)
        //{
        //    if (car.Description.Length > 1 && car.DailyPrice > 0)
        //    {
        //        _iCarDal.Add(car);
        //    }
        //    else
        //    {
        //        Console.WriteLine("Lütfen en az iki karakterli bir isim ve sıfırdan büyük bir ücret giriniz");
        //    }
        //}//Result'tan önce
        [SecuredOperation("car.add, admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Car car)
        {
            //if (car.Description.Length > 1 && car.DailyPrice > 0)
            //{
            //    _iCarDal.Add(car);
            //    return new SuccessResult(Messages.CarAdded);
            //}
            //else
            //{
            //    return new ErrorResult(Messages.InvalidName);
            //} //FluentValidation dan önce

            //var context = new ValidationContext<Car>(car);
            //CarValidator validator = new CarValidator();
            //var result = validator.Validate(context);
            //if(!result.IsValid)
            //{
            //    throw new ValidationException(result.Errors);
            //} //FluentValidation dan sonra.

            // ValidationTool.Validate(new CarValidator(), car); //ValidationTool dan sonra. Aspect oluşturduktan sonra buraya gerek kalmadı.
            //Validation, Cash, Log, Transaction, Authorization gibi CCC leri bu şekilde, metod içerisinde kullanmak karmaşıklığa sebep olacağından;
            //metodun üzerinde bu işlemleri çağırabiliriz. Bu yöntem de AOP dir.

            //var result = _iCarDal.GetAll(c => c.BrandId == car.BrandId).Count;
            //if (result >= 5)
            //{
            //    return new ErrorResult(Messages.CarCountOfBrandError);
            //} //Böyle yazmak yerine metod oluşturup, çağırıyoruz

            //if (CheckIfCarCountOfBrandCorrect(car.BrandId).Success)
            //{
            //    if (CheckIfCarNameExists(car.Description).Success)
            //    {
            //        _iCarDal.Add(car);
            //        return new SuccessResult(Messages.CarAdded);
            //    }
            //}
            //return new ErrorResult(); //BusinessRule dan önce
            IResult result = BusinessRules.Run(CheckIfCarCountOfBrandCorrect(car.BrandId), CheckIfCarNameExists(car.Description));
            if(result!=null)
            {
                return result;
            }
            return new SuccessResult(Messages.CarAdded);
        }

        //public void Update(Car car)
        //{
        //    _iCarDal.Update(car);
        //}
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car Car)
        {
            _iCarDal.Update(Car);
            return new SuccessResult(Messages.CarUpdated);
        }
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Delete(Car car)
        {
            _iCarDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        //public Car GetById(int carId)
        //{
        //    return _iCarDal.Get(c => c.CarId == carId);
        //}
        public IDataResult<Car> GetById(int carId)
        {
            return new SuccessDataResult<Car>(_iCarDal.Get(c => c.CarId == carId));
        }

        //public List<CarDetailDto> GetCarDetails()
        //{
        //    return _iCarDal.GetCarDetails();
        //}
        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            if(DateTime.Now.Hour==22)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<CarDetailDto>>(_iCarDal.GetCarDetails());
        }
        [TransactionScopeAspect]
        public IResult TransactionalOperation(Car car)
        {
            _iCarDal.Update(car);
            _iCarDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

        #region BusinessRulesMethods
        private IResult CheckIfCarCountOfBrandCorrect(int brandId)
        {
            var result = _iCarDal.GetAll(c => c.BrandId == brandId).Count;
            if(result>=5)
            {
                return new ErrorResult(Messages.CarCountOfBrandError);
            }
            return new SuccessResult();
        }

        private IResult CheckIfCarNameExists(string name)
        {
            var result = _iCarDal.GetAll(c => c.Description == name).Any();
            if(result)
            {
                return new ErrorResult(Messages.CarNameAlreadyExists);
            }
            return new SuccessResult();
        }

        private IResult CheckIfBrandLimitExceded(int brandId)
        {
            var result = _iBrandService.GetAll();
            if(result.Data.Count>=10)
            {
                return new ErrorResult(Messages.BrandLimitExceded);
            }
            return new SuccessResult();
        }
        #endregion
    }
}
