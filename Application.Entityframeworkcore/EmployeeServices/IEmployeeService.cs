using Application.DTO.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Entityframeworkcore.EmployeeServices
{
    public interface IEmployeeService
    {
        Task<List<EmployeeDto>> GetListAsync();
        Task<List<EmployeeDto>> GetListByCompanyIdAsync(int companyId);
    }
}
