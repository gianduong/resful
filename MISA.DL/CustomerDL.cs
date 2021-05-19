using MISA.Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Dapper;
using MySqlConnector;
using System.Linq;
using MISA.DL.interfaces;

namespace MISA.DL
{
    public class CustomerDL : BaseDL<Customer>, ICustomerDL
    {
        public bool CheckCustomerCodeExist(string customerCode)
        {
            _dbConnection = new MySqlConnection(_connectionString);
            // 3. Thực thi lệnh lấy dữ liệu trong Database:
            var sqlCommand = $"Proc_CheckCustomerCodeExists";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@m_CustomerCode", customerCode);
            var res = _dbConnection.ExecuteScalar<bool>(sqlCommand, dynamicParameters, commandType: CommandType.StoredProcedure);
            return res;
        }

        public bool CheckEmailExists(String Email)
        {
            _dbConnection = new MySqlConnection(_connectionString);
            // 3. Thực thi lệnh lấy dữ liệu trong Database:
            var sqlCommand = $"Proc_D_CheckCustomerEmailExist";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@d_Email", Email);
            var res = _dbConnection.ExecuteScalar<bool>(sqlCommand, dynamicParameters, commandType: CommandType.StoredProcedure);
            return res;
        }
    }
}
