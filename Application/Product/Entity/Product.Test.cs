using Xunit;

namespace Application.Product.Entity
{
    public class ProductUnitTest
    {
        [Fact]
        public void ProductWithoutValue_WhenEnabled_ReturnError()
        {
            var mockProduct = new Product("Arroz", 0);

            Assert.Throws(typeof(Exception), () => mockProduct.Enable());
        }

        [Fact]
        public void ProductWithValue_WhenEnabled_ShoudHaveStatusEnabled()
        {
            var mockProduct = new Product("Arroz", 10);

            mockProduct.Enable();

            Assert.Equal(mockProduct.GetStatus(), Shared.Constants.Status.ENABLED);
        }

        [Fact]
        public void ProductWithValue_WhenDisabled_ReturnError()
        {
            var mockProduct = new Product("Arroz", 10);

            Assert.Throws(typeof(Exception), () => mockProduct.Disable());
        }

        [Fact]
        public void ProductWithoutValue_WhenDisabled_ShouldHaveStatusDisabled()
        {
            var mockProduct = new Product("Arroz", 0);

            mockProduct.Disable();

            Assert.Equal(mockProduct.GetStatus(), Shared.Constants.Status.DISABLED);
        }

        [Fact]
        public void Product_WhenCreatedWithoutName_ShouldBeInvalid()
        => Assert.Throws(typeof(Exception), () => new Product("", 0));

        [Fact]
        public void Product_WhenCreatedWithNegativeValue_ShouldBeInvalid()
            => Assert.Throws(typeof(Exception), () => new Product("AAA", -1));


        [Fact]
        public void Product_WhenCreatedWithName_ShouldBeValid()
        {
            var mockProduct = new Product("Arroz", 0);

            var isValid = mockProduct.IsValid();

            Assert.True(isValid.isValid);
        }
    }
}