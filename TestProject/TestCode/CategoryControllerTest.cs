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

    public class CategoryControllerTest
    {
        private Mock<IRepository<Category>> mockCategoryRepo;
        private Mock<IUnitOfWork> mockUOW;
        public CategoryControllerTest()
        {
            mockCategoryRepo = new Mock<IRepository<Category>>();
            mockUOW = new Mock<IUnitOfWork>();

        }

        private IList<Category> GetListOfCategory()
        {
            var categories = new List<Category>
            {
                new Category{Id=1,Name="T-Shirt",Description="Test Description",CategoriesList=new List<Category>()},
                new Category{Id=2,Name="ACER",Description="Test Description",CategoriesList=new List<Category>()}
            };
            return categories;
        }

        [Fact]
        public async Task Index_ReturnsAViewResult_WithListOfCategory()
        {
            // Arrange
            var categories = GetListOfCategory();

            mockCategoryRepo.Setup(x => x.GetAllIncludeAsync(It.IsAny<Expression<Func<Category, object>>[]>())).ReturnsAsync(categories);

            mockUOW.Setup(x => x.Repository<Category>()).Returns(mockCategoryRepo.Object);

            var controller = new CategoryController(mockUOW.Object);

            // Act
            var result = await controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<List<CategoryListViewModel>>(viewResult.ViewData.Model);
            Assert.Equal(2, model.Count);

        }

        [Fact]
        public async Task AddEditCategoryPOST_ReturnsEmptyModelWithError_WhenModelStateInvalid()
        {
            // Arrange
            var category = new CategoryViewModel { };

            //mockBrandRepo.Setup(x => x.GetByIdAsync(It.IsAny<int?>())).ReturnsAsync(brand);

            mockUOW.Setup(x => x.Repository<Category>()).Returns(mockCategoryRepo.Object);

            var controller = new CategoryController(mockUOW.Object);
            controller.ModelState.AddModelError("Name", "Required");
            // Act
            var result = await controller.AddEditCategory(0, category);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<CategoryViewModel>(viewResult.ViewData.Model);
            Assert.Null(model.Name);
            Assert.False(viewResult.ViewData.ModelState.IsValid);

        }
        [Fact]
        public async Task AddEditCategoryPost_ReturnsARedirectAndAddBrand_WhenCategoryIsValid()
        {
            // Arrange
            var category = new CategoryViewModel { Name = "Apple" };

            mockCategoryRepo.Setup(x => x.InsertAsync(It.IsAny<Category>())).Returns(Task.FromResult<Category>(new Category())).Verifiable();

            mockUOW.Setup(x => x.Repository<Category>()).Returns(mockCategoryRepo.Object);

            var controller = new CategoryController(mockUOW.Object);

            // Act
            var result = await controller.AddEditCategory(0, category);

            // Assert
            var redirectResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Null(redirectResult.ControllerName);
            Assert.Equal("Index", redirectResult.ActionName);
            mockCategoryRepo.Verify();
        }
        [Fact]
        public async Task AddEditCategoryPost_ReturnsARedirectAndUpdateBrand_WhenBrandIsValid()
        {
            // Arrange
            var brandId = 1;
            var category = new CategoryViewModel { Id = brandId, Name = "Apple" };
            mockCategoryRepo.Setup(x => x.Update(It.IsAny<Category>())).Verifiable();

            mockUOW.Setup(x => x.Repository<Category>()).Returns(mockCategoryRepo.Object);

            var controller = new CategoryController(mockUOW.Object);

            // Act
            var result = await controller.AddEditCategory(brandId, category);

            // Assert
            var redirectResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Null(redirectResult.ControllerName);
            Assert.Equal("Index", redirectResult.ActionName);

        }

        [Fact]
        public async Task Delete_ReturnPartialViewAndCategoryName_ByPassingBrandId()
        {
            // Arrange
            var brandId = 1;
            var category = GetListOfCategory().First(x => x.Id == brandId);
            mockCategoryRepo.Setup(x => x.GetByIdAsync(It.IsAny<int?>())).ReturnsAsync(category);

            mockUOW.Setup(x => x.Repository<Category>()).Returns(mockCategoryRepo.Object);

            var controller = new CategoryController(mockUOW.Object);

            // Act
            var result = await controller.Delete(brandId);

            // Assert
            var viewResult = Assert.IsType<PartialViewResult>(result);
            var model = Assert.IsAssignableFrom<string>(viewResult.ViewData.Model);
            Assert.Equal(category.Name, model);
        }


        [Fact]
        public async Task DeletePost_RedirectAndDeleteCategory_ByPassingBrandId()
        {
            // Arrange
            var brandId = 1;
            var category = GetListOfCategory().First(x => x.Id == brandId);
            mockCategoryRepo.Setup(x => x.GetByIdAsync(It.IsAny<int?>())).ReturnsAsync(category);
            mockCategoryRepo.Setup(x => x.DeleteAsync(It.IsAny<Category>())).Returns(Task.FromResult(It.IsAny<int>())).Verifiable();

            mockUOW.Setup(x => x.Repository<Category>()).Returns(mockCategoryRepo.Object);

            var controller = new CategoryController(mockUOW.Object);

            // Act
            var result = await controller.Delete(brandId, It.IsAny<IFormCollection>());

            // Assert
            var redirectResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Null(redirectResult.ControllerName);
            Assert.Equal("Index", redirectResult.ActionName);
            mockCategoryRepo.Verify();
        }

    }
}
