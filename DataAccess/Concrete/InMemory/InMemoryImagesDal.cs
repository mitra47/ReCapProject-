using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    class InMemoryImagesDal : ICarImagesDal
    {
        List<CarImage> _carImagess;

        public InMemoryImagesDal()
        {
            _carImagess = new List<CarImage>
            {

            };
        }
        public void Add(CarImage images)
        {
            images.CarImageId = _carImagess.Last().CarImageId + 5;
            _carImagess.Add(images);
            Console.WriteLine("Resimiz  basariyla eklendi.", images.CarImageId);
        }

        public void Delete(CarImage images)
        {
            CarImage ımagesToDelete = _carImagess.SingleOrDefault(b => b.CarImageId == images.CarImageId);
            _carImagess.Remove(ımagesToDelete);
            Console.WriteLine("{0} Basarili bir sekilde sistemden silinmistir.", ımagesToDelete.CarImageId);
        }

        public CarImage Get(Expression<Func<CarImage, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<CarImage> GetAll(Expression<Func<CarImage, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(CarImage entity)
        {
            throw new NotImplementedException();
        }
    }
}
