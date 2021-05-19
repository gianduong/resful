using MISA.Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.DL.interfaces
{
    public interface IEmployeeDL: IBaseDL<Employee>
    {
        bool CheckEmployeeCodeExist(string customerCode);
        bool CheckEmailExists(String email);
        bool CheckIdentifyNumberExists(String IdentifyNumber);
        string GenEmployeeCode();
        IEnumerable<Employee> SearchEmployees(String name);
        IEnumerable<Employee> GetPaging(int pageIndex, int pageSize);
        public IEnumerable<Employee> SearchByDepartmentId(Guid department);
    }
}
