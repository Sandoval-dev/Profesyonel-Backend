using AutoMapper;
using DevFramework.Core.Aspects.Postsharp;
using DevFramework.Core.Aspects.Postsharp.AuthorizationAspects;
using DevFramework.Core.Aspects.Postsharp.CacheAspects;
using DevFramework.Core.Aspects.Postsharp.LogAspects;
using DevFramework.Core.Aspects.Postsharp.PerformanceAspects;
using DevFramework.Core.Aspects.Postsharp.TransactionAspects;
using DevFramework.Core.CrossCuttingConcerns.Caching.Microsoft;
using DevFramework.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using DevFramework.Core.CrossCuttingConcerns.Validation.FluentValidation;
using DevFramework.Core.DataAccess;
using DevFramework.Northwind.Business.Abstract;
using DevFramework.Northwind.Business.ValidationRules.FluentValidation;
using DevFramework.Northwind.DataAccess.Abstract;
using DevFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure.Interception;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace DevFramework.Northwind.Business.Concrete.Managers
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;
        private readonly IMapper _mapper;


        public ProductManager(IProductDal productDal,IMapper mapper)
        {
            _productDal = productDal;
            _mapper = mapper;

        }

        [FluentValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]

        public Product Add(Product product)
        {
            return _productDal.Add(product);
        }

        [CacheAspect(typeof(MemoryCacheManager))]
        [LogAspect(typeof(System.Data.Entity.Infrastructure.Interception.DatabaseLogger))]
        [PerformanceCounterAspect(2)]
        [SecuredOperation(Roles="Admin,Editor")]
        public List<Product> GetAll()
        {
            var products = _mapper.Map<List<Product>>(_productDal.GetList());
            return products;
        }

        public Product GetById(int id)
        {
          
            return _productDal.Get(p => p.ProductId == id);
        }

        [TransactionScopeAspect]
        [FluentValidationAspect(typeof(ProductValidator))]
        public void TransactionalOperation(Product product1, Product product2)
        {
            _productDal.Add(product1);
            _productDal.Update(product2);
  
        }

        [FluentValidationAspect(typeof(ProductValidator))]
        public Product Update(Product product)
        {
            ValidatorTool.FluentValidate(new ProductValidator(), product);
            return _productDal.Update(product);
        }
    }
}
