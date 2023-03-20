using Business.Abstract;
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
			IRentalService rentalService = new RentalManager(new EfRentalDal());
			rentalService.Add(new Rental
			{
				CarId = 1,
				CustomerId = 1,
				RentDate = DateTime.Now
			});


			//if (result.Success==true)
			//{
			//	foreach (var car in result.Data)
			//	{
			//		Console.WriteLine(car.CarName + " " + car.BrandName + " " + car.ColorName + " " + car.DailyPrice);
			//	}
			//}
			//else
			//{
			//	Console.WriteLine(result.Message);
			//}


		}
	}
}
