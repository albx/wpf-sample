using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseIt
{
    public class ExpenseService
    {
        private IList<string> _expenseTypes;

        public ExpenseService()
        {
            _expenseTypes = new List<string>
            {
                "Lunch", "Transportation", "Document printing", "Gift", "Magazine subscription",
                "New machine", "Software", "Dinner"
            };
        }

        public IEnumerable<Person> GetExpenses()
        {
            try
            {
                var expenses = new List<Person>();
                for (int i = 0; i < 10; i++)
                {
                    var person = CreatePerson(i);
                    expenses.Add(person);
                }

                return expenses;
            }
            catch 
            {
                throw;
            }
        }

        private Person CreatePerson(int index)
        {
            var rand = new Random();

            var person = new Person
            {
                Name = $"Name {index}",
                Department = $"Dep. {index}"
            };

            int expenseNumber = rand.Next(1, 5);

            var expenseList = new List<Person.Expense>();
            for (int i = 0; i < expenseNumber; i++)
            {
                var type = rand.Next(_expenseTypes.Count);

                var item = new Person.Expense
                {
                    ExpenseType = _expenseTypes[type],
                    ExpenseAmount = rand.Next(10, 1000)
                };
                expenseList.Add(item);
            }

            person.Expenses = expenseList;
            return person;
        }
    }
}
