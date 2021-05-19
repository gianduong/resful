using MISA.BL.Exceptions;
using MISA.BL.interfaces;
using MISA.Common.Entities;
using MISA.DL.interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace MISA.BL
{
    public class EmployeeBL:BaseBL<Employee>, IEmployeeBL
    {
        IEmployeeDL _baseDL;
        public EmployeeBL(IEmployeeDL baseDL):base(baseDL)
        {
            _baseDL = baseDL;
        }

        protected override void ValidateCustom(Employee entity)
        {
            if (entity is Employee)
            {
                var employee = entity as Employee;

                // 2. Check mã khách hàng đã tồn tại hay chưa?
                var isExists = _baseDL.CheckEmployeeCodeExist(employee.EmployeeCode);
                if (isExists == true)
                {
                    throw new GuardException<Employee>("Mã nhân viên đã tồn tại trong hệ thống, vui lòng kiểm tra lại", null);
                }

                // 3. Kiểm tra Email có đúng định dạng hay không?
                var emailTemplate = @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?";
                if (!Regex.IsMatch(employee.Email, emailTemplate))
                {
                    throw new GuardException<Employee>("Email không đúng định dạng, vui lòng kiểm tra lại", null);
                }

                if (_baseDL.CheckEmailExists(employee.Email))
                {
                    throw new GuardException<Customer>("Email đã tồn tại trong hệ thống, vui lòng kiểm tra lại", null);
                }

                if (_baseDL.CheckIdentifyNumberExists(employee.IdentifyNumber))
                {
                    throw new GuardException<Employee>("Chứng minh thư này đã tồn tại trong hệ thống, vui lòng kiểm tra lại", null);
                }
            }
        }

        public String GenNewEmployeeCode()
        {
            String NewCode = "";
            var Employeecode = _baseDL.GenEmployeeCode();
            if(Employeecode is String)
            {
                if (Employeecode != "")
                {
                    String[] split = Employeecode.Split("-");
                    try
                    {
                        int newCode = Int32.Parse(split[1]) + 1;
                        NewCode = split[0] + "-" + newCode;
                    }
                    catch
                    {
                        throw new GuardException<Employee>("Lỗi hệ thống, vui lòng kiểm tra lại sau!", null);
                    }
                }
            }
            return NewCode;
        }

        public IEnumerable<Employee> SearchEmployees(string name)
        {
            return _baseDL.SearchEmployees(name);
        }

        public bool CheckEmployeeCodeExist(string Code)
        {
            return _baseDL.CheckEmployeeCodeExist(Code);
        }

        public IEnumerable<Employee> SearchByDepartmentId(Guid department)
        {
            return _baseDL.SearchByDepartmentId(department);
        }
    }
}
