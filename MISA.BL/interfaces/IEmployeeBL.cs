using MISA.Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.BL.interfaces
{
    public interface IEmployeeBL:IBaseBL<Employee>
    {
        public String GenNewEmployeeCode();
        IEnumerable<Employee> SearchEmployees(String name);
        IEnumerable<Employee> GetPaging(int pageIndex, int pageSize);
        public bool CheckEmployeeCodeExist(string Code);
        public IEnumerable<Employee> SearchByDepartmentId(Guid department);
    }
}
