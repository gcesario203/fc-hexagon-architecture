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
            var mockProduct = new Product.Entity.ProductEntity("Alberto", 15);

            var id = mockProduct.GetId();
            var productServiceStub = new Moq.Mock<IProductPersistence>();

            productServiceStub.Setup(x => x.Get(It.IsAny<string>())).Returns((mockProduct, null));

            var productService = new ProductService(productServiceStub.Object);

            var product = productService.GetById(id);

            Assert.Equal(product.Item1.GetId(), id);
        }

        [Fact]
        public void ProductService_WhenGettingUnexistingProductById_ShouldReturnAException()
        {
            var productServiceStub = new Moq.Mock<IProductPersistence>();

            productServiceStub.Setup(x => x.Get(It.IsAny<string>())).Returns((null, It.IsAny<Exception>()));

            var productService = new ProductService(productServiceStub.Object);

            var product = productService.GetById(Guid.NewGuid().ToString());

            Assert.Null(product.Item1);
        }


        [Fact]
        public void ProductService_WhenCreatingAValidProduct_ShouldReturnTheCreatedProduct()
        {
            var mockProduct = new Product.Entity.ProductEntity("Alberto", 15);

            var productServiceStub = new Moq.Mock<IProductPersistence>();

            productServiceStub.Setup(x => x.Save(It.IsAny<IProductEntity>())).Returns((mockProduct, null));

            var productService = new ProductService(productServiceStub.Object);

            var result = productService.Create("Alberto", 15);

            Assert.Null(result.Item2);

            Assert.True(result.Item1.IsValid().isValid);
        }

        [Fact]
        public void ProductService_WhenCreatingAInvalidProduct_ShouldReturnAException()
        {

            var productServiceStub = new Moq.Mock<IProductPersistence>();

            productServiceStub.Setup(x => x.Save(It.IsAny<IProductEntity>())).Returns((null, It.IsAny<Exception>()));

            var productService = new ProductService(productServiceStub.Object);

            Assert.Throws(typeof(Exception), () => productService.Create("Alberto", -1));
        }

        [Fact]
        public void ProductService_WhenEnablingAProductWithoutValue_ShouldReturnAException()
        {
            var productServiceStub = new Moq.Mock<IProductPersistence>();

            productServiceStub.Setup(x => x.Save(It.IsAny<IProductEntity>())).Returns((null, It.IsAny<Exception>()));

            var productService = new ProductService(productServiceStub.Object);

            var result = productService.Enable(new Product.Entity.ProductEntity("Augusto", 0));

            Assert.Null(result.Item1);

            Assert.NotNull(result.Item2);
        }

        [Fact]
        public void ProductService_WhenEnablingAProductWithValue_ShouldBeActivated()
        {
            var mock = new Product.Entity.ProductEntity("Augusto", 20);
            var productServiceStub = new Moq.Mock<IProductPersistence>();

            productServiceStub.Setup(x => x.Save(It.IsAny<IProductEntity>())).Returns((mock, null));

            var productService = new ProductService(productServiceStub.Object);

            var result = productService.Enable(mock);

            Assert.Equal(result.Item1.GetStatus(), Shared.Constants.Status.ENABLED);
        }

        [Fact]
        public void ProductService_WhenDisablingAProductWithValue_ShouldReturnAException()
        {
            var mock = new Product.Entity.ProductEntity("Augusto", 20);
            var productServiceStub = new Moq.Mock<IProductPersistence>();

            productServiceStub.Setup(x => x.Save(It.IsAny<IProductEntity>())).Returns((null, It.IsAny<Exception>()));

            var productService = new ProductService(productServiceStub.Object);

            var result = productService.Disable(mock);

            Assert.NotNull(result.Item2);
        }

        [Fact]
        public void ProductService_WhenDisablingAProductWithValue_ShouldBeDeactivated()
        {
            var mock = new Product.Entity.ProductEntity("Augusto", 0);
            var productServiceStub = new Moq.Mock<IProductPersistence>();

            productServiceStub.Setup(x => x.Save(It.IsAny<IProductEntity>())).Returns((mock, null));

            var productService = new ProductService(productServiceStub.Object);

            var result = productService.Disable(mock);

            Assert.Equal(result.Item1.GetStatus(), Shared.Constants.Status.DISABLED);
        }
    }
}