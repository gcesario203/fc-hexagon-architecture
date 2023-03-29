using Application.Product.Contracts;
using Xunit;
using Moq;

namespace Application.Product.Services
{
    public class ProductServiceUnitTests
    {
        [Fact]
        public void ProductService_WhenGettingExistingProductById_ShouldReturnTheProduct()
        {
            var mockProduct = new Product.Entity.Product("Alberto", 15);

            var id = mockProduct.GetId();
            var productServiceStub = new Moq.Mock<IProductPersistence>();

            productServiceStub.Setup(x => x.Get(It.IsAny<string>())).Returns((mockProduct, null));

            var productService = new ProductService(productServiceStub.Object);

            var product = productService.Get(id);

            Assert.Equal(product.Item1.GetId(), id);
        }

        [Fact]
        public void ProductService_WhenGettingUnexistingProductById_ShouldReturnAException()
        {
            var productServiceStub = new Moq.Mock<IProductPersistence>();

            productServiceStub.Setup(x => x.Get(It.IsAny<string>())).Returns((null, It.IsAny<Exception>()));

            var productService = new ProductService(productServiceStub.Object);

            var product = productService.Get(Guid.NewGuid().ToString());

            Assert.Null(product.Item1);
        }
    }
}