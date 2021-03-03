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
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarImagesManager : ICarImagesService
    {
        ICarImagesDal _carImagesDal;

        public CarImagesManager(ICarImagesDal carImagesDal)
        {
            _carImagesDal = carImagesDal;
        }

        [ValidationAspect(typeof(CarImagesValidator))]
        public IResult Add(IFormFile file, CarImage images)
        {
            IResult result = BusinessRules.Run(CheckImageLimitExceeded(images.CarId));
            if (result != null)
            {
                return result;
            }
            images.ImagePath = FileHelper.Add(file);
            images.Date = DateTime.Now;
            _carImagesDal.Add(images);
            return new SuccessResult();
        }

        public IResult Delete( CarImage images)
        {
            _carImagesDal.Delete(images);
            return new SuccessResult(Messages.Delete);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImagesDal.GetAll(), Messages.Listed);
        }

        public IDataResult<CarImage> GetById(int id)
        {
            return new SuccessDataResult<CarImage>(_carImagesDal.Get(p => p.ImagesId == id));
        }
        [ValidationAspect(typeof(CarImagesValidator))]
        public IResult Update(IFormFile file,CarImage images )
        {
            images.ImagePath = FileHelper.Update(_carImagesDal.Get(p => p.ImagesId == images.ImagesId).ImagePath, file);
            images.Date = DateTime.Now;
            _carImagesDal.Update(images);
            return new SuccessResult();
        }
        private IResult CheckImageLimitExceeded(int id)
        {
            var carImagecount = _carImagesDal.GetAll(p => p.CarId == id).Count;
            if (carImagecount >= 5)
            {
                return new ErrorResult(Messages.CarImageLimitExceeded);
            }

            return new SuccessResult();
        }
        private List<CarImage> CheckIfCarImageNull(int id)
        {
            string path = @"\Images\logo.jpg";
            var result = _carImagesDal.GetAll(c => c.CarId == id).Any();
            if (!result)
            {
                return new List<CarImage> { new CarImage { CarId = id, ImagePath = path, Date = DateTime.Now } };
            }
            return _carImagesDal.GetAll(p => p.CarId == id);
        }

        public IDataResult<CarImage> Get(int id)
        {
            return new SuccessDataResult<CarImage>(_carImagesDal.Get(p => p.ImagesId == id));
        }
    }
}
