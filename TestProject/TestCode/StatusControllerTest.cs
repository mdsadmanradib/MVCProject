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

namespace Ecommerce.UnitTest.Controllers
{

    public class StatusControllerTest
    {
        private Mock<IRepository<Status>> mockStatusRepo;
        private Mock<IUnitOfWork> mockUOW;
        public StatusControllerTest()
        {
            mockStatusRepo = new Mock<IRepository<Status>>();
            mockUOW = new Mock<IUnitOfWork>();

        }

        private IList<Status> GetListOfStatus()
        {
            var status = new List<Status>
            {
                new Status{Id=1,Name="T-Shirt"
                    ,Description="Test Description",
                    Level = "Test"},
                new Status{Id=2,Name="ACER",Description="Test Description",
                    Level = "Test"}
            };
            return status;
        }


        [Fact]
        public async Task AddEditStatus_ReturnsPartialView_WithSingleCategory()
        {
            // Arrange
            var status = GetListOfStatus().First(x => x.Id == 1);

            mockStatusRepo.Setup(x => x.GetByIdAsync(It.IsAny<int?>())).ReturnsAsync(status);

            mockUOW.Setup(x => x.Repository<Status>()).Returns(mockStatusRepo.Object);

            var controller = new StatusController(mockUOW.Object);

            // Act
            var result = await controller.AddEditStatus(1);

            // Assert
            var viewResult = Assert.IsType<PartialViewResult>(result);
            var model = Assert.IsAssignableFrom<StatusViewModel>(viewResult.ViewData.Model);
            Assert.Equal(status.Name, model.Name);

        }
        [Fact]
        public async Task AddEditStatusPOST_ReturnsEmptyModelWithError_WhenModelStateInvalid()
        {
            // Arrange
            var status = new StatusViewModel { };

            //mockBrandRepo.Setup(x => x.GetByIdAsync(It.IsAny<int?>())).ReturnsAsync(brand);

            mockUOW.Setup(x => x.Repository<Status>()).Returns(mockStatusRepo.Object);

            var controller = new StatusController(mockUOW.Object);
            controller.ModelState.AddModelError("Name", "Required");
            // Act
            var result = await controller.AddEditStatus(0, status);

            // Assert
            var viewResult = Assert.IsType<PartialViewResult>(result);
            var model = Assert.IsAssignableFrom<StatusViewModel>(viewResult.ViewData.Model);
            Assert.Null(model.Name);
            Assert.False(viewResult.ViewData.ModelState.IsValid);

        }
        [Fact]
        public async Task AddEditStatusPost_ReturnsARedirectAndAddBrand_WhenCategoryIsValid()
        {
            // Arrange
            var status = new StatusViewModel { Name = "Apple" };

            mockStatusRepo.Setup(x => x.InsertAsync(It.IsAny<Status>())).Returns(Task.FromResult<Status>(new Status())).Verifiable();


            mockUOW.Setup(x => x.Repository<Status>()).Returns(mockStatusRepo.Object);

            var controller = new StatusController(mockUOW.Object);

            // Act
            var result = await controller.AddEditStatus(0, status);

            // Assert
            var redirectResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Null(redirectResult.ControllerName);
            Assert.Equal("Index", redirectResult.ActionName);
            mockStatusRepo.Verify();
        }
        [Fact]
        public async Task AddEditStatusPost_ReturnsARedirectAndUpdateBrand_WhenBrandIsValid()
        {
            // Arrange
            var brandId = 1;
            var status = new StatusViewModel { Id = brandId, Name = "Apple" };
            mockStatusRepo.Setup(x => x.Update(It.IsAny<Status>())).Verifiable();

            mockUOW.Setup(x => x.Repository<Status>()).Returns(mockStatusRepo.Object);

            var controller = new StatusController(mockUOW.Object);

            // Act
            var result = await controller.AddEditStatus(brandId, status);

            // Assert
            var redirectResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Null(redirectResult.ControllerName);
            Assert.Equal("Index", redirectResult.ActionName);

        }

        [Fact]
        public async Task Delete_ReturnPartialViewAndStatusName_ByPassingBrandId()
        {
            // Arrange
            var brandId = 1;
            var status = GetListOfStatus().First(x => x.Id == brandId);
            mockStatusRepo.Setup(x => x.GetByIdAsync(It.IsAny<int?>())).ReturnsAsync(status);

            mockUOW.Setup(x => x.Repository<Status>()).Returns(mockStatusRepo.Object);

            var controller = new StatusController(mockUOW.Object);

            // Act
            var result = await controller.Delete(brandId);

            // Assert
            var viewResult = Assert.IsType<PartialViewResult>(result);
            var model = Assert.IsAssignableFrom<string>(viewResult.ViewData.Model);
            Assert.Equal(status.Name, model);
        }


        [Fact]
        public async Task DeletePost_RedirectAndDeleteStatus_ByPassingBrandId()
        {
            // Arrange
            var brandId = 1;
            var status = GetListOfStatus().First(x => x.Id == brandId);
            mockStatusRepo.Setup(x => x.GetByIdAsync(It.IsAny<int?>())).ReturnsAsync(status);
            mockStatusRepo.Setup(x => x.DeleteAsync(It.IsAny<Status>())).Returns(Task.FromResult(It.IsAny<int>())).Verifiable();

            mockUOW.Setup(x => x.Repository<Status>()).Returns(mockStatusRepo.Object);

            var controller = new StatusController(mockUOW.Object);

            // Act
            var result = await controller.Delete(brandId, It.IsAny<IFormCollection>());

            // Assert
            var redirectResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Null(redirectResult.ControllerName);
            Assert.Equal("Index", redirectResult.ActionName);
            mockStatusRepo.Verify();
        }

    }
}
