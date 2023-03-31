using Xunit;
using Application.Product.Entity;
using Microsoft.EntityFrameworkCore;

namespace Adapters.Product.Adapters
{
    public class ProductAdapterUnitTests
    {
        [Fact]
        public void ProductRepository_WhenCreatingAProduct_ReturnAIProductRepository()
        {
            var productRepository = new ProductAdapter();

            var result = productRepository.Save(new Application.Product.Entity.Product("Arroz", 25));

            Assert.NotNull(result.Item1);
        }

        [Fact]
        public void ProductRepository_WhenCreatingWithoutName_ReturnsAException()
        {
            var productRepository = new ProductAdapter();

            Assert.Throws(typeof(Exception), () => productRepository.Save(new Application.Product.Entity.Product("", 15)));
        }

        [Fact]
        public void ProductRepository_WhenGettingById_ReturnAIProductRepository()
        {
            var productRepository = new ProductAdapter();

            var result = productRepository.Save(new Application.Product.Entity.Product("Arroz", 15));

            Assert.NotNull(result.Item1);

            var getResult = productRepository.Get(result.Item1.GetId());

            Assert.Equal(getResult.Item1.GetId(), result.Item1.GetId());
        }

        [Fact]
        public void ProductRepository_WhenGettingAInexistingProduct_ReturnsAException()
        {
            var productRepository = new ProductAdapter();

            var getResult = productRepository.Get(Guid.NewGuid().ToString());

            Assert.NotNull(getResult.Item2);
        }
    }
}