﻿using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Concrete
{
	public class Brand:IEntity
	{
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
	}
}
