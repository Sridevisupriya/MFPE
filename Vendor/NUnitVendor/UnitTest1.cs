using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using VendorMicroService.Controllers;
using VendorMicroService.Models;
using VendorMicroService.Provider;

namespace NUnitVendor
{
    [TestFixture]
    public class Tests
    {
        List<Vendor> vendors = new List<Vendor>();
        List<VendorStock> stock = new List<VendorStock>();
        private VendorController _controller;
        private Mock<IVendorProvider> _config;

        [SetUp]
        public void Setup()
        {
          
            _config = new Mock<IVendorProvider>();
            _controller = new VendorController(_config.Object);

        }

        [Test]
        public void GetVendorDetails_Success()
        {
            _config.Setup(p => p.GetDetailsOfVendor(1)).Returns(new List<VendorDto> {new VendorDto()
                {
                VendorId = 1,
                VendorName = "Reebok", 
                DeliveryCharge= 100,
                Rating = 2
                } });
            var result = _controller.GetVendorDetails(1);
            Assert.That(result, Is.InstanceOf<OkObjectResult>());
        }
         [Test]
        public void GetVendorDetails_Success()
        {
            _config.Setup(p => p.GetDetailsOfVendor(2)).Returns(new List<VendorDto> {new VendorDto()
                {
               VendorId = 1,VendorName = "Reebok",  DeliveryCharge= 100,Rating = 2 
                } });
            var result = _controller.GetVendorDetails(1);
            Assert.That(result, Is.InstanceOf<OkObjectResult>());
        }

        [Test]
        public void GetVendorDetails_Fail()
        {
            var result = _controller.GetVendorDetails(0);
            Assert.IsNull(result);
        }
    }
}