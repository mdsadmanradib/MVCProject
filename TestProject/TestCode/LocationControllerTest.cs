using Ecommerce_MVC_Core.Controllers.Admin;
using Ecommerce_MVC_Core.Models.Admin;
using Ecommerce_MVC_Core.Repository;
using Ecommerce_MVC_Core.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestProject.Controller
{
    public class LocationControllerTest
    {
        private Mock<IRepository<Location>> mockLocationRepo;
        private Mock<IUnitOfWork> mockUOW;
        public LocationControllerTest()
        {
            mockLocationRepo = new Mock<IRepository<Location>>();
            mockUOW = new Mock<IUnitOfWork>();

        }


        [Fact]
        public async Task Index()
        {
            // Arrange;


            mockUOW.Setup(x => x.Repository<Location>()).Returns(mockLocationRepo.Object);

            var controller = new LocationController(mockUOW.Object);

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.NotNull(result);

        }
    }
}
