using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfelDomain
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string EncryptedPassword { get; set; }
        public List<ConnectionWithUser> ConnectedPeople { get; set; } = new List<ConnectionWithUser>();
        public List<Income> Incomes { get; set; } = new List<Income>();
        public List<Expense> Expenses { get; set; } = new List<Expense>();
        public List<SavingGoal> SavingGoals { get; set; } = new List<SavingGoal>();
        public List<ShoppingList> shoppingLists { get; set; } = new List<ShoppingList>();
        public double Balance { get; set; }


        public User()
        {
            Balance = Incomes.Sum(x => x.sumOfIncome) - Expenses.Sum(x => x.Sum);
        }

    }
}
