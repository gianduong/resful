using MISA.Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using MISA.DL;
using MISA.BL.Exceptions;
using MISA.DL.interfaces;
using MISA.BL.interfaces;

namespace MISA.BL
{
    public class CustomerGroupBL:BaseBL<CustomerGroup>,ICustomerGroupBL
    {
        public CustomerGroupBL(ICustomerGroupDL baseDL):base(baseDL)
        {

        }
        protected override void ValidateCustom(CustomerGroup entity)
        {
            base.ValidateCustom(entity);
        }

    }
}
