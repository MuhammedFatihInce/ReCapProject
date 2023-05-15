using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Cashing;
using Core.Aspect.Autofac.Transaction;
using Core.Aspect.Autofac.Validation;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
	public class CarManager : ICarService
	{
		ICarDal _carDal;

		public CarManager(ICarDal carDal)
		{
			_carDal = carDal;
		}

		[SecuredOperation("product.add,admin")]
		[ValidationAspect(typeof(CarValidator))]
		[CacheRemoveAspect("IProductService.Get")]
		public IResult Add(Car car)
		{
			
			_carDal.Add(car);

			return new SuccessResult(Messages.ProductAdded);

		}

		[CacheRemoveAspect("IProductService.Get")]
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

		[SecuredOperation("product.getall,admin")]
		[CacheAspect]
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

		[TransactionScopeAspect]
		public IResult AddTransactionalTest(Car car)
		{
			Add(car);
			if (car.DailyPrice < 10)
			{
				throw new Exception("");
			}

			Add(car);

			return null;
		}

	}
}
