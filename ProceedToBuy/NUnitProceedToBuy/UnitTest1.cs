using System;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using ProceedToBuyService.Controllers;
using ProceedToBuyService.Models;
using ProceedToBuyService.Provider;

namespace NUnitProceedToBuy
{
    [TestFixture]
    public class Tests
    {

        private ProceedToBuyController _controller;
        private Mock<IProceedToBuyProvider> _config;

        [SetUp]
        public void Setup()
        {
            _config = new Mock<IProceedToBuyProvider>();
            _controller = new ProceedToBuyController(_config.Object);

        }

        [Test]
        public void AddToWishList_Success()
        {
            WishlistModel entity = new WishlistModel { CustomerId = 1, ProductId = 1 };
            //   _config.Setup(repo => repo.Wish(entity));
            _config.Setup(p => p.Wish( 1,  3)).Returns ( new WishlistSuccess { Message = "Requested product is out of stock. Product added to wishlist"});
            var result = _controller.AddToWishList(entity);
            Assert.That(result, Is.InstanceOf<OkObjectResult>());
            //  Assert.Pass();
        }
        [Test]
        public void AddToWishList_Fail()
        {
          //   WishlistModel entity = new WishlistModel;
            var result = _controller.AddToWishList(null) as StatusCodeResult;
            Assert.AreEqual(500,result.StatusCode);

        }

        [Test]
        public void AddToCart_Success()
        {
            CartModel entity = new CartModel() { Product_Id=1 ,Customer_Id=1 ,Zipcode=544678 , DeliveryDate=DateTime.Now};
            _config.Setup(p => p.GetSupply(1,1,544678,DateTime.Now)).Returns(new CartDto { 
            ProductId=1 ,
            CustomerId=1,
            DeliveryDate =DateTime.Now,
            Zipcode=544678,
            VendorObj = new Vendor
            {
                VendorId = 1,
                VendorName = "Reebok",
                DeliveryCharge = 100,
                Rating = 2
            }
            });

            var result = _controller.AddToCart(entity);
            Assert.That(result, Is.InstanceOf<OkObjectResult>());
        }

        [Test]
        public void AddToCart_FailAsync()
        {
            var result = _controller.AddToCart(null) as StatusCodeResult;
            Assert.AreEqual(500, result.StatusCode);
        }



    }
}