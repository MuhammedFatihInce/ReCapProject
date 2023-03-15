using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
	 class Program
	{

		static void Main(string[] args)
		{
			CarManager carManager = new CarManager(new EfCarDal());
			var result = carManager.GetProductDetails();

			if (result.Success==true)
			{
				foreach (var car in result.Data)
				{
					Console.WriteLine(car.CarName + " " + car.BrandName + " " + car.ColorName + " " + car.DailyPrice);
				}
			}
			else
			{
				Console.WriteLine(result.Message);
			}


		}
	}
}
