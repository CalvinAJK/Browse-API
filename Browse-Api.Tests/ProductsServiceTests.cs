using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading;
using System.Threading.Tasks;
using Browse_API.Services.Products;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Moq.Protected;

namespace Browse_API.Tests
{
    [TestClass]
    public class ProductsServiceTests
    {
        [TestMethod]
        public async Task GetProductsAsync_ShouldReturnListOfProducts()
        {
            // Arrange
            var configurationMock = new Mock<IConfiguration>();
            configurationMock.Setup(c => c["WebServices:UnderCutters:BaseURL"]).Returns("http://example.com");

            var expectedProducts = new List<ProductDTO>
            {
                new ProductDTO { Id = 1, Name = "Product 1", Description = "Description 1" },
                new ProductDTO { Id = 2, Name = "Product 2", Description = "Description 2" },
            };

            var httpClientHandlerMock = new Mock<HttpMessageHandler>();
            httpClientHandlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new ObjectContent(typeof(IEnumerable<ProductDTO>), expectedProducts, new JsonMediaTypeFormatter())
                });

            var httpClient = new HttpClient(httpClientHandlerMock.Object);

            var productService = new ProductsService(httpClient, configurationMock.Object);

            // Act
            var result = await productService.GetProductsAsync();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedProducts.Count, result.ToList().Count);
        }
    }
}
