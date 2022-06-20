using Data.Entity;
using Data.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ShopBridge.Controllers;
using ShopBridge.DTOs;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TestProject.Mocks;

namespace TestProject.ViewModels
{
    [TestClass]
    public class MockProductController
    {
        private readonly Mocks.MockFactory mockFactory = new Mocks.MockFactory();
        private MockLogger<ProductController> mockLogger;
        private MockMapper mockMapper;
        private MockUnitOfWork mockUnitOfWork;
        private MockGenericRepository<Product> mockGenericRepository;
        private ProductController controller;

        [TestInitialize]
        public void SetUp()
        {
            mockLogger = mockFactory.Get<MockLogger<ProductController>>();
            mockMapper = mockFactory.Get<MockMapper>();
            mockUnitOfWork = mockFactory.Get<MockUnitOfWork>();
            mockGenericRepository = mockFactory.Get<MockGenericRepository<Product>>();
        }

        private void SetUpController()
        {
            controller = new ProductController(mockMapper.Object, mockLogger.Object, mockUnitOfWork.Object);
        }
         
        [TestMethod]
        public async Task AddProductWithValidData()
        {
            //Arrange
            ProductDto pDto = new ProductDto()
            {
                Name = "parle",
                Description = "Delicious Biscuits",
                Price = 5,
                Quantity = 100,
                Rating = 4
            };
            Product prod = new Product()
            {
                Name = "parle",
                Description = "Delicious Biscuits",
                Price = 5,
                Quantity = 100,
                Rating = 4
            };
            SetUpController();
            mockUnitOfWork.Setup(x => x.products).Returns(mockGenericRepository.Object);
            mockMapper.Setup(m => m.Map<Product>(pDto)).Returns(prod);
            //act
            var result =await controller.AddProduct(pDto);

            //assert
            var okResult = result as OkObjectResult;
            var product = okResult.Value as Product;
            Assert.AreEqual(product.Name, pDto.Name);
        }

        [TestMethod]
        public async Task UpdateProductWithValidData()
        {
            //Arrange
            ProductDto pDto = new ProductDto()
            {
                ProductId=1,
                Name = "parle",
                Description = "Delicious Biscuits",
                Price = 5,
                Quantity = 50,
                Rating = 4
            };
            Product prod = new Product()
            {
                ProductId = 1,
                Name = "parle",
                Description = "Delicious Biscuits",
                Price = 5,
                Quantity = 100,
                Rating = 4
            };
            SetUpController();
            mockUnitOfWork.Setup(x => x.products).Returns(mockGenericRepository.Object);
            mockUnitOfWork.Setup(x => x.products.Get(It.IsAny<Expression<Func<Product, bool>>>(), null)).ReturnsAsync(prod);
            mockMapper.Setup(m => m.Map<Product>(pDto)).Returns(prod);
            prod.Quantity = 50;
           
            //act
            var result = await controller.UpdateProduct(pDto);

            //assert
            var okResult = result as OkObjectResult;
            var product = okResult.Value as Product;
            Assert.AreEqual(product.Quantity, pDto.Quantity);
        }
    }
}
