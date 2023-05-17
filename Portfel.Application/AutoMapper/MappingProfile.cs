using AutoMapper;
using Portfel.Application.Functions.ExpenseFunctions.Query.GetAllExpenses;
using Portfel.Application.Functions.IncomeFunctions.Query.GetAllIncomes;
using PortfelDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfel.Application.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Expense, GetAllExpensesViewModel>();
            CreateMap<Income, GetAllIncomesViewModel>();
        }

    }
}
