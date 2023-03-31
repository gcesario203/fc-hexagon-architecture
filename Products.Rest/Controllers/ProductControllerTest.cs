using Application.Product.Contracts;
using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using Adapters.Product.DTOs;
using Application.Product.Entity;

namespace Products.Rest.Controllers
{
    public class ProductControllerTest
    {
        [Fact]
        public void ProductController_WhenCreating_ReturnStatusCode201()
        {

            var entity = new ProductEntity("Arroz", 15);
            var serviceMock = new Moq.Mock<IProductService>();

            serviceMock.Setup(x => x.Create(It.IsAny<string>(), It.IsAny<decimal>())).Returns((entity, null));

            var controller = new ProductController(serviceMock.Object);

            var result = controller.Create(new ProductDTO("Arroz", 15));

            Assert.Equal((result as CreatedAtActionResult).StatusCode, 201);
        }

        [Fact]
        public void ProductController_WhenCreating_ReturnStatusCode500()
        {

            var serviceMock = new Moq.Mock<IProductService>();

            serviceMock.Setup(x => x.Create(It.IsAny<string>(), It.IsAny<decimal>())).Returns((null, It.IsAny<Exception>()));

            var controller = new ProductController(serviceMock.Object);

            var result = controller.Create(new ProductDTO("", 15));

            Assert.Equal((result as StatusCodeResult).StatusCode, 500);
        }

        [Fact]
        public void ProductController_WhenGettingById_ReturnStatusCode200()
        {
            var entity = new ProductEntity("AAA", 2);

            var serviceMock = new Moq.Mock<IProductService>();

            serviceMock.Setup(x => x.GetById(It.IsAny<string>())).Returns((entity, null));

            var controller = new ProductController(serviceMock.Object);

            var result = controller.GetById(entity.GetId());

            Assert.Equal((result as OkObjectResult).StatusCode, 200);
        }

        [Fact]
        public void ProductController_WhenGettingById_ReturnStatusCode400()
        {
            var serviceMock = new Moq.Mock<IProductService>();

            serviceMock.Setup(x => x.GetById(It.IsAny<string>())).Returns((null, It.IsAny<Exception>()));

            var controller = new ProductController(serviceMock.Object);

            var result = controller.GetById(Guid.NewGuid().ToString());

            Assert.Equal((result as BadRequestObjectResult).StatusCode, 400);
        }

        [Fact]
        public void ProductController_WhenEnabling_ReturnStatusCode200()
        {
            var entity = new ProductEntity("AAA", 2);

            var serviceMock = new Moq.Mock<IProductService>();

            serviceMock.Setup(x => x.GetById(entity.GetId())).Returns((entity, null));
            serviceMock.Setup(x => x.Enable(entity)).Returns((entity, null));

            var controller = new ProductController(serviceMock.Object);

            var result = controller.Enable(entity.GetId());

            Assert.Equal((result as OkObjectResult).StatusCode, 200);
        }

        [Fact]
        public void ProductController_WhenDisabling_ReturnStatusCode200()
        {
            var entity = new ProductEntity("AAA", 2);

            var serviceMock = new Moq.Mock<IProductService>();

            serviceMock.Setup(x => x.GetById(entity.GetId())).Returns((entity, null));
            serviceMock.Setup(x => x.Disable(entity)).Returns((entity, null));

            var controller = new ProductController(serviceMock.Object);

            var result = controller.Disable(entity.GetId());

            Assert.Equal((result as OkObjectResult).StatusCode, 200);
        }
        [Fact]
        public void ProductController_WhenEnablingNotFindAProduct_ReturnStatusCode400()
        {
            var serviceMock = new Moq.Mock<IProductService>();

            serviceMock.Setup(x => x.GetById(It.IsAny<string>())).Returns((null, It.IsAny<Exception>()));

            var controller = new ProductController(serviceMock.Object);

            var result = controller.Enable(Guid.NewGuid().ToString());

            Assert.Equal((result as BadRequestObjectResult).StatusCode, 400);
        }

        [Fact]
        public void ProductController_WhenDisablingNotFindAProduct_ReturnStatusCode400()
        {
            var serviceMock = new Moq.Mock<IProductService>();

            serviceMock.Setup(x => x.GetById(It.IsAny<string>())).Returns((null, It.IsAny<Exception>()));

            var controller = new ProductController(serviceMock.Object);

            var result = controller.Disable(Guid.NewGuid().ToString());

            Assert.Equal((result as BadRequestObjectResult).StatusCode, 400);
        }

        [Fact]
        public void ProductController_WhenEnablingInvalidProduct_ReturnStatusCode400()
        {
            var entity = new ProductEntity("AAA", 2);

            var serviceMock = new Moq.Mock<IProductService>();

            serviceMock.Setup(x => x.GetById(entity.GetId())).Returns((entity, null));
            serviceMock.Setup(x => x.Enable(entity)).Returns((null, It.IsAny<Exception>()));

            var controller = new ProductController(serviceMock.Object);

            var result = controller.Enable(entity.GetId());

            Assert.Equal((result as BadRequestObjectResult).StatusCode, 400);
        }
        [Fact]
        public void ProductController_WhenDisablingInvalidProduct_ReturnStatusCode400()
        {
            var entity = new ProductEntity("AAA", 2);

            var serviceMock = new Moq.Mock<IProductService>();

            serviceMock.Setup(x => x.GetById(entity.GetId())).Returns((entity, null));
            serviceMock.Setup(x => x.Disable(entity)).Returns((null, It.IsAny<Exception>()));

            var controller = new ProductController(serviceMock.Object);

            var result = controller.Disable(entity.GetId());

            Assert.Equal((result as BadRequestObjectResult).StatusCode, 400);
        }
    }
}