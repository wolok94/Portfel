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
    public class GetIncomeHelper 
    {
        public static IMock<IIncomeRepository> GetMock()
        {
            var mock = new Mock<IIncomeRepository>();
            var incomes = GetIncomes();

            mock.Setup(x => x.AddAsync(It.IsAny<Income>())).ReturnsAsync((Income income) =>
            {
                incomes.Add(income);
                return income;
            });

            mock.Setup(x => x.GetAll()).ReturnsAsync(incomes);

            return mock;
        }

        private static List<Income> GetIncomes()
        {
            return new List<Income>
            {
                new Income
                {
                    Id = 1,
                    incomeDate = DateTime.Now,
                    nameOfIncome = "Wypłata",
                    sumOfIncome = 5000,
                    UserId =1
                },
                new Income
                {
                    Id = 2,
                    incomeDate = DateTime.Now,
                    nameOfIncome = "Nagroda",
                    sumOfIncome = 100000,
                    UserId =1
                }
            };
        }
    }
}
