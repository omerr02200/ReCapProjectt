using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _iCarImageDal;
        IFileHelper _iFileHelper;
        public CarImageManager(ICarImageDal carImageDal, IFileHelper fileHelper)
        {
            _iCarImageDal = carImageDal;
            _iFileHelper = fileHelper;
        }
        //[ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(CarImage carImage, IFormFile file)
        {
            IResult result = BusinessRules.Run(CheckIfCarImageLimit(carImage.CarId));
            if (result != null)
            {
                return result;
            }
            carImage.ImagePath = _iFileHelper.Upload(file, PathConstants.ImagesPath);
            carImage.Date = DateTime.Now;
            _iCarImageDal.Add(carImage);
            return new SuccessResult(Messages.CarImageAdded);
        }

        public IResult Delete(CarImage carImage)
        {
            _iFileHelper.Delete(PathConstants.ImagesPath + carImage.ImagePath);
            _iCarImageDal.Delete(carImage);
            return new SuccessResult(Messages.CarImageDeleted);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_iCarImageDal.GetAll());
        }

        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            IResult result = BusinessRules.Run(CheckIfCarImage(carId));
            if (result != null)
            {
                return new ErrorDataResult<List<CarImage>>(GetDefaultImage(carId).Data);
            }
            return new SuccessDataResult<List<CarImage>>(_iCarImageDal.GetAll(ci => ci.CarId == carId));
        }

        public IDataResult<CarImage> GetByImage(int imageId)
        {
            return new SuccessDataResult<CarImage>(_iCarImageDal.Get(ci => ci.CarImageId == imageId));
        }

        public IResult Update(CarImage carImage, IFormFile file)
        {
            carImage.ImagePath = _iFileHelper.Update(file, PathConstants.ImagesPath + carImage.ImagePath, PathConstants.ImagesPath);
            _iCarImageDal.Update(carImage);
            return new SuccessResult(Messages.CarImageUpdated);
        }
        #region BusinessMethods
        private IResult CheckIfCarImageLimit(int carId)
        {
            var result = _iCarImageDal.GetAll(ci => ci.CarId == carId);
            if (result.Count >= 5)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
        private IResult CheckIfCarImage(int carId)
        {
            var result = _iCarImageDal.GetAll(ci => ci.CarId == carId);
            if (result.Count == 0)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
        private IDataResult<List<CarImage>> GetDefaultImage(int carId)
        {
            List<CarImage> carImages = new List<CarImage>();
            _iCarImageDal.Add(new CarImage { CarId = carId, Date = DateTime.Now, ImagePath = "DefaultImage.jpg" });
            return new SuccessDataResult<List<CarImage>>(carImages);
        }
        #endregion
    }
}
