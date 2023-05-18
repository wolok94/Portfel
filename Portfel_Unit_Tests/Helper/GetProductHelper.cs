using Moq;
using Portfel.Application.Contracts.Persistance;
using PortfelDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfel.Application.UnitTests.Helper
{
    public class GetProductHelper
    {
        public static IMock<IProductRepository> GetMock()
        {
            var mock = new Mock<IProductRepository>();
            var products = GetProducts();

            mock.Setup(x => x.GetAll()).ReturnsAsync(products);
            mock.Setup(x => x.AddAsync(It.IsAny<Product>())).ReturnsAsync((Product product) =>
            {
                products.Add(product);
                return product;
            });

            return mock;
        }
        private static List<Product> GetProducts()
        {
            return new List<Product>
            {
                new Product
                {
                    Id = 1,
                    Name = "Test",
                    Price = 1500
                },
                new Product
                {
                    Id = 2,
                    Name = "Test2",
                    Price = 2000
                }
            };
        } 
    }
}
