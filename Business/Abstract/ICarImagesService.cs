using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarImagesService
    {
        IResult Add(IFormFile file, CarImage images);
        IResult Update(IFormFile file, CarImage images);
        IResult Delete( CarImage images);
        IDataResult<List<CarImage>> GetAll();
        IDataResult<CarImage> Get(int id);
        IDataResult<CarImage> GetById(int id);
    }
}
