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
    public class OrderStatusAdminControllerTest
    {
        [Fact]
        public void Index()
        {
            var controller = new OrderStatusAdminController();
            ViewResult result = controller.Index() as ViewResult;
            Assert.NotNull(result);
        }
    }
}
