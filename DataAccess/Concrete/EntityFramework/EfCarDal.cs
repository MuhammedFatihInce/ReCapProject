using DataAccess.Abstract;
using Entities.Concrete;
using Core.DataAccess.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
	public class EfCarDal : EfEntityRepositoryBase<Car, ReCapContext>, ICarDal
	{
		public List<CarDetailDto> GetProductDetails()
		{
			using (ReCapContext context = new ReCapContext())
			{
				var result = from c in context.Cars
							 join b in context.Brands
							 on c.BrandId equals b.Id
							 join r in context.Colors
							 on c.ColorId equals r.Id
							 select new CarDetailDto 
							 { 
								 CarName = c.Description, BrandName = b.Name, 
								 ColorName = r.Name, DailyPrice = c.DailyPrice 
							 };
				return result.ToList();
			}
		}
	}
}
