using System;
using System.Collections.Generic;
using System.Text;

namespace SQLDocker.Data.Entities
{
    public class Employee
    {
        public Guid Id { get; set; }
        public Guid ClientId { get; set; }
        public string FullName { get; set; }
        public DateTime CreatedOn { get; set; }
        public virtual Client Client { get; set; }
    }
}
