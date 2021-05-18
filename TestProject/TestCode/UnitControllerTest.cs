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

    public class UnitControllerTest
    {
        private Mock<IRepository<Unit>> mockUnitRepo;
        private Mock<IUnitOfWork> mockUOW;
        public UnitControllerTest()
        {
            mockUnitRepo = new Mock<IRepository<Unit>>();
            mockUOW = new Mock<IUnitOfWork>();

        }

        private IList<Unit> GetListOfUnit()
        {
            var unit = new List<Unit>
            {
                new Unit{Id=1,Name="T-Shirt",Description="Test Description",Products=new List<Product>()},
                new Unit{Id=2,Name="ACER",Description="Test Description",Products=new List<Product>()}
            };
            return unit;
        }


        [Fact]
        public async Task AddEditUnit_ReturnsPartialView_WithSingleCategory()
        {
            // Arrange
            var unit = GetListOfUnit().First(x => x.Id == 1);

            mockUnitRepo.Setup(x => x.GetByIdAsync(It.IsAny<int?>())).ReturnsAsync(unit);

            mockUOW.Setup(x => x.Repository<Unit>()).Returns(mockUnitRepo.Object);

            var controller = new UnitsController(mockUOW.Object);

            // Act
            var result = await controller.AddEditUnit(1);

            // Assert
            var viewResult = Assert.IsType<PartialViewResult>(result);
            var model = Assert.IsAssignableFrom<UnitViewModel>(viewResult.ViewData.Model);
            Assert.Equal(unit.Name, model.Name);

        }
        [Fact]
        public async Task AddEditUnitPOST_ReturnsEmptyModelWithError_WhenModelStateInvalid()
        {
            // Arrange
            var unit = new UnitViewModel { };

            //mockBrandRepo.Setup(x => x.GetByIdAsync(It.IsAny<int?>())).ReturnsAsync(brand);

            mockUOW.Setup(x => x.Repository<Unit>()).Returns(mockUnitRepo.Object);

            var controller = new UnitsController(mockUOW.Object);
            controller.ModelState.AddModelError("Name", "Required");
            // Act
            var result = await controller.AddEditUnit(0, unit);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<UnitViewModel>(viewResult.ViewData.Model);
            Assert.Null(model.Name);
            Assert.False(viewResult.ViewData.ModelState.IsValid);

        }
        [Fact]
        public async Task AddEditUnitPost_ReturnsARedirectAndAddBrand_WhenCategoryIsValid()
        {
            // Arrange
            var unit = new UnitViewModel { Name = "Apple" };

            mockUnitRepo.Setup(x => x.InsertAsync(It.IsAny<Unit>())).Returns(Task.FromResult<Unit>(new Unit())).Verifiable();

            mockUOW.Setup(x => x.Repository<Unit>()).Returns(mockUnitRepo.Object);

            var controller = new UnitsController(mockUOW.Object);

            // Act
            var result = await controller.AddEditUnit(0, unit);

            // Assert
            var redirectResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Null(redirectResult.ControllerName);
            Assert.Equal("Index", redirectResult.ActionName);
            mockUnitRepo.Verify();
        }
        [Fact]
        public async Task AddEditUnitPost_ReturnsARedirectAndUpdateBrand_WhenBrandIsValid()
        {
            // Arrange
            var brandId = 1;
            var unit = new UnitViewModel { Id = brandId, Name = "Apple" };
            mockUnitRepo.Setup(x => x.Update(It.IsAny<Unit>())).Verifiable();

            mockUOW.Setup(x => x.Repository<Unit>()).Returns(mockUnitRepo.Object);

            var controller = new UnitsController(mockUOW.Object);

            // Act
            var result = await controller.AddEditUnit(brandId, unit);

            // Assert
            var redirectResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Null(redirectResult.ControllerName);
            Assert.Equal("Index", redirectResult.ActionName);

        }

        [Fact]
        public async Task Delete_ReturnPartialViewAndUnitName_ByPassingBrandId()
        {
            // Arrange
            var brandId = 1;
            var unit = GetListOfUnit().First(x => x.Id == brandId);
            mockUnitRepo.Setup(x => x.GetByIdAsync(It.IsAny<int?>())).ReturnsAsync(unit);

            mockUOW.Setup(x => x.Repository<Unit>()).Returns(mockUnitRepo.Object);

            var controller = new UnitsController(mockUOW.Object);

            // Act
            var result = await controller.DeleteUnit(brandId);

            // Assert
            var viewResult = Assert.IsType<PartialViewResult>(result);
            var model = Assert.IsAssignableFrom<string>(viewResult.ViewData.Model);
            Assert.Equal(unit.Name, model);
        }


        [Fact]
        public async Task DeletePost_RedirectAndDeleteUnit_ByPassingBrandId()
        {
            // Arrange
            var brandId = 1;
            var Unit = GetListOfUnit().First(x => x.Id == brandId);
            mockUnitRepo.Setup(x => x.GetByIdAsync(It.IsAny<int?>())).ReturnsAsync(Unit);
            mockUnitRepo.Setup(x => x.DeleteAsync(It.IsAny<Unit>())).Returns(Task.FromResult(It.IsAny<int>())).Verifiable();

            mockUOW.Setup(x => x.Repository<Unit>()).Returns(mockUnitRepo.Object);

            var controller = new UnitsController(mockUOW.Object);

            // Act
            var result = await controller.DeleteUnit(brandId, It.IsAny<IFormCollection>());

            // Assert
            var redirectResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Null(redirectResult.ControllerName);
            Assert.Equal("Index", redirectResult.ActionName);
            mockUnitRepo.Verify();
        }

    }
}
