using DevFramework.Northwind.Business.Abstract;
using DevFramework.Northwind.Business.DependecnyResolvers.Ninject;
using DevFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ProductDetailService
/// </summary>
public class ProductDetailService : IProductDetailService
{
    IProductService productService=InstanceFactory.GetInstance<IProductService>();
    public List<Product> GetAll()
    {
        return productService.GetAll();
    }
}