using System;
using FluentValidation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SoftwareBlog.Business.Concrete.Manager;
using SoftwareBlog.Northwind.DataAccess.Abstract;
using SoftwareBlog.Northwind.Entities.Concrete;

namespace SoftwareBlog.Northwind.Business.Tests
{
    [TestClass]
    public class ProductManagerTests
    {
        [ExpectedException(typeof(ValidationException))]
        [TestMethod]
        public void Product_validation_check()
        {
            Mock<IProductDal> mock= new Mock<IProductDal>();
            ProductManager productManager= new ProductManager(mock.Object);
            productManager.Add(new Product());
        }
    }
}
