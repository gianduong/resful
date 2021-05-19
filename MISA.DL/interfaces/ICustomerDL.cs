using MISA.Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.DL.interfaces
{
    public interface ICustomerDL:IBaseDL<Customer>
    {
        bool CheckCustomerCodeExist(string customerCode);
        bool CheckEmailExists(String email);
    }
}
