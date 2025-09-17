using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Ecomarce
{
    internal class Manager : User
    {
        private static int _idCounter = 9000;

        public string Department { get; set; }

        public Manager(string name, string email, string password, string department)
        {
            Id = _idCounter++;
            Name = name;
            Email = email;
            Password = password;
            Department = department;
        }

        public override Role Access()
        {
            return Role.Manager;
        }
    }
}
