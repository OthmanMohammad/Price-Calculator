using System.Collections.Generic;

namespace PriceCalculator
{
    public class Expenses
    {

        public List<IExpense> Expense = new List<IExpense>();
        public Expenses()
        {

        }
        public Expenses(List<IExpense> Expense)
        {
            this.Expense = Expense;
        }
        public void AddExpense(IExpense expense)
        {
            Expense.Add(expense);
        }
        public void AddRangeExpense(IExpense expense)
        {
            Expense.Add(expense);
        }
        public void DisplayResult()
        {
            Expense.ForEach(exp =>
            {
                Console.WriteLine($"{exp.Name} = {exp.Amount}");
            });
        }
    }
}
