using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Ecomarce
{
    internal abstract class User
    {
        public int Id { get; protected set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreatedAt { get; private set; }

        public User()
        {
            CreatedAt = DateTime.Now;
        }

        public enum Role { Customer, Employee, Manager }

       
        public abstract Role Access();
    }
}
