using DevFramework.Core.DataAccess.EntityFramework;
using DevFramework.Northwind.DataAccess.Abstract;
using DevFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Northwind.DataAccess.Concrete.EntityFramework
{
    public class EfProductDal :EfEntityRepositoryBase<Product, NorthwindContext>, IProductDal
    {
       
    }
}
