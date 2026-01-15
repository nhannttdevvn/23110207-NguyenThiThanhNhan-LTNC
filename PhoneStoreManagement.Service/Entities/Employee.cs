using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneStoreManagement.Domain.Entities
{
    public class Employee
    {
        public string EmployeeCode { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string HomeTown { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
