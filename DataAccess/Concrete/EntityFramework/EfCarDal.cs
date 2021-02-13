using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car,CarProjectContext>,ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (CarProjectContext context = new CarProjectContext())
            {
                var result = from p in context.Cars
                             join c in context.Brands
                             on p.BrandId equals c.BrandId
                             join y in context.Colors 
                             on p.ColorId equals y.ColorId
                             select new CarDetailDto
                             {
                                 CarId = p.CarId,
                                 CarName = p.CarName,
                                 ColorName=y.ColorName,
                                 BrandName = c.BrandName,
                                 DailyPrice = p.DailyPrice

                             };
                return result.ToList();
            }
        }
        
    }
}
