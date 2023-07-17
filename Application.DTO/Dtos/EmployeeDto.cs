using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.Dtos
{
    public class EmployeeDto
    {
        public EmployeeDto()
        {
        }

        public EmployeeDto(int id, int employeeId , string firstName, string lastName, string bithDate, string position)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            BithDate = bithDate;
            Position = position;
            EmployeeId = employeeId;
        }

        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BithDate { get; set; }
        public string Position { get; set; }
    }
}
