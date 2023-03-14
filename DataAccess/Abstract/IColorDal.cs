using System;
using System.Collections.Generic;
using Entities.Concrete;
using System.Drawing;
using System.Text;
using Color = Entities.Concrete.Color;
using Core.DataAccess;

namespace DataAccess.Abstract
{
	public interface IColorDal:IEntityRepository<Color>
	{
	}
}
