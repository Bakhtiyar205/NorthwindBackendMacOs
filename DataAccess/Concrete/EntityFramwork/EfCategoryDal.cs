using System;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramwork.Contexts;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramwork
{
	public class EfCategoryDal : EfEntityRepositoryBase<Category, NorthwindContext>, ICategoryDal 
    {
	 
	}
}

