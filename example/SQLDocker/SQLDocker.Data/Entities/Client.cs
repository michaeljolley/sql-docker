using System;
using System.Collections.Generic;
using System.Text;

namespace SQLDocker.Data.Entities
{
    public class Client
    {
        public Client()
        {
            Addresses = new HashSet<Address>();
            // Employees = new HashSet<Employee>();
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public DateTime CreatedOn { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }

        //public virtual ICollection<Employee> Employees { get; set; }
    }
}
