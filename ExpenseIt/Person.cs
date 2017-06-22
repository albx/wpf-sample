using System.Collections.Generic;

namespace ExpenseIt
{
    public class Person
    {
        public string Name { get; set; }

        public string Department { get; set; }

        public IEnumerable<Expense> Expenses { get; set; }

        public class Expense
        {
            public string ExpenseType { get; set; }

            public double ExpenseAmount { get; set; }
        }
    }
}
