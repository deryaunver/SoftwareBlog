using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using FluentValidation.Resources;
using SoftwareBlog.Business.Abstract;
using SoftwareBlog.Business.ValidationRules.FluentValidation;
using SoftwareBlog.Core.Aspects.Postsharp;
using SoftwareBlog.Core.Aspects.Postsharp.TransactionAspects;
using SoftwareBlog.Core.Aspects.Postsharp.ValidationAspects;
using SoftwareBlog.Core.CrossCuttingConcerns.Validation.FluentValidation;
using SoftwareBlog.Northwind.DataAccess.Abstract;
using SoftwareBlog.Northwind.Entities.Concrete;

namespace SoftwareBlog.Business.Concrete.Manager
{
    public  class ProductManager:IProductService
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public List<Product> GetAll()
        {
            return _productDal.GetList();
        }

        public Product GetById(int id)
        {
            return _productDal.Get(p => p.ProductID == id);
        }
        [FluentValidationAspect(typeof(ProductValidator))]
        public Product Add(Product product)
        {
            //ValidatorTool.FluentValidate(new ProductValidator(), product);
            return _productDal.Add(product);
        }
        [FluentValidationAspect(typeof(ProductValidator))]
        public Product Update(Product product)
        {
            return _productDal.Update(product);
        }
        [TransactionScopeAspect]
        public void TransactionalOperation(Product product1, Product Product2)
        {
            #region Yöntem1
            //using (TransactionScope scope= new TransactionScope())
            //{
            //    try
            //    {
            //_productDal.Add(product1);
            ////Business Code
            //_productDal.Update(Product2);
            //scope.Complete();
            //    }
            //    catch 
            //    {
            //     scope.Dispose(); 
            //    }
            //} 
            #endregion

            _productDal.Add(product1);
            //Business Code
            _productDal.Update(Product2);
            

        }
    }
}
