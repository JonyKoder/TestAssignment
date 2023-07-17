using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.Dtos
{
    public class CompanyDto
    {
        public CompanyDto()
        {

        }
        public CompanyDto(int id, string name, string city, string state, string phone)
        {
            Id = id;
            Name = name;
            City = city;
            State = state;
            Phone = phone;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Phone { get; set; }
    }
}
