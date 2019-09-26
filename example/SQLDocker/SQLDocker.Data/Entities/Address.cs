using System;
using System.Collections.Generic;
using System.Text;

namespace SQLDocker.Data.Entities
{
    public class Address
    {
        public Guid Id { get; set; }
        public Guid ClientId { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public DateTime CreatedOn { get; set; }
        public virtual Client Client { get; set; }
    }
}
