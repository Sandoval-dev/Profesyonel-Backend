using DevFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;

/// <summary>
/// Summary description for IProductDetailService
/// </summary>
/// 
[ServiceContract]
public interface IProductDetailService
{
    [OperationContract]
    List<Product> GetAll();
}