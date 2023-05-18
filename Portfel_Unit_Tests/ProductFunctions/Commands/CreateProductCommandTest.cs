using Moq;
using Portfel.Application.Contracts.Persistance;
using Portfel.Application.Functions.ProductFunctions.Commands.CreateProduct;
using Portfel.Application.UnitTests.Helper;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfel.Application.UnitTests.ProductFunctions.Commands
{
    public class CreateProductCommandTest
    {
        private readonly IMock<IProductRepository> _mockRepository;

        public CreateProductCommandTest()
        {
            _mockRepository = GetProductHelper.GetMock();
        }
        [Fact]
        public async Task CreateProduct_ForValidModel_ReturnId()
        {
            var handler = new CreateProductCommandHandler(_mockRepository.Object);
            var productsBeforeCount = (await _mockRepository.Object.GetAll()).Count;

            var response = await handler.Handle(new CreateProductCommand
            {
                Name = "Test3",
                Price = 3000
            }, CancellationToken.None);

            var allProducts = (await _mockRepository.Object.GetAll()).Count;

            response.ShouldBeOfType(typeof(int));
            allProducts.ShouldBe(productsBeforeCount + 1);

        }
    }
}
