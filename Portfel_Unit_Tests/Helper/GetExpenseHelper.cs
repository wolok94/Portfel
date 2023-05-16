using Moq;
using Portfel.Application.Contracts.Persistance;
using Portfel.Application.Functions.ExpenseFunctions.Query.GetAllExpenses;
using PortfelDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfel.Application.UnitTests.Helper
{
    public class GetExpenseHelper
    {
        public static IMock<IExpenseRepository> GetMock()
        {
            var expenses = GetExpenses();
            var mock = new Mock<IExpenseRepository>();
            mock.Setup(x => x.AddAsync(It.IsAny<Expense>())).ReturnsAsync((Expense expense) =>
            {
                expenses.Add(expense);
                return expense;
            });

            mock.Setup(x => x.GetAll()).ReturnsAsync(expenses);


            return mock;
        }
        private static List<Expense> GetExpenses()
        {
            var products = new List<Product>
                    {
                        new Product
                        {
                            Id = 1,
                            Name = "Test",
                            Price = 100,
                            Amount = 2,
                        }
                    };
            var expenses = new List<Expense>
            {
                new Expense()
                {
                    DateOfPurchase = DateTime.Now,
                    Id = 1,
                    Products = products
                }
            };
            return expenses;
        }
    }
}
