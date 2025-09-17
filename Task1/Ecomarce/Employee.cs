using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Ecomarce
{
    internal class Employee : User
    {
        private static int _idCounter = 5000;

        public decimal Salary { get; set; }

        public Employee(string name, string email, string password, decimal salary)
        {
            Id = _idCounter++;
            Name = name;
            Email = email;
            Password = password;
            Salary = salary;
        }

        public override Role Access()
        {
            return Role.Employee;
        }
    }
}
