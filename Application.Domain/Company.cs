using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Domain
{
    public class Company
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string City { get; set;}
        public string Address { get; set;}
        public string State { get; set;}
        public string Phone { get; set;}
        public ICollection<Employee> Employees { get;}
    }
}
