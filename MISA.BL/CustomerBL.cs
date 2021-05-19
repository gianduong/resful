using MISA.BL.Exceptions;
using MISA.BL.interfaces;
using MISA.Common.Attributes;
using MISA.Common.Entities;
using MISA.DL;
using MISA.DL.interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace MISA.BL
{
    public class CustomerBL : BaseBL<Customer>,ICustomerBL
    {
        ICustomerDL _customerDL;

        public CustomerBL(ICustomerDL baseDL): base(baseDL) 
        {
            _customerDL = baseDL;
        }
        protected override void ValidateCustom(Customer entity)
        {
            if(entity is Customer)
            {
                var customer = entity as Customer;

                // 2. Check mã khách hàng đã tồn tại hay chưa?
                var isExists = _customerDL.CheckCustomerCodeExist(customer.CustomerCode);
                if (isExists == true)
                {
                    throw new GuardException<Customer>("Mã khách hàng đã tồn tại trong hệ thống, vui lòng kiểm tra lại", null);
                }

                // 3. Kiểm tra Email có đúng định dạng hay không?
                var emailTemplate = @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?";
                if (!Regex.IsMatch(customer.Email, emailTemplate))
                {
                    throw new GuardException<Customer>("Email không đúng định dạng, vui lòng kiểm tra lại", null);
                }

                if (_customerDL.CheckEmailExists(customer.Email))
                {
                    throw new GuardException<Customer>("Email đã tồn tại trong hệ thống, vui lòng kiểm tra lại", null);
                }
            }
        }
    }
}
