﻿using Core.Utilities;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
	public interface ICarService
	{
		IResult Add(Car car);
		IResult Update(Car car);
		IResult Delete(Car car);
		IDataResult<List<Car>> GetAll();
		IDataResult<List<Car>> GetCarsByBrandId(int id);
		IDataResult<List<Car>> GetCarsByColorId(int id);
		IDataResult<List<Car>> GetByUnitPrice(decimal min, decimal max);
		IDataResult<List<CarDetailDto>> GetProductDetails();
		IResult AddTransactionalTest(Car car);
	}
}
