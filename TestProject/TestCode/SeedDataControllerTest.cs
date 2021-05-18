using Ecommerce_MVC_Core.Controllers;
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
using Ecommerce_MVC_Core.Controllers;


namespace TestProject.Controller
{
    public class SeedDataControllerTest
    {
        [Fact]
        public void Index()
        {
            SeedDataController controller = new SeedDataController();
            ViewResult result = controller.Index() as ViewResult;
            Assert.NotNull(result);
        }
    }
}
