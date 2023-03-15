using Business.Abstract;
using Business.Constants;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
	public class CarManager : ICarDalService
	{
		ICarDal _carDal;

		public CarManager(ICarDal carDal)
		{
			_carDal = carDal;
		}


		public IResult Add(Car car)
		{
			if (car.Description.Length < 2 && car.DailyPrice <= 0)
			{
				return new ErrorResult(Messages.ProductNameInvalid);
			}
			_carDal.Add(car);

			return new SuccessResult(Messages.ProductAdded);

		}

		public IResult Update(Car car)
		{
			_carDal.Update(car);
			return new SuccessResult(Messages.ProductModified);
		}

		public IResult Delete(Car car)
		{
			_carDal.Delete(car);
			return new SuccessResult(Messages.ProductDeleted);
		}
	

		public IDataResult<List<Car>> GetAll()
		{
			return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.ProductsListed);
		}

		public IDataResult<List<Car>> GetByUnitPrice(decimal min, decimal max)
		{
			return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.DailyPrice >= min && c.DailyPrice <= max));
		}

		public IDataResult<List<Car>> GetCarsByBrandId(int id)
		{
			return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == id));
		}

		public IDataResult<List<Car>> GetCarsByColorId(int id)
		{
			return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == id));
		}

		public IDataResult<List<CarDetailDto>> GetProductDetails()
		{
			return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetProductDetails());
		}

	}
}
