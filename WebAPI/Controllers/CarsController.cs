using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CarsController : ControllerBase
	{
		ICarDalService _carDalService;

		public CarsController(ICarDalService carDalService)
		{
			_carDalService = carDalService;
		}

		[HttpGet("getall")]
		public IActionResult GetAll()
		{
			var result = _carDalService.GetAll();
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		[HttpGet("getbybrandid")]
		public IActionResult GetByBrandId(int id)
		{
			var result = _carDalService.GetCarsByBrandId(id);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		[HttpGet("getbycolorid")]
		public IActionResult GetByColorId(int id)
		{
			var result = _carDalService.GetCarsByColorId(id);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		[HttpGet("getbyunitprice")]
		public IActionResult GetByUnitPrice(decimal min, decimal max)
		{
			var result = _carDalService.GetByUnitPrice(min, max);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		[HttpGet("getbyproductdetails")]
		public IActionResult GetProductDetails()
		{
			var result = _carDalService.GetProductDetails();
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}


		[HttpPost("add")]
		public IActionResult Add(Car car)
		{
			var result = _carDalService.Add(car);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		[HttpPost("update")]
		public IActionResult Update(Car car)
		{
			var result = _carDalService.Update(car);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		[HttpPost("delete")]
		public IActionResult Delete(Car car)
		{
			var result = _carDalService.Delete(car);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}
	}
}
