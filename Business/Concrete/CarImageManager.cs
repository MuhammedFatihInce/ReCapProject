﻿using Business.Abstract;
using Business.Constants.PathConstants;
using Core.Utilities;
using Core.Utilities.Bussiness;
using Core.Utilities.Helpers.FileHelper;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
	class CarImageManager : ICarImageService
	{
		ICarImageDal _carImageDal;
		IFileHelper _fileHelper;

		public CarImageManager(ICarImageDal carImageDal, IFileHelper fileHelper)
		{
			_carImageDal = carImageDal;
			_fileHelper = fileHelper;
		}

		public IResult Add(IFormFile file, CarImage carImage)
		{
			IResult result = BusinessRules.Run(CheckIFCarImagesLimit(carImage.CarId));
			if (result != null)
			{
				return result;
			}
			carImage.ImagePath = _fileHelper.Upload(file, PathConstants.ImagesPath);
			carImage.Date = DateTime.Now;
			_carImageDal.Add(carImage);
			return new SuccessResult();
		}
		public IResult Update(IFormFile file, CarImage carImage)
		{
			carImage.ImagePath = _fileHelper.Update(file, PathConstants.ImagesPath + carImage.ImagePath, PathConstants.ImagesPath);
			_carImageDal.Update(carImage);
			return new SuccessResult();
		}
		public IResult Delete(CarImage carImage)
		{
			_fileHelper.Delete(PathConstants.ImagesPath + carImage.ImagePath);
			_carImageDal.Delete(carImage);
			return new SuccessResult();
		}

		public IDataResult<List<CarImage>> GetAll()
		{
			return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
		}

		public IDataResult<List<CarImage>> GetByCarId(int carId)
		{
			var result = BusinessRules.Run(CheckCarImage(carId));
			if (result != null)
			{
				return new SuccessDataResult<List<CarImage>>(GetDefaultImage(carId).Data);
			}
			return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c=>c.CarId == carId));
		}

		public IDataResult<CarImage> GetByImageId(int imageId)
		{
			return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.Id == imageId));
		}

		private IResult CheckIFCarImagesLimit(int carId)
		{
			var result = _carImageDal.GetAll(p => p.CarId == carId).Count;
			if (result > 5)
			{
				return new ErrorResult();
			}
			return new SuccessResult();
		}
		private IDataResult<List<CarImage>> GetDefaultImage(int carId)
		{
			List<CarImage> carImage = new List<CarImage>();
			carImage.Add(new CarImage { CarId = carId, Date = DateTime.Now, ImagePath = "DefaultImage.jpg" });
			return new SuccessDataResult<List<CarImage>>(carImage);
		}
		private IResult CheckCarImage(int carId)
		{
			var result = _carImageDal.GetAll(p => p.CarId == carId).Count;
			if (result > 0)
			{
				return new SuccessResult();
			}
			return new ErrorResult();
		}
		
	}
}
