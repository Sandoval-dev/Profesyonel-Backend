using DevFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Northwind.Business.ServiceContracts.Wcf
{
    [ServiceContract]
    public interface IProductDetailService
    {


        [OperationContract]
        List<Product> GetAll();
    }
}
